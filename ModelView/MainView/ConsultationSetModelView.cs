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
            set { consultations = value; }
        }

        private ConsultationModelView consultation;

        public ConsultationModelView Consultation
        {
            get { return consultation; }
            set { consultation = value; }
        }

        public ConsultationSetModelView()
        {
            consultations = _db.ConsultationSet.ToList().Select(c => new ConsultationModelView(c));
        }


    }
}
