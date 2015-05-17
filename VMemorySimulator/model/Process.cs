using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMemorySimulator.model
{
    public class Process
    {
        public string name { get; set; }

        private PageTable tab { get; set; }

        public int size;

        public static Process create(string nameOfProcess, int numOfPages)
        {
            return new Process()
            {
                name = nameOfProcess,
                tab = new PageTable(numOfPages),
                size = numOfPages,
            };
           
        }

        public void setTableView(TabPage p)
        {
            p.Text = this.name;

            ListView tabela = new ListView();
            tabela.View = View.Details;

            tabela.Columns.Add("Page");
            tabela.Columns.Add("V");
            tabela.Columns.Add("M");
            tabela.Columns.Add("Frame");

            
            foreach (ColumnHeader col in tabela.Columns)
            {
                col.Width = p.Parent.Width / 4;
                col.TextAlign = HorizontalAlignment.Center;
            }
            tabela.Size = p.Parent.Size;
            


            for (int i = 0; i < size; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(tab.getValidity(i).ToString());
                item.SubItems.Add(tab.getModification(i).ToString());
                try
                {
                    item.SubItems.Add(getFrameNumberInPrimaryMemory(i).ToString());
                }
                catch (Exception)
                {
                    item.SubItems.Add("");
                }
                tabela.Items.Add(item);
            }

            p.Controls.Add(tabela);

            tab.setView(p);
        }

        public int getFrameNumberInPrimaryMemory(int pageNumber)
        {
            return tab.getFrameNumberInPrimaryMemory(pageNumber);
        }

        public int getFrameNumberInSecondaryMemory(int pageNumber)
        {
            return tab.getFrameNumberInSecondaryMemory(pageNumber);
        }


        public void write(int pageNumber)
        {
            tab.setModification(pageNumber);
        }

        public void insertPageInSecondaryMemory(int process_pageNumber, int newFrame)
        {
            tab.insertPageInSecondaryMemory(process_pageNumber, newFrame);
            
        }
        public void insertPageInPrimaryMemory(int process_pageNumber, int newFrame)
        {
            tab.insertPageInMemory(process_pageNumber, newFrame);
        }

        public void read(int pageNumber)
        {

        }

    }
}
   