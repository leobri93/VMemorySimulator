using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMemorySimulator.model
{
    public class ScriptRunner
    {
        
        public static void Run(ListViewItem instruction, MemoryManager manager)
        {
            #region Identificação dos Valores do Script (Tipo - Nome do Processo - Valor)
            char type = instruction.SubItems[1].Text[0];
            string name = instruction.SubItems[0].Text;
            int value = Int32.Parse(instruction.SubItems[2].Text);
            #endregion

            #region Execução da Instrução
            switch (type)
            {
                case 'C':
                    manager.createProcess(name, value);
                    //this.tableView1.addProcess(manager.getProcess(name));
                    break;
                case 'R':
                    manager.read(name, value);
                    break;
                case 'W':
                    manager.write(name, value);
                    break;
            }
            #endregion
        }
    }
}
