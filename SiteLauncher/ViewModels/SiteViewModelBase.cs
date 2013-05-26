using System.Windows.Input;
using Netcorex.Shared.WPF.Common;
using Netcorex.Shared.WPF.ViewModels;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
  /// <summary>
  /// Extended basis for (Sites and Browsers) ViewModels
  /// </summary>
  /// <typeparam name="T">Generic type of <see cref="SiteModelBase"/></typeparam>
  public abstract class SiteViewModelBase<T> : ViewModelBase<T>
    where T : SiteModelBase
  {
    protected SiteViewModelBase(T model)
      : base(model)
    {
      LaunchCommand = new RelayCommand(LaunchCommandAction);
    }


    public ICommand LaunchCommand { get; set; }


    public abstract void Launch();


    protected void LaunchCommandAction(object parameter)
    {
      Launch();
    }
  }
}
