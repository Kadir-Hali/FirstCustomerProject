using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FirstCustomerProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection connection =
            new SqlConnection("Server=DESKTOP-G3NGAQA; initial catalog = MyDbCustomer; integrated Security = true");
        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from TblDepartment",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}