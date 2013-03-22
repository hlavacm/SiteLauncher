using Microsoft.VisualStudio.TestTools.UnitTesting;
using Netcorex.SiteLauncher.Validations;

namespace SiteLauncher.Tests.Validations
{
  [TestClass]
  public class UrlValidationTest
  {
    private readonly UrlValidationAttribute m_UrlValidationAttribute = new UrlValidationAttribute();


    [TestMethod]
    public void NullAndEmptyTestMethod()
    {
      Assert.IsFalse(m_UrlValidationAttribute.IsValid(null));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid(string.Empty));
    }

    [TestMethod]
    public void GoodUrlTestMethod()
    {
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://netcorex.cz"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://www.netcorex.cz"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://blog.netcorex.cz"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://netcorex.cz/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://www.netcorex.cz/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://blog.netcorex.cz/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://www.netcorex.cz/music-mix"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://www.netcorex.cz/music-mix/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("https://ib24.csob.cz/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://microsoft.com"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://www.microsoft.com/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://ftp.download.microsoft.com/"));
    }

    [TestMethod]
    public void BadUrlTestMethod()
    {
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("netcorex"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("netcorex.cz"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("www.netcorex"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("www.netcorex.cz"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("blog.netcorex.cz"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("blog.netcorex"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("microsoft.com"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("www.microsoft.com"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("http://netcorex"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("http://netcorex"));
    }

    [TestMethod]
    public void LocalhostTestMethod()
    {
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("localhost"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("localhost://"));
      Assert.IsFalse(m_UrlValidationAttribute.IsValid("localhost://website"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost/website"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost/website/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost/website/folder"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost/website/folder/"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost/website.cz"));
      Assert.IsTrue(m_UrlValidationAttribute.IsValid("http://localhost/website/folder.cz"));
    }
  }
}