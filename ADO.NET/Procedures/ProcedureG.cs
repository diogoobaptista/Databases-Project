using Entidades;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procedures
{
    public class ProcedureG
    {
        private readonly string cs;

        public ProcedureG()
        {
            cs = Session.GetConnectionString();
        }
        public void AddNewNC(Nota_Cred nc)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("AddNewNC", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SqlParameter p1 = new SqlParameter("@codigo_fat", nc.codigo_fat);
                        sqlCommand.Parameters.Add(p1);

                        sqlCommand.ExecuteNonQuery();
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
