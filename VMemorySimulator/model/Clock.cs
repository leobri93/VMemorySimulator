using System;
using System.Collections;
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
        public string[] history; 
        public Clock(int tamanho_memoria)
        {
            list = new bool[tamanho_memoria];
            history = new string[tamanho_memoria];
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
            
            //enquato o frame estiver utilizado
            while (list[pont] == true)
            {
                
                //percorrendo historico de process+page
                foreach (string item in history )
                {
                    //verifica se item atual é igual a process_page
                    if (item == process_page)
                    {
                        //caso possitivo, faz o elemento na tabela de paginas receber true
                        list[pont] = true;
                    }
                    else
                    {
                        //faz o elemento receber false na tabela de paginas e anda com o ponteiro
                        list[pont] = false;
                        //anda com o ponteiro
                        if (pont == (list.Length - 1))
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
            //insere na tabela de paginas
            if (list[pont] == false )
            {
                //verificar se a posicao no historico existe
                if (history[pont] != null)
                {
                    //remove do historico naquela posicao
                    history[pont] = null;
                    
                    //O ITEM QUE FOI REMOVIDO DO HISTORICO SAI DA MEMORIA PRINCIPAL E VAI PARA A SECUNDARIA
                   
                    //inserindo o novo process_page no lugar do historico onde foi removido o anterior
                    history[pont] = process_page;

                    //INSERIR O NOVO ITEM NA MEMORIA PRINCIPAL(tabela de paginas)
                    //ATUALIZAR A VIEW

                    //list na posicao onde foi adicionado recebe true
                    list[pont] = true;
                    //anda com o ponteiro
                     if (pont == (list.Length-1))
                     {
                         pont = 0;
                     }
                     else
                     {
                         pont++;
                     }
                }
                else
                {
                    //inserindo o novo process_page no lugar do historico onde foi removido o anterior
                    history[pont] = process_page;

                    //INSERIR NA MEMORIA PRINCIPAL(tabela de paginas)
                    //ATUALIZAR A VIEW

                    //list na posicao onde foi adicionado recebe true
                    list[pont] = true;
                    //anda com o ponteiro
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
