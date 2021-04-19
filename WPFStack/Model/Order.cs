using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFStack.Model
{

    public enum OrderStatus { None, New, Processing, Shipped, Received };

    /// <summary>
    /// Class Orders which is a placeholder for Xaml example data. 
    /// </summary>
    public class Orders : List<Order> { }

    public class Order : INotifyPropertyChanged
    {
        public string CustomerName { get; set; }
        public int OrderId { get; set; }

        public bool InProgress { get; set; }

        public OrderStatus Status { get; set; }
    
        public string strStatus { get; set; }

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
