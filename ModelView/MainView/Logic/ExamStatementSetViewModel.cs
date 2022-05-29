using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.DataBase;
using AdmissionsCommittee.Documents.Exam_statements;

namespace AdmissionsCommittee.ModelView.MainView
{
    public class ExamStatementSetViewModel : BaseModelView
    {
        public ExamStatementSetViewModel(ExamModelView exam)
        {
            Exams = _db.Exam_statementSet.ToList().Select(e => new ExamStatementViewModel(e));
            examToWork = exam.Exam;
            GetEnrollees();
            CreateGeneralText();
        }

        protected RelayCommand createDoc;

        public RelayCommand CreateDocument
        {
            get
            {
                return createDoc ??
                    (createDoc = new RelayCommand(CreateDoc));
            }
        }

        private void CreateDoc(object obj)
        {
            ExamStatementManager manager = new ExamStatementManager();
            manager.GivePairs(CreatePairs());
            var path = manager.CreateAndFillTable(exams);
            MessageBox.Show($"Файл успешно создан в директории {path}");
        }

        private Dictionary<string, string> CreatePairs()
        {
            return new Dictionary<string, string>
            {
                {"<University>", _db.UniversitySet.First().Name },
                {"<Faculty>", examToWork.Flow.Department.Faculty.Name },
                {"<Subject>", examToWork.Subject.Name }
            };
        }

        private void CreateGeneralText()
        {
            GeneralText = $"Экзаменационная ведомость {examToWork.Flow.Name} потока по предмету {examToWork.Subject.Name}";
        }

        public string GeneralText { get; set; }
        private void GetEnrollees()
        {
            var groups = examToWork.Flow.Group;
            var examSheets = groups.Select(g => g.Exam_sheet);
            enrollees = examSheets.SelectMany(e => e.Select(ex => ex.Enrollee));

            if (!_db.Exam_statementSet.Any())
            {
                initializeExamStatement();
            }
            else
            {
                Exams = _db.Exam_statementSet.ToList().Select(e => new ExamStatementViewModel(e));
            }
        }

        private void initializeExamStatement()
        {
            foreach (var enrl in enrollees)
            {
                Exams = Exams.Append(new ExamStatementViewModel(new Exam_statement()
                {
                    Enrolle_last_name = enrl.Surname,
                    Exam_sheet_number = enrl.Exam_sheet.Exam_sheet_number,
                    Exam_schedule = _db.Exam_scheduleSet.First(e => e.Id == examToWork.Id)
                }));
            }

            foreach (var ex in Exams)
            {
                _db.Exam_statementSet.Add(ex.examStatement);
            }
            _db.SaveChanges();
        }

        private IEnumerable<ExamStatementViewModel> exams;

        public IEnumerable<ExamStatementViewModel> Exams
        {
            get { return exams; }
            set 
            { 
                exams = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Enrollee> enrollees;

        private ExamStatementViewModel exam;

        public ExamStatementViewModel Exam
        {
            get { return exam; }
            set 
            { 
                exam = value;
                OnPropertyChanged();
            }
        }

        private Exam_schedule examToWork;

        protected override void Add(object obj)
        {
        }

        protected override void Redact(object obj)
        {
            Exam.Mark = CalculateMark();
            _db.SaveChanges();
            MessageBox.Show("Изменения сохранены");
        }

        private byte? CalculateMark()
        {
            var Subject = examToWork.Subject;

            if(Exam.Points < Subject.Pass_points_to_three)
            {
                return 2;
            }
            if (Exam.Points >= Subject.Pass_points_to_three && Exam.Points < Subject.Pass_points_to_four)
            {
                return 3;
            }
            if (Exam.Points >= Subject.Pass_points_to_four && Exam.Points < Subject.Pass_points_to_five)
            {
                return 4;
            }
            return 5;
        }

        protected override void Delete(object obj)
        {
            
        }

        protected override void Clear(object obj)
        {
        }
    }
}
