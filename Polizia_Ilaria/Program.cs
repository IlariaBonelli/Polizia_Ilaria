using System;
using System.Collections.Generic;

namespace Polizia_Ilaria
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1.Mostra tutti gli Agenti");
                Console.WriteLine("2.Mostra tutti gli Agenti assegnati ad un'area");
                Console.WriteLine("3.Mostra gli Agenti con tot anni di servizio");
                Console.WriteLine("4.Inserisci un nuovo Agente)");
                Console.WriteLine("0.Esci");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        MostraAgenti();
                        break;
                    case '2':
                        MostraAgentiDellArea();
                            break;
                    case '3':
                        MostraAgentiServizio();
                        break;
                    case '4':
                        InserisciAgente();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                        
                }
            } while (true);
        }

        private static void InserisciAgente()
        {
            Layer.InserisciAgente("nome","cognome","codiceFiscale", "dataNascita" ,anniServizio);
        }

        private static void MostraAgentiServizio()
        {
            throw new NotImplementedException();
        }

        private static void MostraAgentiDellArea()
        {
            throw new NotImplementedException();
        }

        private static void MostraAgenti()
        {
            List<Agente> agenti = Layer.MostraAgenti(idAgente);
            
            foreach (Agente a in agenti)
            {
                Console.WriteLine(a);
              
            };
        }
    }
}
