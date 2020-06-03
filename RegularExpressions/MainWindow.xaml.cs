using System.Windows;
using System.Windows.Input;

namespace RegularExpressions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel(SearchTextBox, MyTextBox, MyDataGrid);
            viewModel.Load();
            DataContext = viewModel;
            viewModel.FindCommandExecute();
        }

        /// <summary>
        /// The function is used for searching the previous 
        /// and the next word by using arrows keys
        /// </summary>
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z && MyTextBox.IsFocused == false)
            {
                SearchTextBox.Focus();
                return;
            }
            switch (e.Key)
            {
                case Key.Down:
                    viewModel.FindNextWordCommandExecute();
                    e.Handled = true;
                    break;
                case Key.Right:
                    viewModel.FindNextWordCommandExecute();
                    e.Handled = true;
                    break;
                case Key.Left:
                    viewModel.FindPreviousWordCommandExecute();
                    e.Handled = true;
                    break;
                case Key.Up:
                    viewModel.FindPreviousWordCommandExecute();
                    e.Handled = true;
                    break;
                case Key.Enter:
                    if (MyTextBox.IsFocused == false)
                    {
                        viewModel.FindCommandExecute();
                        e.Handled = true;
                    }
                    break;
                default: break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.FindCommandExecute();
        }
    }
}
