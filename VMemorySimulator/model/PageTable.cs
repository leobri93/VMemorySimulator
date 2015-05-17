using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMemorySimulator.view;

namespace VMemorySimulator.model
{
    public class PageTable
    {
        private bool[] V;
        private bool[] M;
        private int[] frame;

        public TabPage view;

        public PageTable(int size)
        {
            V = new bool[size];
            M = new bool[size];
            frame = new int[size];
        }

        public void setView(TabPage view)
        {
            this.view = view;
        }

        public int getFrameNumberInPrimaryMemory(int PageNumber)
        {
            if (V[PageNumber] == false)
                throw new Exception("Page Fault");
            return frame[PageNumber];
        }

        public int getFrameNumberInSecondaryMemory(int PageNumber)
        {
            if (V[PageNumber] == true)
                throw new Exception("Page Fault");
            return frame[PageNumber];

        }

        public bool getValidity(int PageNumber)
        {
            return V[PageNumber];
        }

        public bool getModification(int PageNumber)
        {
            return M[PageNumber];
        }

        public void setModification(int pageNumber)
        {
            M[pageNumber] = true;
        }

        public void insertPageInMemory(int PageNumber, int FrameNumber)
        {
            V[PageNumber] = true;
            frame[PageNumber] = FrameNumber;

            ListView tabela = (ListView) view.Controls[0];


            ListViewItem item = tabela.Items[PageNumber];
            item.SubItems[1].Text = (getValidity(PageNumber).ToString());
            item.SubItems[2].Text = (getModification(PageNumber).ToString());
            item.SubItems[3].Text = FrameNumber.ToString();

            
        }

        public void insertPageInSecondaryMemory(int PageNumber, int FrameNumber)
        {
            V[PageNumber] = false;
            frame[PageNumber] = FrameNumber;

            ListView tabela = (ListView)view.Controls[0];


            ListViewItem item = tabela.Items[PageNumber];
            item.SubItems[1].Text = (getValidity(PageNumber).ToString());
            item.SubItems[2].Text = (getModification(PageNumber).ToString());
            item.SubItems[3].Text = FrameNumber.ToString();

        }


    }
}
