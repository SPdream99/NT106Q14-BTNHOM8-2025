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

namespace FormRegister
{
    public partial class frm_FormDelete : Form
    {
        public frm_FormDelete()
        {
            InitializeComponent();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                string query = "DELETE FROM SINHVIEN WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", int.Parse(txt_Id.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }
        }

        private void frm_FormDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel == false)
            {
                frm_FormMain formMain = new frm_FormMain();
                formMain.Show();
            }
        }
    }
}
