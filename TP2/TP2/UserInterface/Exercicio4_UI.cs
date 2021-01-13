using EF;
using System;
using System.Transactions;
using Entidades;
using TP2;
using System.Linq;


namespace TP2.UserInterface
{
    public class Exercicio4_UI
    {
        public static int Exercicio4()
        {
            try
            {
                using (TransactionScope ts = Transaction.Ts.GetTsReadUnCommitted())
                {
                    using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                    {
                        Console.WriteLine("Criar Contribuinte");
                        Console.Write("Insira o seu nif: ");
                        decimal niff = Decimal.Parse(Console.ReadLine());
                        if (niff.ToString().Length != 9) throw new FormatException();
                        Console.Write("Hey cara, qual o seu nome aí ? ");
                        var nomee = Console.ReadLine();
                        Console.Write("Insira a sua morada: ");
                        var moradaa = Console.ReadLine();

                        TP2.EF.Contribuinte newContribuinte = new TP2.EF.Contribuinte()
                        {
                            nif = niff,
                            nome = nomee,
                            morada = moradaa
                        };

                        context.Contribuinte.Add(newContribuinte);
                        Console.Write("Insira o seu novo nif: ");
                        decimal niff2 = Decimal.Parse(Console.ReadLine());
                        if (niff2.ToString().Length != 9) throw new FormatException();

                        TP2.EF.Contribuinte contribuinteUpdt = (
                            from c in context.Contribuinte
                            where c.nif == niff
                            select c
                        ).SingleOrDefault();

                        if (contribuinteUpdt != null)
                        {
                            contribuinteUpdt.nif = niff2;
                        }

                        context.SaveChanges();
                    }

                    ts.Complete();
                    return 0;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Valores Inseridos não são validos " + e.Message);
                return -1;
            }
        }
    }
}