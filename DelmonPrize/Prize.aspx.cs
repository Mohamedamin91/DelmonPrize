using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DelmonPrize
{
    public partial class Prize : System.Web.UI.Page
    {
        Sqlconnection Sqlconn = new Sqlconnection();
        Random random = new Random(); 
        int min = 0;
        int max = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:confettiFalling(); ", true);


        }

        protected void btncheckWinner_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this,GetType(), "Javascript", "javascript:confettiFalling(); ", true);

            try
            {
                Sqlconn.OpenConection();
                SqlDataReader dr = Sqlconn.DataReader("SELECT MIN(CandID) 'MIN', MAX(CandID) 'MAX' from prize where Gifts=1 and Attended=1 ");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //min = Convert.ToInt32( dr["MIN"]);
                        //max = Convert.ToInt32( dr["MAX"]);
                        //int randomNumber = random.Next(min, max + 1);
                        //txtwinner.Text = randomNumber.ToString();
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\amin\Source\Repos\DelmonPrize\DelmonPrize\award.wav");
                        player.Play();



                    }
                }
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