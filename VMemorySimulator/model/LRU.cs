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
        public static void treatPageFault(MemoryManager mgr, Process p, int pageNumber)
        {
            string process = history.ToArray()[0].ToString().Split('_')[0];
            int page = Int32.Parse(history.ToArray()[0].ToString().Split('_')[1]);
            Process proc = mgr.getProcessByName(process);
            //
            //VERIFICAR QUANDO O FRAME JA EXISTE
            //
            int sec_frame_novo = mgr._smem.getFreeFrame();
            int frame = proc.tab.getFrameNumber(page);
            
            proc.tab.insertPageInSecondaryMemory(page, sec_frame_novo);
            
            mgr._smem.view.blocks[sec_frame_novo].Text = proc.name + "\n\n" + page;
            mgr._smem.add(sec_frame_novo);

            history.RemoveAt(0);
            history.Add(p.name + "_" + pageNumber);

            p.tab.insertPageInMemory(pageNumber, frame);
            mgr._pmem.view.blocks[frame].Text = p.name + "\n\n" + pageNumber;

        }


        public static void refresh(string process_page)
        {
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
