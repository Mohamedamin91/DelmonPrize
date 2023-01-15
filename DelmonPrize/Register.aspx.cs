using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonPrize
{
    public partial class Register : System.Web.UI.Page
    {
        //  public string ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
        Random random = new Random();
        int min = 0;
        int max = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            int randomNumber = random.Next(min, max + 1);
        }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            filData();
        }
        public void filData()
        {
            if (txtUserInput.Text != string.Empty)
            {
                try
                {
                    MySqlConnection connection = new MySqlConnection("Server=212.76.85.5; Port=3306; Database=delmonit_Prize; Uid=delmonit_admin; Pwd=Ram72763@;");
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Prizes` WHERE `ID` =  " + txtUserInput.Text + " ", connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtfullname.Text = reader.GetString("FullName");
                        txtiqama.Text = reader.GetString("ID");
                        txtcompany.Text = reader.GetString("Company");
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");

                }
            }
            else 
            {
                Response.Write("<script>alert('" + "Please Enter your ID/IQama" + "');</script>");
         
            }
        }
       
    }
}