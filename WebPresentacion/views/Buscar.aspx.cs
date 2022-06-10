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
            card.Visible = false;
            Al.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Credencial Credencial = bl.Buscar(TextBox1.Text);

            if(Credencial.Curp != null)
            {
                card.Visible = true;
                Curp.Text = Credencial.Curp;
                Nombre.Text = Credencial.Nombre;
                Domicilio.Text = Credencial.Domicilio;
                Estado.Text = Credencial.Estado;
                Municipio.Text = Credencial.Municipio;
                Seccion.Text = Credencial.Seccion.ToString();
                Vigencia.Text = Credencial.Vigencia.ToString();
            }
            else
            {
                Al.Visible = true;
                Alerta.Text = "No se encontro ningun elemento";
            }
        }
    }
}