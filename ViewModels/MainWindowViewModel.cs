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
using EnvironmentalMonitoring;
using Microsoft.Data.SqlClient;
using System.Configuration;
using EnvironmentalMonitoring.Data;
using EnvironmentalMonitoring.Views.Windows;

namespace EnvironmentalMonitoring.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
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
        #region OpenRegWindow
        public ICommand OpenRegWindow { get; }
        private void OnOpenRegWindowExecuted(object p)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            CloseAction();
        }
        private bool CanOpenRegWindowExecute(object p) => true;
        #endregion


        #region AuthCommand
        public ICommand AuthCommand { get; }
        public void OnAuthCommandExecuted(object p)
        {
            User tempUser;
            using (ApplicationContext context = new ApplicationContext())
            {
                tempUser = context.Users.Where(u => u.login == LoginTextBoxProp && u.password == PasswordBoxProp)
                    .FirstOrDefault();
            }
            if (tempUser != null)
            {
                MessageBox.Show($"Ви ввійшли в систему під логіном - {tempUser.login}");
                HeadWindow headWindow = new HeadWindow();
                headWindow.Show();
                CloseAction();
            }

            else MessageBox.Show("Логін або пароль введено не вірно");
        }
        public bool CanAuthCommandExecute(object p) => true;
        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Commands
            AuthCommand = new RelayCommand(OnAuthCommandExecuted, CanAuthCommandExecute);
            OpenRegWindow = new RelayCommand(OnOpenRegWindowExecuted, CanOpenRegWindowExecute);
            #endregion
            
        }
    }
}
