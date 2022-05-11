using AdmissionsCommittee.Abstract;
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


    }
}
