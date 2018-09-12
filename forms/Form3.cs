using Situaţii_note_studenţi.Clase;
using Situaţii_note_studenţi.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Situaţii_note_studenţi
{
    public partial class Form3 : Form
    {
        public Form3(Discipline d)
        {
            InitializeComponent();
        }
        Discipline d = new Discipline();
        List<Student> lista_import = new List<Student>();
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5(d);
            frm.ShowDialog();
            this.Hide();
        }
        private void initializare_discip()
        {
            Discipline.Discipline_an1 = new List<string>();
            Discipline.Credite_an1 = new List<int>();
            Discipline.Discipline_an2 = new List<string>();
            Discipline.Credite_an2 = new List<int>();
            Discipline.Discipline_an3 = new List<string>();
            Discipline.Credite_an3 = new List<int>();
        }
        private void disciplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initializare_discip();
            FileStream f = new FileStream("Disc1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            string[] tot = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < tot.Length; i=i+2)
            {
                if (tot[i].Length != 0)
                {
                    string[] unit = tot[i].Split('\r');
                    Discipline.Discipline_an1.Add(unit[0]);
                    Discipline.Credite_an1.Add(Convert.ToInt32(tot[i + 1]));
                }
            }
            sr.Close();
            f.Close();
           f = new FileStream("Disc2.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(f);
            tot = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < tot.Length; i = i + 2)
            {
                if (tot[i].Length != 0)
                {
                    string[] unit = tot[i].Split('\r');
                    Discipline.Discipline_an2.Add(unit[0]);
                    Discipline.Credite_an2.Add(Convert.ToInt32(tot[i + 1]));
                }
            }
            sr.Close();
            f.Close();
            f = new FileStream("Disc3.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(f);
            tot = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < tot.Length; i = i + 2)
            {
                if (tot[i].Length != 0)
                {
                    string[] unit = tot[i].Split('\r');
                    Discipline.Discipline_an3.Add(unit[0]);
                    Discipline.Credite_an3.Add(Convert.ToInt32(tot[i + 1]));
                }
            }
            sr.Close();
            f.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Student> l = new List<Student>();
            if (this.Tag != null)
            { l = (List<Student>)this.Tag; }
            foreach (Student s in lista_import)
            { l.Add(s); }
            Form6 frm = new Form6();
            frm.Tag = l;
            frm.ShowDialog();
            this.Close();

        }
        
        private void studentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream("Studenti.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(f);
            while(!sr.EndOfStream)
            {
                int nr = Convert.ToInt32(sr.ReadLine());
                string n = sr.ReadLine();
                string p = sr.ReadLine();
                int an = Convert.ToInt32(sr.ReadLine());
                int grupa = Convert.ToInt32(sr.ReadLine());
                int nr_note;
                List<int> note=new List<int>();
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
                lista_import.Add(new Student(nr, n, p, an, grupa, note));

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Student> l3 = new List<Student>();
            if (this.Tag != null)
            { l3 = (List<Student>)this.Tag; }
            if(lista_import.Count!=0)
            {
                foreach(Student s in lista_import)
                {
                    l3.Add(s);
                }
            }
            Form8 frm = new Form8();
            l3.Sort();
            frm.Tag = l3;
            frm.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Student> l3 = new List<Student>();
            if (this.Tag != null)
            { l3 = (List<Student>)this.Tag; }
            if (lista_import.Count != 0)
            {
                foreach (Student s in lista_import)
                {
                    l3.Add(s);
                }
            }
            Form7 frm = new Form7();
            frm.Tag = l3;
            frm.ShowDialog();
            this.Close();
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                button3_Click(this, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Student> l3 = new List<Student>();
            if (this.Tag != null)
            { l3 = (List<Student>)this.Tag; }
            if (lista_import.Count != 0)
            {
                foreach (Student s in lista_import)
                {
                    l3.Add(s);
                }
            }
            OleDbConnection conn = AccessConnection.GetConnection();
            //string query = "insert into Studenti(Numar_Matricol, Nume, Prenume, An, Grupa, Note) " +
            //               "values([nr], [n], [p], [an], [g], [note]);";
            foreach(Student s in l3)
            {
                StringBuilder sb = new StringBuilder();
                {
                    foreach (int i in s.Note)
                    {
                        sb.Append(i);
                        if (i != s.Note[s.Note.Count - 1])
                        { sb.Append(","); }
                    }
                }
                string query = "insert into Studenti([Numar_Matricol], [Nume], [Prenume], [An], [Grupa], [Note]) " +
                             "values('"+s.Nr_matricol+"','"+s.Nume+"','"+s.Prenume+"','"+s.An+"','"+s.Grupa+"','"+sb.ToString()+ "')";
                OleDbCommand command = new OleDbCommand(query, conn);
                    command.ExecuteNonQuery();
                  
            }
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Student> l3 = new List<Student>();
            if (this.Tag != null)
            { l3 = (List<Student>)this.Tag; }
            if (lista_import.Count != 0)
            {
                foreach (Student s in lista_import)
                {
                    l3.Add(s);
                }
            }
            Form9 frm = new Form9();
            frm.Tag = l3;
            frm.ShowDialog();
        }

        public void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
