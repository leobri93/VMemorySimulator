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
        public static List<string> history = new List<string>(); 
        public Clock(int tamanho_memoria)
        {
            list = new bool[tamanho_memoria];
            for (int i = 0; i < tamanho_memoria; i++)
                list[i] = false;
        }
        /// <summary>
        /// Usado no read e write para atualizar o status do elemento caso ele seja chamado e já esteja na tabela de paginas
        /// </summary>
        /// <param name="p"></param>
        /// <param name="PageNumber"></param>
        public void refresh(Process p, int PageNumber)
        {
            int cont = 0;
            string process_page = p.name + "_" + PageNumber;
            foreach (string item in history)
            {
                if (item == process_page)
                {
                    list[cont] = true;
                }
                else
                {
                    cont++;
                }
                
            }
            
            
        }


        public void treatPageFault(MemoryManager mgr, Process p, int pageNumber)
        {
            string process_page = p.name + "_" + pageNumber;
            history.Add(p.name + "_" + pageNumber);
            //enquato o frame estiver utilizado
            while (list[pont] == true)
            {
                //percorrendo historico de process+page
                foreach (string item in history)
                {
                    //verifica se item atual é igual a process_page
                    if (item == process_page)
                    {
                        //caso possitivo, faz o elemento na tabela de paginas receber true
                        list[pont] = true;
                    }
                    else
                    {
                        //caso contrario remove o elemento do histórico 
                        history.RemoveAt(pont);
                        //faz o elemento receber false na tabela de paginas e anda com o ponteiro
                        list[pont++] = false;
                    }
                }
                //verfica se é o final da tabela de paginas
                if (pont == (list.Length-1))
                    //caso positivo, volta com o ponteiro para o primeiro elemento
                    pont = 0;
            }
            //insere na tabela de paginas
            if (list[pont] == false )
            {
                foreach (string item in history)
                {
                    if (item == process_page)
                    {
                        list[pont] = true;
                        if (pont == (list.Length-1))
                        {
                            pont = 0;
                        }
                        else
                        {
                            pont++;
                        }
                        
                    }
                   
                    
                }
            }
        }        
    }
}
