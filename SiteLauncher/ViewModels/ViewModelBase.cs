using System;
using System.Windows.Input;
using Netcorex.SiteLauncher.Common;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
  public abstract class ViewModelBase<T>
    where T : ModelBase
  {
    private readonly T m_Model;


    protected ViewModelBase(T model)
    {
      LaunchCommand = new RelayCommand(LaunchCommandAction);
      if (model == null)
        throw new ArgumentNullException("model");
      m_Model = model;
    }

    public T Model
    {
      get { return m_Model; }
    }
    public ICommand LaunchCommand { get; set; }


    public abstract void Launch();


    protected void LaunchCommandAction(object parameter)
    {
      Launch();
    }
  }
}