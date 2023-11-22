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

namespace FirstCustomerProject
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }

        private SqlConnection connection = new SqlConnection("Server=DESKTOP-G3NGAQA; initial catalog = MyDbCustomer; integrated Security = true");
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from TblEmployee",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
