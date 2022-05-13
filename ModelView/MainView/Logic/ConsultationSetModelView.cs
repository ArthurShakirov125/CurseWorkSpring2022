using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ConsultationSetModelView :BaseModelView
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

        public override void Add(object obj)
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

        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            var cons = _db.ConsultationSet.First(c => c.Id == consultation.Consultation.Id);
            _db.ConsultationSet.Remove(cons);
            _db.SaveChanges();
        }
    }
}
