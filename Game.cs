using System;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public class Oyun
    {
        // Oyunun grid boyutunu temsil eder
        public int GridSize { get; private set; }

        // Mayın sayısını belirtir
        public int MineCount { get; private set; }

        // Oyuncunun yaptığı hamle sayısını tutar
        public int HamleSayisi { get; private set; }

        // Oyun alanındaki düğmeleri temsil eden matris
        public Button[,] GridButtons { get; private set; }

        // Oyuncu adını tutar
        public string UserName { get; private set; }

        // Skorboard objesi
        public Skorboard Skorboard { get; private set; }

        // Oyun sınıfının kurucusu; grid boyutu, mayın sayısı ve kullanıcı adını alır
        public Oyun(int gridSize, int mineCount, string userName)
        {
            GridSize = gridSize;
            MineCount = mineCount;
            HamleSayisi = 0;
            UserName = userName;
            GridButtons = new Button[gridSize, gridSize];
            Skorboard = new Skorboard();
        }

        // Oyun alanına rastgele mayınlar yerleştirir
        public void PlaceMines()
        {
            // Mayın sayısı, alan boyutundan fazla ise hata verir
            if (MineCount > GridSize * GridSize)
            {
                MessageBox.Show("Mayın sayısı, alan boyutundan fazla olamaz.");
                return;
            }

            Random rand = new Random();
            int minesPlaced = 0;

            // Tüm mayınlar yerleştirilene kadar devam eder
            while (minesPlaced < MineCount)
            {
                int x = rand.Next(GridSize);
                int y = rand.Next(GridSize);

                // Mayın olmayan bir düğmeye mayın ekler
                if (GridButtons[x, y].Tag == null)
                {
                    GridButtons[x, y].Tag = "MAYIN";
                    minesPlaced++;
                }
            }
        }

        // Hamle sayısını sıfırlar
        public void ResetHamleSayisi()
        {
            HamleSayisi = 0;
        }

        // Hamle sayısını bir artırır
        public void IncrementHamleSayisi()
        {
            HamleSayisi++;
        }

        // Oyuncunun kazanma şartını kontrol eder
        public bool CheckWinCondition()
        {
            // Mayın olmayan ve açık olmayan düğme kalıp kalmadığını kontrol eder
            foreach (var button in GridButtons)
            {
                if (button.Tag == null && button.Enabled)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
