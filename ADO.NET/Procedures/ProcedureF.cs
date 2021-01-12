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
    public class ProcedureF
    {
        private readonly string cs;

        public ProcedureF()
        {
            cs = Session.GetConnectionString();
        }
        public void p_criafatura(decimal nif, string nome, string morada)
        {
            try
            {
                using (TransactionScope ts = Transaction.Ts.GetTsReadCommitted())
                {
                    using (SqlConnection sqlConnection = new SqlConnection(cs))
                    {
                        sqlConnection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("p_criafatura", sqlConnection))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            SqlParameter p1 = new SqlParameter("@nif", nif);
                            SqlParameter p2 = new SqlParameter("@nome", nome);
                            SqlParameter p3 = new SqlParameter("@morada", morada);

                            sqlCommand.Parameters.Add(p1);
                            sqlCommand.Parameters.Add(p2);
                            sqlCommand.Parameters.Add(p3);

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

