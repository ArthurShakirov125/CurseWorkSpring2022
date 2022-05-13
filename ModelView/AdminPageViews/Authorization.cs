using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using AdmissionsCommittee.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace AdmissionsCommittee.ModelView.AdminPageViews
{
    public class Authorization : BaseModelView
    {
        protected RelayCommand _authorizationCommand;

        public RelayCommand TryTo
        {
            get
            {
                return _authorizationCommand ??
                    (_authorizationCommand = new RelayCommand(Try));
            }
        }

        private void Try(object obj)
        {
            if(UserSet.Any(u => u.Login == User.Login))
            {
                User user = UserSet.Where(u => u.Login == User.Login).First();
                string pass = Securitytron.MadeHashCode(User.Password);
                if(user.Password == pass)
                {
                    _navigationService.Navigate(new MainPage(_navigationService));
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя");
            }
        }

        public override void Add(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            throw new NotImplementedException();
        }

        protected UserViewModel _user;

        public UserViewModel User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        protected DbSet<User> UserSet;
        private NavigationService _navigationService;


        public Authorization(NavigationService navigationService)
        {
            _user = new UserViewModel(new User());
            _db = new AdmissionsCommitteeDBContainer();
            UserSet = _db.UserSet;
            _navigationService = navigationService;
        }
    }
}
