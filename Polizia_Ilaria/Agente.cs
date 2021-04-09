using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Polizia_Ilaria
{
    class Agente : Persona
    {
        public int IdAgente { get; }
        public int AnniServizio { get; }
        public DateTime DataNascita { get; }

        public Agente(int idAgente,string codiceFiscale, string nome, string cognome, int anniServizio, DateTime dataNascita)
            : base(nome, cognome, codiceFiscale)
        {
            IdAgente = idAgente;
            AnniServizio = anniServizio;
            DataNascita = dataNascita;
        }
    }
    
    
          
}
