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

        public TableView tableView;
        
        public void createProcess(string nameOfProcess, int size)
        {
            this._pmem.view.reset();
            this._smem.view.reset();

            #region  Cálculo do Número de Páginas
            int numOfPages = size / sizeOfPage;

            if (size % sizeOfPage > 0)
                numOfPages++;
            #endregion

            #region Criação de um Processo e Adição à Lista de Processos
            Process p = Process.create(nameOfProcess, numOfPages);
            _processes.Add(p);
            #endregion

            #region Processo de Alocação de um novo Processo na Memória

            for (int i = 0; i < numOfPages; i++)
            {
            
                #region Alocação Parcial na MP
                if (i < sizeOfProcImg)
                {
                    int free_frame = _pmem.getFreeFrame(); //Pega Próximo Frame Vazio na MP

                    if (free_frame == -1) //Retorna -1 se Memória Cheia
                    {
                        LRU.treatPageFault(this, p, i); //Caso Memória Cheia, Chama LRU
                    }
                        
                    else
                    {
                        p.tab.insertPageInMemory(i, free_frame); //Insere na Tabela de Páginas
                        _pmem.add(free_frame); //Reserva o Frame na MP
                        this._pmem.view.insertPage(free_frame, p.name, i); //Atualiza a View
                    }
                }
                #endregion
                
                #region Alocação Parcial na MS
                else
                {
                    int free_frame = _smem.getFreeFrame(); //Pega Próximo Frame Vazio na MS

                    if (free_frame == -1)
                        throw new Exception("Secondary Memory Full"); //Caso Memória Cheia: Exception

                    else
                    {
                        p.tab.insertPageInSecondaryMemory(i, free_frame); //Insere na Tabela de Páginas
                        _smem.add(free_frame); //Reserva o Frame na MP
                        this._smem.view.insertPage(free_frame, p.name, i); //Atualiza a View                       
                    }
                }
                #endregion
        
            }
            #endregion

            //Atualização na View de Tabelas
            this.tableView.addProcess(p);
        }


        public void read(string nameOfProcess, int logicAddress)
        {
            this._pmem.view.reset();
            this._smem.view.reset();

            foreach (Process p in _processes)
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

        public Process getProcess(string name)
        {
            foreach (Process p in _processes)
                if (p.name == name)
                    return p;
            return null;
        }

    }
}
