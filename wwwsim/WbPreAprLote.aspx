<%@ Page Title="Aprobaci�n Grupal" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="WbPreAprLote.aspx.vb" Inherits="WbPreAprLote" %>
<%@ Register assembly="Microsoft.Web.UI.WebControls" namespace="Microsoft.Web.UI.WebControls" tagprefix="iewc" %>
<%@ Register src="controles/WUCFindGru.ascx" tagname="WUCFindGru" tagprefix="uc2" %>
<%@ Register src="controles/WFindCreGB.ascx" tagname="WFindCreGB" tagprefix="uc3" %>
<%@ Register src="controles/CuwPlanGB.ascx" tagname="CuwPlanGB" tagprefix="uc5" %>
<%@ Register src="controles/CuwComg.ascx" tagname="CuwComg" tagprefix="uc6" %>


<%@ Register src="controles/CUWPreAprLote.ascx" tagname="CUWPreAprLote" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" style="width: 100%">
        <tr>
            <td>
				<iewc:tabstrip id="TabStrip1" AutoPostBack="True" TabDefaultStyle="background-color:#000000;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center;"
				TabHoverStyle="background-color:#777777;" TabSelectedStyle="background-color:#ffffff;color:#000000;"
				runat="server" Font-Names="Century Gothic" Font-Size="Larger">
				<iewc:Tab Text="Busqueda de Clientes"></iewc:Tab>
				<iewc:Tab Text="Aprobaci�n de Credito"></iewc:Tab>
				<iewc:Tab Text="Plan de Pagos"></iewc:Tab>
				<iewc:Tab Text="Comisiones" />
				</iewc:tabstrip></TD>               
                
        </tr>        
        <tr>
            <td>
				<uc3:WFindCreGB ID="WFindCreGB2" runat="server" />				
				<uc1:CUWPreAprLote ID="CUWPreAprLote3" runat="server" />
				<uc5:CuwPlanGB ID="CuwPlanGB2" runat="server" />
				<uc6:CuwComg ID="CuwComg2" runat="server" />
            </td>
        </tr>        
    </table>
</asp:Content>

