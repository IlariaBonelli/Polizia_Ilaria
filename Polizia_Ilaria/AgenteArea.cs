using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polizia_Ilaria
{
    class AgenteArea
    {
        public int IdAgente { get; }
        public int CodiceArea { get; }

        public AgenteArea (int idAgente, int codiceArea)
        {
            IdAgente = idAgente;
            CodiceArea = codiceArea;
        }
    }
}
