using DAL;
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
    public class AddItemFat_UI
    {
        public static int AddItemFat()
        {
            try
            {
                Print.Produto(new ProdutoService().GetProdutos());
                Console.Write("Qual o çodigo da fatura onde pretende adicionar itens?: ");
                string codigo = Console.ReadLine();
                Console.Write("Qual o item a adicionar a fatura?: ");
                string nome = Console.ReadLine();
                Console.Write("Qual o sku do item a adicionar a fatura?: ");
                string sku = Console.ReadLine();
                Console.Write("Qual o numero de unidades?: ");
                decimal num_uni = Decimal.Parse(Console.ReadLine());
                Console.Write("Desconto? \n eg:0.2");
                decimal desconto = Decimal.Parse(Console.ReadLine());
                //TODO VALIDAR SE O DESCONTO INSERIDO É CONFORME O ESPERADO COM 
                Console.Write("Insira 'A' caso queira o formato ADO.Net ou 'E' caso queira o formato EF: ");
                string option = Console.ReadLine();
                if (option == "A")
                {
                    ProcedureH storedProcedure = new ProcedureH();
                    AddItemService it = new AddItemService();
                    storedProcedure.AddItemsFat(codigo, nome, sku, num_uni, desconto);
                    Print.Item(it.GetItemsFat());
                    return 0;
                }
                else if (option == "E")
                {
                    using (TransactionScope ts = Transaction.GetTsSerializable())
                    {
                        using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                        {
                            Service service = new Service(context);
                            service.AddItemsFat(nome, desconto, num_uni, codigo, sku);
                            service.SaveChanges();
                            EF.Print.Print_Item(context);

                        }
                        ts.Complete();
                        return 0;
                    }
                }
                else { Console.WriteLine("Invalid Option"); return -1; }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Valores Inseridos não são validos");
                return -1;
            }
        }
    }
}