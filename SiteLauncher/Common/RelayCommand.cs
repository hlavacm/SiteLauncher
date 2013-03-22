﻿using System;
using System.Windows.Input;

namespace Netcorex.SiteLauncher.Common
{
  public class RelayCommand : ICommand
  {
    private readonly Action<object> m_Execute;
    private readonly Predicate<object> m_CanExecute;


    public RelayCommand(Action<object> execute)
      : this(execute, null)
    {
    }

    public RelayCommand(Action<object> execute, Predicate<object> canExecute)
    {
      if (execute == null)
        throw new ArgumentNullException("execute");

      m_Execute = execute;
      m_CanExecute = canExecute;
    }


    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }


    public bool CanExecute(object parameter)
    {
      return m_CanExecute == null || m_CanExecute(parameter);
    }

    public void Execute(object parameter)
    {
      m_Execute(parameter);
    }
  }
}