using Entidades;
using LogicaNegocios;
using Empresas.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilesWeb;
using UtilFactoria;


namespace Empresas.Controllers
{
    public class MainController : Controller
    {
        [UserSystemAttribute]
        public ActionResult Index()
        {
            T_GENM_USUARIO oT_Genm_Usuario = VariablesWeb.oT_Genm_Usuario;

            ViewBag.FECHA = DateTime.Now; ;
            ViewBag.FECHA = Variables.FechaHoy;

            ViewBag.FLG_USUARIO = oT_Genm_Usuario.FLAG_USUARIO_INTERNO;
            if (ViewBag.FLG_USUARIO == true)
            {
                ViewBag.XCOORDINACION_TECNICA = CShrapEncryption.DecryptString(oT_Genm_Usuario.XCOORDINACION_TECNICA, VariablesWeb.AuthKey);
                ViewBag.XCARGO = CShrapEncryption.DecryptString(oT_Genm_Usuario.XCARGO, VariablesWeb.AuthKey);
            }

            ViewBag.Main = true;

            return View();
        }

        //public JsonResult ListarInformacion()
        //{
        //    List<T_GENM_BANDEJA> l_GENM_INFORMACION = new T_GENM_BANDEJA_LN().prd_alerta_informacion_ct();
        //    return Json(new { l_GENM_INFORMACION = l_GENM_INFORMACION });
        //}


    }
}

