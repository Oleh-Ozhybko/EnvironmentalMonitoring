using EnvironmentalMonitoring.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EnvironmentalMonitoring.Infrastructures.Commands;

namespace EnvironmentalMonitoring.ViewModels
{
    class HeadWindowViewModel : ViewModelBase
    {
        #region Properties
        #region Title
        private string _title = "Моніторинг Екологічного середовища у Львівській області";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion
        #region Program version
        private string _version = "1.0";
        public string Version
        {
            get => _version;
            set => Set(ref _version, value);
        }
        #endregion

        #endregion

        #region Commands
        public ICommand CloseAppWindowCommand { get; }
        private void OnCloseAppWindowExecute(object p)
        {
            Application.Current.Shutdown();
        }
        private bool CanCloseAppWindowExecute(object p) => true;

        #region HelpCommand
        public ICommand HelpCommand { get; }
        private void OnHelpCommandExecuted(object p)
        {
            MessageBox.Show("Not implemented");
        }
        private bool CanHelpCommandExecute(object p) => true;
        #endregion
        #endregion

        public HeadWindowViewModel()
        {
            #region Commands
            CloseAppWindowCommand = new RelayCommand(OnCloseAppWindowExecute, CanCloseAppWindowExecute);
            HelpCommand = new RelayCommand(OnHelpCommandExecuted, CanHelpCommandExecute);
            #endregion
        }
    }
}
