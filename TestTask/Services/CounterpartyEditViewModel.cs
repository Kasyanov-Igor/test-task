using System.Collections.ObjectModel;
using System.Windows.Input;
using Test_task.Model;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
    public class CounterpartyEditViewModel : ViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _inn;
        public string INN
        {
            get => _inn;
            set => SetProperty(ref _inn, value);
        }

        private readonly IRepository<Employee> _repository;
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();

        private int _curatorEmployeeId;
        public int CuratorEmployeeId
        {
            get => _curatorEmployeeId;
            set => SetProperty(ref _curatorEmployeeId, value);
        }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public bool? DialogResult { get; private set; }
        public Action CloseAction { get; set; }

        public CounterpartyEditViewModel(IRepository<Employee> repository)
        {
            this._repository = repository;
            LoadEmployees();
            OkCommand = new RelayCommand(_ =>
            {
                DialogResult = true;
                CloseAction?.Invoke();
                return Task.CompletedTask;
            });

            CancelCommand = new RelayCommand(_ =>
            {
                DialogResult = false;
                CloseAction?.Invoke();
                return Task.CompletedTask;
            });
        }

        private async Task LoadEmployees()
        {
            var items = await _repository.Get();

            Employees.Clear();
            foreach (var item in items)
                Employees.Add(item);
        }
    }
}
