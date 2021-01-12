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
    class CreateFat_UI
    {
        //Criar Fatura
        public static int CreateFatura()
        {
            try
            {
                Console.WriteLine("Criar Fatura");
                Console.Write("Insira o seu nif: ");
                decimal nif = Decimal.Parse(Console.ReadLine());
                if (nif.ToString().Length != 9) throw new FormatException();
                Console.Write("Hey cara, qual o seu nome aí ? ");
                var nome = Console.ReadLine();
                Console.Write("Insira a sua morada: ");
                var morada = Console.ReadLine();
                Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
                string option = Console.ReadLine();
                if (option == "A")
                {
                    FaturaService ft = new FaturaService();
                    ProcedureF storedProcedure = new ProcedureF();
                    storedProcedure.p_criafatura(nif, nome, morada);
                    Print.Fatura(ft.GetFatura());
                    return 0;
                }
                else if (option == "E")
                {
                    using (TransactionScope ts = Transaction.Ts.GetTsReadCommitted())
                    {
                        using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                        {
                            Service service = new Service(context);
                            service.p_criafatura(nif, nome, morada);
                            EF.Print.Print_Fatura(context);

                        }
                        ts.Complete();
                        return 0;
                    }
                }
                else { Console.WriteLine("Invalid Option"); return -1; }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Valores Inseridos não são validos " + e.Message);

                return -1;
            }
            
        }
    }
}
