using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamStatementViewModel : EntityModelView<Exam_statement>
    {
        public ExamStatementViewModel(Exam_statement model) : base(model)
        {
        }

        public Exam_statement examStatement
        {
            get { return _model; }
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleName
        {
            get { return _model.Enrollee.Name; }
            set
            {
                _model.Enrollee.Name = value;
                OnPropertyChanged();
            }
        }

        public string Subject
        {
            get { return _model.Subject.Name; }
            set
            {
                _model.Subject.Name = value;
                OnPropertyChanged();
            }
        }

        public string EnrolleSurename
        {
            get { return _model.Enrollee.Surname; }
            set
            {
                _model.Enrollee.Surname = value;
                OnPropertyChanged();
            }
        }

        public short Points
        {
            get { return _model.Points; }
            set
            {
                _model.Points = value;
                OnPropertyChanged();
            }
        }

        public byte Mark
        {
            get { return _model.Mark; }
            set
            {
                _model.Mark = value;
                OnPropertyChanged();
            }
        }

    }
}
