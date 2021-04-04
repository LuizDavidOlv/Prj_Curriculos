using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Curriculo> Curriculos { get; set; }
        public DbSet<Formacao> Formacoes { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<ExperienciaEmpresas> ExperienciasEmpresas { get; set; }

        public static DbContextOptions<MeuDbContext> GetInMemoryDbContextOptions(string dbName = "Test_DB")
        {
            var options = new DbContextOptionsBuilder<MeuDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return options;
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    foreach (var property in modelBuilder.Model.GetEntityTypes()
        //        .SelectMany(e => e.GetProperties()
        //            .Where(p => p.ClrType == typeof(string))))
        //        property.SetColumnType("varchar(100)");

        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

        //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
