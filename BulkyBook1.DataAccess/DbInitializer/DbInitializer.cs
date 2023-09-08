using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook1.DataAccess.DbInitializer
{
    public class DbInitializer : IDInitializer
    {
        public void Initialize()
        {
            //migrations if they are not aplied

            //Created roles if they are not created

            //if roles are not created, then we will create a admin user as well
        }
    }
}
