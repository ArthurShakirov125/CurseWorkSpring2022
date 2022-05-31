using AdmissionsCommittee.Abstract;
using AdmissionsCommittee.View;
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

namespace AdmissionsCommittee.ModelView
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, ICanNavigatePages
    {
        private NavigationService _navigationService;

        public MainPage(NavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
        }

        public void ToEnrollePage(object sender, RoutedEventArgs e)
        {
            EnrollePage page = new EnrollePage(_navigationService);
            _navigationService.Navigate(page);
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
