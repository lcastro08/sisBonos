<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
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
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #I1
        {
            width: 975px;
            height: 663px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    
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
                <br />
                <br />
          
					<%-- --%>
                </div>

				<div class="col-lg-3 col-md-4 col-sm-4 text-right fh5co-link-wrap">
					<ul class="fh5co-special" data-offcanvass="yes">
						<li>
                            <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                                <AnonymousTemplate>
                                    [<a href="entrada.aspx" ID="HeadLoginStatus" runat="server">Iniciar sesión</a>]
                                </AnonymousTemplate>
                                    <LoggedInTemplate>
                                        Usuario: <span class="bold"><asp:LoginName ID="HeadLoginName" runat="server" Font-Size="Medium" /></span>!
                                       <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Cerrar sesión" LogoutPageUrl="~/"/> 
                                    </LoggedInTemplate>
                            </asp:LoginView>
                        </li>
					</ul>
				</div>
                                <div>
                                <div class="col-lg-6 col-md-5 col-sm-5 text-center fh5co-link-wrap">
                                    <ul data-offcanvass="yes">
                                    <hr />
                                        <li><a href="asesor.aspx" target="I1"><asp:Label ID="Lb_numases" runat="server" Text="Número de Asesor"
                                                Font-Bold="False" BackColor="Black" ForeColor="White"></asp:Label></a></li>
						                <li><a href="principal.aspx" target="I1"><asp:Label ID="Lb_poliza" runat="server" Text="Reportes" 
                                                BackColor="Black" Font-Bold="False" ForeColor="White" Visible="False"></asp:Label></a></li>
                                    <hr />
                                 <%--    <asp:Label ID="Label3" runat="server" 
                                                Text="*Cualquier ajuste que se requiera para el reporte de Efectividad TA tendrá que ser ingresado vía folio en operaciones." 
                                                Font-Bold="True" Font-Size="XX-Small" ForeColor="#33CCCC"></asp:Label>
                                    --%>
                                    </ul>
                                
                                </div>
                                    
                                    <iframe id="I1" name="I1" scrolling="auto" frameborder="0" class="bgcol"></iframe>
                                </div>
			</div>
		</nav>

        <div class="fh5co-cover fh5co-cover-style-2 js-full-height" data-stellar-background-ratio="0.5" data-next="yes"  style="background-image: url(imagenes/torr.jpg);">
		  	<span class="scroll-btn wow fadeInUp" data-wow-duration="1s" data-wow-delay="1.4s">
                
			</span>
			<div class="fh5co-overlay"></asp:Label></div>
			<div class="fh5co-cover-text">
				<div class="container">
					<div class="row">
						<div class="col-md-push-6 col-md-6 full-height js-full-height">
							<div class="fh5co-cover-intro">
							</div>
						</div>
					</div>
				</div>	
			</div>
		</div>

</asp:Content>

