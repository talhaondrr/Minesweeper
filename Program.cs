using System;

namespace MayinTarlasi;

internal class Program
{
    private const int Boyut = 6;
    private const int MayinAdedi = 5;

    private static void Main()
    {
        bool[,] mayinlar = new bool[Boyut, Boyut];
        bool[,] acilanlar = new bool[Boyut, Boyut];
        Random random = new Random();
        int yerlestirilen = 0;

        // Her satırda ve sütunda en fazla bir mayın.
        while (yerlestirilen < MayinAdedi)
        {
            int satir = random.Next(Boyut);
            int sutun = random.Next(Boyut);
            bool uygun = true;

            for (int i = 0; i < Boyut; i++)
            {
                if (mayinlar[satir, i] || mayinlar[i, sutun])
                {
                    uygun = false;
                    break;
                }
            }

            if (uygun)
            {
                mayinlar[satir, sutun] = true;
                yerlestirilen++;
            }
        }

        Console.WriteLine("6x6 MAYIN TARLASI - 5 MAYIN");
        Console.WriteLine("Satır ve sütun: 1 ile 6 arasında. Mayına basmadan 31 kareyi açın.");
        int guvenliAcildi = 0;

        while (true)
        {
            TahtayiGoster(acilanlar, mayinlar, false);
            int satir = KoordinatOku("Satır (1-6): ") - 1;
            int sutun = KoordinatOku("Sütun (1-6): ") - 1;

            if (acilanlar[satir, sutun])
            {
                Console.WriteLine("Bu kareyi zaten açtınız.");
                continue;
            }

            acilanlar[satir, sutun] = true;
            if (mayinlar[satir, sutun])
            {
                Console.WriteLine("Mayına bastınız! Oyun bitti.");
                TahtayiGoster(acilanlar, mayinlar, true);
                break;
            }

            guvenliAcildi++;
            int komsuMayin = KomsuMayinSay(mayinlar, satir, sutun);
            Console.WriteLine($"Güvenli kare. Komşu mayın sayısı: {komsuMayin}");

            if (guvenliAcildi == Boyut * Boyut - MayinAdedi)
            {
                Console.WriteLine("Tebrikler! Tüm güvenli kareleri açtınız.");
                TahtayiGoster(acilanlar, mayinlar, true);
                break;
            }
        }
    }

    private static int KoordinatOku(string mesaj)
    {
        while (true)
        {
            Console.Write(mesaj);
            if (int.TryParse(Console.ReadLine(), out int sonuc) && sonuc >= 1 && sonuc <= Boyut)
                return sonuc;
            Console.WriteLine("1 ile 6 arasında sayı girin.");
        }
    }

    private static int KomsuMayinSay(bool[,] mayinlar, int satir, int sutun)
    {
        int sayac = 0;
        for (int i = Math.Max(0, satir - 1); i <= Math.Min(Boyut - 1, satir + 1); i++)
            for (int j = Math.Max(0, sutun - 1); j <= Math.Min(Boyut - 1, sutun + 1); j++)
                if (mayinlar[i, j]) sayac++;
        return sayac;
    }

    private static void TahtayiGoster(bool[,] acilanlar, bool[,] mayinlar, bool tumunuGoster)
    {
        Console.WriteLine("     1  2  3  4  5  6");
        for (int i = 0; i < Boyut; i++)
        {
            Console.Write($" {i + 1}   ");
            for (int j = 0; j < Boyut; j++)
            {
                string isaret = "#";
                if (mayinlar[i, j] && tumunuGoster) isaret = "*";
                else if (acilanlar[i, j] && mayinlar[i, j]) isaret = "*";
                else if (acilanlar[i, j]) isaret = KomsuMayinSay(mayinlar, i, j).ToString();
                Console.Write(isaret + "  ");
            }
            Console.WriteLine();
        }
    }
}
