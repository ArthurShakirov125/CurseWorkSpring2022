using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamSetModelView : BaseModelView
    {
        private IEnumerable<ExamModelView> exams;

        public IEnumerable<ExamModelView> Exams
        {
            get { return exams; }
            set { exams = value; }
        }

        private ExamModelView exam;

        public ExamModelView Exam
        {
            get { return exam; }
            set { exam = value; }
        }

        public ExamSetModelView()
        {
            exams = _db.Exam_scheduleSet.ToList().Select(e => new ExamModelView(e));
        }


    }
}
