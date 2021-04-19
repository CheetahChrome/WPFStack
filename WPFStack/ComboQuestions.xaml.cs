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

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for ComboQuestions.xaml
    /// </summary>
    public partial class ComboQuestions : Window
    {
        public ComboQuestions()
        {
            InitializeComponent();
            DataContext = new MainVm();
        }

        private void ChangeSelectedValue(object sender, RoutedEventArgs e)
        {
            cbMain.SelectedValue = "Pacific Silver";
        }
    }
}
