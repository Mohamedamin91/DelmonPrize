using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonPrize
{
    public partial class Confirm : System.Web.UI.Page
    {
        Sqlconnection Sqlconn = new Sqlconnection();
        Random random = new Random();
        int min = 0;
        int max = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void filData()
        {




            if (txtUserInput.Text != string.Empty)
            {
                try
                {
                    Sqlconn.OpenConection();
                    SqlParameter paramIDQuery = new SqlParameter("@IDD", SqlDbType.NVarChar);
                    paramIDQuery.Value = txtUserInput.Text;


                    SqlDataReader dr = Sqlconn.DataReader("select * from Prize where  ID =@IDD", paramIDQuery);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtfullname.Text = dr["FullName"].ToString();
                            txtiqama.Text = dr["ID"].ToString();
                            txtcompany.Text = dr["Company"].ToString();
                            string CandID = dr["CandID"].ToString();
                            lblMsg.Visible = true;
                            lblMsg.Text = "Congratulations your Raffle Coupon is :  ' " + CandID + " ' , We wish you best of luck  :) ";

                        }
                        dr.Dispose();
                        dr.Close();
                        dr = Sqlconn.DataReader("Select * From Prize where Attended =  0  and ID =@IDD", paramIDQuery);


                        if (dr.HasRows)
                        {
                            dr.Dispose();
                            Sqlconn.ExecuteQueries(" update Prize set Attended = 1 where ID =@IDD ", paramIDQuery);
                        }
                        else
                        {
                            dr.Close();
                            dr.Dispose();
                        }

                    }
                    else
                    {
                      //  Response.Write("<script>alert('" + "not found" + "');</script>");

                        lblMsg2.Visible = true;
                        lblMsg2.Text = "User/Credentials not Found/Correct  :( ";
                        //    lblMsg.CssClass = "alert alert-danger";

                    }
                    dr.Close();
                    Sqlconn.CloseConnection();
                }
                catch (Exception ex)
                {

                    //  Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                    lblMsg2.Visible = true;
                    lblMsg2.Text = ex.ToString();
                }
            }
            else
            {
               // Response.Write("<script>alert('" + "Please Enter your ID/IQama" + "');</script>");
                lblMsg2.Visible = true;
                lblMsg2.Text = "Please Enter your ID/IQama";
            }


        }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            filData();
        }
    }
}