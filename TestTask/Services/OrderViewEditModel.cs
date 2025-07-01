using System.Collections.ObjectModel;
using System.Windows.Input;
using Test_task.Model;
using Test_task.Model.Entities;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderViewEditModel : ViewModel
    {
        private DateTime _dob = DateTime.Now;
        public DateTime DOB
        {
            get => _dob;
            set => SetProperty(ref _dob, value);
        }

        private uint _amount;
        public uint Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        private readonly IRepository<Employee> _repositoryEmployee;

        private readonly IRepository<Counterparty> _repositoryCounterparty;
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();

        private int _curatorEmployeeId;
        public int CuratorEmployeeId
        {
            get => _curatorEmployeeId;
            set => SetProperty(ref _curatorEmployeeId, value);
        }

        public ObservableCollection<Counterparty> Counterpartys { get; } = new ObservableCollection<Counterparty>();

        private int _curatorCounterpartyId;
        public int CuratorCounterpartyId
        {
            get => _curatorCounterpartyId;
            set => SetProperty(ref _curatorCounterpartyId, value);
        }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public bool? DialogResult { get; private set; }
        public Action CloseAction { get; set; }

        public OrderViewEditModel(IRepository<Employee> repositoryEmployee, IRepository<Counterparty> repositoryCounterparty)
        {
            this._dob = new DateTime(DateTime.Now.Year - 25, 1, 1);
            this._repositoryEmployee = repositoryEmployee;
            this._repositoryCounterparty = repositoryCounterparty;

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

        public async Task InitializeAsync()
        {
            await LoadCounterparty();
            await LoadEmployees();
        }

        private async Task LoadEmployees()
        {
            var items = await _repositoryEmployee.Get();

            Employees.Clear();
            foreach (var item in items)
                Employees.Add(item);
        }

        private async Task LoadCounterparty()
        {
            var items2 = await _repositoryCounterparty.Get();

            Counterpartys.Clear();
            foreach (var item in items2)
                Counterpartys.Add(item);
        }
    }
}

