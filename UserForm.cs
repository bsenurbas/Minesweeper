using System;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class UserForm : Form
    {
        // Kullanıcı adı, grid boyutu ve mayın sayısı bilgilerini tutar
        public string UserName { get; private set; }
        public int GridSize { get; private set; }
        public int MineCount { get; private set; }

        // UserForm yapıcı metodu
        public UserForm()
        {
            InitializeComponent();
        }

        // Label tıklama olayı (gerekirse işlem eklenebilir)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Kullanıcı adı alanındaki değişiklikleri dinler
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Form yüklendiğinde yapılacak işlemler
        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        // Label tıklama olayı (gerekirse işlem eklenebilir)
        private void label3_Click(object sender, EventArgs e)
        {

        }

        // Grid boyutu alanında yapılan değişiklikleri dinler
        private void numGridBoyutu_ValueChanged(object sender, EventArgs e)
        {

        }

        // Başlat butonuna tıklanma olayı
        private void btnBasla_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı doğrulaması
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                UserName = txtUserName.Text; // Kullanıcı adını al
                GridSize = (int)numGridBoyutu.Value; // Grid boyutunu al
                MineCount = (int)numMayinSayisi.Value; // Mayın sayısını al

                this.DialogResult = DialogResult.OK; // Form sonucunu OK olarak ayarla
                this.Close(); // Formu kapat
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı adı giriniz."); // Kullanıcıya uyarı göster
            }
        }

        // Label tıklama olayı (gerekirse işlem eklenebilir)
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
