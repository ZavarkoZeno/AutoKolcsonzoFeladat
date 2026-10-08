using System;
using System.Collections.Generic;
using System.Text;

namespace AutoKolcsonzo
{
    internal class HelybenKolcsonzes : Kolcsonzes
    {
        private int TelephelySzam;

        public HelybenKolcsonzes(
            int kolcsonzesID,
            string auto,
            int ar,
            int telephelySzam) : base(kolcsonzesID, auto, ar)
        {
            TelephelySzam = telephelySzam;
        }

        public override string ToString()
        {
            return "H;" + base.ToString() + $";{TelephelySzam}";
        }
    }
}
