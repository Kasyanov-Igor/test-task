using System.Collections.ObjectModel;
using System.Windows.Input;
using Test_task.Model;
using Test_task.Model.Entities;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderViewModel : ViewModel
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<Employee> _repositoryEmployee;
        private readonly IRepository<Counterparty> _repositoryCounterparty;

        public ObservableCollection<Order> Orders { get; } = new();

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => SetProperty(ref _selectedOrder, value);
        }

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public OrderViewModel(IRepository<Order> repository, IRepository<Employee> repositoryEmployee, IRepository<Counterparty> repositoryCounterparty)
        {
            this._repository = repository;

            this._repositoryEmployee = repositoryEmployee;

            this._repositoryCounterparty = repositoryCounterparty;

            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync());
        }

        private async Task LoadAsync()
        {
            var items = await _repository.Get();

            Orders.Clear();
            foreach (var item in items)
                Orders.Add(item);
        }

        private async Task AddAsync()
        {
            var editVm = new OrderViewEditModel(this._repositoryEmployee, this._repositoryCounterparty);
            var editWindow = new OrderEditView { DataContext = editVm };
            editVm.CloseAction = () => editWindow.Close();

            bool? dialogResult = editWindow.ShowDialog();

            if (editVm.DialogResult == true)
            {
                var newOrder = new Order
                {

                };

                await _repository.Add(newOrder);
                Orders.Add(newOrder);
            }
        }

        private async Task DeleteAsync()
        {
            if (SelectedOrder == null) return;

            await _repository.Delete(SelectedOrder.Id);
            Orders.Remove(SelectedOrder);
        }
    }
}
