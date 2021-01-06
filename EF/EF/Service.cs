using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Service
    {
        internal SI2Trab1Entities context;

        public Service(SI2Trab1Entities context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while saving context changes to database:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }
        }


        public void Fatura()
        {
            ConsoleTable table = new ConsoleTable("Cod Fat", "Ano", "Nº Fat", "Dt Emissao", "Dt Criacao", "Valor Total", "Valor Iva", "Estado", "nif");

            foreach (Fatura ft in context.Fatura)
            {
                table.AddRow(ft.codigo_fat, ft.ano, ft.nr_fat, ft.dt_emissao, ft.dt_criacao, ft.val_total, ft.val_iva, ft.estado, ft.nif);
            }
            table.Write();
            Console.WriteLine();
        }

        public void p_criafatura(decimal nif, string nome, string morada)
        {
            try
            {
                //Contribuinte ct = new Contribuinte() { nif = nif, nome = nome, morada = morada };
                context.p_criafatura(nif, nome, morada);
                
            } catch (Exception e) {
                Console.WriteLine("Error while creating new franchisee:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }
        }


    }
}
