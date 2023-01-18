<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prize.aspx.cs" Inherits="DelmonPrize.Prize" %>

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
    <form id="form1" runat="server">
		 	<%--  --%>
		  <link rel="stylesheet" href="css2.css">
       	 <div class="box" id="box"></div>
	     <script src="main2.js"></script>
         <%--  --%>
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
			      		
						  </div>
								
			      	</div>
							
			      		   <div class="form-group  mb-3">
			      	<label class="label" for="name"></label>

			     <asp:Button ID="btncheckWinner" CssClass="form-control btn btn-primary submit px-3" style="background-color:#35348d;color:white" runat="server" Text="Check The Winner " OnClientClick="confettiFalling()" OnClick="btncheckWinner_Click" />
						
								 </div>
					<div class="form-group mb-3">
			      			<label class="label" for="name"></label>
			      		  <asp:TextBox ID="txtwinner" Visible="false" TextMode="multiline"  runat="server"  CssClass="form-control" Text="" style="color:black;" Enabled="false"></asp:TextBox>

					</div>

		           	<div class="form-group mb-3">
			      			<label class="label" for="name"></label>
				  <asp:Label ID="lblMsg"  CssClass="label2" style="color: #35348d ;  rotation:inherit; font-size :20px; font-weight:bold; font-family:Tahoma; align-content:center;"   runat="server"  ></asp:Label>
			      	<script>
                          var TimeToFade = 8000.0;

                   
                          function fade(eid) {
                              var element = document.getElementById(eid);
                              if (element == null)
                                  return;

                              if (element.FadeState == null) {
                                  if (element.style.opacity == null
                                      || element.style.opacity == ''
                                      || element.style.opacity == '1') {
                                      element.FadeState = 2;
                                  }
                                  else {
                                      element.FadeState = -2;
                                  }
                              }

                              if (element.FadeState == 1 || element.FadeState == -1) {
                                  element.FadeState = element.FadeState == 1 ? -1 : 1;
                                  element.FadeTimeLeft = TimeToFade - element.FadeTimeLeft;
                              }
                              else {
                                  element.FadeState = element.FadeState == 2 ? -1 : 1;
                                  element.FadeTimeLeft = TimeToFade;
                                  setTimeout("animateFade(" + new Date().getTime() + ",'" + eid + "')", 33);
                              }
						  }
                          function animateFade(lastTick, eid) {
                              var curTick = new Date().getTime();
                              var elapsedTicks = curTick - lastTick;

                              var element = document.getElementById(eid);

                              if (element.FadeTimeLeft <= elapsedTicks) {
                                  element.style.opacity = element.FadeState == 1 ? '1' : '0';
                                  element.style.filter = 'alpha(opacity = '
                                      + (element.FadeState == 1 ? '100' : '0') + ')';
                                  element.FadeState = element.FadeState == 1 ? 2 : -2;
                                  return;
                              }

                              element.FadeTimeLeft -= elapsedTicks;
                              var newOpVal = element.FadeTimeLeft / TimeToFade;
                              if (element.FadeState == 1)
                                  newOpVal = 1 - newOpVal;

                              element.style.opacity = newOpVal;
                              element.style.filter = 'alpha(opacity = ' + (newOpVal * 500) + ')';

                              setTimeout("animateFade(" + curTick + ",'" + eid + "')", 33);
                          }

                      
                      </script>
						   </div>
           
							<div class="form-group mb-3">
                
  
							</div>
		         
		            <div class="form-group d-md-flex">
		            	
						
									
		            </div>
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

