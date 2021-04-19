using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFStack.Operations
{
    public class OperationCommand : ICommand
    {

        #region Variables

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Properties

        private Func<object, bool> funcCanExecute { get; set; }
        private Action<object> actionExecute { get; set; }

        #endregion

        #region Construction/Initialization


        public OperationCommand(Action<object> executeAction, Func<object, bool> canExecute = null)
        {

            if (executeAction == null)
                throw new ArgumentNullException($"The operation to be found in the class {nameof(OperationCommand)} for the variable {nameof(executeAction)} is null.");

            actionExecute = executeAction;
            funcCanExecute = canExecute;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return funcCanExecute?.Invoke(parameter) ?? true;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void Execute(object parameter)
        {
            actionExecute?.Invoke(parameter);
        }

        #endregion

    }
}
