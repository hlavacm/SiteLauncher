using System;
using System.Reflection;

namespace Netcorex.SiteLauncher.Helpers
{
  public class AssemblyInfoHelper
  {
    private readonly Assembly m_Assembly;
    private string m_Title;
    private string m_Version;
    private string m_Description;
    private string m_Product;
    private string m_Company;
    private string m_Copyright;
    private string m_Trademark;


    public AssemblyInfoHelper(Assembly assembly)
    {
      if (assembly == null)
        throw new ArgumentNullException("assembly");
      m_Assembly = assembly;
    }


    public Assembly Assembly
    {
      get { return m_Assembly; }
    }
    public string Title
    {
      get { return m_Title ?? (m_Title = GetTitle()); }
    }
    public string Version
    {
      get { return m_Version ?? (m_Version = GetVersion()); }
    }
    public string Description
    {
      get { return m_Description ?? (m_Description = GetDescription()); }
    }
    public string Product
    {
      get { return m_Product ?? (m_Product = GetProduct()); }
    }
    public string Company
    {
      get { return m_Company ?? (m_Company = GetCompany()); }
    }
    public string Copyright
    {
      get { return m_Copyright ?? (m_Copyright = GetCopyright()); }
    }
    public string Trademark
    {
      get { return m_Trademark ?? (m_Trademark = GetTrademark()); }
    }


    private string GetTitle()
    {
      return GetAttributeValue<AssemblyTitleAttribute>(x => x.Title);
    }

    private string GetVersion()
    {
      return Features.GetVersion(m_Assembly.GetName().Version);
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
      object[] customAttributes = m_Assembly.GetCustomAttributes(typeof(T), false);
      if ((customAttributes.Length == 0))
        return null;
      return valueFunc((T)customAttributes[0]);
    }
  }
}