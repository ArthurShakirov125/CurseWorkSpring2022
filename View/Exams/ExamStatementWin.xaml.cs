using AdmissionsCommittee.ModelView.MainView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdmissionsCommittee.View.Exams
{
    /// <summary>
    /// Логика взаимодействия для ExamStatementWin.xaml
    /// </summary>
    public partial class ExamStatementWin : Window
    {
        private ExamModelView exam;
        private ExamStatementSetViewModel context;

        public ExamStatementWin(ExamModelView exam)
        {
            InitializeComponent();
            this.exam = exam;
            context = new ExamStatementSetViewModel(exam);
            DataContext = context;
        }

        private void ShowWin(object sender, RoutedEventArgs e)
        {
            GivePoitns win = new GivePoitns();
            win.DataContext = context;
            win.ShowDialog();
        }
    }
}
