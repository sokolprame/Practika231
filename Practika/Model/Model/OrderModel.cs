using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Model.Model
{
    public class Order_Model
    {
        public class OrderModel
        {
            public int id_ordes { get; set; }
            public int ID_YSLUGE { get; set; }
            public int id_clients { get; set; }

            public int id_sotrudnika { get; set; }
            public int id_car { get; set; }
            public int nomer_car { get; set; }
            public DateTime date { get; set; }
            public decimal sum { get; set; }
            public string status { get; set; }
        }

    }
}
