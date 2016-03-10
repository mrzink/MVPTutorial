using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentModel : IModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string ClassName { get; set; }
        public string Address { get; set; }
    }
}
