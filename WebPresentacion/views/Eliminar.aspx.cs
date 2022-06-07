using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaN;
using ClassEntidades;

namespace WebPresentacion.views
{
    public partial class Eliminar : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = bl.Eliminar(TextBox1.Text).Mostrar();
        }
    }
}