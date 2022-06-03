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
            ListBox1.Items.Clear();
            
            var Credenciales = bl.ImprimePreOrden();
            foreach (Credencial credencial in Credenciales) {
                if(credencial != null)
                    ListBox1.Items.Add(credencial.Curp);
            }
            var CredencialesP = bl.ImprimeInOrden();
            foreach (Credencial credencial in CredencialesP)
            {
                if (credencial != null)
                    ListBox2.Items.Add(credencial.Curp);
            }
            var Credenciales2 = bl.ImprimePostOrden();
            foreach (Credencial credencial in Credenciales2)
            {
                if (credencial != null)
                    ListBox3.Items.Add(credencial.Curp);
            }

        }
        //public Credencial[] credenciales()
        //{
        //    return bl.MostrarCredencial();
        //}

    }
}