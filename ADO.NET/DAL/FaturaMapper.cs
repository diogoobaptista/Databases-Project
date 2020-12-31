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
    public class FaturaMapper
    {
        private String cs;
        public FaturaMapper()
        {
            cs = ConfigurationManager.ConnectionStrings["base dados"].ConnectionString;
            if (cs == null)
            {
                throw new Exception("Connection String must be configured in the config file!");
            }
        }

        public List<Fatura> GetFaturas()
        {
            var faturas = new List<Fatura>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from Fatura", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                Fatura ft = new Fatura
                                {
                                    codigo_fat = sqlDataReader.SafeGet<string>(0),
                                    ano = sqlDataReader.SafeGet<decimal>(1),
                                    nr_fat = sqlDataReader.SafeGet<decimal>(2),
                                    //dt_emissao = sqlDataReader.SafeGet<string>(3),
                                    dt_criacao = sqlDataReader.SafeGet<string>(4),
                                    //val_total = sqlDataReader.SafeGet<decimal>(5),
                                    //val_iva = sqlDataReader.SafeGet<int>(6),
                                    estado = sqlDataReader.SafeGet<string>(7),
                                    nif = sqlDataReader.SafeGet<decimal>(8)
                                   
                                };

                                faturas.Add(ft);
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
            return faturas;
        }
    }
}
