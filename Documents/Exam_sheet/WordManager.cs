using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace AdmissionsCommittee.Documents
{
    /// <summary>
    /// Класс в конструкторе принимает путь к файлу который нужно обработать
    /// В методе GiveInfo поучает словарь для обработки файла
    /// В методе Perform создает копию файла и обрабатывает её
    /// </summary>
    public class WordManager
    {
        public FileInfo _fileInfo;
        private Dictionary<string, string> _items;
        private FileInfo _templateFilePath;

        public string NewDocName { get; set; }

        public string PathToSave { get; set; }

        public WordManager(string fileName, string pathToSave, string docName)
        {
            if (File.Exists(fileName))
            {
                _templateFilePath = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("File not found");
            }
            PathToSave = pathToSave;
            NewDocName = docName;
            _fileInfo = new FileInfo(CopyFile(_templateFilePath.FullName));
        }

        public void GiveInfo(Dictionary<string, string> items)
        {
            _items = items;
        }

        public void Perform()
        {
            try
            {
                var app = new Word.Application();
                object file = _fileInfo.FullName;

                object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in _items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    object wrap = Word.WdFindWrap.wdFindContinue;
                    object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                        MatchCase: false,
                        MatchWholeWord: false,
                        MatchWildcards: false,
                        MatchSoundsLike: missing,
                        MatchAllWordForms: false,
                        Forward: true,
                        Wrap: wrap,
                        Format: false,
                        ReplaceWith: missing, Replace: replace);
                }

                app.ActiveDocument.Save();
                app.ActiveDocument.Close();
                app.Quit();

            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        


        private string CopyFile(string src)
        {

            if (File.Exists(src))
            {
                _fileInfo = new FileInfo(src);
            }

            var app = new Word.Application();
            var sourceDoc = app.Documents.Open(_fileInfo.FullName);

            sourceDoc.ActiveWindow.Selection.WholeStory();
            sourceDoc.ActiveWindow.Selection.Copy();

            var newDocument = new Word.Document();
            newDocument.ActiveWindow.Selection.Paste();

            var newFilePath = Path.Combine(PathToSave, NewDocName + ".docx");

            newDocument.SaveAs(newFilePath);

            sourceDoc.Close(false);
            newDocument.Close();

           // app.Quit();

            return newFilePath;
        }
    }
}
