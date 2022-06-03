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
    public partial class Buscar : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }
            string Curp = "MERJE001HPLNSSA5";

            Response.Write(bl.Buscar(Curp).Mostrar());
        }
    }
}