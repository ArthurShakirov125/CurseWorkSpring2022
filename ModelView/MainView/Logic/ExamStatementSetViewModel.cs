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

        protected override void Add(object obj)
        {
            Exam_statement ex = new Exam_statement()
            {
                Mark = Exam.Mark,
                Points = Exam.Points
            };

            _db.Exam_statementSet.Add(ex);
            _db.SaveChanges();
        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
        }

        protected override void Delete(object obj)
        {
            var ex = _db.Exam_statementSet.Find(Exam.examStatement.Id);
            _db.Exam_statementSet.Remove(ex);
            _db.SaveChanges();
        }

        protected override void Clear(object obj)
        {
            Exam = new ExamStatementViewModel(new Exam_statement());
        }
    }
}
