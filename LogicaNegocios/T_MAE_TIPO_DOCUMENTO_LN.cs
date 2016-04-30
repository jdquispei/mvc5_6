using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class T_MAE_TIPO_DOCUMENTO_LN
    {
        public List<T_MAE_TIPO_DOCUMENTO> PRD_SELECT_TIPO_DOCUMENTO()
        {
            return new T_MAE_TIPO_DOCUMENTO_DA().PRD_SELECT_TIPO_DOCUMENTO();
        }
    }
}
