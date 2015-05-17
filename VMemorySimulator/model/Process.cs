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

        private PageTable tab { get; set; }

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

        public int getFrameNumberInPrimaryMemory(int pageNumber)
        {
            return tab.getFrameNumberInPrimaryMemory(pageNumber);
        }

        public int getFrameNumberInSecondaryMemory(int pageNumber)
        {
            return tab.getFrameNumberInSecondaryMemory(pageNumber);
        }


        public void write(int pageNumber)
        {
            tab.setModification(pageNumber);
        }

        public void insertPageInSecondaryMemory(int process_pageNumber, int newFrame)
        {
            tab.insertPageInSecondaryMemory(process_pageNumber, newFrame);
            
        }
        public void insertPageInPrimaryMemory(int process_pageNumber, int newFrame)
        {
            tab.insertPageInMemory(process_pageNumber, newFrame);
        }

        public void read(int pageNumber)
        {

        }

    }
}
   