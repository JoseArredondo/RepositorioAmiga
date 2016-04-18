<%@ Control Language="vb" AutoEventWireup="false" Inherits="cuwReApertura" CodeFile="cuwReApertura.ascx.vb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<style type="text/css">
    .style1
    {
        width: 88%;
        height: 107px;
    }
    .style2
    {
        width: 166px;
    }
</style>
<head id="Head1" runat="server" />
<TABLE id="Table8" style="border: thin solid highlight; WIDTH: 440px; HEIGHT: 275px; BACKGROUND-COLOR: #ffffff"
	cellSpacing="0" cellPadding="0" width="440" border="0" DESIGNTIMEDRAGDROP="9">
	<TR>
		<TD style="HEIGHT: 33px" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:label id="Label1" runat="server" Width="278px" Font-Bold="True" Font-Size="Medium" Height="15px"
				Font-Names="Verdana" ForeColor="#16387C">Reaperturar Caja</asp:label></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 19px" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label2" runat="server" Font-Names="Georgia" Text="Fecha:"></asp:Label>
                    </td>
                    <td>
                        <asp:textbox id="Txtdfecha" runat="server" Font-Names="Georgia" Width="116px" 
                            BackColor="White" Enabled="False"></asp:textbox>
                                                                <cc1:CalendarExtender ID="Txtdfecha_CalendarExtender" runat="server" 
                                                                    Format="dd/MM/yyyy" 
                            TargetControlID="Txtdfecha">
                                                                </cc1:CalendarExtender>
                                                            </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label4" runat="server" Font-Names="Georgia" Text="Cajero:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbcajeros" runat="server" Font-Names="Gill Sans MT" 
                            Height="33px" Width="202px">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </TD>
	</TR>
	<TR>
		<TD align="center">
            <asp:Button ID="Button1" runat="server" Font-Names="Georgia" 
                Text="ReAperturar" />
        </TD>
	</TR>
	<TR>
		<TD>
                        <asp:Label ID="Label3" runat="server" Font-Names="Georgia" 
                            Text="Saldo Inicial:" Width="110px" Visible="False"></asp:Label>
                        <asp:TextBox ID="txtnsalini" runat="server" Font-Names="Georgia" 
                Visible="False"></asp:TextBox>
                    </TD>
	</TR>
</TABLE>
