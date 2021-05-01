﻿using System;
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
using System.Windows.Threading;

namespace BeehiveManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        private Queen _queen = new Queen();

        public MainWindow()
        {
            InitializeComponent();

            statusReport.Text = _queen.StatusReport;

            _timer.Tick += Timer_Tick;
            _timer.Interval = TimeSpan.FromSeconds(1.5);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            WorkShift_Click(this, new RoutedEventArgs());
        }

        private void AssignJob_Click(object sender, RoutedEventArgs e)
        {
            _queen.AssignBee(jobSelector.Text);
            statusReport.Text = _queen.StatusReport;
        }

        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            _queen.WorkTheNextShift();
            statusReport.Text = _queen.StatusReport;
        }
    }
}
