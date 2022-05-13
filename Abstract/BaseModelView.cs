using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.Abstract
{
    public abstract class BaseModelView : INotifyPropertyChanged
    {

        protected RelayCommand createNewUser;
        protected RelayCommand redactNewUser;
        protected RelayCommand deleteSelectedUser;


        public RelayCommand CreateNewUser
        {
            get
            {
                return createNewUser ??
                    (createNewUser = new RelayCommand(Add));
            }
        }

        public RelayCommand RedactNewUser
        {
            get
            {
                return redactNewUser ??
                    (redactNewUser = new RelayCommand(Redact));
            }
        }
        public RelayCommand DeleteSelectedUser
        {
            get
            {
                return deleteSelectedUser ??
                    (deleteSelectedUser = new RelayCommand(Delete));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected AdmissionsCommitteeDBContainer _db;

        public BaseModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public abstract void Add(object obj);

        public abstract void Redact(object obj);

        public abstract void Delete(object obj);
    }
}
