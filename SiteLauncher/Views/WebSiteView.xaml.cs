using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher.Views
{
  /// <summary>
  /// The View for Web Site (View/Model) edit
  /// </summary>
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
