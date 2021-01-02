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
    public class ProcedureK
    {
        private readonly string cs;

        public ProcedureK()
        {
            cs = Session.GetConnectionString();
        }
        public void AtualizarEstadoFat(Fatura ft)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("AtualizarEstadoFat", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        SqlParameter p1 = new SqlParameter("@codigo_fat", ft.codigo_fat);
                        SqlParameter p2 = new SqlParameter("@novo_estado", ft.estado);

                        sqlCommand.Parameters.Add(p1);
                        sqlCommand.Parameters.Add(p2);

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