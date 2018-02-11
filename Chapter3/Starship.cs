using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTheFinalFrontier
{
    public class Starship
    {
        public void SetMaximumTroopCapacity(int capacity)
        {
            try
            {

            }
            catch (Exception exception)
            {
                string connectionString = "connectionstring goes here";
                string sql = $"INSERT INTO tblLog (error, date) VALUES ({exception.Message}, GetDate())";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(sql)
                    {
                        CommandType = CommandType.Text,
                        Connection = connection
                    };
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                throw exception;
            }
        }
    }
}
