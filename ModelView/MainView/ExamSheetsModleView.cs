using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamSheetsModleView : BaseModelView
    {
        private IEnumerable<ExamSheetModleView> examSheets;

        public IEnumerable<ExamSheetModleView> ExamSheets
        {
            get { return examSheets; }
            set { examSheets = value; }
        }

        private ExamSheetModleView sheet;

        public ExamSheetModleView ExamSheet
        {
            get { return sheet; }
            set { sheet = value; }
        }

        public ExamSheetsModleView()
        {
            ExamSheets = _db.Exam_sheetSet.ToList().Select(e => new ExamSheetModleView(e));
        }


    }
}
