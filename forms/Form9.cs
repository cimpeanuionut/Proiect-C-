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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private float medie_grupa(List<Student> l5,int grupa)
        {
            float s = 0, nr = 0;
            foreach(Student m in l5)
            {
                if(m.Grupa==grupa)
                {
                    s += m.medie();
                    nr++;
                }
            }
            return (float)s / nr;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Student> l = new List<Student>();
            l = (List<Student>)this.Tag;
            Dictionary<int, float> d = new Dictionary<int, float>();
            foreach(Student s in l)
            {
                if (!d.ContainsKey(s.Grupa))
                { d[s.Grupa] = medie_grupa(l, s.Grupa); }
            }
            foreach(KeyValuePair<int,float> k in d)
            {
                this.chart1.Series["Medie"].Points.AddXY(k.Key, k.Value);
            }
            chart1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = Application.OpenForms.OfType<Form3>().FirstOrDefault();
            if (form != null)
            {
                form.button8_Click(this, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
