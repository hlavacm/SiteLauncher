using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher.Views
{
	public partial class BrowserView
	{
		public BrowserView()
		{
			InitializeComponent();
		}


		public new BrowserViewModel DataContext
		{
			get { return base.DataContext as BrowserViewModel; }
			set { base.DataContext = value; }
		}
	}
}