﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLecture.ExtensionClasses
{
   public static class StringExtensionsNotQuite
   {
      public static char MiddleChar(string myString)
      {
         return myString[myString.Length / 2];
      }
   }
}
