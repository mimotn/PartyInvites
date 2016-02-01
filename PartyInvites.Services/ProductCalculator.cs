using System.Collections.Generic;
using System.Linq;
using PartyInvites.Domain;

namespace PartyInvites.Services
{
    public class ProductCalculator : ICalculator
    {
        public decimal TotalPrice(IEnumerable<Product> products)
        {
            return products.Sum(x => x.Price);
        }
    }
}