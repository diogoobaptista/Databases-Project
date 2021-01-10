using ConsoleTables;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public static class Print
    {
        public static void Fatura(List<Fatura> faturas)
        {
            ConsoleTable table = new ConsoleTable("Cod Fat", "Ano", "Nº Fat","Dt Emissao","Dt Criacao","Valor Total","Valor Iva","Estado","nif");

            foreach (Fatura ft in faturas)
            {
                table.AddRow(ft.codigo_fat, ft.ano, ft.nr_fat, ft.dt_emissao, ft.dt_criacao, ft.val_total, ft.val_iva, ft.estado, ft.nif);


               // Console.WriteLine("Fatura: codigo fat= " + ft.codigo_fat +"| ano= " + ft.ano + "| número da ft= " + ft.nr_fat +
                //    "| dt_emissao= " + ft.dt_emissao + "| dt_criacao= " + ft.dt_criacao + "| valor total ft= " + ft.val_total +"| valor iva ft= " + ft.val_iva + "| estado nc= " + ft.estado +
                //     "| nif= " + ft.nif);
               // Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
            }
            table.Write();
            Console.WriteLine();
        }

        public static void Nota_Cred(List<Nota_Cred> ncs)
        {
            ConsoleTable table = new ConsoleTable("Cod Nc", "Ano", "Nº NC", "Dt Emissao", "Dt Criacao", "Valor NC", "Estado", "Codigo Fat");

            foreach (Nota_Cred nc in ncs)
            {
                table.AddRow(nc.codigo_nc, nc.ano, nc.nr_nc, nc.dt_emissao, nc.dt_criacao, nc.val_nc, nc.estado, nc.codigo_fat);
                
            }
            table.Write();
            Console.WriteLine();
        }

        public static void Item(List<Item> itens)
        {
            ConsoleTable table = new ConsoleTable("Num item", "Desc", "Deconto", "Num Unid", "Codigo Fat", "SKU");

            foreach (Item item in itens)
            {
                table.AddRow(item.num_item, item.desc_item, item.desconto, item.num_uni, item.codigo_fat, item.sku);

            }
            table.Write();
            Console.WriteLine();
        }

        public static void Produto(List<Produto> produtos)
        {
            ConsoleTable table = new ConsoleTable("SKU", "Desc", "Iva", "Preço Unid");

            foreach (Produto produto in produtos)
            {
                table.AddRow(produto.sku, produto.desc_prod, produto.perc_iva, produto.preco_unit);

            }
            table.Write();
            Console.WriteLine();
        }
    }
}
