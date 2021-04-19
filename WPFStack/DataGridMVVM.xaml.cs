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
using WPFStack.Operations;

namespace WPFStack
{
    /// <summary>
    /// Interaction logic for DataGridMVVM.xaml
    /// </summary>
    public partial class DataGridMVVM : Window
    {
        private MainVm VM { get; set; }
        public DataGridMVVM()
        {
            InitializeComponent();

             DataContext = VM = new MainVm();

VM.DeleteItem = new OperationCommand((o) => MessageBox.Show("Delete Me"),
                                     (o) => (myGrid.SelectedItem as Order)?.InProgress == false );


        }

private void MyGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
{
    VM.DeleteItem.RaiseCanExecuteChanged();
}



        private void tbSelection_LostFocus(object sender, RoutedEventArgs e)
{
            
    if (string.IsNullOrWhiteSpace(tbSelection.Text) == false)
    {
        int userOrderId; 

        int.TryParse(tbSelection.Text, out userOrderId);

        if (userOrderId != -1)
        {
            var orders = myGrid.ItemsSource as List<Order>;

            var order = orders.FirstOrDefault(ord => ord.OrderId == userOrderId);

            if (order != null)
                myGrid.SelectedItem = order;
            else
                myGrid.SelectedIndex = -1; // Default to nothing.

        }
        else
            myGrid.SelectedIndex = -1; // Default to nothing.
    }

}


    }
}
