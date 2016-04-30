using Entidades;
using LogicaNegocios;
using Empresas.Models;
using System;
using System.Collections.Generic;
//using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UtilFactoria;

namespace Empresas.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                T_GENM_USUARIO o_T_GENM_USUARIO = new T_GENM_USUARIO();
                o_T_GENM_USUARIO.LOGIN = login.NombreUsuario;
                o_T_GENM_USUARIO.PASSWORD = login.Clave;//UtilFactoria.EncriptacionHelper.EncryptToByte(login.Clave);

                try
                {
                    //T_GENM_USUARIO o_T_GENM_USUARIO = new T_GENM_USUARIO();
                    o_T_GENM_USUARIO = new T_GENM_USUARIO_LN().prd_logym(o_T_GENM_USUARIO);
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", "Usuario o Clave incorrectas");
                    ModelState.AddModelError("", e.Message);
                    return View();
                }

                //o_T_GENM_USUARIO.AuthKey = CShrapEncryption.GenerateKey();

                if (o_T_GENM_USUARIO != null)
                {
                    //if (o_T_GENM_USUARIO.FLAG_RESULT)
                    //{
                    //    if (o_T_GENM_USUARIO.FLAG_USUARIO_INTERNO)
                    //    {
                    try
                    {
                        /*
                        DirectoryEntry DomainUser = ValidDirectory.valDominio(login.NombreUsuario, login.Clave);
                        o_T_GENM_USUARIO.PUESTO_USUARIO = DomainUser.Properties.Contains("title") == false ? String.Empty : DomainUser.Properties["title"][0].ToString().Trim().ToUpper();
                        o_T_GENM_USUARIO.AREA_USUARIO = DomainUser.Properties.Contains("physicalDeliveryOfficeName") == false ? String.Empty : DomainUser.Properties["physicalDeliveryOfficeName"][0].ToString();
                        o_T_GENM_USUARIO.CORREO_USUARIO = DomainUser.Properties.Contains("mail") == false ? String.Empty : DomainUser.Properties["mail"][0].ToString();
                        o_T_GENM_USUARIO.FOTO_USUARIO = DomainUser.Properties.Contains("thumbnailPhoto") == false ? System.Configuration.ConfigurationManager.AppSettings["no_foto"].ToString() : Convert.ToBase64String(DomainUser.Properties["thumbnailPhoto"][0] as byte[]) ?? String.Empty;
                        */
                        o_T_GENM_USUARIO.PUESTO_USUARIO = String.Empty;
                        o_T_GENM_USUARIO.AREA_USUARIO = String.Empty;
                        o_T_GENM_USUARIO.CORREO_USUARIO = String.Empty;
                        o_T_GENM_USUARIO.FOTO_USUARIO = String.Empty;

                        o_T_GENM_USUARIO.XCARGO = CShrapEncryption.EncryptString(o_T_GENM_USUARIO.XCARGO, o_T_GENM_USUARIO.AuthKey);
                        o_T_GENM_USUARIO.XCOORDINACION_TECNICA = CShrapEncryption.EncryptString(o_T_GENM_USUARIO.XCOORDINACION_TECNICA, o_T_GENM_USUARIO.AuthKey);

                        Session["AuthAccount"] = o_T_GENM_USUARIO;

                        FormsAuthentication.SetAuthCookie(
                         login.NombreUsuario, true);

                        return RedirectToAction("Index", "Main");
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("", "Usuario o Clave incorrectas");
                    }
                    //    }
                    //    else
                    //    {
                    //        if (o_T_GENM_USUARIO.PASSWORD.Equals(login.Clave))
                    //        {
                    //            o_T_GENM_USUARIO.XPERSONA_JURIDICA = CShrapEncryption.EncryptString(o_T_GENM_USUARIO.XPERSONA_JURIDICA, o_T_GENM_USUARIO.AuthKey);

                    //            Session["AuthAccount"] = o_T_GENM_USUARIO;
                    //            o_T_GENM_USUARIO.PUESTO_USUARIO = "";
                    //            o_T_GENM_USUARIO.AREA_USUARIO = "";
                    //            o_T_GENM_USUARIO.CORREO_USUARIO = "";
                    //            o_T_GENM_USUARIO.FOTO_USUARIO = System.Configuration.ConfigurationManager.AppSettings["no_foto"].ToString();

                    //            FormsAuthentication.SetAuthCookie(
                    //             login.NombreUsuario, true);

                    //            return RedirectToAction("Index", "Main");
                    //        }
                    //        else
                    //        {
                    //            ModelState.AddModelError("", "Usuario o Clave incorrectas");
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    ModelState.AddModelError("", "Usuario Inactivo");
                    //}

                }
                else
                {
                    ModelState.AddModelError("", "Usuario o Clave incorrectas");
                }

            }

            return View();
        }

    }
}