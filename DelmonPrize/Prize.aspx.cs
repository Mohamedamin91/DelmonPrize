using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace DelmonPrize
{
    public partial class Prize : System.Web.UI.Page
    {
        Sqlconnection Sqlconn = new Sqlconnection();
        Random random = new Random();
        SqlDataReader dr;
        int Winner = 0;
        int randomNumber = 0;
        int min = 0;
        int max = 0;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btncheckWinner_Click(object sender, EventArgs e)
        {
            string Celebrationemoje = "\uD83C\uDF89";
            SqlParameter paramCompanyID = new SqlParameter("@C1", SqlDbType.Int);
            SqlParameter paramWinnerID = new SqlParameter("@C2", SqlDbType.Int);


            try
            {
                Sqlconn.OpenConection();


                dr = Sqlconn.DataReader("SELECT MIN(CandID) 'MIN', MAX(CandID) 'MAX' from prize where Gifts=1 and Attended=1 ");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        min = Convert.ToInt32(dr["MIN"]);
                        max = Convert.ToInt32(dr["MAX"]);
                        randomNumber = random.Next(min, max + 1);
                        paramWinnerID.Value = randomNumber;

                    }
                    dr.Dispose();
                    dr.Close();
                    dr = Sqlconn.DataReader("SELECT company from prize where CandID = @C2 " , paramWinnerID);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            CompanyID = Convert.ToInt32(dr["company"]);
                            paramCompanyID.Value = CompanyID;
                        }
                    }

                    dr.Dispose();
                    dr.Close();
                    dr = Sqlconn.DataReader("Select * from winners where companyid = @C1  and winnerid = @C2 " , paramCompanyID,paramWinnerID);
                    if (!dr.HasRows)
                    {
                        dr.Dispose();
                        Sqlconn.ExecuteQueries("insert into winners (companyid,winnerid) values (@C1,@C2)", paramCompanyID, paramWinnerID);
                        lblMsg.Text = Celebrationemoje + " Congratulations, To The Holder of Raffle Coupon No.:  '" + randomNumber.ToString() + "' " + Celebrationemoje;
                        Page.ClientScript.RegisterStartupScript(typeof(string), "fadeMsg", "fade('" + lblMsg.ClientID + "');", true);
                    }
                    else
                    {
                        dr.Dispose();
                        dr.Close();
                    }

                    dr.Close();
                    Sqlconn.CloseConnection();



                }



                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\amin\Source\Repos\DelmonPrize\DelmonPrize\award.wav");
                //  player.Play();
                paramWinnerID.Value = randomNumber;


               
            }
           



            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                Sqlconn.CloseConnection();
            }
        }
    }
}