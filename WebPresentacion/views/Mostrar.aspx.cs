using System;
using ClassLogicaN;
using ClassEntidades;
using System.Collections.Generic;

namespace WebPresentacion.views
{
    public partial class Mostrar : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }

                List<Credencial> PreOrdenC = bl.ImprimePreOrden();
                PreOrden.DataSource = PreOrdenC;
                PreOrden.DataBind();

                List<Credencial> EntreOrdenC = bl.ImprimeInOrden();
                EntreOrden.DataSource = EntreOrdenC;
                EntreOrden.DataBind();

                List<Credencial> PostOrdenC = bl.ImprimePostOrden();
                PostOrden.DataSource = PostOrdenC;
                PostOrden.DataBind();

        }

    }
}