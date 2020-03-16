using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Logeo
/// </summary>
public class Logeo
{
    Conexiones cd = new Conexiones();

    public string[] Autentificacion(string user, string pass)
    {
        string sql;
        SqlCommand comando;
        SqlConnection conexion = new SqlConnection(cd.cadena(1));
        SqlDataAdapter adaptador;
        System.Data.DataTable dt = new System.Data.DataTable();

        conexion.Open();

        using (conexion)
        {
            sql = "Select id_registro,username,pwd from Tbl_Acceso_Usuarios where username ='" + user + "' and pwd = '" + pass + "' and mandrake='*'";
            comando = new SqlCommand(sql, conexion);
            comando.CommandTimeout = 500000;
            adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(dt);
        }

        conexion.Close();

        String[] valores;
        valores = new String[3];

        if (dt.Rows.Count == 0)
        {
            valores[1] = "";
            valores[2] = "";
        }
        else
        {
            valores[1] = dt.Rows[0][1].ToString();
            valores[2] = dt.Rows[0][2].ToString();
        }

        return valores;
    }
}