//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnidadPedagogicaSDStaticInfo.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class mensajex
    {
        public int idMensaje { get; set; }
        public string cuerpo { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> idUsuario { get; set; }
    
        public virtual usuariox usuariox { get; set; }
    }
}
