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
            initialProcedure.ResetDB();
            Console.WriteLine("Click enter after each test to proceed \n ");
            
            TestExerciseF();
            TestExerciseG();
            TestExerciseH();
            TestExerciseI();
            //TestExerciseJ();
            TestExercise1b();
            

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
            //initialProcedure.ResetDB();
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
            //initialProcedure.ResetDB();
            Console.ReadLine();

        }

        private static void TestExerciseH()
        {
            Console.WriteLine("****************************** Exercise H test ****************************** \n");
            ProcedureH storedProcedure = new ProcedureH();
            AddItemService it = new AddItemService();
            Item itsTest = new Item();
          
      
            itsTest.desc_item = "bacalhau";
            itsTest.num_uni = 3;
            itsTest.sku = "321458";
            itsTest.codigo_fat = "FT2021-11111";
            itsTest.desconto = 0.2M;

            Console.WriteLine("AddNewItem test : ");
            storedProcedure.AddItemsFat(itsTest);
            Print.Item(it.GetItemsFat());
            
            Console.ReadLine();

        }

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

       /* private static void TestExerciseJ()
        {
            Console.WriteLine("****************************** Exercise I test ****************************** \n");
            ProcedureJ storedProcedure = new ProcedureJ();
            NCService nc = new NCService();
            Nota_Cred ncTest = new Nota_Cred();

            ncTest.ano = 2001;


            Console.WriteLine("Listar Notas de Cred de um ano test : ");
            storedProcedure.ListOfNotaCred(ncTest);
            Print.Nota_Cred(nc.GetNotasCred());

            Console.ReadLine();

        }*/

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
            Console.WriteLine("FT"+anos+"-" + nr_fat);

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



        }
}
