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
            papel.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, dimx, dimy)); // fondo de mi imagen


            Pen lapiz = new Pen(Color.FromArgb(244, 217, 255), 1); // lapiz
            Color Rosa = Color.FromArgb(244, 217, 255);
            SolidBrush Brocha = new SolidBrush(Color.Black); // Brocha Verde 
            Font Times = new Font("Times", 8); // tipografia 

            int AnchoRectangulo = 200;
            int AltoRectangulo = 85;
            int AltoMargen = 20;
            
            // Recuadro de Credencial
            
            papel.FillRectangle(new SolidBrush(Rosa), new Rectangle((dimx/2) - (AnchoRectangulo / 2), AltoMargen, AnchoRectangulo, AltoRectangulo )); 

            // Imprime Curp
            papel.DrawString("Curp: MERJE001001HPLNSSA0", Times, Brocha, ((dimx/2)- (AnchoRectangulo / 2)), AltoMargen + 5);
            // Imprime  Nombre
            papel.DrawString("Nombre: Jesús Antonio Mena De la rosa", Times, Brocha, ((dimx / 2) - (AnchoRectangulo / 2)), AltoMargen + 20);
            // Imprime Domicilio
            papel.DrawString("Domicilio: 102 Poniente", Times, Brocha, ((dimx / 2) - (AnchoRectangulo / 2)), AltoMargen + 35);
            //imprime Estado
            papel.DrawString("Estado: Puebla", Times, Brocha, ((dimx / 2) - (AnchoRectangulo / 2)), AltoMargen + 50);
            //Imprime Municipio
            papel.DrawString("Municipio: Puebla", Times, Brocha, ((dimx / 2) - (AnchoRectangulo / 2) + 100), AltoMargen + 50);
            // Imprime Sección 
            papel.DrawString("Sección: 003", Times, Brocha, ((dimx / 2) - (AnchoRectangulo / 2)), AltoMargen + 65);
            // Imprime Vigencia 
            papel.DrawString("Vigencia: 2025", Times, Brocha, ((dimx / 2) - (AnchoRectangulo / 2) + 100), AltoMargen + 65);



        }
    }
}