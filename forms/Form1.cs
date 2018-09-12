using Situaţii_note_studenţi.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Situaţii_note_studenţi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void adaugaUtilizatoriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "admin" && textBox2.Text.Trim() == "admin")
            {
                Form2 frm = new Form2();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Nu sunteti pe contul de administrator", "Eroare", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void despreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Proiect PAW 2016", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length != 0 && textBox2.Text.Trim().Length != 0)
            {
                Utilizator u1 = new Utilizator(textBox1.Text, textBox2.Text);
                try
                {
                    FileStream f = new FileStream("Utilizatori.dat", FileMode.Open, FileAccess.Read);
                    List<Utilizator> u = new List<Utilizator>();
                    BinaryFormatter bf = new BinaryFormatter();
                    u = (List < Utilizator > )bf.Deserialize(f);
                    f.Close();
                    int ok = 0;
                    foreach(Utilizator m in u)
                    {
                        if (m.Username == u1.Username && m.Password == u1.Password)
                            ok = 1;
                    }
                    if (ok == 1||(textBox1.Text=="admin"&&textBox2.Text=="admin"))
                    {
                        Discipline d = new Discipline();
                        Form3 frm = new Form3(d);
                        frm.ShowDialog();
                        this.Hide();
                        
                    }
                    else
                    {
                        var r=MessageBox.Show("Autentificare esuata, Doriti sa incercati din nou?", "Eroare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.No)
                        { Application.Exit(); }
                    }
                }
                catch(FileNotFoundException ex) { MessageBox.Show("Nu exista utilizatori inregistrati"); }
            }
        }
    }
}
