using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practika.Model.Class1;

namespace Practika.Model
{
    internal class RepairOrder
    {
        public class RepairOrder
        {
            public int Id { get; set; }
            public Client Client { get; set; }
            public ObservableCollection<Service> Services { get; set; }
            public DateTime Date { get; set; }
            public string Status { get; set; }
        }

        public class Service
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
