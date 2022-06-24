using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Es la carga de la primera vez
                objacceso = new miClassAccesoSQL(System.Configuration.ConfigurationManager.ConnectionStrings["conlocal"].ConnectionString);
                Session["objAcc"] = objacceso;
            }
            else
            {
                //Vengo de un POSTBACK
                objacceso = (miClassAccesoSQL)Session["objAcc"];
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}