using System;
using System.Reflection;
using System.Text;
using System.Windows.Media.Imaging;

namespace Netcorex.SiteLauncher.Helpers
{
  public static class Features
  {
    public static string GetVersion(Version version = null)
    {
      if (version == null)
        version = Assembly.GetExecutingAssembly().GetName().Version;
      StringBuilder builder = new StringBuilder();
      builder.Append(string.Format("{0}.{1}", version.Major, version.Minor));
      int build = version.Build;
      if (build > 0)
        builder.Append(string.Format(".{0}", build));
      int revision = version.Revision;
      if (revision > 0)
      {
        if (build <= 0)
          builder.Append(".0");
        builder.Append(string.Format(".{0}", revision));
      }
      return builder.ToString();
    }

    public static bool IsUrlValid(string url)
    {
      return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
    }

    public static BitmapImage LoadImageFromUri(string uri)
    {
      BitmapImage image = new BitmapImage();
      image.BeginInit();
      image.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
      image.EndInit();
      return image;
    }
  }
}