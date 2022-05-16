﻿using System;
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

        protected override void Add(object obj)
        {
            var sub = new Subject()
            {
                Name = Subject.Name,
                Pass_points = Subject.PassPoints,
            };

            Exam_statement ex = new Exam_statement()
            {
                Subject = sub,
            };

            _db.Exam_statementSet.Add(ex);
            _db.SubjectSet.Add(sub);
            _db.SaveChanges();
        }

        protected override void Redact(object obj)
        {
            _db.SaveChanges();
        }

        protected override void Delete(object obj)
        {
            var sub = _db.SubjectSet.Find(Subject.Subject.Id);
            _db.SubjectSet.Remove(sub);
            _db.SaveChanges();
        }

        protected override void Clear(object obj)
        {
            Subject = new SubjectModelView(new Subject());
        }
    }
}
