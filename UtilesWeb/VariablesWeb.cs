using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Security.Claims;
using System.Web;

namespace UtilesWeb
{
    public static class VariablesWeb
    {
        /// <summary>
        /// Lista de Opciones de Menu o Paginas a las que tiene un usuario
        /// se basa en la aplicacion actual
        /// </summary> ,
        public static List<T_GENM_MENU> ListaMenu
        {
            get
            {
                T_GENM_USUARIO o_GENM_USUARIO = (T_GENM_USUARIO)HttpContext.Current.Session["AuthAccount"];
                if (o_GENM_USUARIO != null)
                {
                    if (o_GENM_USUARIO.l_T_GENM_MENU.Count > 0)
                    {
                        return o_GENM_USUARIO.l_T_GENM_MENU;
                    }
                }
                return null;

            }
        }

        /// <summary>
        /// Lista de Perfiles de Usuario que tiene el usuario validado
        /// </summary>
        public static T_GENM_PERFIL ListaPerfiles
        {
            get
            {
                T_GENM_USUARIO o_GENM_USUARIO = (T_GENM_USUARIO)HttpContext.Current.Session["AuthAccount"];
                if (o_GENM_USUARIO != null)
                {
                    if (o_GENM_USUARIO != null)
                    {
                        if (o_GENM_USUARIO.l_TGENM_PERFIL != null)
                        {
                            return o_GENM_USUARIO.l_TGENM_PERFIL;
                        }
                    }
                    return null;
                }
                return null;

            }
        }

        /// <summary>
        /// Usuario validado, contiene informacion de codigo de usuario.
        /// Dentro esta la entidad donde muestra la informacion de Oficina, area, etc
        /// </summary>
        public static T_GENM_USUARIO oT_Genm_Usuario
        {
            get
            {
                T_GENM_USUARIO o_GENM_USUARIO = (T_GENM_USUARIO)HttpContext.Current.Session["AuthAccount"];
                if (o_GENM_USUARIO != null)
                {
                    if (o_GENM_USUARIO != null)
                    {

                        return o_GENM_USUARIO;
                    }
                    return null;
                }
                return null;
            }
        }

        public static string AuthKey
        {
            get
            {
                T_GENM_USUARIO o_GENM_USUARIO = (T_GENM_USUARIO)HttpContext.Current.Session["AuthAccount"];
                if (o_GENM_USUARIO != null)
                {
                    if (o_GENM_USUARIO != null)
                    {

                        return o_GENM_USUARIO.AuthKey;
                    }
                    return null;
                }
                return null;
            }
        }

        /// <summary>
        /// Direccion IP a donde se ha validado el usuario
        /// </summary>
        /// 
        /*
        public static string oDireccionIP
        {
            get
            {
                var claims = ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims;
                if (claims != null)
                {
                    var ip = claims.Count() > 1 ? claims.FirstOrDefault(
                        p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/direccionip").
                        Value : "";

                    if (!string.IsNullOrEmpty(ip))
                    {
                        //string direccionIP = new JavaScriptSerializer().Deserialize<string>(ip);
                        return ip;
                    }
                }
                return "";

            }
        }*/

        public static string MensajeException { get; set; }

        /// <summary>
        /// Ruta del servidor donde actualmente estamos validados
        /// </summary>
        public static string RutaServidor
        {
            get
            {
                if (HttpContext.Current.Session["oRutaServidor"] != null)
                {
                    return (string)HttpContext.Current.Session["oRutaServidor"];
                }
                return "";
            }
            set { HttpContext.Current.Session["oRutaServidor"] = value; }
        }
    }
}
