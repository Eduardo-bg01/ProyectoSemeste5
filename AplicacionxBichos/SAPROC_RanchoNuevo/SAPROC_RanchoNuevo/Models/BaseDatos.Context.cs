//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAPROC_RanchoNuevo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ranchonuevoEntities2 : DbContext
    {
        public ranchonuevoEntities2()
            : base("name=ranchonuevoEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<actualizacion> actualizacion { get; set; }
        public virtual DbSet<configuracion> configuracion { get; set; }
        public virtual DbSet<fila> fila { get; set; }
        public virtual DbSet<lote> lote { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
    }
}
