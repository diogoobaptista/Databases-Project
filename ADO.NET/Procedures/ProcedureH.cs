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
    public class ProcedureH
    {
        private readonly string cs;

        public ProcedureH()
        {
            cs = Session.GetConnectionString();
        }
        public void AddItemsFat(Item it)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("AddItemsFat", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SqlParameter p1 = new SqlParameter("@desc_item", it.desc_item);
                        SqlParameter p2 = new SqlParameter("@desconto", it.desconto);
                        SqlParameter p3 = new SqlParameter("@num_uni", it.num_uni);
                        SqlParameter p4 = new SqlParameter("@codigo_fat", it.codigo_fat);
                        SqlParameter p5 = new SqlParameter("@sku", it.sku);
                        sqlCommand.Parameters.Add(p1);
                        sqlCommand.Parameters.Add(p2);
                        sqlCommand.Parameters.Add(p3);
                        sqlCommand.Parameters.Add(p4);
                        sqlCommand.Parameters.Add(p5);

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
