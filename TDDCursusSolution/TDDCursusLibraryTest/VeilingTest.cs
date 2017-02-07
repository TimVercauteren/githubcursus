using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class VeilingTest
    {
        private Veiling veiling;
        [TestInitialize]
        public void Initialize()
        {
            veiling = new Veiling();
        }
        [TestMethod]
        public void HoogsteBodIsNulZonderBiedingen()
        {
            Assert.AreEqual(0, new Veiling().HoogsteBod);
        }
        [TestMethod]
        public void HoogsteBodNa1BodIsHetBod()
        {
            veiling.DoeBod(30);
            Assert.AreEqual(30, veiling.HoogsteBod);
        }
        [TestMethod]
        public void HoogsteBodNa2BiedingenIsDeHoogsteBieding()
        {
            veiling.DoeBod(10);
            veiling.DoeBod(40);
            veiling.DoeBod(20);
            Assert.AreEqual(40, veiling.HoogsteBod);
        }
    }
}
