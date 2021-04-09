using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Ilaria
{
    abstract class Persona
    {
        public string Nome { get; }
        public string Cognome { get; }
        public string CodiceFiscale { get; }

        public Persona(string nome, string cognome, string codiceFiscale)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceFiscale;
        }

    }    //implementare metodo equals per confrontare codici fiscali
}




         
