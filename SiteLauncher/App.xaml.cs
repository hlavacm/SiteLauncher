using System.Windows;
using System.Windows.Threading;
using Netcorex.SiteLauncher.Localization;

namespace Netcorex.SiteLauncher
{
	public partial class App
	{
		public const string ProgramName = "Site Launcher";
		public const string ProgramTitle = "Web & File Site Launcher";
		public const string ProgramCompany = "NETCOREX";
		public const string ProgramCopyright = "Copyright © Martin Hlaváč 2013";


		private void AppOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			MessageBox.Show(e.Exception.Message, Titles.Error, MessageBoxButton.OK, MessageBoxImage.Error);
			e.Handled = true;
		}
	}
}