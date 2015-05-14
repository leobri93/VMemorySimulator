using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class Clock
    {
        public bool[] list; //lista de utilizados
        public int pont = 0; //ponteiro

        public Clock(int tamanho_memoria)
        {
            list = new bool[tamanho_memoria];
            for (int i = 0; i < tamanho_memoria; i++)
                list[i] = false;
        }

        public void refresh(string process_page)
        {

        }


        public void treatPageFault(MemoryManager mgr, Process p, int PageNumber)
        {
            while (list[pont] == true)
            {
                list[pont++] = false;
                if (pont == list.Length)
                    pont = 0;
            }
            p.tab.insertPageInMemory(PageNumber, pont);       
        }        
    }
}
