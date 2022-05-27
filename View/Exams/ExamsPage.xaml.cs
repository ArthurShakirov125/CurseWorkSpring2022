using AdmissionsCommittee.ModelView.MainView;
using AdmissionsCommittee.View.Exams;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdmissionsCommittee.View
{
    /// <summary>
    /// Логика взаимодействия для ExamsPage.xaml
    /// </summary>
    public partial class ExamsPage : Page
    {
        private NavigationService _navigationService;
        private ExamSetModelView _context;

        public ExamsPage(NavigationService navigationService)
        {
            InitializeComponent();
            this._navigationService = navigationService;
            _context = new ExamSetModelView();
            DataContext = _context;
        }

        private void ToEnrollePage(object sender, RoutedEventArgs e)
        {
            EnrollePage page = new EnrollePage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void ToFacultysPage(object sender, RoutedEventArgs e)
        {
            FacultyPage page = new FacultyPage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void ToExamsPage(object sender, RoutedEventArgs e)
        {
        }

        private void ToConsultsPage(object sender, RoutedEventArgs e)
        {
            ConsultPage page = new ConsultPage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void ToFlowsPage(object sender, RoutedEventArgs e)
        {
            FlowsPage page = new FlowsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void ToGroupsPage(object sender, RoutedEventArgs e)
        {
            GroupsPage page = new GroupsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void ToDepartsPage(object sender, RoutedEventArgs e)
        {
            DepartmentPage page = new DepartmentPage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void ToSubjectsPage(object sender, RoutedEventArgs e)
        {
            SubjectsPage page = new SubjectsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        private void AddWin(object sender, RoutedEventArgs e)
        {
            AddExam win = new AddExam();
            win.DataContext = _context;
            win.Show();
        }

        private void RedactWin(object sender, RoutedEventArgs e)
        {
            RedactExam win = new RedactExam();
            win.DataContext = _context;
            win.Show();
        }

        private void ToExamStatement(object sender, RoutedEventArgs e)
        {

        }
    }
}
