using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Netcorex.SiteLauncher.Validations;

namespace SiteLauncher.Tests.Validations
{
  [TestClass]
  public class FileExistsValidationTest
  {
    private readonly FileExistsValidationAttribute m_FileExistsValidationAttribute = new FileExistsValidationAttribute();


    [TestMethod]
    public void NullAndEmptyTestMethod()
    {
      Assert.IsFalse(m_FileExistsValidationAttribute.IsValid(null));
      Assert.IsFalse(m_FileExistsValidationAttribute.IsValid(string.Empty));
    }

    [TestMethod]
    public void GoodFileTestMethod()
    {
      string currentDirectory = Directory.GetCurrentDirectory();
      Assert.IsTrue(m_FileExistsValidationAttribute.IsValid(string.Format("{0}\\SiteLauncher.exe", currentDirectory)));
      Assert.IsTrue(m_FileExistsValidationAttribute.IsValid(string.Format("{0}/SiteLauncher.exe", currentDirectory)));
      Assert.IsTrue(m_FileExistsValidationAttribute.IsValid("c:\\Windows\\notepad.exe"));
      Assert.IsTrue(m_FileExistsValidationAttribute.IsValid("c:/Windows/notepad.exe"));
    }

    [TestMethod]
    public void BadFileTestMethod()
    {
      string currentDirectory = Directory.GetCurrentDirectory();
      Assert.IsFalse(m_FileExistsValidationAttribute.IsValid(string.Format("{0}\\NotExistingFileName.exe", currentDirectory)));
      Assert.IsFalse(m_FileExistsValidationAttribute.IsValid(string.Format("{0}/NotExistingFileName.exe", currentDirectory)));
      Assert.IsFalse(m_FileExistsValidationAttribute.IsValid("c:/Users/Dowloads/Last/Year/internet.exe"));
    }
  }
}
