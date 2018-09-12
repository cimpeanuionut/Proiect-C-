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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        List<Utilizator> u = new List<Utilizator>();
        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text.Trim().Length!=0)&&(textBox2.Text.Trim().Length!=0))
            {
                
                Utilizator u1 = new Utilizator(textBox1.Text, textBox2.Text);
                u.Add(u1);
                
                
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream("Utilizatori.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, u);
            f.Close();
            this.Close();
        }
    }
}
