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

        public short? PassPointsToThree
        {
            get { return _model.Pass_points_to_three; }
            set
            {
                _model.Pass_points_to_three = value;
                OnPropertyChanged();
            }
        }

        public short? PassPointsToFour
        {
            get { return _model.Pass_points_to_four; }
            set
            {
                _model.Pass_points_to_four = value;
                OnPropertyChanged();
            }
        }

        public short? PassPointsToFive
        {
            get { return _model.Pass_points_to_five; }
            set
            {
                _model.Pass_points_to_five = value;
                OnPropertyChanged();
            }
        }
    }
}
