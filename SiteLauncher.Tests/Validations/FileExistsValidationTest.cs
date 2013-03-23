using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Netcorex.SiteLauncher.Validations;

namespace SiteLauncher.Tests.Validations
{
	[TestClass]
	public class FileExistsValidationTest
	{
		private readonly FileExistsValidationAttribute _fileExistsValidationAttribute = new FileExistsValidationAttribute();


		[TestMethod]
		public void NullAndEmptyTestMethod()
		{
			Assert.IsFalse(_fileExistsValidationAttribute.IsValid(null));
			Assert.IsFalse(_fileExistsValidationAttribute.IsValid(string.Empty));
		}

		[TestMethod]
		public void GoodFileTestMethod()
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			Assert.IsTrue(_fileExistsValidationAttribute.IsValid(string.Format("{0}\\SiteLauncher.exe", currentDirectory)));
			Assert.IsTrue(_fileExistsValidationAttribute.IsValid(string.Format("{0}/SiteLauncher.exe", currentDirectory)));
			Assert.IsTrue(_fileExistsValidationAttribute.IsValid("c:\\Windows\\notepad.exe"));
			Assert.IsTrue(_fileExistsValidationAttribute.IsValid("c:/Windows/notepad.exe"));
		}

		[TestMethod]
		public void BadFileTestMethod()
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			Assert.IsFalse(_fileExistsValidationAttribute.IsValid(string.Format("{0}\\NotExistingFileName.exe", currentDirectory)));
			Assert.IsFalse(_fileExistsValidationAttribute.IsValid(string.Format("{0}/NotExistingFileName.exe", currentDirectory)));
			Assert.IsFalse(_fileExistsValidationAttribute.IsValid("c:/Users/Dowloads/Last/Year/internet.exe"));
		}
	}
}
