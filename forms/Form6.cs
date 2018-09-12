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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private List<Student> lista = new List<Student>();
        private List<Student> grupa = new List<Student>();
        Discipline d = new Discipline();
        private void button1_Click(object sender, EventArgs e)
        {
            lista = (List<Student>)this.Tag;
            foreach(Student s in lista)
            {
                if(s.Grupa==Convert.ToInt32(textBox1.Text))
                {
                    grupa.Add(s);
                }
            }
            if (grupa.Count != 0)
            {
                textBox2.Text += grupa[0].Nume + " " + grupa[0].Prenume;
            }
            else MessageBox.Show("Nu exista studenti in aceasta grupa");
        }
        int i = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string[] note = textBox3.Text.Split(' ');
            grupa[i].Note = new List<int>();
            for (int j = 0; j < note.Length; j++)
            { grupa[i].Note.Add(Convert.ToInt32(note[j])); }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            if (i < grupa.Count - 1)
            {
                i++;
                textBox2.Text += grupa[i].Nume + " " + grupa[i].Prenume;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            while(i<grupa.Count)
            {
                for (int j= 0;j < lista.Count;j++)
                    if(lista[j].Nr_matricol==grupa[i].Nr_matricol)
                    {
                        lista[j].Note = new List<int>();
                        lista[j].Note = grupa[i].Note;
                        break;
                    }
                i++;
            }
            Form3 frm = new Form3(d);
            frm.Tag = lista;
            frm.ShowDialog();
            this.Close();

        }
    }
}
