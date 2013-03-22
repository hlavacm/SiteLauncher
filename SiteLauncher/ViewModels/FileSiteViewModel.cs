using System;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Win32;
using Netcorex.SiteLauncher.Common;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
  public class FileSiteViewModel : ViewModelBase<FileSiteModel>
  {
    public FileSiteViewModel(FileSiteModel model)
      : base(model)
    {
      SelectPathCommand = new RelayCommand(SelectPathCommandAction);
    }


    public ICommand SelectPathCommand { get; set; }


    private void SelectPathCommandAction(object parameter)
    {
      OpenFileDialog dialog = new OpenFileDialog
        {
          DefaultExt = ".html",
          Filter = "All Web files (*.*)|*.*",
          InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
          RestoreDirectory = true,
        };
      if (dialog.ShowDialog() == true)
        Model.Path = dialog.FileName;
    }

    public sealed override void Launch()
    {
      Process.Start(Model.Path);
    }
  }
}