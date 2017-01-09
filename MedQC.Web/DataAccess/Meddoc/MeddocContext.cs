using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MedQC.Web.Models;
using Oracle.ManagedDataAccess.Client;
namespace MedQC.Web.DataAccess.Meddoc
{
    public class MeddocContext : DbContext
    {
        public MeddocContext(string connectionString)
            : base(connectionString) {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MeddocContext>());
        }
        
        public DbSet<Models.Meddoc.TimeRule> TimeRule { get; set; }
        public DbSet<Models.Meddoc.QcArticle> QcArticle { get; set; }
        public DbSet<Models.Meddoc.QcCheckPoint> QcCheckPoint { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MEDDOC");
        }

    }
}