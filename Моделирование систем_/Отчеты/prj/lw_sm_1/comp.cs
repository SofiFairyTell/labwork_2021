using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw_sm_1
{
    public class comp
    {
        public string compName { get; set; } //название группы верхнего уровня
        public int capacity;
        public comp()
        {
            this.compName = "comp_";
            this.capacity = 4;
        }

        public comp(int Capacity,string compName)
        {
            this.compName = compName;
            this.capacity = Capacity;
        }
    }
}
