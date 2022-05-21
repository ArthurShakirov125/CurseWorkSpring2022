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
    public class ConsultationSetModelView : BaseModelView
    {

        private Dates _dates;

        public Dates Date
        {
            get { return _dates; }
            set { _dates = value; }
        }

        private IEnumerable<ConsultationModelView> consultations;

        public IEnumerable<ConsultationModelView> Consultations
        {
            get { return consultations; }
            set 
            { 
                consultations = value;
                OnPropertyChanged();
            }
        }

        private ConsultationModelView consultation;

        public ConsultationModelView Consultation
        {
            get { return consultation; }
            set 
            { 
                consultation = value;
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

        public ConsultationSetModelView()
        {
            Consultations = _db.ConsultationSet.ToList().Select(c => new ConsultationModelView(c));
            subjects = _db.SubjectSet.Select(s => s.Name).ToList();
            flows = _db.FlowSet.Select(s => s.Name).ToList();
            _dates = new Dates();
            Consultation = new ConsultationModelView(new Consultation()
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
        }

        protected override void Add(object obj)
        {
            var cons = new Consultation()
            {
                Classroom = Consultation.Classroom,
                Flow = _db.FlowSet.First(f => f.Name == Consultation.Flow),
                Subject = _db.SubjectSet.First(s => s.Name == Consultation.SubjectName),
                Date = _dates.MakeADate()
        };

            _db.ConsultationSet.Add(cons);
            _db.SaveChanges();
            MessageBox.Show("Добавление выполнено успешно");
            Consultations = _db.ConsultationSet.ToList().Select(c => new ConsultationModelView(c));

        }

        protected override void Redact(object obj)
        {
            Consultation.Consultation.Date = _dates.MakeADate();
            _db.SaveChanges();
            MessageBox.Show("Редактирование выполнено успешно");
            Consultations = _db.ConsultationSet.ToList().Select(c => new ConsultationModelView(c));
        }

        protected override void Delete(object obj)
        {
            var cons = _db.ConsultationSet.First(c => c.Id == consultation.Consultation.Id);
            _db.ConsultationSet.Remove(cons);
            _db.SaveChanges();
            MessageBox.Show("Удаление выполнено успешно");
            Consultations = _db.ConsultationSet.ToList().Select(c => new ConsultationModelView(c));
        }

        protected override void Clear(object obj)
        {
            Consultation = new ConsultationModelView(new Consultation()
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
        }
    }
}
