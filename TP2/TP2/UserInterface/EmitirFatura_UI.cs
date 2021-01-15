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
using System.Transactions;

namespace TP2.UserInterface
{
    public class EmitirFatura_UI
    {
        public static int EmitirFatura()
        {
            try
            {
                Console.WriteLine("Emitir Fatura");
                Console.Write("Insira o seu nif: ");
                decimal nif = Decimal.Parse(Console.ReadLine());
                Console.Write("Insira o seu nome: ");
                var nome = Console.ReadLine();
                Console.Write("Insira a sua morada: ");
                var morada = Console.ReadLine();
                Print.Produto(new ProdutoService().GetProdutos());
                Console.Write("Qual o item a adicionar a fatura?: ");
                string nome_item = Console.ReadLine();
                Console.Write("Qual o sku do item a adicionar a fatura?: ");
                string sku = Console.ReadLine();
                Console.Write("Qual o numero de unidades?: ");
                decimal num_uni = Decimal.Parse(Console.ReadLine());
                Console.Write("Desconto? eg:0.2");
                decimal desconto = Decimal.Parse(Console.ReadLine());

                Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
                string option = Console.ReadLine();
                if (option == "A")
                {
                    string cod_fat = new FunctionE().getNextFatCod("FT");
                    FaturaService ft = new FaturaService();
                    new ProcedureF().p_criafatura(nif, nome, morada);
                    AddItemService it = new AddItemService();
                    new ProcedureH().AddItemsFat(cod_fat, nome_item, sku, num_uni, desconto);
                    new ProcedureI().AtualizarValorTotal(cod_fat);
                    new ProcedureK().AtualizarEstadoFat(cod_fat, "Emitida");
                    Print.Item(it.GetItemsFat());
                    Print.Fatura(ft.GetFatura());
                    return 0;
                }
                else if (option == "E")
                {
                    using (TransactionScope ts = Transaction.Ts.GetTsSerializable())
                    {
                        using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                        {
                            Service service = new Service(context);
                            string cod_fat = service.GetNextFatCod("FT");
                            service.p_criafatura(nif, nome, morada);
                            service.AddItemsFat(nome, desconto, num_uni, cod_fat, sku);
                            service.AtualizarValorTotal(cod_fat);
                            service.RefreshAll();
                            service.AtualizarEstadoFat(cod_fat, "Emitida");
                            service.RefreshAll();
                            service.SaveChanges();
                            EF.Print.Print_Item(context);
                            EF.Print.Print_Fatura(context);
                        }
                        ts.Complete();
                        return 0;
                    }
                }
                else { Console.WriteLine("Invalid Option"); return -1; }
            }
            catch (Exception e)
            {
                Console.WriteLine("Valores Inseridos não são validos " + e.Message);
                return -1;
            }
        }

    }
}