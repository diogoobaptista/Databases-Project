using Entidades;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Procedures
{
    public class ProcedureH
    {
        private readonly string cs;

        public ProcedureH()
        {
            cs = Session.GetConnectionString();
        }
        public void AddItemsFat(string codigo_fat, string desc_item, string sku, decimal num_uni, decimal desconto)
        {
            try
            {
                using (TransactionScope ts = Transaction.Ts.GetTsReadCommitted())
                {
                    using (SqlConnection sqlConnection = new SqlConnection(cs))
                    {
                        sqlConnection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("AddItemsFat", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            SqlParameter p1 = new SqlParameter("@desc_item", desc_item);
                            SqlParameter p2 = new SqlParameter("@desconto", desconto);
                            SqlParameter p3 = new SqlParameter("@num_uni", num_uni);
                            SqlParameter p4 = new SqlParameter("@codigo_fat", codigo_fat);
                            SqlParameter p5 = new SqlParameter("@sku", sku);
                            sqlCommand.Parameters.Add(p1);
                            sqlCommand.Parameters.Add(p2);
                            sqlCommand.Parameters.Add(p3);
                            sqlCommand.Parameters.Add(p4);
                            sqlCommand.Parameters.Add(p5);

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    ts.Complete();
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
