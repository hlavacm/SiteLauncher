using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher.Views
{
	public partial class WebSiteView
	{
		public WebSiteView()
		{
			InitializeComponent();
		}


		public new WebSiteViewModel DataContext
		{
			get { return base.DataContext as WebSiteViewModel; }
			set { base.DataContext = value; }
		}
	}
}