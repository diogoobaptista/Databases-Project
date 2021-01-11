using System;

namespace TP2.UserInterface
{
    public class Test_UI
    {
        public static int Test()
        {
            try
            {
                Console.Write("Click Enter to run ADO tests");
                Console.ReadLine();
                Console.Write("Run ADO tests:");
                string adoRes = TestSuit.TestADO.RunSuit();
                
            
                Console.Write("Click Enter to run EF tests");
                Console.ReadLine();
                Console.Write("Run EF tests:");
                string efRes = TestSuit.TestEF.RunSuit();
                Console.WriteLine("Tempo de execução ADO: " + adoRes+ "\n Tempo de execução EF: "+efRes);
                Console.ReadLine();
                return 0;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error running tests " + e.Message);
                return -1;
            }
        }
    }
}