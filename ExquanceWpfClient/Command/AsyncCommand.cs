using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExquanceWpfClient.Command
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }

    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
    }

    public abstract class AsyncCommand : IAsyncCommand
    {
        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }

        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public abstract Task ExecuteAsync(object parameter);

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }

    public abstract class AsyncCommand<T> : IAsyncCommand<T>
    {
        #region private

        private bool _isExecuting;

        #endregion

        #region public

        public event EventHandler CanExecuteChanged;

        public bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public bool CanExecute(T parameter)
        {
            return !_isExecuting;
        }

        #endregion

        public abstract Task ExecuteAsync(T parameter);

        #region Explicit implementations

        bool ICommand.CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        async void ICommand.Execute(object parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            IsExecuting = true;

            await ExecuteAsync((T) parameter);

            IsExecuting = false;
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}