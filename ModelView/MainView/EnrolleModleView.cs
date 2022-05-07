using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class EnrolleModleView : EntityViewModel<Enrollee>
    {
        public EnrolleModleView(Enrollee model) : base(model)
        {
        }

        public Enrollee enrolee
        {
            get { return _model; }
        }

        public string EnrolleName
        {
            get { return _model.Name; }
            set
            {
                _model.Name = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleSurename
        {
            get { return _model.Surname; }
            set
            {
                _model.Surname = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleLastname
        {
            get { return _model.Lastname; }
            set
            {
                _model.Lastname = value;
                OnPropertyChanged();
            }
        }

        public string EnrollePassport
        {
            get { return _model.Passport; }
            set
            {
                _model.Passport = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleEducation
        {
            get { return _model.Education; }
            set
            {
                _model.Education = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleGraduation
        {
            get { return _model.Graduation.ToString("dd:mm:yyyy"); }
            set
            {
                _model.Graduation = DateTime.Parse(value);
                OnPropertyChanged();
            }
        }

        public bool EnrolleGoldenMedal
        {
            get { return _model.Golden_medal; }
            set
            {
                _model.Golden_medal = value;
                OnPropertyChanged();
            }
        }

        public bool EnrolleSilverMedal
        {
            get { return _model.Silver_medal; }
            set
            {
                _model.Silver_medal = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleFlow
        {
            get { return _model.Exam_sheet.Group.Flow.Name; }
            set
            {
                _model.Exam_sheet.Group.Flow.Name = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleGroup
        {
            get { return _model.Exam_sheet.Group.Name; }
            set
            {
                _model.Exam_sheet.Group.Name = value;
                OnPropertyChanged();
            }
        }
    }
}
