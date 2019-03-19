using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnidadPedagogicaSDStaticInfo.DAL
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
        public void Actualizar(tokens tokens)
        {
            try
            {
                using (UPSDTCUXEntities entities = new UPSDTCUXEntities())
                {
                    entities.Entry(tokens).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                }
            }
            catch (Exception ee)
            {


            }
        }


        public void Eliminar(tokens tokens)
        {
            try
            {
                UPSDTCUXEntities entities = new UPSDTCUXEntities();
                var result = entities.tokens.Find(tokens.idToken);
                entities.tokens.Remove(result);
                entities.SaveChanges();

            }
            catch (Exception ee)
            {


            }
        }

        public void Insertar(tokens tokens)
        {
            try
            {
                UPSDTCUXEntities entities = new UPSDTCUXEntities();
                entities.tokens.Add(tokens);
                entities.SaveChanges();

            }
            catch (Exception ee)
            {


            }
        }

        public List<tokens> Mostrar()
        {
            //Inicializamos
            List<tokens> lista = new List<tokens>();

            try
            {
                UPSDTCUXEntities entities = new UPSDTCUXEntities();
                lista = entities.tokens.ToList();
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
