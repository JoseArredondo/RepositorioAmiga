<%@ Control Language="vb" AutoEventWireup="false" Codefile="CUWAprInd.ascx.vb" Inherits="CUWAprInd"  %>
<meta content="False" name="vs_showGrid">
<style type="text/css">
    .style1
    {
        width: 53%;
        height: 294px;
    }
    .style2
    {
        width: 91%;
    }
    .style11
    {
        width: 95%;
        height: 26px;
    }
    .style12
    {
        width: 66px;
    }
    .style13
    {
        width: 87px;
    }
    .style14
    {
        width: 86%;
        height: 25px;
    }
    .style16
    {
        width: 184px;
    }
    .style17
    {
        width: 59px;
    }
    .style18
    {
        height: 37px;
    }
    .style19
    {
        height: 29px;
    }
    .style20
    {
        width: 80%;
    }
    .style21
    {
        width: 217px;
    }
    .style22
    {
        width: 70px;
    }
    .style23
    {
        height: 28px;
    }
    .style25
    {
        width: 89%;
        height: 76px;
    }
    .style26
    {
        width: 305px;
    }
    .style27
    {
        height: 38px;
    }
    .style28
    {
        width: 95%;
        height: 106px;
    }
    .style29
    {
        width: 124px;
    }
    .style31
    {
        width: 152px;
    }
    .style32
    {
        width: 152px;
        height: 33px;
    }
    .style34
    {
        width: 124px;
        height: 33px;
    }
    .style35
    {
        height: 33px;
    }
    .style36
    {
        width: 152px;
        height: 28px;
    }
    .style38
    {
        width: 124px;
        height: 28px;
    }
    .style39
    {
        height: 36px;
    }
    .style40
    {
        width: 95%;
        height: 79px;
    }
    .style41
    {
        width: 130px;
    }
    .style42
    {
        width: 125px;
    }
    .style43
    {
        width: 305px;
        height: 36px;
    }
    .style44
    {
        width: 101px;
        height: 33px;
    }
    .style45
    {
        width: 101px;
    }
    .style46
    {
        width: 101px;
        height: 28px;
    }
