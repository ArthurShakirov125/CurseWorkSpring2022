using AdmissionsCommittee.ModelView.MainView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace AdmissionsCommittee.Documents.Exam_statements
{
    public class ExamStatementManager
    {
        const string FILEPATH = @"C:\C#\Curswork\AdmissionsCommittee\Documents\Templates\Exam_statement.docx";
        const int COLUMNS = 4;

        WordManager wordManager;
        private string pathToSave;
        private string docName;
        private FileInfo _fileInfo;

        private List<string> header;
        private Dictionary<string, string> _pairs;

        public ExamStatementManager(string pathToSave = @"C:\Users\Wolve\Desktop", string docName = "Экзаменационная ведомость")
        {
            this.pathToSave = pathToSave;
            this.docName = docName;
            wordManager = new WordManager(FILEPATH, pathToSave, docName);
            _fileInfo = wordManager._fileInfo;
            InitializeHeader();
        }

        public void GivePairs(Dictionary<string, string> pairs)
        {
            _pairs = pairs;
        }

        private void InitializeHeader()
        {
            header = new List<string>()
            {
                "№ п/п",
                "ФИО",
                "Баллы",
                "Оценка"
            };
        }

        public string CreateAndFillTable(IEnumerable<ExamStatementViewModel> exams)
        {
            PrepareDoc();
            var examList = exams.ToList();
            var app = new Word.Application();
            object file = _fileInfo.FullName;

            var doc = app.Documents.Open(file);

            Word.Table tb;
            tb = doc.Tables.Add(doc.Paragraphs[doc.Paragraphs.Count].Range, exams.Count() + 1, COLUMNS);
            tb.Borders.Enable = 1;

            for (int i = 0; i < header.Count; i++)
            {
                tb.Cell(1, i + 1).Range.Text = header[i];
            }

            // заполнить столбцы со студентами и их оценками испоьзуя exams
            for (int row = 2; row <= exams.Count() + 1; row++)
            {
                tb.Cell(row, 1).Range.Text = examList[row - 2].EnrolleeNumber.ToString();
                tb.Cell(row, 2).Range.Text = examList[row - 2].EnrolleLastName;
                tb.Cell(row, 3).Range.Text = examList[row - 2].Points.ToString();
                tb.Cell(row, 4).Range.Text = examList[row - 2].Mark.ToString();
            }



            doc.Save();
            doc.Close();
            app.Quit();

            return _fileInfo.DirectoryName;
        }

        private void PrepareDoc()
        {
            wordManager.GiveInfo(_pairs);
            wordManager.Perform();
        }
    }
}
