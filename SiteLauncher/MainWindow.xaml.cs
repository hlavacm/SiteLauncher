using System;
using System.Collections.ObjectModel;
using Netcorex.SiteLauncher.Models;
using Netcorex.SiteLauncher.Properties;
using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher
{
	public partial class MainWindow
	{
		public MainWindow()
			: base(640, 400)
		{
			InitializeComponent();
		}


		public new MainViewModel DataContext
		{
			get { return base.DataContext as MainViewModel; }
			set { base.DataContext = value; }
		}


		private void OnContentRendered(object sender, EventArgs e)
		{
			WebSiteViewModel webSite = new WebSiteViewModel(new WebSiteModel(Settings.Default.WebSiteUrl));
			FileSiteViewModel fileSite = new FileSiteViewModel(new FileSiteModel(Settings.Default.FileSitePath));
			ObservableCollection<BrowserViewModel> browsers = new ObservableCollection<BrowserViewModel>();
			string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", string.Empty);
			string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
			string localApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			browsers.Add(new BrowserViewModel(new BrowserModel("Internet Explorer", "http://windows.microsoft.com/en-US/internet-explorer/download-ie/", string.Format("{0}\\Internet Explorer\\iexplore.exe", programFiles), Settings.Default.InternetExplorerPath)));
			browsers.Add(new BrowserViewModel(new BrowserModel("Firefox", "http://www.mozilla.org/firefox/", string.Format("{0}\\Mozilla Firefox\\firefox.exe", programFilesX86), Settings.Default.FirefoxPath)));
			browsers.Add(new BrowserViewModel(new BrowserModel("Opera", "http://www.opera.com/", string.Format("{0}\\Opera\\Opera.exe", programFilesX86), Settings.Default.OperaPath)));
			browsers.Add(new BrowserViewModel(new BrowserModel("Chrome", "http://www.google.com/chrome/", string.Format("{0}\\Google\\Chrome\\Application\\chrome.exe", localApplicationData), Settings.Default.ChromePath)));
			browsers.Add(new BrowserViewModel(new BrowserModel("Safari", "http://www.apple.com/safari/", string.Format("{0}\\Safari\\Safari.exe", programFilesX86), Settings.Default.SafariPath)));
			browsers.Add(new BrowserViewModel(new BrowserModel("Maxthon", "http://www.maxthon.com/", string.Format("{0}\\Maxthon\\Bin\\Maxthon.exe", programFilesX86), Settings.Default.MaxthonPath)));
			DataContext = new MainViewModel(webSite, fileSite, browsers);
		}

		protected override void SaveSettings()
		{
			Settings.Default.WebSiteUrl = DataContext.WebSite.Model.Url;
			Settings.Default.FileSitePath = DataContext.FileSite.Model.Path;
			base.SaveSettings();
		}
	}
}