using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Conexiones
/// </summary>
public class Conexiones
{
    public String cadena(int valor)
    {
        String str = "";

        if (valor == 1)
        {
            str = @"Data Source=LINEASPERSONALES, 1808; Initial Catalog=campañas;Integrated Security=SSPI; Persist Security Info = False;"; ;
        }

        if (valor == 2)
        {
            str = @"Data Source=LINEASPERSONALES, 1808;Initial Catalog=campañas;Integrated Security=SSPI; Persist Security Info = False;"; ;
        }

        return str;
    }
}