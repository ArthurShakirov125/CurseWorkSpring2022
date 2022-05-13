using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ConsultationModelView : EntityModelView<Consultation>
    {
        public ConsultationModelView(Consultation model) : base(model)
        {
        }


        public Consultation Consultation
        {
            get { return _model; }
            set 
            { 
                _model = value;
                OnPropertyChanged();
            }
        }

        public string SubjectName
        {
            get { return _model.Subject.Name; }
            set
            {
                var subject = _db.SubjectSet.Where(s => s.Name == value).First();

                _model.Subject = subject;
                _db.SaveChanges();
                OnPropertyChanged(); ;
            }
        }

        public string Classroom
        {
            get { return _model.Classroom; }
            set
            {
                _model.Classroom = value;
                OnPropertyChanged();
            }
        }

        public string Flow
        {
            get { return _model.Flow.Name; }
            set
            {
                var flow = _db.FlowSet.Where(f => f.Name == value).First();

                _model.Flow = flow;
                _db.SaveChanges();
                OnPropertyChanged();
            }
        }

        public string Date
        {
            get { return _model.Date.ToString("dd:mm:yyyy"); }
            set
            {
                _model.Date = DateTime.Parse(value);
                OnPropertyChanged();
            }
        }

    }
}
