using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public partial class T_GENM_USUARIO
    {
        public T_GENM_USUARIO()
        {
            FLG_ESTADO = true;
        }

        public T_GENM_USUARIO(IDataReader reader)
        {
            this.ID_USUARIO = Convert.ToInt32(reader["ID_USUARIO"]);
            this.FLG_ESTADO = reader["FLAG_ACTIVO"].ToString() == "1" ? true : false;
            this.LOGIN = reader["LOGIN"].ToString();
        }

        [DataMember]
        public string XUSUARIO { get; set; }

        [DataMember]
        [Display(Name = "Clave")]
        public string ClaveTexto { get; set; }

        [DataMember]
        [Display(Name = "Numero de documento")]
        public string NUMERO_DOCUMENTO { get; set; }

        [DataMember]
        public bool FLAG_RESULT { get; set; }
        [DataMember]
        public string MESSAGE { get; set; }
        [DataMember]
        public string PUESTO_USUARIO { get; set; }
        [DataMember]
        public string AREA_USUARIO { get; set; }
        [DataMember]
        public string CORREO_USUARIO { get; set; }
        [DataMember]
        public string FOTO_USUARIO { get; set; }
        [DataMember]
        public T_GENM_PERSONA_NATURAL o_T_GENM_PERSONA_NATURAL { get; set; }
        [DataMember]
        public T_GENM_PERFIL l_TGENM_PERFIL { get; set; }
        [DataMember]
        public List<T_GENM_MENU> l_T_GENM_MENU { get; set; }
        [DataMember]
        public string AuthKey { get; set; }
        [DataMember]
        public string XPERSONA_JURIDICA { get; set; }
        [DataMember]
        public string RAZON_SOCIAL { get; set; }
        [DataMember]
        public string DIRECCION_COMPLETA { get; set; }
        [DataMember]
        public string XCOORDINACION_TECNICA { get; set; }
        [DataMember]
        public string XID_DIRECCION_COORDINACION { get; set; }
        [DataMember]
        public string XID_INSPECTOR { get; set; }
        [DataMember]
        public string DE_COORDINACION_TECNICA { get; set; }
        [DataMember]
        public string NOMBRE_COMERCIAL { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string XCARGO { get; set; }
        [DataMember]
        public string DE_CARGO { get; set; }

        [DataMember]
        [Display(Name = "Perfil")]
        public int ID_PERFIL { get; set; }
        [DataMember]
        public string DESCRIPCION_PERFIL { get; set; }
        [DataMember]
        public List<T_GENM_PERFIL> T_GENM_PERFILES { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Persona Natural")]
        public string FULLNAME_PERSONA_NATURAL { get; set; }
    }
}
