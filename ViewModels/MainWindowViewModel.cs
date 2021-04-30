using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EnvironmentalMonitoring.ViewModels.Base;
using EnvironmentalMonitoring.Infrastructures.Commands;
using EnvironmentalMonitoring.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace EnvironmentalMonitoring.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        string connectionString;
        #region Title of the main window
        private string _title = "Environmental Monitoring in the Lviv region";
        ///<summary>Заголовок вікна</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion
        #region Program version
        ///<summary>Поточна версія програми</summary>
        private string _version = "1.0";

        ///<summary>Поточна версія програми</summary>
        public string Version
        {
            get => _version;
            set => Set(ref _version, value);
        }
        #endregion

        #region Commands

        #region CloseAppCommand
        public ICommand CloseAppCommand { get; }
        private void OnCloseAppCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseAppCommandExecute(object p) => true;
        #endregion

        #region HelpCommand

        public ICommand HelpCommand { get; }
        private void OnHelpCommandExecuted(object p)
        {
            MessageBox.Show("Test Help box");
        }
        private bool CanHelpCommandExecute(object p) => true;

        #endregion

        #region AuthCommand
        public ICommand AuthCommand { get; }
        public void OnAuthCommandExecuted(object p)
        {
            
        }
        public bool CanAuthCommandExecute(object p) => true;
        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Commands

            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);

            HelpCommand = new RelayCommand(OnHelpCommandExecuted, CanHelpCommandExecute);
            AuthCommand = new RelayCommand(OnAuthCommandExecuted, CanAuthCommandExecute);
            #endregion

        }
    }
}
