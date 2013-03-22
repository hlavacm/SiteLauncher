using Netcorex.SiteLauncher.Helpers;
using Netcorex.SiteLauncher.Validations;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// "Datový" model pro webovou stránku
  /// </summary>
  public class WebSiteModel : ModelBase
  {
    private string m_Url;


    public WebSiteModel(string url = null)
    {
      Url = url;
    }

    [UrlValidation]
    public string Url
    {
      get { return m_Url; }
      set
      {
        SetProperty(ref m_Url, value, "Url");
        IsVerified = Features.IsUrlValid(m_Url);
      }
    }
  }
}