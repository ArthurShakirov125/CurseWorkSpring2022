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
        protected UserCreateWindow _createWindow;
        public AdminPage()
        {
            InitializeComponent();
            DataContext = new UsersViewModel();
        }

        private void CreateNewUser(object sender, RoutedEventArgs e)
        {
            _createWindow = new UserCreateWindow();
            _createWindow.Show();
        }
    }
}
