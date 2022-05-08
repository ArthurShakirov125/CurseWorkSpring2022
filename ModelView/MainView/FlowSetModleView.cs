using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class FlowSetModleView : BaseModelView
    {
        private IEnumerable<FlowModleView> flows;

        public IEnumerable<FlowModleView> Flows
        {
            get { return flows; }
            set 
            { 
                flows = value;
                OnPropertyChanged();
            }
        }


        private Flow flow;

        public Flow Flow
        {
            get { return flow; }
            set 
            { 
                flow = value;
                OnPropertyChanged();
            }
        }


    }
}
