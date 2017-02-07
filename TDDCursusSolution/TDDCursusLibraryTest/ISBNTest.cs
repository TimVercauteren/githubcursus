using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class ISBNTest
    {
        [TestMethod]
        public void EenISBNMet13CijfersEnJuisteControleIsJuist()
        {
            var isbn = new ISBN(9789027439642);
        }
        [TestMethod]
        public void EenISBNMet13eCijferNulEnJuisteControleIsJuist()
        {
            var isbn = new ISBN(9783161484100);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenISBNMet12CijfersIsFout()
        {
            var isbn = new ISBN(978902743964);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenISBNMet14CijfersIsFout()
        {
            var isbn = new ISBN(97890274396420);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenISBNMet0IsFout()
        {
            var isbn = new ISBN(0);
        }
        [TestMethod]
        public void EenISBNStringToeGeeftDeOorsprongkelijkeISBNTerug()
        {
            var nummer = 9789027439642;
            var isbn = new ISBN(nummer);
            Assert.AreEqual(nummer.ToString(), isbn.ToString());
        }
    }
}
