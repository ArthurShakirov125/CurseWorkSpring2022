using AdmissionsCommittee.ModelView;
using AdmissionsCommittee.ModelView.AdminPageViews;
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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        protected UsersViewModel usersViewModel;
        protected UserCreateWindow _createWindow;
        protected UserRedactWindow _redactWindow;
        protected NavigationService _navigationService;
        public AdminPage(NavigationService navigationService)
        {
            InitializeComponent();

            usersViewModel = new UsersViewModel();
            this.DataContext = usersViewModel;
            _navigationService = navigationService;
        }

        private void CreateNewUser(object sender, RoutedEventArgs e)
        {
            _createWindow = new UserCreateWindow(usersViewModel);
            _createWindow.Show();
        }

        private void ReadactSelectedUser(object sender, RoutedEventArgs e)
        {
            _redactWindow = new UserRedactWindow(usersViewModel);
            _redactWindow.Show();
        }

        private void ToMainPage(object sender, RoutedEventArgs e)
        {
            _navigationService.Navigate(new MainPage(_navigationService));
        }
    }
}
