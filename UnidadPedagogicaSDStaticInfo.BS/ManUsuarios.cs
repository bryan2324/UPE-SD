using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UnidadPedagogicaSDStaticInfo.DAL;

namespace UnidadPedagogicaSDStaticInfo.BS
{
    public class ManUsuarios
    {
        private static ManUsuarios Instancia;

        public static ManUsuarios _Instancia
        {
            get
            {
                if (Instancia == null)
                {
                    return new ManUsuarios();
                }
                return Instancia;
            }
            set
            {
                if (Instancia == null)
                {
                    Instancia = value;
                }
            }
        }

        public void Actualizar(usuariox Usuarios)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.ManUsuarios._Instancia.Actualizar(Usuarios);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Eliminar(usuariox Usuarios)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.ManUsuarios._Instancia.Eliminar(Usuarios);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Insertar(usuariox Usuarios)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.ManUsuarios._Instancia.Insertar(Usuarios);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public List<usuariox> Mostrar()
        {
            List<usuariox> lista = new List<usuariox>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = DAL.ManUsuarios._Instancia.Mostrar();
                    scope.Complete();
                }
                return lista;
            }
            catch (Exception ee)
            {

                throw;
            }
        }
    }
}
