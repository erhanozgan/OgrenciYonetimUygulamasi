using System;
using System.Collections.Generic;
using System.Globalization;


namespace OgrenciYonetimUygulamasi
{
    class MainClass
    {
        //Listemizi Tanımlıyoruz...
        static List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        static int say= 0;
        static int siraNo = 1;

        public static void Main(string[] args)
        {
            Uygulama();
        }


        static void Uygulama()
        {
            Menu();
            while (true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                    case "E":
                        OgrenciEkle();
                        break;
                    case "2":
                    case "L":
                        OgrenciListele();
                        break;
                    case "3":
                    case "S":
                        OgrenciSil();
                        break;
                    case "4":
                    case "X":
                        Environment.Exit(0);
                        break;

                }
            }
        }

        static string SecimAl()
        {
            Console.Write("Seçiminiz: ");
            string giris = Console.ReadLine().ToUpper();
            if (giris == "1" || giris == "E" || giris == "2" || giris == "L" || giris == "3" || giris == "S" || giris == "4" || giris == "X")
            {
            }
            else
            {
                say++;
                Console.WriteLine($"{say} Hatalı giriş yapıldı.");
                    
            }
            if (say==10)
            {
                Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                Environment.Exit(0);
            }
            return giris;
        }

        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle(E)");
            Console.WriteLine("2 - Öğrenci Listele(L)");
            Console.WriteLine("3 - Öğrenci Sil(S)");
            Console.WriteLine("4 - Çıkış(X)");
            Console.WriteLine("");

        }

        static void OgrenciSil()
        {

            Console.WriteLine("3- Öğrenci Sil---------");
            Console.Write("Öğrencinin No'sunu Giriniz: ");

            int ogrenciNo = int.Parse(Console.ReadLine());

            Ogrenci ogr = null;

            foreach (Ogrenci item in Ogrenciler)
            {
                if (ogrenciNo == item.No)
                {
                    ogr = item;
                    break;
                }
            }
            if (ogr != null)
            {
                Console.WriteLine("Adı: " + ogr.Ad);
                Console.WriteLine("Soyadı: " + ogr.Soyad);
                Console.WriteLine("Şubesi: " + ogr.Sube);
                Console.Write($"{ogrenciNo} numaralı öğrenciyi silmek istediğinize emin misiniz? (E/H)");
                string secim = Console.ReadLine();
                if (secim.ToUpper() == "E")
                {
                    Ogrenciler.Remove(ogr);
                    Console.WriteLine("Öğrenci Silinmiştir");
                    Console.WriteLine("------------------->");

                }
                else
                {
                    Console.WriteLine("Silme işlemi iptal edildi!");
                    Console.WriteLine("------------------->");

                }
            }
            else
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");

            }


        }

        static void OgrenciListele()
        {

            Console.WriteLine("2- Öğrenci Listele--------");
            Console.WriteLine("");
            Console.WriteLine($"Şube          No          Ad Soyad");
            Console.WriteLine($"-----------------------------------");
            int kayitSayisi = Ogrenciler.Count;
            if (kayitSayisi == 0)
            {
                Console.WriteLine("Listelenecek Öğrenci Bulunamadı.");
            }
            else
            {
                foreach (Ogrenci item in Ogrenciler)
                {

                    Console.WriteLine($"{item.Sube}        {item.No}        {item.Ad} {item.Soyad}");

                }
            }
            
        }

        static void SahteVeriGir()
        {

            Ogrenci o1 = new Ogrenci();

            o1.No = 1;
            o1.Ad = "Erhan";
            o1.Soyad = "Özğan";
            o1.Sube = "Maltepe";

            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Alya";
            o2.Soyad = "Özğan";
            o2.No = 2;
            o2.Sube = "Maltepe";

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Derya";
            o3.Soyad = "Özğan";
            o3.No = 3;
            o3.Sube = "Maltepe";


            Ogrenciler.Add(o1);
            Ogrenciler.Add(o2);
            Ogrenciler.Add(o3);

        }

        static void OgrenciEkle()
        {
            Ogrenci o1 = new Ogrenci();

            Console.WriteLine("1- Öğrenci Ekle----------");
            Console.WriteLine($"{siraNo}. Öğrencinin");
            Console.Write("No: ");

            o1.No = int.Parse(Console.ReadLine());
            foreach (var item in Ogrenciler)
            {
                if (item.No == o1.No)
                {
                    Console.WriteLine($"{item.No} Numaralı öğrenci daha önce eklenmiştir! Lütfen yeni bir numara ekleyiniz.");
                    return;
                }
            }
            Console.Write("Adı: ");
            o1.Ad = Console.ReadLine();
            o1.Ad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(o1.Ad);
            Console.Write("Soyadı: ");
            o1.Soyad = Console.ReadLine();
            o1.Soyad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(o1.Soyad);
            Console.Write("Şubesi: ");
            o1.Sube = Console.ReadLine();
            o1.Sube = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(o1.Sube);
            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)");
            string secim = Console.ReadLine();



            if (secim.ToUpper() == "E")
            {
                
                Ogrenciler.Add(o1);//Ekleme Yaptık
                Console.WriteLine("Öğrenci Eklenmiştir");
                Console.WriteLine("------------------->");
                siraNo++;

            }
            else if (secim.ToUpper() == "H")
            {
                Console.WriteLine("Öğrenci Eklenmedi");
                Console.WriteLine("------------------->");

            }

        }

    }
}
