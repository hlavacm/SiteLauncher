using System.IO;
using Netcorex.Shared.WPF.Validations;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// Model for the File Sites (based on file path)
  /// </summary>
  public class FileSiteModel : SiteModelBase
  {
    private string _path;


    public FileSiteModel(string path = null)
    {
      Path = path;
    }


    [FileExistsValidation]
    public string Path
    {
      get { return _path; }
      set
      {
        SetProperty(ref _path, value);
        IsVerified = File.Exists(_path);
      }
    }
  }
}
