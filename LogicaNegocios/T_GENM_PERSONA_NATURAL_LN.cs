using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class T_GENM_PERSONA_NATURAL_LN
    {
        public List<T_GENM_PERSONA_NATURAL> prd_pagina_PersonaNatural(string filtro, string filtroMat, string filtroPat, string filtroDoc, int NumPag, int CantRegxPag)
        {
            return new T_GENM_PERSONA_NATURAL_DA().prd_pagina_PersonaNatural(filtro, filtroMat, filtroPat, filtroDoc, NumPag, CantRegxPag);
        }
    }
}
