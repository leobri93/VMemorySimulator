using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMemorySimulator.view;

namespace VMemorySimulator.model
{
    public class Memory
    {

        public Page[] pages;
        public MemoryView view;

        public Memory(int numOfPages)
        {
            pages = new Page[numOfPages];
            for (int i = 0; i < pages.Length; i++)
                pages[i] = new Page();
        }

        public static Memory create(int numOfPages, MemoryView v)
        {
            Memory mem = new Memory(numOfPages)
            {
                view = v,

            };
            v.setMemory(mem);

            return mem;
        }

        public void resetView()
        {
            view.reset();
        }

        public void add(int frame)
        {
            pages[frame].free = false;
        }

        public int getFreeFrame()
        {
            for (int i = 0; i < pages.Length; i++)
                if (pages[i].free == true)
                    return i;
            return -1;
        }

        public bool isFull()
        {
            for (int i = 0; i < pages.Length; i++)
                if (pages[i].free == true)
                    return false;
            return true;
        }

        public void free(int frame)
        {
            pages[frame].free = true;
        }
    }
   
}
