using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class LRU
    {

        public static void treatPageFault(MemoryManager mgr, Process p, int pageNumber)
        {
            for (int i = 0; i < mgr._pmem.pages.Length; i++)
            {
                if (mgr._pmem.pages[i] == null)
                {
                    mgr._pmem.pages[i] = new Page()
                    {
                        free = false,
                    };
                    p.tab.insertPageInMemory(pageNumber, i);
                    return;
                }
            }
            //Tratar memoria principal cheia

        }
    }
}
