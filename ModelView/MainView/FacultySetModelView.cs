using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class FacultySetModelView : BaseModelView
    {
        private IEnumerable<FacultyModelView> _faculties;

        public IEnumerable<FacultyModelView> Faculties
        {
            get { return _faculties; }
            set 
            { 
                _faculties = value;
                OnPropertyChanged();
            }
        }

        private FacultyModelView selectedFaculty;

        public FacultyModelView Faculty
        {
            get { return selectedFaculty; }
            set 
            { 
                selectedFaculty = value;
                OnPropertyChanged();
            }
        }


        public FacultySetModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
            Faculties = _db.FacultySet.ToList().Select(f => new FacultyModelView(f));
        }




    }
}
