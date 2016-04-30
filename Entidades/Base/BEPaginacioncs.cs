using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BEPaginacion
    {
        public int Pagina { get; set; }
        public int TotalVirtual { get; set; }
        public int CantRegxPag { get; set; }

    }
}
