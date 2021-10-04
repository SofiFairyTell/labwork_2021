using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw_sm_1
{
    public class comp: IComparer<comp> 
    {
        public string compName { get; set; } //название группы верхнего уровня
        public int capacity;
        public comp()
        {
            this.compName = "comp_";
            this.capacity = 0; //изначально емкость незаполнена
        }

        public comp(int Capacity,string compName)
        {
            this.compName = compName;
            this.capacity = Capacity;
        }
        public int Compare(comp o1, comp o2)
        {
            if (o1.capacity > o2.capacity)
            {
                return 1;
            }
            else if (o1.capacity < o2.capacity)
            {
                return -1;
            }

            return 0;
        }
    }
}
