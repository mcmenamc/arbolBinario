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
        private int cuantaNodo = 0;
        
        public ClassLista()
        {
            Ancla = null;
        }

        public string Insertar(Credencial info)
        {
            NodoLista nuevo;
            nuevo = new NodoLista();
            nuevo.informacion = info;
            nuevo.izq = null;
            nuevo.der = null;
            string mensaje;
            if (this.Ancla == null)
            {
                this.Ancla = nuevo;
                mensaje = "Cabeza "+ this.Ancla.informacion.Mostrar();
            }
            else
            {
                NodoLista anterior = null, reco;
                reco = this.Ancla;
                while (reco != null)
                {
                    anterior = reco;
                    if(info.Curp.Length < reco.informacion.Curp.Length)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (info.Curp.Length < anterior.informacion.Curp.Length)
                {
                    anterior.izq = nuevo;
                    mensaje = "izquierda" + nuevo.informacion.Mostrar();
                }
                else
                {
                    anterior.der = nuevo;
                    mensaje = "Derechca " + nuevo.informacion.Mostrar();
                }
                    
            }
            cuantaNodo++;
            return mensaje;
        }
        private Credencial ImprimePre(NodoLista reco)
        {
            Credencial nodoLista = null;
            if(reco != null)
            {
                nodoLista = reco.informacion;
                this.ImprimePre(reco.izq);
                this.ImprimePre(reco.der);
            }
            return nodoLista;
        }

        public Credencial[] imprimePre()
        {
            Credencial[] resultados = new Credencial[cuantaNodo];

            int c = 0;
            NodoLista r1 = null;
            r1 = this.Ancla;
            while (c < cuantaNodo){
                resultados[c] = this.ImprimePre(r1);
                c++;
            }
            return resultados;
        }

        
        //public Credencial[] MostrarLista()
        //{
        //    Credencial[] resultados = new Credencial[cuantaNodo];

        //    NodoLista r1 = null;
        //    int c = 0;
        //    r1 = Ancla;

        //    while (r1 != null)
        //    {
        //        resultados[c] = r1.informacion;
        //        c++;
        //        r1 = r1.siguente;
        //    }
        //    return resultados;
        //}
        //public NodoLista Buscar(string curp)
        //{
        //    NodoLista r1 = null;
        //    NodoLista piedrita = null;
        //    r1 = Ancla;
        //    while(r1 != null)
        //    {
        //        if(r1.informacion.Curp == curp)
        //        {
        //            piedrita = r1;
        //        }
        //        r1 = r1.siguente;
        //    }
        //    return piedrita;
        //}
        //public NodoLista AnteriorParaBuscarEliminar(string curp)
        //{
        //    NodoLista r1 = null;
        //    NodoLista Anterio = null;
        //    NodoLista AnteriorEncontrado = null;
        //    r1 = Ancla;
        //    Anterio = r1;
        //    while(r1 != null)
        //    {
        //        if(r1.informacion.Curp == curp)
        //        {
        //            AnteriorEncontrado = Anterio;
        //        }
        //        Anterio = r1;
        //        r1 = r1.siguente;
        //    }
        //    return AnteriorEncontrado;
        //}
        //public string EliminarNodo(string curp)
        //{
        //    NodoLista Encontrado = null;
        //    NodoLista Anterior = null;
        //    string Salida = "";
        //    Encontrado = Buscar(curp);
        //    if(Encontrado != null)
        //    {
        //        if(Encontrado == Ancla)
        //        {
        //            Ancla = Encontrado.siguente;
        //            Encontrado.siguente = null;
        //            Salida = "Se elimino el primer elemento";
        //        }
        //        else
        //        {
        //            Anterior = AnteriorParaBuscarEliminar(curp);
        //            Anterior.siguente = Encontrado.siguente;
        //            Encontrado.siguente = null;
        //            Encontrado = null;
        //            Salida = "Se elimino correctamente";
        //        }
        //        cuantaNodo--;
        //    }
        //    else
        //    {
        //        Salida = "No se encontro por que no existe";
        //    }
        //    return Salida;
        //}
    }

}
