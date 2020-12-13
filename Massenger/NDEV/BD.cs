using MasenggerModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Masengger.NDEV
{
    public static class BD
    {
        public static DataSet sp_Usuarios_Select(ref bool isEmpty, string correo)
        {
            SP sp = new SP("sp_Usuarios_Select");

            sp.AgregarParametro("Correo", correo);

            DataSet result = sp.EjecutaProcedimiento_SEL();
            isEmpty = IsEmpty(result);

            return result;
        }

        public static DataSet sp_Usuarios_SelectAll(ref bool isEmpty)
        {
            SP sp = new SP("sp_Usuarios_SelectAll");

            DataSet result = sp.EjecutaProcedimiento_SEL();
            isEmpty = IsEmpty(result);

            return result;
        }

        public static bool sp_Usuarios_Insert(Usuario usuario)
        {
            SP sp = new SP("sp_Usuarios_Insert");

            sp.AgregarParametro("Nick", usuario.Nick);
            sp.AgregarParametro("Correo", usuario.Correo);
            sp.AgregarParametro("Password", usuario.Password);

            return sp.EjecutaProcedimiento_UP_IN();
        }

        public static bool sp_Usuarios_Exists(string usuario = "", string correo = "")
        {
            SP sp = new SP("sp_Usuarios_Exists");

            sp.AgregarParametro("Nick", usuario);
            sp.AgregarParametro("Correo", correo);

            return Convert.ToBoolean(sp.EjecutaProcedimiento_SEL().Tables[0].Rows[0]["Existe"]);
        }

        public static DataSet sp_Mensajes_SelectAll(ref bool isEmpty, int idUsuario = 0, int idGrupo = 0, int idUsuarioRemitente = 0)
        {
            SP sp = new SP("sp_Mensajes_SelectAll");

            sp.AgregarParametro("IdUsuario", idUsuario);
            sp.AgregarParametro("IdUsuarioRemitente", idUsuarioRemitente);
            sp.AgregarParametro("IdGrupo", idGrupo);

            DataSet result = sp.EjecutaProcedimiento_SEL();
            isEmpty = IsEmpty(result);

            return result;
        }

        public static DataSet sp_Mensajes_Select(ref bool isEmpty, int idMensaje)
        {
            SP sp = new SP("sp_Mensajes_Select");

            sp.AgregarParametro("IdMensaje", idMensaje);

            DataSet result = sp.EjecutaProcedimiento_SEL();
            isEmpty = IsEmpty(result);

            return result;
        }

        public static bool sp_Mensajes_Insert(Mensaje mensaje)
        {
            SP sp = new SP("sp_Mensajes_Insert");

            sp.AgregarParametro("IdUsuario", mensaje.IdUsuario);
            sp.AgregarParametro("IdUsuarioRemitente", mensaje.IdUsuarioRemitente);
            sp.AgregarParametro("IdGrupo", mensaje.IdGrupo);
            sp.AgregarParametro("Contenido", mensaje.Contenido);
            sp.AgregarParametro("RutaContenido", mensaje.RutaContenido);

            if (!Convert.IsDBNull(mensaje.Binario))
            {
                sp.AgregarParametro("Binario", mensaje.Binario);
            }

            return sp.EjecutaProcedimiento_UP_IN();
        }

        public static int? sp_Mensajes_SelectMaxIdentity()
        {
            SP sp = new SP("sp_Mensajes_SelectMaxIdentity");

            DataSet result = sp.EjecutaProcedimiento_SEL();

            if (IsEmpty(result))
            {
                return null;
            }

            return Convert.ToInt32(result.Tables[0].Rows[0][0]);
        }

        public static bool IsEmpty(DataSet ds)
        {
            if (ds == null)
            {
                return true;
            }

            if (ds.Tables.Count <= 0)
            {
                return true;
            }

            if (ds.Tables[0].Rows.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (pro.PropertyType.Name == "Byte[]")
                        {
                            if (!Convert.IsDBNull(dr[column.ColumnName]))
                            {
                                pro.SetValue(obj, (byte[])dr[column.ColumnName]);
                            }
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
