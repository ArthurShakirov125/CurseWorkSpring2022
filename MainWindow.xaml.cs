using AdmissionsCommittee.DataBase;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var db = new AdmissionsCommitteeDBContainer();

            var university = new University()
            {
                Address = "ул. Ворошилова, 12, Челябинск, Челябинская обл., 454014",
                Name = "Международный институт дизайна и сервиса"
            };

            db.UniversitySet.Add(university);
            db.SaveChanges();
        }
    }
}
