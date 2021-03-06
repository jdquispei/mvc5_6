﻿using Entidades;
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
    public class PersonaNaturalController : Controller
    {
        // GET: PersonaNatural
        [UserSystemAttribute]
        public ActionResult Index()
        {
             return View();
        }

        [UserSystemAttribute]
        [HttpPost]
        public JsonResult ListarPersonaNatural(string Bus_Nombre = "", string Bus_Ape_Paterno = "", string Bus_Ape_Materno = "", string Bus_Nro_Documento = "", int page = 0, int pageSize = 10)
        {
            List<T_GENM_PERSONA_NATURAL> l_T_GENM_PERSONA_NATURAL = new T_GENM_PERSONA_NATURAL_LN().prd_pagina_PersonaNatural(Bus_Nombre, Bus_Ape_Paterno, Bus_Ape_Materno, Bus_Nro_Documento, page, pageSize);

            pageSize = l_T_GENM_PERSONA_NATURAL.Count == 0 ? 0 : l_T_GENM_PERSONA_NATURAL[0].TotalVirtual;

            return Json(new { l_T_GENM_PERSONA_NATURAL = l_T_GENM_PERSONA_NATURAL, pageSize = pageSize });
        }

        [UserSystemAttribute]
        public ActionResult PersonaNatural(string PersonaNatural = " ")
        {
            T_GENM_PERSONA_NATURAL o_GenmPersonaNatural = null;

            if (PersonaNatural.Trim().Equals(string.Empty))
            {
                o_GenmPersonaNatural = new T_GENM_PERSONA_NATURAL();
                o_GenmPersonaNatural.XPERSONANATURAL = PersonaNatural;
                o_GenmPersonaNatural.FLG_ESTADO = true;
                //o_GenmPersonaNatural.ListaDireccion = new List<T_GENM_DIRECCION>();
            }
            else
            {
                o_GenmPersonaNatural = new T_GENM_PERSONA_NATURAL();
                o_GenmPersonaNatural.XPERSONANATURAL = PersonaNatural;
                //o_GenmPersonaNatural = new T_GENM_PERSONA_NATURAL_LN().prd_detalle_persona_natural(o_GenmPersonaNatural);
                //o_GenmPersonaNatural.ListaDireccion = new T_GENM_DIRECCION_LN().prd_pagina_Direccion(PersonaNatural);
            }

            //LlenarMaestras();

            ViewBag.ListaTipoDocumento = new T_MAE_TIPO_DOCUMENTO_LN().PRD_SELECT_TIPO_DOCUMENTO();

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("PersonaNatural", o_GenmPersonaNatural);
            //}

            return View("PersonaNatural", o_GenmPersonaNatural);
        }
    }
}