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

            if(mgr._smem.getFreeFrame() == -1)
                mgr._smem.free(newProcess.tab.getFrameNumberInSecondaryMemory(newProcess_pageNumber));


            int frame = process.tab.getFrameNumber(process_pageNumber);

            int newFrame = mgr._smem.getFreeFrame();
            process.tab.insertPageInSecondaryMemory(process_pageNumber, newFrame);
            mgr._smem.view.insertPage(newFrame, process.name, process_pageNumber);
            mgr._smem.add(newFrame);

            
            newProcess.tab.insertPageInMemory(newProcess_pageNumber, frame);
            mgr._pmem.view.insertPage(frame, newProcess.name, newProcess_pageNumber); //Atualiza a view 


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

        /// <summary>
        /// verifica se tem algum espaço de frame vazio, caso haja algum retorna false. Caso todos estejam preenchidos retorna true.
        /// </summary>
        /// <param name="mgr"></param>
        /// <param name="p"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static bool verifyFrame(MemoryManager mgr, Process p, int pageNumber)
        {   
                
               for (int i = 0; i < mgr._pmem.pages.Length; i++)
               {
                   //verificar o frame, caso esteja vazio insere
                   if (mgr._pmem.pages[i] == null)
                   {
                       mgr._pmem.pages[i] = new Page()
                       {
                           free = false,
                       };
                       p.tab.insertPageInMemory(pageNumber, i);
                       return false;
                   }
           }
               return true;
            

        }
    }
}
