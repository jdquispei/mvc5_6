using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilFactoria
{
    public static class Variables
    {
        public const string ValorVerdadero = "1";
        public const string ValorFalso = "0";
        public const string MensajeObligatorio = "Dato obligatorio";
        public static DateTime FechaHoy { get { return DateTime.Now; } }
    }
}
