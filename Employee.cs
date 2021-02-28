using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace EmployeeManagement
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rahul Deshmukh\Documents\MyEmployeeDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into EmployeeTbl values('"+EmpIdTb.Text+"','"+EmpNameTb.Text+"','"+EmpAddTb.Text+"','"+ EmpPosCb.SelectedItem.ToString()+"','"+EmpDob.Value.Date+"','"+EmpPhoneTb.Text+"','"+EmpEduCb.SelectedItem.ToString()+"','"+EmpGenCb.SelectedItem.ToString()+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(EmpIdTb.Text == "")
            {
                MessageBox.Show("Enter The Employee Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmployeeTbl where Empid=('" + EmpIdTb.Text + "');";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Succesfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
