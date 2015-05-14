using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMemorySimulator.model
{
    public class Process
    {
        public string name { get; set; }

        public PageTable tab { get; set; }

        public int size;

        public static Process create(string nameOfProcess, int numOfPages)
        {
            return new Process()
            {
                name = nameOfProcess,
                tab = new PageTable(numOfPages),
                size = numOfPages,
            };
           
        }
    }
}
   