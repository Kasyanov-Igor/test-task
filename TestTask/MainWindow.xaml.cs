using System.Text;
using System.Windows;
using TestTask.Services;

namespace TestTask
{

    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}