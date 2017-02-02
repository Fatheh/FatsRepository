using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dbConnection cn = new dbConnection();
            cn.dbConnect();
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCity.Items.Clear();
            fillComboCity();

        }

        public void fillComboCity()
        {
            if (cmbCountry.Text == "India")
            {

                cmbCity.Items.Add("Goa");
                cmbCity.Items.Add("Maharashtra");
                cmbCity.Items.Add("Karnataka");
            }
            else if (cmbCountry.Text == "Pakistan")
            {
                
                cmbCity.Items.Add("Lahore");
                cmbCity.Items.Add("Islamabad");
            }
            else if (cmbCountry.Text == "Bangladesh")
            {
             
                cmbCity.Items.Add("Dhaka");
                cmbCity.Items.Add("Mirpur");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into register (r_fname,r_lname,r_cname,r_cityname) values (@rfname,@rlname,@rcname,@rcityname)";
                using (SqlCommand cmd = new SqlCommand(query, dbConnection.con))
                {
                    dbConnection.con.Open();
                    cmd.Parameters.AddWithValue("@rfname", SqlDbType.VarChar).Value = txtFName.Text;
                    cmd.Parameters.AddWithValue("@rlname", SqlDbType.VarChar).Value = txtLName.Text;
                    cmd.Parameters.AddWithValue("@rcname", SqlDbType.VarChar).Value = cmbCountry.Text;
                    cmd.Parameters.AddWithValue("@rcityname", SqlDbType.VarChar).Value = cmbCity.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted Successfully");
                    dbConnection.con.Close();
                    Form2 fm2 = new Form2();
                    fm2.Show();
                    
                    this.Hide();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
