using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for consulta
/// </summary>
public class consulta
{
    String str = @"Data Source=LINEASPERSONALES, 1808;Initial Catalog=campañas;Integrated Security=SSPI; Persist Security Info = False;";

    public System.Data.DataTable EjecutaConsultaSQl(string query)
    {
        string sql;
        SqlCommand comando;
        SqlConnection coexion = new SqlConnection(str);
        SqlDataAdapter adaptador;
        System.Data.DataTable dt = new System.Data.DataTable();
        coexion.Open();

        using (coexion)
        {
            sql = query;
            comando = new SqlCommand(sql, coexion);
            comando.CommandTimeout = 500000;
            adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(dt);

            //resultado = Convert.ToDouble(dt.Rows[0][0].ToString);   
        }

        coexion.Close();
        return dt;
    }
}