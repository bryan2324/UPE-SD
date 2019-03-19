using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnidadPedagogicaSDStaticInfo.DAL;

namespace UnidadPedagogicaSD.StaticInfo.Models
{
    public class RegistroModel
    {
        public int idToken { get; set; }
        public int token { get; set; }




        public bool verificar(int token) {

            List<tokens> allUser = new List<tokens>();
            allUser = UnidadPedagogicaSDStaticInfo.BS.ManTokens._Instancia.Mostrar();

            int largo = Convert.ToInt32(allUser.Count.ToString());
            bool r = false;
            try
            {

                for (int i = 0; i < largo; i++)
                {
                    String BDToken = allUser[i].token.ToString();



                    if (Convert.ToInt32(BDToken)==token)
                    {


                        r = true;
                    }

                }
            }
            catch (Exception e)
            {
            }

            return r;
        }


    }
}