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
        private void btnDepartmentList_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from TblDepartment",connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDepartmentSave_Click(object sender, EventArgs e)
        {
            if (rdbActive.Checked || rdbPassive.Checked)
            {
                connection.Open();
                SqlCommand command =
                    new SqlCommand("insert into TblDepartment(DepartmentName,DepartmentStatus) values (@p1,@p2)",
                        connection);
                command.Parameters.AddWithValue("@p1", txtDepartmentName.Text);
                if (rdbActive.Checked)
                {
                    command.Parameters.AddWithValue("@p2", true);
                }

                if (rdbPassive.Checked)
                {
                    command.Parameters.AddWithValue("@p2", false);
                }

                command.ExecuteNonQuery();
                MessageBox.Show("Departman başarılı bir şekilde eklendi.", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bir durum seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCDepartmentDelete_Click(object sender, EventArgs e)
        {
            if (txtDepartmentId.Text!="")
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from TblDepartment where DepartmentID = @p1",connection);
                command.Parameters.AddWithValue("@p1", txtDepartmentId.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Departman başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                connection.Close();
            }
            else
            {
                MessageBox.Show("Lütfen ID alanını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDepartmentUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update TblDepartment set DepartmentName=@p1 where DepartmentID=@p2",connection);
            command.Parameters.AddWithValue("@p1", txtDepartmentName.Text);
            command.Parameters.AddWithValue("@p2", txtDepartmentId.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Departman adı başarıyla güncellendi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            connection.Close();
        }
    }
}