using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadPedagogicaSDStaticInfo.DAL
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
        public void Actualizar(usuariox usuariox)
        {
            try
            {
                using (UPSDTCUXEntities  entities = new UPSDTCUXEntities ())
                {
                    entities.Entry(usuariox).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch (Exception ee)
            {


            }
        }


        public void Eliminar(usuariox usuariox)
        {
            try
            {
                UPSDTCUXEntities  entities = new UPSDTCUXEntities ();
                var result = entities.usuariox.Find(usuariox.idUsuario);
                entities.usuariox.Remove(result);
                entities.SaveChanges();

            }
            catch (Exception ee)
            {


            }
        }

        public void Insertar(usuariox usuariox)
        {
            try
            {
                UPSDTCUXEntities  entities = new UPSDTCUXEntities ();
                entities.usuariox.Add(usuariox);
                entities.SaveChanges();

            }
            catch (Exception ee)
            {


            }
        }

        public List<usuariox> Mostrar()
        {
            //Inicializamos
            List<usuariox> lista = new List<usuariox>();

            try
            {
                UPSDTCUXEntities  entities = new UPSDTCUXEntities ();
                lista = entities.usuariox.ToList();
                entities.SaveChanges();

                return lista;
            }
            catch (Exception ee)
            {
                throw;
            }
        }
    }
}
