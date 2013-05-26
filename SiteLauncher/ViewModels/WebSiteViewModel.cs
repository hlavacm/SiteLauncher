using System.Diagnostics;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
  /// <summary>
  /// View Model for the Web Site Model
  /// </summary>
  public class WebSiteViewModel : SiteViewModelBase<WebSiteModel>
	{
		public WebSiteViewModel(WebSiteModel model)
			: base(model)
		{
		}


		public sealed override void Launch()
		{
			Process.Start(Model.Url);
		}
	}
}
