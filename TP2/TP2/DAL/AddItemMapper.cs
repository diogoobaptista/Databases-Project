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
    public class AddItemMapper
    {
        private String cs;

        public AddItemMapper()
        {
            cs = ConfigurationManager.ConnectionStrings["base dados"].ConnectionString;
            if (cs == null)
            {
                throw new Exception("Connection String must be configured in the config file!");
            }
        }

        public List<Item> GetItemsFat()
        {
            var items = new List<Item>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from Item", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                Item itt = new Item()
                                {
                                    num_item = sqlDataReader.SafeGet<int>(0),
                                    desc_item = sqlDataReader.SafeGet<string>(1),
                                    desconto = sqlDataReader.SafeGet<decimal>(2),
                                    num_uni = sqlDataReader.SafeGet<decimal>(3),
                                    codigo_fat = sqlDataReader.SafeGet<string>(4),
                                    sku = sqlDataReader.SafeGet<string>(5)
                                };

                                items.Add(itt);
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
            return items;
        }
    }
}
