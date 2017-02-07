using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class WoordTest  
    {
        [TestMethod]
        public void EenWoordIsEenPalinDroom()
        {
            Assert.IsTrue(new Woord("lepel").isPalinDroom());
        }
        [TestMethod]
        public void EenWoordIsGeenPalinDroom()
        {
            Assert.IsFalse(new Woord("palindroom").isPalinDroom());
        }
        [TestMethod]
        public void EenLegeStringIsEenPalindroom()
        {
            Assert.IsTrue(new Woord("").isPalinDroom());
        }
    }
}
