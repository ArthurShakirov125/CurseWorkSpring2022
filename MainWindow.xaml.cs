using AdmissionsCommittee.DataBase;
using AdmissionsCommittee.ModelView;
using AdmissionsCommittee.ModelView.AdminPageViews;
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

namespace AdmissionsCommittee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var db = new AdmissionsCommitteeDBContainer();

            if (db.UserSet.Any())
            {
                AuthorizationPage page = new AuthorizationPage(this.NavigationService);
                NavigationService.Navigate(page);
            }
            else
            {
                AdminPage page = new AdminPage(NavigationService);
                NavigationService.Navigate(page);
            }

            
        }
    }
}
