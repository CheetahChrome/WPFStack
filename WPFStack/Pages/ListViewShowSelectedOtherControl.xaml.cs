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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFStack.Model;

namespace WPFStack.Pages
{
    /// <summary>
    /// Interaction logic for ListViewShowSelectedOtherControl.xaml
    /// </summary>
    public partial class ListViewShowSelectedOtherControl : Page
    {
        public ListViewShowSelectedOtherControl()
        {
            InitializeComponent();
        }


        private ListCollectionView CurrentView { get; set; }
    private void ProcessChange(object sender, RoutedEventArgs e)
    {
        if (lbOriginal.ItemsSource is Orders asOrders)
        {
            lbShowSelected.ItemsSource = null; // Inform control of reset
            lbShowSelected.ItemsSource = asOrders.Where(ord => ord.InProgress)
                                                 .Select(ord => ord.CustomerName)
                                                 .ToList();
        }
         

    }

  
    }
}
