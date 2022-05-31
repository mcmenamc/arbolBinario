using ClassEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassDAL
{
    public class ClassLista
    {
        private NodoLista Ancla = null;
        private int cuantaNodo = 0;

        public string Agregar(NodoLista nuevo)
        {
            string salida = "";
            NodoLista t = null;

            if(Ancla == null)
            {
                Ancla = nuevo;
                salida = "Se Inserto el primer Nodo";
            }
            else
            {
                t = Ancla;
                while(t.siguente != null){
                    t = t.siguente;
                }
                t.siguente = nuevo;
                salida = "Se inverto un nodo al final de la lista";
            }
            cuantaNodo++;
            return salida;
        }
        public Credencial[] MostrarLista()
        {
            Credencial[] resultados = new Credencial[cuantaNodo];

            NodoLista r1 = null;
            int c = 0;
            r1 = Ancla;

            while (r1 != null)
            {
                resultados[c] = r1.informacion;
                c++;
                r1 = r1.siguente;
            }
            return resultados;
        }
        public NodoLista Buscar(string curp)
        {
            NodoLista r1 = null;
            NodoLista piedrita = null;
            r1 = Ancla;
            while(r1 != null)
            {
                if(r1.informacion.Curp == curp)
                {
                    piedrita = r1;
                }
                r1 = r1.siguente;
            }
            return piedrita;
        }
        public NodoLista AnteriorParaBuscarEliminar(string curp)
        {
            NodoLista r1 = null;
            NodoLista Anterio = null;
            NodoLista AnteriorEncontrado = null;
            r1 = Ancla;
            Anterio = r1;
            while(r1 != null)
            {
                if(r1.informacion.Curp == curp)
                {
                    AnteriorEncontrado = Anterio;
                }
                Anterio = r1;
                r1 = r1.siguente;
            }
            return AnteriorEncontrado;
        }
        public string EliminarNodo(string curp)
        {
            NodoLista Encontrado = null;
            NodoLista Anterior = null;
            string Salida = "";
            Encontrado = Buscar(curp);
            if(Encontrado != null)
            {
                if(Encontrado == Ancla)
                {
                    Ancla = Encontrado.siguente;
                    Encontrado.siguente = null;
                    Salida = "Se elimino el primer elemento";
                }
                else
                {
                    Anterior = AnteriorParaBuscarEliminar(curp);
                    Anterior.siguente = Encontrado.siguente;
                    Encontrado.siguente = null;
                    Encontrado = null;
                    Salida = "Se elimino correctamente";
                }
                cuantaNodo--;
            }
            else
            {
                Salida = "No se encontro por que no existe";
            }
            return Salida;
        }
    }

}
