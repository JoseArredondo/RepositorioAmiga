<%@ Control Language="vb" AutoEventWireup="false" Codefile="CUWCamplote.ascx.vb" Inherits="CUWCamplote"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<meta content="False" name="vs_showGrid">
<style type="text/css">
    .style9
    {
        width: 51%;
        height: 406px;
    }
    .style10
    {
        width: 91%;
        height: 284px;
    }
    .style11
    {
        width: 72%;
        height: 30px;
    }
    .style12
    {
        width: 68px;
    }
    .style13
    {
        width: 81px;
    }
    .style14
    {
        width: 157px;
    }
    .style17
    {
        width: 94%;
    }
    .style18
    {
        width: 63px;
        height: 23px;
    }
    .style19
    {
        height: 23px;
    }
    .style20
    {
        width: 100%;
        height: 97px;
    }
    .style21
    {
        width: 156px;
    }
    .style22
    {
        width: 97%;
        height: 79px;
    }
    .style24
    {
        width: 117px;
    }
    .style25
    {
        width: 141px;
    }
    .style31
    {
        height: 27px;
    }
    .style32
    {
        width: 615px;
    }
    .style33
    {
        width: 94%;
        height: 63px;
    }
    .style34
    {
        width: 139px;
    }
    .style35
    {
        width: 127px;
    }
    .style36
    {
        width: 118px;
    }
    .style37
    {
        width: 95px;
    }
    .style40
    {
        width: 118px;
        height: 32px;
    }
    .style41
    {
        width: 117px;
        height: 32px;
    }
    .style42
    {
        width: 141px;
        height: 32px;
    }
    .style43
    {
        height: 32px;
    }
    .style44
    {
        width: 118px;
        height: 40px;
    }
    .style45
    {
        width: 117px;
        height: 40px;
    }
    .style46
    {
        width: 141px;
        height: 40px;
    }
    .style47
    {
        height: 40px;
    }
    .style48
    {
        width: 118px;
        height: 28px;
    }
    .style49
    {
        width: 117px;
        height: 28px;
    }
    .style50
    {
        width: 141px;
        height: 28px;
    }
    .style51
    {
        height: 28px;
    }
</style>

