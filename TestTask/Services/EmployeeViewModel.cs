﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Test_task.Model;
using Test_task.Model.Entities;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
    public class EmployeeViewModel : ViewModel
    {
        private readonly IRepository<Employee> _repository;

        public ObservableCollection<Employee> Employees { get; } = new();

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set => SetProperty(ref _selectedEmployee, value);
        }

        public ICommand LoadCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public EmployeeViewModel(IRepository<Employee> repository)
        {
            this._repository = repository;

            LoadCommand = new RelayCommand(async _ => await LoadAsync());
            AddCommand = new RelayCommand(async _ => await AddAsync());
            DeleteCommand = new RelayCommand(async _ => await DeleteAsync());
        }

        private async Task LoadAsync()
        {
            var items = await _repository.Get();

            Employees.Clear();
            foreach (var item in items)
                Employees.Add(item);
        }

        private async Task AddAsync()
        {
            var editVm = new EmployeeEditViewModel();
            var editWindow = new EmployeeEditView { DataContext = editVm };
            editVm.CloseAction = () => editWindow.Close();

            bool? dialogResult = editWindow.ShowDialog();

            if (editVm.DialogResult == true)
            {
                var newUser = new Employee
                {
                     UserName = editVm.Name,
                     JobTitle = editVm.SelectedJobTitle,
                     DOB = editVm.DOB,
                };

                await _repository.Add(newUser);
                Employees.Add(newUser);
            }
        }

        private async Task DeleteAsync()
        {
            if (SelectedEmployee == null) return;

            await _repository.Delete(SelectedEmployee.Id);
            Employees.Remove(SelectedEmployee);
        }
    }
}
