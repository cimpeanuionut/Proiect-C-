using Situaţii_note_studenţi.Clase;
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

namespace Situaţii_note_studenţi.forms
{
    public partial class Form5 : Form
    {
        Discipline d = new Discipline();
        public Form5(Discipline d)
        {
            InitializeComponent();
            this.d = d;
        }
       
        List<Student> l = new List<Student>();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
                errorProvider1.SetError(textBox1, "Introduceti un numar matricol");
            else if (textBox2.Text.Trim().Length == 0)
                errorProvider1.SetError(textBox2, "Introduceti numele");
            else if (textBox3.Text.Trim().Length == 0)
                errorProvider1.SetError(textBox3, "Introduceti prenumele");
            else if (Convert.ToInt32(textBox4.Text) < 1 || Convert.ToInt32(textBox4.Text) > 3)
                errorProvider1.SetError(textBox4, "Introduceti o valoare intr 1 si 3");
            else if (textBox5.Text.Trim().Length == 0)
                errorProvider1.SetError(textBox5, "Introduceti grupa");
            else if (textBox6.Text.Trim().Length == 0)
                errorProvider1.SetError(textBox6, "Introduceti notele");
            else
            {
                String[] v = textBox6.Text.Split(' ');
                List<int> n = new List<int>();
                for (int i = 0; i < v.Length; i++)
                { n.Add(Convert.ToInt32(v[i])); }
                Student s = new Student(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), n);
                l.Add(s);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                errorProvider1.Clear();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream("Studenti.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            foreach (Student s in l)
            {
                sw.WriteLine(s.Nr_matricol);
                sw.WriteLine(s.Nume);
                sw.WriteLine(s.Prenume);
                sw.WriteLine(s.An);
                sw.WriteLine(s.Grupa);
                for (int i = 0; i < s.Note.Count; i++)
                {
                    sw.Write(s.Discip[i]);
                    sw.Write(": ");
                    sw.Write(s.Note[i]);
                    sw.WriteLine();
                }
            }
            sw.Close();
            f.Close();
            Form3 frm = new Form3(d);
            frm.Tag = l;
            frm.Show();
            this.Close();
        }

        private void Form5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void Form5_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop,false);
            foreach(string s in files)
            {
                FileStream f = new FileStream(s, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(f);
                    int nr = Convert.ToInt32(sr.ReadLine());
                    string n = sr.ReadLine();
                    string p = sr.ReadLine();
                    int an = Convert.ToInt32(sr.ReadLine());
                    int grupa = Convert.ToInt32(sr.ReadLine());
                    int nr_note;
                    List<int> note = new List<int>();
                    if (an == 1)
                        nr_note = Discipline.Discipline_an1.Count;
                    else if (an == 2)
                        nr_note = Discipline.Discipline_an2.Count;
                    else
                    { nr_note = Discipline.Discipline_an3.Count; }
                    int i = 0;
                    while (i < nr_note)
                    {
                        string[] unit = sr.ReadLine().Trim().Split(':');
                        note.Add(Convert.ToInt32(unit[1]));
                        i++;
                    }
                    l.Add(new Student(nr, n, p, an, grupa, note));
                sr.Close();
                f.Close();
                
            }
        }
    }
}
