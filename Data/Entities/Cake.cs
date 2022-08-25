using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet6WebAPICrud.Data.Entities
{
    public class Cake
    {
        public int Id {get; set; }
        public string Name{get; set; }
        public decimal Price {get; set; }
        public string Description {get; set; }
    }
}