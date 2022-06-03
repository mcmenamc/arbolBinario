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
                    if(info.Curp.CompareTo(reco.informacion.Curp) < 0)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
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
            return mensaje;
        }
        private void PreOrden(NodoLista reco)
        {
            if(reco != null)
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
                    {
                        reco = reco.der;
                    }
                    else
                    {
                        reco = reco.izq;
                    }
                }
            }
            return null;
        }
    }

}
