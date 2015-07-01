using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceExampleApp.Banco_de_Dados;

namespace WebServiceExampleApp.Repository
{
   public class NoticiasRepositorio
    {
        private static Banco GetDataBase()
        {
            Banco db = new Banco();
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            return db;
        }

        public static List<Noticias> Get()
        {
            Banco db = GetDataBase();
            var query = from works in db.Noticia orderby works.Id  select works;

            List<Noticias> noticia = new List<Noticias>(query.AsEnumerable());
            return noticia;
        }

        public static void create(Noticias pNoticia)
        {
            Banco db = GetDataBase();
            db.Noticia.InsertOnSubmit(pNoticia);
            db.SubmitChanges();
        }

        public static void delete(Noticias pNoticia)
        {
            Banco db = GetDataBase();
            var query = from t in db.Noticia where t.Id == pNoticia.Id select t;
            db.Noticia.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

    }
}
