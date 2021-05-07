using EnvironmentalMonitoring.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region Commands

        #endregion

        public HeadWindowViewModel()
        {
            #region Commands

            #endregion
        }
    }
}
