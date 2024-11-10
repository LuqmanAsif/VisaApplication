<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VisaApplication.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap-grid.css" rel="stylesheet" />
    <link href="Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-grid.rtl.css" rel="stylesheet" />
    <link href="Content/bootstrap-grid.rtl.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-reboot.css" rel="stylesheet" />
    <link href="Content/bootstrap-reboot.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-reboot.rtl.css" rel="stylesheet" />
    <link href="Content/bootstrap-reboot.rtl.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-utilities.css" rel="stylesheet" />
    <link href="Content/bootstrap-utilities.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-utilities.rtl.css" rel="stylesheet" />
    <link href="Content/bootstrap-utilities.rtl.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.rtl.css" rel="stylesheet" />
    <link href="Content/bootstrap.rtl.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <style>
         body{
        padding-top:4.2rem;
		padding-bottom:4.2rem;
		background:rgba(0, 0, 0, 0.76);
        }
        a{
         text-decoration:none !important;
         }
         h1,h2,h3{
         font-family: 'Kaushan Script', cursive;
         }
          .myform{
        position: relative;
		display: -ms-flexbox;
		display: flex;
		padding: 1rem;
		-ms-flex-direction: column;
		flex-direction: column;
		width: 100%;
		pointer-events: auto;
		background-color: #fff;
		background-clip: padding-box;
		border: 1px solid rgba(0,0,0,.2);
		border-radius: 1.1rem;
		outline: 0;
		max-width: 500px;
		 }
         .tx-tfm{
         text-transform:uppercase;
         }
         .mybtn{
         border-radius:50px;
         }
        
         .login-or {
         position: relative;
         color: #aaa;
         margin-top: 10px;
         margin-bottom: 10px;
         padding-top: 10px;
         padding-bottom: 10px;
         }
         .span-or {
         display: block;
         position: absolute;
         left: 50%;
         top: -2px;
         margin-left: -25px;
         background-color: #fff;
         width: 50px;
         text-align: center;
         }
         .hr-or {
         height: 1px;
         margin-top: 0px !important;
         margin-bottom: 0px !important;
         }
          form .error {
         color: #ff0000;
         }
         
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
        <div class="row">
			<div class="col-md-5 mx-auto">
			  <div id="first">
				<div class="myform form">
					 <div class="logo mb-3">
						 <div class="col-md-12 text-center">
							<h1>Login</h1>
						 </div>
					</div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Email address</label>
                        <asp:Textbox runat="server"  name="email" CssClass="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email"></asp:Textbox>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Password</label>
                        <asp:Textbox runat="server" type="password" name="password" id="password"  CssClass="form-control" aria-describedby="emailHelp" placeholder="Enter Password"></asp:Textbox>
                    </div>
                    <div class="form-group">
                        <p class="text-center">By signing up you accept our <a href="#">Terms Of Use</a></p>
                    </div>
                    <div class="col-md-12 text-center ">
                        <asp:button runat="server" ID="loginbutton" OnClick="loginbutton_Click" CssClass=" btn btn-block mybtn btn-primary tx-tfm" Text="Login"></asp:button>
                    </div>
                    <div class="col-md-12 ">
                        <div class="login-or">
                            <hr class="hr-or">
                            <span class="span-or">or</span>
                        </div>
                    </div>
                    <div class="form-group">
                        <p class="text-center">Don't have account? <a href="Signup.aspx" id="signup">Sign up here</a></p>
                    </div>
				</div>
			</div>
            </div>
        </div>
       </div>
    </form>
</body>
</html>
