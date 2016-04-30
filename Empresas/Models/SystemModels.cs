using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Empresas.Models
{
    [Serializable()]
    public class Login
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar el login")]
        //[MaxLength(100, ErrorMessage = "El campo login no debe exceder 100 caracteres")]
        //[MinLength(3, ErrorMessage = "El campo login debe ser mayor a 3 caracteres")]
        public string NombreUsuario { get; set; }
        [Required, DataType(DataType.Password)]
        //[MaxLength(100, ErrorMessage = "El campo login no debe exceder 100 caracteres")]
        public string Clave { get; set; }
        [DataType(DataType.Password)]
        public string ClaveNuevaTexto { get; set; }
        [DataType(DataType.Password)]
        public string ClaveNuevaConfirmaTexto { get; set; }

        public byte[] ClaveNueva { get; set; }
    }
}