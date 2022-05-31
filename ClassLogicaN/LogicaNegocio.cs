using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassEntidades;
using ClassDAL;

namespace ClassLogicaN
{
    public class LogicaNegocio
    {
        private ClassLista objDAL = new ClassLista();

        public string InsertarCredencial(NodoLista nuevo)
        {
            return objDAL.Agregar(nuevo);
        }
        public Credencial[] MostrarCredencial()
        {
            return objDAL.MostrarLista();
        }
       
        public string BuscarCredencial(string curp)
        {
            string salida = "";
            NodoLista piedra = null;
            piedra = objDAL.Buscar(curp);
            if(piedra == null)
            {
                salida = "No se encontro con la credencial";
            }
            else
            {
                salida = "Credencial:" + piedra.informacion.Mostrar();
            }
            return salida;
        }
        public string EliminarCredencial(string curp)
        {
            return objDAL.EliminarNodo(curp);
        }
    }   
}
