using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            if (Exam.Classroom == null || Exam.Date == null
                || Exam.SubjectName == null || Exam.Flow == null)
            {
                MessageBox.Show("Пожалуйста заполните все поля");
                return;
            }
            var ex = new Exam_schedule()
            {
                Classroom = Exam.Classroom,
                Flow = _db.FlowSet.First(f => f.Name == Exam.Flow),
                Subject = _db.SubjectSet.First(s => s.Name == Exam.SubjectName),
                Date = _dates.MakeADate()
            };

            _db.Exam_scheduleSet.Add(ex);
            _db.SaveChanges();
            MessageBox.Show("Изменения сохранены");
            Exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }

        protected override void Redact(object obj)
        {
            if (Exam.Classroom == null || Exam.Date == null)
            {
                MessageBox.Show("Пожалуйста заполните все поля");
                return;
            }
            Exam.Exam.Date = _dates.MakeADate();
            _db.SaveChanges();
            MessageBox.Show("Экзамен успешно добавлен");
            Exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }

        protected override void Delete(object obj)
        {
            var ex = _db.Exam_scheduleSet.Find(Exam.Exam.Id);
            _db.Exam_scheduleSet.Remove(ex);
            _db.SaveChanges();
            MessageBox.Show("Удаление успешно завершено");
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
