using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ConsultationSetModelView : BaseModelView
    {
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

        public ConsultationSetModelView()
        {
            consultations = _db.ConsultationSet.ToList().Select(c => new ConsultationModelView(c));
        }

        protected override void Add(object obj)
        {
            var cons = new Consultation()
            {
                Classroom = Consultation.Classroom,
               // Date = Consultation.Consultation.Date,
                Flow = _db.FlowSet.First(f => f.Name == Consultation.Flow),
                Subject = _db.SubjectSet.First(s => s.Name == Consultation.SubjectName)
            };

            _db.ConsultationSet.Add(cons);
            _db.SaveChanges();
            MessageBox.Show("Добавление выполнено успешно");

        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
            MessageBox.Show("Редактирование выполнено успешно");
        }

        protected override void Delete(object obj)
        {
            var cons = _db.ConsultationSet.First(c => c.Id == consultation.Consultation.Id);
            _db.ConsultationSet.Remove(cons);
            _db.SaveChanges();
            MessageBox.Show("Удаление выполнено успешно");
        }

        protected override void Clear(object obj)
        {
            Consultation = new ConsultationModelView(new Consultation());
        }
    }
}
