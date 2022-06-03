using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaN;
using ClassEntidades;

namespace WebPresentacion
{
    public partial class Insertar : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Alerta.Text = "";
            Al.Visible = false;
            DropEstados.Items.Clear();
            DropEstados.Items.Add("");

            DropMunicipios.Items.Clear();
            DropMunicipios.Items.Add("");

            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }
            if(Request.HttpMethod == "POST")
            {
                Response.Write(Request.Form[""]);
                try
                {
                    Alerta.Text = bl.InsertarCredencial(new ClassEntidades.Credencial()
                    {
                        Curp = TxtCurp.Value,
                        Domicilio = TxtDomicilio.Value,
                        Estado = DropEstados.Value,
                        Municipio = DropMunicipios.Value,
                        Nombre = TxtNombre.Value,
                        Seccion = Convert.ToInt32(TxtSeccion.Value),
                        Vigencia = Convert.ToInt32(TxtVigencia.Value),
                    });
                    Session["bl"] = bl;
                    TxtCurp.Value = "";
                    TxtDomicilio.Value = "";
                    TxtNombre.Value = "";
                    DropEstados.SelectedIndex = 0;
                    DropMunicipios.SelectedIndex = 0;
                    TxtSeccion.Value = "";
                    TxtVigencia.Value = "";
                }
                catch (Exception ex)
                {
                    Alerta.Text = ex.Message;
                }
                Al.Visible = true;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}