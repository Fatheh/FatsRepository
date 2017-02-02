using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationWindowsForm
{
    public partial class Form2 : Form
    {
        SqlDataAdapter da;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dbConnection cn = new dbConnection();
            cn.dbConnect();

            string query = "select r_id,r_fname as'First Name',r_lname as'Last Name',r_cname as'Country Name',r_cityname as'City Name' from register";
            da = new SqlDataAdapter(query, dbConnection.con);
            ds = new DataSet();
            da.Fill(ds, "dgTable");
            dgv.DataSource = ds.Tables[0];
            dgv.Columns[0].Visible = false;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cmbl = new SqlCommandBuilder(da);
                da.Update(ds, "dgTable");
                MessageBox.Show("Data Updated");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
