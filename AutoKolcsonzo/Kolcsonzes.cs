using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKolcsonzo
{
    internal class Kolcsonzes
    {
        private int KolcsonzesID;
        private string Auto;
        private int Ar;

        public Kolcsonzes(int kolcsonzesID, string auto, int ar)
        {
            KolcsonzesID = kolcsonzesID;
            Auto = auto;
            Ar = ar;
        }

        public override string ToString()
        {
            return $"{KolcsonzesID};{Auto};{Ar}";
        }
    }
}
