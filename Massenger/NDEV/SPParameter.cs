using System;
using System.Data;

namespace Masengger.NDEV
{
    public class SPParameter
    {
        #region Variables
        private string V_Variable;
        private object V_Valor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad para obtener el nombre de la variable
        /// </summary>
        public string Variable
        {
            get { return V_Variable; }
            set { V_Variable = value; }
        }

        /// <summary>
        /// Propiedad para obtener el valor de la Variable
        /// </summary>
        public object Valor
        {
            get { return V_Valor; }
            set { V_Valor = value; }
        }
        /// <summary>
        /// Tipos de Valores q puede Obtener la Variable
        /// </summary>
        public SqlDbType GetTypeProperty
        {
            get
            {
                try
                {
                    if (V_Valor == null)
                    {
                        return SqlDbType.VarChar;
                    }

                    switch (V_Valor.GetType().FullName.ToString())
                    {
                        case "System.String":
                            return SqlDbType.VarChar;
                        case "System.Int16":
                            return SqlDbType.Int;
                        case "System.Int32":
                            return SqlDbType.Int;
                        case "System.Int64":
                            return SqlDbType.Int;
                        case "System.Decimal":
                            return SqlDbType.Decimal;
                        case "System.Double":
                            return SqlDbType.BigInt;
                        case "System.DateTime":
                            return SqlDbType.DateTime;
                        case "System.Byte":
                            return SqlDbType.Image;
                        case "System.Byte[]":
                            return SqlDbType.Image;
                        case "System.Drawing.Bitmap":
                            return SqlDbType.Image;
                        case "System.Boolean":
                            return SqlDbType.Bit;
                        default:
                            return SqlDbType.VarChar;
                    }
                }
                catch (NullReferenceException)
                {
                    return SqlDbType.VarChar;
                }
            }
        }
        #endregion

        #region Constructor
        public SPParameter(string P_Variable, object P_Valor)
        {
            try
            {
                Variable = P_Variable;
                Valor = P_Valor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la creacion del parametro" + ex.Message);
            }
        }
        #endregion
    }
}
