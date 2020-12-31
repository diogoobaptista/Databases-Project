using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN
{
    public static class Print
    {
        public static void Fatura(List<Fatura> faturas)
        {

            var t = new TablePrinter("Cod Fat", "Ano", "Nº Fat","Dt Emissao","Dt Criacao","Valor Total","Valor Iva","Estado","nif");
            


            foreach (Fatura ft in faturas)
            {
                t.AddRow(ft.codigo_fat, ft.ano, ft.nr_fat, ft.dt_emissao, ft.dt_criacao, ft.val_total, ft.val_iva, ft.estado, ft.nif);


               // Console.WriteLine("Fatura: codigo fat= " + ft.codigo_fat +"| ano= " + ft.ano + "| número da ft= " + ft.nr_fat +
                //    "| dt_emissao= " + ft.dt_emissao + "| dt_criacao= " + ft.dt_criacao + "| valor total ft= " + ft.val_total +"| valor iva ft= " + ft.val_iva + "| estado nc= " + ft.estado +
                //     "| nif= " + ft.nif);
               // Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
            }
            t.Print();
        }

        public static void Nota_Cred(List<Nota_Cred> notasCred)
        {
            foreach (Nota_Cred nc in notasCred)
            {
                Console.WriteLine("Notas de Crédito: codigo_nc= " + nc.codigo_nc + "| ano= " + nc.ano + "| número da nc= " + nc.nr_nc +
                    "| dt_emissao= " + nc.dt_emissao +"| dt_criacao= " + nc.dt_criacao + "| valor nc= " + nc.val_nc + "| estado nc= " + nc.estado + "| codigo fat= " + nc.codigo_fat);
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}
