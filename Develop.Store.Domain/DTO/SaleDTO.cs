using Develop.Store.Domain.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Develop.Store.Domain.DTO
{
    public class SaleDTO
    {
        public List<ProductDTO> Products { get; set; }
        public Customer Customer { get; set; }
        public double TotalValue { get; set; }
        public double TotalValueAfterDiscount { get; set; }
    }
}