<table cellpadding="0" cellspacing="0" class="style9">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <table bgcolor="White" cellpadding="0" cellspacing="0" class="style9" 
                style="border: thin solid #003366; WIDTH: 585px; HEIGHT: 315px">
                <tr>
                    <td class="style32">
                        <table align="left" bgcolor="White" cellpadding="0" cellspacing="0" 
                            class="style10">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="style11">
                                        <tr>
                                            <td class="style12">
                                                <asp:label id="Label1" runat="server" Width="57px" Font-Names="Verdana" 
                                                    Font-Size="8pt" ForeColor="#16387C" Height="16px">Credito:</asp:label>
                                            </td>
                                            <td class="style13">
                                                <asp:dropdownlist id="cbxCodIns" runat="server" Font-Names="Century Gothic" 
                                                    Font-Size="8pt" Enabled="False"></asp:dropdownlist>
                                            </td>
                                            <td class="style14">
                                                <asp:dropdownlist id="cbxcodofi" runat="server" Width="161px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt" Enabled="False"></asp:dropdownlist>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtcnrocta" runat="server" Font-Names="Century Gothic" Font-Size="8pt" BorderWidth="1px"
								Enabled="False"></asp:textbox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="style17">
                                        <tr>
                                            <td class="style18">
                                                <asp:label id="Label3" runat="server" Width="66px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Analista:</asp:label>
                                            </td>
                                            <td class="style19">
                                                <asp:textbox id="txtNomAna" runat="server" Width="252px" Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox>
                                            </td>
                                            <td class="style19">
                                                <asp:textbox id="txtCredito" runat="server" Width="182px" Font-Size="8pt" BorderWidth="1px" Visible="False"></asp:textbox>
                                            </td>
                                            <td class="style19">
                                                <asp:textbox id="txtcontrato" runat="server" Width="24px" Visible="False"></asp:textbox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:label id="Label7" runat="server" Width="126px" Font-Names="Calibri" Font-Size="12pt"
									ForeColor="#003300" BorderColor="#003300" Font-Bold="True" Height="16px">Datos del Cr�dito</asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="style20">
                                        <tr>
                                            <td align="right" class="style21">
                                                <asp:label id="Label13" runat="server" Width="62px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Grupo:</asp:label>
                                            </td>
                                            <td>
                                                <SELECT id="cbxgrupos" style="FONT-SIZE: 12px; WIDTH: 456px; FONT-FAMILY: 'Century Gothic'"
								name="cbxanacre" runat="server">
								<OPTION selected></OPTION>
							</SELECT></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                <asp:label id="Label8" runat="server" Width="115px" Font-Names="Verdana" 
                                                    Font-Size="8pt" ForeColor="#16387C" Height="16px">L�nea de Cr�dito:</asp:label>
                                            </td>
                                            <td>
                                                <asp:dropdownlist id="cbxLineas" runat="server" Width="456px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
									Height="32px"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
							<asp:label id="Label15" runat="server" Width="132px" Font-Names="Verdana" 
                                Font-Size="8pt" ForeColor="#16387C" Height="19px" Visible="False">Causas de Rechazo:</asp:label>
						                    </td>
                                            <td>
							<SELECT id="cbxrechazo" style="FONT-SIZE: 12px; WIDTH: 456px; FONT-FAMILY: 'Century Gothic'"
								name="cbxanacre0" runat="server" visible="False">
								<OPTION selected></OPTION>
							</SELECT></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                <asp:label id="Label28" runat="server" Width="115px" Font-Names="Verdana" 
                                                    Font-Size="8pt" ForeColor="#16387C" Height="16px">Tipo de Contrato:</asp:label>
						                    </td>
                                            <td>
							                    <asp:dropdownlist id="cbxContrato" runat="server" Width="456px" 
                                                    Font-Names="Verdana" Font-Size="8pt"></asp:dropdownlist></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="style22">
                                        <tr>
                                            <td align="right" class="style36">
                                                <asp:label id="Label4" runat="server" Width="115px" Font-Names="Verdana" 
                                                    Font-Size="8pt" ForeColor="#16387C"
								Height="19px">Monto Solicitado:</asp:label>
                                            </td>
                                            <td class="style24">
                                                <asp:TextBox ID="txtMonSol" runat="server" BorderWidth="1px" Enabled="False" 
                                                    Font-Names="Century Gothic" Font-Size="8pt" Width="94px">0.00</asp:TextBox>
                                            </td>
                                            <td align="right" class="style25">
                                                <asp:label id="Label6" runat="server" Width="128px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C">Fecha Desembolso</asp:label>
                                            </td>
                                            <td>
                                                <asp:textbox id="txtFecDes" runat="server" Width="85px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False"></asp:textbox><asp:rangevalidator id="RangeValidator2" runat="server" Font-Names="Verdana" Font-Size="8pt" ErrorMessage="RangeValidator"
									Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/3000" ControlToValidate="txtFecDes">Fecha 
                                                Inv�lida-</asp:rangevalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style48">
                                                &nbsp;</td>
                                            <td class="style49">
                                                <asp:textbox id="txtmonSug" runat="server" Width="93px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="19px" Visible="False"></asp:textbox>
                                            </td>
                                            <td align="right" class="style50">
                                                <asp:label id="Label12" runat="server" Width="99px" Font-Names="Verdana" Font-Size="8pt" ForeColor="#16387C"
								Height="18px">Fecha 1er.Cuota</asp:label>
                                            </td>
                                            <td class="style51">
                                                <asp:textbox id="txtfecpri" runat="server" Width="85px" 
                                                    Font-Names="Century Gothic" Font-Size="Smaller"
									BorderWidth="1px" Enabled="False"></asp:textbox><asp:rangevalidator id="Rangevalidator6" runat="server" Font-Names="Verdana" Font-Size="8pt" ErrorMessage="RangeValidator"
									Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/3000" ControlToValidate="txtfecpri" DESIGNTIMEDRAGDROP="1491">Fecha 
                                                Inv�lida-</asp:rangevalidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style36">
                                        <asp:label id="Label14" runat="server" Width="48px" Font-Names="Calibri" 
                                            Font-Size="10pt">N�Cuotas:</asp:label>
                                            </td>
                                            <td class="style24">
                                        <asp:textbox id="pnCuoSug" runat="server" Width="80px" 
                                            Font-Names="Century Gothic" Font-Size="Smaller"
								BorderWidth="1px" Height="20px"></asp:textbox>
                                            </td>
                                            <td align="right" class="style25">
                                        <asp:label id="Label20" runat="server" Width="80px" Font-Names="Calibri" 
                                            Font-Size="10pt" ForeColor="#16387C">F.Vencimiento:</asp:label>
                                            </td>
                                            <td>
                                        <asp:textbox id="txtvencimiento" runat="server" Width="85px" 
                                                    Font-Names="Century Gothic" Font-Size="Smaller"
								BorderWidth="1px" Enabled="False" Height="22px"></asp:textbox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style36">
                                                </td>
                                            <td class="style24">
                                        <asp:label id="Label27" runat="server" Width="96px" Font-Names="Calibri" 
                                            Font-Size="10pt" Font-Bold="True">TIPO DE CUOTA</asp:label>
                                            </td>
                                            <td align="right" class="style25">
                                                </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style40">
                                                <asp:textbox id="txtnMonApr" runat="server" Width="36px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="16px" Visible="False"></asp:textbox>
                                                <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Font-Names="Calibri" 
                                                    Font-Size="12pt" Width="36px" Height="16px" Visible="False"></asp:TextBox>
                                            </td>
                                            <td class="style41">
                                        <asp:radiobutton id="RadioButton1" runat="server" Width="104px" 
                                            Font-Names="Calibri" Font-Size="10pt"
								BorderWidth="0px" BackColor="White" GroupName="TipoPago" Text="FIJA NIVELADA" 
                                            Checked="True"></asp:radiobutton>
                                            </td>
                                            <td align="right" class="style42">
                                                &nbsp;</td>
                                            <td class="style43">
                                        <asp:label id="Label26" runat="server" Width="96px" Font-Names="Calibri" 
                                            Font-Size="10pt" Font-Bold="True">FORMA DE PAGO</asp:label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style44">
                                                </td>
                                            <td class="style45" align="left">
                                        <asp:radiobutton id="RadioButton5" runat="server" Width="48px" 
                                            Font-Names="Calibri" Font-Size="10pt"
								BorderWidth="0px" BackColor="White" GroupName="TipoPago" Text="FLAT" Height="18px"></asp:radiobutton>
                                            </td>
                                            <td align="right" class="style46">
                                        <asp:label id="Label24" runat="server" Width="96px" Font-Names="Calibri" 
                                            Font-Size="10pt">Capital:</asp:label>
                                            </td>
                                            <td class="style47">
                                        <asp:dropdownlist id="cbxCapital" runat="server" Width="150px" 
                                            Font-Names="Calibri" Font-Size="10pt" AutoPostBack="True" Height="16px"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style36">
                                                &nbsp;</td>
                                            <td class="style24" align="left">
                                                &nbsp;</td>
                                            <td align="right" class="style25">
                                        <asp:label id="Label25" runat="server" Width="79px" Font-Names="Calibri" 
                                            Font-Size="10pt" Height="16px">Interes:</asp:label>
                                            </td>
                                            <td>
                                        <asp:dropdownlist id="cbxInteres" runat="server" Width="150px" 
                                            Font-Names="Calibri" Font-Size="10pt" Height="16px"></asp:dropdownlist>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="style36">
                                                <asp:label id="Label18" runat="server" Width="103px" Font-Names="Verdana" 
                                                    Font-Size="8pt" ForeColor="#16387C" Height="16px" Visible="False">Tipo de Cuota:</asp:label>
                                            </td>
                                            <td class="style24" align="left">
                                                <asp:textbox id="txttipocuota" runat="server" Width="93px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="19px" Visible="False"></asp:textbox>
                                            </td>
                                            <td align="right" class="style25">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="style31">
			<asp:datagrid id="Datagrid1" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="3"
								BorderWidth="1px" BorderStyle="None" BorderColor="#006699" BackColor="White" 
                Height="16px" Width="618px"
								runat="server">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="#FFFF66" />
								<ItemStyle ForeColor="#000066"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#006699"></HeaderStyle>
								<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="ccodcta" HeaderText="Codigo Pr�stamo" 
                                        SortExpression="ccodcta">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Names="Calibri" 
                                            Font-Overline="False" Font-Size="X-Small" Font-Strikeout="False" 
                                            Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Calibri" 
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                            HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundColumn>
									<asp:BoundColumn DataField="cnomcli" SortExpression="cnomcli" 
                                        HeaderText="Nombre ">
										<HeaderStyle Font-Size="X-Small" Font-Names="Calibri" Font-Bold="True" HorizontalAlign="Center"
											VerticalAlign="Middle" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                                            Font-Underline="False"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" Font-Names="Calibri" HorizontalAlign="Center" 
                                            VerticalAlign="Top" Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                            Font-Strikeout="False" Font-Underline="False"></ItemStyle>
									</asp:BoundColumn>
                                    <asp:BoundColumn DataField="cnudoci" HeaderText="Identificacion" 
                                        SortExpression="cnudoci">
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Calibri" 
                                            Font-Overline="False" Font-Size="X-Small" Font-Strikeout="False" 
                                            Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Bold="True" Font-Italic="False" Font-Names="Calibri" 
                                            Font-Overline="False" Font-Size="X-Small" Font-Strikeout="False" 
                                            Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundColumn>
								    <asp:BoundColumn DataField="nmonsol" HeaderText="Monto Otorgado" 
                                        SortExpression="nmonsol" DataFormatString="{0:Q###,##0.00}">
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Names="Calibri" 
                                            Font-Overline="False" Font-Size="X-Small" Font-Strikeout="False" 
                                            Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Calibri" 
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                            HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
                                </td>
                            </tr>
                            <tr>
                                <td class="style31">
                                    <asp:label id="Label11" runat="server" Width="295px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Red"
									Height="21px" Font-Bold="True"></asp:label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table align="center" cellpadding="0" cellspacing="0" class="style33">
                                        <tr>
                                            <td class="style35">
                                                <INPUT id="btnAplicar" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_aplicar_b.jpg); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button5" runat="server"></td>
                                            <td class="style36">
                                                <INPUT id="btnGrabar" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_guardar2_b.gif); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button4" runat="server"></td>
                                            <td class="style37">
                                                <INPUT id="btnPlan" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_plan_b.jpg); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button8" runat="server"></td>
                                            <td class="style34">
                                                <INPUT id="Button2" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_iniciar_b.jpg); WIDTH: 59px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 55px; BACKGROUND-COLOR: transparent"
								type="button" name="Button7" runat="server"></td>
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
                                                <asp:textbox id="txtcCodCli" runat="server" Width="31px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="16px" Visible="False"></asp:textbox>
                                                <asp:textbox id="txtcNomcli" runat="server" Width="33px" 
                                        Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="16px" Visible="False"></asp:textbox>
                                                <asp:textbox id="txtgarantias" runat="server" Width="29px" 
                                                    Font-Names="Century Gothic" Font-Size="8pt"
								BorderWidth="1px" Enabled="False" Height="16px" Visible="False"></asp:textbox>
                            <asp:TextBox ID="txtbandera" runat="server" Visible="False" Width="25px" Height="16px"></asp:TextBox>
                            <asp:TextBox ID="txtccodsol" runat="server" Visible="False" Width="61px"></asp:TextBox>
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

