﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartHome
{
    // The Command class reacts to the button click and activates its event property.

    public class FridgeCommand:ICommand
    {
        public event Action<object> FridgeStatus;

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
            FridgeStatus(parameter);
        }
    }
}
