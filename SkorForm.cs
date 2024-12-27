using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class SkorForm : Form
    {
        // Skorları tutan liste
        private List<Skor> skorlar;

        // Oyunu yeniden başlatma olayı
        public event EventHandler RestartGameRequested;

        // SkorForm yapıcı metodu
        public SkorForm(List<Skor> skorlar)
        {
            InitializeComponent();
            this.skorlar = skorlar;
            LoadScores(); // Skorları yükle
        }

        // Skorları tabloya yükler
        private void LoadScores()
        {
            dataGridView1.Rows.Clear();
            foreach (var skor in skorlar)
            {
                dataGridView1.Rows.Add(skor.UserName, skor.HamleSayisi, skor.SkorPuan);
            }
        }

        // Form yüklendiğinde yapılacak işlemler
        private void SkorForm_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler buraya eklenebilir
        }

        // DataGridView hücresine tıklanma olayı
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // dataGridView hücresine tıklanınca yapılacak işlemler buraya eklenebilir
        }

        // Form yeniden boyutlandırıldığında yapılacak işlemler
        private void SkorForm_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.ClientSize.Width - 40; // sağ ve soldan boşluk bırak
            dataGridView1.Height = this.ClientSize.Height - 100; // alt kenardan boşluk bırak

            // Başlık veya etiket konumlandırma
            label2.Location = new Point((this.ClientSize.Width - label2.Width) / 2, 20);
        }

        // Form yüklendiğinde yapılacak ekstra işlemler
        private void SkorForm_Load_1(object sender, EventArgs e)
        {
            // Ek yüklendiğinde yapılacak işlemler buraya eklenebilir
        }

        // Etiket tıklandığında yapılacak işlemler
        private void label2_Click(object sender, EventArgs e)
        {
            // Etiket tıklama olayında yapılacak işlemler buraya eklenebilir
        }

        // Yeniden başlat butonuna tıklanma olayı
        private void btnRestart_Click(object sender, EventArgs e)
        {
            // RestartGameRequested olayını tetikle
            RestartGameRequested?.Invoke(this, EventArgs.Empty);
            this.Close(); // Skor formunu kapat
        }
    }
}
