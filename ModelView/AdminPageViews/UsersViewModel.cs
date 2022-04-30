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
    public class UsersViewModel : BaseViewModel
    {
        protected RelayCommand createNewUser;

        protected List<User> rawUsers { get; set; }

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
        public UserViewModel NewUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        private AdmissionsCommitteeDBContainer _db;
        public UsersViewModel()
        {
            _db = new AdmissionsCommitteeDBContainer();

            rawUsers = _db.UserSet.ToList();

            Users = rawUsers.Select(u => new UserViewModel(u));

            var User = new User();

            _newUser = new UserViewModel(User);

        }

        public RelayCommand CreateNewUser
        {
            get
            {
                return createNewUser ??
                    (createNewUser = new RelayCommand(AddUser));
            }
        }

        public void AddUser(object obj)
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
    }
}
