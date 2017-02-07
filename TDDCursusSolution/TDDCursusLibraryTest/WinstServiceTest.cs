using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDCursusLibrary;
using Moq;

namespace TDDCursusLibraryTest
{
    [TestClass]
    public class WinstServiceTest
    {
        private Mock<IOpbrengstDAO> mockFactoryO;
        private Mock<IKostDAO> mockFactoryK;
        private IOpbrengstDAO opbrengstDAO;
        private IKostDAO kostDAO;
        private WinstService winstService;
        [TestInitialize]
        public void Initialize()
        {
            mockFactoryK = new Mock<IKostDAO>();
            mockFactoryO = new Mock<IOpbrengstDAO>();
            opbrengstDAO = mockFactoryO.Object;
            mockFactoryO.Setup(EenOpbrengstDAO => EenOpbrengstDAO.TotaleOpbrengst()).Returns(1600);
            kostDAO = mockFactoryK.Object;
            mockFactoryK.Setup(EenKostDAO => EenKostDAO.TotaleKost()).Returns(600);
            winstService = new WinstService(opbrengstDAO, kostDAO);
        }
        [TestMethod]
        public void HetVerschilTussenDeOpbrengstEnDeKostenIsDeWinst()
        {
            Assert.AreEqual(1000m, winstService.Winst);
            mockFactoryO.Verify(EenOpbrenst => EenOpbrenst.TotaleOpbrengst());
            mockFactoryK.Verify(EenKost => EenKost.TotaleKost());
        }
    }
}
