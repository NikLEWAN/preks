using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FupLib;

namespace FupTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTotalSucces()
        {
            Assert.AreEqual(36, TransportCalc.Total("12 12 12"));
        }

        [TestMethod]
        public void TestTotalFail()
        {
            Assert.AreEqual(10, TransportCalc.Total("9 2"));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "AntalKm is out of range")]
        public void TestAverageExceed()
        {
            TransportCalc.Average(2100, 5000);
        }
    }
}
