using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.AdminPageViews
{
    public class UniversityModelView : EntityModelView<University>
    {
        public UniversityModelView(University model) : base(model)
        {
        }

        public University University
        {
            get { return _model; }
            set 
            { 
                _model = value; 
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                _model.Name = value;
                OnPropertyChanged();
            }
        }

        public string Adress
        {
            get { return _model.Address; }
            set
            {
                _model.Address = value;
                OnPropertyChanged();
            }
        }

    }
}
