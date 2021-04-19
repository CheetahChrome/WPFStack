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
using WPFStack.Operations;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for DataGridQuestions.xaml
    /// </summary>
    public partial class DataGridQuestions : Window
    {
        public DataGridQuestions()
        {
            InitializeComponent();


        }

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Got Focus");
        }

        //private void dgPeople_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        //{
        //    switch (dgPeople.SelectedIndex)
        //    {
        //    case 1:
        //        FrameworkElement fe = e.Source as FrameworkElement;
        //        fe.ContextMenu.Items
        //        break;
        //    }
        //}
    }
}
