using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class RekeningTest
    {
        private Rekening rekening;
        [TestInitialize]
        public void Initialize()
        {
            rekening = new Rekening();
        }
        [TestMethod]
        public void EenLegeRekeningHeeftSaldoNul()
        {
            Assert.AreEqual(0, new Rekening().Saldo);
        }
        [TestMethod]
        public void StortingNaEenBedragGeeftBedrag()
        {
            var bedrag = 20m;
            rekening.Storten(bedrag);
            Assert.AreEqual(bedrag, rekening.Saldo);
        }
        [TestMethod]
        public void TweeBedragenStortenGeeftDeSomAlsSaldo()
        {
            var bedrag1 = 20m;
            var bedrag2 = 30m;
            rekening.Storten(bedrag1);
            rekening.Storten(bedrag2);
            Assert.AreEqual(bedrag1 + bedrag2, rekening.Saldo);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void HetBedragVanEenStortingMagNietNulZijn()
        {
            rekening.Storten(decimal.Zero);
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void HetBedragVanEenStortingMagNietNegatiefZijn()
        {
            rekening.Storten(-30m);
        }
        
    }
}
