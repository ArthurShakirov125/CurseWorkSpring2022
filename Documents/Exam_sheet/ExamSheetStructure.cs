using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.Documents
{
    internal class ExamSheetStructure
    {
        public const string FILEPATH = @"..\..\Documents\Templates\Exam_sheet_template.docx";

        private Dictionary<string, string> keyValuePairs;

        public Dictionary<string, string> Pairs
        {
            get { return keyValuePairs; }
            set { keyValuePairs = value; }
        }

        public ExamSheetStructure()
        {
            Initialize();
        }

        private void Initialize()
        {
            keyValuePairs = new Dictionary<string, string>()
            {
                {"<University>", "" },
                {"<Sheet_number>", "" },
                {"<Faculty>", "" },
                {"<Spec>", "" },
                {"<Surename>", "" },
                {"<Name>", "" },
                {"<Lastname>", "" },
                {"<DateOfDelivery>", "" },

                {"<n1>", "" },
                {"<Sub1>", "" },
                {"<Date1>", "" },
                {"<Mark1>", "" },
                {"<Points1>", "" },

                {"<n2>", "" },
                {"<Sub2>", "" },
                {"<Date2>", "" },
                {"<Mark2", "" },
                {"<Points2>", "" },

            };
        }
    }
}
