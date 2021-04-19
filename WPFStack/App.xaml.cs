using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainVm VM { get; set; }


        public App()
        {
           // VM = this.Resources["MainViewModel"] as MainVm;
           VM = new MainVm();
        }

    }
}
