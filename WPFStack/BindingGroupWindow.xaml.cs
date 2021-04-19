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
using WPFStack.Model;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for BindingGroupWindow.xaml
    /// </summary>
    public partial class BindingGroupWindow : Window
    {
        public BindingGroupWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new LaunchOperation();
            grMain.BindingGroup.BeginEdit();


        }
    }
}
