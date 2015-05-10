using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class Memory
    {

        public Page[] pages;

        public static Memory create(int numOfPages)
        {
            return new Memory()
            {
                pages = new Page[numOfPages]
            };
        }
    }

   
}
