<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
    

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

    <link rel="shortcut icon" href="favicon.ico">
	
	<!-- Google Fonts -->
	<link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,700|Monsterrat:400,700|Merriweather:400,300italic,700' rel='stylesheet' type='text/css'>
	
	<!-- Animate.css -->
	<link rel="stylesheet" href="css/animate.css">
	<!-- Icomoon Icon Fonts-->
	<link rel="stylesheet" href="css/icomoon.css">
	<!-- Magnific Popup-->
	<link rel="stylesheet" href="css/magnific-popup.css">
	<!-- Owl Carousel -->
	<link rel="stylesheet" href="css/owl.carousel.min.css">
	<link rel="stylesheet" href="css/owl.theme.default.min.css">
	<!-- Bootstrap  -->
	<link rel="stylesheet" href="css/bootstrap.css">
	
	<!-- Cards -->
	<link rel="stylesheet" href="css/cards.css">

	<!-- Modernizr JS -->
	<script src="js/modernizr-2.6.2.min.js"></script>
	<!-- FOR IE9 below -->
	<!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="fh5co-page">
		<nav class="fh5co-nav-style-1" role="navigation" data-offcanvass-position="fh5co-offcanvass-left">
			<div class="container">
				<div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 fh5co-logo">
					<a href="#" class="js-fh5co-mobile-toggle fh5co-nav-toggle"><i></i></a>
					<a><asp:Label ID="Label2" runat="server" Text="TA" Font-Italic="True" 
                        Font-Size="XX-Large" ForeColor="#0099CC"></asp:Label>rget</a>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/Targ1.png" 
                        Height="92px" Width="113px" />
                    <br />
                    <a>
                    <asp:Label ID="Label1" runat="server" Text="Calculadora de Training" 
                        Font-Italic="True" Font-Size="Small" ForeColor="#0099CC"></asp:Label></a>
				</div>

                <div class="col-lg-6 col-md-5 col-sm-5 text-center fh5co-link-wrap">
					<ul data-offcanvass="yes">
                    </ul>
                </div>

				<div class="col-lg-3 col-md-4 col-sm-4 text-right fh5co-link-wrap">
					<ul class="fh5co-special" data-offcanvass="yes">
						<li><a href="registro.aspx" class="call-to-action">Registrarse</a></li>
					</ul>
				</div>
			</div>
		</nav>

        <div class="fh5co-cover fh5co-cover-style-2 js-full-height" data-stellar-background-ratio="0.5" data-next="yes"  style="background-image: url(imagenes/torr.jpg);">
		  	<span class="scroll-btn wow fadeInUp" data-wow-duration="1s" data-wow-delay="1.4s">
                
			</span>
			<div class="fh5co-overlay"></div>
			<div class="fh5co-cover-text">
				<div class="container">
					<div class="row">
						<div class="col-md-push-6 col-md-6 full-height js-full-height">
							<div class="fh5co-cover-intro">
								<h1 class="cover-text-lead wow fadeInUp" data-wow-duration="1s" data-wow-delay=".5s">Seguros Monterrey New York Life</h1>
								<h2 class="cover-text-sublead wow fadeInUp" data-wow-duration="1s" data-wow-delay=".8s">Bienvenido, inicia sesi&oacute;n para continuar.</h2>
								<p class="wow fadeInUp" data-wow-duration="1s" data-wow-delay="1.1s"><a href="entrada.aspx" class="btn btn-primary btn-outline btn-lg">Entrar</a></p>
							</div>
						</div>
					</div>
				</div>	
			</div>
		</div>
</asp:Content>
