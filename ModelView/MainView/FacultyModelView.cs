using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class FacultyModelView : EntityModelView<Faculty>
    {
        public FacultyModelView(Faculty model) : base(model)
        {
        }

        public Faculty Faculty
        {
            get { return _model; }
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

        public int Competition
        {
            get { return _model.Competition; }
            set
            {
                _model.Competition = value;
                OnPropertyChanged();
            }
        }
    }
}
