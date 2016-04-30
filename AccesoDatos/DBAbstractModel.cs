using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
//using Infraestructura;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AccesoDatos
{
    public class DBAbstractModel
    {
        private string connectionString = default(String);
        private string commandText = default(String);
        private CommandType commandType = default(CommandType);
        private List<DbParameter> inParams = default(List<DbParameter>);


        public Database getDb()
        {
            Database db = default(Database);
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            db = factory.Create("SQLconnectionStr");
            return db;
        }

        // @construct
        // @param   void
        /* public DBAbstractModel()
         {
             ConnectionFactory.DatabaseProvider = ConnectionFactory.MSSQL;
             connectionString = CShrapEncryption.DecryptString(ConfigurationManager.ConnectionStrings["MTC_DGAC"].ConnectionString);
         }*/
        // @param	text:string
        // @return	DBAbstractModel
        /*public DBAbstractModel Cmd(string text)
        {
            inParams = new List<DbParameter>();
            commandText = text;
            return this;
        }
        // @param	type:CommandType
        // @return	DBAbstractModel
        public DBAbstractModel CmdType(CommandType type)
        {
            commandType = type;
            return this;
        }
        // @param	@params:object
        // @return	DBAbstractModel
        public DBAbstractModel AddParameters(object @params)
        {
            // importante!
            // Hay que tener cuidado cuando utilice esta sobrecarga del constructor SqlParameter para especificar valores de 
            // parámetro de número entero. Dado que esta sobrecarga toma un parámetro value de tipo Object, cuando el 
            // valor entero sea cero se debe convertir en un tipo Object, tal como se muestra en el siguiente ejemplo de C#.
            // Parameter = new SqlParameter("@pname", Convert.ToInt32(0));
            // Si no se lleva a cabo esta conversión, el compilador supone que se está intentando llamar a la sobrecarga del 
            // constructor SqlParameter (string,SqlDbType).
            var type = @params.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                var param = ConnectionFactory.CreateParameter("@" + propertyInfo.Name, propertyInfo.GetValue(@params, null));
                param.Direction = ParameterDirection.Input;
                inParams.Add(param);
            }
            return this;
        }*/
        // @param	void
        // @return	Int32
        //public Int32 ExecuteNonQuery()
        //{
        //    try
        //    {
        //        using (var connection = ConnectionFactory.CreateConnection(connectionString))
        //        using (var cmd = connection.CreateCommand())
        //        {
        //            ConfigureCommand(cmd);
        //            PopulateParameters(cmd);
        //            connection.Open();
        //            var i32 = cmd.ExecuteNonQuery();
        //            return i32;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //throw;
        //    }
        //    return default(Int32);
        //}
        // @param	void
        // @return	SqlDataReader
        //public DbDataReader ExecuteReader()
        //{
        //    try
        //    {
        //        var connection = ConnectionFactory.CreateConnection(connectionString);
        //        var cmd = connection.CreateCommand();
        //        ConfigureCommand(cmd);
        //        PopulateParameters(cmd);
        //        connection.Open();
        //        var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        return reader;
        //    }
        //    catch (Exception)
        //    {
        //        //throw;
        //    }
        //    return default(DbDataReader);
        //}
        // @param	cmd:SqlCommand
        // @return	void
        public void ConfigureCommand(DbCommand cmd)
        {
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.CommandTimeout = 0;
        }
        // @param	cmd:SqlCommand
        // @return	void
        public void PopulateParameters(DbCommand cmd)
        {
            cmd.Parameters.AddRange(inParams.ToArray());
        }
        // @param	value:object
        // @return	T
        public T FromDB<T>(object value)
        {
            return (value == DBNull.Value) ? default(T) : (T)value;
        }
        // @param	value:T
        // @return	object
        public object ToDB<T>(T value)
        {
            return (value == null) ? (object)DBNull.Value : value;
        }
    }
}
