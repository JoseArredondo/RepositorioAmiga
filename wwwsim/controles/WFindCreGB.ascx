<%@ Control Language="vb" AutoEventWireup="false" Codefile="WFindCreGB.ascx.vb" Inherits="WFindCreGB"  %>

 <script type="text/javascript">

	    function SoloLetras_Numeros(evt) {
	        var charCode = (evt.which) ? evt.which : event.keyCode
	        if (charCode == 08 || charCode == 32 || charCode == 45 || charCode == 241 || charCode == 209)
	            return true;
	        else if (charCode >= 48 && charCode <= 57)
	            return true;	            
	        else if (charCode >= 65 && charCode <= 90)
	            return true;
	        else if (charCode >= 97 && charCode <= 122)
	            return true;
	        return false;
	    }

	    
    </script>
    
<TABLE id="Table2" style="BORDER-RIGHT: highlight thin solid; BORDER-TOP: highlight thin solid; BORDER-LEFT: highlight thin solid; WIDTH: 576px; BORDER-BOTTOM: highlight thin solid; HEIGHT: 377px"
	cellSpacing="0" cellPadding="0" width="576" border="0" bgcolor="White">
	<TR>
		<TD style="HEIGHT: 11px">
			<P style="BACKGROUND-COLOR: white" align="center">
				<asp:label id="Label9" Font-Bold="True" ForeColor="#16387C" Height="27px" Font-Size="12pt"
					Font-Names="Calibri" Width="490px" runat="server">BUSQUEDA DE CREDITOS POR 
                GRUPOS SOLIDARIO / BANCO COMUNAL</asp:label></P>
		</TD>
	</TR>
	<TR>
		<TD align="center">
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="472" border="0" style="WIDTH: 472px; HEIGHT: 147px">
				<TR>
					<TD style="WIDTH: 301px" align="right">
						<asp:radiobuttonlist id="rdbbusqueda" ForeColor="#16387C" Height="173px" 
                            Font-Size="8pt" Font-Names="Century Gothic"
							Width="170px" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" BackColor="AliceBlue"
							BorderWidth="2px" BorderColor="Navy">
							<asp:ListItem Value="Por Nombre" Selected="True">Por Nombre                         </asp:ListItem>
							<asp:ListItem Value="Por C&#243;digo">Por C&#243;digo                       </asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD style="WIDTH: 178px">
						<asp:radiobuttonlist id="rdbbusqueda2" ForeColor="#16387C" Height="172px" 
                            Font-Size="8pt" Font-Names="Century Gothic"
							Width="206px" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" BackColor="LightSteelBlue"
							BorderWidth="2px" BorderColor="Navy">
							<asp:ListItem Value="Proceso de Solicitud">Proceso de Solicitud</asp:ListItem>
							<asp:ListItem Value="Proceso de Sugerencia">Proceso de Sugerencia</asp:ListItem>
							<asp:ListItem Value="Proceso de Autorizaci�n">Proceso de Autorizaci�n</asp:ListItem>
							<asp:ListItem Value="Vigentes" Selected="True">Vigentes</asp:ListItem>
							<asp:ListItem Value="Todos">Todos</asp:ListItem>
						    <asp:ListItem>Cancelados</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD style="WIDTH: 301px">
						<asp:radiobuttonlist id="rdbbusqueda3" runat="server" Width="131px" 
                            Font-Names="Century Gothic" Font-Size="9pt"
							Height="174px" ForeColor="#16387C" BorderColor="Navy" BorderWidth="2px" BackColor="LightSkyBlue"
							RepeatDirection="Horizontal" RepeatColumns="1">
							<asp:ListItem Value="Grupo" Selected="True">Grupo</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
			</TABLE>
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" border="0" 
                style="WIDTH: 547px; HEIGHT: 58px">
				<TR>
					<TD style="WIDTH: 222px" align="right">
						<asp:label id="Label1" Font-Bold="True" ForeColor="#16387C" Height="13px" Font-Size="10pt"
							Font-Names="Verdana" Width="144px" runat="server">Nombre :</asp:label></TD>
					<TD style="WIDTH: 238px">
						<P align="left">
							<asp:textbox id="TxtNombre" tabIndex="1" Width="350px" runat="server" ToolTip="Digite el Nombre del Cliente"
								BorderWidth="1px" Font-Names="Verdana" BorderColor="#2E6A99" Height="28px" 
							onkeypress="return SoloLetras_Numeros(event)" CssClass="ToUpper"></asp:textbox></P>
					</TD>
					<TD style="WIDTH: 80px">
						<P align="right"><INPUT id="Button1" style="BACKGROUND-IMAGE: url(Web/jpgs/btn_buscar2_b.gif);WIDTH: 56px;BACKGROUND-REPEAT: no-repeat;HEIGHT: 48px;BACKGROUND-COLOR: transparent"
								type="button" name="Button1" runat="server"></P>
					</TD>
				</TR>
			</TABLE>
			<DIV style="BACKGROUND-COLOR: #ffffff" align="center">
                <asp:GridView ID="Grid_Cuenta" runat="server" 
                    AutoGenerateColumns="False" CssClass="CSSTableGenerator" Font-Names="Verdana" 
                    Font-Size="10pt" Height="148px" Width="579px">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True">
                            <ControlStyle Font-Names="Gill Sans MT" />
                            <ItemStyle Font-Names="Gill Sans MT" />
                        </asp:CommandField>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo">
                            <ControlStyle Font-Names="Calibri" Font-Size="10pt" />
                            <HeaderStyle Font-Names="Gill Sans MT" Font-Size="10pt" />
                            <ItemStyle Font-Names="Gill Sans MT" Font-Size="10pt" 
                                HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cnomcli" HeaderText="Nombre">
                            <ControlStyle Font-Names="Calibri" Font-Size="10pt" />
                            <HeaderStyle Font-Names="Gill Sans MT" Font-Size="10pt" />
                            <ItemStyle Font-Names="Gill Sans MT" Font-Size="10pt" 
                                HorizontalAlign="Center" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="ncapdes" HeaderText="Monto" 
                            DataFormatString="{0:###,##0.00}">
                            <ControlStyle Font-Names="Calibri" Font-Size="10pt" />
                            <HeaderStyle Font-Names="Gill Sans MT" Font-Size="10pt" />
                            <ItemStyle Font-Names="Gill Sans MT" Font-Size="10pt" 
                                HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dfecvig" HeaderText="Fecha" 
                            DataFormatString="{0:dd-MM-yyyy}">
                            <ControlStyle Font-Names="Calibri" Font-Size="10pt" />
                            <HeaderStyle Font-Names="Gill Sans MT" Font-Size="10pt" />
                            <ItemStyle Font-Names="Gill Sans MT" Font-Size="10pt" 
                                HorizontalAlign="Center" />
                        </asp:BoundField>                        
                        <asp:BoundField DataField="cestado" HeaderText="Estado">
                            <ControlStyle Font-Names="Calibri" Font-Size="10pt" />
                            <HeaderStyle Font-Names="Gill Sans MT" Font-Size="10pt" />
                            <ItemStyle Font-Names="Gill Sans MT" Font-Size="10pt" 
                                HorizontalAlign="Center" />
                        </asp:BoundField>
                               
                    </Columns>
                    <FooterStyle Font-Names="Gill Sans MT" />
                    <PagerStyle Font-Names="Gill Sans MT" />
                    <HeaderStyle BackColor="#99CC00" ForeColor="#003366" />
                    <AlternatingRowStyle BackColor="#CCFF66" />
                </asp:GridView>
			</DIV>
		</TD>
	</TR>
</TABLE>
