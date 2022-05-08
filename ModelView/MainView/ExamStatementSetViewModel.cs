using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamStatementSetViewModel : BaseModelView
    {
        public ExamStatementSetViewModel()
        {
            Exams = _db.Exam_statementSet.ToList().Select(e => new ExamStatementViewModel(e));
        }

        private IEnumerable<ExamStatementViewModel> exams;

        public IEnumerable<ExamStatementViewModel> Exams
        {
            get { return exams; }
            set 
            { 
                exams = value;
                OnPropertyChanged();
            }
        }

        private ExamStatementViewModel exam;

        public ExamStatementViewModel Exam
        {
            get { return exam; }
            set 
            { 
                exam = value;
                OnPropertyChanged();
            }
        }


    }
}
