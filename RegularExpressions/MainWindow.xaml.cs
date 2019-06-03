﻿using System.Windows;

namespace RegularExpressions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel(MyTextBox);
            viewModel.Load();
            DataContext = viewModel;
        }
    }
}