using System.Linq;
using BaseLibS.Util;
using NUnit.Framework;

namespace BaseLibS.Test.Util
{
    [TestFixture]
    public class StringUtilsTest
    {
        [Test]
        public void TestConcat()
        {
            var strings = new[] {"", "b", "c"};
            var concatList = StringUtils.Concat(",", strings);
            Assert.AreEqual(",b,c", concatList);
            var concatEnumerable = StringUtils.Concat(",", strings.AsEnumerable());
            Assert.AreEqual(",b,c", concatEnumerable);
        }
    }
}
