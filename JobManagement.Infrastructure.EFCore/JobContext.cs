using JobManagement.Domain.PersonAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobManagement.Domain.PersonEshtegVazAgg;
using JobManagement.Domain.PersonOzvNoaAgg;
using JobManagement.Domain.QorbAgg;
using JobManagement.Domain.QorbMoasAgg;
using JobManagement.Domain.QorbMoasPorAgg;
using JobManagement.Domain.QorbMoasPorKarAgg;
using JobManagement.Infrastructure.EFCore.Mapping;

namespace JobManagement.Infrastructure.EFCore
{
    public class JobContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonEshtegVaz> PersonEshtegVazs { get; set; }
        public DbSet<PersonOzvNoa> PersonOzvNoas { get; set; }
        public DbSet<Qorb> Qorbs { get; set; }
        public DbSet<QorbMoas> QorbMoass { get; set; }
        public DbSet<QorbMoasPor> QorbMoasPors { get; set; }
        public DbSet<QorbMoasPorKar> QorbMoasPorKars { get; set; }
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(PersonMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
