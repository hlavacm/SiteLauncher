using System;
using System.IO;
using Netcorex.Shared.WPF.Validations;
using Netcorex.SiteLauncher.Properties;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// Model for the Browsers
  /// </summary>
  public class BrowserModel : SiteModelBase
  {
    private string _title;
    private string _iconName;
    private string _iconPath;
    private string _web;
    private readonly string _defaultSystemPath;
    private string _systemPath;
    private bool _isRequired;


    public BrowserModel(string title, string web, string defaultSystemPath, string currentSystemPath)
    {
      if (string.IsNullOrEmpty(title))
      {
        throw new ArgumentNullException("title");
      }
      Title = title;
      if (string.IsNullOrEmpty(web))
      {
        throw new ArgumentNullException("web");
      }
      Web = web;
      if (string.IsNullOrEmpty(defaultSystemPath))
      {
        throw new ArgumentNullException("defaultSystemPath");
      }
      _defaultSystemPath = defaultSystemPath;
      if (string.IsNullOrEmpty(currentSystemPath))
      {
        currentSystemPath = _defaultSystemPath;
      }
      SystemPath = currentSystemPath;
      if (IsVerified)
      {
        IsRequired = true;
      }
    }

    public BrowserModel(string title, string web, string defaultSystemPath)
      : this(title, web, defaultSystemPath, null)
    {
    }


    public string Title
    {
      get { return _title; }
      set
      {
        SetProperty(ref _title, value);
        if (string.IsNullOrEmpty(_title))
        {
          IconName = IconPath = null;
        }
        else
        {
          IconName = string.Format("{0}.png", _title.Trim().Replace(" ", string.Empty).ToLower());
          IconPath = string.Format("pack://application:,,,/SiteLauncher;component/Icons/{0}", IconName);
        }
      }
    }
    public string IconName
    {
      get { return _iconName; }
      private set { SetProperty(ref _iconName, value); }
    }
    public string IconPath
    {
      get { return _iconPath; }
      private set { SetProperty(ref _iconPath, value); }
    }
    [UrlValidation]
    public string Web
    {
      get { return _web; }
      set { SetProperty(ref _web, value); }
    }
    public string DefaultSystemPath
    {
      get { return _defaultSystemPath; }
    }
    [FileExistsValidation]
    public string SystemPath
    {
      get { return _systemPath; }
      set
      {
        SetProperty(ref _systemPath, value);
        IsVerified = File.Exists(_systemPath);
        if (_systemPath != DefaultSystemPath)
        {
          switch (IconName) // update current user´s browser path by string key...
          {
            case "internetexplorer":
              Settings.Default.InternetExplorerPath = _systemPath;
              break;
            case "firefox":
              Settings.Default.FirefoxPath = _systemPath;
              break;
            case "opera":
              Settings.Default.OperaPath = _systemPath;
              break;
            case "chrome":
              Settings.Default.ChromePath = _systemPath;
              break;
            case "safari":
              Settings.Default.SafariPath = _systemPath;
              break;
            case "maxthon":
              Settings.Default.MaxthonPath = _systemPath;
              break;
          }
        }
      }
    }
    public bool IsRequired
    {
      get { return _isRequired; }
      set { SetProperty(ref _isRequired, value); }
    }
  }
}
