//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SERVIS_WEB_PROYECTO.ModeloDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLEBOLETA
    {
        public int NUM_BOL { get; set; }
        public int IDE_Lib { get; set; }
        public int CAN_ART { get; set; }
    
        public virtual BOLETA BOLETA { get; set; }
        public virtual TBLibro TBLibro { get; set; }
    }
}
