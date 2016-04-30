using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class T_GENM_USUARIO_LN
    {
        public T_GENM_USUARIO prd_logym(T_GENM_USUARIO o_GENM_USUARIO)
        {
            return new T_GENM_USUARIO_DA().prd_logym(o_GENM_USUARIO);
        }
    }
}
