<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confeirrm.aspx.cs" Inherits="DelmonPrize.Confirm" %>

<!doctype html>
<html lang="en">
  <head>
  	 <title>Delmon Group | Annual Party </title>
	<link rel="icon" href="../Delmonlogo.jpg">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

	<link href="https://fonts.googleapis.com/css?family=Lato:300,400,700,900&display=swap" rel="stylesheet">

	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
	
	<link rel="stylesheet" href="Main.css">

	</head>
	<body>
	<form action="#" runat="server">
	<section class="ftco-section">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-md-6 text-center mb-5">
					<h2 class="heading-section"><img src="../Delmonlogo.jpg" width="150" height="100" alt="" /></h2>
				</div>
			</div>
			<div class="row justify-content-center">
				<div class="col-md-12 col-lg-10">
					<div class="wrap d-md-flex">
						<div class="text-wrap p-4 p-lg-5 text-center d-flex align-items-center order-md-last">
							<div class="text w-100">
								<h2>42<sup style= "font-size:20px; font-family:'sans-serif' ">nd</sup> -  Delmon Annual Party Anniversary-2023</h2>
								<p>This is a great chance for us to come together as a team, celebrate all the hard work we've put in throughout the year, and just have some fun..</p>
								<p ><b>* Please</b> register and attend for getting a chance to win prizes</p>
							</div>
			      </div>
						<div class="login-wrap p-4 p-lg-5">
			      	<div class="d-flex">
			      		<div class="w-100">
			      		
		                 <asp:Label ID="lblMsg" CssClass="mb-4" style="color: #35348d ; font-size :24px; font-weight:bold; " runat="server" ></asp:Label>
		                 <asp:Label ID="lblMsg2" CssClass="mb-4" style="color: #eb2d2e ; font-size :24px; font-weight:bold; " runat="server" ></asp:Label>

						  </div>
								
			      	</div>
							<form action="#" class="signin-form">
			      		<div class="form-group mb-3">
			      			<label class="label" for="name"></label>
							     <asp:TextBox ID="txtUserInput" CssClass="form-control" placeholder="Enter Your ID/IQama" style="color:gray" runat="server"  Enabled="True"></asp:TextBox>	
		                 	
			      		</div>
								<div class="form-group mb-3">
			      			<label class="label" for="name"></label>
			      		 <asp:TextBox ID="txtfullname" runat="server"  CssClass="form-control" Text="Full Name" style="color:black"  Enabled="false"></asp:TextBox>		
				     
			      		</div>
								<div class="form-group mb-3">
			      			<label class="label" for="name"></label>
			      			      <asp:TextBox ID="txtiqama" runat="server"   CssClass="form-control" Text="ID/IQama" style="color:black" Enabled="false"></asp:TextBox>
				         
			      		</div>
								<div class="form-group mb-3">
			      			<label class="label" for="name"></label>
			      		  <asp:TextBox ID="txtcompany" runat="server"  CssClass="form-control" Text="Company" style="color:black" Enabled="false"></asp:TextBox>
			      		</div>
		           
		            <div class="form-group  mb-3">
			      	<label class="label" for="name"></label>

			     <asp:Button ID="btnconfirm" CssClass="form-control btn btn-primary submit px-3" style="background-color:#35348d;color:white" runat="server" OnClick="btnconfirm_Click" Text="Confirm"    />
		            </div>
		            <div class="form-group d-md-flex">
		            	
						
									
		            </div>
		          </form>
		        </div>
		      </div>
				</div>
			</div>
		</div>
	</section>

	<script src="js/jquery.min.js"></script>
  <script src="js/popper.js"></script>
  <script src="js/bootstrap.min.js"></script>
  <script src="js/main.js"></script>
		</form>
	</body>
</html>


