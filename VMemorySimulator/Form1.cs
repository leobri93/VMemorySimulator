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

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(openFileDialog1.FileName);
                textBox6.Text = openFileDialog1.FileName;
                while (!sr.EndOfStream)
                {                        
                    listView1.Items.Add(new ListViewItem(sr.ReadLine().Split(' ')));
                }
                    
                MessageBox.Show("Script Imported Successfuly!","Script Importer");          
            }
        }
    }
}
