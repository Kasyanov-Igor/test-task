using System.Collections.ObjectModel;
using System.Windows.Input;
using Test_task.Model.Entities;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
	public class CounterpartyViewModel : ViewModel
	{
		private readonly IRepository<Counterparty> _repository;

		public ObservableCollection<Counterparty> Counterparties { get; } = new();

		private Counterparty _selectedCounterparty;
		public Counterparty SelectedCounterparty
		{
			get => _selectedCounterparty;
			set
			{
				_selectedCounterparty = value;
				OnPropertyChanged();
			}
		}

		public ICommand LoadCommand { get; }
		public ICommand AddCommand { get; }
		public ICommand DeleteCommand { get; }

		public CounterpartyViewModel(IRepository<Counterparty> repository)
		{
			this._repository = repository;

			LoadCommand = new RelayCommand(async _ => await LoadAsync());
			AddCommand = new RelayCommand(async _ => await AddAsync());
			DeleteCommand = new RelayCommand(async _ => await DeleteAsync(), _ => SelectedCounterparty != null);
		}

		private async Task LoadAsync()
		{
			Counterparties.Clear();
			var items = await _repository.Get();
			foreach (var item in items)
				Counterparties.Add(item);
		}

		private async Task AddAsync()
		{
			var newCounterparty = new Counterparty
			{
				Name = "New Counterparty",
				INN = "0000000000",
                CuratorEmployeeId = 1
			};
			await _repository.Add(newCounterparty);
			Counterparties.Add(newCounterparty);
		}

		private async Task DeleteAsync()
		{
			if (SelectedCounterparty != null)
			{
				await _repository.Delete(SelectedCounterparty.Id);
				Counterparties.Remove(SelectedCounterparty);
			}
		}
	}
}
