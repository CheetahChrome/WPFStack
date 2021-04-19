using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPFStack.Model
{
    public class LaunchOperation : INotifyPropertyChanged
    {


        private bool _LaunchApprovalAlphaGiven;
        private bool _LaunchApprovalOmegaGiven;


        public bool LaunchApprovalAlphaGiven
        {
            get { return _LaunchApprovalAlphaGiven; }
            set { _LaunchApprovalAlphaGiven = value; OnPropertyChanged("LaunchApprovalAlphaGiven"); }
        }


        public bool LaunchApprovalOmegaGiven
        {
            get { return _LaunchApprovalOmegaGiven; }
            set { _LaunchApprovalOmegaGiven = value; OnPropertyChanged("LaunchApprovalOmegaGiven"); }
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
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
