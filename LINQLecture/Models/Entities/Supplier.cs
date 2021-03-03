using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Models.Entities
{
   public class Supplier
   {
      public int Id { get; set; }
      [Required, StringLength(50)]
      public string Name { get; set; }

      public ICollection<SupplierPart> PartsSupplied { get; set; }
         = new List<SupplierPart>();
   }
}
