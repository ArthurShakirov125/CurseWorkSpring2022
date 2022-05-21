using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class GroupSetModelView : BaseModelView
    {

        public GroupSetModelView()
        {
            groups = _db.GroupSet.ToList().Select(g => new GroupModelView(g));

            SelectedGroup = new GroupModelView(new Group()
            {
                Flow = new Flow()
                {
                    Department = new Department()
                    {
                        Faculty = new Faculty()
                    }
                }
            });

            Flows = _db.FlowSet.Select(f => f.Name).ToList();
        }

        private List<string> flows;

        public List<string> Flows
        {
            get { return flows; }
            set { flows = value; }
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

        protected override void Add(object obj)
        {
            if (selectedGroup.Name == null || selectedGroup.Flow == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }
            var grp = new Group()
            {
                Name = selectedGroup.Name,
                Flow = _db.FlowSet.First(s => s.Name == selectedGroup.Flow)
            };

            _db.GroupSet.Add(grp);
            _db.SaveChanges();
            Groups = _db.GroupSet.ToList().Select(g => new GroupModelView(g));
        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
        }

        protected override void Delete(object obj)
        {
            var grp = _db.GroupSet.Find(selectedGroup.Group.Id);
            _db.GroupSet.Remove(grp);
            _db.SaveChanges();
            Groups = _db.GroupSet.ToList().Select(g => new GroupModelView(g));
        }

        protected override void Clear(object obj)
        {
            SelectedGroup = new GroupModelView(new Group()
            {
                Flow = new Flow()
                {
                    Department = new Department()
                    {
                        Faculty = new Faculty()
                    }
                }
            });
        }
    }
}
