<%@ Register TagPrefix="uc1" TagName="WbCreditosClientes" Src="WbCreditosClientes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="WbFind" Src="WbFind.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="WbCreditos.ascx.vb" Inherits="wwwSIM.WbCreditos" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD>
			<uc1:WbFind id="WbFind1" runat="server"></uc1:WbFind></TD>
	</TR>
	<TR>
		<TD>
			<uc1:WbCreditosClientes id="WbCreditosClientes1" runat="server"></uc1:WbCreditosClientes></TD>
	</TR>
</TABLE>
