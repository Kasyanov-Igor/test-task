using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
	public class MainViewModel : ViewModel
	{
		public CounterpartyViewModel CounterpartyVM { get; }
		public OrderViewModel OrderVM { get; }
		public EmployeeViewModel EmployeeVM { get; }

		private ViewModel _currentViewModel;
		public ViewModel CurrentViewModel
		{
			get => _currentViewModel;
			set => SetProperty(ref _currentViewModel, value);
		}

		public ObservableCollection<string> ModelNames { get; } = new ObservableCollection<string>
		{
		"Counterparty",
		"Order",
		"Employee"
		};

		private string _selectedModelName;
		public string SelectedModelName
		{
			get => _selectedModelName;
			set
			{
				if (SetProperty(ref _selectedModelName, value))
				{
					switch (value)
					{
						case "Counterparty":
							CurrentViewModel = CounterpartyVM;
							break;
						case "Order":
							CurrentViewModel = OrderVM;
							break;
						case "Employee":
							CurrentViewModel = EmployeeVM;
							break;
					}
				}
			}
		}

		public MainViewModel(
			CounterpartyViewModel counterpartyVM,
			OrderViewModel orderVM,
			EmployeeViewModel employeeVM)
		{
			CounterpartyVM = counterpartyVM;
			OrderVM = orderVM;
			EmployeeVM = employeeVM;

			SelectedModelName = ModelNames.First();
		}
	}
}
