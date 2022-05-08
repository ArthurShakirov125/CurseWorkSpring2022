using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class EnrollesModelView : BaseModelView
    {
        public EnrollesModelView()
        {
            _db = new AdmissionsCommitteeDBContainer();
            enrolleModles = _db.EnrolleeSet.ToList().Select(e => new EnrolleModleView(e));
        }

        private IEnumerable<EnrolleModleView> enrolleModles;

        public IEnumerable<EnrolleModleView> EnrolleModles
        {
            get { return enrolleModles; }
            set
            {
                enrolleModles = value;
                OnPropertyChanged();
            }
        }

        private EnrolleModleView selectedEnrolle;

        public EnrolleModleView SelectedEnrolle
        {
            get { return selectedEnrolle; }
            set 
            { 
                selectedEnrolle = value;
                OnPropertyChanged();
            }
        }

    }
}
