using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EnvironmentalMonitoring.ViewModels;
namespace EnvironmentalMonitoring.Views.Windows
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            RegistrationWindowViewModel vm = new RegistrationWindowViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(Close);
        }
    }
}
