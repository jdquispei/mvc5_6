using Entidades;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilesWeb;
using UtilFactoria;

namespace AccesoDatos
{
    public class T_GENM_PERSONA_NATURAL_DA
    {
        private string cadena = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

        public List<T_GENM_PERSONA_NATURAL> prd_pagina_PersonaNatural(string filtro, string filtroMat, string filtroPat, string filtroDoc, int NumPag, int CantRegxPag)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.PRD_PAGINA_PERSONA_NATURAL", cn))
                {
                    //cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@In_Filtro_Nombre", SqlDbType.VarChar).Value = filtro.Trim().ToUpper();
                    cmd.Parameters.Add("@In_Filtro_APaterno", SqlDbType.VarChar).Value = filtroMat.Trim().ToUpper();
                    cmd.Parameters.Add("@In_Filtro_AMaterno", SqlDbType.VarChar).Value = filtroPat.Trim().ToUpper();
                    cmd.Parameters.Add("@In_Filtro_Documento", SqlDbType.VarChar).Value = filtroDoc.Trim().ToUpper();
                    cmd.Parameters.Add("@In_NumPag", SqlDbType.Int).Value = NumPag;
                    cmd.Parameters.Add("@In_CantRegxPag", SqlDbType.Int).Value = CantRegxPag;
                    cmd.Parameters.Add("@Out_Var_Total", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("@Out_Cur_PersonaNatural", sqlDbType.RefCursor).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    List<T_GENM_PERSONA_NATURAL> l_GENM_PERSONA_NATURAL = new List<T_GENM_PERSONA_NATURAL>();

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T_GENM_PERSONA_NATURAL o_TGENM_PERSONA_NATURAL = new T_GENM_PERSONA_NATURAL();
                        o_TGENM_PERSONA_NATURAL.XPERSONANATURAL = CShrapEncryption.EncryptString(dr["ID_PERSONA_NATURAL"].ToString().Trim(), VariablesWeb.AuthKey);
                        o_TGENM_PERSONA_NATURAL.NOMBRE = dr["NOMBRES"].ToString().Trim();
                        o_TGENM_PERSONA_NATURAL.APELLIDO_PATERNO = dr["APELLIDO_PATERNO"].ToString().Trim();
                        o_TGENM_PERSONA_NATURAL.APELLIDO_MATERNO = dr["APELLIDO_MATERNO"].ToString().Trim();
                        o_TGENM_PERSONA_NATURAL.ID_TIPO_DOCUMENTO = Convert.ToInt32(dr["ID_TIPO_DOCUMENTO"].ToString().Trim());
                        o_TGENM_PERSONA_NATURAL.TIPO_DOCUMENTO = dr["TIPO_DOCUMENTO"].ToString().Trim();
                        o_TGENM_PERSONA_NATURAL.NUMERO_DOCUMENTO = dr["NUMERO_DOCUMENTO"].ToString().Trim();
                        o_TGENM_PERSONA_NATURAL.CORREO = dr["CORREO"].ToString().Trim();
                        o_TGENM_PERSONA_NATURAL.FLG_ESTADO = Convert.ToBoolean(Convert.ToInt16(dr["FLG_ESTADO"].ToString().Trim()));
                        o_TGENM_PERSONA_NATURAL.TotalVirtual = Convert.ToInt32(cmd.Parameters[6].Value.ToString().Trim());
                        l_GENM_PERSONA_NATURAL.Add(o_TGENM_PERSONA_NATURAL);
                    }

                    cn.Close();
                    return l_GENM_PERSONA_NATURAL;
                }
            }
        }
    }
}
