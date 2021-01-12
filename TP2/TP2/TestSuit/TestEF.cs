using EF;
using System;
using System.Diagnostics;
using System.Threading;
using System.Transactions;
using TP2.EF;

namespace TP2.TestSuit
{
    public class TestEF
    {

        public static string RunSuit()
        {
            string result = null;
            using (TransactionScope ts = Transaction.Ts.GetTsSerializable())
            {
                using (var context = new SI2Trab1Entities())
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    Service service = new Service(context);

                    service.ResetDatabase();

                    TestExerciseF(service);
                    TestExerciseG(service);
                    TestExerciseH(service);
                    TestExerciseI(service);
                    TestExerciseJ(service);
                    TestExerciseK(service);
                    TestExercise1b(service);
                    TestExercise1c(service);
                    stopwatch.Stop();
                    result = $"Tempo passado: {stopwatch.Elapsed}";
                }
                ts.Complete();
                return result;
            }
        }

        private static void TestExerciseF(Service service)
        {
            Console.WriteLine("************************** Exercicio F test **************************");

            service.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste");
            service.SaveChanges();
            EF.Print.Print_Fatura(service.context);
            Console.WriteLine("AddNewFat test : OK ");
        }

        private static void TestExerciseG(Service service)
        {
            Console.WriteLine("****************************** Exercise G test ****************************** \n");
            service.AddNewNC("FT2001-12346");
            EF.Print.Print_Nota_Cred(service.context);
            Console.WriteLine("AddNewNC test :  OK ");
        }

        private static void TestExerciseH(Service service)
        {
            Console.WriteLine("****************************** Exercise H test ****************************** \n");
            service.AddItemsFat("bacalhau", (decimal)0.3, 3, "FT2021-11111", "321458");
            service.SaveChanges();
            EF.Print.Print_Item(service.context);
            Console.WriteLine("AddNewItem test : OK");
        }

        private static void TestExerciseI(Service service)
        {
            Console.WriteLine("****************************** Exercise I test ****************************** \n");
            service.AtualizarValorTotal("FT2021-11111");
            service.RefreshAll();
            service.SaveChanges();
            EF.Print.Print_Fatura(service.context);
            Console.WriteLine("AtualizarValorTotal test : OK");
        }

        private static void TestExerciseJ(Service service)
        {
            Console.WriteLine("****************************** Exercise J test ****************************** \n");
            EF.Print.Print_List_Of_Nc(service.ListOfNotaCred(2001));
            Console.WriteLine("Listar Notas de Cred de um ano test : OK");
        }

        private static void TestExerciseK(Service service)
        {
            Console.WriteLine("****************************** Exercise K test ****************************** \n");

            service.AtualizarEstadoFat("FT2021-11111", "Emitida");
            service.RefreshAll();
            service.SaveChanges();
            EF.Print.Print_Fatura(service.context);
            Console.WriteLine("AtualizarEstadoFat test : OK");
        }

        private static void TestExercise1b(Service service)
        {
            Console.WriteLine("****************************** Exercise 1b test ****************************** \n");

            Console.WriteLine("Próximo cod da fatura: " + service.GetNextFatCod("FT"));
            Console.WriteLine("Próximo cod da nota_cred: " + service.GetNextFatCod("NC"));
            Console.WriteLine("******* OK *******");
        }

        private static void TestExercise1c(Service service)
        {
            Console.WriteLine("****************************** Exercise 1c test ****************************** \n");
            string code = service.GetNextFatCod("FT"); //exercicio e
            service.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste"); //exercicio f
            service.AddItemsFat("bolo", 0, 3, code, "321455"); //exercicio H
            
            service.AtualizarValorTotal(code); //exercicio I
            
            service.AtualizarEstadoFat(code, "Emitida");//exercicio K
            EF.Print.Print_Fatura(service.context);
            Console.WriteLine("******* OK *******");
        }
    }
}