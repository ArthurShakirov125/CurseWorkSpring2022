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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdmissionsCommittee.View
{
    /// <summary>
    /// Логика взаимодействия для EnrollePage.xaml
    /// </summary>
    public partial class EnrollePage : Page
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
    }
}
