﻿using AdmissionsCommittee.ModelView.AdminPageViews;
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

namespace AdmissionsCommittee.View
{
    /// <summary>
    /// Логика взаимодействия для UserCreateWindow.xaml
    /// </summary>
    public partial class UserCreateWindow : Window
    {
        private UsersViewModel usersViewModel;

        public UserCreateWindow()
        {
            InitializeComponent();
        }

        public UserCreateWindow(UsersViewModel usersViewModel)
        {
            InitializeComponent();
            this.usersViewModel = usersViewModel;
            DataContext = usersViewModel;
        }
    }
}
