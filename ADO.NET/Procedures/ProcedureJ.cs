using DAL;
using Entidades;
using Microsoft.SqlServer.Server;
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
    public class ProcedureJ
    {
        private readonly string cs;

        public ProcedureJ()
        {
            cs = Session.GetConnectionString();
        }

        public List<Nota_Cred> ListOfNotaCred(Nota_Cred notinhas)
        {
            var notasc = new List<Nota_Cred>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand("select * from ListOfNotaCred(" + notinhas.ano + ")", sqlConnection))
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

        /*
        public void ListOfNotaCred(bool useDataTable,IEnumerable<decimal> ids)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.ListOfNotaCred";
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter;
                    if (useDataTable)
                    {
                        parameter = command.Parameters
                                      .AddWithValue("@Display", CreateDataTable(ids));
                    }
                    else
                    {
                        parameter = command.Parameters
                                      .AddWithValue("@Display", CreateSqlDataRecords(ids));
                    }
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.ListOfNotaCred";

                    command.ExecuteNonQuery();
                }
            }
        }

        private static DataTable CreateDataTable(IEnumerable<decimal> ids)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(long));
            foreach (long id in ids)
            {
                table.Rows.Add(id);
            }
            return table;
        }

        private static IEnumerable<SqlDataRecord> CreateSqlDataRecords(IEnumerable<decimal> ids)
        {
            SqlMetaData[] metaData = new SqlMetaData[1];
            metaData[0] = new SqlMetaData("ID", SqlDbType.BigInt);
            SqlDataRecord record = new SqlDataRecord(metaData);
            foreach (long id in ids)
            {
                record.SetInt64(0, id);
                yield return record;
            }
        }
    }
    */
