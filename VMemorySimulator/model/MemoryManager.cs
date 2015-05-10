using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMemorySimulator.model
{
    public class MemoryManager
    {
        private List<Process> _processes = new List<Process>();
        public Memory _pmem;
        public Memory _smem;

        public int sizeOfPage;
        public int sizeOfProcImg;
        public int logicAddress;
        
        public void createProcess(string nameOfProcess, int size)
        {
            int numOfPages = size / sizeOfPage;
            if (size % sizeOfPage > 0)
                numOfPages++;
            _processes.Add(Process.create(nameOfProcess,numOfPages));

            //CARREGAR PARTE DO PROCESSO NA MEMORIA PRINCIPAL

            //CARREGAR A OUTRA PARTE DO PROCESSO NA MEMORIA SECUNDÁRIAS

        }

        public void read(string nameOfProcess, int logicAddress)
        {
            foreach(Process p in _processes)
            {
                if(p.name == nameOfProcess)
                {
                    int pageNumber = getPageNumber(logicAddress);
                    try {
                        int frameNumber = p.tab.getFrameNumber(pageNumber);
                        //SWAP ENTRE MEMORIAS
                        execute();
                    }
                    catch (Exception e)
                    {
                        //Atualiza a tabela de paginas
                        if (e.Message == "Page Fault")
                            LRU.treatPageFault(this, p, pageNumber);
                        //SWAP ENTRE MEMORIAS
                        execute();
                    }
                    return;
                }
            }

            throw new Exception("ProcessNotFound");
        }

        public void execute()
        {

        }

        public void write(string nameOfProcess, int logicAddress)
        {

        }

        public int getPageNumber(int logicAddress)
        {
            return logicAddress / sizeOfPage;
        }

        public int getOffset(int logicAddress)
        {
            return logicAddress % sizeOfPage;
        }

    }
}
