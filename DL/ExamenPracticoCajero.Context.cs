﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ExamenPracticoCajeroEntities : DbContext
    {
        public ExamenPracticoCajeroEntities()
            : base("name=ExamenPracticoCajeroEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cajero> Cajeroes { get; set; }
        public virtual DbSet<Tipo> Tipoes { get; set; }
    
        public virtual int RetirarEfectivo(Nullable<decimal> retiro)
        {
            var retiroParameter = retiro.HasValue ?
                new ObjectParameter("Retiro", retiro) :
                new ObjectParameter("Retiro", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RetirarEfectivo", retiroParameter);
        }
    
        public virtual ObjectResult<CajeroGetAll_Result> CajeroGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CajeroGetAll_Result>("CajeroGetAll");
        }
    }
}
