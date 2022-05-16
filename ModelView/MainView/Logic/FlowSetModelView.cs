using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class FlowSetModelView : BaseModelView
    {

        public FlowSetModelView()
        {
            Flows = _db.FlowSet.ToList().Select(f => new FlowModelView(f));
            deps = _db.DepartmentSet.Select(d => d.Name).ToList();
            faculties = _db.FacultySet.Select(f => f.Name).ToList();
            Flow = new FlowModelView(new Flow()
            {
                Department = new Department()
                {
                    Faculty = new Faculty()
                }
            });
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
        private IEnumerable<string> faculties;

        public IEnumerable<string> Faculties
        {
            get { return faculties; }
            set
            {
                faculties = value;
            }
        }

        private IEnumerable<string> deps;

        public IEnumerable<string> Departs
        {
            get { return deps; }
            set
            {
                deps = value;
                OnPropertyChanged();
            }
        }
        protected override void Add(object obj)
        {
            var flow = new Flow()
            {
                Name = Flow.Name,
                Department = _db.DepartmentSet.First(d => d.Name == Flow.Department),
            };
            _db.FlowSet.Add(flow);
            _db.SaveChanges();
            Flows = _db.FlowSet.ToList().Select(f => new FlowModelView(f));
        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
        }

        protected override void Delete(object obj)
        {
            var flow = _db.FlowSet.Find(Flow.Flow.Id);
            _db.FlowSet.Remove(flow);
            _db.SaveChanges();
            Flows = _db.FlowSet.ToList().Select(f => new FlowModelView(f));
        }

        protected override void Clear(object obj)
        {
            Flow = new FlowModelView(new Flow()
            {
                Department = new Department()
                {
                    Faculty = new Faculty()
                }
            });
        }
    }
}
