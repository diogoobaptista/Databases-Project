using Entidades;
using Functions;
using Procedures;
using Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TP2.TestSuit
{
    class TestADO
    {

        private static InicialProcedure initialProcedure = new InicialProcedure();


        public static void RunSuit()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            initialProcedure.ResetDB();
            Console.WriteLine("Click enter after each test to proceed \n ");

            TestExerciseF();
            TestExerciseG();
            TestExerciseH();
            TestExerciseI();
            TestExerciseJ();
            TestExerciseK();
            TestExercise1b();
            TestExercise1c();

            stopwatch.Stop();
            Console.WriteLine($"Tempo passado: {stopwatch.Elapsed}");
            Console.ReadLine();
        }

        private static void TestExerciseF()
        {
            Console.WriteLine("****************************** Exercise F test ****************************** \n");
            ProcedureF storedProcedure = new ProcedureF();
            FaturaService ft = new FaturaService();
            storedProcedure.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste");
            Print.Fatura(ft.GetFatura());
            Console.WriteLine("AddNewFat test : OK ");
            //Console.ReadLine();


        }

        private static void TestExerciseG()
        {
            Console.WriteLine("****************************** Exercise G test ****************************** \n");
            ProcedureG storedProcedure = new ProcedureG();
            NCService nc = new NCService();
            storedProcedure.AddNewNC("FT2001-12346");
            Print.Nota_Cred(nc.GetNotasCred());
            //initialProcedure.ResetDB();
            Console.WriteLine("AddNewNC test :  OK ");
            //Console.ReadLine();

        }

        private static void TestExerciseH()
        {
            Console.WriteLine("****************************** Exercise H test ****************************** \n");
            ProcedureH storedProcedure = new ProcedureH();
            AddItemService it = new AddItemService();
            storedProcedure.AddItemsFat("FT2021-11111", "bacalhau", "321458",3,0.2M);
            Print.Item(it.GetItemsFat());
            Console.WriteLine("AddNewItem test : OK");
           //Console.ReadLine();

        }

        private static void TestExerciseI()
        {
            Console.WriteLine("****************************** Exercise I test ****************************** \n");
            ProcedureI storedProcedure = new ProcedureI();
            FaturaService ft = new FaturaService();
            storedProcedure.AtualizarValorTotal("FT2021-11111");
            Print.Fatura(ft.GetFatura());
            Console.WriteLine("AtualizarValorTotal test : OK");
            //Console.ReadLine();

        }
        private static void TestExerciseJ()
        {
            Console.WriteLine("** Exercise J test ** \n");
            ProcedureJ storedProcedure = new ProcedureJ();
            NCService nc = new NCService();
            Print.Nota_Cred((storedProcedure.ListOfNotaCred(2001)));
            Console.WriteLine("Listar Notas de Cred de um ano test : OK");
            //Console.ReadLine();
        }

        private static void TestExerciseK()
        {
            Console.WriteLine("****************************** Exercise K test ****************************** \n");
            ProcedureK storedProcedure = new ProcedureK();
            FaturaService ft = new FaturaService();
            storedProcedure.AtualizarEstadoFat("FT2021-11111", "Emitida");
            Print.Fatura(ft.GetFatura());
            Console.WriteLine("AtualizarEstadoFat test : OK");
           // Console.ReadLine();
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
            Console.WriteLine("******* OK *******");
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
            storedProcedureF.p_criafatura(111111111, "Joana Teste", "Morada da Joana Teste");
            //Console.WriteLine("//////////// Criar fatura sem Item ////////////");
            //Print.Fatura(ft.GetFatura());

            ProcedureH storedProcedureH = new ProcedureH(); //H
            AddItemService it = new AddItemService();

            storedProcedureH.AddItemsFat("FT2021-11112", "bacalhau", "321458", 3, 0.2M);
            //Console.WriteLine("//////////// Adicionar fatura com Item ////////////");
            //Print.Item(it.GetItemsFat());

            ProcedureI storedProcedureI = new ProcedureI(); //I

            Thread.Sleep(1000);

            storedProcedureI.AtualizarValorTotal(cod_fat);
            //Console.WriteLine("//////////// Atualizar fatura com valor total atualizado ////////////");
            //Print.Fatura(ft.GetFatura());

            Thread.Sleep(1000);

            ProcedureK storedProcedureK = new ProcedureK(); //K

            storedProcedureK.AtualizarEstadoFat(cod_fat, "Emitida");
            //Console.WriteLine("//////////// Atualizar estado da fatura ////////////");
            Print.Fatura(ft.GetFatura());
            Console.WriteLine("******* OK *******");
            //Console.ReadLine();
        }
    }
}