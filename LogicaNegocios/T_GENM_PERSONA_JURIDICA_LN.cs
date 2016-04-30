using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class T_GENM_PERSONA_JURIDICA_LN
    {
        public List<T_GENM_PERSONA_JURIDICA> prd_pagina_PersonaJuridica(string Ruc, string RazonSocial, int NumPag, int CantRegxPag)
        {
            return new T_GENM_PERSONA_JURIDICA_DA().prd_pagina_PersonaJuridica(Ruc, RazonSocial, NumPag, CantRegxPag);
        }
    }
}
