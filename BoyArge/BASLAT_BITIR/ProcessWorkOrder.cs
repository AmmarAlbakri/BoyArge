using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BoyArge.BASLAT_BITIR
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private static string connectionString = File.ReadAllText("Connection.txt");

        private SqlConnection con = new SqlConnection(connectionString);

        private void Form3_Load(object sender, EventArgs e)
        {
            con.Open();
            textBox2.ReadOnly = true;

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT ISMERKEZAD,ISMERKEZKOD from [TEKSTIL_UYG].[dbo].[VWARGE_PRODUCTION_PROCESS]", con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cmd.ExecuteNonQuery();

                comboBox2.DisplayMember = "ISMERKEZAD";
                comboBox2.ValueMember = "ISMERKEZKOD";
                comboBox2.DataSource = ds.Tables[0];
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = (Form1)Application.OpenForms["Form1"];

            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_ADD_OPERATION]", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                cmd.Parameters["@SERINO"].Value = textBox2.Text.Trim().ToString();
                cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@ISMERKEZKOD", SqlDbType.VarChar);
                cmd.Parameters["@ISMERKEZKOD"].Value = comboBox2.SelectedValue.ToString();
                cmd.Parameters["@ISMERKEZKOD"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                frm.refresh();
                frm.proses_operasyonlari(textBox2.Text.Trim().ToString());
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