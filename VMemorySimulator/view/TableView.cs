using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMemorySimulator.model;

namespace VMemorySimulator.view
{
    public class TableView : TabControl
    {
        public TableView()
        {
}

        public void registerSwap(string newProcess, int newPageNumber, string process, int PageNumber)
        {
            ((ListView)TabPages[0].Controls[0]).Items.Add(newProcess + newPageNumber + process + PageNumber);
        }


        public static void setup(Process process)
        {
            /*TabPage tabpage = new TabPage();
            tabpage.Text = process.name;

            ListView tabela = new ListView();
            tabela.View = View.Details;
            
            tabela.Columns.Add("Page");
            tabela.Columns.Add("V");
            tabela.Columns.Add("M");
            tabela.Columns.Add("Frame");
            foreach(ColumnHeader col in tabela.Columns)
            {
                col.Width = this.Width / 4;
                col.TextAlign = HorizontalAlignment.Center;
            }
            tabela.Size = this.Size;

            for (int i = 0; i < process.size; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(process.tab.getValidity(i).ToString());
                item.SubItems.Add(process.tab.getModification(i).ToString());
                try {
                    item.SubItems.Add(process.tab.getFrameNumber(i).ToString());
                }
                catch(Exception e)
                {

                }
                tabela.Items.Add(item);
            }

            
            tabpage.Controls.Add(tabela);

            this.TabPages.Add(tabpage);
            */
        }



    }
}
