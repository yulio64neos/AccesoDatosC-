using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassAccesoSQL;

namespace WebPruebaAccesoDat
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //Pongo una referencia para no andar construyendo el new
        miClassAccesoSQL objacceso = null;
        DataSet contenedor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Es la carga de la primera vez
                objacceso = new miClassAccesoSQL(System.Configuration.ConfigurationManager.ConnectionStrings["conexionremotalocal"].ConnectionString);
                Session["objAcc"] = objacceso;
                contenedor = new DataSet();
                Session["contenedor"] = contenedor;
            }
            else
            {
                //Vengo de un POSTBACK
                objacceso = (miClassAccesoSQL)Session["objAcc"];
                contenedor = (DataSet)Session["contenedor"];
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet caja = null;
            string m = "";
            caja = objacceso.ConsultaDS("Select * from Profesor", ref m);
            TextBox1.Text = m;
            if (caja!= null)
            {
                GridView1.DataSource = caja.Tables[0];
                GridView1.DataBind();
            }
            objacceso.CerrarConexion();
        }

       

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView2.DataSource = contenedor.Tables[ListBox1.SelectedIndex];
            GridView2.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script> alert('Esto es un boton de prueba') </script>");
            string consulta = "";
            string m = "";
            ListBox1.Items.Clear();
            consulta = "select * from Profesor";
            if (objacceso.MultiplesConsultasDataSet(consulta, ref m, ref contenedor, "profesor"))
            {
                TextBox1.Text = m;
                ListBox1.Items.Add("profesor");
            }
            else
            {
                TextBox1.Text = "Error: " + m;
            }
            objacceso.CerrarConexion();
            consulta = "select * from EstadoCivil";
            if (objacceso.MultiplesConsultasDataSet(consulta, ref m, ref contenedor, "estadocivil"))
            {
                TextBox1.Text = m;
                ListBox1.Items.Add("Consulta Estado Civil");
            }
            else
            {
                TextBox1.Text = "Error: " + m;
            }
            objacceso.CerrarConexion();
            consulta = "select * from Medico";
            if (objacceso.MultiplesConsultasDataSet(consulta, ref m, ref contenedor, "medico"))
            {
                TextBox1.Text = m;
                ListBox1.Items.Add("Consulta Estado Medico");
            }
            else
            {
                TextBox1.Text = "Error: " + m;
            }
            objacceso.CerrarConexion();
            Session["contenedor"] = contenedor;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlParameter uno = new SqlParameter("dato", SqlDbType.VarChar, 50);
            uno.Value = TextBox2.Text;
            string inserta = "insert into EstadoCivil(Estado) " +
                "values(@dato);";
            string m = "";
            objacceso.ModificacionInsegura(inserta, ref m);
            objacceso.CerrarConexion();
            TextBox1.Text = m;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataSet atrapa = null;
            string h = "";
            atrapa = objacceso.ConsultaDS("SELECT * FROM EstadoCivil", ref h);
            objacceso.CerrarConexion();
            if(atrapa != null)
            {
                GridView2.DataSource = atrapa.Tables[0];
                GridView2.DataBind();
            }
            TextBox1.Text = h;
        }
    }
}