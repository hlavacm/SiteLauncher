using Netcorex.SiteLauncher.ViewModels;

namespace Netcorex.SiteLauncher.Views
{
  /// <summary>
  /// The View for File Site (View/Model) edit
  /// </summary>
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
