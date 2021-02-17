﻿using System;
using System.Windows.Input;

namespace POCMeasurementConverter.Command
{
    public class SimpleCommand : ICommand
    {
        /// <summary>
        /// Action delegate to be executed by the command
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Can execute predicate of the command
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Default constructor of the <see cref="SimpleCommand"/>
        /// </summary>
        /// <param name="execute">Execute action deletage</param>
        /// <param name="canExecute">Can execute predicate of the command</param>
        public SimpleCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Indicates weither the command can be executed
        /// </summary>
        /// <param name="parameter">Parameter of the command call</param>
        /// <returns>Executable status of the command</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter">Parameter of the command call</param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// Event which indicates that the value of CanExecute has been changed
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
