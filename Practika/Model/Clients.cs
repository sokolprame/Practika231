using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Model
{
    internal class Class1
    {
        public class Client
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public ObservableCollection<Car> Cars { get; set; }
        }

        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public string Year { get; set; }
        }
    }
}
