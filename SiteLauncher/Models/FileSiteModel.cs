using System.IO;
using Netcorex.SiteLauncher.Validations;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// "Datový" model pro souborovou stránku
  /// </summary>
  public class FileSiteModel : ModelBase
  {
    private string m_Path;


    public FileSiteModel(string path = null)
    {
      Path = path;
    }


    [FileExistsValidation]
    public string Path
    {
      get { return m_Path; }
      set
      {
        SetProperty(ref m_Path, value, "Path");
        IsVerified = File.Exists(m_Path);
      }
    }
  }
}