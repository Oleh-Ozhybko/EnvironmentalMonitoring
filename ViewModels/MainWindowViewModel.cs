using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnvironmentalMonitoring.ViewModels.Base;

namespace EnvironmentalMonitoring.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
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
    }
}
