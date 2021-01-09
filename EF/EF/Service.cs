using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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

        public void RefreshAll()
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.Reload();
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

        public void Print_Fatura()
        {
            ConsoleTable table = new ConsoleTable("Cod Fat", "Ano", "Nº Fat", "Dt Emissao", "Dt Criacao", "Valor Total", "Valor Iva", "Estado", "nif");

            foreach (Fatura ft in context.Fatura)
            {
                table.AddRow(ft.codigo_fat, ft.ano, ft.nr_fat, ft.dt_emissao, ft.dt_criacao, ft.val_total, ft.val_iva, ft.estado, ft.nif);
            }
            table.Write();
            Console.WriteLine();
        }

        public void Print_Nota_Cred()
        {
            ConsoleTable table = new ConsoleTable("Cod Nc", "Ano", "Nº NC", "Dt Emissao", "Dt Criacao", "Valor NC", "Estado", "Codigo Fat");

            foreach (Nota_Cred nc in context.Nota_Cred)
            {
                table.AddRow(nc.codigo_nc, nc.ano, nc.nr_nc, nc.dt_emissao, nc.dt_criacao, nc.val_nc, nc.estado, nc.codigo_fat);

            }
            table.Write();
            Console.WriteLine();
        }

        public void Print_Item()
        {
            ConsoleTable table = new ConsoleTable("Num item", "Desc", "Deconto", "Num Unid", "Codigo Fat", "SKU");

            foreach (Item item in context.Item)
            {
                table.AddRow(item.num_item, item.desc_item, item.desconto, item.num_uni, item.codigo_fat, item.sku);

            }
            table.Write();
            Console.WriteLine();
        }

        public void Print_List_Of_Nc(List<ListOfNotaCred_Result> lista)
        {
            ConsoleTable table = new ConsoleTable("Cod Nc", "Ano", "Nº NC", "Dt Emissao", "Dt Criacao", "Valor NC", "Estado", "Codigo Fat");

            var iterator = lista.GetEnumerator();
            while (iterator.MoveNext())
            {
                var nc = iterator.Current;
                table.AddRow(nc.codigo_nc, nc.ano, nc.nr_nc, nc.dt_emissao, nc.dt_criacao, nc.val_nc, nc.estado, nc.codigo_fat);
            }

            table.Write();
            Console.WriteLine();
        }

        public void p_criafatura(decimal nif, string nome, string morada)
        {
            try
            {
                context.p_criafatura(nif, nome, morada);
                
            } catch (Exception e) {
                Console.WriteLine("Error while creating new fatura:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }
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

        public void AtualizarValorTotal(string codigo_fat)
        {
            try
            {
                context.AtualizarValorTotal(codigo_fat);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while update fatura with valorTotal:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }
        }

        public List<ListOfNotaCred_Result> ListOfNotaCred(decimal ano)
        {
            try
            {
                return context.ListOfNotaCred(ano).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while creating list of NC:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
                return null;
            }

        }

        public void AtualizarEstadoFat(string codigo_fat, string novoEstado)
        {
            try
            {
                context.AtualizarEstadoFat(codigo_fat, novoEstado);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while update fatura with novoEstado:");
                Console.WriteLine("-- {0}", e.GetBaseException().Message);
            }
        }

         public string GetNextFatCod(string tipo_cod)
         {
            decimal anos = DateTime.Now.Year;
            if (tipo_cod == "FT") {
                List<Fatura> num = context.Fatura.Where(fatura => fatura.ano == anos).ToList();
                decimal nr_fat = 11111;
                if (num.Any())
                {
                    nr_fat = num.LastOrDefault().nr_fat + 1;
                }
                return tipo_cod + anos + "-" + nr_fat;
            }
            else if(tipo_cod == "NC")
            {
                List<Nota_Cred> num_nc = context.Nota_Cred.Where(nota_cred => nota_cred.ano == anos).ToList();
                decimal nc_nr = 11111;
                if (num_nc.Any())
                {
                    nc_nr = num_nc.LastOrDefault().nr_nc + 1;
                }
                return tipo_cod + anos + "-" + nc_nr;
            }
            return null;
         }


    }
}
