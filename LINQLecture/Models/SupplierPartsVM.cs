using LINQLecture.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Models
{
   public class SupplierPartsVM
   {
      public string SupplierName { get; set; }
      public IEnumerable<SupplierPart> SupplierParts { get; set; }
   }

}
