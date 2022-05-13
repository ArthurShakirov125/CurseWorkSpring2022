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

        public override void Add(object obj)
        {
            var fac = new Faculty()
            {
                Name = selectedFaculty.Name,
                Competition = selectedFaculty.Competition,
            };

            _db.FacultySet.Add(fac);
            _db.SaveChanges();
        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            var Facul = _db.FacultySet.Find(selectedFaculty.Faculty.Id);
            _db.FacultySet.Remove(Facul);
            _db.SaveChanges();
        }
    }
}
