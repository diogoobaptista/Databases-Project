using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    class App
    {
        public enum OPTIONS
        {
            NONE,
            Criar_Fatura,
            Criar_Nota_Crédito,
            Add_Item_A_Fatura,
            Atualizar_Valor_Total,
            Listar_Nota_Cred_AnoX,
            Atualizar_Estado_Fatura,
            Obter_Cod_Fatura,
            Obter_Cod_NC,
            Emitir_Fatura,
            Exit
        };

        private delegate int DBMethod();
        private Dictionary<OPTIONS, DBMethod> funcs;
        private static App _instance;
        public static App Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new App();
                return _instance;
            }
            private set { }
        }

        private App()
        {
            funcs = new Dictionary<OPTIONS, DBMethod>();
            funcs.Add(OPTIONS.Criar_Fatura, UserInterface.CF);
            /*funcs.Add(OPTIONS.Criar_Nota_Crédito, UserInterface.I2);
            funcs.Add(OPTIONS.Add_Item_A_Fatura, UserInterface.I3);
            funcs.Add(OPTIONS.Atualizar_Valor_Total, UserInterface.D1);
            funcs.Add(OPTIONS.Listar_Nota_Cred_AnoX, UserInterface.D2);
            funcs.Add(OPTIONS.Atualizar_Estado_Fatura, UserInterface.D3);
            funcs.Add(OPTIONS.Obter_Cod_Fatura, UserInterface.U1);
            funcs.Add(OPTIONS.Obter_Cod_NC, UserInterface.U2);
            funcs.Add(OPTIONS.Emitir_Fatura, UserInterface.U3); */ 
        }

        public OPTIONS DisplayMenu()
        {
            OPTIONS option = OPTIONS.NONE;
            try
            {
                Array arr = Enum.GetValues(typeof(OPTIONS));
                Console.WriteLine("Choose an option");
                for (int i = 1; i < arr.Length; i++)
                {
                    Console.WriteLine("{0} {1}. ", i, arr.GetValue(i).ToString());
                }
                Console.WriteLine();
                Console.Write("-> ");
                var result = Console.ReadLine();
                option = (OPTIONS)Enum.Parse(typeof(OPTIONS), result);
            }
            catch (ArgumentException ex)
            {
                //nothing to do. User press select no option and press enter.
            }
            return option;
        }

        public void Run()
        {
            OPTIONS userInput = OPTIONS.NONE;
            do
            {
                Console.Clear();
                userInput = DisplayMenu();
                Console.Clear();
                try
                {
                    funcs[userInput]();
                    Console.WriteLine("Press any key to return.");
                    Console.ReadKey();
                }
                catch (KeyNotFoundException ex)
                {
                    //Nothing to do. The option was not a valid one. Read another.
                }

            } while (userInput != OPTIONS.Exit);
        }
    }

    class MainClass
    {
        public static void Main(String[] args)
        {
            App.Instance.Run();
        }
    }
}
