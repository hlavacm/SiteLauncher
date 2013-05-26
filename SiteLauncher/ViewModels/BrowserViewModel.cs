using System;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Win32;
using Netcorex.Shared.WPF.Common;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
  /// <summary>
  /// View Model for the Browser Model
  /// </summary>
  public class BrowserViewModel : SiteViewModelBase<BrowserModel>
	{
		public BrowserViewModel(BrowserModel model)
			: base(model)
		{
			SelectPathCommand = new RelayCommand(SelectPathCommandAction);
			StartCommand = new RelayCommand(StartCommandAction);
		}


		public ICommand SelectPathCommand { get; set; }
		public ICommand StartCommand { get; set; }


		public void Start()
		{
			Process.Start(Model.SystemPath);
		}

		public void Launch(string pathOrUrl)
		{
			if (string.IsNullOrEmpty(pathOrUrl))
			{
				throw new ArgumentNullException("pathOrUrl");
			}
			Process.Start(Model.SystemPath, pathOrUrl);
		}

		public sealed override void Launch()
		{
			Process.Start(Model.Web);
		}


		private void SelectPathCommandAction(object parameter)
		{
			OpenFileDialog dialog = new OpenFileDialog
			  {
				  DefaultExt = ".exe",
				  Filter = "Executable (Browser) Files (.exe)|*.exe",
				  InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
				  RestoreDirectory = true,
			  };
			if (dialog.ShowDialog() == true)
			{
				Model.SystemPath = dialog.FileName;
			}
		}

		private void StartCommandAction(object parameter)
		{
			Start();
		}
	}
}
