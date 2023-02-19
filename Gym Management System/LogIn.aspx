<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Gym_Management_System.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
	<title>Log In</title>
	
    <meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="LoginStyle/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/vendor/bootstrap/css/bootstrap.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/fonts/iconic/css/material-design-iconic-font.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/vendor/animate/animate.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="LoginStyle/vendor/css-hamburgers/hamburgers.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/vendor/animsition/css/animsition.min.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/vendor/select2/select2.min.css">
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="LoginStyle/vendor/daterangepicker/daterangepicker.css">
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="LoginStyle/css/util.css">
	<link rel="stylesheet" type="text/css" href="LoginStyle/css/main.css">
<!--===============================================================================================-->




</head>
<body>
   
    <div>
    
        <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100">
				<form class="login100-form validate-form" id="form1" runat="server">
					<span class="login100-form-logo">
						<i class="zmdi zmdi-landscape"></i>
					</span>

					<span class="login100-form-title p-b-34 p-t-27">
						Log in
					</span>

					<div class="wrap-input100 validate-input" data-validate = "Enter username">
						
						
                        <asp:TextBox ID="txtEmail" runat="server" class="input100" placeholder="Username"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="&#xf207;"></span>
					</div>

					<div class="wrap-input100 validate-input" data-validate="Enter password">
						
                        <asp:TextBox ID="txtPass" class="input100" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <span class="focus-input100" data-placeholder="&#xf191;"></span>
					</div>

					<div class="container-login100-form-btn">	
                        <asp:Button ID="btnLogin" class="login100-form-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />
					</div>

					
				</form>
			</div>
		</div>
	</div>
	

	<div id="dropDownSelect1"></div>

    <!--===============================================================================================-->
	<script src="LoginStyle/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginStyle/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginStyle/vendor/bootstrap/js/popper.js"></script>
	<script src="LoginStyle/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginStyle/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="LoginStyle/vendor/daterangepicker/moment.min.js"></script>
	<script src="LoginStyle/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="LoginStyle/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="LoginStyle/js/main.js"></script>


    </div>
  
</body>
</html>
