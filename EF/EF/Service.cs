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

        public void ResetDatabase()
        {
            try
            {
                context.drop_tables();
                context.CreateTables();
                context.PopulateTables();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while reseting database:");
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
                Console.WriteLine("Error while creating new fatura:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }
        }

        public void Nota_Cred()
        {
            ConsoleTable table = new ConsoleTable("Cod Nc", "Ano", "Nº NC", "Dt Emissao", "Dt Criacao", "Valor NC", "Estado", "Codigo Fat");

            foreach (Nota_Cred nc in context.Nota_Cred)
            {
                table.AddRow(nc.codigo_nc, nc.ano, nc.nr_nc, nc.dt_emissao, nc.dt_criacao, nc.val_nc, nc.estado, nc.codigo_fat);

            }
            table.Write();
            Console.WriteLine();
        }

        public void AddNewNC(string codigo_fat)
        {
            try
            {
                context.AddNewNC(codigo_fat);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating new Nota_Credito:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }

        }

        public void Item()
        {
            ConsoleTable table = new ConsoleTable("Num item", "Desc", "Deconto", "Num Unid", "Codigo Fat", "SKU");

            foreach (Item item in context.Item)
            {
                table.AddRow(item.num_item, item.desc_item, item.desconto, item.num_uni, item.codigo_fat, item.sku);

            }
            table.Write();
            Console.WriteLine();
        }

        public void AddItemsFat(string desc_item, decimal desconto, decimal num_uni, string codigo_fat, string sku)
        {
            try
            {
                context.AddItemsFat(desc_item, desconto, num_uni, codigo_fat,sku);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating new fatura with itens:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }

        }


    }
}
