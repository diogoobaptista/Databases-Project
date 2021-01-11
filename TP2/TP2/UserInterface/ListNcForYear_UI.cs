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
    public class ListNcForYear_UI
    {
        public static int ListNcForYear()
        {
            try
            {
                Console.Write("Ano das Notas de Credito que Pretende listar?:");
                decimal ano = Decimal.Parse(Console.ReadLine());
                Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
                string option = Console.ReadLine();
                if (option == "A")
                {
                    ProcedureJ storedProcedure = new ProcedureJ();
                    NCService nc = new NCService();
                    Print.Nota_Cred((storedProcedure.ListOfNotaCred(ano)));
                    return 0;
                }
                else if (option == "E")
                {
                    using (TransactionScope ts = TP2.Transaction.GetTsReadUnCommitted())
                    {
                        using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                        {
                            Service service = new Service(context);
                            EF.Print.Print_List_Of_Nc(service.ListOfNotaCred(ano));
                        }
                        ts.Complete();
                        return 0;
                    }
                }
                else { Console.WriteLine("Invalid Option"); return -1; }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Valores Inseridos não são validos");
                return -1;
            }
        }
    }
}