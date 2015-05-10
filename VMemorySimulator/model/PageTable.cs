using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class PageTable
    {
        private bool[] V;
        private bool[] M;
        private int[] frame;

        public PageTable(int size)
        {
            V = new bool[size];
            M = new bool[size];
            frame = new int[size];
        }

        public int getFrameNumber(int PageNumber)
        {
            if (V[PageNumber] == false)
                throw new Exception("Page Fault");
            return frame[PageNumber];
        }

        public void insertPageInMemory(int PageNumber, int FrameNumber)
        {
            V[PageNumber] = true;
            frame[PageNumber] = FrameNumber;
        }
    }
}
