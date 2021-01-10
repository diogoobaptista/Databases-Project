using EF;
using Entidades;
using Procedures;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2.UserInterface
{
    class CreateNc_UI
    {
        public static int CreateNotaCredito()
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
                // using (TransactionScope ts = GetTs())
                //{
                using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                {
                    Service service = new Service(context);
                    service.AddNewNC(codigo);
                    service.Print_Nota_Cred();

                }
                //ts.Complete();
                return 0;
                //}
            }
            else { Console.WriteLine("Invalid Option"); return -1; }
        }
    }
}
