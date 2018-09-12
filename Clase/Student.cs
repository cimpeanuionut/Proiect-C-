using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Situaţii_note_studenţi.Clase
{
    class Student :ICloneable,IComparable
    {
        private int nr_matricol;
        private string nume;
        private string prenume;
        private int an;
        private int grupa;
        private List<String> discip;
        private List<int> note;

        public Student(int nr_matricol, string nume, string prenume, int an, int grupa,List<int> note)
        {
            this.nr_matricol = nr_matricol;
            this.nume = nume;
            this.prenume = prenume;
            this.an = an;
            this.grupa = grupa;
            atribuie_discipline();
            this.Note = note;
        }

        public int Nr_matricol
        {
            get
            {
                return nr_matricol;
            }

            set
            {
                nr_matricol = value;
            }
        }

        public string Nume
        {
            get
            {
                return nume;
            }

            set
            {
                nume = value;
            }
        }

        public string Prenume
        {
            get
            {
                return prenume;
            }

            set
            {
                prenume = value;
            }
        }

        public int An
        {
            get
            {
                return an;
            }

            set
            {
                an = value;
            }
        }

        public int Grupa
        {
            get
            {
                return grupa;
            }

            set
            {
                grupa = value;
            }
        }

        public List<string> Discip
        {
            get
            {
                return discip;
            }

            set
            {
                discip = value;
            }
        }

        public List<int> Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public  void atribuie_discipline()
        {
            if (an == 1)
                Discip = Discipline.Discipline_an1;
            else
                if (an == 2)
                Discip = Discipline.Discipline_an2;
            else
                Discip = Discipline.Discipline_an3;
        }
        public float medie()
            {
            int s = 0;
            for(int i=0;i<Discip.Count;i++)
            {
                if (an == 1)
                    s += Note[i] * Discipline.Credite_an1[i];
                else
                    if(an==2)
                    s+= Note[i] * Discipline.Credite_an2[i];
                else
                   s+= Note[i] * Discipline.Credite_an3[i];
            }
            if (an == 1)
                return ((float)s / Discipline.Credite_an1.Sum());
            else
                    if (an == 2)
                return ((float)s / Discipline.Credite_an2.Sum());
            else
                return ((float)s / Discipline.Credite_an3.Sum());
        }
        public object Clone()
        {
           
            return new Student(this.nr_matricol,this.nume, this.prenume, this.an, this.grupa,this.Note);
        }

        public int CompareTo(object obj)
        {
            if (this.medie() > ((Student)obj).medie())
                return -1;
            else if (this.medie() < ((Student)obj).medie())
                return 1;
            else return String.Compare(this.nume, ((Student)obj).nume);
        }
    }
}
