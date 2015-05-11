using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class Page
    {
        public bool free;
        public int[] space;

        public Page()
        {
            free = true;
        }
    }
}
