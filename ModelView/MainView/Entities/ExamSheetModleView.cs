using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamSheetModleView : EntityModelView<Exam_sheet>
    {
        public ExamSheetModleView(Exam_sheet model) : base(model)
        {
        }


        public Exam_sheet Sheet
        {
            get { return _model; }
            set 
            { 
                _model = value;
                OnPropertyChanged();
            }
        }


        public int Number
        {
            get { return _model.Exam_sheet_number; }
            set 
            { 
                _model.Exam_sheet_number = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleName
        {
            get { return _model.Enrollee.Name; }
            set
            {
                _model.Enrollee.Name = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleSurname
        {
            get { return _model.Enrollee.Surname; }
            set
            {
                _model.Enrollee.Surname = value;
                OnPropertyChanged();
            }
        }






    }
}
