using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Demo.Common.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    //áp dụng cho các button thêm - xóa - sửa - lọc
    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;



        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        //
        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    // áp dụng tạo button khu vực
    public class RelayCommand : ICommand
    {
        // Fields 
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion

        // Constructors 
        #region Constructors
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        //Members
        #region ICommand Members [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
        //áp dụng bàn phím số HDCSoft
        #region
        public class RelayCommandWithParameter : ICommand
        {
            readonly Action<object> _execute;
            readonly Func<bool> _canExecute;

            public RelayCommandWithParameter(Action<object> execute)
                : this(execute, null)
            {
            }

            public RelayCommandWithParameter(Action<object> execute, Func<bool> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }


            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute.Invoke();
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
                _execute(parameter);
            }

        }
        #endregion
        //RelayComand Backspace
        #region
        public class RelayCommandBackspace : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            private Action methodToExecute;
            private Func<bool> canExecuteEvaluator;
            public RelayCommandBackspace(Action methodToExecute, Func<bool> canExecuteEvaluator)
            {
                this.methodToExecute = methodToExecute;
                this.canExecuteEvaluator = canExecuteEvaluator;
            }
            public RelayCommandBackspace(Action methodToExecute)
                : this(methodToExecute, null)
            {
            }
            public bool CanExecute(object parameter)
            {
                if (this.canExecuteEvaluator == null)
                {
                    return true;
                }
                else
                {
                    bool result = this.canExecuteEvaluator.Invoke();
                    return result;
                }
            }
            public void Execute(object parameter)
            {
                this.methodToExecute.Invoke();
            }
            #endregion
            //Formatter
            #region
            public Func<int, string> Formatter { get; set; }
            #endregion
        }
    }
}
