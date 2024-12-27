using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        // Oyun sınıfını temsil eder
        private Oyun oyun;

        // Zamanlayıcı ve süre değişkenleri
        private Timer oyunTimer; // Zamanlayıcı
        private int sure; // Süre (saniye cinsinden)

        // Form1 sınıfının kurucusu
        public Form1()
        {
            InitializeComponent();

            // Form ayarları
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(600, 400);
            this.Resize += new System.EventHandler(this.Form1_Resize);

            // Timer ayarları (oyunTimer nesnesini burada başlatıyoruz)
            oyunTimer = new Timer();
            oyunTimer.Interval = 1000; // Her 1 saniyede bir tetiklenecek
            oyunTimer.Tick += OyunTimer_Tick; // Tick olayını bağla

            StartGame();
        }

        // Timer tick olayı
        private void OyunTimer_Tick(object sender, EventArgs e)
        {
            sure++; // Süreyi bir saniye artır
        }

        // Form yeniden boyutlandırıldığında grid panelini yeniden ayarlar
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (gridPanel != null)
            {
                gridPanel.Width = this.ClientSize.Width - 200; // Sağdaki kontrol paneline göre ayarlayın
                gridPanel.Height = this.ClientSize.Height - 50; // Alt kenar boşluğu
            }
        }

        // Oyunu başlatır ve ayarları kullanıcıdan alır
        private void StartGame()
        {
            // UserForm'u aç
            using (UserForm userForm = new UserForm())
            {
                if (userForm.ShowDialog() == DialogResult.OK)
                {
                    // Kullanıcıdan alınan değerleri oyun ayarlarına aktar
                    int gridSize = userForm.GridSize;
                    int mineCount = userForm.MineCount;
                    string userName = userForm.UserName;

                    oyun = new Oyun(gridSize, mineCount, userName);

                    // Responsive grid oluştur
                    CreateGrid();
                    oyun.PlaceMines();

                    // Süreyi sıfırlayın ve timer'ı başlatın
                    sure = 0;
                    oyunTimer.Start();
                }
                else
                {
                    // Eğer form kapanırsa uygulamayı sonlandırabiliriz veya kullanıcıya bir uyarı verebiliriz
                    MessageBox.Show("Oyun başlatılmadı.");
                    this.Close();
                }
            }
        }

        // Oyun gridini temsil eden panel
        private TableLayoutPanel gridPanel;

        // Grid yapısını oluşturur
        private void CreateGrid()
        {
            // Eski grid panelini temizleyin
            if (gridPanel != null)
            {
                this.Controls.Remove(gridPanel);
                gridPanel.Dispose();
                gridPanel = null;
            }

            gridPanel = new TableLayoutPanel
            {
                RowCount = oyun.GridSize,
                ColumnCount = oyun.GridSize,
                Dock = DockStyle.Fill,
                Location = new Point(20, 20),
                Margin = new Padding(20),
                BackColor = Color.LightSkyBlue
            };

            // Satır ve sütun boyutlarını yüzde olarak ayarlamadan önce eski stilleri temizleyin
            gridPanel.RowStyles.Clear();
            gridPanel.ColumnStyles.Clear();

            for (int i = 0; i < oyun.GridSize; i++)
            {
                gridPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / oyun.GridSize));
                gridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / oyun.GridSize));
            }

            // Her hücreye buton ekleyin
            for (int i = 0; i < oyun.GridSize; i++)
            {
                for (int j = 0; j < oyun.GridSize; j++)
                {
                    Button btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.FromArgb(231, 167, 208),
                        FlatStyle = FlatStyle.Standard,
                        Margin = new Padding(1)
                    };
                    btn.MouseDown += HucreTiklandi;
                    gridPanel.Controls.Add(btn, j, i); // Satır-sütun sırası j, i olarak veriliyor
                    oyun.GridButtons[i, j] = btn; // Grid button referansı ekleniyor
                }
            }

            // Paneli formun içine ekleyin
            this.Controls.Add(gridPanel);
        }

        // Hücre tıklama olayı
        private void HucreTiklandi(object sender, MouseEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int x = -1, y = -1;

            // Tıklanan hücreyi bul
            for (int i = 0; i < oyun.GridSize; i++)
            {
                for (int j = 0; j < oyun.GridSize; j++)
                {
                    if (oyun.GridButtons[i, j] == clickedButton)
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }

            if (x == -1 || y == -1) return;

            if (e.Button == MouseButtons.Right)
            {
                if (clickedButton.Text == "🚩")
                {
                    clickedButton.Text = ""; // Bayrağı kaldır
                }
                else
                {
                    clickedButton.Text = "🚩"; // Bayrak koy
                    clickedButton.BackColor = Color.FromArgb(255, 107, 107);
                    clickedButton.ForeColor = Color.White;
                }
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                oyun.IncrementHamleSayisi(); // Hamle sayısını artır

                if (clickedButton.Tag != null && clickedButton.Tag.ToString() == "MAYIN")
                {
                    MessageBox.Show("Mayına bastınız, oyun bitti!");
                    ShowAllMines();
                    OyunuBitir(false);
                }
                else
                {
                    int mineCount = CountAdjacentMines(x, y);
                    clickedButton.Enabled = false;

                    if (mineCount == 0)
                    {
                        clickedButton.BackColor = Color.FromArgb(237, 233, 194);
                        clickedButton.ForeColor = Color.FromArgb(209, 96, 96);
                        clickedButton.Text = "";
                        RevealAdjacentSafeCells(x, y);
                    }
                    else
                    {
                        clickedButton.BackColor = Color.FromArgb(237, 233, 194);
                        clickedButton.ForeColor = Color.FromArgb(209, 96, 96);
                        clickedButton.Text = mineCount.ToString();
                    }

                    if (CheckWinCondition())
                    {
                        MessageBox.Show("Tebrikler, oyunu kazandınız!");
                        OyunuBitir(true);
                    }
                }
            }
        }

        // Oyunu kazanıp kazanmadığını kontrol eder
        private bool CheckWinCondition()
        {
            foreach (var button in oyun.GridButtons)
            {
                if (button.Tag == null && button.Enabled)
                {
                    return false;
                }
            }
            return true;
        }

        // Belirli bir hücrenin çevresindeki mayınları sayar
        private int CountAdjacentMines(int x, int y)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;
                    if (newX >= 0 && newY >= 0 && newX < oyun.GridSize && newY < oyun.GridSize)
                    {
                        if (oyun.GridButtons[newX, newY].Tag != null && oyun.GridButtons[newX, newY].Tag.ToString() == "MAYIN")
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        // Oyunu sonlandırır
        private void OyunuBitir(bool kazandi)
        {
            oyunTimer.Stop(); // Süreyi durdur

            int dogruBayrakSayisi = DogruBayrakSayisi(); // Doğru işaretlenmiş mayın sayısını al
            int skor = HesaplaSkor(dogruBayrakSayisi, sure); // Skoru hesapla

            int skorPuan = kazandi ? skor : 0; // Eğer kazanılmışsa skor geçerli olsun
            oyun.Skorboard.SkorEkle(new Skor { UserName = oyun.UserName, HamleSayisi = oyun.HamleSayisi, SkorPuan = skorPuan });

            SkorForm skorForm = new SkorForm(oyun.Skorboard.GetScores());
            skorForm.ShowDialog();
        }

        // Skor hesaplar
        private int HesaplaSkor(int dogruBayrakSayisi, int sure)
        {
            if (sure == 0) return 0; // Süre 0 ise, bölme hatasından kaçınmak için 0 döndür
            return (int)((dogruBayrakSayisi / (double)sure) * 1000);
        }

        // Doğru yerleştirilen bayrakları sayar
        private int DogruBayrakSayisi()
        {
            int dogruBayrak = 0;

            for (int i = 0; i < oyun.GridSize; i++)
            {
                for (int j = 0; j < oyun.GridSize; j++)
                {
                    Button btn = oyun.GridButtons[i, j];
                    if (btn.Text == "🚩" && btn.Tag != null && btn.Tag.ToString() == "MAYIN")
                    {
                        dogruBayrak++;
                    }
                }
            }
            return dogruBayrak;
        }

        // Güvenli hücreleri açar
        private void RevealAdjacentSafeCells(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;
                    if (newX >= 0 && newY >= 0 && newX < oyun.GridSize && newY < oyun.GridSize)
                    {
                        Button adjacentButton = oyun.GridButtons[newX, newY];
                        if (adjacentButton.Enabled)
                        {
                            int adjacentMines = CountAdjacentMines(newX, newY);
                            adjacentButton.BackColor = Color.FromArgb(237, 233, 194);
                            adjacentButton.ForeColor = Color.FromArgb(209, 96, 96);
                            adjacentButton.Text = adjacentMines == 0 ? "" : adjacentMines.ToString();
                            adjacentButton.Enabled = false;
                            if (adjacentMines == 0)
                            {
                                RevealAdjacentSafeCells(newX, newY);
                            }
                        }
                    }
                }
            }
        }

        // Tüm mayınları gösterir
        private void ShowAllMines()
        {
            foreach (var button in oyun.GridButtons)
            {
                if (button.Tag != null && button.Tag.ToString() == "MAYIN")
                {
                    button.Text = "💣";
                    button.BackColor = Color.FromArgb(255, 107, 107);
                    button.ForeColor = Color.White;
                    button.Font = new Font(button.Font.FontFamily, 12, FontStyle.Bold);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }

        // Yeniden başlatma butonuna tıklama olayı
        private void btnYenidenBaslat_Click(object sender, EventArgs e)
        {
            // 1. Hamle sayısını sıfırla ve ekrana yansıt
            oyun.ResetHamleSayisi();

            // 2. Eski grid panelini ve kontrolleri temizleyin
            if (gridPanel != null)
            {
                foreach (Control control in gridPanel.Controls)
                {
                    control.Dispose(); // Her butonu bellekten kaldır
                }
                gridPanel.Controls.Clear(); // Grid panelin içindeki tüm kontrolleri temizle
                this.Controls.Remove(gridPanel); // Paneli formdan kaldır
                gridPanel.Dispose(); // Paneli bellekten temizle
                gridPanel = null; // Panel referansını sıfırla
            }

            // 3. Yeni bir oyun nesnesi oluştur (mevcut ayarlarla)
            oyun = new Oyun(oyun.GridSize, oyun.MineCount, oyun.UserName);

            // 4. Yeni grid'i oluştur ve mayınları yerleştir
            CreateGrid(); // Bu metot grid'i yeniden oluşturur
            oyun.PlaceMines(); // Mayınları yerleştir

            // 5. Formu yeniden çiz (ekran güncellemelerini zorla)
            this.Refresh();
        }

        // Skor formunu gösterir
        private void ShowScoreForm()
        {
            // Skorları almak için oyun skor tablosundan skorları çekiyoruz
            List<Skor> skorlar = oyun.Skorboard.GetScores();

            using (SkorForm skorForm = new SkorForm(skorlar))
            {
                // RestartGameRequested olayını dinleyerek yeniden başlatma metodunu çalıştır
                skorForm.RestartGameRequested += (s, e) => btnYenidenBaslat_Click(s, e);
                skorForm.ShowDialog();
            }
        }
    }
}
