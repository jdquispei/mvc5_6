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
    public class T_GENM_PERSONA_JURIDICA_DA
    {
        private string cadena = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();

        public List<T_GENM_PERSONA_JURIDICA> prd_pagina_PersonaJuridica(string Ruc, string RazonSocial, int NumPag, int CantRegxPag)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.PRD_PAGINA_PERSONA_JURIDICA", cn))
                {
                    //cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@In_Filtro_Ruc", SqlDbType.VarChar).Value = Ruc.Trim().ToUpper();
                    cmd.Parameters.Add("@In_Filtro_Razon_Social", SqlDbType.VarChar).Value = RazonSocial.Trim().ToUpper();
                    cmd.Parameters.Add("@In_NumPag", SqlDbType.Int).Value = NumPag;
                    cmd.Parameters.Add("@In_CantRegxPag", SqlDbType.Int).Value = CantRegxPag;
                    cmd.Parameters.Add("@Out_Var_Total", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("@Out_Cur_PersonaNatural", sqlDbType.RefCursor).Direction = ParameterDirection.Output;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    List<T_GENM_PERSONA_JURIDICA> l_GENM_PERSONA_JURIDICA = new List<T_GENM_PERSONA_JURIDICA>();

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T_GENM_PERSONA_JURIDICA o_TGENM_PERSONA_JURIDICA = new T_GENM_PERSONA_JURIDICA();
                        o_TGENM_PERSONA_JURIDICA.XPERSONAJURIDICA = CShrapEncryption.EncryptString(dr["ID_PERSONA_JURIDICA"].ToString().Trim(), VariablesWeb.AuthKey);
                        o_TGENM_PERSONA_JURIDICA.RUC = dr["RUC"].ToString().Trim();
                        o_TGENM_PERSONA_JURIDICA.RAZON_SOCIAL = dr["RAZON_SOCIAL"].ToString().Trim();
                        o_TGENM_PERSONA_JURIDICA.FLG_ESTADO = Convert.ToBoolean(Convert.ToInt16(dr["FLG_ESTADO"].ToString().Trim()));
                        o_TGENM_PERSONA_JURIDICA.TotalVirtual = Convert.ToInt32(cmd.Parameters[4].Value.ToString().Trim());
                        l_GENM_PERSONA_JURIDICA.Add(o_TGENM_PERSONA_JURIDICA);
                    }

                    cn.Close();
                    return l_GENM_PERSONA_JURIDICA;
                }
            }
        }
    }
}
