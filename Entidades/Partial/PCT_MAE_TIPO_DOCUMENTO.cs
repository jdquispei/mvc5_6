using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class T_MAE_TIPO_DOCUMENTO
    {
        public T_MAE_TIPO_DOCUMENTO()
        {
        }

        [DataMember]
        public string XTIPODOCUMENTO { get; set; }

        [DataMember]
        public bool FLAG_RESULT { get; set; }
        [DataMember]
        public string MESSAGE { get; set; }
    }
}
