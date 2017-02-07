using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class StatistiekTest
    {
        [TestMethod]
        public void HetGemiddeldeVan10En15is12Komma5()
        {
            Assert.AreEqual(12.5m, Statistiek.Gemiddelde(new decimal [] { 10m,15m }));
        }
        [TestMethod]
        public void HetGemiddeldeVanEenGetalIsDatGetal()
        {
            Assert.AreEqual(12m, Statistiek.Gemiddelde(new decimal[] { 12m }));
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void HetGemiddeldeVanNietsKanJeNietBepalen()
        {
            Statistiek.Gemiddelde(new decimal[] { });
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void HetGemiddeldeVanNullKanJeNietBepalen()
        {
            Statistiek.Gemiddelde(null); 
        }
    }
}
