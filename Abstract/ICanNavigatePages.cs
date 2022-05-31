using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdmissionsCommittee.Abstract
{
    internal interface ICanNavigatePages
    {
        void ToEnrollePage(object sender, RoutedEventArgs e);
        void ToFacultysPage(object sender, RoutedEventArgs e);
        void ToExamsPage(object sender, RoutedEventArgs e);
        void ToConsultsPage(object sender, RoutedEventArgs e);
        void ToFlowsPage(object sender, RoutedEventArgs e);
        void ToGroupsPage(object sender, RoutedEventArgs e);
        void ToDepartsPage(object sender, RoutedEventArgs e);
        void ToSubjectsPage(object sender, RoutedEventArgs e);
        void ToAdminPage(object sender, RoutedEventArgs e);
    }
}
