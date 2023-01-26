using Google.Cloud.TextToSpeech.V1;
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
//using Google.Cloud.TextToSpeech.V1;


namespace DelmonPrize
{
    public partial class Prize : System.Web.UI.Page
    {
        Sqlconnection Sqlconn = new Sqlconnection();
        SpeechAudioFormatInfo info = new SpeechAudioFormatInfo(6, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
        SpeechSynthesizer synth = new SpeechSynthesizer();



        SqlDataReader dr;
        SqlDataReader dr2;
        Random random = new Random();

        int randomNumber = 0;
        int CompanyID = 0;
        //int min = 1;
        //int max = 5;
        string companyname = "";
        string fullname="";
        
        List<int> numbers = new List<int>();
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

               
                dr = Sqlconn.DataReader("Select * From Prize ");
                if (dr.HasRows)
                {
                    randomNumber = random.Next(1, 5);
                    paramWinnerID.Value = randomNumber;
                    txtcompany.Text = "";
                    txtwinner.Text = "";
                    lblMsg.Text = "";
                    lblMsg3.Text = lblMsg.Text;
                    while (dr.Read())
                    {
                      
                        dr2 = Sqlconn.DataReader("SELECT FullName,COMPName_EN, company from prize, Companies where prize.company=Companies.CRNumber and  [Gifts]=1   and [Selected]=0   and [Attended] =1  and CandID = @C2 ", paramWinnerID);
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                CompanyID = Convert.ToInt32(dr2["company"]);
                                fullname = dr2["FullName"].ToString();
                                companyname = dr2["COMPName_EN"].ToString();
                                paramCompanyID.Value = CompanyID;

                            }
                            txtcompany.Text = companyname;
                            txtwinner.Text = fullname;
                            Sqlconn.ExecuteQueries("update  prize set selected = 1 where  CandID = @C2 ", paramWinnerID);
                            lblMsg.Text = Celebrationemoje + " Congratulations   '" + fullname + "' ,  The Holder of Raffle Coupon No.:  '" + randomNumber.ToString() + "' " + Celebrationemoje;
                            //synth.Speak(lblMsg.Text);
                            lblMsg3.Text = lblMsg.Text;
                            Page.ClientScript.RegisterStartupScript(typeof(string), "fadeMsg", "fade('" + lblMsg.ClientID + "');", true);
                       //     ScriptManager.RegisterClientScriptBlock(this, GetType(), "uKey", "PlaySoundNow();", true);
                         
                            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                            //string soundUrl = "http://www.Delmon.sa/award.wav";
                            //player.SoundLocation = soundUrl;
                            //player.Play();






                        }


                    }
                   
                }
                else
                {
                    txtcompany.Text = "";
                    txtwinner.Text = "";
                    //  lblMsg.Text = "";
                    lblMsg2.Text = "We are sad to inform you that the scheduled number of prizes has ended... " +
                        " Good luck to those who are not selected this year." +
                        " We look forward to having you with us next year - 2024. " +
                        " Thanks for coming  " + Sadnessemoje;
                    // Page.ClientScript.RegisterStartupScript(typeof(string), "fadeMsg", "fade('" + lblMsg2.ClientID + "');", true);

                }


            }
            catch (Exception)
            {

                throw;
            }
       
        
        
        }
    }
}