using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class DepartmentModelView : EntityModelView<Department>
    {
        public DepartmentModelView(Department model) : base(model)
        {
        }

        public Department Department 
        {
            get { return _model; }
        }

        public string Name
        {
            get { return _model.Name; }
            set 
            { 
                _model.Name = value;
                OnPropertyChanged();
            }
        }

        public string Faculty
        {
            get { return _model.Faculty.Name; }
            set
            {
                _model.Faculty = _db.FacultySet.First(f => f.Name == value);
                OnPropertyChanged();
            }
        }

    }
}
