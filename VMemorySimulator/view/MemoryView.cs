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

        public MemoryView()
        {
            this.BackColor = System.Drawing.Color.White;
        }

        public void reset()
        {
            foreach(Label block in blocks)
            {
                block.ForeColor = System.Drawing.Color.Black;
                block.BackColor = System.Drawing.Color.White;          
            }
        }

        public void insertPage(int frameNumber, string nameOfProcess, int PageNumber, bool isSwap)
        {
            this.blocks[frameNumber].Text = nameOfProcess + "\n\n" + PageNumber;
            blocks[frameNumber].ForeColor = System.Drawing.Color.Red;
            if (isSwap)
                blocks[frameNumber].BackColor = System.Drawing.Color.LightGreen;
        }

        public void setMemory(Memory mem)
        {
            this.mem = mem;
            this.Controls.Clear();
            blocks = new Label[mem.pages.Length];
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i] = new Label();
                blocks[i].BackColor = System.Drawing.Color.White;
                blocks[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                blocks[i].BorderStyle = BorderStyle.FixedSingle;
                blocks[i].Text = "";
                
                blocks[i].Size = new System.Drawing.Size(this.Size.Width / mem.pages.Length, this.Size.Height);
                blocks[i].Location = new System.Drawing.Point(blocks[i].Size.Width * i, 0);
                this.Controls.Add(blocks[i]);
            }
        }
    }
}
