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
    public partial class T_GENM_PERSONA_NATURAL : BEPaginacion
    {
        [DataMember]
        public int ID_PERSONA_NATURAL { get; set; }

        [DataMember]
        public int Id_Persona { get; set; }

        [DataMember]
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Debe ingresar Nombre o Nombres")]
        public string NOMBRE { get; set; }

        [DataMember]
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Debe ingresar Apellido Paterno")]
        public string APELLIDO_PATERNO { get; set; }

        [DataMember]
        [Display(Name = "Apellido Materno")]
        //[Required(ErrorMessage = "Debe ingresar Apellido Materno")]
        public string APELLIDO_MATERNO { get; set; }

        [DataMember]
        [Display(Name = "Tipo Documento")]
        public Int32 ID_TIPO_DOCUMENTO { get; set; }

        [DataMember]
        public string TIPO_DOCUMENTO { get; set; }

        [DataMember]
        [Display(Name = "Numero de documento")]
        [Required(ErrorMessage = "Debe ingresar Número de Documento")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Número de documento: Ingrese solo números")]
        public string NUMERO_DOCUMENTO { get; set; }

        [DataMember]
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Debe ingresar Correo Electrónico")]
        [RegularExpression("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", ErrorMessage = "Mail incorrecto")]
        public string CORREO { get; set; }

        [Display(Name = "Teléfono")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "Teléfono: Ingrese solo números")]
        public string TELEFONO { get; set; }

        [Display(Name = "Teléfono Adicional")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "Teléfono: Ingrese solo números")]
        //[Required(ErrorMessage = "Debe Ingresar el Teléfono")]
        public string TELEFONO_ADICIONAL { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe Ingresar Dirección")]
        public string DIRECCION { get; set; }

        [DataMember]
        [Display(Name = "Activo")]
        public bool FLG_ESTADO { get; set; }

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
