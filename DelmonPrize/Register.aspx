<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DelmonPrize.Register" %>

<!DOCTYPE html>
<html>
<head>
 
	<link rel="stylesheet" href="style.css">
	    <link href="../Css.css" rel="stylesheet">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
	<title>Login Form Using HTML And CSS Only</title>
	
 <div class="col-lg-3 col-md-2">
                            <!-- Logo -->
                            <div class="logo">
                                <a href="#"><img style="margin-bottom:25px;" src="../Delmonlogo.jpg" width="150" height="100" alt=""></a>
                            </div> 
	                     <asp:Label ID="lblMsg" runat="server" ></asp:Label>


                        </div>    
</head>
<body >
	 
	
	<div class="container" id="container">
		<div class="form-container log-in-container">
			<form action="#" runat="server">
				<h1 style="margin-bottom:20px; color:#35348d">Register</h1>
				<%--<div class="social-container">
					
				</div>--%>
			
                <asp:TextBox ID="txtUserInput" style="margin-bottom:25px; color:black" runat="server" placeholder="Enter Your ID/IQama"  Enabled="True"></asp:TextBox>	
				<asp:TextBox ID="txtfullname" runat="server" Text="Full Name" Enabled="false"></asp:TextBox>		
				<asp:TextBox ID="txtiqama" runat="server" Text="ID/IQama" Enabled="false"></asp:TextBox>
				<asp:TextBox ID="txtcompany" runat="server" Text="Company " Enabled="false"></asp:TextBox>
			     <asp:Button ID="btnconfirm" CssClass="button" runat="server" Text="Confirm" style=" color:white ;margin-top:50px;" OnClick="btnconfirm_Click"  />
				<style>
	.button
{
    border-radius: 20px;
    border: 1px solid #35348d;
    background-color: #35348d;
    color: #FFFFFF;
    font-size: 12px;
    font-weight: bold;
    padding: 12px 45px;
    letter-spacing: 1px;
    text-transform: uppercase;
    transition: transform 80ms ease-in;
}
				</style>

			</form>
			
		</div>
		<div class="overlay-container">
			<div class="overlay">
				<div  class="overlay-panel overlay-right">
					<h1 style="margin-bottom:35px;">Delmon Annual Party - 2023</h1>
					<p> This is a great chance for us to come together as a team, celebrate all the hard work we've put in throughout the year, and just have some fun..</p>
				    <p ><b>* Please</b> register and attend for getting a chance to win prizes</p>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
