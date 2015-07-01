using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceExampleApp.Repository
{

    [Table(Name = "Noticia")]
   public class Noticias
    {
        [Column (IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column (CanBeNull = false)]
        public Object News { get; set; }
    }
}
