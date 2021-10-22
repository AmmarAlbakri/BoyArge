using BoyArge.BASLAT_BITIR;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class Form1 : Form
    {
        public int rowInd;
        private DataTable table = new DataTable();

        private static string connectionString = File.ReadAllText("Connection.txt");
        //static string connectionString = "data source=192.168.109.2,1433;user id=arge;password=Arge*2020!;initial catalog=TEKSTIL_UYG; Connection Timeout=1;";

        public static string Process = "";
        public static string OpNo = "";
        public static string SeriNo = "";

        //static string connectionString = "data source=192.168.109.2,1433;user id=arge;password=Arge*2020!;initial catalog=TEKSTIL_UYG; Connection Timeout=1;";
        public SqlConnection con = new SqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        public void proses_operasyonlari(string evrak_no)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT CASE DURUM WHEN 0 THEN 'Başladı' WHEN 1 THEN 'Tamamlandı' END AS MakineDurum," +
                    $"ISMERKEZAD as Operasyon,URTRKO.KAYNAKKOD as Makine_Kod,KAYNAKAD as Makine,CEILING(MIKTAR) as Miktar,BASTARIHSAAT as Başlama," +
                    $"BITTARIHSAAT as Bitiş,SIRANO as SıraNo,OPERASYONNO as No,URTRKO.EVRAKNO as EVRAKNO,  " +
                    $"CASE URTRKO.MKOD1 WHEN '0' THEN 'YÖNETİCİ' WHEN '' THEN '' ELSE (SELECT TOP(1) ADISOYADI FROM VWARGE_PERSONEL WHERE LKOD1=URTRKO.MKOD1 AND LKOD1<>'' AND LKOD1 IS NOT NULL) END AS BAS_OPR, " +
                    $"CASE URTRKO.MKOD2 WHEN '0' THEN 'YÖNETİCİ' WHEN '' THEN '' ELSE (SELECT TOP(1) ADISOYADI FROM VWARGE_PERSONEL WHERE LKOD1=URTRKO.MKOD2 AND LKOD1<>'' AND LKOD1 IS NOT NULL) END AS BIT_OPR  " +
                    $"FROM URTRKO " +
                    $"LEFT OUTER JOIN dbo.URTISM WITH(NOLOCK) ON URTISM.ISMERKEZKOD = URTRKO.ISMERKEZKOD " +
                    $"LEFT OUTER JOIN dbo.URTKYN WITH(NOLOCK) ON URTKYN.KAYNAKKOD = URTRKO.KAYNAKKOD " +
                    $"WHERE EVRAKNO = '{evrak_no}'" +
                    $"ORDER BY SIRANO", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                dataGridView1.DataSource = ds.Tables["ss"];
                dataGridView1.AutoResizeColumns();
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dataGridView1.RowsDefaultCellStyle.SelectionBackColor = Color.Orange;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;
                dataGridView1.Columns[9].Visible = false;
                DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
                uninstallButtonColumn.Name = "Manuel_İşlem";
                dataGridView1.Columns.Insert(10, uninstallButtonColumn);

                DataGridViewButtonColumn uninstallButtonColumn2 = new DataGridViewButtonColumn();
                uninstallButtonColumn2.Name = "Manuel_İşlem2";
                dataGridView1.Columns.Insert(11, uninstallButtonColumn2);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[10].Value = "Bitir";
                    row.Cells[11].Value = "İptal";
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT OPDURUM.ACIKLAMA as Durum,OPERASYONNO as No, ISMERKEZAD as Operasyonlar,CEILING(MIKTAR) as Miktar,OPBASTARIHSAAT as Başlama,OPBITTARIHSAAT as Bitiş,URTROT.SKOD1 [Planlanan Makine],URTROT.EVRAKNO as EVRAKNO," +
                $"Case URTROT.SKOD4 WHEN '1' THEN 'İşletme' WHEN '2' THEN 'Yönetici' WHEN '3' THEN 'Sistem' END as Tür " +
                $"FROM URTROT " +
                $"LEFT OUTER JOIN dbo.REFKRT OPDURUM WITH(NOLOCK) ON(OPDURUM.TABLOAD = 'URTKRT'  AND OPDURUM.ALANAD = 'OPDURUM' AND OPDURUM.KOD = URTROT.OPDURUM) " +
                $"LEFT OUTER JOIN dbo.URTISM WITH(NOLOCK) ON URTISM.ISMERKEZKOD = URTROT.ISMERKEZKOD " +
                $"WHERE EVRAKNO = '{evrak_no}' " +
                $"ORDER BY OPERASYONNO", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                dataGridView2.DataSource = ds.Tables["ss"];
                //dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray; //LightSteelBlue
                //dataGridView2.RowsDefaultCellStyle.SelectionBackColor = Color.Orange;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.Columns[0].ReadOnly = true;
                dataGridView2.Columns[1].ReadOnly = true;
                dataGridView2.Columns[2].ReadOnly = true;
                dataGridView2.Columns[3].ReadOnly = true;
                dataGridView2.Columns[4].ReadOnly = true;
                dataGridView2.Columns[5].ReadOnly = true;
                dataGridView2.Columns[6].ReadOnly = false;
                dataGridView2.ClearSelection();
                dataGridView2.CurrentCell = null;
                dataGridView2.Columns[7].Visible = false;

                DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
                uninstallButtonColumn.Name = "Manuel_İşlem";
                dataGridView2.Columns.Insert(8, uninstallButtonColumn);

                DataGridViewButtonColumn uninstallButtonColumn2 = new DataGridViewButtonColumn();
                uninstallButtonColumn2.Name = "Manuel_İşlem2";
                dataGridView2.Columns.Insert(9, uninstallButtonColumn2);

                DataGridViewButtonColumn uninstallButtonColumn3 = new DataGridViewButtonColumn();
                uninstallButtonColumn3.Name = "Manuel_İşlem3";
                dataGridView2.Columns.Insert(10, uninstallButtonColumn3);

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells["Durum"].Value.ToString() == "Tamamlandı")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    if (row.Cells["Durum"].Value.ToString() == "Başladı")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    if (row.Cells["Durum"].Value.ToString() == "Beklemede")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    row.Cells[8].Value = "Bitir";
                    row.Cells[9].Value = "İptal";
                    row.Cells[10].Value = "Başla";
                }
                dataGridView2.AutoResizeColumns();
                // dataGridView2.Columns["Planlanan Makine"].HeaderCell.Style.ForeColor = Color.Yellow;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string selectSql = $"SELECT [Müşteri Kısa Ad],[MALAD],[İçerik],[Renk Kodu],[Renk Adı],[Miktar] FROM VWARGE_ORDER " +
                                   $"LEFT JOIN VWARGE_IS_EMRI ON VWARGE_IS_EMRI.SIPARISSN = VWARGE_ORDER.KALEMSN " +
                                   $"WHERE [Refakart No] = '{isEmriNumarasi.Text.Trim()}'";
                SqlCommand cmd = new SqlCommand(selectSql, con);

                using (SqlDataReader read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        musteri.Text = (read["Müşteri Kısa Ad"].ToString());
                        kalite.Text = (read["MALAD"].ToString());
                        icerik.Text = (read["İçerik"].ToString());
                        renk_kodu.Text = (read["Renk Kodu"].ToString());
                        renk.Text = (read["Renk Adı"].ToString());
                        miktar.Text = (read["Miktar"].ToString());
                    }
                }
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void refresh()
        {
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            operatorKodu.Text = "";
            operatorAdi.Text = "";
            makinaBarkodu.Text = "";
        }

        public void press_enter()
        {
            musteri.Text = "";
            kalite.Text = "";
            icerik.Text = "";
            renk_kodu.Text = "";
            renk.Text = "";
            miktar.Text = "";

            string sakla = isEmriNumarasi.Text;

            refresh();
            isEmriNumarasi.Text = sakla;
            proses_operasyonlari(isEmriNumarasi.Text.Trim());

            this.ActiveControl = operatorKodu;

            table = (DataTable)dataGridView2.DataSource;
            dataGridView2.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void isEmriNumarasi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                press_enter();
            }
        }

        private void operatorKodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"SELECT SICILKOD, AD, SOYAD FROM VWTEX_SICILKART WITH(NOLOCK) WHERE SICILKOD = '{operatorKodu.Text.Trim()}'", con);

                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();

                    da.Fill(ds, "ss");
                    operatorAdi.Text = ds.Tables[0].Rows[0]["AD"].ToString() + " " + ds.Tables[0].Rows[0]["SOYAD"].ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lütfen geçerli bir operatör kodu ekleyiniz !", "Uyarı mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                this.ActiveControl = makinaBarkodu;
            }
        }

        private void makinaBarkodu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (String.IsNullOrEmpty(makinaBarkodu.Text))
                    return;

                if (makinaBarkodu.Text.Substring(0, 1).ToString() == "S")
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_START_OPERATION]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = isEmriNumarasi.Text.Trim();
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERATORKOD", SqlDbType.VarChar);
                        cmd.Parameters["@OPERATORKOD"].Value = operatorKodu.Text.Trim();
                        cmd.Parameters["@OPERATORKOD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                        cmd.Parameters["@KAYNAKKOD"].Value = makinaBarkodu.Text.Trim().Substring(2, makinaBarkodu.Text.Length - 2);
                        cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(isEmriNumarasi.Text.Trim());
                        isEmriNumarasi.Text = "";
                        this.ActiveControl = isEmriNumarasi;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        makinaBarkodu.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        makinaBarkodu.Text = "";
                    }
                }
                else if (makinaBarkodu.Text.Substring(0, 1).Equals("F"))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_FINISH_OPERATION]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = isEmriNumarasi.Text.Trim();
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERATORKOD", SqlDbType.VarChar);
                        cmd.Parameters["@OPERATORKOD"].Value = operatorKodu.Text.Trim();
                        cmd.Parameters["@OPERATORKOD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                        cmd.Parameters["@KAYNAKKOD"].Value = makinaBarkodu.Text.Trim().Substring(2, makinaBarkodu.Text.Length - 2);
                        cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(isEmriNumarasi.Text.Trim());

                        isEmriNumarasi.Text = "";
                        this.ActiveControl = isEmriNumarasi;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        makinaBarkodu.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        makinaBarkodu.Text = "";
                    }
                }
                else if (makinaBarkodu.Text.Substring(0, 1).Equals("C"))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_CANCEL_OPERATION]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = isEmriNumarasi.Text.Trim();
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERATORKOD", SqlDbType.VarChar);
                        cmd.Parameters["@OPERATORKOD"].Value = operatorKodu.Text.Trim();
                        cmd.Parameters["@OPERATORKOD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                        cmd.Parameters["@KAYNAKKOD"].Value = makinaBarkodu.Text.Trim().Substring(2, makinaBarkodu.Text.Length - 2);
                        cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(isEmriNumarasi.Text.Trim());

                        isEmriNumarasi.Text = "";
                        this.ActiveControl = isEmriNumarasi;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        makinaBarkodu.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        makinaBarkodu.Text = "";
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri tabanı bağlantısı sağlanılamadı !", "Bağlantı hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            this.ActiveControl = isEmriNumarasi;
            if (!String.IsNullOrEmpty(isEmriNumarasi.Text.Trim()))
                press_enter();

            if (LoginForm.UserId != 1)
                button_guncelle.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
        }

        private void isEmriNumarasi_Enter(object sender, EventArgs e)
        {
            isEmriNumarasi.BackColor = Color.Yellow;
        }

        private void isEmriNumarasi_Leave(object sender, EventArgs e)
        {
            isEmriNumarasi.BackColor = Color.White;
        }

        private void operatorKodu_Enter(object sender, EventArgs e)
        {
            operatorKodu.BackColor = Color.Yellow;
        }

        private void operatorKodu_Leave(object sender, EventArgs e)
        {
            operatorKodu.BackColor = Color.White;
        }

        private void makinaBarkodu_Enter(object sender, EventArgs e)
        {
            makinaBarkodu.BackColor = Color.Yellow;
        }

        private void makinaBarkodu_Leave(object sender, EventArgs e)
        {
            makinaBarkodu.BackColor = Color.White;
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            refresh();
            isEmriNumarasi.Text = "";
            musteri.Text = "";
            kalite.Text = "";
            icerik.Text = "";
            renk_kodu.Text = "";
            renk.Text = "";
            miktar.Text = "";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int a;
            DialogResult dialog = MessageBox.Show("Makine sayıları ve operasyonlar güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (int.TryParse(row.Cells["Planlanan Makine"].Value.ToString().Trim(), out a))
                        {
                            SqlCommand update = new SqlCommand($"UPDATE URTROT SET SKOD1 = @SKOD1_Value WHERE EVRAKNO = @EvrakNo AND OPERASYONNO = @OperasyonNo ", con);

                            update.Parameters.AddWithValue("@SKOD1_Value", row.Cells["Planlanan Makine"].Value.ToString().Trim());
                            update.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                            update.Parameters.AddWithValue("@OperasyonNo", row.Cells["No"].Value);
                            update.ExecuteNonQuery();
                        }
                        else
                            MessageBox.Show($" {row.Cells["Operasyonlar"].Value}  için lütfen bir sayı değeri giriniz", "Uyarı");
                    }
                    if (dataGridView2.DataSource != null)
                        MessageBox.Show("Planlanan makina sayısı güncellendi", "Bilgilendirme");
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Manuel_İşlem"].Index)
            {
                var result = "";
                string calculatePassword = "";
                if (LoginForm.UserId != 1)
                {
                    result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
                    //Begin getting password from db
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader passwordReader = cmd.ExecuteReader();
                        passwordReader.Read();

                        calculatePassword = passwordReader["Property"].ToString();
                        passwordReader.Close();
                    }

                    //End of getting password from db
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    { throw ex; }
                }

                if (result.Equals(calculatePassword) || LoginForm.UserId == 1)
                {
                    string grid_evrakno = dataGridView1.Rows[e.RowIndex].Cells["EVRAKNO"].Value.ToString();
                    string grid_kaynakkod = dataGridView1.Rows[e.RowIndex].Cells["Makine_Kod"].Value.ToString();
                    string grid_operasyonno = dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString();
                    string sıra_no = dataGridView1.Rows[e.RowIndex].Cells["SıraNo"].Value.ToString();

                    try
                    {
                        SqlCommand cmd = new SqlCommand("[SPARGE_FINISH_MANUEL_MACHINE]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = grid_evrakno;
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERASYONNO", SqlDbType.VarChar);
                        cmd.Parameters["@OPERASYONNO"].Value = grid_operasyonno;
                        cmd.Parameters["@OPERASYONNO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                        cmd.Parameters["@KAYNAKKOD"].Value = grid_kaynakkod;
                        cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@SIRANO", SqlDbType.Int);
                        cmd.Parameters["@SIRANO"].Value = sıra_no;
                        cmd.Parameters["@SIRANO"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(grid_evrakno);
                        this.ActiveControl = isEmriNumarasi;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result != "")
                {
                    MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["Manuel_İşlem2"].Index)
            {
                var result = "";
                string calculatePassword = "";
                if (LoginForm.UserId != 1)
                {
                    result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
                    //Begin getting password from db
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader passwordReader = cmd.ExecuteReader();
                        passwordReader.Read();

                        calculatePassword = passwordReader["Property"].ToString();
                        passwordReader.Close();
                    }
                    catch (Exception ex) { throw ex; }
                    //End of getting password from db
                }

                if (result.Equals(calculatePassword) || LoginForm.UserId == 1)
                {
                    try
                    {
                        string grid_evrakno = dataGridView1.Rows[e.RowIndex].Cells["EVRAKNO"].Value.ToString();
                        string grid_kaynakkod = dataGridView1.Rows[e.RowIndex].Cells["Makine_Kod"].Value.ToString();
                        string grid_operasyonno = dataGridView1.Rows[e.RowIndex].Cells["No"].Value.ToString();
                        string sırano = dataGridView1.Rows[e.RowIndex].Cells["SıraNo"].Value.ToString();

                        SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_CANCEL_MANUEL_MACHINE]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = grid_evrakno;
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERASYONNO", SqlDbType.VarChar);
                        cmd.Parameters["@OPERASYONNO"].Value = grid_operasyonno;
                        cmd.Parameters["@OPERASYONNO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                        cmd.Parameters["@KAYNAKKOD"].Value = grid_kaynakkod;
                        cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@SIRANO", SqlDbType.Int);
                        cmd.Parameters["@SIRANO"].Value = sırano;
                        cmd.Parameters["@SIRANO"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(grid_evrakno);

                        //isEmriNumarasi.Text = "";
                        this.ActiveControl = isEmriNumarasi;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result != "")
                {
                    MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Manuel_İşlem"].Index)
            {
                if (isEmriNumarasi.Text.Trim() == "") return;
                var result = "";
                string calculatePassword = "";
                if (LoginForm.UserId != 1)
                {
                    result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
                    //Begin getting password from db
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader passwordReader = cmd.ExecuteReader();
                        passwordReader.Read();

                        calculatePassword = passwordReader["Property"].ToString();
                        passwordReader.Close();
                    }
                    catch (Exception ex)
                    { throw ex; }
                    //End of getting password from db
                }

                if (result.Equals(calculatePassword) || LoginForm.UserId == 1)
                {
                    string grid_evrakno = dataGridView2.Rows[e.RowIndex].Cells["EVRAKNO"].Value.ToString();
                    string grid_operasyonno = dataGridView2.Rows[e.RowIndex].Cells["No"].Value.ToString();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_FINISH_MANUEL]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = grid_evrakno;
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERASYONNO", SqlDbType.VarChar);
                        cmd.Parameters["@OPERASYONNO"].Value = grid_operasyonno;
                        cmd.Parameters["@OPERASYONNO"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(grid_evrakno);
                        this.ActiveControl = isEmriNumarasi;
                        table = (DataTable)dataGridView2.DataSource;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result != "")
                {
                    MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.ColumnIndex == dataGridView2.Columns["Manuel_İşlem2"].Index)
            {
                if (isEmriNumarasi.Text.Trim() == "") return;
                var result = "";
                string calculatePassword = "";
                if (LoginForm.UserId != 1)
                {
                    result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
                    //Begin getting password from db
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader passwordReader = cmd.ExecuteReader();
                        passwordReader.Read();

                        calculatePassword = passwordReader["Property"].ToString();
                        passwordReader.Close();
                    }
                    catch (Exception ex) { throw ex; }
                }

                //End of getting password from db
                if (result.Equals(calculatePassword) || LoginForm.UserId == 1)
                {
                    try
                    {
                        string grid_evrakno = dataGridView2.Rows[e.RowIndex].Cells["EVRAKNO"].Value.ToString();
                        string grid_operasyonno = dataGridView2.Rows[e.RowIndex].Cells["No"].Value.ToString();

                        SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_CANCEL_MANUEL]", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                        cmd.Parameters["@SERINO"].Value = grid_evrakno;
                        cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@OPERASYONNO", SqlDbType.VarChar);
                        cmd.Parameters["@OPERASYONNO"].Value = grid_operasyonno;
                        cmd.Parameters["@OPERASYONNO"].Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();

                        refresh();
                        proses_operasyonlari(grid_evrakno);
                        this.ActiveControl = isEmriNumarasi;
                        table = (DataTable)dataGridView2.DataSource;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result != "")
                {
                    MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.ColumnIndex == dataGridView2.Columns["Manuel_İşlem3"].Index)
            {
                if (isEmriNumarasi.Text.Trim() == "") return;
                var result = "";
                string calculatePassword = "";
                if (LoginForm.UserId != 1)
                {
                    result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
                    //Begin getting password from db
                    try
                    {
                        SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataReader passwordReader = cmd.ExecuteReader();
                        passwordReader.Read();

                        calculatePassword = passwordReader["Property"].ToString();
                        passwordReader.Close();
                    }
                    catch (Exception ex) { throw ex; }
                    //End of getting password from db
                }

                if (result.Equals(calculatePassword) || LoginForm.UserId == 1)
                {
                    try
                    {
                        refresh();
                        proses_operasyonlari(isEmriNumarasi.Text.Trim());

                        SeriNo = dataGridView2.Rows[e.RowIndex].Cells["EVRAKNO"].Value.ToString();
                        OpNo = dataGridView2.Rows[e.RowIndex].Cells["No"].Value.ToString();
                        Process = dataGridView2.Rows[e.RowIndex].Cells["Operasyonlar"].Value.ToString();

                        Form2 frm = new Form2();

                        frm.textBox1.Text = Process;

                        SqlCommand cmd = new SqlCommand($"SELECT KAYNAKAD,KAYNAKKOD from [TEKSTIL_UYG].[dbo].[VWARGE_PROCESS_MACHINE] where [ISMERKEZAD] = '{Process}' ", con);
                        cmd.CommandType = CommandType.Text;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        cmd.ExecuteNonQuery();

                        frm.comboBox2.DisplayMember = "KAYNAKAD";
                        frm.comboBox2.ValueMember = "KAYNAKKOD";
                        frm.comboBox2.DataSource = ds.Tables[0];
                        frm.ShowDialog();
                        table = (DataTable)dataGridView2.DataSource;
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (result != "")
                {
                    MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnoperasyonlar_sil_Click(object sender, EventArgs e)
        {
            if (dataGridView2.DataSource == null) return;
            Process = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["Operasyonlar"].Value.ToString();

            if (Process == null) return;
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show($"{Process} Operasyon Silinsin mi ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string grid_evrakno = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["EVRAKNO"].Value.ToString();
                    string grid_operasyonno = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["No"].Value.ToString();

                    SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_DELETE_OPERATION]", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                    cmd.Parameters["@SERINO"].Value = grid_evrakno;
                    cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                    cmd.Parameters.Add("@OPERASYONNO", SqlDbType.VarChar);
                    cmd.Parameters["@OPERASYONNO"].Value = grid_operasyonno;
                    cmd.Parameters["@OPERASYONNO"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();

                    refresh();
                    proses_operasyonlari(grid_evrakno);
                    this.ActiveControl = isEmriNumarasi;
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnoperasyon_ekle_Click(object sender, EventArgs e)
        {
            if (isEmriNumarasi.Text.Trim() == null || isEmriNumarasi.Text.Trim() == "") return;
            if (dataGridView2.DataSource == null) return;
            Form3 frm3 = new Form3();
            frm3.textBox2.Text = isEmriNumarasi.Text.Trim();
            frm3.ShowDialog();
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            var result = "";
            string calculatePassword = "";

            result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
            //Begin getting password from db
            try
            {
                SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                cmd.CommandType = CommandType.Text;

                SqlDataReader passwordReader = cmd.ExecuteReader();
                passwordReader.Read();

                calculatePassword = passwordReader["Property"].ToString();
                passwordReader.Close();
            }
            catch (Exception ex) { throw ex; }
            //End of getting password from db

            if (result.Equals(calculatePassword))
            {
                bool check = true;
                foreach (DataGridViewRow row3 in dataGridView2.Rows)
                {
                    foreach (DataGridViewRow row2 in dataGridView2.Rows)
                    {
                        if (row2.Cells["Durum"].Value.ToString().Trim() != "Beklemede")
                        {
                            check = false;
                            break;
                        }
                    }
                }
                try
                {
                    rowInd = dataGridView2.SelectedCells[0].OwningRow.Index;
                }
                catch (Exception) { MessageBox.Show("Lütfen tablodan bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Operasyon Numaraları güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    if (check == true)
                    {
                        SqlCommand ModifyOpNo = new SqlCommand($"DECLARE @OPERASYONNO INT DECLARE @ISMERKEZKOD VARCHAR(25)" +
                            $"DECLARE db_cursor CURSOR FOR " +
                            $"SELECT OPERASYONNO,ISMERKEZKOD FROM URTROT WHERE EVRAKNO=@EvrakNo OPEN db_cursor " +
                            $"FETCH NEXT FROM db_cursor INTO @OPERASYONNO, @ISMERKEZKOD WHILE @@FETCH_STATUS = 0 " +
                            $"BEGIN " +
                            $"update URTROT set OPERASYONNO = (SELECT OPERASYONNO FROM URTROT WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD) + 11 " +
                            $"where EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD update URTROK set OPERASYONNO = (SELECT OPERASYONNO FROM URTROT" +
                            $" WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD)+11 where EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD " +
                            $"FETCH NEXT FROM db_cursor INTO @OPERASYONNO, @ISMERKEZKOD " +
                            $"END " +
                            $"CLOSE db_cursor " +
                            $"DEALLOCATE db_cursor", con);

                        ModifyOpNo.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                        ModifyOpNo.ExecuteNonQuery();
                    }
                    else { MessageBox.Show("Operasyon durumları Beklemede olmalıdır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    //rowInd = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["No"].RowIndex;
                    try
                    {
                        rowInd = dataGridView2.SelectedCells[0].OwningRow.Index;
                    }
                    catch (Exception)
                    { MessageBox.Show("Lütfen tablodan bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    DataRow row = table.NewRow();

                    row["DURUM"] = dataGridView2.Rows[rowInd].Cells["DURUM"].Value.ToString();
                    row["No"] = dataGridView2.Rows[rowInd].Cells["No"].Value.ToString();
                    row["Operasyonlar"] = dataGridView2.Rows[rowInd].Cells["Operasyonlar"].Value.ToString();
                    row["Miktar"] = dataGridView2.Rows[rowInd].Cells["Miktar"].Value.ToString();
                    row["Başlama"] = dataGridView2.Rows[rowInd].Cells["Başlama"].Value.ToString();
                    row["Bitiş"] = dataGridView2.Rows[rowInd].Cells["Bitiş"].Value.ToString();
                    row["Planlanan Makine"] = dataGridView2.Rows[rowInd].Cells["Planlanan Makine"].Value.ToString();
                    if (rowInd > 0)
                    {
                        foreach (DataGridViewRow row4 in dataGridView2.Rows)
                        {
                            row4.Cells["No"].Value = 10;
                        }
                        bool a = true;
                        int index = 0;
                        foreach (DataGridViewRow row5 in dataGridView2.Rows)
                        {
                            index++;
                            if (a == true)
                            {
                                if (Convert.ToInt32(row5.Cells["No"].Value) == 10)
                                    a = false;
                                continue;
                            }
                            row5.Cells["No"].Value = Convert.ToInt32(row5.Cells["No"].Value) * index;
                        }
                        table.Rows.RemoveAt(rowInd);
                        table.Rows.InsertAt(row, rowInd - 1);
                        table.Rows[rowInd]["No"] = (rowInd * 10) + 10;
                        dataGridView2.ClearSelection();
                        dataGridView2.Rows[rowInd - 1].Selected = true;
                        row["No"] = -(-rowInd * 10);
                    }
                    foreach (DataGridViewRow row1 in dataGridView2.Rows)
                    {
                        if (row1.Cells["Durum"].Value.ToString() == "Tamamlandı")
                        {
                            row1.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        if (row1.Cells["Durum"].Value.ToString() == "Başladı")
                        {
                            row1.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        if (row1.Cells["Durum"].Value.ToString() == "Beklemede")
                        {
                            row1.DefaultCellStyle.BackColor = Color.LightPink;
                        }
                        row1.Cells[8].Value = "Bitir";
                        row1.Cells[9].Value = "İptal";
                        row1.Cells[10].Value = "Başla";
                    }

                    foreach (DataGridViewRow row3 in dataGridView2.Rows)
                    {
                        SqlCommand update2 = new SqlCommand($"UPDATE URTROT SET OPERASYONNO = @OPERASYONNO WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = (SELECT ISMERKEZKOD FROM VWARGE_PRODUCTION_PROCESS WHERE ISMERKEZAD=@ISMERKEZAD) ", con);

                        update2.Parameters.AddWithValue("@OPERASYONNO", row3.Cells["No"].Value.ToString().Trim());
                        update2.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                        update2.Parameters.AddWithValue("@ISMERKEZAD", row3.Cells["Operasyonlar"].Value);
                        update2.ExecuteNonQuery();

                        SqlCommand update3 = new SqlCommand($"UPDATE URTROK SET OPERASYONNO = @OPERASYONNO WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = (SELECT ISMERKEZKOD FROM VWARGE_PRODUCTION_PROCESS WHERE ISMERKEZAD=@ISMERKEZAD) ", con);

                        update3.Parameters.AddWithValue("@OPERASYONNO", row3.Cells["No"].Value.ToString().Trim());
                        update3.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                        update3.Parameters.AddWithValue("@ISMERKEZAD", row3.Cells["Operasyonlar"].Value);
                        update3.ExecuteNonQuery();
                    }
                    //refresh();
                    //proses_operasyonlari(isEmriNumarasi.Text.Trim());
                }
            }
            else if (result != "")
            {
                MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            var result = "";
            string calculatePassword = "";

            result = Interaction.InputBox("", "Lütfen şifre giriniz", "", 250, 250);
            //Begin getting password from db
            try
            {
                SqlCommand cmd = new SqlCommand("select Property from [dbo].[VWARGE_tblParameters] where Definition = 'BASLAT_BITIR' and Feature='Code'", con);
                cmd.CommandType = CommandType.Text;

                SqlDataReader passwordReader = cmd.ExecuteReader();
                passwordReader.Read();

                calculatePassword = passwordReader["Property"].ToString();
                passwordReader.Close();
            }
            catch (Exception ex) { throw ex; }
            //End of getting password from db

            if (result.Equals(calculatePassword))
            {
                bool check = true;
                foreach (DataGridViewRow row3 in dataGridView2.Rows)
                {
                    foreach (DataGridViewRow row2 in dataGridView2.Rows)
                    {
                        if (row2.Cells["Durum"].Value.ToString().Trim() != "Beklemede")
                        {
                            check = false;
                            break;
                        }
                    }
                }
                try
                {
                    rowInd = dataGridView2.SelectedCells[0].OwningRow.Index;
                }
                catch (Exception)
                { MessageBox.Show("Lütfen tablodan bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Operasyon Numaraları güncellensin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    if (check == true)
                    {
                        SqlCommand ModifyOpNo = new SqlCommand($"DECLARE @OPERASYONNO INT DECLARE @ISMERKEZKOD VARCHAR(25)" +
                            $"DECLARE db_cursor CURSOR FOR " +
                            $"SELECT OPERASYONNO,ISMERKEZKOD FROM URTROT WHERE EVRAKNO=@EvrakNo OPEN db_cursor " +
                            $"FETCH NEXT FROM db_cursor INTO @OPERASYONNO, @ISMERKEZKOD WHILE @@FETCH_STATUS = 0 " +
                            $"BEGIN " +
                            $"update URTROT set OPERASYONNO = (SELECT OPERASYONNO FROM URTROT WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD) + 11 " +
                            $"where EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD update URTROK set OPERASYONNO = (SELECT OPERASYONNO FROM URTROT" +
                            $" WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD)+11 where EVRAKNO = @EvrakNo AND ISMERKEZKOD = @ISMERKEZKOD " +
                            $"FETCH NEXT FROM db_cursor INTO @OPERASYONNO, @ISMERKEZKOD " +
                            $"END " +
                            $"CLOSE db_cursor " +
                            $"DEALLOCATE db_cursor", con);

                        ModifyOpNo.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                        ModifyOpNo.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Operasyon durumları Beklemede olmalıdır", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                    }
                    //rowInd = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells["No"].RowIndex;
                    try
                    {
                        rowInd = dataGridView2.SelectedCells[0].OwningRow.Index;
                    }
                    catch (Exception)
                    { MessageBox.Show("Lütfen tablodan bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                    DataRow row = table.NewRow();

                    row["DURUM"] = dataGridView2.Rows[rowInd].Cells["DURUM"].Value.ToString();
                    row["No"] = dataGridView2.Rows[rowInd].Cells["No"].Value.ToString();
                    row["Operasyonlar"] = dataGridView2.Rows[rowInd].Cells["Operasyonlar"].Value.ToString();
                    row["Miktar"] = dataGridView2.Rows[rowInd].Cells["Miktar"].Value.ToString();
                    row["Başlama"] = dataGridView2.Rows[rowInd].Cells["Başlama"].Value.ToString();
                    row["Bitiş"] = dataGridView2.Rows[rowInd].Cells["Bitiş"].Value.ToString();
                    row["Planlanan Makine"] = dataGridView2.Rows[rowInd].Cells["Planlanan Makine"].Value.ToString();
                    if (rowInd < dataGridView2.Rows.Count - 1)
                    {
                        foreach (DataGridViewRow row4 in dataGridView2.Rows)
                        {
                            row4.Cells["No"].Value = 10;
                        }
                        bool a = true;
                        int index = 0;
                        foreach (DataGridViewRow row5 in dataGridView2.Rows)
                        {
                            index++;
                            if (a == true)
                            {
                                if (Convert.ToInt32(row5.Cells["No"].Value) == 10)
                                    a = false;
                                continue;
                            }
                            row5.Cells["No"].Value = Convert.ToInt32(row5.Cells["No"].Value) * index;
                        }
                        table.Rows.RemoveAt(rowInd);
                        table.Rows.InsertAt(row, rowInd + 1);
                        table.Rows[rowInd]["No"] = (rowInd * 10) + 10;
                        dataGridView2.ClearSelection();
                        dataGridView2.Rows[rowInd + 1].Selected = true;
                        row["No"] = (rowInd * 10) + 20;
                    }
                    foreach (DataGridViewRow row1 in dataGridView2.Rows)
                    {
                        if (row1.Cells["Durum"].Value.ToString() == "Tamamlandı")
                        {
                            row1.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        if (row1.Cells["Durum"].Value.ToString() == "Başladı")
                        {
                            row1.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        if (row1.Cells["Durum"].Value.ToString() == "Beklemede")
                        {
                            row1.DefaultCellStyle.BackColor = Color.LightPink;
                        }
                        row1.Cells[8].Value = "Bitir";
                        row1.Cells[9].Value = "İptal";
                        row1.Cells[10].Value = "Başla";
                    }

                    foreach (DataGridViewRow row3 in dataGridView2.Rows)
                    {
                        SqlCommand update2 = new SqlCommand($"UPDATE URTROT SET OPERASYONNO = @OPERASYONNO WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = (SELECT ISMERKEZKOD FROM VWARGE_PRODUCTION_PROCESS WHERE ISMERKEZAD=@ISMERKEZAD) ", con);

                        update2.Parameters.AddWithValue("@OPERASYONNO", row3.Cells["No"].Value.ToString().Trim());
                        update2.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                        update2.Parameters.AddWithValue("@ISMERKEZAD", row3.Cells["Operasyonlar"].Value);
                        update2.ExecuteNonQuery();

                        SqlCommand update3 = new SqlCommand($"UPDATE URTROK SET OPERASYONNO = @OPERASYONNO WHERE EVRAKNO = @EvrakNo AND ISMERKEZKOD = (SELECT ISMERKEZKOD FROM VWARGE_PRODUCTION_PROCESS WHERE ISMERKEZAD=@ISMERKEZAD) ", con);

                        update3.Parameters.AddWithValue("@OPERASYONNO", row3.Cells["No"].Value.ToString().Trim());
                        update3.Parameters.AddWithValue("@EvrakNo", isEmriNumarasi.Text.Trim());
                        update3.Parameters.AddWithValue("@ISMERKEZAD", row3.Cells["Operasyonlar"].Value);
                        update3.ExecuteNonQuery();
                    }
                    //refresh();
                    //proses_operasyonlari(isEmriNumarasi.Text.Trim());
                }
            }
            else if (result != "")
            {
                MessageBox.Show("Hatalı şifre girdiniz", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                string grid_evrakno = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["EVRAKNO"].Value.ToString();
                string makine_kod = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Makine_Kod"].Value.ToString();

                SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_OPERATION_UPDATEPARAMETERS]", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                cmd.Parameters["@SERINO"].Value = grid_evrakno;
                cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                cmd.Parameters["@KAYNAKKOD"].Value = makine_kod;
                cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                refresh();
                proses_operasyonlari(grid_evrakno);
                this.ActiveControl = isEmriNumarasi;
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

//for (int i = 0; i < dataGridView1.Rows.Count; i++)
//{
//    DataGridViewRow row = dataGridView1.Rows[i];

//    row.Cells[2].Value = true;

//}