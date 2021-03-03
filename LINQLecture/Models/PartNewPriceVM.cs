using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.Models
{
   public class PartNewPriceVM
   {
      public string Name { get; set; }
      public decimal OldPrice { get; set; }
      public decimal NewPrice { get; set; }
   }

}
