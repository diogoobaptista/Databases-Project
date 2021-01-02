using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class FunctionE
    {
        private readonly string cs;

        public FunctionE()
        {
            cs = Session.GetConnectionString();
        }

        public string getNextFatCod(string tipo_cod)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("getNextFatCod", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter p1 = new SqlParameter("@tipo_codigo", tipo_cod);
                        sqlCommand.Parameters.Add(p1);

                        SqlParameter returnValue = sqlCommand.Parameters.Add("@RETURN_VALUE", SqlDbType.NVarChar);
                        returnValue.Direction = ParameterDirection.ReturnValue;

                        sqlCommand.ExecuteNonQuery();
                        return (string)returnValue.Value;
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                throw exception;
            }
        }
    }
}
