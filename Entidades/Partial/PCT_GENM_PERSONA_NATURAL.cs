using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class T_GENM_PERSONA_NATURAL
    {
        public T_GENM_PERSONA_NATURAL()
        {
        }

        [DataMember]
        [Display(Name = "Nombre Completo")]
        public string NOMBRE_COMPLETO { get; set; }

        [DataMember]
        public string XPERSONANATURAL { get; set; }

        [DataMember]
        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "Debe seleccionar Tipo de Documento")]
        public string XID_TIPO_DOCUMENTO { get; set; }

        //[DataMember]
        //public List<T_GENM_DIRECCION> ListaDireccion { get; set; }

        [DataMember]
        public string RAZON_SOCIAL { get; set; }
    }
}
