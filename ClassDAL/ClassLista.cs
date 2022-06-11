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
            int nivel = 1;
            string mensaje = "";
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
                    else if(info.Curp.CompareTo(reco.informacion.Curp) > 0)
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
                    else if(info.Curp.CompareTo(anterior.informacion.Curp) > 0)
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
        private List<Credencial> Amplitud(NodoLista NodoLista)
        {
            NodoLista reco;
            reco = NodoLista;
            Queue<NodoLista> queue = new Queue<NodoLista>();
            this.Credenciales = new List<Credencial>();
            if (reco != null)
                queue.Enqueue(reco);
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
        private void casoultimo(NodoLista nodoMenor, NodoLista padreNodoMenor, NodoLista reco, NodoLista anterior)
        {
            while (nodoMenor.izq != null)
            {
                padreNodoMenor = nodoMenor;
                nodoMenor = nodoMenor.izq;
            }
            padreNodoMenor.izq = nodoMenor.der;
            nodoMenor.izq = reco.izq;
            nodoMenor.der = reco.der;
            if (anterior == null)
                this.Ancla = nodoMenor;
            else
                if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp) > 0)
                    anterior.izq = nodoMenor;
                else
                    if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp) < 0)
                        anterior.der = nodoMenor;
        }
        private void caso2(NodoLista reco, NodoLista anterior, NodoLista nodoMenor, NodoLista padreNodoMenor)
        {
            if (reco.der.izq == null)
            {
                reco.der.izq = reco.izq;
                if (anterior == null)
                    this.Ancla = reco.der;
                else if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp) > 0)
                        anterior.izq = reco.der;
                    else
                        anterior.der = reco.der;
            }
            else
            {
                nodoMenor = reco.der.izq;
                padreNodoMenor = reco.der;
                this.casoultimo(nodoMenor, padreNodoMenor, reco, anterior);
            }
        }
        public void eliminados(string curp)
        {
            NodoLista reco = null;
            reco = this.Ancla;
            NodoLista anterior = null;
            NodoLista nodoMenor = null;
            NodoLista padreNodoMenor = null;
            while (reco.informacion.Curp != curp) {
                if (curp.CompareTo(reco.informacion.Curp) < 0)
                {
                    anterior = reco;
                    reco = reco.izq;
                }
                else
                {
                    anterior = reco;
                    reco = reco.der;
                }
            }
            if (reco.der == null)
            {
                if (anterior == null)
                    this.Ancla = reco.izq;
                else
                {
                    if (anterior.informacion.Curp.CompareTo(reco.informacion.Curp) > 0)
                        anterior.izq = reco.izq;
                    else
                        anterior.der = reco.izq;
                }
            }
            else
                this.caso2(reco, anterior,nodoMenor, padreNodoMenor);
        }
    }
}
