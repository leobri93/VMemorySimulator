using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class LRU
    {
        public static List<string> history = new List<string>();

        public static void treatPageFault(MemoryManager mgr, Process newProcess, int newProcess_pageNumber)
        {
            string nameOfProcess = history.ToArray()[0].ToString().Split('_')[0];
            int process_pageNumber = Int32.Parse(history.ToArray()[0].ToString().Split('_')[1]);

            Process process = mgr.getProcessByName(nameOfProcess);

            history.RemoveAt(0);
            history.Add(newProcess.name + "_" + newProcess_pageNumber);

            if(mgr._smem.isFull())
                mgr._smem.free(newProcess.getFrameNumberInSecondaryMemory(newProcess_pageNumber));


            int frame = process.getFrameNumberInPrimaryMemory(process_pageNumber);

            int newFrame = mgr._smem.getFreeFrame();
            process.insertPageInSecondaryMemory(process_pageNumber, newFrame);

            mgr._smem.view.insertPage(newFrame, process.name, process_pageNumber,true);
            mgr._smem.add(newFrame);

            
            newProcess.insertPageInPrimaryMemory(newProcess_pageNumber, frame);
            mgr._pmem.view.insertPage(frame, newProcess.name, newProcess_pageNumber,true); //Atualiza a view 

        }

        public static void refresh(Process p, int PageNumber)
        {
            string process_page = p.name + "_" + PageNumber;

            foreach (string item in history)
            {
                if (item == process_page)
                {
                    history.Remove(item);
                    history.Add(item);
                    return;
                }

            }
            history.Add(process_page);
        }
    }
}
