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
        public Form1()
        {
            InitializeComponent();        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "script";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                textBox6.Text = openFileDialog1.FileName;
                while (!sr.EndOfStream)
                {                        
                    listScript.Items.Add(new ListViewItem(sr.ReadLine().Split(' ')));
                }
                    
                MessageBox.Show("Script Imported Successfuly!","Script Importer");          
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MemoryManager manager = new MemoryManager()
            {
                sizeOfPage = Int32.Parse(t_page.Text),
                sizeOfProcImg = Int32.Parse(t_pi.Text),
                logicAddress = Int32.Parse(t_la.Text),
                _pmem = Memory.create(Int32.Parse(t_pm.Text)),
                _smem = Memory.create(Int32.Parse(t_sm.Text)),
            };

            foreach(ListViewItem item in listScript.Items)
            {
                char type = item.SubItems[1].Text[0];
                string name = item.SubItems[0].Text;
                int value = Int32.Parse(item.SubItems[2].Text);

                switch (type) {
                    case 'C':
                        manager.createProcess(name, value);
                        break;
                    case 'R':
                        manager.read(name, value);
                        break;
                    case 'W':
                        manager.write(name, value);
                        break;
                }
            }
        }
    }
}
