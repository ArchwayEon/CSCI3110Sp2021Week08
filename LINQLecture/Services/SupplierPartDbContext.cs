using LINQLecture.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Services
{
   public class SupplierPartDbContext : DbContext
   {
      public SupplierPartDbContext(DbContextOptions options) : base(options)
      {
      }

      public DbSet<Supplier> Suppliers { get; set; }
      public DbSet<Part> Parts { get; set; }
      public DbSet<SupplierPart> SupplierParts { get; set; }
   }
}