</style>
<table bgcolor="White" border="1" cellpadding="0" cellspacing="0" 
    class="style1" style="border-color: #003366">
    <tr>
        <td>
            <table align="center" cellpadding="0" cellspacing="0" class="style2">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" class="style11">
                            <tr>
                                <td align="right" class="style12">
                                    <asp:label id="Label1" runat="server" Width="57px" Font-Names="Verdana" 
                                        Font-Size="8pt" ForeColor="#16387C" Height="16px">Credito:</asp:label>
                                </td>
                                <td class="style13">
                                    <asp:dropdownlist id="cbxCodIns" runat="server" Font-Names="Century Gothic" Font-Size="8pt"></asp:dropdownlist>
                                </td>
                                <td>
                                    <asp:dropdownlist id="cbxcodofi" runat="server" Width="187px" 
                                        Font-Names="Century Gothic" Font-Size="8pt" Height="16px" Enabled="False"></asp:dropdownlist>
                                    <asp:textbox id="txtcnrocta" runat="server" Font-Names="Century Gothic" 
                                        Font-Size="8pt" BorderWidth="1px"
								Enabled="False" Height="22px" Width="107px"></asp:textbox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style18">
                        <table cellpadding="0" cellspacing="0" class="style14">
                            <tr>
                                <td align="right" class="style17">
                                    <asp:label id="Label2" runat="server" Width="55px" Font-Names="Verdana" 
                                        Font-Size="8pt" ForeColor="#16387C" Height="16px">Cliente:</asp:label>
                                </td>
                                <td class="style16">
                                    <asp:textbox id="txtcCodCli" runat="server" Width="224px" 
                                        Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="24px"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtcNomcli" runat="server" Width="224px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="24px"></asp:textbox><asp:textbox id="txtcontrato" runat="server" Width="24px" Visible="False"></asp:textbox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style19">
                        <table cellpadding="0" cellspacing="0" class="style20">
                            <tr>
                                <td align="right" class="style22">
                                    <asp:label id="Label3" runat="server" Width="66px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Analista:</asp:label>
                                </td>
                                <td class="style21">
                                    <asp:textbox id="txtNomAna" runat="server" Width="252px" 
                                        Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="22px"></asp:textbox>
                                </td>
                                <td>
                                    <asp:textbox id="txtCredito" runat="server" Width="188px" Font-Size="8pt" 
                                        BorderWidth="1px" Visible="False" Height="22px"></asp:textbox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label16" runat="server" Width="126px" Font-Names="Calibri" Font-Size="10pt"
									ForeColor="#003300" BorderColor="#003300" Font-Bold="True" Height="16px">Datos del Cr�dito</asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="style23">
                        <table cellpadding="0" cellspacing="0" class="style25">
                            <tr>
                                <td align="right" class="style26">
                                    <asp:label id="Label13" runat="server" Width="62px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Grupo:</asp:label>
                                </td>
                                <td>
                                    <SELECT id="cbxgrupos" style="FONT-SIZE: 12px; WIDTH: 456px; FONT-FAMILY: 'Century Gothic'"
								name="cbxanacre" runat="server">
								<OPTION selected></OPTION>
							</SELECT></td>
                            </tr>
                            <tr>
                                <td align="right" class="style43">
                                    <asp:label id="Label8" runat="server" Width="115px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">L�nea de Cr�dito:</asp:label>
                                </td>
                                <td class="style39">
                                    <asp:dropdownlist id="cbxLineas" runat="server" Width="456px" 
                                    Font-Names="Century Gothic" Font-Size="8pt"
									Height="32px" Enabled="False"></asp:dropdownlist>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style43">
                                    <asp:label id="Label17" runat="server" Width="115px" Font-Names="Verdana" 
                                        Font-Size="8pt" ForeColor="#16387C">Fuente de Fondos:</asp:label>
                                </td>
                                <td class="style39">
                                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Font-Names="Calibri" 
                                        Font-Size="12pt" Height="21px" Width="211px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style26">
							<asp:label id="Label15" runat="server" Width="140px" Font-Names="Verdana" 
                                Font-Size="8pt" ForeColor="#16387C">Causas de Rechazo:</asp:label>
						        </td>
                                <td>
							<SELECT id="cbxrechazo" style="FONT-SIZE: 12px; WIDTH: 456px; FONT-FAMILY: 'Century Gothic'"
								name="cbxanacre0" runat="server">
								<OPTION selected></OPTION>
							</SELECT></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="style27">
                        <table cellpadding="0" cellspacing="0" class="style28">
                            <tr>
                                <td align="right" class="style32">
                                    <asp:label id="Label4" runat="server" Width="107px" Font-Names="Verdana" 
                                        Font-Size="8pt" ForeColor="#16387C"
								Height="19px">Monto Solicitado:</asp:label>
                                </td>
                                <td class="style44">
                                    <asp:textbox id="txtMonSol" runat="server" Width="94px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox>
                                </td>
                                <td align="right" class="style34">
                                    <asp:label id="Label5" runat="server" Width="123px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Monto 
                                    Aprobado:</asp:label>
                                </td>
                                <td class="style35">
                                    <asp:textbox id="txtnMonApr" 
                                runat="server" Width="92px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" Font-Names="Verdana" Font-Size="8pt" ErrorMessage="RangeValidator"
									Type="Double" MinimumValue="25" MaximumValue="1000000000" ControlToValidate="txtnMonApr">Monto 
                                    Inv�lido-</asp:rangevalidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style31">
                                    <asp:label id="Label10" runat="server" Width="132px" Font-Names="Verdana" 
                                        Font-Size="8pt" ForeColor="#16387C" Height="19px">Monto Sugerido:</asp:label>
                                </td>
                                <td class="style45">
                                    <asp:textbox id="txtmonSug" runat="server" Width="90px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox>
                                </td>
                                <td align="right" class="style29">
                                    <asp:label id="Label6" runat="server" Width="128px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Fecha 
                                    Desembolso:</asp:label>
                                </td>
                                <td>
                                    <asp:textbox id="txtFecDes" 
                                runat="server" Width="94px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" Font-Names="Verdana" Font-Size="8pt" ErrorMessage="RangeValidator"
									Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/3000" ControlToValidate="txtFecDes">Fecha 
                                    Inv�lida-</asp:rangevalidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style36">
                                    <asp:label id="Label14" runat="server" Width="48px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Cuotas:</asp:label>
                                </td>
                                <td class="style46">
                                    <asp:textbox id="pnCuoSug" runat="server" Width="65px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox>
                                </td>
                                <td align="right" class="style38">
                                    <asp:label id="Label12" runat="server" Width="99px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C"
								Height="18px">Fecha 1er.Cuota:</asp:label>
                                </td>
                                <td class="style23">
                                    <asp:textbox id="txtfecpri" runat="server" Width="90px" 
                                    Font-Names="Century Gothic" Font-Size="Smaller"
									BorderWidth="1px" Enabled="False"></asp:textbox><asp:rangevalidator id="Rangevalidator6" runat="server" Font-Names="Verdana" Font-Size="8pt" ErrorMessage="RangeValidator"
									Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/3000" ControlToValidate="txtfecpri" DESIGNTIMEDRAGDROP="1491">Fecha 
                                    Inv�lida-</asp:rangevalidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style31">
							<asp:label id="Label9" runat="server" Width="87px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Garant�as:</asp:label>
                                </td>
                                <td class="style45">
                                    <asp:textbox id="txtgarantias" runat="server" Width="81px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox>
                                </td>
                                <td class="style29">
                            <asp:TextBox ID="txtbandera" runat="server" Visible="False" Width="61px"></asp:TextBox>
                                </td>
                                <td>
                            <asp:TextBox ID="txtccodsol" runat="server" Visible="False" Width="61px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:label id="Label11" runat="server" Width="295px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
									Height="21px" Font-Bold="True"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="style39">
                        <table align="center" cellpadding="0" cellspacing="0" class="style40">
                            <tr>
                                <td class="style42">
                                    <INPUT id="btnGrabar" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_guardar2_b.gif); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button8" runat="server"></td>
                                <td class="style42">
                                    <INPUT id="btnPlan" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_plan_b.jpg); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button7" runat="server"></td>
                                <td class="style41">
                                    <INPUT id="Button2" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_iniciar_b.jpg); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button6" runat="server"></td>
                                <td>
                                    <INPUT id="Button1" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_rechazar_b.jpg); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button5" runat="server"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
				<asp:textbox id="txtdFecVen" runat="server" Width="48px" Visible="False"></asp:textbox><asp:textbox id="txtcTipCuo" runat="server" Width="64px" Visible="False"></asp:textbox><asp:textbox id="txtcTipPer" runat="server" Width="64px" Visible="False"></asp:textbox><asp:textbox id="txtnperdia" runat="server" Width="56px" Visible="False"></asp:textbox><asp:textbox id="txtndiaGra" runat="server" Width="44px" Visible="False"></asp:textbox>
				<asp:textbox id="txtcflat" runat="server" Width="44px" Visible="False"></asp:textbox>
				<asp:textbox id="txtcfreccap" runat="server" Width="44px" Visible="False"></asp:textbox>
				<asp:textbox id="txtcfrecint" runat="server" Width="44px" Visible="False"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>

