using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Masengger.NDEV
{
    class SP
    {
        private SqlConnection Sql_conn = null;
        private SqlCommand Sql_cmd = null;
        private SqlParameter Sql_Parametro = null;
        private SqlDataAdapter Sql_Adapter = null;
        private DataSet ds_Resultado = new DataSet();

        private static string str_ConnectionDB = "";

        #region "Propiedades"

        public string Nombre { get; set; }

        public ArrayList Parametros { get; set; }

        #endregion

        #region "Constructor"

        public SP(string P_Nombre)
        {
            try
            {
                Nombre = P_Nombre;
                Parametros = new ArrayList();

                if (string.IsNullOrEmpty(str_ConnectionDB))
                {
                    str_ConnectionDB = $@"{ConfigurationManager.ConnectionStrings["default"].ConnectionString}";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Funciones"

        public void AgregarParametro(string P_Variable, object P_Valor)
        {
            try
            {
                SPParameter Parametro = new SPParameter("@" + P_Variable, P_Valor);
                Parametros.Add(Parametro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Funcion para ejecutar procediemiento [SELECT]
        /// </summary>
        /// <returns></returns>
        public DataSet EjecutaProcedimiento_SEL()
        {
            Sql_conn = new SqlConnection(str_ConnectionDB);

            Sql_conn.Open();
            try
            {
                Sql_cmd = new SqlCommand(Nombre, Sql_conn);
                Sql_cmd.CommandType = CommandType.StoredProcedure;
                Sql_cmd.CommandTimeout = 600;
                //Agrega las variables al procedimiento almacenado                
                foreach (SPParameter Parametro in Parametros)
                {
                    Sql_Parametro = new SqlParameter(Parametro.Variable, Parametro.GetTypeProperty);
                    Sql_Parametro.Direction = ParameterDirection.Input;
                    Sql_Parametro.Value = Parametro.Valor ?? DBNull.Value;
                    Sql_cmd.Parameters.Add(Sql_Parametro);
                }
                Sql_Adapter = new SqlDataAdapter(Sql_cmd);
                Sql_Adapter.Fill(ds_Resultado);

                return ds_Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sql_conn.Close();
            }
        }

        /// <summary>
        /// Funcion para ejecutar procediemiento [UPDATE-INSERT]
        /// </summary>
        /// <returns></returns>
        public bool EjecutaProcedimiento_UP_IN()
        {
            Sql_conn = new SqlConnection(str_ConnectionDB);

            Sql_conn.Open();
            bool Resultado = false;
            try
            {
                Sql_cmd = new SqlCommand(Nombre, Sql_conn);
                Sql_cmd.CommandType = CommandType.StoredProcedure;
                //Agrega las variables al procedimiento almacenado                
                foreach (SPParameter Parametro in Parametros)
                {
                    Sql_Parametro = new SqlParameter(Parametro.Variable, Parametro.GetTypeProperty);
                    Sql_Parametro.Direction = ParameterDirection.Input;
                    Sql_Parametro.Value = Parametro.Valor;
                    Sql_cmd.Parameters.Add(Sql_Parametro);
                }
                Resultado = (Convert.ToInt32(Sql_cmd.ExecuteNonQuery()) > 0) ? true : false;

                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sql_conn.Close();
            }
        }

        /// <summary>
        /// Funcion para ejecutar procediemiento [UPDATE-INSERT], Retornando el Identity
        /// </summary>
        /// <returns></returns>
        public int EjecutaProcedimiento_UP_IN_ReturnID()
        {
            Sql_conn = new SqlConnection(str_ConnectionDB);

            Sql_conn.Open();
            int Resultado = 0;
            try
            {
                Sql_cmd = new SqlCommand(Nombre, Sql_conn);
                Sql_cmd.CommandType = CommandType.StoredProcedure;
                //Agrega las variables al procedimiento almacenado                
                foreach (SPParameter Parametro in Parametros)
                {
                    Sql_Parametro = new SqlParameter(Parametro.Variable, Parametro.GetTypeProperty);
                    Sql_Parametro.Direction = ParameterDirection.Input;
                    Sql_Parametro.Value = Parametro.Valor;
                    Sql_cmd.Parameters.Add(Sql_Parametro);
                }
                Resultado = Convert.ToInt32(Sql_cmd.ExecuteScalar());

                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sql_conn.Close();
            }
        }

        /// <summary>
        /// Funcion para ejecutar procediemiento [SELECT TOTALES]
        /// </summary>
        /// <returns></returns>
        public bool EjecutaProcedimiento_TF()
        {
            Sql_conn = new SqlConnection(str_ConnectionDB);

            Sql_conn.Open();
            bool Resultado = false;
            try
            {
                Sql_cmd = new SqlCommand(Nombre, Sql_conn);
                Sql_cmd.CommandType = CommandType.StoredProcedure;
                //Agrega las variables al procedimiento almacenado                
                foreach (SPParameter Parametro in Parametros)
                {
                    Sql_Parametro = new SqlParameter(Parametro.Variable, Parametro.GetTypeProperty);
                    Sql_Parametro.Direction = ParameterDirection.Input;
                    Sql_Parametro.Value = Parametro.Valor;
                    Sql_cmd.Parameters.Add(Sql_Parametro);
                }
                Resultado = (Convert.ToInt32(Sql_cmd.ExecuteScalar()) > 0) ? true : false;

                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sql_conn.Close();
            }
        }

        /// <summary>
        /// Funcion para ejecutar procediemiento [SELECT COUNT]
        /// </summary>
        /// <returns></returns>
        public int EjecutaProcedimiento_COUNT()
        {
            Sql_conn = new SqlConnection(str_ConnectionDB);

            Sql_conn.Open();
            int Resultado = 0;
            try
            {
                Sql_cmd = new SqlCommand(Nombre, Sql_conn);
                Sql_cmd.CommandType = CommandType.StoredProcedure;
                //Agrega las variables al procedimiento almacenado                
                foreach (SPParameter Parametro in Parametros)
                {
                    Sql_Parametro = new SqlParameter(Parametro.Variable, Parametro.GetTypeProperty);
                    Sql_Parametro.Direction = ParameterDirection.Input;
                    Sql_Parametro.Value = Parametro.Valor;
                    Sql_cmd.Parameters.Add(Sql_Parametro);
                }
                Resultado = Convert.ToInt32(Sql_cmd.ExecuteScalar());

                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sql_conn.Close();
            }
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
