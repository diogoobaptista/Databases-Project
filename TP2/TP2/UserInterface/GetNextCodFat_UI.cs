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

namespace TP2.UserInterface
{
    public class GetNextCodFat_UI
    {
        public static int GetNextCodFat()
        {
            Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
            string option = Console.ReadLine();
            if (option == "A")
            {
                FaturaService ft = new FaturaService();
                decimal anos = DateTime.Now.Year;
                List<Fatura> num = ft.GetFatura().Where(fatura => fatura.ano == anos).ToList();

                decimal nr_fat = 11111;
                if (num.Any())
                {
                    nr_fat = num.LastOrDefault().nr_fat + 1;
                }
                Console.WriteLine("Próximo cod da fatura: " + "FT" + anos + "-" + nr_fat);
                return 0;
            }
            else if (option == "E")
            {
                // using (TransactionScope ts = GetTs())
                //{
                using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                {
                    Service service = new Service(context);
                    Console.WriteLine("Próximo cod da fatura: " + service.GetNextFatCod("FT"));
                }
                //ts.Complete();
                return 0;
                //}
            }
            else { Console.WriteLine("Invalid Option"); return -1; }
        }
    }
}