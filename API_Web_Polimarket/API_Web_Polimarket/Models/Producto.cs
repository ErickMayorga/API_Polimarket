//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_Web_Polimarket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public double precio { get; set; }
        public int idCategoria { get; set; }
    }
}