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
        public string InsertarCredencial(Credencial nuevo)
        {
            return objDAL.Insertar(nuevo);
        }
        public List<Credencial> ImprimePreOrden()
        {
            return objDAL.PreOrden();
        }
        public List<Credencial> ImprimeInOrden()
        {
            return objDAL.InOrden();
        }
        public List<Credencial> ImprimePostOrden()
        {
            return objDAL.PostOrden();
        }
        public Credencial Buscar(string Curp)
        {
            return objDAL.Buscar(Curp);
        }
        public void Eliminar(string Curp)
        {
            objDAL.eliminados(Curp);
        }
        public List<Credencial> Amplitud()
        {
            return objDAL.Amplitud();
        }
    }   
}
