using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Conection
{

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarcaId { get; set; }

        public Beer(int id, string name, int MarcaID) 
        {
            this.Id = id;
            this.Name = name;
            this.MarcaId = MarcaID;
        }

    }
}
