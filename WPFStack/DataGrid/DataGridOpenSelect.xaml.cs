using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFStack.Model;

namespace WPFStack.DataGrid
{
    /// <summary>
    /// Interaction logic for DataGridOpenSelect.xaml
    /// </summary>
    public partial class DataGridOpenSelect : Page
    {
        public DataGridOpenSelect()
        {
            InitializeComponent();
        }


        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            var person = dgPeople.SelectedItem as Person;

            MessageBox.Show($"Checkout {person.Name} ");

        }

        private void dgPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = dgPeople.SelectedItem as Person;

            MessageBox.Show($"Checkout {person.First} ");

        }
    }
}
