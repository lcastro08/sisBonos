using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;

public partial class principal : System.Web.UI.Page
{
    consulta query = new consulta();
    DataTable dt; 

    protected void Page_Load(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = query.EjecutaConsultaSQl("SELECT A.DESC_VTA,A.DESC_OFNA,A.EDA,A.DESC_GEREN,A.PROM_MAT,A.PROM_SUC,A.RAZ_SOCIAL,A.NUM_AGENTE,A.NOMBRE_DEL,A.FECHA_DE_C,A.CONCURSO,A.GRUPO,A.MES_ACTUAL,B.POL_VIDA,B.[PólizasAMFLEX],B.PÓLIZAS,B.COMISIONES,B.CUMPLE_POL_VIDA,B.META_PÓLIZAS,B.META_COMISIONES,B.CUMPLETA,B.BONO_EXCEDENTE,B.FALTA_PÓLIZAS,B.FALTA_COMISIONES,B.PORCENTAJE_A_GANAR,B.POLIZAS_ACUMULADAS,B.POLIZAS_PROMEDIO,B.POR_BONOADIC,B.PROACTIVO,B.POL_FALTANTES,A.ENE,A.FEB,A.MAR,ABR='',MAY='',JUN='',JUL='',AGO='',SEP='',OCT='',NOV='',DIC='' FROM  DETALLE_EFECTIVIDAD_REPORTE_UNO A LEFT OUTER JOIN ASESORES_TA_LP B ON A.NUM_AGENTE=B.ASESOR WHERE A.DESC_VTA NOT LIKE '%Z%'");
    }
    protected void Btn_efec_Click(object sender, EventArgs e)
    {

     
    }
}