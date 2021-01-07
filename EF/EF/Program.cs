using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EF
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var context = new SI2Trab1Entities())
            {
                Service service = new Service(context);
                service.ResetDatabase();
                Console.WriteLine("Click enter after each test to proceed \n ");

                TestExerciseF(service);
                TestExerciseG(service);
                TestExerciseH(service);
                //TestExerciseI();
                //TestExerciseJ();
                //TestExercise1b();
                //TestExercise1c();
                //TestExerciseK();
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
                Click("************************** ExercicioF **************************");
                
                service.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste");
                service.Fatura();
            }
        
            private static void TestExerciseG(Service service)
            {
                 Click("****************************** Exercise G test ****************************** \n");
                 service.AddNewNC("FT2001-12346");
                 service.Nota_Cred();
            }

            private static void TestExerciseH(Service service)
            {
                  Click("****************************** Exercise H test ****************************** \n");
                  service.AddItemsFat("bacalhau", 0, 3, "FT2021-11111", "321458");
                  service.Item();
            }
        /*
        private static void TestExerciseI()
        {
            Console.WriteLine("****************************** Exercise I test ****************************** \n");
            ProcedureI storedProcedure = new ProcedureI();
            FaturaService ft = new FaturaService();
            Fatura ftTest = new Fatura();

            ftTest.codigo_fat = "FT2021-11111";


            Console.WriteLine("AtualizarValorTotal test : ");
            storedProcedure.AtualizarValorTotal(ftTest);
            Print.Fatura(ft.GetFatura());

            Console.ReadLine();

        }
        private static void TestExerciseJ()
        {
            Console.WriteLine("** Exercise J test ** \n");
            ProcedureJ storedProcedure = new ProcedureJ();
            NCService nc = new NCService();
            Nota_Cred ncTest = new Nota_Cred();

            ncTest.ano = 2001;


            Console.WriteLine("Listar Notas de Cred de um ano test : ");
            Print.Nota_Cred((storedProcedure.ListOfNotaCred(ncTest)));

            Console.ReadLine();

        }
        private static void TestExercise1b()
        {
            Console.WriteLine("****************************** Exercise 1b test ****************************** \n");
            Console.WriteLine("Código da próxima fatura:");
            FaturaService ft = new FaturaService();
            decimal anos = DateTime.Now.Year;
            List<Fatura> num = ft.GetFatura().Where(fatura => fatura.ano == anos).ToList();

            decimal nr_fat = 11111;
            if (num.Any())
            {
                nr_fat = num.LastOrDefault().nr_fat + 1;
            }
            Console.WriteLine("FT" + anos + "-" + nr_fat);

            Console.WriteLine("Código da próxima Nota de crédito:");
            NCService nc = new NCService();
            decimal anos_nc = DateTime.Now.Year;
            List<Nota_Cred> ncs = nc.GetNotasCred().Where(nota_cred => nota_cred.ano == anos_nc).ToList();

            decimal nc_nr = 11111;
            if (ncs.Any())
            {
                nc_nr = ncs.LastOrDefault().nr_nc + 1;
            }
            Console.WriteLine("NC" + anos + "-" + nc_nr);
            Console.ReadLine();
        }

        private static void TestExercise1c()
        {
            Console.WriteLine("****************************** Exercise 1c test ****************************** \n");
            Console.WriteLine("Emissão de uma fatura:");
            FunctionE function = new FunctionE();
            string cod_fat = function.getNextFatCod("FT");  //procedure E
            Console.WriteLine("cod fatura" + cod_fat);
            ProcedureF storedProcedureF = new ProcedureF(); //procedure F
            FaturaService ft = new FaturaService();
            Contribuinte ctTest = new Contribuinte();
            ctTest.nif = 111111111;
            ctTest.nome = "Joana Teste";
            ctTest.morada = "Morada da Joana Teste";
            storedProcedureF.p_criafatura(ctTest);
            Console.WriteLine("//////////// Criar fatura sem Item ////////////");
            Print.Fatura(ft.GetFatura());

            ProcedureH storedProcedureH = new ProcedureH(); //H
            AddItemService it = new AddItemService();
            Item itsTest = new Item();

            itsTest.desc_item = "bacalhau";
            itsTest.num_uni = 3;
            itsTest.sku = "321458";
            itsTest.codigo_fat = "FT2021-11112";
            itsTest.desconto = 0.2M;

            storedProcedureH.AddItemsFat(itsTest);
            Console.WriteLine("//////////// Adicionar fatura com Item ////////////");
            Print.Item(it.GetItemsFat());

            ProcedureI storedProcedureI = new ProcedureI(); //I
            Fatura ftTest = new Fatura();

            ftTest.codigo_fat = "FT2021-11112";

            Thread.Sleep(1000);

            storedProcedureI.AtualizarValorTotal(ftTest);
            Console.WriteLine("//////////// Atualizar fatura com valor total atualizado ////////////");
            Print.Fatura(ft.GetFatura());

            Thread.Sleep(1000);

            ProcedureK storedProcedureK = new ProcedureK(); //K

            ftTest.codigo_fat = "FT2021-11112";
            ftTest.estado = "Emitida";

            storedProcedureK.AtualizarEstadoFat(ftTest);
            Console.WriteLine("//////////// Atualizar estado da fatura ////////////");
            Print.Fatura(ft.GetFatura());

            Console.ReadLine();
        }

        private static void TestExerciseK()
        {
            Console.WriteLine("****************************** Exercise K test ****************************** \n");
            ProcedureK storedProcedure = new ProcedureK();
            FaturaService ft = new FaturaService();
            Fatura ftTest = new Fatura();

            ftTest.codigo_fat = "FT2021-11111";
            ftTest.estado = "Emitida";

            Console.WriteLine("AtualizarEstadoFat test : ");
            storedProcedure.AtualizarEstadoFat(ftTest);
            Print.Fatura(ft.GetFatura());
            Console.WriteLine("******* PRESS ENTER *******");
            Console.ReadLine();


        }*/
    }
}
