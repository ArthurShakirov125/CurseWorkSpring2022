using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using AdmissionsCommittee.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdmissionsCommittee.ModelView.AdminPageViews
{
    public class UsersViewModel : BaseModelView
    {


        protected RelayCommand takeSelectedUser;

        public IEnumerable<UserViewModel> _users;

        public IEnumerable<UserViewModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        protected UserViewModel _selectedUser;

        public UserViewModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        protected UserViewModel _newUser;

        private string _selectedUserLogin;

        public string Password { get; set; }

        public UserViewModel NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }
        

        public UsersViewModel()
        {
            _db = new AdmissionsCommitteeDBContainer();

            Users = _db.UserSet.ToList().Select(u => new UserViewModel(u));

            _newUser = new UserViewModel(new User());

        }
        public RelayCommand TakeSelectedUser
        {
            get
            {
                return takeSelectedUser ??
                    (takeSelectedUser = new RelayCommand(takeUser));
            }
        }
        protected override void Delete(object obj)
        {
            _db.UserSet.Remove(SelectedUser.User);
            Users = Users.Where(u => u.Login != SelectedUser.Login);
            _db.SaveChanges();
            MessageBox.Show("Изменение произведено успешно");
        }

        private void takeUser(object obj)
        {
            _selectedUserLogin = SelectedUser.Login;
        }

        protected override void Redact(object obj)
        {
            User user = _db.UserSet.Where(u => u.Login == _selectedUserLogin).First();
            user.Login = SelectedUser.Login;
            user.Password = Securitytron.MadeHashCode(Password);
            Password = "";
            _db.SaveChanges();
            MessageBox.Show("Изменение произведено успешно");
        }

        protected override void Add(object obj)
        {
            if (Users.Any(user => user.Login == NewUser.Login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
            }
            else
            {
                var newuser = new UserViewModel(new User()
                    { 
                      Login = NewUser.Login,
                      Password = Securitytron.MadeHashCode(NewUser.Password)
                    });

                Users = Users.Append(newuser);
                _db.UserSet.Add(newuser.User);
                _db.SaveChanges();
                MessageBox.Show("Пользователь добавлен успешно");
            }
        }

        protected override void Clear(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
