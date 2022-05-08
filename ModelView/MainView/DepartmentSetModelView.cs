using AdmissionsCommittee.Abstract;
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
            _db = new DataBase.AdmissionsCommitteeDBContainer();
            Departments = _db.DepartmentSet.ToList().Select(d => new DepartmentModelView(d));

        }


    }
}
