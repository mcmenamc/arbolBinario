using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;

namespace WebPresentacion
{
    public partial class Graficador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap imagen1 = new Bitmap(1290, 1080);

            Graphics hoja = Graphics.FromImage(imagen1);
            Dibuja(hoja, imagen1.Width, imagen1.Height);


            Response.ContentType = "image/jpeg";
            imagen1.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        }
        public void Dibuja(Graphics papel, int dimx, int dimy)
        {

            var Credenciales = new[]
            {
                new {
                Curp = "dwwwdwwd",
                Nombre = "Jesús Antonio Mena De la rosa",
                Domicilio = "102 Poniente",
                Estado = "Puebla",
                Municipio= "Puebla",
                Seccion = 082,
                Vigencia = 2028
                },
                new {
                Curp = "MERJE001001HPLNSSA0",
                Nombre = "Jesús Antonio Mena De la rosa",
                Domicilio = "102 Poniente",
                Estado = "Puebla",
                Municipio= "Puebla",
                Seccion = 082,
                Vigencia = 2028
                }
            };





            papel.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(0, 0, dimx, dimy)); // fondo de mi imagen

            
            Pen lapiz = new Pen(Color.FromArgb(244, 217, 255), 1); // lapiz
            Color Rosa = Color.FromArgb(244, 217, 255);
            SolidBrush Brocha = new SolidBrush(Color.Black); // Brocha Verde 
            Font Times = new Font("Times", 8); // tipografia 

            int AnchoRectangulo = 200;
            int AltoRectangulo = 85;
            int AltoMargen = 20;
            int x = dimx / 2 - 100;

            // Recuadro de Credencial
            papel.FillRectangle(new SolidBrush(Rosa), new Rectangle(x, AltoMargen, AnchoRectangulo, AltoRectangulo));
            // Curp
            //papel.DrawString("Curp: " + Credenciales[0].Curp, Times, Brocha, new RectangleF(x, AltoMargen + 5, AnchoRectangulo, AltoRectangulo));
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

       

            string[,] arr = new string[3, 2] { { "one", "two" }, { "three", "four" }, { "five", "six" } };


            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    papel.DrawString("Curp: " + arr[i,j], Times, Brocha, new RectangleF(x, AltoMargen + 5, AnchoRectangulo, AltoRectangulo));
                    AltoMargen = AltoMargen +50;

                }
            }


        }

    }
}