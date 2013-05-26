using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher.Views
{
  /// <summary>
  /// The View for Browser (View/Model) edit
  /// </summary>
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
