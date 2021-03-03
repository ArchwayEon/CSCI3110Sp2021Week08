using LINQLecture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Services
{
   public interface ISupplierPartsRepository
   {
      IQueryable<SupplierPart> ReadAllSupplierParts();
      IQueryable<Supplier> ReadAllSuppliers();
   }
}
