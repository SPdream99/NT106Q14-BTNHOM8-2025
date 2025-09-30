using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormRegister
{
    public partial class frm_FormUpdate : Form
    {
        public frm_FormUpdate()
        {
            InitializeComponent();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = "UPDATE SINHVIEN SET NAMESV=@name,EMAIL=@email,PHONE=@phone WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txt_Id.Text));
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@email", txt_Email.Text);
                cmd.Parameters.AddWithValue("@phone", txt_Phone.Text);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
        }

        private void frm_FormUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.Cancel == false)
            {
                frm_FormMain formMain = new frm_FormMain();
                formMain.Show();
            }
        }
    }
}
