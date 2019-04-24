using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace our_project.Models
{
    public class UnemploymentContext : DbContext
    {
        public UnemploymentContext(DbContextOptions options) : base(options) { }
        public DbSet<UnemploymentStat> UnemploymentStats { get; set; }
    }
}