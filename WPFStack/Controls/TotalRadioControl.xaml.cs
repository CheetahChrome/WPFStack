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

namespace WPFStack.Controls
{
    /// <summary>
    /// Interaction logic for TotalRadioControl.xaml
    /// </summary>
    public partial class TotalRadioControl : UserControl
    {

        #region public List<Tuple<string,int>> Items
        /// <summary>
        /// 
        /// </summary>
        public List<Tuple<string,int>> Items
        {
            get { return GetValue(ItemsProperty) as List<Tuple<string,int>>; }
            set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Identifies the Items dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "Items",
                typeof(List<Tuple<string,int>>),
                typeof(TotalRadioControl),
                new PropertyMetadata(null, OnItemsPropertyChanged));

        /// <summary>
        /// ItemsProperty property changed handler.
        /// </summary>
        /// <param name="d">TotalRadioControl that changed its Items.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TotalRadioControl source = d as TotalRadioControl;
            List<Tuple<string,int>> value = e.NewValue as List<Tuple<string,int>>;

            //if ((source != null) && (value != null))
            //{
            //    var control = source.lbHorizontalRadioList.Items[0];
            //}

        }
        #endregion public List<Tuple<string,int>> Items


        public TotalRadioControl()
        {
            InitializeComponent();
        }

        private void ListLoaded(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = (ListBoxItem)(lbHorizontalRadioList.ItemContainerGenerator.ContainerFromIndex(0));
        }
    }
}
