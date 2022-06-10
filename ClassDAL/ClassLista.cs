using ClassEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
                if(reco.informacion.Curp == nuevo.informacion.Curp)
                {
                    return "Credencial ya insertada anteriormente";
                }

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
                    mensaje = "Credencial ya insertada anteriormente";
                }
                else
                {
                    if (info.Curp.CompareTo(anterior.informacion.Curp) < 0)
                    {
                        anterior.izq = nuevo;
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
                return null; //si árbol vacío retorna NULL
            else // Si no es vacío
                if (t.izq == null)
                return (t); // Si no tiene hijo izquierdo: lo encontró.
            else
                return BuscaMinimo(t.izq); //busca en subárbol izquierdo.
        }
        private NodoLista MenorDescendiente(NodoLista t)
        {
            if (t == null)
                return null; // si el arbol esta vacío retorna null
            if (t.der == null)
                return null; // si no tiene hijos derechos no hay sucesor
            return (BuscaMinimo(t.der));
        }

        


        private List<Credencial> Amplitud(NodoLista NodoLista)
        {
            NodoLista reco;
            reco = NodoLista;
            Queue<NodoLista> queue = new Queue<NodoLista>();
            this.Credenciales = new List<Credencial>();

            if (reco != null)
            {
                queue.Enqueue(reco);
            }
            while (queue.Count > 0)
            {
                reco = queue.Dequeue();
                Credenciales.Add(reco.informacion);
                if (reco.izq != null)
                    queue.Enqueue(reco.izq);
                if (reco.der != null)
                    queue.Enqueue(reco.der);
            }
            return Credenciales;
        }

        public List<Credencial> Amplitud()
        {
            return Amplitud(this.Ancla);
        }

        //public string EliminarNodo(string Curp)
        //{
        //    string mensaje = "";
        //    NodoLista reco = null;
        //    reco = this.Ancla;
        //    NodoLista anterior = null;

        //    while (reco.informacion.Curp != Curp)
        //    {
        //        if (Curp.CompareTo(reco.informacion.Curp) < 0)
        //        {
        //            anterior = reco;
        //            reco = reco.izq;
        //        }
        //        else
        //        {
        //            if (Curp.CompareTo(reco.informacion.Curp)> 0)
        //            {
        //                anterior = reco;
        //                reco = reco.der;
        //            }
        //        }
        //        if (reco == null)
        //        {
        //            mensaje = "No Existe el nodo";
        //        }
        //    }
        //    if (reco.der == null)
        //    {
        //        if (anterior == null)
        //        {
        //            this.Ancla = reco.izq;
        //            mensaje = "Se elimino la raíz";
        //        }
        //        else
        //        {
        //            if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp)> 0)
        //            {
        //                anterior.izq = reco.izq;
        //                mensaje = "Se elimino el hijo izquierdo";
        //            }
        //            else
        //            {
        //                anterior.der = reco.izq;
        //                mensaje = "Se elimino el nodo";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (reco.der.izq == null)
        //        {
        //            reco.der.izq = reco.izq;

        //            if (anterior == null)
        //            {
        //                this.Ancla = reco.der;
        //                mensaje = "Se elimino el nodo";
        //            }
        //            else
        //            {
        //                //anterior.der = reco.der;
        //                //mensaje = "Se elimino cuando no tiene hijo izquierdo";
        //                if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp) > 0)
        //                {
        //                    anterior.izq = reco.der;
        //                    mensaje = "Se elimino";
        //                }
        //                else
        //                {
        //                    anterior.der = reco.der;
        //                    mensaje = "Se elimino el nodo";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            NodoLista nodoMin = reco.der.izq;
        //            NodoLista anteriorMin = reco.der;

        //            while (nodoMin.izq != null)
        //            {
        //                anteriorMin = nodoMin;
        //                nodoMin = nodoMin.izq;
        //            }

        //            anteriorMin.izq = nodoMin.der;
        //            nodoMin.izq = anteriorMin.izq;
        //            nodoMin.der = anteriorMin.der;

        //            if (anterior == null)
        //            {
        //                this.Ancla = nodoMin;
        //                mensaje = "Se elimino el nodo Ancla";
        //            }
        //            else
        //            {
        //                if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp) < 0)
        //                {
        //                    anterior.der = nodoMin;
        //                    mensaje = "Se elimno el nodo";
        //                }
        //            }
        //        }
        //    }
        //    return mensaje;
        //}

        //private NodoLista Eliminar(NodoLista nodo, string Curp)
        //{
        //    if (nodo == null)
        //        return nodo;

        //     if (Curp.CompareTo(nodo.informacion.Curp) < 0)
        //        nodo.izq = Eliminar(nodo.izq, Curp);

        //    else if (Curp.CompareTo(nodo.informacion.Curp) > 0)
        //        nodo.der = Eliminar(nodo.der, Curp);
        //    else// Se encontro el elemento a eliminar
        //    {
        //        if (nodo.izq == null) // dos hijos: remplazar con
        //        {
        //            NodoLista temp = nodo.der;
        //            // falta liberar espacio
        //            temp = null;
        //            return temp;
        //        }
        //        else if(nodo.der == null)// un hijo o ninguno
        //        {
        //            NodoLista temp = nodo.izq;
        //            // falta liberar espacio
        //            temp = null;
        //            return temp;
        //        }
        //        NodoLista temp2 = BuscaMinimo(nodo.der);
        //        nodo.informacion.Curp = temp2.informacion.Curp;
        //        nodo.der = this.Eliminar(nodo.izq, temp2.informacion.Curp);

        //    }
        //     return nodo;
        //}

        private NodoLista Eliminar(NodoLista nodo, string Curp)
        {
            NodoLista temp;
            if (nodo == null)
                return nodo;
            else if (Curp.CompareTo(nodo.informacion.Curp) < 0)
                nodo.izq = Eliminar(nodo.izq, Curp);
            else if (Curp.CompareTo(nodo.informacion.Curp) > 0)
                nodo.der = Eliminar(nodo.der, Curp);
            else// Se encontro el elemento a eliminar
            {
                if (nodo.izq != null && nodo.der != null) // dos hijos: remplazar con
                {
                    temp = this.MenorDescendiente(nodo.der);
                    nodo.informacion = temp.informacion;
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

        public void EliminarNodo(string Curp)
        {
            
            this.Eliminar(this.Ancla, Curp);
        }

        //public NodoLista BuscarPadre(string Curp, NodoLista nodo)
        //{
        //    NodoLista temp = null;

        //    if (nodo == null)
        //        return null;

        //    if (nodo.izq != null)
        //    {
        //        if (nodo.izq.informacion.Curp == Curp)
        //            return nodo;
        //    }

        //    if (nodo.der != null)
        //    {
        //        if (nodo.der.informacion.Curp == Curp)
        //            return nodo;
        //    }

        //    if (nodo.izq != null && Curp.CompareTo(nodo.informacion.Curp) < 0)
        //        temp = BuscarPadre(Curp, nodo.izq);

        //    if (nodo.der != null && Curp.CompareTo(nodo.informacion.Curp) > 0)
        //        temp = BuscarPadre(Curp, nodo.der);

        //    return temp;
        //}


        //private NodoLista borrar3(NodoLista nodo, string curp)
        //{
        //    if (nodo == null)
        //        return nodo;
            
        //    if(curp.CompareTo(nodo.informacion.Curp) < 0)
        //        nodo.izq = borrar3(nodo.izq,curp);
        //    else
        //    {
        //        if(curp.CompareTo(nodo.informacion.Curp) > 0)
        //            nodo.der = borrar3(nodo.der, curp);
        //        else
        //        {
        //            // casos sin hijos
        //            if (nodo.izq == null && nodo.der == null)
        //            {
        //                nodo = null;
        //                return nodo;
        //            }

        //            else if(nodo.izq == null)
        //            {
        //                NodoLista padre = this.BuscarPadre(curp, nodo);
        //                padre.der = nodo.der;
        //                return nodo;
        //            }
        //            else
        //            {
        //                NodoLista minimo = BuscaMinimo(nodo.der);
        //                nodo.informacion = minimo.informacion;
        //                nodo.der = borrar3(nodo.der, minimo.informacion.Curp);
        //            }
        //        }
        //    }
        //    return nodo;
        //}
        //public void borrar3(string Curp)
        //{
        //    borrar3(this.Ancla, Curp);
        //}
       
    }
}
