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

        public enum SubstitutionPolicy {LRU,Clock};

        public int policy;

        public TableView tableView;

        public Clock clock;


        public MemoryManager()
        {
            LRU.history = new List<string>();
        }

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
            //Reset Views
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

                    if (free_frame == -1)
                    {
                        switch (policy)
                        {
                            case (int)SubstitutionPolicy.LRU:
                                LRU.treatPageFault(this, p, i);
                                break;
                            case (int)SubstitutionPolicy.Clock:
                                clock.treatPageFault(this, p, i);
                                break;
                        }
                    }
                    else
                    {
                        switch (policy)
                        {
                            case (int)SubstitutionPolicy.LRU:
                                LRU.refresh(p, i);
                                break;
                            case (int)SubstitutionPolicy.Clock:
                                //faz os page faults de quando ainda há espaço no frame
                                clock.treatPageFault(this,p, i);
                                break;
                        }
                       

                        p.insertPageInPrimaryMemory(i, free_frame); //INSERINDO NA TABELA
                        _pmem.add(free_frame); //RESERVANDO FRAME NA MEMORIA PRINCIPAL
                        this._pmem.view.insertPage(free_frame, p.name, i,false); //Atualiza a view 

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
                        p.insertPageInSecondaryMemory(i, free_frame); //Insere na Tabela de Páginas
                        _smem.add(free_frame); //Reserva o Frame na MP
                        this._smem.view.insertPage(free_frame, p.name, i,false); //Atualiza a View                       
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

            #region Reset nas Views das Memórias
            _pmem.resetView();
            _smem.resetView();
            #endregion

            Process process = getProcessByName(nameOfProcess);

            if(process == null)
                throw new Exception("Process Not Found");

            int pageNumber = getPageNumber(logicAddress);

            try
            {
                int frameNumber = process.getFrameNumberInPrimaryMemory(pageNumber);
            }
            catch (Exception e)
            {
                switch(e.Message)
                {
                    case "Page Fault":
                    switch (policy)
                    {
                        case (int)SubstitutionPolicy.LRU:
                            LRU.treatPageFault(this, process, pageNumber);
                            break;
                        case (int)SubstitutionPolicy.Clock:
                            clock.treatPageFault(this, process, pageNumber);
                            break;
                    }
                    break;
                    default:
                        throw e;                       
                }
            }

            process.read(pageNumber);

            this._pmem.view.insertPage(process.getFrameNumberInPrimaryMemory(pageNumber), process.name, pageNumber, false);

            switch (policy)
            {
                case (int)SubstitutionPolicy.LRU:
                    LRU.refresh(process, pageNumber);
                    break;
                case (int)SubstitutionPolicy.Clock:
                    clock.refresh(process, pageNumber);
                    break;
            }
        }
      
        public void write(string nameOfProcess, int logicAddress)
        {

            #region Reset nas Views das Memórias
            _pmem.resetView();
            _smem.resetView();
            #endregion

            Process process = getProcessByName(nameOfProcess);

            if (process == null)
                throw new Exception("Process Not Found");

            int pageNumber = getPageNumber(logicAddress);

            try
            {
                int frameNumber = process.getFrameNumberInPrimaryMemory(pageNumber);
            }
            catch (Exception e)
            {
                switch (e.Message)
                {
                    case "Page Fault":
                        switch (policy)
                        {
                            case (int)SubstitutionPolicy.LRU:
                                LRU.treatPageFault(this, process, pageNumber);
                                break;
                            case (int)SubstitutionPolicy.Clock:
                                clock.treatPageFault(this, process, pageNumber);
                                break;
                        }
                        break;
                    default:
                        throw e;
                }
            }

            process.write(pageNumber);

            this._pmem.view.insertPage(process.getFrameNumberInPrimaryMemory(pageNumber), process.name, pageNumber, false);

            switch (policy)
            {
                case (int)SubstitutionPolicy.LRU:
                    LRU.refresh(process, pageNumber);
                    break;
                case (int)SubstitutionPolicy.Clock:
                    clock.refresh(process, pageNumber);
                    break;
            }
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
