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
            //verifica se a tabela de paginas está cheia 
            if (verifyFrame(mgr,p,pageNumber))
            {

            }
            //Tratar memoria principal cheia
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
