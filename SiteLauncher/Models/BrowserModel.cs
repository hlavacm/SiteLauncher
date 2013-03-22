using System;
using System.IO;
using Netcorex.SiteLauncher.Properties;
using Netcorex.SiteLauncher.Validations;

namespace Netcorex.SiteLauncher.Models
{
  /// <summary>
  /// "Datový" model pro prohlížeč
  /// </summary>
  public class BrowserModel : ModelBase
  {
    private string m_Title;
    private string m_IconName;
    private string m_IconPath;
    private string m_Web;
    private readonly string m_DefaultSystemPath;
    private string m_SystemPath;
    private bool m_IsRequired;


    public BrowserModel(string title, string web, string defaultSystemPath, string currentSystemPath)
    {
      if (string.IsNullOrEmpty(title))
        throw new ArgumentNullException("title");
      Title = title;
      if (string.IsNullOrEmpty(web))
        throw new ArgumentNullException("web");
      Web = web;
      if (string.IsNullOrEmpty(defaultSystemPath))
        throw new ArgumentNullException("defaultSystemPath");
      m_DefaultSystemPath = defaultSystemPath;
      if (string.IsNullOrEmpty(currentSystemPath))
        currentSystemPath = m_DefaultSystemPath;
      SystemPath = currentSystemPath;
      if (IsVerified)
        IsRequired = true;
    }

    public BrowserModel(string title, string web, string defaultSystemPath)
      : this(title, web, defaultSystemPath, null)
    {
    }


    public string Title
    {
      get { return m_Title; }
      set
      {
        SetProperty(ref m_Title, value, "Title");
        if (string.IsNullOrEmpty(m_Title))
          IconName = IconPath = null;
        else
        {
          IconName = string.Format("{0}.png", m_Title.Trim().Replace(" ", string.Empty).ToLower());
          IconPath = string.Format("pack://application:,,,/SiteLauncher;component/Icons/{0}", IconName);
        }
      }
    }
    public string IconName
    {
      get { return m_IconName; }
      private set { SetProperty(ref m_IconName, value, "IconName"); }
    }
    public string IconPath
    {
      get { return m_IconPath; }
      private set { SetProperty(ref m_IconPath, value, "IconPath"); }
    }
    [UrlValidation]
    public string Web
    {
      get { return m_Web; }
      set { SetProperty(ref m_Web, value, "Web"); }
    }
    public string DefaultSystemPath
    {
      get { return m_DefaultSystemPath; }
    }
    [FileExistsValidation]
    public string SystemPath
    {
      get { return m_SystemPath; }
      set
      {
        SetProperty(ref m_SystemPath, value, "SystemPath");
        IsVerified = File.Exists(m_SystemPath);
        if (m_SystemPath != DefaultSystemPath)
        {
          switch (IconName) // update current user´s browser path by string key...
          {
            case "internetexplorer":
              Settings.Default.InternetExplorerPath = m_SystemPath;
              break;
            case "firefox":
              Settings.Default.FirefoxPath = m_SystemPath;
              break;
            case "opera":
              Settings.Default.OperaPath = m_SystemPath;
              break;
            case "chrome":
              Settings.Default.ChromePath = m_SystemPath;
              break;
            case "safari":
              Settings.Default.SafariPath = m_SystemPath;
              break;
            case "maxthon":
              Settings.Default.MaxthonPath = m_SystemPath;
              break;
          }
        }
      }
    }
    public bool IsRequired
    {
      get { return m_IsRequired; }
      set { SetProperty(ref m_IsRequired, value, "IsRequired"); }
    }
  }
}