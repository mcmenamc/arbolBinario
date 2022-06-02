using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class NodoLista
    {
        public Credencial informacion;
        public NodoLista der = null;
        public NodoLista izq = null;

        //public NodoLista(Credencial objnuevo)
        //{
        //    informacion = objnuevo;
        //    der = null;
        //    izq = null;
        //}
    }
}
