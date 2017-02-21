using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day2APIServer.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cereal> Cereals { get; set; }
    }
}