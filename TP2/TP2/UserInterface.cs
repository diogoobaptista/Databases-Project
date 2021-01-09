using Entidades;
using Procedures;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class UserInterface
    {
        //Criar Fatura
        public static int CF()
        {
            Console.WriteLine("Criar Fatura");
            Console.Write("Insira o seu nif: ");
            decimal nif = Decimal.Parse(Console.ReadLine());
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
                Contribuinte ctTest = new Contribuinte();
                storedProcedure.p_criafatura(ctTest.nif=nif, ctTest.nome=nome, ctTest.morada=morada);
                Print.Fatura(ft.GetFatura());
                return 0;
            }
            else if (option == "E")
            {
                return 0;
            }
            else { Console.WriteLine("Invalid Option"); return -1; }

          
        }
    }
}
