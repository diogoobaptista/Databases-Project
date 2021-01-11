using EF;
using Entidades;
using Procedures;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TP2.UserInterface
{
    class CreateNc_UI
    {
        public static int CreateNotaCredito()
        {
            try
            {
                Console.WriteLine("Insira o Codigo da Fatura para o qual pretende a nota de credito:");
                string codigo = Console.ReadLine();
                Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
                string option = Console.ReadLine();
                if (option == "A")
                {
                    ProcedureG storedProcedure = new ProcedureG();
                    NCService nc = new NCService();
                    storedProcedure.AddNewNC(codigo);
                    Print.Nota_Cred(nc.GetNotasCred());

                    return 0;
                }
                else if (option == "E")
                {
                    using (TransactionScope ts = Transaction.GetTsReadCommitted())
                    {
                        using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                        {
                            Service service = new Service(context);
                            service.AddNewNC(codigo);
                            EF.Print.Print_Nota_Cred(context);

                        }
                        ts.Complete();
                        return 0;
                    }
                }
                else { Console.WriteLine("Invalid Option"); return -1; }
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Valores Inseridos não são validos "+ e.Message);
                return -1;
            }
        }
    }
}
