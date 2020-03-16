<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="entrada.aspx.cs" Inherits="entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<nav class="fh5co-nav-style-1" role="navigation" data-offcanvass-position="fh5co-offcanvass-left">
			<div class="container">
				<div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 fh5co-logo">
					<a href="#" class="js-fh5co-mobile-toggle fh5co-nav-toggle"><i></i></a>
					<a><asp:Label ID="Label1" runat="server" Text="TA" Font-Italic="True" 
                        Font-Size="XX-Large" ForeColor="#0099CC"></asp:Label>rget</a>
                    <asp:Image ID="Image1" runat="server" Height="92px" 
                        ImageUrl="~/imagenes/Targ1.png" Width="113px"></asp:Image>
                        <br />
                        <a>
                        <asp:Label ID="Label3" runat="server" Text="Calculadora de Training" 
                        Font-Italic="True" Font-Size="Small" ForeColor="#0099CC"></asp:Label>
                        </a>
				</div>
                <div class="col-lg-6 col-md-5 col-sm-5 text-center fh5co-link-wrap">
                </div>
				<div class="col-lg-3 col-md-4 col-sm-4 text-right fh5co-link-wrap">
					<ul class="fh5co-special" data-offcanvass="yes">
						<li>
                            <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                                <AnonymousTemplate>
                                    [<a href="entrada.aspx" ID="HeadLoginStatus" runat="server">Iniciar sesión</a>]
                                </AnonymousTemplate>
                                    <LoggedInTemplate>
                                        Usuario: <span class="bold"><asp:LoginName ID="HeadLoginName" runat="server" /></span>!
                                       <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Cerrar sesión" LogoutPageUrl="~/"/> 
                                    </LoggedInTemplate>
                            </asp:LoginView>
                        </li>
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
                       
                                <asp:Login ID="Login1" runat="server" onauthenticate="Login1_Authenticate" 
                                           FailureText="Verifique sus credenciales. Inténtelo de nuevo.">
                                        <LayoutTemplate>
                                    <table border="0" cellpadding="4" cellspacing="0" 
                                            style="border-collapse:collapse;">
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0">
                                                    <tr>
                                                        <td align="center" colspan="2" 
                                                            style="color:White;background-color:#58ACFA;font-weight:bold; font-size:medium">
                                                            Iniciar sesión
                                                        </td>
                                                    </tr>
                                        <tr>
                                                <td align="right">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                                                        Font-Size="10pt" ForeColor="#CCFFFF">Nombre de usuario:  </asp:Label>
                                                </td>
                                                <td class="style3">
                                                    <asp:TextBox ID="UserName" runat="server" Font-Size="11pt" BackColor="Black" 
                                                        Width="80px" Height="20px" Font-Bold="True" ForeColor="White"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                        ControlToValidate="UserName" 
                                                        ErrorMessage="El nombre de usuario es obligatorio." 
                                                        ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">
                                                        <asp:Label ID="Label4" runat="server" Text="*" Font-Bold="True" Font-Size="Large" ForeColor="#CC9900"></asp:Label>
                                                        </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                                        Font-Size="10pt" ForeColor="#CCFFFF">Contraseña:  </asp:Label>
                                                </td>
                                                <td class="style3">
                                                    <asp:TextBox ID="Password" runat="server" Font-Size="11pt" TextMode="Password" 
                                                        BackColor="Black" Width="80px"  
                                                        Height="20px" Font-Bold="True" ForeColor="White"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                        ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." 
                                                        ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">
                                                        <asp:Label ID="Label5" runat="server" Text="*" Font-Size="Large" Font-Bold="True" ForeColor="#CC9900"></asp:Label>
                                                        </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                     <asp:CheckBox ID="RememberMe" runat="server" Font-Size="9pt" 
                                                        Text="Recordarlo la próxima vez" ForeColor="#66CCFF" /> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color:Red; font-size:small">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" colspan="2">
                                                    <p class="wow fadeInUp" data-wow-duration="1s" data-wow-delay="1.1s">
                                                        <asp:Button ID="Button1" CssClass="btn btn-primary btn-outline btn-lg" 
                                                            runat="server" BackColor="Black" 
                                                          BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                                          Font-Names="Verdana" Font-Size="10pt" ForeColor="White" 
                                                          Text="Iniciar Sesión" ValidationGroup="Login1" 
                                                          onclick="LoginButton_Click"  />

                                                    </p>
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                     </asp:Login>

                              
         <table>
            
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" 
                        Text="En caso de no recordar tu contraseña, por favor envía un correo a : lcastroh@mnyl.com.mx" 
                        Font-Bold="True" Font-Italic="True" Font-Size="Small" ForeColor="#0099CC"></asp:Label>
                </td>
            </tr>
        </table>
                              
                            </div>
                        </div>
                    </div>
                </div>
             </div>
        </div>


</asp:Content>

