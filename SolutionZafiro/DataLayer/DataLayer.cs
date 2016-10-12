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
        public void ZFCore_CompletarRegistroEstudiante(string Nuip,string Nombre,string Apellido,DateTime FechaNacimiento,string Telefono, string Movil,string Direccion,string CodigoCompañia,string AspUserId )
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
            
            DbConnection connection = null;
            try
            {
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
