﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="DelmonPrize.Confirm" %>
<!doctype html>
<html lang="en">
  <head>
  	<title>Login 07</title>
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
								<h2>Delmon Annual Party (42) anniversary-2023</h2>
								<p>This is a great chance for us to come together as a team, celebrate all the hard work we've put in throughout the year, and just have some fun..</p>
								<p ><b>* Please</b> register and attend for getting a chance to win prizes</p>
							</div>
			      </div>
						<div class="login-wrap p-4 p-lg-5">
			      	<div class="d-flex">
			      		<div class="w-100">
			      			<h3 class="mb-4">Sign In</h3>
			      		</div>
								
			      	</div>
							<form action="#" class="signin-form">
			      		<div class="form-group mb-3">
			      			<label class="label" for="name">ID/IQAMA</label>
							     <asp:TextBox ID="txtUserInput" CssClass="form-control" placeholder="Enter Your ID/IQama" runat="server"  Enabled="True"></asp:TextBox>	
		                 	
			      		</div>
								<div class="form-group mb-3">
			      			<label class="label" for="name">Full Name</label>
			      		 <asp:TextBox ID="txtfullname" runat="server"  CssClass="form-control" Text="Full Name"  Enabled="false"></asp:TextBox>		
				     
			      		</div>
								<div class="form-group mb-3">
			      			<label class="label" for="name">ID/IQama</label>
			      			      <asp:TextBox ID="txtiqama" runat="server"   CssClass="form-control" Text="ID/IQama"  Enabled="false"></asp:TextBox>
				         
			      		</div>
								<div class="form-group mb-3">
			      			<label class="label" for="name">Company</label>
			      		  <asp:TextBox ID="txtcompany" runat="server"  CssClass="form-control" Text="Company " Enabled="false"></asp:TextBox>
			      		</div>
		           
		            <div class="form-group">
			     <asp:Button ID="btnconfirm" CssClass="form-control btn btn-primary submit px-3" runat="server" Text="Confirm"    />
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


