using System.Collections.Generic;
using PartyInvites.Domain;

namespace PartyInvites.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}