<%@ Reference Control="~/controles/dgKardex.ascx" %>
<%@ Reference Control="~/controles/dgHistorialCreditos.ascx" %>
<%@ Reference Control="~/controles/dgCreditos.ascx" %>
<%@ control language="vb" autoeventwireup="false" inherits="wbestcta, App_Web_v6ddqlgy" %>
<%@ Register TagPrefix="uc1" TagName="dgHistorialCreditos" Src="dgHistorialCreditos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="dgKardex" Src="dgKardex.ascx" %>
<%@ Register TagPrefix="uc1" TagName="dgCreditos" Src="dgCreditos.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD align="center">
			<asp:Label id="Label1" runat="server" Font-Names="Verdana" Font-Bold="True">Estado de Cuenta</asp:Label></TD>
	</TR>
	<TR>
		<TD></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 49px">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 208px" align="right">
						<asp:Label id="Label2" runat="server" Width="54px" Font-Names="Verdana">Cr�dito</asp:Label></TD>
					<TD style="WIDTH: 81px">
						<asp:TextBox id="txtCodCta" runat="server" Width="152px"></asp:TextBox></TD>
					<TD style="WIDTH: 79px"></TD>
					<TD style="WIDTH: 165px">
						<asp:TextBox id="txtCodCli" runat="server" Width="136px"></asp:TextBox></TD>
					<TD><INPUT id="btnBuscar" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-IMAGE: url(imagenes/Buscar.bmp); WIDTH: 96px; COLOR: buttontext; BACKGROUND-REPEAT: no-repeat; FONT-FAMILY: 'Verdana'; HEIGHT: 37px; BACKGROUND-COLOR: transparent"
							tabIndex="8" type="button" name="btnBuscar" runat="server"></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD align="center">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="2">
						<P align="left">
							<iewc:TabStrip id="TabStrip1" runat="server" TabSelectedStyle="background-color:#ffffff;color:#000000"
								TabHoverStyle="background-color:#777777" TabDefaultStyle="background-color:#000000;font-family:verdana;font-weight:bold;font-size:8pt;color:#ffffff;width:79;height:21;text-align:center"
								AutoPostBack="True">
								<iewc:Tab Text="Creditos"></iewc:Tab>
								<iewc:Tab Text="Historial"></iewc:Tab>
								<iewc:Tab Text="Kardex"></iewc:Tab>
							</iewc:TabStrip></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 336px" align="center">
						<P align="left">
							<uc1:dgCreditos id="DgCreditos1" runat="server"></uc1:dgCreditos>
							<uc1:dgHistorialCreditos id="DgHistorialCreditos1" runat="server" Visible="False"></uc1:dgHistorialCreditos>
							<uc1:dgKardex id="DgKardex1" runat="server" Visible="False"></uc1:dgKardex></P>
					</TD>
				</TR>
			</TABLE>
			<P><INPUT id="Button1" style="FONT-WEIGHT: bold; FONT-SIZE: 8pt; BACKGROUND-ATTACHMENT: fixed; BACKGROUND-IMAGE: url(http://localhost/WbCRED/imagenes/Nuevo.gif); WIDTH: 191px; COLOR: buttontext; BACKGROUND-REPEAT: no-repeat; FONT-FAMILY: 'Verdana'; HEIGHT: 40px; BACKGROUND-COLOR: transparent"
					tabIndex="8" type="button" value="Imprimir" name="btnBuscar" runat="server"></P>
			<P>&nbsp;</P>
		</TD>
	</TR>
</TABLE>
