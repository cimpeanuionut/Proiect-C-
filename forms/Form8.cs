using Situaţii_note_studenţi.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Situaţii_note_studenţi.forms
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();

        }

        private void populareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Student> l = new List<Student>();
            l = (List<Student>)this.Tag;
            foreach (Student s in l)
            {
                ListViewItem itm = new ListViewItem(s.Nr_matricol.ToString());

                itm.SubItems.Add(s.Nume);
                itm.SubItems.Add(s.Prenume);
                itm.SubItems.Add(s.An.ToString());
                itm.SubItems.Add(s.Grupa.ToString());
                itm.SubItems.Add(s.medie().ToString());
                listView1.Items.Add(itm);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

    

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int[] X = { 50, 120, 200, 300, 400,500 }; //relative to Left margin
            int Y = 50; //relative to Top margin
            Font F = listView1.Font;
            Brush B = new SolidBrush(listView1.ForeColor);
            for (int J = 0; J < listView1.Columns.Count; J++)
            {
                e.Graphics.DrawString(listView1.Columns[J].Text, F, B, X[J], Y);
            }
            Y += F.Height;
            for (int I = 0; I < listView1.Items.Count; I++)
            {
                for (int J = 0; J < listView1.Items[I].SubItems.Count; J++)
                {
                    e.Graphics.DrawString(listView1.Items[I].SubItems[J].Text, F, B, X[J], Y);
                }
                Y += F.Height;
            }
        }

        public void inaoiLaMeniuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
