using Microsoft.VisualStudio.TestTools.UnitTesting;
using Netcorex.SiteLauncher.Validations;

namespace SiteLauncher.Tests.Validations
{
	[TestClass]
	public class UrlValidationTest
	{
		private readonly UrlValidationAttribute _urlValidationAttribute = new UrlValidationAttribute();


		[TestMethod]
		public void NullAndEmptyTestMethod()
		{
			Assert.IsFalse(_urlValidationAttribute.IsValid(null));
			Assert.IsFalse(_urlValidationAttribute.IsValid(string.Empty));
		}

		[TestMethod]
		public void GoodUrlTestMethod()
		{
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://netcorex.cz"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://www.netcorex.cz"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://blog.netcorex.cz"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://netcorex.cz/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://www.netcorex.cz/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://blog.netcorex.cz/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://www.netcorex.cz/music-mix"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://www.netcorex.cz/music-mix/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("https://ib24.csob.cz/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://microsoft.com"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://www.microsoft.com/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://ftp.download.microsoft.com/"));
		}

		[TestMethod]
		public void BadUrlTestMethod()
		{
			Assert.IsFalse(_urlValidationAttribute.IsValid("netcorex"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("netcorex.cz"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("www.netcorex"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("www.netcorex.cz"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("blog.netcorex.cz"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("blog.netcorex"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("microsoft.com"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("www.microsoft.com"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("http://netcorex"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("http://netcorex"));
		}

		[TestMethod]
		public void LocalhostTestMethod()
		{
			Assert.IsFalse(_urlValidationAttribute.IsValid("localhost"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("localhost://"));
			Assert.IsFalse(_urlValidationAttribute.IsValid("localhost://website"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost/website"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost/website/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost/website/folder"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost/website/folder/"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost/website.cz"));
			Assert.IsTrue(_urlValidationAttribute.IsValid("http://localhost/website/folder.cz"));
		}
	}
}