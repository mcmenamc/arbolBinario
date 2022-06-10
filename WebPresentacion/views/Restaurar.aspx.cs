using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassEntidades;
using Newtonsoft.Json;
using ClassLogicaN;
using System.Data;

namespace WebPresentacion.views
{
    public partial class Recuperar : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();
        List<Credencial> recuperado = new List<Credencial>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }
            Alerta.Text = "";
            Al.Visible = false;
            RestaurarAutomatic1.Visible = false;
            string pathDefault = Server.MapPath(Request.ApplicationPath) + "Catalogues/recuperacion.json";
            recuperado = this.LeerArchivo(pathDefault);
            if (recuperado != null)
            {
                Alerta.Text = "¡Se encontro un archivo de restauración por defecto! ¿Quieres verlo?";
                Al.Visible = true;
            }
        }
        protected void VerTabla(object sender, EventArgs e)
        {
            GridView1.DataSource = recuperado;
            GridView1.DataBind();
            Alerta.Text = "¿Quieres restaurar los datos de la tablas?";
            VerTabla1.Visible = false;
            RestaurarAutomatic1.Visible = true;
        }
        protected void RestaurarAutomatic(object sender, EventArgs e)
        {
            this.Restaurar(recuperado);
            grid.Visible = false;
            Alerta.Text = "Se Restauro correctamente";
        }
        public List<Credencial> LeerArchivo(string path)
        {
            try
            {
                StreamReader r = new StreamReader(path);
                string json = r.ReadToEnd();
                List<Credencial> Credenciales = JsonConvert.DeserializeObject<List<Credencial>>(json);
                return Credenciales;
            }
            catch (Exception Ex)
            {
                return null;
            }
        }
        public void Restaurar(List<Credencial> Credenciales)
        {
            foreach (Credencial credencial in Credenciales)
            {
                bl.InsertarCredencial(credencial);
            }
            Session["bl"] = bl;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Restaurar(recuperado);
        }
        protected void RestaurarFileDynamic(object sender, EventArgs e)
        {
            
            string cadenaAleatoria = string.Empty;
            cadenaAleatoria = Guid.NewGuid().ToString();
            if (FileUpload1.HasFile)
            {
                string[] name = FileUpload1.FileName.Split('.');
                if (name[1] != "json")
                {
                    Al.Visible = true;
                    Alerta.Text = "No Adminimos Archivos que no sean .json";
                    VerTabla1.Visible = false;
                }
                else
                {
                    string nombre = Server.MapPath(Request.ApplicationPath + "Catalogues/" + cadenaAleatoria + ".json");
                    FileUpload1.SaveAs(nombre);
                    List<Credencial> Credenciales = this.LeerArchivo(nombre);
                    this.Restaurar(Credenciales);
                }
                
            }
        }

        protected void Backup_Click(object sender, EventArgs e)
        {
        }
    }
}