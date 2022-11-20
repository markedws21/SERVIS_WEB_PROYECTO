using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVIS_WEB_PROYECTO.Entity
{
    public class Boleta
    {
        public int NUM_BOL { get; set; }
        public DateTime FEC_BOL { get; set; }
        public int idAsignatura { get; set; }
        public int codAlu { get; set; }
    }
}