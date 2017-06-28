using System.Linq;
using BaseLibS.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseLibS.Test.Util {
	[TestClass]
	public class FileUtilsTest {
		[TestMethod]
		public void TestAnnot()
		{
		    var executablePath = FileUtils.executablePath;
            Assert.IsNotNull(executablePath);

		}
	}
}