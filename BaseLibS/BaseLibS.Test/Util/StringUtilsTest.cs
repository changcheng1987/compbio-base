using System.Linq;
using BaseLibS.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseLibS.Test.Util {
	[TestClass]
	public class StringUtilsTest {
		[TestMethod]
		public void TestConcat() {
			string[] strings = {"", "b", "c"};
			string concatList = StringUtils.Concat(",", strings);
			Assert.AreEqual(",b,c", concatList);
			string concatEnumerable = StringUtils.Concat(",", strings.AsEnumerable());
			Assert.AreEqual(",b,c", concatEnumerable);
		}
	}
}