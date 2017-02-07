using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    public class LandService
    {
        private readonly ILandDAO landDAO;
        public decimal VerhoudingOppervlakteLandtoOppervlakteAlleLanden(string landcode)
        {
            var land = landDAO.Read(landcode);
            var opperVlakteAlleLanden = landDAO.OppervlakteAlleLanden();
            return (decimal)land.Oppervlakte / opperVlakteAlleLanden;
        }
        public LandService(ILandDAO landDAO)
        {
            this.landDAO = landDAO;
        }
    }
}
