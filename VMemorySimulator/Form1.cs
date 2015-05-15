using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMemorySimulator.model;

namespace VMemorySimulator
{
    public partial class Form1 : Form
    {
        private MemoryManager manager;
        private int step = 0;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileName = "script";
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            #region Procedimento do File Dialog para receber o Script
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                textBox6.Text = openFileDialog1.FileName;
                while (!sr.EndOfStream)
                {                        
                    //Consome o Script
                    listScript.Items.Add(new ListViewItem(sr.ReadLine().Split(' ')));
                }   
                MessageBox.Show("Script Imported Successfuly!","Script Importer",MessageBoxButtons.OK,MessageBoxIcon.Information);

                sr.Close();        
            }
            #endregion

            resetMemoryManager();

            #region Configuração Enable/Disable dos Componentes Ready for Execute
            button2.Enabled = true;
            button3.Enabled = true;
            t_page.Enabled = false;
            t_pi.Enabled = false;
            t_la.Enabled = false;
            t_pm.Enabled = false;
            t_sm.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {

            #region Atualização das Cores na ListView do Script
            ListViewItem instruction = listScript.Items[step++];
            instruction.BackColor = System.Drawing.Color.Yellow;
            if(step > 1)
                listScript.Items[step - 2].BackColor = Color.White;
            #endregion

            try {
                ScriptRunner.Run(instruction, manager);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Memory Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
                resetMemoryManager();
                listScript.Items[step-1].BackColor = Color.White;
                step = 0;
            }
            
        }

        public void resetMemoryManager()
        {
            manager = new MemoryManager()
            {
                sizeOfPage = Int32.Parse(t_page.Text),
                sizeOfProcImg = Int32.Parse(t_pi.Text),
                logicAddress = Int32.Parse(t_la.Text),
                _pmem = Memory.create(Int32.Parse(t_pm.Text), memoryView1),
                _smem = Memory.create(Int32.Parse(t_sm.Text), memoryView2),
                tableView = this.tableView1,
                clock = new Clock(Int32.Parse(t_pm.Text)),
                policy = comboBox1.SelectedIndex,
            };

            LRU.history = new List<string>();

            manager._pmem.view.readjust(manager._pmem);
            manager._smem.view.readjust(manager._smem);

        }
    }
}
