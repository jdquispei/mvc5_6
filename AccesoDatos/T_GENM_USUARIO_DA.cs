using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    public class T_GENM_USUARIO_DA : DBAbstractModel
    {

        private string cadena = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
        public T_GENM_USUARIO prd_logym(T_GENM_USUARIO o_GENM_USUARIO)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.USP_LOGIN_USUARIO", cn))
                {
                    //cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@IN_LOGIN", SqlDbType.VarChar).Value = o_GENM_USUARIO.LOGIN.Trim().ToUpper();

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T_GENM_USUARIO o_T_GENM_USUARIO = new T_GENM_USUARIO();
                        o_T_GENM_USUARIO.ID_USUARIO = Convert.ToInt32(dr["ID_USUARIO"].ToString().Trim());
                        o_T_GENM_USUARIO.LOGIN = dr["LOGIN"].ToString().Trim();
                        o_T_GENM_USUARIO.PASSWORD = dr["PASSWORD"].ToString().Trim();

                    }

                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        T_GENM_PERFIL o_TGENM_PERFIL = new T_GENM_PERFIL();
                        o_TGENM_PERFIL.ID_PERFIL = Convert.ToInt32(dr["ID_PERFIL"].ToString().Trim());
                        o_TGENM_PERFIL.DESCRIPCION = dr["DESCRIPCION"].ToString().Trim();
                        o_TGENM_PERFIL.FLG_ESTADO = Convert.ToBoolean(Convert.ToInt16(dr["FLG_ESTADO"].ToString().Trim()));
                        o_GENM_USUARIO.l_TGENM_PERFIL = o_TGENM_PERFIL;
                    }

                    List<T_GENM_MENU> l_T_GENM_MENU = new List<T_GENM_MENU>();
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        T_GENM_MENU o_T_GENM_MENU = new T_GENM_MENU();
                        o_T_GENM_MENU.ID_MENU = Convert.ToInt32(dr["ID_MENU"].ToString().Trim());
                        o_T_GENM_MENU.DESCRIPCION = dr["DESCRIPCION"].ToString().Trim();
                        o_T_GENM_MENU.URL = dr["URL"].ToString().Trim();
                        o_T_GENM_MENU.Accion = "";
                        o_T_GENM_MENU.Controladora = "";
                        if (!dr["URL"].ToString().Trim().Equals("#"))
                        {
                            string[] str = dr["URL"].ToString().Trim().Split(new string[] { "/" }, StringSplitOptions.None);
                            o_T_GENM_MENU.Controladora = dr["URL"].ToString().Trim().Split('/')[1].ToString() == null ? "" : dr["URL"].ToString().Trim().Split('/')[1].ToString();
                            o_T_GENM_MENU.Accion = dr["URL"].ToString().Trim().Split('/')[2].ToString() == null ? "" : dr["URL"].ToString().Trim().Split('/')[2].ToString();
                        }

                        o_T_GENM_MENU.ORDEN = Convert.ToInt32(dr["ID_MENU"].ToString().Trim());
                        o_T_GENM_MENU.RUTA_MENU = dr["RUTA_MENU"].ToString().Trim();
                        o_T_GENM_MENU.ID_MENU_ORIGEN = Convert.ToInt32(dr["ID_MENU_ORIGEN"].ToString().Trim());
                        o_T_GENM_MENU.FLG_ESTADO = Convert.ToBoolean(Convert.ToInt16(dr["FLG_ESTADO"].ToString().Trim()));
                        l_T_GENM_MENU.Add(o_T_GENM_MENU);
                    }
                    o_GENM_USUARIO.l_T_GENM_MENU = l_T_GENM_MENU;

                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        T_GENM_PERSONA_NATURAL o_T_GENM_PERSONA_NATURAL = new T_GENM_PERSONA_NATURAL();
                        o_T_GENM_PERSONA_NATURAL.ID_PERSONA_NATURAL = Convert.ToInt32(dr["ID_PERSONA_NATURAL"].ToString().Trim());
                        o_T_GENM_PERSONA_NATURAL.NOMBRE = dr["NOMBRES"].ToString().Trim();
                        o_T_GENM_PERSONA_NATURAL.APELLIDO_PATERNO = dr["APELLIDO_PATERNO"].ToString().Trim();
                        o_T_GENM_PERSONA_NATURAL.APELLIDO_MATERNO = dr["APELLIDO_MATERNO"].ToString().Trim();
                        o_T_GENM_PERSONA_NATURAL.CORREO = dr["CORREO"].ToString().Trim();
                        o_T_GENM_PERSONA_NATURAL.FLG_ESTADO = Convert.ToBoolean(Convert.ToInt16(dr["FLG_ESTADO"].ToString().Trim()));
                        o_T_GENM_PERSONA_NATURAL.NOMBRE_COMPLETO = o_T_GENM_PERSONA_NATURAL.NOMBRE + ' ' + o_T_GENM_PERSONA_NATURAL.APELLIDO_PATERNO + ' ' + o_T_GENM_PERSONA_NATURAL.APELLIDO_MATERNO;
                        o_T_GENM_PERSONA_NATURAL.NUMERO_DOCUMENTO = dr["NUMERO_DOCUMENTO"].ToString().Trim();
                        o_GENM_USUARIO.o_T_GENM_PERSONA_NATURAL = o_T_GENM_PERSONA_NATURAL;

                    }

                    cn.Close();
                }
            }

            return o_GENM_USUARIO;
        }
    }
}
