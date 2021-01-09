using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace EF
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var context = new SI2Trab1Entities())
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                Service service = new Service(context);
                
                service.ResetDatabase();
                Console.WriteLine("Click enter after each test to proceed \n ");

                TestExerciseF(service);
                TestExerciseG(service);
                TestExerciseH(service);
                TestExerciseI(service);
                TestExerciseJ(service);
                TestExerciseK(service);
                TestExercise1b(service);
                TestExercise1c(service);
                stopwatch.Stop();
                Console.WriteLine($"Tempo passado: {stopwatch.Elapsed}");
                Click("End");
            }
        }

            private static void Click(string nextMessage = "")
            {
                Console.ReadKey();
                Console.WriteLine("\n{0}\n", nextMessage);
            }

            private static void TestExerciseF(Service service)
            {
                Click("************************** Exercicio F test **************************");
                
                service.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste");
                service.SaveChanges();
                service.Print_Fatura();
            }
        
            private static void TestExerciseG(Service service)
            {
                 Click("****************************** Exercise G test ****************************** \n");
                 service.AddNewNC("FT2001-12346");
                 service.Print_Nota_Cred();
            }

            private static void TestExerciseH(Service service)
            {
                  Click("****************************** Exercise H test ****************************** \n");
                  service.AddItemsFat("bacalhau", (decimal)0.3, 3, "FT2021-11111", "321458");
                  service.SaveChanges();
                  service.Print_Item();
            }

            private static void TestExerciseI(Service service)
            {
                Click("****************************** Exercise I test ****************************** \n");
                service.AtualizarValorTotal("FT2021-11111");
                service.RefreshAll();
                service.SaveChanges();
                service.Print_Fatura();
            }

            private static void TestExerciseJ(Service service)
            {
                Click("****************************** Exercise J test ****************************** \n");
                service.Print_List_Of_Nc(service.ListOfNotaCred(2001));
            }

            private static void TestExerciseK(Service service)
            {
                Click("****************************** Exercise K test ****************************** \n");

                service.AtualizarEstadoFat("FT2021-11111", "Emitida");
                service.RefreshAll();
                service.SaveChanges();
                service.Print_Fatura();
            }

            private static void TestExercise1b(Service service)
            {
                Click("****************************** Exercise 1b test ****************************** \n");
                
                Console.WriteLine("Próximo cod da fatura: "+service.GetNextFatCod("FT"));
                Console.WriteLine("Próximo cod da nota_cred: "+service.GetNextFatCod("NC"));
            }

            private static void TestExercise1c(Service service)
            {
                Click("****************************** Exercise 1c test ****************************** \n");
                string code = service.GetNextFatCod("FT"); //exercicio e
                service.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste"); //exercicio f
                service.AddItemsFat("bolo",0,3,code, "321455"); //exercicio H
                Thread.Sleep(1000);
                service.AtualizarValorTotal(code); //exercicio I
                Thread.Sleep(1000);
                service.AtualizarEstadoFat(code, "Emitida");//exercicio K
                service.Print_Fatura();
            }
        }
}
