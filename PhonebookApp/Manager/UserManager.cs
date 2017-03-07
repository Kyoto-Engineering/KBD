using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhonebookApp.DAL;
using PhonebookApp.Gateway;

namespace PhonebookApp.Manager
{
   public  class UserManager
    {

        public UserGateway aGateway;

        public int SaveUser(User aUser)
        {
            aGateway = new UserGateway();
            return aGateway.SaveUser(aUser);
        }
    }
}
