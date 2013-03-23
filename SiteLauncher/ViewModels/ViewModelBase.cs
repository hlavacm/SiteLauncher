using System;
using System.Windows.Input;
using Netcorex.SiteLauncher.Common;
using Netcorex.SiteLauncher.Models;

namespace Netcorex.SiteLauncher.ViewModels
{
	public abstract class ViewModelBase<T>
	  where T : ModelBase
	{
		private readonly T _model;


		protected ViewModelBase(T model)
		{
			LaunchCommand = new RelayCommand(LaunchCommandAction);
			if (model == null)
				throw new ArgumentNullException("model");
			_model = model;
		}

		public T Model
		{
			get { return _model; }
		}
		public ICommand LaunchCommand { get; set; }


		public abstract void Launch();


		protected void LaunchCommandAction(object parameter)
		{
			Launch();
		}
	}
}