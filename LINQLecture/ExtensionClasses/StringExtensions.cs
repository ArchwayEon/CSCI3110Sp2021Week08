using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.ExtensionClasses
{
   public static class StringExtensions
   {
      public static char MiddleChar(this string myString)
      {
         return myString[myString.Length / 2];
      }
   }

}
