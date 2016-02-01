using System.Collections.Generic;
using System.Linq;
using PartyInvites.Domain;

namespace PartyInvites.Services
{
    public class ProductDiscountCalculator : ICalculator
    {
        public decimal Discount { get; set; }
        public decimal TotalPrice(IEnumerable<Product> products)
        {
            var sum = products.Sum(x => x.Price);
            if (Discount > 0 && Discount < sum/2)
            {
                return sum - Discount;
            }

            return sum;
        }
    }
}