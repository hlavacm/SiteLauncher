using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher.Views
{
	public partial class FileSiteView
	{
		public FileSiteView()
		{
			InitializeComponent();
		}


		public new FileSiteViewModel DataContext
		{
			get { return base.DataContext as FileSiteViewModel; }
			set { base.DataContext = value; }
		}
	}
}