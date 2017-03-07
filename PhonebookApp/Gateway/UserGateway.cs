using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhonebookApp.DAL;
using PhonebookApp.DbGateway;

namespace PhonebookApp.Gateway
{
    public class UserGateway : ConnectionGateway
    {
      public int SaveUser(User aUser)
      {
          connection.Open();
          string insertquery = " insert into Registration(Username,Usertype,Password,Name,Email,Designation,Department,ContactNo) Values('" + aUser.UserName + "','" + aUser.UserType + "','" + aUser.Password + "','" + aUser.Name + "','" + aUser.Email + "','" + aUser.Designation + "','" + aUser.Department + "','" + aUser.ContactNo + "')";
          SqlCommand cmd = new SqlCommand(insertquery, connection);
          int affectedrows = cmd.ExecuteNonQuery();
          connection.Close();
          return affectedrows;
      }
    }
}
