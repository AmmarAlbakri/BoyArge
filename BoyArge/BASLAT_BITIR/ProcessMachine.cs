using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace BoyArge
{
    public partial class Form2 : Form
    {
        private static string connectionString = File.ReadAllText("Connection.txt");

        private SqlConnection con = new SqlConnection(connectionString);

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Form1 frm = new Form1();

                Form1 frm = (Form1)Application.OpenForms["Form1"];

                SqlCommand cmd = new SqlCommand("[dbo].[SPARGE_START_OPERATION]", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SERINO", SqlDbType.VarChar);
                cmd.Parameters["@SERINO"].Value = Form1.SeriNo;
                cmd.Parameters["@SERINO"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@OPERATORKOD", SqlDbType.VarChar);
                cmd.Parameters["@OPERATORKOD"].Value = 0;
                cmd.Parameters["@OPERATORKOD"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@KAYNAKKOD", SqlDbType.VarChar);
                cmd.Parameters["@KAYNAKKOD"].Value = comboBox2.SelectedValue.ToString();
                cmd.Parameters["@KAYNAKKOD"].Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();

                string serino = Form1.SeriNo;

                frm.refresh();
                frm.proses_operasyonlari(serino);
                this.Close();
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