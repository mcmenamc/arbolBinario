using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using ClassLogicaN;
using ClassEntidades;

namespace WebPresentacion
{
    public partial class Graficador : System.Web.UI.Page
    {
        LogicaNegocio bl = new LogicaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["bl"] != null)
            {
                bl = (LogicaNegocio)Session["bl"];
            }

            Bitmap imagen1 = new Bitmap(1290, 1080);

            Graphics hoja = Graphics.FromImage(imagen1);
            Dibuja(hoja, imagen1.Width, imagen1.Height);

            Response.ContentType = "image/jpeg";
            imagen1.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        }
        public void Dibuja(Graphics papel, int dimx, int dimy)
        {

            Pen lapiz = new Pen(Color.FromArgb(244, 217, 255), 1); // lapiz
            Color Rosa = Color.FromArgb(244, 217, 255);
            SolidBrush Brocha = new SolidBrush(Color.Black); // Brocha Verde 
            Font Times = new Font("Times", 8); // tipografia 

            papel.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(0, 0, dimx, dimy)); // fondo de mi imagen

            List<Credencial> EntreOrden = new List<Credencial>();
            List<Credencial> PreOrden = new List<Credencial>();
            EntreOrden = bl.ImprimePreOrden();
            EntreOrden.Add(new Credencial { Curp = ""});
            PreOrden = bl.ImprimeInOrden();




            if (EntreOrden.Count > 0)
            {

                int xRectangulo = dimx / EntreOrden.Count;
                int yRectangulo = dimy / EntreOrden.Count;

                int posix = 0;
                int posiy = 0;

                foreach (Credencial credencial in EntreOrden)
                {
                    papel.FillRectangle(new SolidBrush(Rosa), new Rectangle(posix, posiy, xRectangulo, yRectangulo));
                    papel.DrawString(credencial.Curp, Times, Brocha, new Rectangle(posix, posiy, xRectangulo, yRectangulo));

                    posix = posix + xRectangulo;
                    posiy = posiy + yRectangulo;

                }
                
            }






            //int AnchoRectangulo = 200;
            //int AltoRectangulo = 85;
            //int AltoMargen = 20;
            //int x = dimx / 2 - 100;

            // Recuadro de Credencial
            //papel.FillRectangle(new SolidBrush(Rosa), new Rectangle(x, AltoMargen, AnchoRectangulo, AltoRectangulo));
            // Curp
            //papel.DrawString("Curp: " + count, Times, Brocha, new RectangleF(x, AltoMargen + 5, AnchoRectangulo, AltoRectangulo));
            ////Nombre
            //papel.DrawString("Nombre: " + Credenciales[0].Nombre, Times, Brocha, new RectangleF(x, AltoMargen + 20, AnchoRectangulo, AltoRectangulo));
            ////Domicilio
            //papel.DrawString("Domicilio" + Credenciales[0].Domicilio, Times, Brocha, new RectangleF(x, AltoMargen + 35 , AnchoRectangulo, AltoRectangulo));
            ////Estado
            //papel.DrawString("Estado" + Credenciales[0].Estado, Times, Brocha, new RectangleF(x, AltoMargen + 50, AnchoRectangulo, AltoRectangulo));
            ////Municipio
            //papel.DrawString("Municipio" + Credenciales[0].Municipio, Times, Brocha, new RectangleF(x, AltoMargen + 65, AnchoRectangulo, AltoRectangulo));
            ////Sección
            //papel.DrawString("Sección" + Credenciales[0].Seccion.ToString(), Times, Brocha, new RectangleF(x + 125, AltoMargen + 50, AnchoRectangulo, AltoRectangulo));
            ////Vigencia
            //papel.DrawString("Vigencia" + Credenciales[0].Vigencia.ToString(), Times, Brocha, new RectangleF(x + 125, AltoMargen + 65, AnchoRectangulo, AltoRectangulo));
            
        }   

    }
}