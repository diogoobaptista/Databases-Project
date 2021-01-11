using ConsoleTables;
using System;
using System.Collections.Generic;

namespace TP2.EF
{
    public class Print
    {

        public static void Print_Fatura(SI2Trab1Entities context)
        {
            ConsoleTable table = new ConsoleTable("Cod Fat", "Ano", "Nº Fat", "Dt Emissao", "Dt Criacao", "Valor Total", "Valor Iva", "Estado", "nif");

            foreach (Fatura ft in context.Fatura)
            {
                table.AddRow(ft.codigo_fat, ft.ano, ft.nr_fat, ft.dt_emissao, ft.dt_criacao, ft.val_total, ft.val_iva, ft.estado, ft.nif);
            }
            table.Write();
            Console.WriteLine();
        }

        public static void Print_Nota_Cred(SI2Trab1Entities context)
        {
            ConsoleTable table = new ConsoleTable("Cod Nc", "Ano", "Nº NC", "Dt Emissao", "Dt Criacao", "Valor NC", "Estado", "Codigo Fat");

            foreach (Nota_Cred nc in context.Nota_Cred)
            {
                table.AddRow(nc.codigo_nc, nc.ano, nc.nr_nc, nc.dt_emissao, nc.dt_criacao, nc.val_nc, nc.estado, nc.codigo_fat);

            }
            table.Write();
            Console.WriteLine();
        }

        public static void Print_Item(SI2Trab1Entities context)
        {
            ConsoleTable table = new ConsoleTable("Num item", "Desc", "Deconto", "Num Unid", "Codigo Fat", "SKU");

            foreach (Item item in context.Item)
            {
                table.AddRow(item.num_item, item.desc_item, item.desconto, item.num_uni, item.codigo_fat, item.sku);

            }
            table.Write();
            Console.WriteLine();
        }

        public static void Print_List_Of_Nc(List<ListOfNotaCred_Result> lista)
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
    }
}