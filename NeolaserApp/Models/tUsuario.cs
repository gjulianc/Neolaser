//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NeolaserApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string user { get; set; }
        public string Password { get; set; }
        public string Foto { get; set; }
        public int FkRol { get; set; }
        public Nullable<int> FkCliente { get; set; }
    
        public virtual tCliente tCliente { get; set; }
        public virtual tRole tRole { get; set; }
    }
}