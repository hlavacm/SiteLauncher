using Netcorex.Shared.WPF.Models;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// Extended basis for (Sites and Browsers) Models
  /// </summary>
  public abstract class SiteModelBase : ModelBase
  {
    private bool _isVerified;


    public bool IsVerified
    {
      get { return _isVerified; }
      protected set { SetProperty(ref _isVerified, value); }
    }
  }
}
