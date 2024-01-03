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

        //int min = 1;
        //int max = 5;
        //string companyname = "";
        string fullname="";
        private List<int> selectedNumbers
        {
            get
            {
                return ViewState["SelectedNumbers"] as List<int> ?? new List<int>();
            }
            set
            {
                ViewState["SelectedNumbers"] = value;
            }
        }
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
            SqlParameter paramWinnerID = new SqlParameter("@C2", SqlDbType.Int);

            try
            {
                Sqlconn.OpenConection();

                // Fetch candidate IDs that meet the specified conditions
                dr2 = Sqlconn.DataReader("SELECT CandID FROM prize WHERE [Gifts]=1 AND [Selected]=0 AND [Attended]=1");
                if (dr2.HasRows)
                {
                    int randomNumber;

                    // Continue selecting random numbers until an unused one is found
                    do
                    {
                        randomNumber = random.Next(1, 500);
                    } while (selectedNumbers.Contains(randomNumber));

                    paramWinnerID.Value = randomNumber;

                    // Retrieve the winner details based on the randomly selected number
                    dr = Sqlconn.DataReader("SELECT FullName, company FROM prize WHERE [CandID] = @C2", paramWinnerID);

                    if (dr.HasRows && dr.Read())
                    {
                        fullname = dr["FullName"].ToString();
                        txtwinner.Text = fullname;
                        lblMsg.Visible = true;
                        lblMsg.Text = Celebrationemoje + " Congratulations   '" + fullname + "' ,  The Holder of Raffle Coupon No.:  '" + randomNumber.ToString() + "' " + Celebrationemoje;
                        // Mark the candidate as selected in the database
                        Sqlconn.ExecuteQueries("UPDATE prize SET selected = 1 WHERE CandID = @C2", paramWinnerID);
                        Sqlconn.ExecuteQueries("insert into Winners (WinnerID) values (@C2) ", paramWinnerID);

                        lblwinner.Text = randomNumber.ToString();
                        Page.ClientScript.RegisterStartupScript(typeof(string), "fadeMsg", "fade('" + lblMsg.ClientID + "');", true);
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "uKey", "PlaySoundNow();", true);

                        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                        string soundUrl = Server.MapPath("~/award.wav");
                        player.SoundLocation = soundUrl;
                        player.Play();

                        // Add the selected number to the list
                        selectedNumbers.Add(randomNumber);
                    }
                }
                else
                {
                    txtwinner.Text = "";
                    lblMsg2.Text = "We are sad to inform you that the scheduled number of prizes has ended... " +
                        " Good luck to those who are not selected this year." +
                        " We look forward to having you with us next year - 2025. " +
                        " Thanks for coming  " + Sadnessemoje;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Sqlconn.CloseConnection();

                // Clear the selectedNumbers list after all processing is done
                selectedNumbers.Clear();
            }
        }
    }
}