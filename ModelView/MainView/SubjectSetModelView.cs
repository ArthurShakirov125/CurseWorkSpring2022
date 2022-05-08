using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class SubjectSetModelView : BaseModelView
    {
        private IEnumerable<SubjectModelView> _subjects;

        public IEnumerable<SubjectModelView> Subjects
        {
            get { return _subjects; }
            set 
            { 
                _subjects = value;
                OnPropertyChanged();
            }
        }

        private SubjectModelView _subject;

        public SubjectModelView Subject
        {
            get { return _subject; }
            set 
            { 
                _subject = value;
                OnPropertyChanged();
            }
        }

        public SubjectSetModelView()
        {
            Subjects = _db.SubjectSet.ToList().Select(s => new SubjectModelView(s));
        }

    }
}
