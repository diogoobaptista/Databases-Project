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
    public class ProcedureJ
    {
        private readonly string cs;

        public ProcedureJ()
        {
            cs = Session.GetConnectionString();
        }
        public DataSet ListOfNotaCred(Nota_Cred nc)
        {
            try
            {

                DataSet ds = new DataSet();
                using (SqlConnection sqlConnection = new SqlConnection(cs))
                {
                    sqlConnection.Open();
                    
                    using (SqlCommand sqlCommand = new SqlCommand("ListOfNotaCred", sqlConnection))
                    {
                        
                        using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                        {

                          
                            
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@ano", nc.ano); 
                            
                            da.Fill(ds);
                           

                            //SqlParameter p1 = new SqlParameter("@ano", nc.ano);
                          
                           
                            //sqlCommand.ExecuteNonQuery();
                            Console.WriteLine("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF");
                        }
                    }
                    return ds ;
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
