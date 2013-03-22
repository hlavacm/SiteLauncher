using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Netcorex.SiteLauncher.Common;
using Netcorex.SiteLauncher.Helpers;
using Netcorex.SiteLauncher.Localization;

namespace Netcorex.SiteLauncher.ViewModels
{
  public class MainViewModel : BindableBase
  {
    private readonly WebSiteViewModel m_WebSite;
    private readonly FileSiteViewModel m_FileSite;
    private readonly ObservableCollection<BrowserViewModel> m_Browsers;


    public MainViewModel(WebSiteViewModel webSite, FileSiteViewModel fileSite, ObservableCollection<BrowserViewModel> browsers)
    {
      AboutCommand = new RelayCommand(AboutCommandAction);
      SelectAllBrowsersCommand = new RelayCommand(SelectAllBrowsersCommandAction);
      UnselectAllBrowsersCommand = new RelayCommand(UnselectAllBrowsersCommandAction);
      LaunchAllWebSitesCommand = new RelayCommand(LaunchAllWebSitesCommandAction);
      LaunchAllFileSitesCommand = new RelayCommand(LaunchAllFileSitesCommandAction);
      StartAllBrowsersCommand = new RelayCommand(StartAllBrowsersCommandAction);
      LaunchAllBrowserWebsCommand = new RelayCommand(LaunchAllBrowserWebsCommandAction);
      if (webSite == null)
        throw new ArgumentNullException("webSite");
      m_WebSite = webSite;
      if (fileSite == null)
        throw new ArgumentNullException("fileSite");
      m_FileSite = fileSite;
      if (browsers == null)
        throw new ArgumentNullException("browsers");
      m_Browsers = browsers;
    }


    public WebSiteViewModel WebSite
    {
      get { return m_WebSite; }
    }
    public FileSiteViewModel FileSite
    {
      get { return m_FileSite; }
    }
    public ObservableCollection<BrowserViewModel> Browsers
    {
      get { return m_Browsers; }
    }
    public ICommand AboutCommand { get; set; }
    public ICommand SelectAllBrowsersCommand { get; set; }
    public ICommand UnselectAllBrowsersCommand { get; set; }
    public ICommand LaunchAllWebSitesCommand { get; set; }
    public ICommand LaunchAllFileSitesCommand { get; set; }
    public ICommand StartAllBrowsersCommand { get; set; }
    public ICommand LaunchAllBrowserWebsCommand { get; set; }


    private void AboutCommandAction(object parameter)
    {
      StringBuilder aboutBuilder = new StringBuilder();
      aboutBuilder.AppendLine(App.ProgramName);
      aboutBuilder.AppendLine(string.Format("v{0}", Features.GetVersion()));
      aboutBuilder.AppendLine("mailto:hlavacm@hotmail.com/");
      aboutBuilder.AppendLine("http://blog.netcorex.cz/");
      aboutBuilder.AppendLine(App.ProgramCopyright);
      aboutBuilder.AppendLine("---");
      aboutBuilder.AppendLine("FAMFAMFAM Silk Icons");
      aboutBuilder.AppendLine("www.famfamfam.com/lab/icons/silk");
      MessageBox.Show(aboutBuilder.ToString(), Titles.About, MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void SelectAllBrowsersCommandAction(object parameter)
    {
      foreach (BrowserViewModel browser in Browsers)
        browser.Model.IsRequired = true;
    }

    private void UnselectAllBrowsersCommandAction(object parameter)
    {
      foreach (BrowserViewModel browser in Browsers)
        browser.Model.IsRequired = false;
    }

    private void LaunchAllWebSitesCommandAction(object parameter)
    {
      List<BrowserViewModel> browsers = Browsers.Where(x => x.Model.IsRequired && x.Model.IsVerified).ToList();
      string webSiteUrl = WebSite.Model.Url;
      foreach (BrowserViewModel browser in browsers)
        browser.Launch(webSiteUrl);
    }

    private void LaunchAllFileSitesCommandAction(object parameter)
    {
      List<BrowserViewModel> browsers = Browsers.Where(x => x.Model.IsRequired && x.Model.IsVerified).ToList();
      string fileSitePath = FileSite.Model.Path;
      foreach (BrowserViewModel browser in browsers)
        browser.Launch(fileSitePath);
    }

    private void StartAllBrowsersCommandAction(object parameter)
    {
      List<BrowserViewModel> browsers = Browsers.Where(x => x.Model.IsRequired && x.Model.IsVerified).ToList();
      foreach (BrowserViewModel browser in browsers)
        browser.Start();
    }

    private void LaunchAllBrowserWebsCommandAction(object parameter)
    {
      List<BrowserViewModel> browsers = Browsers.Where(x => x.Model.IsRequired && x.Model.IsVerified).ToList();
      foreach (BrowserViewModel browser in browsers)
        browser.Launch();
    }
  }
}