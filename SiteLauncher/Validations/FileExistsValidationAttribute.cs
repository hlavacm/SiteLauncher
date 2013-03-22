using System.ComponentModel.DataAnnotations;
using System.IO;
using Netcorex.SiteLauncher.Localization;

namespace Netcorex.SiteLauncher.Validations
{
  public class FileExistsValidationAttribute : ValidationAttribute
  {
    public FileExistsValidationAttribute()
    {
      ErrorMessage = Titles.NotValidFile;
    }


    public override bool IsValid(object value)
    {
      if (value == null)
        return false;
      string path = value.ToString();
      if (string.IsNullOrEmpty(path))
        return false;
      return File.Exists(path);
    }
  }
}