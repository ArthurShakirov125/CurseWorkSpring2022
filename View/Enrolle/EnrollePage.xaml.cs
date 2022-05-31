using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.ModelView.MainView;
using AdmissionsCommittee.View.Enrolle;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AdmissionsCommittee.View
{
    /// <summary>
    /// Логика взаимодействия для EnrollePage.xaml
    /// </summary>
    public partial class EnrollePage : Page, ICanNavigatePages
    {
        private NavigationService _navigationService;
        private EnrollesModelView enrollesModelView;

        public EnrollePage(NavigationService navigationService)
        {
            InitializeComponent();
            enrollesModelView = new EnrollesModelView();
            DataContext = enrollesModelView;
            this._navigationService = navigationService;
        }

        private void Redact(object sender, RoutedEventArgs e)
        {
            var win = new RedactEnrolleWindow();
            enrollesModelView.initializeDates();
            win.DataContext = enrollesModelView;
            win.Show();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var win = new AddEnrolle();
            win.DataContext = enrollesModelView;
            win.Show();
        }

        public void ToEnrollePage(object sender, RoutedEventArgs e)
        {
        }

        public void ToFacultysPage(object sender, RoutedEventArgs e)
        {
            FacultyPage page = new FacultyPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToExamsPage(object sender, RoutedEventArgs e)
        {
            ExamsPage page = new ExamsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToConsultsPage(object sender, RoutedEventArgs e)
        {
            ConsultPage page = new ConsultPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToFlowsPage(object sender, RoutedEventArgs e)
        {
            FlowsPage page = new FlowsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToGroupsPage(object sender, RoutedEventArgs e)
        {
            GroupsPage page = new GroupsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToDepartsPage(object sender, RoutedEventArgs e)
        {
            DepartmentPage page = new DepartmentPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToSubjectsPage(object sender, RoutedEventArgs e)
        {
            SubjectsPage page = new SubjectsPage(_navigationService);
            _navigationService.Navigate(page);
        }

        public void ToAdminPage(object sender, RoutedEventArgs e)
        {
            AdminPage page = new AdminPage(_navigationService);
            _navigationService.Navigate(page);
        }


    }
}
