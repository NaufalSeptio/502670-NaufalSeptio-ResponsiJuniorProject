using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace GSTK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=5432;Username=postgres;Password=___;Database=ListofName";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_insert(_nama, _departemen)";
                ProcessCmdKey = new NpgsqlCommand(SqlDbType, conn);
                cmd.Parameters AddWithValue("_nama", textBox1.Text);
                cmd.Parameters AddWithValue("_departemen", comboBox1);
                {
                    MessageBox.Show("Data Users Berhasil diiput", "Well Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Mohon pilih baris data yang akan diedit", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information) return;
            }
            try
            {
                conn.Open();
                sql = @"select * from st_update(_nama, _departemen)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters AddWithValue("_nama", textBox1.Text);
                cmd.Parameters AddWithValue("_departemen", comboBox1);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data berhasil diedit", "Well Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message + "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Mohon pilih baris data yang akan dihapus", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information) return;
            }
            try
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
