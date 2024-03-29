﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP2.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SI2Trab1Entities : DbContext
    {
        public SI2Trab1Entities()
            : base("name=SI2Trab1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Codigo_Fatura> Codigo_Fatura { get; set; }
        public virtual DbSet<Codigo_NotaCred> Codigo_NotaCred { get; set; }
        public virtual DbSet<Contribuinte> Contribuinte { get; set; }
        public virtual DbSet<Estado_FAT> Estado_FAT { get; set; }
        public virtual DbSet<Estado_NC> Estado_NC { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Fatura_Hist> Fatura_Hist { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Item_NC> Item_NC { get; set; }
        public virtual DbSet<Nota_Cred> Nota_Cred { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Item_Hist> Item_Hist { get; set; }
        public virtual DbSet<ResumoFat> ResumoFat { get; set; }
    
        [DbFunction("SI2Trab1Entities", "ListOfNc")]
        public virtual IQueryable<ListOfNc_Result> ListOfNc(Nullable<decimal> ano)
        {
            var anoParameter = ano.HasValue ?
                new ObjectParameter("ano", ano) :
                new ObjectParameter("ano", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ListOfNc_Result>("[SI2Trab1Entities].[ListOfNc](@ano)", anoParameter);
        }
    
        [DbFunction("SI2Trab1Entities", "ListOfNotaCred")]
        public virtual IQueryable<ListOfNotaCred_Result> ListOfNotaCred(Nullable<decimal> ano)
        {
            var anoParameter = ano.HasValue ?
                new ObjectParameter("ano", ano) :
                new ObjectParameter("ano", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ListOfNotaCred_Result>("[SI2Trab1Entities].[ListOfNotaCred](@ano)", anoParameter);
        }
    
        public virtual int AddItemsFat(string desc_item, Nullable<decimal> desconto, Nullable<decimal> num_uni, string codigo_fat, string sku)
        {
            var desc_itemParameter = desc_item != null ?
                new ObjectParameter("desc_item", desc_item) :
                new ObjectParameter("desc_item", typeof(string));
    
            var descontoParameter = desconto.HasValue ?
                new ObjectParameter("desconto", desconto) :
                new ObjectParameter("desconto", typeof(decimal));
    
            var num_uniParameter = num_uni.HasValue ?
                new ObjectParameter("num_uni", num_uni) :
                new ObjectParameter("num_uni", typeof(decimal));
    
            var codigo_fatParameter = codigo_fat != null ?
                new ObjectParameter("codigo_fat", codigo_fat) :
                new ObjectParameter("codigo_fat", typeof(string));
    
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddItemsFat", desc_itemParameter, descontoParameter, num_uniParameter, codigo_fatParameter, skuParameter);
        }
    
        public virtual int AddNewNC(string codigo_fat)
        {
            var codigo_fatParameter = codigo_fat != null ?
                new ObjectParameter("codigo_fat", codigo_fat) :
                new ObjectParameter("codigo_fat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewNC", codigo_fatParameter);
        }
    
        public virtual int AddNewProduct(string sku, string desc_prod, Nullable<int> perc_iva, Nullable<decimal> preco_unit)
        {
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            var desc_prodParameter = desc_prod != null ?
                new ObjectParameter("desc_prod", desc_prod) :
                new ObjectParameter("desc_prod", typeof(string));
    
            var perc_ivaParameter = perc_iva.HasValue ?
                new ObjectParameter("perc_iva", perc_iva) :
                new ObjectParameter("perc_iva", typeof(int));
    
            var preco_unitParameter = preco_unit.HasValue ?
                new ObjectParameter("preco_unit", preco_unit) :
                new ObjectParameter("preco_unit", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewProduct", skuParameter, desc_prodParameter, perc_ivaParameter, preco_unitParameter);
        }
    
        public virtual int AtualizarEstadoFat(string codigo_fat, string novo_estado)
        {
            var codigo_fatParameter = codigo_fat != null ?
                new ObjectParameter("codigo_fat", codigo_fat) :
                new ObjectParameter("codigo_fat", typeof(string));
    
            var novo_estadoParameter = novo_estado != null ?
                new ObjectParameter("novo_estado", novo_estado) :
                new ObjectParameter("novo_estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AtualizarEstadoFat", codigo_fatParameter, novo_estadoParameter);
        }
    
        public virtual int AtualizarValorTotal(string codigo_fat)
        {
            var codigo_fatParameter = codigo_fat != null ?
                new ObjectParameter("codigo_fat", codigo_fat) :
                new ObjectParameter("codigo_fat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AtualizarValorTotal", codigo_fatParameter);
        }
    
        public virtual int CreateTables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTables");
        }
    
        public virtual int drop_tables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("drop_tables");
        }
    
        public virtual int DropTables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DropTables");
        }
    
        public virtual int EditNewProduct(string sku, string desc_prod, Nullable<int> perc_iva, Nullable<decimal> preco_unit)
        {
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            var desc_prodParameter = desc_prod != null ?
                new ObjectParameter("desc_prod", desc_prod) :
                new ObjectParameter("desc_prod", typeof(string));
    
            var perc_ivaParameter = perc_iva.HasValue ?
                new ObjectParameter("perc_iva", perc_iva) :
                new ObjectParameter("perc_iva", typeof(int));
    
            var preco_unitParameter = preco_unit.HasValue ?
                new ObjectParameter("preco_unit", preco_unit) :
                new ObjectParameter("preco_unit", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EditNewProduct", skuParameter, desc_prodParameter, perc_ivaParameter, preco_unitParameter);
        }
    
        public virtual int GetCode(string tipo)
        {
            var tipoParameter = tipo != null ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetCode", tipoParameter);
        }
    
        public virtual int p_criafatura(Nullable<decimal> nif, string nome, string morada)
        {
            var nifParameter = nif.HasValue ?
                new ObjectParameter("nif", nif) :
                new ObjectParameter("nif", typeof(decimal));
    
            var nomeParameter = nome != null ?
                new ObjectParameter("nome", nome) :
                new ObjectParameter("nome", typeof(string));
    
            var moradaParameter = morada != null ?
                new ObjectParameter("morada", morada) :
                new ObjectParameter("morada", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_criafatura", nifParameter, nomeParameter, moradaParameter);
        }
    
        public virtual int PopulateTables()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PopulateTables");
        }
    
        public virtual int RemoveProduct(string sku)
        {
            var skuParameter = sku != null ?
                new ObjectParameter("sku", sku) :
                new ObjectParameter("sku", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RemoveProduct", skuParameter);
        }
    }
}
