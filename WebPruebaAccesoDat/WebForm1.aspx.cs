using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient; //Proveedor de sql
using System.Data; //Usar el dataset y todos sus objetos

namespace WebPruebaAccesoDat
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDatos_Click(object sender, EventArgs e)
        {
            using (SqlConnection camino = new SqlConnection())
            {
                camino.ConnectionString = System.Configuration.ConfigurationManager.
                    ConnectionStrings["conlocal"].ConnectionString;
                try
                {
                    camino.Open();
                    TextBox1.Text = "Conexión establecida correctamente";
                }
                catch (Exception a)
                {
                    TextBox1.Text = "BUGASO: " + a.Message;
                }
            }
        }

        protected void btnProfe_Click(object sender, EventArgs e)
        {
            SqlCommand bocho = null;
            using (SqlConnection camino = new SqlConnection())
            {
                camino.ConnectionString = System.Configuration.ConfigurationManager.
                    ConnectionStrings["conlocal"].ConnectionString;
                try
                {
                    camino.Open();
                    bocho = new SqlCommand();
                    bocho.CommandText = "Insert Into Profesor(RegistroEmpleado, Nombre, Ap_pat, Ap_mat, Genero, Categoria, F_edoCivil)" +
                        "values(245, 'Pedro', 'Martinez', 'Galaviz', 'Masculino', 'PTC', 1);";
                    TextBox1.Text = "Conexión establecida correctamente";
                    //bocho.CommandText = "Insert Into EstadoCivil( Estado, Extra) values ('Soltero', 'Chido')";
                    bocho.Connection = camino;
                    bocho.ExecuteNonQuery();
                    TextBox1.Text = "Inserción correcta";
                }
                catch (Exception a)
                {
                    TextBox1.Text = "NELSON: " + a.Message;
                }
            }
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            SqlCommand bocho = null;
            SqlDataReader cajita = null;
            using (SqlConnection camino = new SqlConnection())
            {
                camino.ConnectionString = System.Configuration.ConfigurationManager.
                    ConnectionStrings["conlocal"].ConnectionString;
                try
                {
                    camino.Open();
                    bocho = new SqlCommand();
                    bocho.CommandText = "select * from Profesor";
                    bocho.Connection = camino;
                    cajita = bocho.ExecuteReader();
                    TextBox1.Text = "Consulta correcta";
                    //Recorrido de los datos
                    ListBox1.Items.Clear();
                    if (cajita.HasRows)
                    {
                        while (cajita.Read())
                        {
                            ListBox1.Items.Add(
                                cajita[0].ToString() + " " + 
                                cajita[1].ToString() + " " + 
                                cajita[2].ToString() + " " + 
                                cajita[3].ToString() + " " + 
                                cajita[4].ToString());
                        }
                    }
                    else
                    {
                        TextBox2.Text = "La consulta fue correcta pero no hay datos WUUUUUUUUUUUUUUU";
                    }
                }
                catch (Exception a)
                {
                    TextBox2.Text = "NELSON: " + a.Message;
                }
            }
        }

        protected void btnDataSet_Click(object sender, EventArgs e)
        {
            SqlCommand bocho = null;
            SqlDataAdapter trailer = null;
            DataSet cajota = null;
            using (SqlConnection camino = new SqlConnection())
            {
                camino.ConnectionString = System.Configuration.ConfigurationManager.
                    ConnectionStrings["conlocal"].ConnectionString;
                try
                {
                    camino.Open();
                    bocho = new SqlCommand();
                    bocho.CommandText = "select * from Profesor";
                    bocho.Connection = camino;
                    trailer = new SqlDataAdapter();
                    cajota = new DataSet();
                    trailer.SelectCommand = bocho;
                    trailer.Fill(cajota);
                    TextBox2.Text = "Consulta correcta en DS";
                    camino.Close();
                    //Recorrido de los datos
                    if (cajota != null)
                    {
                        GridView1.DataSource = cajota.Tables[0];
                        GridView1.DataBind();
                    }
                }
                catch (Exception a)
                {
                    TextBox2.Text = "NELSON: " + a.Message;
                }
            }
        }
    }
}