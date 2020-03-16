using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class entrada : System.Web.UI.Page
{
    Logeo logeo = new Logeo();
    MasterPage frm = new MasterPage();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            String[] valores;
            valores = logeo.Autentificacion(Login1.UserName, Login1.Password);

            if (valores[1] == Login1.UserName)
            {
                if (valores[2] == Login1.Password)
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
                    Response.Redirect("inicio.aspx");

                }
            }
        }
        catch (Exception ex)
        {
            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + ex.Message + "');</script>");
        }
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }
}