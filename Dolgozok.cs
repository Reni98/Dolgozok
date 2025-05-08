using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozok
{
    internal class Dolgozok
    {
        public string nev;
        public int kor;
        public string nem;
        public string pozicio;
        public string reszleg;

        public Dolgozok(string nev, string kor, string nem, string pozicio, string reszleg)
        {
            this.nev = nev;
            this.kor = int.Parse(kor);
            this.nem = nem;
            this.pozicio = pozicio;
            this.reszleg = reszleg;
        }
    }
}
