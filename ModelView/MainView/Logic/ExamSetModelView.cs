using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using AdmissionsCommittee.View.Helper;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamSetModelView : BaseModelView
    {
        private Dates _dates;

        public Dates Date
        {
            get { return _dates; }
            set { _dates = value; }
        }

        private IEnumerable<ExamModelView> exams;

        public IEnumerable<ExamModelView> Exams
        {
            get { return exams; }
            set { 
                exams = value;
                OnPropertyChanged();
            }
        }

        private ExamModelView exam;

        public ExamModelView Exam
        {
            get { return exam; }
            set { 
                exam = value;
                OnPropertyChanged();
            }
        }


        private List<string> subjects;

        public List<string> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        private List<string> flows;

        public List<string> Flows
        {
            get { return flows; }
            set { flows = value; }
        }

        public ExamSetModelView()
        {
            Exam = new ExamModelView(new Exam_schedule()
            {
                Subject = new Subject(),
                Flow = new Flow()
                {
                    Department = new Department()
                    {
                        Faculty = new Faculty() { }
                    }
                }
            });
            Exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
            subjects = _db.SubjectSet.Select(s => s.Name).ToList();
            flows = _db.FlowSet.Select(s => s.Name).ToList();
            _dates = new Dates();
        }

        protected override void Add(object obj)
        {
            var ex = new Exam_schedule()
            {
                Classroom = Exam.Classroom,
                Flow = _db.FlowSet.First(f => f.Name == Exam.Flow)
            };


            ex.Subject = _db.SubjectSet.First(s => s.Name == Exam.SubjectName);
            ex.Date = _dates.MakeADate();


            _db.Exam_scheduleSet.Add(ex);
            _db.SaveChanges();
            Exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }

        protected override void Redact(object obj)
        {
            Exam.Exam.Date = _dates.MakeADate();
            _db.SaveChanges();
            Exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }

        protected override void Delete(object obj)
        {
            var ex = _db.Exam_scheduleSet.Find(Exam.Exam.Id);
            _db.Exam_scheduleSet.Remove(ex);
            _db.SaveChanges();
            Exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }

        protected override void Clear(object obj)
        {
            Exam = new ExamModelView(new Exam_schedule() 
            { 
                Subject = new Subject(),
                Flow = new Flow() 
                { Department = new Department()
                    {
                        Faculty = new Faculty() { }
                    } 
                }
            });
        }
    }
}
