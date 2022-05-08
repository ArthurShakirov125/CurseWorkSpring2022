using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView
{
    public class UserViewModel : EntityModelView<User>
    {
        public UserViewModel(User model) : base(model)
        {
        }

        public User User
        {
            get { return _model; }
        }


        public string Login
        {
            get { return _model.Login; }
            set 
            { 
                _model.Login = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _model.Password; }
            set
            {
                _model.Password = value;
                OnPropertyChanged();
            }
        }
    }
}
