using EF;
using Entidades;
using Functions;
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
    public class GetNextCodNc_UI
    {
        public static int GetNextCodNC()
        {
            Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
            string option = Console.ReadLine();
            if (option == "A")
            {
                NCService nc = new NCService();
                decimal anos = DateTime.Now.Year;
                List<Nota_Cred> ncs = nc.GetNotasCred().Where(nota_cred => nota_cred.ano == anos).ToList();

                decimal nc_nr = 11111;
                if (ncs.Any())
                {
                    nc_nr = ncs.LastOrDefault().nr_nc + 1;
                }
                Console.WriteLine("Próximo cod da nota de credito: " + "NC" + anos + "-" + nc_nr);
                return 0;
            }
            else if (option == "E")
            {
                using (TransactionScope ts = Transaction.Ts.GetTsReadUnCommitted())
                {
                using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                {
                    Service service = new Service(context);
                    Console.WriteLine("Próximo cod da fatura: " + service.GetNextFatCod("NC"));
                }
                ts.Complete();
                return 0;
                }
            }
            else { Console.WriteLine("Invalid Option"); return -1; }
        }
    }
}