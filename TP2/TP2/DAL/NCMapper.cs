using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class NCMapper
    {
        private String cs;

        public NCMapper()
        {
            cs = ConfigurationManager.ConnectionStrings["base dados"].ConnectionString;
            if (cs == null)
            {
                throw new Exception("Connection String must be configured in the config file!");
            }
        }

        public List<Nota_Cred> GetNotasCred()
        {
            var notasc = new List<Nota_Cred>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from Nota_Cred", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                Nota_Cred nc = new Nota_Cred
                                {
                                    codigo_nc = sqlDataReader.SafeGet<string>(0),
                                    ano = sqlDataReader.SafeGet<decimal>(1),
                                    nr_nc = sqlDataReader.SafeGet<decimal>(2),
                                    dt_emissao = sqlDataReader.SafeGet<string>(3),
                                    dt_criacao = sqlDataReader.SafeGet<string>(4),
                                    val_nc = sqlDataReader.SafeGet<decimal>(5),
                                    estado = sqlDataReader.SafeGet<string>(6),
                                    codigo_fat = sqlDataReader.SafeGet<string>(7)

                                };

                                notasc.Add(nc);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw exception;
            }
            return notasc;
        }
    }
}
