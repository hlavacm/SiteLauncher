using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Netcorex.SiteLauncher.Common;

namespace Netcorex.SiteLauncher.Windows
{
  public abstract class WindowBase : Window
  {
    private readonly double m_DefaultWidth = 960;
    private readonly double m_DefaultHeight = 600;


    protected WindowBase()
    {
      CloseCommand = new RelayCommand(CloseCommandAction);
      CenterScreenCommand = new RelayCommand(CenterScreenCommandAction);
      DefaultSizeCommand = new RelayCommand(DefaultSizeCommandAction);
      MinWidth = 400;
      MinHeight = 300;
      //MaxWidth = SystemParameters.WorkArea.Width;
      //MaxHeight = SystemParameters.WorkArea.Height;
      //RibbonWindowService.FixMaximizedWindowTitle(this);
    }

    protected WindowBase(double defaultWidth, double defaultHeight)
      : this()
    {
      m_DefaultWidth = defaultWidth;
      m_DefaultHeight = defaultHeight;
    }


    public double DefaultWidth
    {
      get { return m_DefaultWidth; }
    }
    public double DefaultHeight
    {
      get { return m_DefaultHeight; }
    }
    public ICommand CloseCommand { get; set; }
    public ICommand CenterScreenCommand { get; set; }
    public ICommand DefaultSizeCommand { get; set; }


    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
      if ((Left + ActualWidth) > SystemParameters.WorkArea.Width
        || (Top + ActualHeight) > SystemParameters.WorkArea.Height)
        CenterScreenCommand.Execute(null);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      SaveSettings();
      base.OnClosing(e);
    }

    protected virtual void SaveSettings()
    {
      Properties.Settings.Default.Save();
    }

    private void CloseCommandAction(object parameter)
    {
      Close();
    }

    private void CenterScreenCommandAction(object parameter)
    {
      double left = (SystemParameters.WorkArea.Width / 2) - (Width / 2);
      double top = (SystemParameters.WorkArea.Height / 2) - (Height / 2);
      Left = left > 0 ? left : 0;
      Top = top > 0 ? top : 0;
    }

    private void DefaultSizeCommandAction(object parameter)
    {
      Width = DefaultWidth;
      Height = DefaultHeight;
    }
  }
}