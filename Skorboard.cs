using System;
using System.Collections.Generic;
using System.IO;

namespace MayinTarlasi
{
    public class Skorboard
    {
        private List<Skor> skorlar = new List<Skor>();
        private const string FilePath = "skorlar.txt"; // Skorları kaydetmek için dosya yolu

        public Skorboard()
        {
            YükleSkorlar(); // Başlangıçta skorları yükle
        }

        // Yeni skor ekleme metodu
        public void SkorEkle(Skor yeniSkor)
        {
            skorlar.Add(yeniSkor);
            KaydetSkorlar(); // Her yeni skor eklemede kaydet
        }

        // Skorları döndüren metot
        public List<Skor> GetScores()
        {
            return skorlar;
        }

        // Skorları txt dosyasına kaydeden metot
        private void KaydetSkorlar()
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (var skor in skorlar)
                {
                    sw.WriteLine($"{skor.UserName},{skor.HamleSayisi},{skor.SkorPuan}");
                }
            }
        }

        // Txt dosyasından skorları okuyan metot
        private void YükleSkorlar()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string userName = parts[0];
                            int hamleSayisi = int.Parse(parts[1]);
                            int skorPuan = int.Parse(parts[2]);

                            skorlar.Add(new Skor
                            {
                                UserName = userName,
                                HamleSayisi = hamleSayisi,
                                SkorPuan = skorPuan
                            });
                        }
                    }
                }
            }
        }
    }
}
