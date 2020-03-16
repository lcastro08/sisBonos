<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="asesor.aspx.cs" Inherits="asesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript" language="javascript">
        //esta funcion solo deja ingresar numeros enteros
        function entero(e) {
            var caracter
            caracter = e.keyCode
            status = caracter

            if (caracter > 47 && caracter < 58) {
                return true
            }
            return false
        }
        </script>

    <style type="text/css">
        .style1
        {
            height: 171px;
        }
        .style2
        {
            width: 88px;
        }
        .style3
        {
            width: 85px;
        }
    </style>

    <link href="formulario.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div >
    <table>
       <tr>
       <td style="width: 15px"></td>
        <td><th>
           <asp:Label ID="Label2" runat="server" Text="No. Asesor: " CssClass="etiqueta" 
               Font-Size="Small"></asp:Label></th></td>
               <td></td>
        <td><asp:TextBox ID="txt_asesor" runat="server" onkeypress = "return entero(event)" 
                MaxLength="5" ToolTip="Indica el número de asesor" Height="25px" 
                Width="65px" Font-Size="Small"></asp:TextBox> </td>
                <td></td>
        <td><asp:Button ID="btn_asesor" runat="server" Text="Buscar" 
                onclick="btn_asesor_Click" CssClass="button" Font-Bold="True" 
                Font-Size="Small" Height="35px" /> </td>
                <td style="width: 150px"></td>
        
        <td>
            <asp:Label ID="Label3" runat="server" Text="Información al: " Font-Bold="True" 
                ForeColor="#1F618D" Font-Italic="True" Font-Size="Small"></asp:Label> </td>

        <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#2C3E50" 
                Font-Size="Small"></asp:Label><asp:Label ID="Lb_mes_inv" runat="server" Text="" Visible="false"></asp:Label></td>
                <td style="width: 150px"></td>
                <td><asp:ImageButton ID="img_excel" runat="server" 
                ImageUrl="~/imagenes/Excel_15.png" onclick="img_excel_Click" Width="29px" 
                ToolTip="Exportar tabla a Excel" /></td>
                <td style="width: 150px"><asp:Label ID="Label15" runat="server" Text="Exportar a Excel" Font-Size="Small"></asp:Label></td>
      </tr>
    </table>
    <table id="datos_ases" runat="server" visible="false" >
        <tr>
            <td><asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/Asesor.png" Height="75px" Width="90px"/></td>
             <td class="style3">
                <asp:Label ID="Label13" runat="server" Text="Pre contrato:  "  Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#336699"></asp:Label>
                    <asp:CheckBox ID="CheckBox1" runat="server" Height="20px" Width="20px" 
                    Font-Size="X-Small" Enabled="false" Font-Bold="True" ForeColor="Black" />
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td>
                <asp:Label ID="Lb_uno_nombre" runat="server" Text="Nombre: " Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#336699"></asp:Label>
                <asp:Label ID="Lb_nombre_ases" runat="server" Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td>
                <asp:Label ID="Lb_uno_grupo" runat="server" Text="Grupo: " Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#336699"></asp:Label>
                <asp:Label ID="Lb_grupo_ases" runat="server" Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Dir. Comer: " Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#336699"></asp:Label>
                <asp:Label ID="Lb_dircomer" runat="server" Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="Black"></asp:Label>
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td>
                <asp:Label ID="Lb_uno_concurso" runat="server" Text="Concurso: " Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#009999"></asp:Label>
                <asp:Label ID="Lb_concurso" runat="server" Text="Label" Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#0066CC"></asp:Label>
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td class="style2">
                <asp:Label ID="Lb_uno_mes" runat="server" Text="Mes: " Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="#336699"></asp:Label>
                <asp:Label ID="Lb_mes" runat="server" Font-Bold="True" 
                    Font-Size="X-Small" ForeColor="Black"></asp:Label>      
            </td>
        </tr>
        </table>
        <div>
        <table id="datos_ases_dos" runat="server" visible="false" style="float:left;">
        <tr>
            <td>
                
            </td>
            <td>
                <asp:Image ID="Image9" runat="server" Height="40px" Width="60px" 
                    ImageUrl="~/imagenes/docum.png" ToolTip="Producción actual"/>
            </td>
            <td>
                <asp:Label ID="Lb_titulo_polizas" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#336699" Text="Pólizas:"></asp:Label>
                <asp:Label ID="Lb_tot_polizas" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="Black"></asp:Label>
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td>
                <asp:Label ID="Lb_titulo_comision" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#336699" Text="Comisiones:"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="$" Font-Bold="True" 
                    Font-Size="Small" ForeColor="Black"></asp:Label>
                <asp:Label ID="Lb_comision" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="Black"></asp:Label>
            </td>
            <td>&nbsp&nbsp&nbsp</td> 
            <td>&nbsp&nbsp&nbsp</td>
            <td>&nbsp&nbsp&nbsp</td>
            <td>&nbsp&nbsp&nbsp</td>  
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Image ID="Image8" runat="server" Height="40px" Width="60px" 
                    ImageUrl="~/imagenes/meta.png" ToolTip="Metas"/></td>
            <td>
                <asp:Label ID="Lb_tittle_meta_pol" runat="server" Text="Pólizas:" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#003300"></asp:Label>
                    <asp:Label ID="Lb_meta_pol" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#339966"></asp:Label>
            </td>
            <td>
                &nbsp
                &nbsp
            </td>
            <td>
                <asp:Label ID="Lb_tittle_meta_com" runat="server" Text="Comisiones:" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#003300"></asp:Label>
                <asp:Label ID="Lb_meta_com" runat="server" Text="" Font-Bold="True" 
                    Font-Size="Small" ForeColor="#339966"></asp:Label>
            </td>
        </tr>
    </table>
    <table id="historia_meses" runat="server" style="float:left;" visible="false">
        <tr>
            <td colspan="6" align="center">
                <asp:Label ID="Label5" runat="server" Text="Historia de meses ganados" 
                    Font-Bold="True" Font-Size="Medium" ForeColor="#0099CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label6" runat="server" Text="1" CssClass="labelmes11" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label7" runat="server" Text="2" CssClass="labelmes11" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label9" runat="server" Text="3" CssClass="labelmes11" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
            <td align="center"> 
                <asp:Label ID="Label10" runat="server" Text="4" CssClass="labelmes11" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label11" runat="server" Text="5" CssClass="labelmes11" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label12" runat="server" Text="6" CssClass="labelmes11" 
                    Font-Bold="True" Font-Size="Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center"><asp:Image ID="Image2" runat="server" Height="20px" Width="20px" /></td>
            <td><asp:Image ID="Image3" runat="server" Height="20px" Width="20px"/></td>
            <td><asp:Image ID="Image4" runat="server" Height="20px" Width="20px"/></td>
            <td><asp:Image ID="Image5" runat="server" Height="20px" Width="20px"/></td>
            <td><asp:Image ID="Image6" runat="server" Height="20px" Width="20px"/></td>
            <td><asp:Image ID="Image7" runat="server" Height="20px" Width="20px"/></td>
        </tr>
    </table>
    </div>
    <br />
    <div style="width:120%; height:350; overflow:auto;">
        <asp:Label ID="Lb_nota" runat="server" 
            Text="*Los datos mostrados en este sistema son de caracter informativo. La información oficial se encuentra en la hoja meta." 
            Font-Bold="True" Font-Size="X-Small" ForeColor="#804040" Visible="False"></asp:Label>
            <br />
        <asp:Label ID="Label14" runat="server" Text="**Las pólizas personales de familiares, se marcan hasta la firma del contrato**"
        Font-Bold="True" Font-Size="X-Small" ForeColor="#CC6600" Visible="False"></asp:Label>
    <table style="margin: 0 auto;" cellspacing = "15">
    <tr>
    <td class="style1">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" Font-Size="Small" ForeColor="#0099FF" GridLines="Vertical" 
            HorizontalAlign="Center" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="960px">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="agente" HeaderText="Agente" 
                    SortExpression="agente" />
                <asp:BoundField DataField="poliza" HeaderText="Póliza" 
                    SortExpression="poliza" />
                <asp:BoundField DataField="fec_emis" HeaderText="Emisión" 
                    SortExpression="fec_emis" />
                <asp:BoundField DataField="fec_pago" HeaderText="Pago" 
                    SortExpression="fec_pago" />
                <asp:BoundField DataField="forma_pago" HeaderText="Forma Pago" 
                    SortExpression="forma_pago" />
                <asp:BoundField DataField="prima_anualizada" HeaderText="Prima anual" 
                    SortExpression="prima_anualizada" />
                <asp:BoundField DataField="conteo_cc" HeaderText="Conteo" 
                    SortExpression="conteo_cc" />
                <asp:BoundField DataField="mes_cuenta" HeaderText="Mes" 
                    SortExpression="mes_cuenta" />
                <asp:BoundField DataField="desc_plan" HeaderText="Descripción del plan" 
                    SortExpression="desc_plan" />
                <asp:BoundField DataField="status" HeaderText="Estatus" 
                    SortExpression="estatus" />
                <asp:BoundField DataField="comisiones" HeaderText="Comisiones" 
                    SortExpression="comisiones" />
                <asp:BoundField DataField="personal" HeaderText="Personal" 
                    SortExpression="personal" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#148F77" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="#003366" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    </td>
   </tr>
    </table>
    </div>
    </div>
</asp:Content>

