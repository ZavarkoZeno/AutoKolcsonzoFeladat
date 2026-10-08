namespace AutoKolcsonzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "input.txt";
            string[] sorok = File.ReadAllLines(path);
            List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();

            foreach (var sor in sorok)
            {
                string[] darabok = sor.Split(";");
                string tip = darabok[0];
                int kolcsonzesID = int.Parse(darabok[1]);
                string auto = darabok[2];
                int ar = int.Parse(darabok[3]);


                if (tip == "H")
                {
                    int telephelySzam = int.Parse(darabok[4]);

                    kolcsonzesek.Add(
                        new HelybenKolcsonzes(
                            kolcsonzesID,
                            auto,
                            ar,
                            telephelySzam
                        )
                    );
                }
                else if (tip == "K")
                {
                    string cim = darabok[4];
                    string sofor = darabok[5];
                    kolcsonzesek.Add(
                        new KiszallitottKolcsonzes(
                            kolcsonzesID,
                            auto,
                            ar,
                            cim,
                            sofor
                        )
                    );
                }
            }

            Console.WriteLine("-------- Kölcsönzések --------");

            foreach (var kolcsonzes in kolcsonzesek)
            {
                Console.WriteLine(kolcsonzes);
            }

            List<Kolcsonzes> helyben = new List<Kolcsonzes>();

            foreach (var item in kolcsonzesek)
            {
                if (item is HelybenKolcsonzes)
                {
                    helyben.Add(item);
                }
            }

            List<Kolcsonzes> kiszallitas = new List<Kolcsonzes>();

            foreach (var item in kolcsonzesek)
            {
                if (item is KiszallitottKolcsonzes)
                {
                    kiszallitas.Add(item);
                }
            }

            List<Auto> Autok = new List<Auto>();

            sorok = File.ReadAllLines("autok.txt");

            foreach (var item in sorok)
            {
                string[] darabok = item.Split(',');

                Autok.Add(
                    new Auto(
                        darabok[0],
                        int.Parse(darabok[1])
                    )
                );
            }

            Console.WriteLine();

            Console.WriteLine(
                "-------- Üdvözöljük az autókölcsönzőben --------"
            );

            Console.WriteLine(
                "Melyik autót szeretné kibérelni?"
            );

            string kivalasztottAuto = Console.ReadLine();
            int osszeg = 0;
            if (Autok.Contains(new Auto(kivalasztottAuto, 0)))
            {
                osszeg = Autok[
                    Autok.IndexOf(
                        new Auto(kivalasztottAuto, 0)
                    )
                ].Ar;

                Console.WriteLine(
                    $"Az autó ára: {osszeg} Ft"
                );
            }
            else
            {
                Console.WriteLine(
                    $"Nem található ilyen autó: {kivalasztottAuto}"
                );

                return;
            }

            Console.WriteLine();

            Console.WriteLine(
                "Hogyan szeretné átvenni az autót?"
            );

            Console.WriteLine(
                "1 - Helyben"
            );

            Console.WriteLine(
                "2 - Kiszállítással"
            );

            string tipus = Console.ReadLine();
            int ujID = kolcsonzesek.Count + 1;
            Kolcsonzes ujKolcsonzes;


            if (tipus == "1")
            {
                Console.WriteLine(
                    "Adja meg a telephely számát:"
                );

                int telephelySzam = int.Parse(
                    Console.ReadLine()
                );

                ujKolcsonzes = new HelybenKolcsonzes(
                    ujID,
                    kivalasztottAuto,
                    osszeg,
                    telephelySzam
                );
            }
            else if (tipus == "2")
            {
                Console.WriteLine(
                    "Adja meg a kiszállítási címet:"
                );

                string cim = Console.ReadLine();

                Console.WriteLine(
                    "Adja meg a sofőr nevét:"
                );

                string sofor = Console.ReadLine();

                ujKolcsonzes = new KiszallitottKolcsonzes(
                    ujID,
                    kivalasztottAuto,
                    osszeg,
                    cim,
                    sofor
                );
            }
            else
            {
                Console.WriteLine(
                    "Hibás választás!"
                );

                return;
            }

            kolcsonzesek.Add(ujKolcsonzes);

            helyben = new List<Kolcsonzes>();
            kiszallitas = new List<Kolcsonzes>();

            foreach (var item in kolcsonzesek)
            {
                if (item is HelybenKolcsonzes)
                {
                    helyben.Add(item);
                }
                else if (item is KiszallitottKolcsonzes)
                {
                    kiszallitas.Add(item);
                }
            }

            File.WriteAllText(
                "helyben.txt",
                String.Join("\n", helyben)
            );

            File.WriteAllText(
                "kiszallitas.txt",
                String.Join("\n", kiszallitas)
            );

            Console.WriteLine();

            Console.WriteLine(
                "-------- Új kölcsönzés --------"
            );

            Console.WriteLine(
                ujKolcsonzes
            );

            Console.WriteLine();

            Console.WriteLine(
                $"Fizetendő összeg: {osszeg} Ft"
            );
        }
    }
}