using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace WPFStack.Bindings
{
    /// <summary>
    /// Interaction logic for BindingPage.xaml
    /// </summary>
    public partial class BindingPage : Window, INotifyPropertyChanged
    {
        private DispatcherTimer DispatcherTimer { get; set; } = new DispatcherTimer();

    private int _PartA;
    private int _PartB;

    public int PartA
    {
        get => _PartA;
        set { _PartA = value; OnPropertyChanged(nameof(PartA)); }
    }


    public int PartB
    {
        get => _PartB;
        set { _PartB = value; OnPropertyChanged(nameof(PartB)); }
    }
        public BindingPage()
        {
            InitializeComponent();
            DataContext = this;

            PartA = 235;
            PartB = 846;

            DispatcherTimer.Tick += (o, args) => { PartA++; };
            DispatcherTimer.Interval = new TimeSpan(0, 0, 1);

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            PartA++;

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
