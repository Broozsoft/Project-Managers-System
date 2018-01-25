using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pmboard.Models
{
    public partial class DbEntities : DbContext
    {
    
        public DbSet<Projects> Projects { get; set; }
        public DbSet<GateKeepers> GateKeepers { get; set; }
        public DbSet<Projectmanagers> Projectmanagers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<GoldStar> GoldStar { get; set; }
        public DbEntities() : base("name=DbEntities")
        { }
//        public DbEntities(string connectionString) : base(connectionString)
//{
//        }
    }
}