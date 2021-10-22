
namespace BoyArge
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.isEmriNumarasi = new System.Windows.Forms.TextBox();
            this.operatorKodu = new System.Windows.Forms.TextBox();
            this.operatorAdi = new System.Windows.Forms.TextBox();
            this.btnYeni = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.makinaBarkodu = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btnoperasyon_ekle = new System.Windows.Forms.Button();
            this.btnoperasyonlar_sil = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.miktar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.renk = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.renk_kodu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.icerik = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.kalite = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.musteri = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button_guncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "İŞ EMRİ NUMARASI :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "OPERATÖR KODU :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(1, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "MAKİNA BARKODU :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // isEmriNumarasi
            // 
            this.isEmriNumarasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.isEmriNumarasi.Location = new System.Drawing.Point(122, 15);
            this.isEmriNumarasi.Name = "isEmriNumarasi";
            this.isEmriNumarasi.Size = new System.Drawing.Size(309, 44);
            this.isEmriNumarasi.TabIndex = 3;
            this.isEmriNumarasi.Enter += new System.EventHandler(this.isEmriNumarasi_Enter);
            this.isEmriNumarasi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.isEmriNumarasi_KeyDown);
            this.isEmriNumarasi.Leave += new System.EventHandler(this.isEmriNumarasi_Leave);
            // 
            // operatorKodu
            // 
            this.operatorKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.operatorKodu.Location = new System.Drawing.Point(122, 75);
            this.operatorKodu.Name = "operatorKodu";
            this.operatorKodu.Size = new System.Drawing.Size(309, 44);
            this.operatorKodu.TabIndex = 4;
            this.operatorKodu.Enter += new System.EventHandler(this.operatorKodu_Enter);
            this.operatorKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.operatorKodu_KeyDown);
            this.operatorKodu.Leave += new System.EventHandler(this.operatorKodu_Leave);
            // 
            // operatorAdi
            // 
            this.operatorAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.operatorAdi.Location = new System.Drawing.Point(122, 127);
            this.operatorAdi.Name = "operatorAdi";
            this.operatorAdi.ReadOnly = true;
            this.operatorAdi.Size = new System.Drawing.Size(309, 35);
            this.operatorAdi.TabIndex = 5;
            // 
            // btnYeni
            // 
            this.btnYeni.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnYeni.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnYeni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYeni.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnYeni.Location = new System.Drawing.Point(91, 0);
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.Size = new System.Drawing.Size(84, 26);
            this.btnYeni.TabIndex = 6;
            this.btnYeni.Text = "Yeni";
            this.btnYeni.UseVisualStyleBackColor = false;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnKaydet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKaydet.Location = new System.Drawing.Point(0, 0);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(91, 26);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // makinaBarkodu
            // 
            this.makinaBarkodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.makinaBarkodu.Location = new System.Drawing.Point(122, 185);
            this.makinaBarkodu.Name = "makinaBarkodu";
            this.makinaBarkodu.Size = new System.Drawing.Size(309, 44);
            this.makinaBarkodu.TabIndex = 8;
            this.makinaBarkodu.Enter += new System.EventHandler(this.makinaBarkodu_Enter);
            this.makinaBarkodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.makinaBarkodu_KeyDown);
            this.makinaBarkodu.Leave += new System.EventHandler(this.makinaBarkodu_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(460, 279);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(460, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "M A K İ N A    O P E R A S Y O N L A R";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 615);
            this.panel1.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 30);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel5);
            this.splitContainer2.Size = new System.Drawing.Size(447, 585);
            this.splitContainer2.SplitterDistance = 280;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.isEmriNumarasi);
            this.panel4.Controls.Add(this.operatorKodu);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.operatorAdi);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.makinaBarkodu);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(447, 280);
            this.panel4.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_down);
            this.panel6.Controls.Add(this.btn_up);
            this.panel6.Controls.Add(this.btnoperasyon_ekle);
            this.panel6.Controls.Add(this.btnoperasyonlar_sil);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 248);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(443, 28);
            this.panel6.TabIndex = 37;
            // 
            // btn_down
            // 
            this.btn_down.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_down.Location = new System.Drawing.Point(75, 0);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(75, 28);
            this.btn_down.TabIndex = 38;
            this.btn_down.Text = "Aşağı";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_up
            // 
            this.btn_up.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_up.Location = new System.Drawing.Point(0, 0);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(75, 28);
            this.btn_up.TabIndex = 37;
            this.btn_up.Text = "Yukarı";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btnoperasyon_ekle
            // 
            this.btnoperasyon_ekle.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnoperasyon_ekle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnoperasyon_ekle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnoperasyon_ekle.Location = new System.Drawing.Point(252, 0);
            this.btnoperasyon_ekle.Name = "btnoperasyon_ekle";
            this.btnoperasyon_ekle.Size = new System.Drawing.Size(99, 28);
            this.btnoperasyon_ekle.TabIndex = 35;
            this.btnoperasyon_ekle.Text = "Operasyon Ekle";
            this.btnoperasyon_ekle.UseVisualStyleBackColor = false;
            this.btnoperasyon_ekle.Click += new System.EventHandler(this.btnoperasyon_ekle_Click);
            // 
            // btnoperasyonlar_sil
            // 
            this.btnoperasyonlar_sil.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnoperasyonlar_sil.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnoperasyonlar_sil.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnoperasyonlar_sil.Location = new System.Drawing.Point(351, 0);
            this.btnoperasyonlar_sil.Name = "btnoperasyonlar_sil";
            this.btnoperasyonlar_sil.Size = new System.Drawing.Size(92, 28);
            this.btnoperasyonlar_sil.TabIndex = 36;
            this.btnoperasyonlar_sil.Text = "Operasyon Sil";
            this.btnoperasyonlar_sil.UseVisualStyleBackColor = false;
            this.btnoperasyonlar_sil.Click += new System.EventHandler(this.btnoperasyonlar_sil_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.miktar);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.renk);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.renk_kodu);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.icerik);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.kalite);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.musteri);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.panel5.ForeColor = System.Drawing.Color.Maroon;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(447, 302);
            this.panel5.TabIndex = 11;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // miktar
            // 
            this.miktar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.miktar.Location = new System.Drawing.Point(122, 222);
            this.miktar.Multiline = true;
            this.miktar.Name = "miktar";
            this.miktar.ReadOnly = true;
            this.miktar.Size = new System.Drawing.Size(309, 33);
            this.miktar.TabIndex = 34;
            this.miktar.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(3, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 32);
            this.label11.TabIndex = 33;
            this.label11.Text = "MİKTAR :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // renk
            // 
            this.renk.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.renk.Location = new System.Drawing.Point(122, 180);
            this.renk.Multiline = true;
            this.renk.Name = "renk";
            this.renk.ReadOnly = true;
            this.renk.Size = new System.Drawing.Size(309, 33);
            this.renk.TabIndex = 32;
            this.renk.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(3, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 29);
            this.label10.TabIndex = 31;
            this.label10.Text = "RENK :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // renk_kodu
            // 
            this.renk_kodu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.renk_kodu.Location = new System.Drawing.Point(122, 139);
            this.renk_kodu.Multiline = true;
            this.renk_kodu.Name = "renk_kodu";
            this.renk_kodu.ReadOnly = true;
            this.renk_kodu.Size = new System.Drawing.Size(309, 33);
            this.renk_kodu.TabIndex = 30;
            this.renk_kodu.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(3, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 29);
            this.label9.TabIndex = 29;
            this.label9.Text = "RENK KODU :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // icerik
            // 
            this.icerik.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.icerik.Location = new System.Drawing.Point(122, 98);
            this.icerik.Multiline = true;
            this.icerik.Name = "icerik";
            this.icerik.ReadOnly = true;
            this.icerik.Size = new System.Drawing.Size(309, 33);
            this.icerik.TabIndex = 28;
            this.icerik.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(3, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 29);
            this.label8.TabIndex = 27;
            this.label8.Text = "İÇERİK :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // kalite
            // 
            this.kalite.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.kalite.Location = new System.Drawing.Point(122, 56);
            this.kalite.Multiline = true;
            this.kalite.Name = "kalite";
            this.kalite.ReadOnly = true;
            this.kalite.Size = new System.Drawing.Size(309, 33);
            this.kalite.TabIndex = 26;
            this.kalite.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "KALİTE :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // musteri
            // 
            this.musteri.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.musteri.Location = new System.Drawing.Point(122, 16);
            this.musteri.Multiline = true;
            this.musteri.Name = "musteri";
            this.musteri.ReadOnly = true;
            this.musteri.Size = new System.Drawing.Size(309, 33);
            this.musteri.TabIndex = 24;
            this.musteri.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 29);
            this.label6.TabIndex = 23;
            this.label6.Text = "MÜŞTERİ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.button_guncelle);
            this.panel3.Controls.Add(this.btnYeni);
            this.panel3.Controls.Add(this.btnKaydet);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 30);
            this.panel3.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(447, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 615);
            this.panel2.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(460, 615);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 13;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 27);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(460, 277);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "P R O S E S    O P E R A S Y O N L A R";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_guncelle
            // 
            this.button_guncelle.BackColor = System.Drawing.Color.Orchid;
            this.button_guncelle.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_guncelle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_guncelle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_guncelle.Location = new System.Drawing.Point(175, 0);
            this.button_guncelle.Name = "button_guncelle";
            this.button_guncelle.Size = new System.Drawing.Size(145, 26);
            this.button_guncelle.TabIndex = 8;
            this.button_guncelle.Text = "Veritabanı Güncelle";
            this.button_guncelle.UseVisualStyleBackColor = false;
            this.button_guncelle.Click += new System.EventHandler(this.button_guncelle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 615);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Üretim İş Emri Kartı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox operatorKodu;
        private System.Windows.Forms.TextBox operatorAdi;
        private System.Windows.Forms.Button btnYeni;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox makinaBarkodu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox miktar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox renk;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox renk_kodu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox icerik;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox kalite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox musteri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnoperasyon_ekle;
        private System.Windows.Forms.Button btnoperasyonlar_sil;
        public System.Windows.Forms.TextBox isEmriNumarasi;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button_guncelle;
    }
}

