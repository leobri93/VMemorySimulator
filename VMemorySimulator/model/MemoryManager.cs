using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMemorySimulator.view;

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
            Process p = Process.create(nameOfProcess, numOfPages);
            _processes.Add(p);

            //ALLOC MEM
            for(int i = 0; i < numOfPages; i++)
            {
                //ALOCANDO NA MEMORIA PRINCIPAL
                if (i < sizeOfProcImg)
                {
                    int free_frame = _pmem.getFreeFrame();
                    if (free_frame == -1)
                        LRU.treatPageFault(this, p, i); //CASO MEMORIA CHEIA, CHAMA LRU
                    else
                    {
                        p.tab.insertPageInMemory(i, free_frame); //INSERINDO NA TABELA
                        _pmem.add(free_frame); //RESERVANDO FRAME NA MEMORIA PRINCIPAL
                        this._pmem.view.blocks[free_frame].Text = p.name + "\n\n" + i; //COLOCANDO NA VIEW
                    }
                }
                //ALOCANDO NA MEMÓRIA SECUNDÁRIA
                else
                {
                    int free_frame = _smem.getFreeFrame();
                    if (free_frame == -1)
                        throw new Exception("Secondary Memory Full!"); //CASO MEMORIA CHEIA, EXCEPTION MEMORIA CHEIA!
                    else
                    {
                        p.tab.insertPageInSecondaryMemory(i, free_frame); //INSERINDO NA TABELA
                        _smem.add(free_frame); //RESERVANDO FRAME NA MEMORIA SECUNDARIA
                        this._smem.view.blocks[free_frame].Text = p.name + "\n\n" + i; //COLOCANDO NA VIEW
                    }
                }
            }           
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
                            //verifcar qual metodo de substituição foi escolhido
                            LRU.treatPageFault(this, p, pageNumber);
                        //SWAP ENTRE MEMORIAS
                        execute();
                    }
                    this._pmem.view.blocks[p.tab.getFrameNumber(pageNumber)].Text = p.name + "\n\n" + pageNumber;
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
            foreach (Process p in _processes)
            {
                if ((p.name == nameOfProcess))
                {
                    int pageNumber = getPageNumber(logicAddress);
                    try
                    {
                        int frameNumber = p.tab.getFrameNumber(pageNumber);
                        //SWAP 
                        executeWrite();
                    }
                    catch (Exception e)
                    {
                        if (e.Message.IndexOf("Page Fault", StringComparison.InvariantCultureIgnoreCase) != -1)
                        {
                            //verifcar qual metodo de substituição foi escolhido
                            LRU.treatPageFault(this, p, pageNumber);
                            //SWAP
                            executeWrite();
                        }
                    }
                    this._pmem.view.blocks[p.tab.getFrameNumber(pageNumber)].Text = p.name + "\n\n"+ pageNumber;
                    return;
                }
            }
        }

        private void executeWrite()
        {
            //throw new NotImplementedException();
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
