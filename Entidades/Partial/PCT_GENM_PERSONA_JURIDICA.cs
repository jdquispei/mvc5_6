using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class T_GENM_PERSONA_JURIDICA
    {
        public T_GENM_PERSONA_JURIDICA()
        {

        }
        [DataMember]
        public string XPERSONAJURIDICA { get; set; }
        [DataMember]
        [Display(Name = "Nº Certificado")]
        public string NUMERO_CERTIFICADO { get; set; }
        [DataMember]
        [Display(Name = "Fase Certificacion")]
        public string FASE_CERTIFICACION { get; set; }
        //[DataMember]
        //public List<T_GENM_CONTACTO> ListaContacto { get; set; }
        //[DataMember]
        //public List<T_GENM_AUTORIZACION> ListaAutorizacion { get; set; }
        //[DataMember]
        //public List<T_GENM_CERTIFICACION> ListaCertificacion { get; set; }
        [DataMember]
        public string TIPO { get; set; }
        [DataMember]
        public string XTIPO { get; set; }
        [DataMember]
        [Display(Name = "País")]
        public string XPAIS { get; set; }

        [DataMember]
        [Display(Name = "País Origen")]
        public string XPAIS_ORIGEN { get; set; }

        [DataMember]
        [Display(Name = "Departamento")]
        public string XDEPARTAMENTO { get; set; }
        [DataMember]
        [Display(Name = "Provincia")]
        public string XPROVINCIA { get; set; }
        [DataMember]
        [Display(Name = "Distrito")]
        public string XDISTRITO { get; set; }
        [DataMember]
        public string XFLG_NACIONALIDAD { get; set; }
        [DataMember]
        public string XTIPO_USUARIO { get; set; }

        [DataMember]
        public int ID_GIRO { get; set; }

        [DataMember]
        public string GIRO { get; set; }

        [DataMember]
        public int ID_DIRECCION_MTC { get; set; }

        [DataMember]
        public int ID_COORDINACION_TECNICA { get; set; }
    }
}
