using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTDD;
using System.Collections.Generic;

namespace TestTDDTest
{
    [TestClass]
    public class PersoonTest
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void DeLijstVoornamenMagNietLeegZijn()
        {
            new Persoon(new List<string> { });
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void DeLijstVoornamenMagNietNullZijn()
        {
            new Persoon(null);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenElementVanDeLijstVoornamenMagNietLeegZijn()
        {
            new Persoon(new List<string> { "Tim", "", "Jan" });
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void EenElementVanDeLijstVoornamenMagNietNullZijn()
        {
            new Persoon(new List<string> { "Tim", null, "Jan" });
        }
        [TestMethod]
        public void EenPersoonMetEenVoornaamInDeLijstIsJuist()
        {
            new Persoon(new List<string> { "Tim" });
        }
        [TestMethod]
        public void EenPersoonMetMeerdereVoornamenInDeLijstIsJuist()
        {
            new Persoon(new List<string> { "Tim", "Piet", "Jan" });
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenPersoonMetEenNaamUitCijfersIsFout()
        {
            new Persoon(new List<string> { "T1m" });
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenPersoonMetMeerdereNamenWaarvanEenUitCijfersIsFout()
        {
            new Persoon(new List<string> { "Tim", "J*n", "Pi4t" });
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void EenPersoonMet2DezelfdeNamenHoofdletterGevoeligIsFout()
        {
            new Persoon(new List<string> { "Tim", "johan", "tim" });
        }
        [TestMethod]
        public void EenToStringDieAlleNamenTerugGeeftDoorSpatiesGescheidenIsJuist()
        {
            var persoon = new Persoon(new List<string> { "Tim", "Jan", "Johan" });
            string resultaat = "Tim Jan Johan";
            Assert.AreEqual(resultaat, persoon.ToString());
        }
        [TestMethod]
        public void EenToStringMetEenNaamGeeftDieNaamTerug()
        {
            var persoon = new Persoon(new List<string> { "Tim" });
            Assert.AreEqual("Tim", persoon.ToString());
        }
        [TestMethod]
        public void EenToStringDieNamenAanElkaarPlaktIsFout()
        {
            var persoon = new Persoon(new List<string> { "Tim", "Jan", "Johan" });
            string resultaat = "TimJanJohan";
            Assert.AreNotEqual(resultaat, persoon.ToString());
        }
    }
}
