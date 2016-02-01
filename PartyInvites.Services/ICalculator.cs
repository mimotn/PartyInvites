using System.Collections.Generic;
using PartyInvites.Domain;

namespace PartyInvites.Services
{
    public interface ICalculator
    {
        decimal TotalPrice(IEnumerable<Product> products);
    }
}