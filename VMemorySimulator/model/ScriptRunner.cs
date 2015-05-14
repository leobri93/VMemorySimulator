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
        private static int step = 0;
        private MemoryManager manager;

        public static void Run(ListView listScript)
        {
            ListViewItem item = listScript.Items[step++];
            item.BackColor = System.Drawing.Color.Yellow;

            #region Identificação dos Valores do Script (Tipo - Nome do Processo - Valor)
            char type = item.SubItems[1].Text[0];
            string name = item.SubItems[0].Text;
            int value = Int32.Parse(item.SubItems[2].Text);
            #endregion

            #region Execução da Instrução
            switch (type)
            {
                case 'C':
                    manager.createProcess(name, value);
                    this.tableView1.addProcess(manager.getProcess(name));
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
