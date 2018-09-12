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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        List<Student> l = new List<Student>();
        Discipline d = new Discipline();
        private void button1_Click(object sender, EventArgs e)
        {
            
            l = (List<Student>)this.Tag;
            foreach (Student s in l)
            {
                if (s.Nr_matricol == Convert.ToInt32(textBox1.Text))
                {
                    textBox2.Text += s.Nume;
                    textBox3.Text += s.Prenume;
                    textBox4.Text += s.An;
                    textBox5.Text += s.Grupa;
                    foreach (int i in s.Note)
                    { textBox6.Text += i + " "; }
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            l = (List<Student>)this.Tag;
            for(int i=0;i<l.Count;i++)
            {
                if (l[i].Nr_matricol == Convert.ToInt32(textBox1.Text))
                {
                    l[i].Note = new List<int>();
                    string[] note = textBox6.Text.Split(' ');
                    foreach(string j in note)
                    {
                        l[i].Note.Add(Convert.ToInt32(j));
                    }
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(d);
            frm.Tag = l;
            frm.ShowDialog();
            this.Close();

        }
    }
}
