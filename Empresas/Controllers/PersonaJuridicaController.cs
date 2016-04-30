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
    public class PersonaJuridicaController : Controller
    {
        // GET: PersonaJuridica
        [UserSystemAttribute]
        public ActionResult Index()
        {
            return View();
        }

        [UserSystemAttribute]
        [HttpPost]
        public JsonResult ListarPersonaJuridica(string Bus_Ruc = "", string Bus_Razon_Social = "", int page = 0, int pageSize = 10)
        {
            List<T_GENM_PERSONA_JURIDICA> l_T_GENM_PERSONA_JURIDICA = new T_GENM_PERSONA_JURIDICA_LN().prd_pagina_PersonaJuridica(Bus_Ruc, Bus_Razon_Social, page, pageSize);

            pageSize = l_T_GENM_PERSONA_JURIDICA.Count == 0 ? 0 : l_T_GENM_PERSONA_JURIDICA[0].TotalVirtual;

            return Json(new { l_T_GENM_PERSONA_JURIDICA = l_T_GENM_PERSONA_JURIDICA, pageSize = pageSize });
        }

        [UserSystemAttribute]
        public ActionResult PersonaJuridica(string PersonaJuridica = " ")
        {
            T_GENM_PERSONA_JURIDICA o_GenmPersonaNatural = null;

            if (PersonaJuridica.Trim().Equals(string.Empty))
            {
                o_GenmPersonaNatural = new T_GENM_PERSONA_JURIDICA();
                o_GenmPersonaNatural.XPERSONAJURIDICA = PersonaJuridica;
                o_GenmPersonaNatural.FLG_ESTADO = true;
                //o_GenmPersonaNatural.ListaDireccion = new List<T_GENM_DIRECCION>();
            }
            else
            {
                o_GenmPersonaNatural = new T_GENM_PERSONA_JURIDICA();
                o_GenmPersonaNatural.XPERSONAJURIDICA = PersonaJuridica;
                //o_GenmPersonaNatural = new T_GENM_PERSONA_NATURAL_LN().prd_detalle_persona_natural(o_GenmPersonaNatural);
                //o_GenmPersonaNatural.ListaDireccion = new T_GENM_DIRECCION_LN().prd_pagina_Direccion(PersonaNatural);
            }

            //LlenarMaestras();

            ViewBag.ListaTipoDocumento = new T_MAE_TIPO_DOCUMENTO_LN().PRD_SELECT_TIPO_DOCUMENTO();

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("PersonaNatural", o_GenmPersonaNatural);
            //}

            return View("PersonaJuridica", o_GenmPersonaNatural);
        }
    }
}