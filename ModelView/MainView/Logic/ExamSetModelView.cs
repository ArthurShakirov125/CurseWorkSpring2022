using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamSetModelView : BaseModelView
    {
        private IEnumerable<ExamModelView> exams;

        public IEnumerable<ExamModelView> Exams
        {
            get { return exams; }
            set { exams = value; }
        }

        private ExamModelView exam;

        public ExamModelView Exam
        {
            get { return exam; }
            set { exam = value; }
        }

        public ExamSetModelView()
        {
            exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }

        protected override void Add(object obj)
        {
            var ex = new Exam_schedule()
            {
                Classroom = Exam.Classroom,
                //Date = Exam.Date,
                Subject = _db.SubjectSet.First(s => s.Name == Exam.SubjectName),
                Flow = _db.FlowSet.First(f => f.Name == Exam.Flow)
            };

            _db.Exam_scheduleSet.Add(ex);
            _db.SaveChanges();
        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
        }

        protected override void Delete(object obj)
        {
            var ex = _db.Exam_scheduleSet.Find(Exam.Exam.Id);
            _db.Exam_scheduleSet.Remove(ex);
            _db.SaveChanges();
        }

        protected override void Clear(object obj)
        {
            Exam = new ExamModelView(new Exam_schedule());
        }
    }
}
