﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class LogOutCommand : ICommand
    {
        MainWindowViewModel vm;
        public LogOutCommand(MainWindowViewModel vm)
        {
            this.vm = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.LogOut?.Invoke();
        }
    }
}