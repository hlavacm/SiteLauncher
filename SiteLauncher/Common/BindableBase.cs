using System.ComponentModel;

namespace Netcorex.SiteLauncher.Common
{
  public abstract class BindableBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;


    protected bool SetProperty<T>(ref T storage, T value, string propertyName)
    {
      if (Equals(storage, value))
        return false;
      storage = value;
      OnPropertyChanged(propertyName);
      return true;
    }

    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler eventHandler = PropertyChanged;
      if (eventHandler == null)
        return;
      eventHandler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}