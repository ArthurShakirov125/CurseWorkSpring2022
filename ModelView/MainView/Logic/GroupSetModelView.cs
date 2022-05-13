using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class GroupSetModelView : BaseModelView
    {

        public GroupSetModelView()
        {
            groups = _db.GroupSet.ToList().Select(g => new GroupModelView(g));
        }

        private IEnumerable<GroupModelView> groups;

        public IEnumerable<GroupModelView> Groups
        {
            get { return groups; }
            set 
            { 
                groups = value;
                OnPropertyChanged();
            }
        }

        private GroupModelView selectedGroup;

        public GroupModelView SelectedGroup
        {
            get { return selectedGroup; }
            set 
            { 
                selectedGroup = value;
                OnPropertyChanged();
            }
        }

        public override void Add(object obj)
        {
            var grp = new Group()
            {
                Name = selectedGroup.Name,
                Flow = _db.FlowSet.First(s => s.Name == selectedGroup.Flow)
            };

            _db.GroupSet.Add(grp);
            _db.SaveChanges();
        }

        public override void Redact(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object obj)
        {
            var grp = _db.GroupSet.Find(selectedGroup.Group.Id);
            _db.GroupSet.Remove(grp);
            _db.SaveChanges();
        }
    }
}
