using System;
using System.Reflection;

namespace Netcorex.SiteLauncher.Helpers
{
	public class AssemblyInfoHelper
	{
		private readonly Assembly _assembly;
		private string _title;
		private string _version;
		private string _description;
		private string _product;
		private string _company;
		private string _copyright;
		private string _trademark;


		public AssemblyInfoHelper(Assembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException("assembly");
			}
			_assembly = assembly;
		}


		public Assembly Assembly
		{
			get { return _assembly; }
		}
		public string Title
		{
			get { return _title ?? (_title = GetTitle()); }
		}
		public string Version
		{
			get { return _version ?? (_version = GetVersion()); }
		}
		public string Description
		{
			get { return _description ?? (_description = GetDescription()); }
		}
		public string Product
		{
			get { return _product ?? (_product = GetProduct()); }
		}
		public string Company
		{
			get { return _company ?? (_company = GetCompany()); }
		}
		public string Copyright
		{
			get { return _copyright ?? (_copyright = GetCopyright()); }
		}
		public string Trademark
		{
			get { return _trademark ?? (_trademark = GetTrademark()); }
		}


		private string GetTitle()
		{
			return GetAttributeValue<AssemblyTitleAttribute>(x => x.Title);
		}

		private string GetVersion()
		{
			return Features.GetVersion(_assembly.GetName().Version);
		}

		private string GetDescription()
		{
			return GetAttributeValue<AssemblyDescriptionAttribute>(x => x.Description);
		}

		private string GetProduct()
		{
			return GetAttributeValue<AssemblyProductAttribute>(x => x.Product);
		}

		private string GetCompany()
		{
			return GetAttributeValue<AssemblyCompanyAttribute>(x => x.Company);
		}

		private string GetCopyright()
		{
			return GetAttributeValue<AssemblyCopyrightAttribute>(x => x.Copyright);
		}

		private string GetTrademark()
		{
			return GetAttributeValue<AssemblyTrademarkAttribute>(x => x.Trademark);
		}

		private string GetAttributeValue<T>(Func<T, string> valueFunc)
		  where T : Attribute
		{
			object[] customAttributes = _assembly.GetCustomAttributes(typeof(T), false);
			if ((customAttributes.Length == 0))
			{
				return null;
			}
			return valueFunc((T)customAttributes[0]);
		}
	}
}