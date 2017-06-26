using System;
using System.Drawing;
using BaseLib.Graphic;
using BaseLibS.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaseLib.Test
{
    [TestClass]
    public class FontTest
    {
        [TestMethod]
        public void TestMonospaceFont()
        {
            var font2 = new Font2("Courier New", 9);
            var convertedFont = GraphUtils.ToFont(font2);
            var nativeFont = new Font(FontFamily.GenericMonospace, 9);
            Assert.AreEqual(nativeFont.Name, convertedFont.Name);
            Assert.AreEqual(nativeFont.Size, convertedFont.Size);
        }
    }
}
