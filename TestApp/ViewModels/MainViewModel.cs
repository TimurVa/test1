using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using TestApp.Models;
using TestApp.OtherClases.Converters;
using TestApp.ViewModels.BaseVM;

namespace TestApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        #region Properties
        
        private double _finalAmount;
        public double FinalAmount
        {
            get => _finalAmount;
            set
            {
                _finalAmount = value;
                // in real world app. using FodyWeavers instead of this...
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public MainViewModel()
        {
        }

        #endregion

        #region Commands

        private ICommand _chooseJsonCommand;
        public ICommand ChooseJsonCommand => _chooseJsonCommand ?? (_chooseJsonCommand = new RelayCommand(ChooseJsonCommand_Executed));

        private void ChooseJsonCommand_Executed(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json Files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                FinalAmount = 0;
                Calculate(openFileDialog.FileName);
            }
        }

        #endregion

        #region Helpers

        private void Calculate(string path)
        {
            List<Employee> employee = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(path), new EmployeeToConcreteTypeConverter());

            foreach (var item in employee)
            {
                FinalAmount += item.CalculateSalary();
            }
        }

        #endregion
    }
}
