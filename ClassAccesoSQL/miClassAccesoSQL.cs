using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ClassAccesoSQL
{
    public class miClassAccesoSQL
    {
        private string cadConexion;
        private SqlConnection cnglobal = null;

        public miClassAccesoSQL(string cadenaBD)
        {
            cadConexion = cadenaBD;
        }
        public string AbrirConexion() // Metodo con parametros de referencia
        {
            string mensaje = "";
            cnglobal.ConnectionString = cadConexion;
            try
            {
                cnglobal.Open();
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                cnglobal = null; //Devuelve una conexion nula
                mensaje = "Error: " + r.Message;
            }
            return mensaje;
        }


        public DataSet ConsultaDS(string querySql, ref string mensaje)
        {
            //SqlConnection conAbierta = null;
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();

            mensaje = AbrirConexion();
            {
                if (cnglobal == null)
                {
                    mensaje = "No hay conexion a la BD";
                    DS_salida = null;
                }
                else
                {
                    carrito = new SqlCommand();
                    carrito.CommandText = querySql;
                    carrito.Connection = cnglobal;

                    trailer = new SqlDataAdapter();
                    trailer.SelectCommand = carrito;

                    try
                    {
                        trailer.Fill(DS_salida, "tabla0");
                        mensaje = "Consulta Correcta en DataSet";
                    }
                    catch (Exception a)
                    {
                        DS_salida = null;
                        mensaje = "Error!" + a.Message;
                    }
                    cnglobal.Close();
                    cnglobal.Dispose();
                }
            }
            return DS_salida;
        }

        public void CerrarConexion()
        {
            //Verificamos la conexión global
            if (cnglobal != null)
            {
                //Veo si está abierto
                if (cnglobal.State == ConnectionState.Open)
                {
                    //Entonces lo cierro y le hago DISPOSE :V JUAS JUAS
                    cnglobal.Close();
                    cnglobal.Dispose();
                }
            }
            
        }

        public SqlDataReader ConsultarReader(string querySql,  ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            mensaje = AbrirConexion();
            if (cnglobal == null)
            {
                mensaje = "No hay conexion a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = cnglobal;

                try
                {
                    contenedor = carrito.ExecuteReader();
                    mensaje = "Consulta Correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    mensaje = "Error!" + a.Message;
                }
            }
            return contenedor;
        }

        public Boolean MultiplesConsultasDataSet(string querySql, SqlConnection conAbierta, ref string mensaje, ref DataSet dataset1, string nomConsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;
            mensaje = AbrirConexion();
            if (cnglobal == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = cnglobal;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(dataset1, nomConsulta);
                    mensaje = "Consulta correcta en el DataSet";
                    salida = true;
                }
                catch (Exception a)
                {
                    mensaje = "Error: " + a.Message;
                }
                CerrarConexion();
            }
            return salida;
        }

    }
}
