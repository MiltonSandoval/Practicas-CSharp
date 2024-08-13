using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CerveceriaDB
{
    class Cervesas
    {
        public int Id;
        public string Name;
        public int MarcaId;

        public Cervesas(int id, string name, int marcaid) 
        {
            this.Id = id;
            this.Name = name;
            this.MarcaId = marcaid;
        }
        public Cervesas(string name, int marcaid)
        {
            this.Name = name;
            this.MarcaId = marcaid;
        }
    }
}
