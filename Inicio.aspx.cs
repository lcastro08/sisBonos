using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inicio : System.Web.UI.Page
{
    consulta query = new consulta();
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        var ident = Context.User.Identity.Name.ToString();
        dt = new DataTable();
        dt = query.EjecutaConsultaSQl("SELECT dir_comercial,mandrake FROM Tbl_Acceso_Usuarios where username='" + ident + "'");

        if (Context.User.Identity.IsAuthenticated == true)
        {
            /*if (dt.Rows[0][0].ToString() == "LP - DA")
            {*/
            Lb_numases.Visible = true;
            Lb_poliza.Visible = false;
            /*}
            else
            {
                Lb_numases.Visible = false;
                Lb_numases2.Visible = true;
                Lb_nombreases.Visible = false;
                Lb_poliza.Visible = false;
                Lb_poliza2.Visible = true;
            }
        }
        else
        {
            Lb_numases.Visible = false;
            Lb_numases2.Visible = false;
            Lb_nombreases.Visible = false;
            Lb_poliza.Visible = false;
            Lb_poliza2.Visible = false;
        }*/

        }
    }
}
