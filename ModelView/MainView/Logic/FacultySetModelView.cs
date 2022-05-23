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


        protected override void Clear(object obj)
        {
            Faculty = new FacultyModelView(new Faculty());
        }

        public FacultySetModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
            Faculties = _db.FacultySet.ToList().Select(f => new FacultyModelView(f));
            Faculty = new FacultyModelView(new Faculty());
        }

        protected override void Add(object obj)
        {
            if (Faculty.Name == null)
            {
                MessageBox.Show("Пожалуйста заполните все поля");
                return;
            }
            var fac = new Faculty()
            {
                Name = Faculty.Name,
                Competition = Faculty.Competition,
            };

            _db.FacultySet.Add(fac);
            _db.SaveChanges();
            Faculties = _db.FacultySet.ToList().Select(f => new FacultyModelView(f));
            MessageBox.Show("Добавление выполнено успешно");
        }

        protected override void Redact(object obj)
        {
            if (Faculty.Name == null)
            {
                MessageBox.Show("Пожалуйста заполните все поля");
                return;
            }
            _db.SaveChanges();
            MessageBox.Show("Редактирование выполнено успешно");
        }

        protected override void Delete(object obj)
        {
            var Facul = _db.FacultySet.Find(selectedFaculty.Faculty.Id);
            _db.FacultySet.Remove(Facul);
            _db.SaveChanges();
            Faculties = _db.FacultySet.ToList().Select(f => new FacultyModelView(f));
            MessageBox.Show("Удаление выполнено успешно");
        }
    }
}
