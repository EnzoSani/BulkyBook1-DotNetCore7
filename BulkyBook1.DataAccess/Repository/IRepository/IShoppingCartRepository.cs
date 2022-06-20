using BulkyBook1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook1.DataAccess.IRepository
{
    public interface IShoppingCartRepository :IRepository<ShoppingCart>
    {
        int DecrementCount(ShoppingCart shoppingCart, int count);

        int IncrementCount(ShoppingCart shoppingCart, int count);
    }
}
