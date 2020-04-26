﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHome
{
    // The Command class reacts to the button click and activates its event property.
    public class EDoorCommand : ICommand
    {
        public event Action<object> DoorStatus;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            DoorStatus(parameter);
        }
    }
}
