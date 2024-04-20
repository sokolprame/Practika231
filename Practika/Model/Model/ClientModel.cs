using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Model.Model
{
    internal class Client_Model
    {
        public class ClientModel
        {
            public int id_clients { get; set; }
            public int Id_car { get; set; }
            public string nomer_car { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime Data { get; set; }
            public string phone { get; set; }
        }

    }
}
