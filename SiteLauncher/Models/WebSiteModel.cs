using Netcorex.Shared.WPF.Helpers;
using Netcorex.Shared.WPF.Validations;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// Model for the Web Sites (based on url)
  /// </summary>
  public class WebSiteModel : SiteModelBase
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
        SetProperty(ref _url, value);
        IsVerified = Features.IsUrlValid(_url);
      }
    }
  }
}
