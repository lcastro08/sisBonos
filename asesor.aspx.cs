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

public partial class asesor : System.Web.UI.Page
{
    consulta query = new consulta();
    DataTable dt; 
    DataTable dt2;
    DataTable dt3;
    string unNumero;
    int numero1;
    string ganador;
    string ganador1;
    string ganador2;
    string ganador3;
    string ganador4;
    string ganador5;

    /*string variable;*/
    string variable = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        datos_ases.Visible = false;
        datos_ases_dos.Visible = false;

        dt = new DataTable();
        dt = query.EjecutaConsultaSQl("Select Convert(char(10), MAX(F_PAGO), 103) from POLIZARIO15");
        Label1.Text = dt.Rows[0][0].ToString();
                

     /*   if (Context.User.Identity.IsAuthenticated == true)
        {
            try
            {
                dt = new DataTable();
                dt = query.EjecutaConsultaSQl("Select Convert(char(10), MAX(F_PAGO), 103) from POLIZARIO15");
                Label1.Text = dt.Rows[0][0].ToString();
                variable = Request.QueryString["variable"];
                buscame(variable);

            }
            catch (Exception ex)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Redirect("");
        }
        */
    }
    protected void btn_asesor_Click(object sender, EventArgs e)
    {
        buscame(txt_asesor.Text);
    }

    
    public void buscame(string valor)
    {
        try
        {
            dt = new DataTable();
            dt = query.EjecutaConsultaSQl("SELECT SUM(CAMP1) AS POLIZAS, SUM(COM01_A+COM02_A+COM03_A+COM04_A+COM05_A+COM06_A+COM07_A+COM08_A+COM09_A+COM10_A+COM11_A+COM12_A+COM01+COM02+COM03+COM04+COM05+COM06+COM07+COM08+COM09+COM10+COM11+COM12) AS COMISION FROM CAMPAÑA_DETALLE_TARGET WHERE age1 = " + valor + " AND  (C1>=-6) AND CAMP1>0 ");
            Lb_tot_polizas.Text = dt.Rows[0][0].ToString();
            Lb_comision.Text = dt.Rows[0][1].ToString();

            if (Lb_tot_polizas.Text == "")
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('No hay pólizas registradas con este No. De asesor');</script>");
                historia_meses.Visible = false;
            }

            else
            {

                unNumero = Lb_comision.Text;
                Lb_comision.Text = string.Format("{0:###,###,###,##0.00##}", Decimal.Parse(unNumero));
                datos_asesor(txt_asesor.Text);
            }
        }
        catch (Exception ex)
        {

            this.Page.Response.Write("<script language='JavaScript'>window.alert('" + ex.Message + "');</script>");
            /*this.Page.Response.Write("<script language='JavaScript'>window.alert('Este asesor no está en sus primeros 12 meses');</script>");*/
            datos_ases.Visible = false;
            datos_ases_dos.Visible = false;
        }

    }

    public void datos_asesor(string valor)
    {
        dt = new DataTable();
        dt = query.EjecutaConsultaSQl("SELECT NOMBRE_DEL,PROM,GRUPO,Convert(char(10),CONCURSO, 103),TMPDEF FROM AGENTES WHERE NUM_AGENTE=" + valor + " AND PROCESO=(SELECT MAX (Proceso) FROM AGENTES)");
        Lb_nombre_ases.Text = dt.Rows[0][0].ToString();
        Lb_grupo_ases.Text = dt.Rows[0][2].ToString();
        Lb_concurso.Text = dt.Rows[0][3].ToString();
        datos_ases.Visible = true;
        datos_ases_dos.Visible = true;

        if (dt.Rows[0][4].ToString() == "S")
        {
            CheckBox1.Checked = true;
        }
        else
        {
            CheckBox1.Checked = false;
        }

        dt = new DataTable();
        dt = query.EjecutaConsultaSQl("SELECT B.DESC_VTA FROM AGENTES A INNER JOIN CATALOGO B ON A.PROM=B.PROM_SUC WHERE A.NUM_AGENTE=" + valor + "AND (A.PROCESO=(SELECT MAX (Proceso) FROM AGENTES)) AND (B.PROCESO=(SELECT MAX (Proceso) FROM CATALOGO))");
        Lb_dircomer.Text = dt.Rows[0][0].ToString();
        meses_polizas(txt_asesor.Text);
    }

    public void meses_polizas(string valor)
    {
        
        dt3 = new DataTable();
            /*dt3 = query.EjecutaConsultaSQl("SELECT RECORRIMIENTOANUAL from HISTORIATA WHERE AGENTE=" + valor + " AND PROCESO=(SELECT MAX (Proceso) FROM HISTORIATA)");*/
        dt3 = query.EjecutaConsultaSQl("SELECT datediff([month],[CONCURSO] ,(Select MAX(fecha_de_c) from agentes where proceso=(SELECT MAX (Proceso) FROM agentes)))+1 FROM AGENTES WHERE NUM_AGENTE=" + valor + " AND PROCESO=(SELECT MAX (Proceso) FROM AGENTES)");
        
        if(CheckBox1.Checked==true)
        {
            Lb_mes.Text = "0";
            Label14.Visible = true;
        }
        else
        {
            Lb_mes.Text = dt3.Rows[0][0].ToString();
            Label14.Visible = false;
        }
        
        numero1 = int.Parse(Lb_mes.Text);
            /*if (dt3.Rows.Count > 0)*/
            if (numero1>12)
            {
                this.Page.Response.Write("<script language='JavaScript'>window.alert('Este asesor no está en sus primeros 12 meses');</script>");
                datos_ases.Visible = false;
                datos_ases_dos.Visible = false;
                GridView1.Visible = false;
                historia_meses.Visible = false;

            }
            else if (numero1>=0 & numero1<=12)
            {
                /*Lb_mes.Text = "0";*/
                datos_ases.Visible = true;
                datos_ases_dos.Visible = true;
                GridView1.Visible = true;
                historia_meses.Visible = true;
                dt3 = new DataTable();
            //dt3 = query.EjecutaConsultaSQl("SELECT RECORRIMIENTOANUAL,[GANADOR MES] FROM HISTORIATA WHERE AGENTE=" + valor + "AND RECORRIMIENTOANUAL<=6 ORDER BY RECORRIMIENTOANUAL");
            dt3 = query.EjecutaConsultaSQl("SELECT RECORRIMIENTOANUAL,[GANADOR MES] FROM HISTORIATA WHERE AGENTE=" + valor + " ORDER BY RECORRIMIENTOANUAL");
            numero1 = dt3.Rows.Count;

                if (numero1 > 6 & numero1 <= 12)
                {
                    Image8.Visible = false;
                    Lb_tittle_meta_pol.Visible = false;
                    Lb_meta_pol.Visible = false;
                    Lb_tittle_meta_com.Visible = false;
                    Lb_meta_com.Visible = false;
                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    ganador4 = dt3.Rows[4][1].ToString();
                    ganador5 = dt3.Rows[5][1].ToString();

                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador3 == "1")
                    {
                        Image5.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador3 == "0")
                    {
                        Image5.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador4 == "1")
                    {
                        Image6.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador4 == "0")
                    {
                        Image6.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador5 == "1")
                    {
                        Image7.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador5 == "0")
                    {
                        Image7.ImageUrl = "imagenes/no.png";
                    }
                }

                if (numero1 == 6 & Lb_grupo_ases.Text == "2")
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "18";
                    Lb_meta_com.Text = "42,000";
                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    ganador4 = dt3.Rows[4][1].ToString();
                    ganador5 = dt3.Rows[5][1].ToString();

                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador3 == "1")
                    {
                        Image5.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador3 == "0")
                    {
                        Image5.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador4 == "1")
                    {
                        Image6.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador4 == "0")
                    {
                        Image6.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador5 == "1")
                    {
                        Image7.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador5 == "0")
                    {
                        Image7.ImageUrl = "imagenes/no.png";
                    }
                }

                if ((numero1 == 6 & (Lb_grupo_ases.Text == "0" || Lb_grupo_ases.Text == "4" || Lb_grupo_ases.Text == "5")))
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "18";
                    Lb_meta_com.Text = "42,000";
                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    ganador4 = dt3.Rows[4][1].ToString();


                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador3 == "1")
                    {
                        Image5.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador3 == "0")
                    {
                        Image5.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador4 == "1")
                    {
                        Image6.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador4 == "0")
                    {
                        Image6.ImageUrl = "imagenes/no.png";
                    }
                    Image7.ImageUrl = "imagenes/no.png";
                }

                if (numero1 == 5 & Lb_grupo_ases.Text=="2")
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "15";
                    Lb_meta_com.Text = "33,000";

                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    ganador4 = dt3.Rows[4][1].ToString();

                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador3 == "1")
                    {
                        Image5.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador3 == "0")
                    {
                        Image5.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador4 == "1")
                    {
                        Image6.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador4 == "0")
                    {
                        Image6.ImageUrl = "imagenes/no.png";
                    }

                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if ((numero1 == 5 & (Lb_grupo_ases.Text == "0" || Lb_grupo_ases.Text == "4" || Lb_grupo_ases.Text == "5")))
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "15";
                    Lb_meta_com.Text = "33,000";

                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador3 == "1")
                    {
                        Image5.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador3 == "0")
                    {
                        Image5.ImageUrl = "imagenes/no.png";
                    }
                    Image6.ImageUrl = "imagenes/no.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if (numero1 == 4 & Lb_grupo_ases.Text == "2")
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "12";
                    Lb_meta_com.Text = "25,000";
                
                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador3 == "1")
                    {
                        Image5.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador3 == "0")
                    {
                        Image5.ImageUrl = "imagenes/no.png";
                    }
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if ((numero1 == 4 & (Lb_grupo_ases.Text == "0" || Lb_grupo_ases.Text == "4" || Lb_grupo_ases.Text == "5")))
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "12";
                    Lb_meta_com.Text = "25,000";

                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                    ganador3 = dt3.Rows[3][1].ToString();
                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }

                    Image5.ImageUrl = "imagenes/no.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if (numero1 == 3 & Lb_grupo_ases.Text == "2")
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "9";
                    Lb_meta_com.Text = "18,000";

                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();
                   
                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador2 == "1")
                    {
                        Image4.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador2 == "0")
                    {
                        Image4.ImageUrl = "imagenes/no.png";
                    }
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if ((numero1 == 3 & (Lb_grupo_ases.Text == "0" || Lb_grupo_ases.Text == "4" || Lb_grupo_ases.Text == "5")))
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "9";
                    Lb_meta_com.Text = "18,000";

                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                    ganador2 = dt3.Rows[2][1].ToString();

                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }
                    Image4.ImageUrl = "imagenes/no.png";
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if (numero1 == 2 & Lb_grupo_ases.Text == "2")
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "6";
                    Lb_meta_com.Text = "12,000";


                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();
                   
                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    if (ganador1 == "1")
                    {
                        Image3.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador1 == "0")
                    {
                        Image3.ImageUrl = "imagenes/no.png";
                    }

                    Image4.ImageUrl = "imagenes/dud.png";
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

                if ((numero1 == 2 & (Lb_grupo_ases.Text == "0" || Lb_grupo_ases.Text == "4" || Lb_grupo_ases.Text == "5")))
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "6";
                    Lb_meta_com.Text = "12,000";

                    ganador = dt3.Rows[0][1].ToString();
                    ganador1 = dt3.Rows[1][1].ToString();

                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }

                    Image3.ImageUrl = "imagenes/no.png";
                    Image4.ImageUrl = "imagenes/dud.png";
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }
                if (numero1 == 1 & Lb_grupo_ases.Text == "2")
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "3";
                    Lb_meta_com.Text = "7,500";
                    ganador = dt3.Rows[0][1].ToString();
                   
                    if (ganador == "1")
                    {
                        Image2.ImageUrl = "imagenes/si.png";
                    }
                    else if (ganador == "0")
                    {
                        Image2.ImageUrl = "imagenes/no.png";
                    }
                    Image3.ImageUrl = "imagenes/dud.png";
                    Image4.ImageUrl = "imagenes/dud.png";
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }
            }

        if ((numero1 == 1 & (Lb_grupo_ases.Text == "0" || Lb_grupo_ases.Text == "4" || Lb_grupo_ases.Text == "5")))
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "3";
                    Lb_meta_com.Text = "7,500";
                    ganador = dt3.Rows[0][1].ToString();
                   
                    Image2.ImageUrl = "imagenes/no.png";
                    Image3.ImageUrl = "imagenes/dud.png";
                    Image4.ImageUrl = "imagenes/dud.png";
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

        if (numero1 == 0)
                {
                    Image8.Visible = true;
                    Lb_tittle_meta_pol.Visible = true;
                    Lb_meta_pol.Visible = true;
                    Lb_tittle_meta_com.Visible = true;
                    Lb_meta_com.Visible = true;
                    Lb_meta_pol.Text = "3";
                    Lb_meta_com.Text = "7,500";

                    Image2.ImageUrl = "imagenes/dud.png";
                    Image3.ImageUrl = "imagenes/dud.png";
                    Image4.ImageUrl = "imagenes/dud.png";
                    Image5.ImageUrl = "imagenes/dud.png";
                    Image6.ImageUrl = "imagenes/dud.png";
                    Image7.ImageUrl = "imagenes/dud.png";
                }

            /*dt = new DataTable();
            dt = query.EjecutaConsultaSQl("SELECT MONTH(MAX(F_PAGO)) AS MES FROM POLIZARIO");
            Lb_mes_inv.Text = dt.Rows[0][0].ToString();
            if (Lb_mes_inv.Text == "9")
            {*/
                dt2 = new DataTable();
        /*dt2 = query.EjecutaConsultaSQl("SELECT age1 as AGENTE1,PORC_PART1,pol AS POLIZA,Convert(char(10),F_EMIS, 103) AS FEC_EMIS,Convert(char(10),f_pago, 103) AS FEC_PAGO,fp AS FORMA_PAGO,pcob_anu AS PRIMA_ANUALIZADA,CAMP1 AS CONTEO_CC,MES_CUENTA,desc_plan AS DESC_PLAN,status_vig AS STATUS,com09 as COM_SEP,com08 AS COM_AGO,com07 AS COM_JUL,com06 AS COM_JUN,com05 AS COM_MAY,com04 AS COM_ABR,com03 AS COM_MAR,com02 AS COM_FEB,com01 AS COM_ENE,com01_a AS COM_ENE_ANTERIOR,com02_a AS COM_FEB_ANTERIOR,com03_a AS COM_MAR_ANTERIOR,com04_a AS COM_ABR_ANTERIOR,com05_a AS COM_MAY_ANTERIOR,com06_a AS COM_JUN_ANTERIOR,com07_a AS COM_JUL_ANTERIOR,com08_a AS COM_AGO_ANTERIOR,com09_a AS COM_SEP_ANTERIOR,com10_a AS COM_OCT_ANTERIOR,com11_a AS COM_NOV_ANTERIOR,com12_a AS COM_DIC_ANTERIOR,personal AS PERSONAL FROM POLIZARIO15 WHERE age1 = " + valor + " or age2 = " + valor + " or age3 = " + valor + " ORDER BY F_PAGO");*/
        //dt2 = query.EjecutaConsultaSQl("SELECT age1 as AGENTE,pol AS POLIZA,Convert(char(10),F_EMIS, 103) AS 'FECHA EMISION',Convert(char(10),f_pago, 103) AS 'FECHA DE PAGO',fp AS 'FORMA DE PAGO',pcob_anu AS 'PRIMA ANUALIZADA',CAMP1 AS 'CONTEO DE CC',MES_CUENTA AS 'MES CUENTA',desc_plan AS 'PLAN',status_vig AS STATUS,SUM(COM01+COM02+COM03+COM04+COM05+COM06+COM07+COM08+COM09+COM10+COM11+COM12+com01_a+com02_a+com03_a+com04_a+com05_a+com06_a+com07_a+com08_a+com09_a+com10_a+com11_a+com12_a) AS COMISIONES,	personal AS PERSONAL FROM CAMPAÑA_DETALLE_TARGET WHERE age1 = " + valor + " AND C1>=-6 GROUP BY AGE1,PORC_PART1,pol,F_EMIS,F_PAGO,fp,pcob_anu,CAMP1,MES_CUENTA,desc_plan,status_vig,personal ORDER BY F_PAGO");
        dt2 = query.EjecutaConsultaSQl("SELECT age1 as AGENTE,pol AS POLIZA,Convert(char(10),F_EMIS, 103) AS FEC_EMIS,Convert(char(10),f_pago, 103) AS FEC_PAGO,fp AS FORMA_PAGO,pcob_anu AS PRIMA_ANUALIZADA,CAMP1 AS CONTEO_CC,MES_CUENTA AS MES_CUENTA,desc_plan AS DESC_PLAN,status_vig AS STATUS,SUM(COM01+COM02+COM03+COM04+COM05+COM06+COM07+COM08+COM09+COM10+COM11+COM12+com01_a+com02_a+com03_a+com04_a+com05_a+com06_a+com07_a+com08_a+com09_a+com10_a+com11_a+com12_a) AS COMISIONES,	personal AS PERSONAL FROM CAMPAÑA_DETALLE_TARGET WHERE age1 = " + valor + " AND C1>=-6 GROUP BY AGE1,PORC_PART1,pol,F_EMIS,F_PAGO,fp,pcob_anu,CAMP1,MES_CUENTA,desc_plan,status_vig,personal ORDER BY F_PAGO");
        GridView1.DataSource = dt2;
                /*GridView1.Rows[0].Cells[10].Text = "Prima Anualizada";*/
                GridView1.DataBind();
                Lb_nota.Visible = true;
            /*}*/
            

        
    }

    protected void img_excel_Click(object sender, ImageClickEventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page page = new Page();
        HtmlForm form = new HtmlForm();

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
        Response.End();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    private decimal _Total = 0;

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        _Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PRIMA_ANUALIZADA"));

        e.Row.Cells[10].Text = string.Format("{0:N0}", Convert.ToDouble(Math.Round(Convert.ToDecimal(_Total), 2)));
        e.Row.Cells[10].Text = string.Format("{0:N0}");
      
    }
}