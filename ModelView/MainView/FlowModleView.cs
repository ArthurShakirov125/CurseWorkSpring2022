using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class FlowModleView : EntityModelView<Flow>
    {
        public FlowModleView(Flow model) : base(model)
        {
        }

        public Flow Flow
        {
            get { return _model; }
            set { _model = value; }
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

        public string Department
        {
            get { return _model.Department.Name; }
            set
            {
                var department = _db.DepartmentSet.Where(d => d.Name == value).First();

                _model.Department = department;
                _db.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string Faculty
        {
            get { return _model.Department.Faculty.Name; }
            set
            {
                var faculty = _db.FacultySet.Where(f => f.Name == value).First();

                _model.Department.Faculty = faculty;
                _db.SaveChanges();
                OnPropertyChanged();
            }
        }

    }
}
