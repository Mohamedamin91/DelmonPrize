using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;

namespace DelmonPrize
{
    public partial class Prize : System.Web.UI.Page
    {
        Sqlconnection Sqlconn = new Sqlconnection();
        SpeechAudioFormatInfo info = new SpeechAudioFormatInfo(6, AudioBitsPerSample.Sixteen, AudioChannel.Mono);


        SqlDataReader dr;
        SqlDataReader dr2;
        SqlDataReader dr3;

       // int randomNumber = 0;
        int min = 1;
        int max = 5;
        string companyname = "";
        string fullname;
        
        List<int> numbers = new List<int>();
        Random rand = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                //your code here...
            }


        }


        protected void btncheckWinner_Click(object sender, EventArgs e)
        {
            string Celebrationemoje = "\uD83C\uDF89";
            string Sadnessemoje = "☹️";
            SqlParameter paramCompanyID = new SqlParameter("@C1", SqlDbType.Int);
            SqlParameter paramWinnerID = new SqlParameter("@C2", SqlDbType.Int);


            try
            {
                Sqlconn.OpenConection();
                while (numbers.Count < 5)
                {
                    int randomNumber = rand.Next(1, 5);
                    paramWinnerID.Value = randomNumber;
                    if (!numbers.Contains(randomNumber))
                    {
                        numbers.Add(randomNumber);
                        dr2 = Sqlconn.DataReader("SELECT FullName ,COMPName_EN from prize,Companies where Companies.CRNumber = prize.Company and Gifts = 1 and Selected = 0 and Attended = 1 and CandID= " + randomNumber + " ");
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                fullname = dr2["FullName"].ToString();
                                companyname = dr2["COMPName_EN"].ToString();
                            }
                            lblMsg.Text = Celebrationemoje + " Congratulations  '" + fullname + "' ,  The Holder of Raffle Coupon Number.:  '" + randomNumber.ToString() + "' " + Celebrationemoje;
                            lblMsg.Visible = true;
                            Page.ClientScript.RegisterStartupScript(typeof(string), "fadeMsg", "fade('" + lblMsg.ClientID + "');", true);
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\amin\Source\Repos\DelmonPrize\DelmonPrize\award.wav");
                            //  player.Play();
                            Sqlconn.ExecuteQueries("update prize set Selected = 1 where CandID=@C2 ", paramWinnerID);

                        }

                    }
                }





                    

                          
                       


                    




                } 
                



                //else
                //{
                //    lblMsg.Text = string.Empty;
                //    lblMsg2.Text = "Sorry, there are no more candidates available " + Sadnessemoje;
                //    Page.ClientScript.RegisterStartupScript(typeof(string), "fadeMsg", "fade('" + lblMsg2.ClientID + "');", true);

                //}








               
            




            catch (Exception ex)
            {
                lblMsg2.Text = ex.ToString();
            
            }
            finally
            {

                Sqlconn.CloseConnection();
            }
            Page.DataBind();
        }
    }
}