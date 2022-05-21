using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using AdmissionsCommittee.View.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class EnrollesModelView : BaseModelView
    {
        public List<string> Groups { get; set; }
        public List<string> Flows { get; set; }

        private Dates _dates;

        public Dates Date
        {
            get { return _dates; }
            set { _dates = value; }
        }


        public EnrollesModelView()
        {
            enrolleModles = _db.EnrolleeSet.ToList().Select(e => new EnrolleModleView(e));

            Flows = _db.FlowSet.Select(f => f.Name).ToList();
            Groups = _db.GroupSet.Select(g => g.Name).ToList();

            _dates = new Dates();
            
        }

        private IEnumerable<EnrolleModleView> enrolleModles;

        public IEnumerable<EnrolleModleView> EnrolleModles
        {
            get { return enrolleModles; }
            set
            {
                enrolleModles = value;
                OnPropertyChanged();
            }
        }

        private EnrolleModleView selectedEnrolle;

        public EnrolleModleView SelectedEnrolle
        {
            get { return selectedEnrolle; }
            set 
            { 
                selectedEnrolle = value;
                OnPropertyChanged();
            }
        }



        public void initializeDates()
        {
            _dates.SelectedDay = SelectedEnrolle.EnrolleGraduationDateTime.Day;
            _dates.SelectedMonth = SelectedEnrolle.EnrolleGraduationDateTime.Month;
            _dates.SelectedYear = SelectedEnrolle.EnrolleGraduationDateTime.Year;
        }

        protected override void Redact(object obj)
        {
            Enrollee enrollee = _db.EnrolleeSet.Where(u => u.Id == SelectedEnrolle.enrolee.Id).First();

            enrollee.Name = selectedEnrolle.EnrolleName;
            enrollee.Surname = selectedEnrolle.EnrolleSurename;
            enrollee.Lastname = selectedEnrolle.EnrolleLastname;
            enrollee.Passport = selectedEnrolle.EnrollePassport;
            enrollee.Education = selectedEnrolle.EnrolleEducation;
            enrollee.Golden_medal = selectedEnrolle.EnrolleGoldenMedal;
            enrollee.Silver_medal = selectedEnrolle.EnrolleSilverMedal;

            string date = string.Join("/", _dates.SelectedDay, _dates.SelectedMonth, _dates.SelectedYear);
            enrollee.Graduation = DateTime.Parse(date);
            selectedEnrolle.EnrolleGraduation = date;


            _db.SaveChanges();
            MessageBox.Show("Изменение произведено успешно");
        }

        protected override void Add(object obj)
        {
            Enrollee enrollee = new Enrollee();

            enrollee.Name = selectedEnrolle.EnrolleName;
            enrollee.Surname = selectedEnrolle.EnrolleSurename;
            enrollee.Lastname = selectedEnrolle.EnrolleLastname;
            enrollee.Passport = selectedEnrolle.EnrollePassport;
            enrollee.Education = selectedEnrolle.EnrolleEducation;
            enrollee.Golden_medal = selectedEnrolle.EnrolleGoldenMedal;
            enrollee.Silver_medal = selectedEnrolle.EnrolleSilverMedal;

            string date = string.Join("/", _dates.SelectedDay, _dates.SelectedMonth, _dates.SelectedYear);
            enrollee.Graduation = DateTime.Parse(date);

            Exam_sheet _Sheet = new Exam_sheet()
            {
                Enrollee = enrollee,
                Group = _db.GroupSet.First(g => g.Name == selectedEnrolle.EnrolleGroup)
            };
            _db.Exam_sheetSet.Add(_Sheet);

            enrollee.Exam_sheet = _Sheet;

            _db.EnrolleeSet.Add(enrollee);
            _db.SaveChanges();

            MessageBox.Show("Изменение произведено успешно");

        }

        protected override void Delete(object obj)
        {
            var enrl = _db.EnrolleeSet.Find(SelectedEnrolle.enrolee.Id);
            _db.EnrolleeSet.Remove(enrl);
            _db.SaveChanges();
        }

        protected override void Clear(object obj)
        {
            SelectedEnrolle = new EnrolleModleView(new Enrollee());
        }
    }
}
