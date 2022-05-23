using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionsCommittee.Documents
{
    public class ExamSheetManager
    {
        private ExamSheetStructure _sheetStructure;
        private WordManager _wordManager;


        public string PathToSave
        {
            get { return _wordManager.PathToSave; }
            set { _wordManager.PathToSave = value; }
        }


        public ExamSheetManager(string pathToSave = @"C:\Users\Wolve\Desktop", string docName = "Экзаменационый лист")
        {
            _sheetStructure = new ExamSheetStructure();
            _wordManager = new WordManager(ExamSheetStructure.FILEPATH, pathToSave, docName);
        }


        public Dictionary<string, string> Pairs
        {
            get { return _sheetStructure.Pairs; }
            set { _sheetStructure.Pairs = value; }
        }

        public void MadeDocument()
        {
            _wordManager.GiveInfo(Pairs);
            _wordManager.Perform();
        } 



    }
}
