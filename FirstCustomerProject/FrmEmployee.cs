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
            SqlCommand cmd = new SqlCommand("select Name,Surname,City,Salary,DepartmentName from TblEmployee inner join TblDepartment on TblEmployee.DepartmentID = TblDepartment.DepartmentID ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from TblDepartment",connection);
            int rowCount = (int)command.ExecuteScalar();
            if ( numDepartmentID.Value <= rowCount)
            {
                
                SqlCommand cmd = new SqlCommand("insert into TblEmployee(Name,Surname,City,Salary,DepartmentID) values (@p1,@p2,@p3,@p4,@p5)", connection);
                cmd.Parameters.AddWithValue("p1", txtName.Text);
                cmd.Parameters.AddWithValue("p2", txtSurname.Text);
                cmd.Parameters.AddWithValue("p3", txtCity.Text);
                cmd.Parameters.AddWithValue("p4", txtSalary.Text);
                cmd.Parameters.AddWithValue("p5", numDepartmentID.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Çalışan başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Geçerli olan bir departman ID'si giriniz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
    }
}
