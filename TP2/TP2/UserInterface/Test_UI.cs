using System;

namespace TP2.UserInterface
{
    public class Test_UI
    {
        public static int Test()
        {
            try
            {
                Console.Write("Run ADO tests:");
                TestSuit.TestADO.RunSuit();
                Console.Write("Run EF tests:");
                TestSuit.TestEF.RunSuit();
                return 0;
            }
            catch(Exception e)
            {
                return -1;
            }
        }
    }
}