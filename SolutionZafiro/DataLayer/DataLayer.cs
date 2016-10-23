using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace DataLayer
{
    public  class DataLayer
    {

        public string ZFCore_RecuperarParametro(string NombreParametro,string CodigoCompania) {
            DbConnection connection = null;
            string Parametro = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase(); //Crea el objeto base de datos, esto representa la connection a la base de datos indicada en el archivo de configuracion
                string SqlCommand = "ZFCore_RecuperarParametro";
                DbCommand DatabaseCommand = db.GetStoredProcCommand(SqlCommand);//Crea un SqlCommandComand a partir del nombre del procedimiento almacenado
                db.AddInParameter(DatabaseCommand, "NombreParametro", DbType.String, NombreParametro);
                db.AddInParameter(DatabaseCommand, "CodigoCompania", DbType.String, CodigoCompania);
                using (connection = db.CreateConnection())
                {
                    connection.Open();
                    Parametro = db.ExecuteScalar(DatabaseCommand).ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            return Parametro;
        }

        public void ZFCore_AsociarUsuarioCompania(string UserId, string Codigo)
        {
            DbConnection connection = null;            
            try
            {
                Database db = DatabaseFactory.CreateDatabase(); //Crea el objeto base de datos, esto representa la connection a la base de datos indicada en el archivo de configuracion
                string SqlCommand = "ZFCore_AsociarUsuarioCompania";
                DbCommand DatabaseCommand = db.GetStoredProcCommand(SqlCommand);//Crea un SqlCommandComand a partir del nombre del procedimiento almacenado
                db.AddInParameter(DatabaseCommand, "Codigo", DbType.String, Codigo);
                db.AddInParameter(DatabaseCommand, "IdUser", DbType.String, UserId);
                using (connection = db.CreateConnection())
                {

                    connection.Open();
                    Codigo = db.ExecuteScalar(DatabaseCommand).ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public string ZFCore_RecuperarCodigoCompania(string CodigoCompania)
        {
            DbConnection connection = null;
            string Codigo = "";
            try
            {
                Database db = DatabaseFactory.CreateDatabase(); //Crea el objeto base de datos, esto representa la connection a la base de datos indicada en el archivo de configuracion
                string SqlCommand = "ZFCore_RecuperarCodigoCompania";
                DbCommand DatabaseCommand = db.GetStoredProcCommand(SqlCommand);//Crea un SqlCommandComand a partir del nombre del procedimiento almacenado
                db.AddInParameter(DatabaseCommand, "Codigo", DbType.String, CodigoCompania);

                using (connection = db.CreateConnection())
                {

                   connection.Open();
                   Codigo= db.ExecuteScalar(DatabaseCommand).ToString();
                }
            }
            catch (Exception )
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
            return Codigo;
        }

        public void ZFCore_CompletarRegistroEstudiante(string Nuip,string Nombre,string Apellido,DateTime FechaNacimiento,string Telefono, string Movil,string Direccion,string CodigoCompañia,string AspUserId )
        {
                      
            DbConnection connection = null;
            try
            {
                Database db = DatabaseFactory.CreateDatabase(); //Crea el objeto base de datos, esto representa la connection a la base de datos indicada en el archivo de configuracion
                string SqlCommand = "ZFCore_CompletarRegistroEstudiante";
                DbCommand DatabaseCommand = db.GetStoredProcCommand(SqlCommand);//Crea un SqlCommandComand a partir del nombre del procedimiento almacenado
                db.AddInParameter(DatabaseCommand, "Nuip", DbType.String, Nuip);
                db.AddInParameter(DatabaseCommand, "Nombre", DbType.String, Nombre);
                db.AddInParameter(DatabaseCommand, "Apellido", DbType.String, Apellido);
                db.AddInParameter(DatabaseCommand, "FechaNacimiento", DbType.DateTime, FechaNacimiento);
                db.AddInParameter(DatabaseCommand, "Telefono", DbType.String, Telefono);
                db.AddInParameter(DatabaseCommand, "Movil", DbType.String, Movil);
                db.AddInParameter(DatabaseCommand, "Direccion", DbType.String, Direccion);
                db.AddInParameter(DatabaseCommand, "CodigoCompañia", DbType.String, CodigoCompañia);
                db.AddInParameter(DatabaseCommand, "AspUserId", DbType.String, AspUserId);
                using (connection = db.CreateConnection())
                {

                    connection.Open();
                    db.ExecuteNonQuery(DatabaseCommand);
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                connection.Close();
            }

        }
    }
}
