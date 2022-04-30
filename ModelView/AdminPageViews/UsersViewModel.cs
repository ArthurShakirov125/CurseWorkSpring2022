using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
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

        protected List<User> rawUsers;
        public IEnumerable<UserViewModel> Users { get; set; }

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

        public UsersViewModel()
        {
            var db = new AdmissionsCommitteeDBContainer();

            rawUsers = db.UserSet.ToList();

            Users = rawUsers.Select(u => new UserViewModel(u));

            var User = new User() 
            {
                Login = "Admin",
                Password = "0000"
            };

            _newUser = new UserViewModel(User);

     
        }

        public RelayCommand CreateNewUser
        {
            get
            {
                return createNewUser ??
                    (createNewUser = new RelayCommand(SaveExecute));
            }
        }
        public void SaveExecute(object obj)
        {
            MessageBox.Show($"{_newUser.Login}, {_newUser.Password}");
        }





    }
}
