using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKolcsonzo
{
    internal class Auto
    {
        private string Nev { get; set; }

        public int Ar { get; private set; }

        public Auto(string nev, int ar)
        {
            Nev = nev;
            Ar = ar;
        }

        public override bool Equals(object? obj)
        {
            return obj != null && ((Auto)obj).Nev == Nev;
        }
    }
}
