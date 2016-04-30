using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class T_GENM_MENU
    {
        public T_GENM_MENU()
        {

        }

        public T_GENM_MENU(IDataReader reader)
        {
            this.ID_MENU = Convert.ToInt32(reader["ID_MENU"].ToString());
            this.DESCRIPCION = reader["DESCRIPCION"].ToString().Trim();
            this.ORDEN = Convert.ToInt32(reader["ORDEN"].ToString().Trim());
            this.URL = reader["URL"].ToString().Trim();
            this.RUTA_MENU = reader["RUTA_MENU"].ToString().Trim();
            this.ID_MENU_ORIGEN = Convert.ToInt32(reader["ID_MENU_ORIGEN"].ToString());
            this.FLG_ESTADO = Convert.ToBoolean(Convert.ToInt16(reader["FLG_ESTADO"].ToString().Trim()));
        }

        [DataMember]
        public string Controladora { get; set; }
        [DataMember]
        public string Accion { get; set; }
        [DataMember]
        public string Area { get; set; }

    }
}
