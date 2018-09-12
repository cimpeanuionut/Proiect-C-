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

namespace Situaţii_note_studenţi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Discipline.Discipline_an1 = new List<string>();
            Discipline.Credite_an1 = new List<int>();
            Discipline.Discipline_an2 = new List<string>();
            Discipline.Credite_an2 = new List<int>();
            Discipline.Discipline_an3 = new List<string>();
            Discipline.Credite_an3 = new List<int>();
            
        }
        Discipline d = new Discipline();
        private void button1_Click(object sender, EventArgs e)
        {

            Discipline.Discipline_an1.Add(textBox1.Text);
            Discipline.Credite_an1.Add(Convert.ToInt32(textBox4.Text));
            textBox1.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Discipline.Discipline_an2.Add(textBox6.Text);
            Discipline.Credite_an2.Add(Convert.ToInt32(textBox5.Text));
            textBox6.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Discipline.Discipline_an3.Add(textBox3.Text);
            Discipline.Credite_an3.Add(Convert.ToInt32(textBox2.Text));
            textBox3.Clear();
            textBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream("Disc1.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(f);
            for(int i=0;i<Discipline.Credite_an1.Count;i++)
            {
                sw.WriteLine(Discipline.Discipline_an1[i]);
                sw.WriteLine(Discipline.Credite_an1[i]);
            }
            sw.Close();
            f.Close();
            f = new FileStream("Disc2.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(f);
            for (int i = 0; i < Discipline.Credite_an2.Count; i++)
            {
                sw.WriteLine(Discipline.Discipline_an2[i]);
                sw.WriteLine(Discipline.Credite_an2[i]);
            }
            sw.Close();
            f.Close();
            f = new FileStream("Disc3.txt", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(f);
            for (int i = 0; i < Discipline.Credite_an3.Count; i++)
            {
                sw.WriteLine(Discipline.Discipline_an3[i]);
                sw.WriteLine(Discipline.Credite_an3[i]);
            }
            sw.Close();
            f.Close();
            Form3 frm = new Form3(d);
            frm.ShowDialog();
            this.Close();
        }
        
    }
}
