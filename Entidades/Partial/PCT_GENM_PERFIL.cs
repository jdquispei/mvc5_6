using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class T_GENM_PERFIL
    {
        public T_GENM_PERFIL()
        {
        }

        [DataMember]
        public string XPERFIL { get; set; }
        [DataMember]
        public string XMENU_PERFIL { get; set; }
        [DataMember]
        public string XMENU { get; set; }
        [DataMember]
        public int ID_MENU_PERFIL { get; set; }
        [DataMember]
        public int ID_MENU { get; set; }

    }
}
