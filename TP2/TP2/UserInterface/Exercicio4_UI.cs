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

                Console.WriteLine("O Contribuinte a alterar o que tem o nif 111222333");
                using (TransactionScope ts = Transaction.Ts.GetTsReadUnCommitted())
                {
                    decimal niff;
                    using (EF.SI2Trab1Entities context = new EF.SI2Trab1Entities())
                    {

                        Console.Write("Hey cara, qual o seu nome aí ? ");
                        var nomee = Console.ReadLine();

                        TP2.EF.Contribuinte contribuinteUpdt1 = (
                            from c in context.Contribuinte
                            where c.nif == 111222333
                            select c
                        ).SingleOrDefault();
                        contribuinteUpdt1.nome = nomee;
                        using (EF.SI2Trab1Entities context2 = new EF.SI2Trab1Entities())
                        {
                            Console.Write("Insira o seu novo nome: ");
                            var nome2 = Console.ReadLine();

                            TP2.EF.Contribuinte contribuinteUpdt2 = (
                                from c in context2.Contribuinte
                                where c.nif == 111222333
                                select c
                            ).SingleOrDefault();
                            contribuinteUpdt2.nome = nome2;
                            context2.SaveChanges();
                        }
                        context.SaveChanges();
                    }
                    ts.Complete();
                    return 0;
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine( e.Message);
                return -1;
            }
        }
    }
}