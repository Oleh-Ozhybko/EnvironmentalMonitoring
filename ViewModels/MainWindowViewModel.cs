﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EnvironmentalMonitoring.ViewModels.Base;
using EnvironmentalMonitoring.Infrastructures.Commands;
using EnvironmentalMonitoring.Models;
using EnvironmentalMonitoring;
using Microsoft.Data.SqlClient;
using System.Configuration;
using EnvironmentalMonitoring.Data;

namespace EnvironmentalMonitoring.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        ApplicationContext context;
        #region Properties
        #region Title of the main window
        private string _title = "Environmental Monitoring in the Lviv region";
        ///<summary>Заголовок вікна</summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion
        #region LoginTextBoxProp
        private string _loginTextBoxProp = String.Empty;
        public string LoginTextBoxProp
        {
            get => _loginTextBoxProp;
            set => Set(ref _loginTextBoxProp, value);
        }
        #endregion
        #region PasswordBoxProp
        private string _passwordBoxProp;
        public string PasswordBoxProp
        {
            get => _passwordBoxProp;
            set => Set(ref _passwordBoxProp, value);
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
            context = new ApplicationContext();
            #region Commands
            
            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);

            HelpCommand = new RelayCommand(OnHelpCommandExecuted, CanHelpCommandExecute);
            AuthCommand = new RelayCommand(OnAuthCommandExecuted, CanAuthCommandExecute);
            #endregion

        }
    }
}
