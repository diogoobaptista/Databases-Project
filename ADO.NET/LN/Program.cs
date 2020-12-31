using Procedures;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace LN
{
    class Program
    {
       
        private static InicialProcedure initialProcedure = new InicialProcedure();

        public static void Main(string[] args) {
            Console.WriteLine("Click enter after each test to proceed \n ");

            TestExerciseF();
            TestExerciseG();
            //TestExerciseH();
            //TestExerciseI();
            //TestExerciseJ();

        }

        private static void TestExerciseF()
        {
            Console.WriteLine("****************************** Exercise F test ****************************** \n");
            ProcedureF storedProcedure = new ProcedureF();
            FaturaService ft = new FaturaService();
            Contribuinte ctTest = new Contribuinte();
                ctTest.nif = 111111111;
                ctTest.nome = "Joana Teste";
                ctTest.morada = "Morada da Joana Teste";
            
            Console.WriteLine("AddNewFat test : ");
            storedProcedure.p_criafatura(ctTest);
            Print.Fatura(ft.GetFatura());
            initialProcedure.ResetDB();
            Console.WriteLine("******* PRESS ENTER *******");
            Console.ReadLine();

           
        }

        private static void TestExerciseG()
        {
            Console.WriteLine("****************************** Exercise G test ****************************** \n");
            ProcedureG storedProcedure = new ProcedureG();
            NCService nc = new NCService();
            Nota_Cred ncTest = new Nota_Cred();
            
            ncTest.codigo_fat = "FT2001-12346";

            Console.WriteLine("AddNewNC test : ");
            storedProcedure.AddNewNC(ncTest);
            Print.Nota_Cred(nc.GetNotasCred());
            initialProcedure.ResetDB();
            Console.ReadLine();

        }
    }
}
