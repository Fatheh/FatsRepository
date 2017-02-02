using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace RegistrationWindowsForm
{
    class dbConnection
    {
        public static SqlConnection con = new SqlConnection();

        public void dbConnect()
        {
        try {
                string cnstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Gauresh\Documents\Visual Studio 2015\Projects\RegistrationWindowsForm\RegistrationWindowsForm\Register.mdf';Integrated Security=True";
                con.ConnectionString = cnstr;
                
            }
            
         catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
           
        }
    }
}
