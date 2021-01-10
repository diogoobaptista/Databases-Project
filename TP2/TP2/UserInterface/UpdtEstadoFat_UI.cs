﻿using EF;
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
    public class UpdtEstadoFat_UI
    {
        public static int UpdtEstadoFat()
        {
            Console.Write("Altrar o estado ");
            Console.Write("Qual o codigo da fatura que quer mudar o estado?: ");
            string codigo = Console.ReadLine();
            Console.Write("Novo estado?: ");
            string novoestado = Console.ReadLine();
            Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
            string option = Console.ReadLine();
            if (option == "A")
            {
                ProcedureK storedProcedure = new ProcedureK();
                FaturaService ft = new FaturaService();
                storedProcedure.AtualizarEstadoFat(codigo,novoestado);
                Print.Fatura(ft.GetFatura());
                return 0;
            }
            else if (option == "E")
            {
                // using (TransactionScope ts = GetTs())
                //{
                using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                {
                    Service service = new Service(context);
                    service.AtualizarEstadoFat(codigo, novoestado);
                    service.RefreshAll();
                    service.SaveChanges();
                    service.Print_Fatura();

                }
                //ts.Complete();
                return 0;
                //}
            }
            else { Console.WriteLine("Invalid Option"); return -1; }
        }
    }
}
