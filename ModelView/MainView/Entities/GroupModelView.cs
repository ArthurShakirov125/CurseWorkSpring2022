using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class GroupModelView : EntityModelView<Group>
    {
        public GroupModelView(Group model) : base(model)
        {
        }


        public Group Group
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

        public string Flow
        {
            get { return _model.Flow.Name; }
            set
            {
                var flow = _db.FlowSet.Where(f => f.Name == value).First();

                _model.Exam_sheet.Group.Flow = flow;
                _db.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string Department
        {
            get { return _model.Flow.Department.Name; }
            set
            {
                var department = _db.DepartmentSet.Where(d => d.Name == value).First();

                _model.Flow.Department = department;
                _db.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string Faculty
        {
            get { return _model.Flow.Department.Faculty.Name; }
            set
            {
                var faculty = _db.FacultySet.Where(f => f.Name == value).First();

                _model.Flow.Department.Faculty = faculty;
                _db.SaveChanges();
                OnPropertyChanged();
            }
        }

    }
}
