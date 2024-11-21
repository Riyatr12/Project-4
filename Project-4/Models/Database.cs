using Microsoft.Data.SqlClient;
using Project_4.Models;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using Utilities;

namespace Project_4.Models
{
    public class Database
    {
      DBConnect dbConnect = new DBConnect();
        SqlCommand command = new SqlCommand();

        public int ValidateLogin(User user)
        {

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ValidateLogin";

                command.Parameters.AddWithValue("@BrokerUsername", user.UserName);
                command.Parameters.AddWithValue("@BrokerPassword", user.Password);

                DataSet ds = dbConnect.GetDataSetUsingCmdObj(command);


                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int userId = Convert.ToInt32(ds.Tables[0].Rows[0]["BrokerID"]);

                    return userId;
                }
                return 0;
            

        }


    }
}
