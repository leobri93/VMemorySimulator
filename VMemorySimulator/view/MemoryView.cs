using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMemorySimulator.model;

namespace VMemorySimulator.view
{
    public class MemoryView : System.Windows.Forms.Panel
    {
        private Memory mem;
        public Label[] blocks;


        public void readjust(Memory mem, int numOfPages)
        {
            this.mem = mem;
            blocks = new Label[numOfPages];
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new Label();
                blocks[i].BackColor = System.Drawing.Color.Red;
                blocks[i].Text = "PX";
                blocks[i].Size = new System.Drawing.Size(this.Size.Width / numOfPages, this.Size.Height);
                blocks[i].Location = new System.Drawing.Point(blocks[i].Size.Width * i, 0);
            }
        }
    }
}
