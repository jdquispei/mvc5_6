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
    public partial class T_GENM_MENU : BEPaginacion
    {
        [DataMember]
        public int ID_MENU { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Debe ingresar la descripción del menu")]
        public string DESCRIPCION { get; set; }
        [Display(Name = "Url")]
        [Required(ErrorMessage = "Debe ingresar la Url del menu")]
        public string URL { get; set; }
        [Display(Name = "Orden")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese un dato numero valido para el Orden del Menu")]
        [Required(ErrorMessage = "Debe ingresar el Orden del menu")]
        public int ORDEN { get; set; }
        [Display(Name = "Activo?")]
        public bool FLG_ESTADO { get; set; }
        [Display(Name = "Ruta de Menu")]
        [Required(ErrorMessage = "Debe ingresar la ruta del menu")]
        [DataType(DataType.Text)]
        public string RUTA_MENU { get; set; }
        [Display(Name = "Grupo de Menu")]
        public int ID_MENU_ORIGEN { get; set; }

        [DataMember]
        public int ID_USUARIO_REG { get; set; }
        [DataMember]
        public DateTime FEC_REG { get; set; }
        [DataMember]
        public int ID_USUARIO_ACT { get; set; }
        [DataMember]
        public DateTime FEC_ACT { get; set; }
        [DataMember]
        public string XMENU { get; set; }
        [DataMember]
        public string XMENU_ORIGEN { get; set; }
    }
}
