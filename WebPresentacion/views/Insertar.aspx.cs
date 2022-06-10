using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaN;
using ClassEntidades;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebPresentacion
{
    public partial class Insertar : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }


            Alerta.Text = "";
            Al.Visible = false;


            //Response.Write("Curp: " + Request.Form["TxtCurp"]);
            //Response.Write("<br> Nombre: "+ Request.Form["TxtNombre"]);
            ////Response.Write("<br> Estado: " + Request.Form["DropEstados"]);
            ////Response.Write("<br> Municipio: " + Request.Form["DropMunicipios"]);
            //Response.Write("<br> Domicilio: " + Request.Form["TxtDomicilio"]);
            //Response.Write("<br> Sección: " + Request.Form["TxtSeccion"]);
            //Response.Write("<br> Vigencia: " + Request.Form["TxtVigencia"]);
            //Response.Write("<br> Credencial" + Request.Form["BtnCredencial"]);
            //Response.Write("<br> sssssTxtDomicilio: " + Request.Form["TxtEstado"]);
            //Response.Write("<br> sssssTxtMunicipio: " + Request.Form["TxtMunicipio"]);


            if (Request.HttpMethod == "POST")
            {
                try
                {
                    Alerta.Text = bl.InsertarCredencial(new ClassEntidades.Credencial()
                    {
                        Curp = Request.Form["TxtCurp"],
                        Domicilio = Request.Form["TxtDomicilio"],
                        Estado = Request.Form["TxtEstado"],
                        Municipio = Request.Form["TxtMunicipio"],
                        Nombre = Request.Form["TxtNombre"],
                        Seccion = Convert.ToInt32(Request.Form["TxtSeccion"]),
                        Vigencia = Convert.ToInt32(Request.Form["TxtVigencia"]),
                    });

                    Session["bl"] = bl;
                    this.GurdarArchivo();
                }
                catch (Exception ex)
                {
                    Alerta.Text = ex.Message;
                }
                Al.Visible = true;
            }
        }

        public void GurdarArchivo()
        {
            string path = Server.MapPath(Request.ApplicationPath) + "Catalogues/recuperacion.json";

            List<Credencial> Credenciales = bl.Amplitud();

            string json = JsonConvert.SerializeObject(Credenciales);
            System.IO.File.WriteAllText(path, json);
        }
    }
}