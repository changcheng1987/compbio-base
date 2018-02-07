using System;
using BaseLibS.Num;
using NUnit.Framework;

namespace BaseLibS.Test.Num
{
    [TestFixture]
    public class ArrayUtilsTest
    {
        [Test]
        public void TestPackAndUnpackArrayOfArrays()
        {
            var arr = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6, 7, 8},
            };
            ArrayUtils.PackArrayOfArrays(arr, out var value, out var ind);
            var arr2 = ArrayUtils.UnpackArrayOfArrays(value, ind);
            Assert.AreEqual(arr.Length, arr2.Length);
            CollectionAssert.AreEqual(arr[0], arr2[0]);
            CollectionAssert.AreEqual(arr[1], arr2[1]);
        }

        [Test]
        public void TestPackAndUnpackArrayOfStrings()
        {
            var arr = new[] { "1", "2", "3", "4"};
            ArrayUtils.PackArrayOfStrings(arr, out var value, out var ind);
            var arr2 = ArrayUtils.UnpackArrayOfStrings(value, ind);
            CollectionAssert.AreEqual(arr, arr2);
        }
    }
}
