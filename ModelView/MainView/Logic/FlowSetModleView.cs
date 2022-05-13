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

        public FlowSetModleView()
        {
            Flows = _db.FlowSet.ToList().Select(f => new FlowModelView(f));
        }

        private IEnumerable<FlowModelView> flows;

        public IEnumerable<FlowModelView> Flows
        {
            get { return flows; }
            set 
            { 
                flows = value;
                OnPropertyChanged();
            }
        }


        private FlowModelView flow;

        public FlowModelView Flow
        {
            get { return flow; }
            set 
            { 
                flow = value;
                OnPropertyChanged();
            }
        }

        public override void Add(object obj)
        {
            var flow = new Flow()
            {
                Name = Flow.Name,
                Department = _db.DepartmentSet.First(d => d.Name == Flow.Department),
            };
            _db.FlowSet.Add(flow);
            _db.SaveChanges();
        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            var flow = _db.FlowSet.Find(Flow.Flow.Id);
            _db.FlowSet.Remove(flow);
            _db.SaveChanges();
        }
    }
}
