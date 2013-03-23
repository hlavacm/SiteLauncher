using System.Diagnostics;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
	public class WebSiteViewModel : ViewModelBase<WebSiteModel>
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