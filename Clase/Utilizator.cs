using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Situaţii_note_studenţi.Clase
{
    [Serializable]
    class Utilizator
    {
        private string username;
        private string password;

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public Utilizator(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
