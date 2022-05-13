using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class DepartmentSetModelView : BaseModelView
    {
        private IEnumerable<DepartmentModelView> departments;

        public IEnumerable<DepartmentModelView> Departments
        {
            get { return departments; }
            set 
            { 
                departments = value;
                OnPropertyChanged();
            }
        }

        private DepartmentModelView departmentModel;

        public DepartmentModelView DepartmentModel
        {
            get { return departmentModel; }
            set 
            { 
                departmentModel = value;
                OnPropertyChanged();
            }
        }

        public DepartmentSetModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
            Departments = _db.DepartmentSet.ToList().Select(d => new DepartmentModelView(d));

        }

        public override void Add(object obj)
        {
            var dep = new Department()
            {
                Name = DepartmentModel.Name,
                Faculty = _db.FacultySet.First(f => f.Name == DepartmentModel.Faculty),
            };

            _db.DepartmentSet.Add(dep);
            _db.SaveChanges();
        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            var dep = _db.DepartmentSet.Find(departmentModel.Department.Id);
            _db.DepartmentSet.Remove(dep);
            _db.SaveChanges();
        }
    }
}
