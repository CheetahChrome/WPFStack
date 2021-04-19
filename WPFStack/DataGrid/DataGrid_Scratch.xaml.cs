using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WPFStack.DataGrid
{
    /// <summary>
    /// Interaction logic for DataGrid_Scratch.xaml
    /// </summary>
    public partial class DataGrid_Scratch : Window, INotifyPropertyChanged
    {


        private ObservableCollection<double> _MyObservableDoubles;

        public ObservableCollection<double> MyObservableDoubles
        {
            get => _MyObservableDoubles;
            set { _MyObservableDoubles = value; OnPropertyChanged(nameof(MyObservableDoubles)); }
        }

        public List<double> MyListDoubles { get; set; }

        public DataGrid_Scratch()
        {
            MyObservableDoubles = new ObservableCollection<double>();
            MyObservableDoubles.Add(86753.09);
            MyObservableDoubles.Add(2.0);

            MyListDoubles = new List<double>() { 86753.09 };
            InitializeComponent();
        }

        /// <summary>
        /// Event raised when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
