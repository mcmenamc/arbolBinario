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
        public NodoLista siguente = null;


        public NodoLista(Credencial objnuevo)
        {
            informacion = objnuevo;
            siguente = null;
        }
    }
}
