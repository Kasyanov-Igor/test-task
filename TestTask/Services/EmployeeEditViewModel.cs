using System.Collections.ObjectModel;
using System.Windows.Input;
using Test_task.Model;
using Test_task.Model.Enum;
using Test_task.Repositories.Interface;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
    public class EmployeeEditViewModel : ViewModel
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        private JobTitle _selectedJobTitle;

        public JobTitle SelectedJobTitle
        {
            get => _selectedJobTitle;
            set => SetProperty(ref _selectedJobTitle, value);
        }
        private DateTime _dob;
        public DateTime DOB
        {
            get => _dob;
            set => SetProperty(ref _dob, value);
        }
        public Array JobTitles => Enum.GetValues(typeof(JobTitle));
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public bool? DialogResult { get; private set; }
        public Action CloseAction { get; set; }

        public EmployeeEditViewModel()
        {
            this._dob = new DateTime(DateTime.Now.Year - 25, 1, 1);
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
    }
}
