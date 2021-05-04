using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EnvironmentalMonitoring.Data;
using EnvironmentalMonitoring.Infrastructures.Commands;
using EnvironmentalMonitoring.Models;
using EnvironmentalMonitoring.ViewModels.Base;


namespace EnvironmentalMonitoring.ViewModels
{
    class RegistrationWindowViewModel : ViewModelBase
    {
        #region Properties
        #region Title 
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
        #region EmailTextBoxProp
        private string _emailTextBoxProp = String.Empty;
        public string EmailTextBoxProp
        {
            get => _emailTextBoxProp;
            set => Set(ref _emailTextBoxProp, value);
        }
        #endregion
        #endregion

        #region Commands
        #region OpenMainWindow
        public ICommand OpenMainWindow { get; }
        private void OnOpenMainWindowExecuted(object p)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            CloseAction();
        }
        private bool CanOpenMainWindowExecute(object p) => true;
        #endregion
        #region RegCommand
        public ICommand RegCommand { get; }
        private void OnRegCommandExecuted(object p)
        {
            if (IsValid())
            {
                User tempUser;
                using (ApplicationContext context = new ApplicationContext())
                {
                    tempUser = new User { login = LoginTextBoxProp, password = PasswordBoxProp, email = EmailTextBoxProp };
                    context.Users.Add(tempUser);
                    context.SaveChanges();
                }
                MessageBox.Show("Реєстрація відбулась успішно!");
            }
            else
                MessageBox.Show("Ви ввели не вірно дані для заповнення");

        }
        private bool CanRegCommandExecute(object p) => true;
        #endregion
        #endregion

        public RegistrationWindowViewModel()
        {
            #region Commands
            OpenMainWindow = new RelayCommand(OnOpenMainWindowExecuted, CanOpenMainWindowExecute);
            RegCommand = new RelayCommand(OnRegCommandExecuted, CanRegCommandExecute);
            #endregion
        }
        #region Validation region
        private bool IsValid()
        {
            if (isLoginValid() && IsEmailValid() && isPasswordValid())
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    User tempUser = context.Users.Where(u => u.login == LoginTextBoxProp ||
                    u.email == EmailTextBoxProp).FirstOrDefault();
                    if (tempUser == null)
                        return true;
                    else
                        MessageBox.Show("Такий логін або Email вже існує");
                }
            }
            return false;
        }
        private bool isLoginValid()
        {
            LoginTextBoxProp.ToLower().Trim();
            if (LoginTextBoxProp.Length > 5 && LoginTextBoxProp.Length < 20)
                return true;

            MessageBox.Show("Логін має містити не менше 5 символів і не більше 20");
            return false;
        }
        private bool IsEmailValid()
        {
            EmailTextBoxProp.ToLower().Trim();
            if (EmailTextBoxProp.Length > 5 && EmailTextBoxProp.Length < 30 && EmailTextBoxProp.Contains("@"))
                return true;

            MessageBox.Show("Email має містити не менше 5 символів і не більше 20");
            return false;
        }
        private bool isPasswordValid()
        {
            if (PasswordBoxProp.Length > 5 && PasswordBoxProp.Length < 20)
                return true;

            MessageBox.Show("Пароль введено не вірно");
            return false;
        }
        #endregion
    }
}
