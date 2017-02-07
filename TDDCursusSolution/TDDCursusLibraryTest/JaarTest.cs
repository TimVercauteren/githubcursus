using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class JaarTest
    {
        [TestMethod]
        public void EenJaarDeelbaarDoor400IsEenSchrikkelJaar()
        {
            Assert.AreEqual(true, new Jaar(2000).IsSchrikkeljaar);
        }
        [TestMethod]
        public void EenJaarDeelbaarDoor100MaarNietDoor400IsGeenSchrikkeljaar()
        {
            Assert.AreEqual(false, new Jaar(1900).IsSchrikkeljaar);
        }
        [TestMethod]
        public void EenJaarDeelBaarDoor4IsEenSchrikkelJaar()
        {
            Assert.AreEqual(true, new Jaar(8).IsSchrikkeljaar);
        }
        [TestMethod]
        public void EenJaarNietDeelbaarDoor4IsGeenSchrikkelJaar()
        {
            Assert.AreEqual(false, new Jaar(13).IsSchrikkeljaar);
        }
    }
}
