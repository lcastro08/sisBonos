using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.IO;


public partial class Reportes : System.Web.UI.Page
{
    consulta query = new consulta();

    

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Btn_efectividad_Click(object sender, EventArgs e)
    {
       /* StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page page = new Page();
        HtmlForm form = new HtmlForm();

        query.EjecutaConsultaSQl(File.ReadAllText(@"~/Querys/efectividad.sql").Replace("#proceso#", aniomes));

        //Change the Header Row back to white color
        //GridView1.HeaderRow.Style.Add("background-color", "Blue");

        //for (int i = 0; i < GridView1.Columns.Count; i++)
        //{
        //    //Apply style to Individual Cells
        //    GridView1.HeaderRow.Cells[i].Style.Add("background-color", "Red");
        //}

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];

            //Change Color back to white
            //row.BackColor = System.Drawing.Color.White;

            //Apply text style to each Row
            //row.Attributes.Add("class", "textmode");

            row.Height = 30;
            //Apply style to Individual Cells of Alternating Row
            //if (i % 2 != 0)
            //{
            //    for (int j = 0; j < GridView1.Columns.Count; i++)
            //    {
            //        row.Cells[j].Style.Add("background-color", "#C2D69B");
            //    }
            //}
        }

        GridView1.EnableViewState = false;
        page.EnableEventValidation = false;
        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(GridView1);
        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("Content-Disposition", "attachment; filename= InformeDeDatos.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();*/
    }
}