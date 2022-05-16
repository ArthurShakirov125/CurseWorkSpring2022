using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


        private IEnumerable<string> faculties;

        public IEnumerable<string> Faculties
        {
            get { return faculties; }
            set 
            {
                faculties = value;
            }
        }

        public DepartmentSetModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
            Departments = _db.DepartmentSet.ToList().Select(d => new DepartmentModelView(d));
            Faculties = _db.FacultySet.Select(f => f.Name).ToList();
            DepartmentModel = new DepartmentModelView(new Department() { Faculty = new Faculty()});

        }

        protected override void Add(object obj)
        {
            var dep = new Department()
            {
                Name = DepartmentModel.Name,
                Faculty = _db.FacultySet.First(f => f.Name == departmentModel.Faculty),
            };

            _db.DepartmentSet.Add(dep);
            _db.SaveChanges();
            MessageBox.Show("Добавленеи выполнено успешно");
            Departments = _db.DepartmentSet.ToList().Select(d => new DepartmentModelView(d));
        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
        }

        protected override void Delete(object obj)
        {
            var dep = _db.DepartmentSet.Find(departmentModel.Department.Id);
            _db.DepartmentSet.Remove(dep);
            _db.SaveChanges();
            MessageBox.Show("Удаление выполнено успешно");
            Departments = _db.DepartmentSet.ToList().Select(d => new DepartmentModelView(d));
        }

        protected override void Clear(object obj)
        {
            DepartmentModel = new DepartmentModelView(new Department() 
            { Faculty = new Faculty()});
        }
    }
}
