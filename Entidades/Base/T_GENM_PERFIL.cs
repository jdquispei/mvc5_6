﻿using System;
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
    public partial class T_GENM_PERFIL 
    {
        [DataMember]
        public int ID_PERFIL { get; set; }
        [DataMember]
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar la descripción del perfil")]
        [MaxLength(100, ErrorMessage = "El campo descripción no debe exceder 100 caracteres")]
        [MinLength(3, ErrorMessage = "El campo descrición debe ser mayor a 3 caracteres")]
        public string DESCRIPCION { get; set; }
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
