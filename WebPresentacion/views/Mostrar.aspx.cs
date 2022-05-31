using System;
using ClassLogicaN;
using ClassEntidades;

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
            //ListBox1.Items.Clear();

            //Credencial[] credenciales = bl.MostrarCredencial();
            //foreach (Credencial credencial in credenciales)
            //{
            //    ListBox1.Items.Add(credencial.Mostrar());
            //}

            
        }
        public Credencial[] credenciales()
        {
            return bl.MostrarCredencial();
        }
        
    }
}