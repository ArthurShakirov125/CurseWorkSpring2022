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

        protected RelayCommand create;
        protected RelayCommand redact;
        protected RelayCommand delete;
        protected RelayCommand clearCommand;

        public RelayCommand ClearCommand
        {
            get
            {
                return clearCommand ??
                    (clearCommand = new RelayCommand(Clear));
            }
        }

        

        public RelayCommand CreateNew
        {
            get
            {
                return create ??
                    (create = new RelayCommand(Add));
            }
        }

        public RelayCommand RedactCommand
        {
            get
            {
                return redact ??
                    (redact = new RelayCommand(Redact));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return delete ??
                    (delete = new RelayCommand(Delete));
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

        protected abstract void Add(object obj);

        protected abstract void Redact(object obj);

        protected abstract void Delete(object obj);

        protected abstract void Clear(object obj);
    }
}
