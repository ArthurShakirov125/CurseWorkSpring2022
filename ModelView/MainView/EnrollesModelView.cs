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
    public class EnrollesModelView : BaseModelView
    {
        public List<string> Groups { get; set; }
        public List<string> Flows { get; set; }

        public EnrollesModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
            enrolleModles = _db.EnrolleeSet.ToList().Select(e => new EnrolleModleView(e));

            Flows = _db.FlowSet.Select(f => f.Name).ToList();
            Groups = _db.GroupSet.Select(g => g.Name).ToList();
            
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
        private RelayCommand redactEnrolle;

        public EnrolleModleView SelectedEnrolle
        {
            get { return selectedEnrolle; }
            set 
            { 
                selectedEnrolle = value;
                OnPropertyChanged();
            }
        }

        public int[] days { get; set; }

        public int SelectedDay { get; set; }

        public int[] months { get; set; }

        public int SelectedMonth { get; set; }

        public int[] years { get; set; }

        public int SelectedYear { get; set; }

        public void initializeDates()
        {
            days = new int[31];

            for (int i = 0; i < 31; i++)
            {
                days[i] = i + 1;
            }

            months = new int[12];
            for (int i = 0; i < 12; i++)
            {
                months[i] = i + 1;
            }

            years = new int[50];

            for (int i = 0; i < 50; i++)
            {
                years[i] = 1980 + i;
            }
            SelectedDay = SelectedEnrolle.EnrolleGraduationDateTime.Day;
            SelectedMonth = SelectedEnrolle.EnrolleGraduationDateTime.Month;
            SelectedYear = SelectedEnrolle.EnrolleGraduationDateTime.Year;
        }



        public RelayCommand RedactNewUser
        {
            get
            {
                return redactEnrolle ??
                    (redactEnrolle = new RelayCommand(SaveChanges));
            }
        }
        public void SaveChanges(object obj)
        {
            Enrollee enrollee = _db.EnrolleeSet.Where(u => u.Id == SelectedEnrolle.enrolee.Id).First();

            enrollee.Name = selectedEnrolle.EnrolleName;
            enrollee.Surname = selectedEnrolle.EnrolleSurename;
            enrollee.Lastname = selectedEnrolle.EnrolleLastname;
            enrollee.Passport = selectedEnrolle.EnrollePassport;
            enrollee.Education = selectedEnrolle.EnrolleEducation;
            enrollee.Golden_medal = selectedEnrolle.EnrolleGoldenMedal;
            enrollee.Silver_medal = selectedEnrolle.EnrolleSilverMedal;
            enrollee.Exam_sheet = _db.Exam_sheetSet.First(e => e.Group.Name == SelectedEnrolle.EnrolleGroup);

            string date = string.Join("/", SelectedDay, SelectedMonth, SelectedYear);
            enrollee.Graduation = DateTime.Parse(date);
            selectedEnrolle.EnrolleGraduation = date;

            _db.SaveChanges();
            MessageBox.Show("Изменение произведено успешно");
        }

    }
}
