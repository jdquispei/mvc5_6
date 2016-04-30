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
using UtilesWeb;
using UtilFactoria;

namespace AccesoDatos
{
    public class T_MAE_TIPO_DOCUMENTO_DA : DBAbstractModel
    {

        private string cadena = ConfigurationManager.ConnectionStrings["SqlConnection"].ToString();
        public List<T_MAE_TIPO_DOCUMENTO> PRD_SELECT_TIPO_DOCUMENTO()
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.PRD_SELECT_TIPO_DOCUMENTO", cn))
                {
                    //cmd.BindByName = true;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cn.Open();
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    List<T_MAE_TIPO_DOCUMENTO> l_MAE_TIPO_DOCUMENTO = new List<T_MAE_TIPO_DOCUMENTO>();

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T_MAE_TIPO_DOCUMENTO o_T_MAE_TIPO_DOCUMENTO = new T_MAE_TIPO_DOCUMENTO();
                        o_T_MAE_TIPO_DOCUMENTO.XTIPODOCUMENTO = CShrapEncryption.EncryptString(dr["ID_TIPO_DOCUMENTO"].ToString().Trim(),VariablesWeb.AuthKey);
                        o_T_MAE_TIPO_DOCUMENTO.DESCRIPCION = dr["DESCRIPCION"].ToString().Trim();
                        l_MAE_TIPO_DOCUMENTO.Add(o_T_MAE_TIPO_DOCUMENTO);

                    }

                    cn.Close();
                    return l_MAE_TIPO_DOCUMENTO;
                }
            }            
        }
    }
}
