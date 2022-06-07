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

        private NodoLista Ancla;
        private List<Credencial> Credenciales;
        public ClassLista()
        {
            this.Ancla = null;  
        }
        public string Insertar(Credencial info)
        {
            NodoLista nuevo;
            nuevo = new NodoLista();
            nuevo.informacion = info;
            nuevo.izq = null;
            nuevo.der = null;
            int nivel = 0;
            string mensaje;
            if (this.Ancla == null)
            {
                this.Ancla = nuevo;
                mensaje = "Se inserto en la raíz como nivel -> " + nivel;
            }
            else
            {
                NodoLista anterior = null;
                NodoLista reco;
                reco = this.Ancla;
                while (reco != null)
                {
                    anterior = reco;
                    nivel++;
                    if (info.Curp.CompareTo(reco.informacion.Curp) < 0)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if(info.Curp == anterior.informacion.Curp)
                {
                    mensaje = "Credencial ya insertada anteriormente:v";
                }
                else
                {
                    if (info.Curp.CompareTo(anterior.informacion.Curp) < 0)
                    {
                        mensaje = "Se inserto a la Izquierda en la sub rama -> " + nivel;
                    }
                    else
                    {
                        anterior.der = nuevo;
                        mensaje = "Se inserto a la Derecha nivel ->  " + nivel;
                    }
                }
                
            }
            return mensaje;
        }
        private void PreOrden(NodoLista reco)
        {
            if (reco != null)
            {
                Credenciales.Add(reco.informacion);
                this.PreOrden(reco.izq);
                this.PreOrden(reco.der);
            }
        }
        public List<Credencial> PreOrden()
        {
            NodoLista r1 = null;
            r1 = this.Ancla;
            this.Credenciales = new List<Credencial>();
            this.PreOrden(r1);
            return this.Credenciales;
        }
        private void InOrden(NodoLista reco)
        {
            if (reco != null)
            {
                this.InOrden(reco.izq);
                Credenciales.Add(reco.informacion);
                this.InOrden(reco.der);
            }
        }
        public List<Credencial> InOrden()
        {
            NodoLista r1 = null;
            r1 = this.Ancla;
            this.Credenciales = new List<Credencial>();
            this.InOrden(r1);
            return this.Credenciales;
        }
        private void PostOrden(NodoLista reco)
        {
            if (reco != null)
            {
                this.PostOrden(reco.izq);
                this.PostOrden(reco.der);
                Credenciales.Add(reco.informacion);
            }
        }
        public List<Credencial> PostOrden()
        {
            NodoLista r1 = null;
            r1 = this.Ancla;
            this.Credenciales = new List<Credencial>();
            this.PostOrden(r1);
            return this.Credenciales;
        }

        public Credencial Buscar(string Curp)
        {
            NodoLista reco = null;
            reco = this.Ancla;
            while (reco != null)
            {
                if (Curp == reco.informacion.Curp)
                    return reco.informacion;
                else
                {
                    if (Curp.CompareTo(reco.informacion.Curp) > 0)
                        reco = reco.der;
                    else
                        reco = reco.izq;
                }
            }
            if(reco == null)
                return new Credencial();
            return reco.informacion;
        }

        private NodoLista BuscaMinimo(NodoLista t)
        {
            if (t == null)
                return (null); //si árbol vacío retorna NULL
            else // Si no es vacío
                if (t.izq == null)
                return (t); // Si no tiene hijo izquierdo: lo encontró.
            else
                return (BuscaMinimo(t.izq)); //busca en subárbol izquierdo.
        }
        private NodoLista MenorDescendiente(NodoLista t)
        {
            if (t == null)
                return null; // si el arbol esta vacío retorna null
            if (t.der == null)
                return null; // si no tiene hijos derechos no hay sucesor
            return (BuscaMinimo(t.der));

        }

        private NodoLista Eliminar(NodoLista nodo, string Curp)
        {
            NodoLista temp;
            if (nodo == null)
                return nodo;
            else if (Curp.CompareTo(nodo.informacion.Curp) < 0)
                nodo.izq = Eliminar(nodo.izq, Curp);
            else if(Curp.CompareTo(nodo.informacion.Curp) > 0)
                nodo.der = Eliminar(nodo.der, Curp);
            else// Se encontro el elemento a eliminar
            {
                if (nodo.izq != null && nodo.der != null) // dos hijos: remplazar con
                {
                    temp = this.MenorDescendiente(nodo.der);
                    nodo.informacion.Curp = temp.informacion.Curp;
                    nodo.der = this.Eliminar(nodo.der, temp.informacion.Curp);
                }
                else // un hijo o ninguno
                {
                    temp = nodo;
                    if (nodo.izq == null)
                        nodo = nodo.der;
                    else if (nodo.der == null)
                        nodo = nodo.izq;
                    temp = null; // liberar espacio
                }
            }
            return nodo;
        }

        public Credencial EliminarNodo(string Curp)
        {
            NodoLista r1;
            r1 = this.Ancla;
            return this.Eliminar(r1, Curp).informacion;
        }


        //    private NodoLista BuscarMin(NodoLista Arbol)
        //    {
        //        if (Arbol == null)
        //            return BuscarMin(null);
        //        else
        //        {
        //            if (Arbol.izq == null)
        //                return BuscarMin(null);
        //            else
        //                return BuscarMin(Arbol.izq);
        //        }
        //    }


        //    public string EliminarNodo(string Curp, NodoLista Arbol)
        //    {
        //        var celda_Temp = this.Ancla;
        //        string mensaje = "";
        //        if (Arbol == null)
        //            mensaje = "¡Elemento no encontrado!";
        //        else
        //        {
        //            if (Curp.CompareTo(Arbol.informacion.Curp) < 0)
        //                EliminarNodo(Curp, Arbol.izq);
        //            else
        //            {
        //                if(Curp.CompareTo(Arbol.informacion.Curp) > 0)
        //                    EliminarNodo(Curp, Arbol.der);
        //                else
        //                {
        //                    if (Arbol.izq != null)// duda
        //                    {
        //                        celda_Temp = Arbol;
        //                        Arbol = Arbol.der;
        //                        //GC.SuppressFinalize(celda_Temp);
        //                        celda_Temp = null;
        //                    }
        //                    else
        //                    {
        //                        if (Arbol.der == null)
        //                        {
        //                            celda_Temp = Arbol;
        //                            Arbol = Arbol.izq;
        //                            celda_Temp = null;
        //                        }
        //                        else
        //                        {
        //                            celda_Temp = 
        //                        }

        //                    }
        //                }


        //            }
        //        }
        //        return mensaje;
        //    }
    }
}
