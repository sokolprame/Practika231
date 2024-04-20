using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practika.Model.Model
{
    internal class Employer_Model
    {
        public class EmployerModel
        {
            public int Id_sotrudnika { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string role { get; set; }
            public decimal wage { get; set; }
        }

    }
}
