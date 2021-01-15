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
    public class ProdutoMapper
    {
        private String cs;

        public ProdutoMapper()
        {
            cs = ConfigurationManager.ConnectionStrings["base dados"].ConnectionString;
            if (cs == null)
            {
                throw new Exception("Connection String must be configured in the config file!");
            }
        }

        public List<Produto> GetProdutos()
        {
            var produs = new List<Produto>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from Produto", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                Produto pp = new Produto()
                                {
                                    sku = sqlDataReader.SafeGet<string>(0),
                                    desc_prod = sqlDataReader.SafeGet<string>(1),
                                    perc_iva = sqlDataReader.SafeGet<int>(2),
                                    preco_unit = sqlDataReader.SafeGet<decimal>(3)
                                };

                                produs.Add(pp);
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
            return produs;
        }
    }
}