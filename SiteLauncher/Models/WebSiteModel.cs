using Netcorex.SiteLauncher.Helpers;
using Netcorex.SiteLauncher.Validations;

namespace Netcorex.SiteLauncher.Models
{
	/// <summary>
	/// "Datový" model pro webovou stránku
	/// </summary>
	public class WebSiteModel : ModelBase
	{
		private string _url;


		public WebSiteModel(string url = null)
		{
			Url = url;
		}

		[UrlValidation]
		public string Url
		{
			get { return _url; }
			set
			{
				SetProperty(ref _url, value, "Url");
				IsVerified = Features.IsUrlValid(_url);
			}
		}
	}
}