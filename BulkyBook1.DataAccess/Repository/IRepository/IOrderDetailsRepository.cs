using BulkyBook1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook1.DataAccess.IRepository
{
    public interface IOrderDetailsRepository :IRepository<OrderDetails>
    {
        void Update(OrderDetails obj);
    }
}
