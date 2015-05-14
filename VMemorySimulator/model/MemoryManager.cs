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

        public Process getProcessByName(string nameOfProcess)
        {
            foreach (Process p in _processes)
            {
                if (p.name == nameOfProcess)
                    return p;
            }
            return null;
        }

        public void createProcess(string nameOfProcess, int size)
        {

            //Cálculo do Número de Páginas
            int numOfPages = size / sizeOfPage;

            if (size % sizeOfPage > 0)
                numOfPages++;

            //Criação de um Processo
            Process p = Process.create(nameOfProcess, numOfPages);

            //Adição à Lista de Processos
            _processes.Add(p);
            

            //Processo de Alocação de um novo Processo na Memória
            for(int i = 0; i < numOfPages; i++)
            {
                //Alocação Parcial na Memória Principal
                if (i < sizeOfProcImg)
                {
                    int free_frame = _pmem.getFreeFrame();

                    if (free_frame == -1)
                    {
                        // verifcar metodo de substituicao =  LRU
                        LRU.treatPageFault(this, p, i); //CASO MEMORIA CHEIA, CHAMA LRU

                        //caso seja clock
                        //entra no metodo de clock

                    }
                    else
                    {
                        LRU.refresh(p.name + "_" + i);
                        p.tab.insertPageInMemory(i, free_frame); //INSERINDO NA TABELA
                        _pmem.add(free_frame); //RESERVANDO FRAME NA MEMORIA PRINCIPAL
                        this._pmem.view.insertPage(free_frame, p.name, i); //COLOCANDO NA VIEW
                    }
                }

                //Alocação Parcial na Memória Secundária
                else
                {
                    int free_frame = _smem.getFreeFrame();
                    if (free_frame == -1)
                        throw new Exception("Secondary Memory Full!"); //CASO MEMORIA CHEIA, EXCEPTION MEMORIA CHEIA!
                    else
                    {
                        p.tab.insertPageInSecondaryMemory(i, free_frame); //INSERINDO NA TABELA
                        _smem.add(free_frame); //RESERVANDO FRAME NA MEMORIA SECUNDARIA
                        this._smem.view.insertPage(free_frame, p.name, i); //ATUALIZANDO VIEW                        
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
                    LRU.refresh(p.name + "_" + pageNumber);
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
                    LRU.refresh(p.name + pageNumber);
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

        public Process getProcess(string name)
        {
            foreach (Process p in _processes)
                if (p.name == name)
                    return p;
            return null;
        }

    }
}
