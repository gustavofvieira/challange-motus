using Develop.Store.Domain.Models;
using System;

namespace Develop.Store.Domain.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public int Quantities { get; set; }
        public double TotalValue { get; set; }
        public double TotalValueAfterDiscount { get; set; }
    }
}
