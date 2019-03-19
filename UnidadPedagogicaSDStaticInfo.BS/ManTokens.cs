using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UnidadPedagogicaSDStaticInfo.DAL;

namespace UnidadPedagogicaSDStaticInfo.BS
{
    public class ManTokens
    {
        private static ManTokens Instancia;

        public static ManTokens _Instancia
        {
            get
            {
                if (Instancia == null)
                {
                    return new ManTokens();
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

        public void Actualizar(tokens Usuarios)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.ManTokens._Instancia.Actualizar(Usuarios);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Eliminar(tokens Usuarios)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.ManTokens._Instancia.Eliminar(Usuarios);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public void Insertar(tokens Usuarios)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.ManTokens._Instancia.Insertar(Usuarios);
                    scope.Complete();
                }
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        public List<tokens> Mostrar()
        {
            List<tokens> lista = new List<tokens>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    lista = DAL.ManTokens._Instancia.Mostrar();
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
