using System.IO;
using Netcorex.SiteLauncher.Validations;

namespace Netcorex.SiteLauncher.Models
{
	/// <summary>
	/// "Datový" model pro souborovou stránku
	/// </summary>
	public class FileSiteModel : ModelBase
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
				SetProperty(ref _path, value, "Path");
				IsVerified = File.Exists(_path);
			}
		}
	}
}