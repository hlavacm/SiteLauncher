using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Netcorex.SiteLauncher.Localization;

namespace Netcorex.SiteLauncher.Validations
{
	public class UrlValidationAttribute : ValidationAttribute
	{
		public const string UrlRegexPattern = @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|xxx|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{2}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&amp;%\$#\=~_\-]+))*$";


		public UrlValidationAttribute()
		{
			ErrorMessage = Titles.NotValidUrl;
		}


		public override bool IsValid(object value)
		{
			if (value == null)
			{
				return false;
			}
			string url = value.ToString();
			if (string.IsNullOrEmpty(url))
			{
				return false;
			}
			Regex urlRegex = new Regex(UrlRegexPattern);
			bool match = urlRegex.IsMatch(url);
			return match;
		}
	}
}