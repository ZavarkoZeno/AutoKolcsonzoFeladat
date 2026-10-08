using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKolcsonzo
{
    internal class KiszallitottKolcsonzes : Kolcsonzes
    {
        private string Cim;
        private string Sofor;

        public KiszallitottKolcsonzes(
            int kolcsonzesID,
            string auto,
            int ar,
            string cim,
            string sofor) : base(kolcsonzesID, auto, ar)
        {
            Cim = cim;
            Sofor = sofor;
        }

        public override string ToString()
        {
            return "K;" + base.ToString() + $";{Cim};{Sofor}";
        }
    }
}
