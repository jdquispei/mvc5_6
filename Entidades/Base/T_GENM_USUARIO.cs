using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [DataContract]
    [Serializable]
    public partial class T_GENM_USUARIO
    {
        [DataMember]
        public int ID_USUARIO { get; set; }

        [DataMember]
        [Display(Name = "Login Usuario")]
        [Required(ErrorMessage = "Debe ingresar el login del usuario")]
        public string LOGIN { get; set; }
        [DataMember]
        [Display(Name = "Clave")]
        [DataType(DataType.Text)]
        public string PASSWORD { get; set; }
        [DataMember]
        [Display(Name = "Es un Usuario Activo?")]
        public bool FLG_ESTADO { get; set; }
        [DataMember]
        [Display(Name = "Es un Usuario Interno?")]
        public bool FLAG_USUARIO_INTERNO { get; set; }
        [DataMember]
        public int ID_PERSONA_NATURAL { get; set; }

        [DataMember]
        public int ID_USUARIO_REG { get; set; }
        [DataMember]
        public DateTime FEC_REG { get; set; }
        [DataMember]
        public int ID_USUARIO_ACT { get; set; }
        [DataMember]
        public DateTime FEC_ACT { get; set; }
    }
}
