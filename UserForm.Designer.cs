using System.Drawing;

namespace MayinTarlasi
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMayinSayisi = new System.Windows.Forms.NumericUpDown();
            this.btnBasla = new System.Windows.Forms.Button();
            this.numGridBoyutu = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMayinSayisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridBoyutu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(286, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adınızı Giriniz:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUserName.Location = new System.Drawing.Point(311, 113);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(135, 27);
            this.txtUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(332, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mayın Sayısı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(337, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Blok sayısı : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numMayinSayisi
            // 
            this.numMayinSayisi.BackColor = System.Drawing.Color.MintCream;
            this.numMayinSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.numMayinSayisi.Location = new System.Drawing.Point(311, 223);
            this.numMayinSayisi.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMayinSayisi.Name = "numMayinSayisi";
            this.numMayinSayisi.Size = new System.Drawing.Size(135, 28);
            this.numMayinSayisi.TabIndex = 11;
            this.numMayinSayisi.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnBasla
            // 
            this.btnBasla.BackColor = System.Drawing.Color.MintCream;
            this.btnBasla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBasla.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnBasla.ForeColor = System.Drawing.Color.Crimson;
            this.btnBasla.Location = new System.Drawing.Point(340, 257);
            this.btnBasla.Name = "btnBasla";
            this.btnBasla.Size = new System.Drawing.Size(75, 36);
            this.btnBasla.TabIndex = 10;
            this.btnBasla.Text = "Başla";
            this.btnBasla.UseVisualStyleBackColor = false;
            this.btnBasla.Click += new System.EventHandler(this.btnBasla_Click);
            // 
            // numGridBoyutu
            // 
            this.numGridBoyutu.BackColor = System.Drawing.Color.MintCream;
            this.numGridBoyutu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.numGridBoyutu.Location = new System.Drawing.Point(311, 162);
            this.numGridBoyutu.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numGridBoyutu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGridBoyutu.Name = "numGridBoyutu";
            this.numGridBoyutu.Size = new System.Drawing.Size(135, 28);
            this.numGridBoyutu.TabIndex = 9;
            this.numGridBoyutu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGridBoyutu.ValueChanged += new System.EventHandler(this.numGridBoyutu_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Crimson;
            this.label4.Location = new System.Drawing.Point(313, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 40);
            this.label4.TabIndex = 20;
            this.label4.Text = "Buse Nur Baş \r\n220229015\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numMayinSayisi);
            this.Controls.Add(this.btnBasla);
            this.Controls.Add(this.numGridBoyutu);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Name = "UserForm";
            this.Text = "Kullanıcı Adı Girişi";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMayinSayisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGridBoyutu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.NumericUpDown numMayinSayisi;
        internal System.Windows.Forms.Button btnBasla;
        internal System.Windows.Forms.NumericUpDown numGridBoyutu;
        private System.Windows.Forms.Label label4;
    }
}
