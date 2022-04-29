using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.AdminPageViews
{
    public class UsersViewModel : BaseViewModel
    {
        protected List<User> rawUsers;
        public IEnumerable<UserViewModel> Users { get; set; }

        public UserViewModel userViewModel;

        public UsersViewModel()
        {
            var db = new AdmissionsCommitteeDBContainer();

            rawUsers = db.UserSet.ToList();

            Users = rawUsers.Select(u => new UserViewModel(u));
     
        }

        public UserViewModel SelectedUser
        {
            get { return userViewModel; }
            set
            { 
                userViewModel = value;
                OnPropertyChanged();
            }
        }

    }
}
