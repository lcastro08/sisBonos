<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="Btn_efectividad" runat="server" Text="Efectividad Training" 
                        onclick="Btn_efectividad_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lb_titulo_fec" runat="server" Text="Fecha del reporte:"></asp:Label>
                    <asp:Label ID="Lb_fecha" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>

