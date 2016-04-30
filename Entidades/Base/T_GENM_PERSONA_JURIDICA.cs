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
    public partial class T_GENM_PERSONA_JURIDICA : BEPaginacion
    {
        [DataMember]
        public int ID_PERSONA_JURIDICA { get; set; }

        [DataMember]
        [Display(Name = "Nombre o Razón Social")]
        //[Required(ErrorMessage = "Debe Ingresar la Razón Social")]
        public string RAZON_SOCIAL { get; set; }

        [DataMember]

        [Display(Name = "RUC")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Ruc: Ingrese solo números")]
        //[Required(ErrorMessage = "Debe Ingresar el RUC")]
        public string RUC { get; set; }

        [DataMember]
        [Display(Name = "Nombre Comercial")]
        public string NOMBRE_COMERCIAL { get; set; }

        [DataMember]
        [Display(Name = "Dirección")]
        public string DIRECCION { get; set; }

        [DataMember]
        [Display(Name = "Dirección Alternativa")]
        public string DIRECCION_ALTERNATIVA { get; set; }

        [DataMember]
        [Display(Name = "E-mail")]
        [RegularExpression("^[_a-z0-9-]+(.[_a-z0-9-]+)*@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$", ErrorMessage = "E-Mail incorrecto")]
        public string EMAIL { get; set; }

        [DataMember]
        [Display(Name = "Pagina Web")]
        //[RegularExpression("/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \?=.-]*)*\/?$/", ErrorMessage = "Pagina Web incorrecta")]
        public string PAGINA_WEB { get; set; }

        [Display(Name = "Teléfono 1")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Teléfono: Ingrese solo números")]
        //[Required(ErrorMessage = "Debe Ingresar el Teléfono")]
        public string TELEFONO1 { get; set; }

        [Display(Name = "Teléfono 2")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Teléfono: Ingrese solo números")]
        public string TELEFONO2 { get; set; }

        [DataMember]
        [Display(Name = "Nacionalidad")]
        public bool FLG_NACIONALIDAD { get; set; }
        [DataMember]
        public bool ID_PAIS { get; set; }

        [DataMember]
        [Display(Name = "Activo")]
        public bool FLG_ESTADO { get; set; }

        [DataMember]
        [Display(Name = "Dirección")]
        public string DIRECCION_COMPLETA { get; set; }

        [DataMember]
        public int ID_USUARIO_REG { get; set; }

        [DataMember]
        public DateTime FEC_REG { get; set; }

        [DataMember]
        public int ID_USUARIO_ACT { get; set; }

        [DataMember]
        public DateTime FEC_ACT { get; set; }

        [DataMember]
        public string TELEFONO_1 { get; set; }

        [DataMember]
        public string TELEFONO_2 { get; set; }

        [DataMember]
        public string WEB { get; set; }

        [DataMember]
        public string ABREVIATURA { get; set; }

        [DataMember]
        [Display(Name = "Departamento")]
        public string DESC_DEPARTAMENTO { get; set; }

        [DataMember]
        [Display(Name = "Provincia")]
        public string DESC_PROVINCIA { get; set; }

        [DataMember]
        [Display(Name = "Distrito")]
        public string DESC_DISTRITO { get; set; }

        [DataMember]
        [Display(Name = "Condicion")]
        public string DESC_CONDICION { get; set; }
    }
}