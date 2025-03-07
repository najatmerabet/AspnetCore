using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
         public string  Symbol { get; set; }=string.Empty;
        public string Company { get; set; }=string.Empty;
       
       public decimal LastDiv { get; set; }

       public string Industry { get; set; }= string.Empty;

       public long MarketCap { get; set; }
    }
}