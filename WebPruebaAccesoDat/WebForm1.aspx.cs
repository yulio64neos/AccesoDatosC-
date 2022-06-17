using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
                        "values(245, 'Pedro', 'Martinez', 'Galaviz', 'Masculino', 'PTC', 12);";
                    TextBox1.Text = "Conexión establecida correctamente";
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
    }
}