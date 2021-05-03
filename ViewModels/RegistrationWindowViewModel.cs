using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        #endregion

        public RegistrationWindowViewModel()
        {
            #region Commands
            
            #endregion
        }
    }
}
