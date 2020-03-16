<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="principal.aspx.cs" Inherits="principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
     <link href="formulario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="Btn_efec" runat="server" Text="Reporte Efectividad TA" CssClass="button" 
                        Font-Bold="True" Font-Size="Small" 
                        ToolTip="Generar el último reporte de efectividad training" 
                        onclick="Btn_efec_Click" /></td>
            </tr>
        </table>
    </div>

</asp:Content>

