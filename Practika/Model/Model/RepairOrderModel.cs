using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Model.Model
{
    internal class RepairOrder_Model
    {
        public class RepairOrderModel
        {
            public int Id { get; set; }
            public int ClientId { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }
    }
}
