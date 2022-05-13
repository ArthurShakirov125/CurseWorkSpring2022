using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class SubjectModelView : EntityModelView<Subject>
    {
        public SubjectModelView(Subject model) : base(model)
        {
        }

        public Subject Subject
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

        public short PassPoints
        {
            get { return _model.Pass_points; }
            set
            {
                _model.Pass_points = value;
                OnPropertyChanged();
            }
        }
    }
}
