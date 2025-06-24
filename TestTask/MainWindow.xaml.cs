using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_task.Model.Entities;
using Test_task.Repositories;
using Test_task.Services.Interfaces;
using TestTask.Services;

namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Конструктор с параметрами для DI
        public MainWindow(CounterpartyViewModel vm) : this()
        {
            DataContext = vm;
        }
    }
}