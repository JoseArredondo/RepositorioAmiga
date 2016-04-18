<%@ control language="vb" autoeventwireup="false" inherits="WbUCLientesCon, App_Web_mb_xwoah" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<style type="text/css">
    .style4
    {
        width: 100%;
        height: 86px;
        margin-right: 0px;
    }
    .style5
    {
        width: 122px;
    }
    .style6
    {
        height: 22px;
        width: 222px;
    }
    .style7
    {
        height: 24px;
        width: 222px;
    }
    .style8
    {
        height: 23px;
        width: 222px;
    }
    .style9
    {
        height: 2px;
        width: 222px;
    }
    .style10
    {
        height: 16px;
        width: 222px;
    }
    .style11
    {
        height: 22px;
        width: 11px;
    }
    .style12
    {
        height: 24px;
        width: 11px;
    }
    .style13
    {
        height: 23px;
        width: 11px;
    }
    .style14
    {
        height: 2px;
        width: 11px;
    }
    .style15
    {
        height: 16px;
        width: 11px;
    }
    .style19
    {
        width: 114px;
        height: 4px;
    }
    .style22
    {
        height: 4px;
    }
    .style23
    {
        height: 4px;
        width: 222px;
    }
    .style24
    {
        height: 4px;
        width: 11px;
    }
    .style25
    {
        width: 172px;
    }
    .style27
    {
        width: 100%;
    }
    .style28
    {
        width: 122px;
        height: 29px;
    }
    .style29
    {
        width: 172px;
        height: 29px;
    }
    .style31
    {
        height: 29px;
    }
    .style33
    {
        width: 114px;
        height: 32px;
    }
    .style34
    {
        height: 32px;
        width: 222px;
    }
    .style35
    {
        height: 32px;
        width: 11px;
    }
    .style36
    {
        height: 32px;
    }
    .style37
    {
        width: 133px;
    }
    .style38
    {
        width: 133px;
        height: 29px;
    }
    .style39
    {
        height: 140px;
    }
    .style1
    {
        height: 21px;
        width: 81px;
    }
    .style2
    {
        height: 26px;
        width: 81px;
    }
    #Table3
    {
        width: 84%;
        height: 346px;
    }
    .style43
    {
        width: 27px;
        height: 16px;
    }
    .style44
    {
        height: 16px;
    }
    .style45
    {
        height: 16px;
        width: 81px;
    }
    .style46
    {
        width: 27px;
        height: 4px;
    }
    .style47
    {
        height: 4px;
        width: 81px;
    }
    .style48
    {
        width: 27px;
        height: 7px;
    }
    .style49
    {
        height: 7px;
    }
    .style50
    {
        height: 7px;
        width: 81px;
    }
    .style51
    {
        width: 27px;
        height: 8px;
    }
    .style52
    {
        height: 8px;
    }
    .style53
    {
        height: 8px;
        width: 81px;
    }
    .style54
    {
        width: 27px;
        height: 66px;
    }
    .style55
    {
        height: 66px;
    }
    .style56
    {
        height: 66px;
        width: 81px;
    }
    .style57
    {
        width: 27px;
        height: 18px;
    }
    .style58
    {
        height: 18px;
    }
    .style59
    {
        height: 18px;
        width: 81px;
    }
    .style60
    {
        width: 27px;
        height: 6px;
    }
    .style61
    {
        height: 6px;
    }
    .style62
    {
        height: 6px;
        width: 81px;
    }
    .style63
    {
        width: 27px;
        height: 17px;
    }
    .style64
    {
        height: 17px;
    }
    .style65
    {
        height: 17px;
        width: 81px;
    }
    </style>
<head id="Head1" />

    <script src="js/jquery.js" type="text/javascript"></script>    
    <script type="text/javascript" src="js/lib.js"></script>
    <script type="text/javascript">
        function HabilitaCampos() {
            //2 y 6 se habilitan los campos si son diferentes de deshabilitan

            var EstadoCivil = document.getElementById("<%=cmbEstCli.ClientID %>").options[document.getElementById("<%=cmbEstCli.ClientID %>").selectedIndex].value
            if (EstadoCivil == 2 || EstadoCivil == 6) {
                document.getElementById("<%=TxtNomC.ClientID %>").disabled = true;
                document.getElementById("<%=TxtIdCony.ClientID %>").disabled = true;
                document.getElementById("<%=cmbProfCony.ClientID %>").disabled = true;
                document.getElementById("<%=TxtNacCony.ClientID %>").disabled = true;
                document.getElementById("<%=cmbGenCony.ClientID %>").disabled = true;
                document.getElementById("<%=Sleer.ClientID %>").disabled = true;
                document.getElementById("<%=cmbParent.ClientID %>").disabled = true;
                //alert("lo habilite")
            }
            else {
                document.getElementById("<%=TxtNomC.ClientID %>").disabled = true;
                document.getElementById("<%=TxtIdCony.ClientID %>").disabled = true;
                document.getElementById("<%=cmbProfCony.ClientID %>").disabled = true;
                document.getElementById("<%=TxtNacCony.ClientID %>").disabled = true;
                document.getElementById("<%=cmbGenCony.ClientID %>").disabled = true;
                document.getElementById("<%=Sleer.ClientID %>").disabled = true;
                document.getElementById("<%=cmbParent.ClientID %>").disabled = false;
            }

        }

        function CargaMuni0() {
            $.ajax({
                type: "POST",
                url: "ajax/Municipios0.ashx",
                data: "Departamento0=" + document.getElementById("<%=DropDownDeptos0.ClientID %>").options[document.getElementById("<%=DropDownDeptos0.ClientID %>").selectedIndex].value,
                success: function(html) {
                $("#<%=DropDownMuni0.ClientID %>").html(html);
                CargaComu0();
                 }
            });
        }

                    
        function CargaMuni() {    
    	$.ajax({
  			type: "POST",
  			url: "ajax/Municipios.ashx",
  			data: "Departamento=" + document.getElementById("<%=DropDownDeptos.ClientID %>").options[document.getElementById("<%=DropDownDeptos.ClientID %>").selectedIndex].value,
  			success: function(html){
  			$("#<%=DropDownMuni.ClientID %>").html(html);
  			 CargaComu();
  			}
  		});  		
		}
		function CargaComu() {    
    	$.ajax({
  			type: "POST",
  			url: "ajax/Comunidades.ashx",
  			data: "Municipio=" + document.getElementById("<%=DropDownMuni.ClientID %>").options[document.getElementById("<%=DropDownMuni.ClientID %>").selectedIndex].value,
  			success: function(html){
  			$("#<%=DropDownComu.ClientID %>").html(html);  			  
  			}
  		});  		
		}

		function CargaComu0() {
		    $.ajax({
		        type: "POST",
		        url: "ajax/Comunidades0.ashx",
		        data: "Municipio0=" + document.getElementById("<%=DropDownMuni0.ClientID %>").options[document.getElementById("<%=DropDownMuni0.ClientID %>").selectedIndex].value,
		        success: function(html) {
		            $("#<%=DropDownComu0.ClientID %>").html(html);
		        }
		    });
		}	

       function Getfecha(){
           document.getElementById('<%=TxtEdad.ClientID %>').value = calcular_edad(document.getElementById('<%=TxtDfecnaci.ClientID %>').value);	         
	    }

       function Getfecha1(){
           document.getElementById('<%=TxtEdadCony.ClientID %>').value = calcular_edad(document.getElementById('<%=TxtNacCony.ClientID %>').value);	         
	    }
	    
    </script>

<P style="FONT-SIZE: 11pt; FONT-FAMILY: 'Gill Sans MT'">
	<TABLE id="Table1" style="border: thin solid highlight; WIDTH: 720px; HEIGHT: 933px; BACKGROUND-COLOR: #FFFFFF"
		cellSpacing="0" cellPadding="0" border="0">
		<TR>
			<TD>
				<P style="FONT-WEIGHT: bold; FONT-SIZE: 14pt; COLOR: #006699; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'"
					align="center">CONSULTA DE CLIENTE<asp:Image ID="ImageFoto" runat="server" Height="58px" Visible="False" 
                        Width="83px" />
                </P>
			</TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 16px; BACKGROUND-COLOR: silver">
				<P style="FONT-WEIGHT: normal; FONT-SIZE: 11pt; COLOR: White; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; BACKGROUND-COLOR: #006699"
					align="center">Identificaci�n</P>
			</TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 132px" align="center">
				<TABLE id="Table2" style="WIDTH: 652px; HEIGHT: 112px" cellSpacing="0" 
                    cellPadding="0" border="0">
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 22px">Cliente</TD>
						<TD class="style6"><asp:textbox id="TxtCodigo" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"></asp:textbox></TD>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style11">Oficina</TD>
						<TD style="HEIGHT: 22px"><asp:dropdownlist id="cmbOficina" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"
								Width="184px" tabIndex="1"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">Tipo 
							de Cliente</TD>
						<TD class="style7"><asp:dropdownlist id="cmbTipcli" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="208px" tabIndex="2"></asp:dropdownlist></TD>
						<TD style="FONT-SIZE: 10pt; " class="style12"></TD>
						<TD style="HEIGHT: 24px">
                                    &nbsp;</TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style19">
                            <asp:Label ID="Label8" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Primer Nombre:" Width="124px"></asp:Label>
                        </TD>
						<TD class="style23"><asp:textbox id="TxtNomcli" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="200px" tabIndex="3"></asp:textbox></TD>
						<TD style="FONT-SIZE: 10pt; " class="style24">
							<asp:Label ID="Label10" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Primer Apellido:" Width="124px"></asp:Label>
						</TD>
						<TD style="font-family: Gill Sans MT; font-size: 12px;" class="style22">
                            
                            <asp:textbox id="Txtpriape" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="200px" tabIndex="6"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style19">
                            <asp:Label ID="Label7" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Segundo Nombre:" Width="124px"></asp:Label>
                        </TD>
						<TD class="style23">
                            <asp:textbox id="Txtsegnom" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="200px" tabIndex="4"></asp:textbox></TD>
						<TD style="FONT-SIZE: 10pt; " class="style24">
							<asp:Label ID="Label11" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Segundo Apellido:" Width="124px"></asp:Label>
						</TD>
						<TD style="font-family: Gill Sans MT; font-size: 12px;" class="style22">
                            
                            <asp:textbox id="Txtsegape" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="200px" tabIndex="7"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style19">
                            <asp:Label ID="Label9" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Tercer Nombre:" Width="124px"></asp:Label>
                        </TD>
						<TD class="style23">
                            <asp:textbox id="Txtternom" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="200px" tabIndex="5"></asp:textbox></TD>
						<TD style="FONT-SIZE: 10pt; " class="style24">
							<asp:Label ID="Label12" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Apellido de Casada:" Width="124px"></asp:Label>
						</TD>
						<TD style="font-family: Gill Sans MT; font-size: 12px;" class="style22">
                            
                            <asp:textbox id="Txtapecasada" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="200px" tabIndex="8"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style19">
							<asp:Label ID="Label26" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Tipo de Doc.:" Width="124px"></asp:Label>
						</TD>
						<TD class="style23">
                            <asp:dropdownlist id="cmbTipDoc" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="208px" tabIndex="9" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD style="FONT-SIZE: 10pt; " class="style24">
							<asp:Label ID="Label25" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Fec.Nacimiento:" Width="124px"></asp:Label>
						</TD>
						<TD style="font-family: Gill Sans MT; font-size: 12px;" class="style22">
                            
                            <table cellpadding="0" cellspacing="0" class="style27">
                                <tr>
                                    <td>
                            
                            <asp:TextBox ID="TxtDfecnaci" runat="server" onChange = "Getfecha()" BackColor="White" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" Width="116px" tabIndex="11"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="Mask_EditExt1" runat="server" 
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="TxtDfecnaci">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="TxtDfecnaci_CalendarExtender" runat="server" 
                                Format="dd/MM/yyyy" PopupButtonID="Image_btn1" TargetControlID="TxtDfecnaci" 
                                            PopupPosition="Right">
                            </cc1:CalendarExtender>
                                    </td>
                                    <td>
                            <asp:ImageButton ID="Image_btn1" runat="server" 
                                ImageUrl="~/web/gifs/Calendar_scheduleHS.png" />
                                    </td>
                                    <td>
                                    <asp:TextBox ID="TxtEdad" runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                        Font-Size="10pt" Width="64px"></asp:TextBox>
                            
                                    </td>
                                </tr>
                            </table>
                            
                        </TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style19">N� de Doc.:</TD>
						<TD class="style23">
                            <table cellpadding="0" cellspacing="0" class="style27">
                                <tr>
                                    <td>
                                        <asp:textbox id="Txtorden" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="39px" MaxLength="14" tabIndex="5" Height="21px" Visible="False"></asp:textbox>
                                    </td>
                                    <td>
                                        <asp:textbox id="TxtIdCivil" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"
								Width="161px" MaxLength="16" tabIndex="10" Height="19px"></asp:textbox>
                                    </td>
                                </tr>
                            </table>
                        </TD>
						<TD style="FONT-SIZE: 10pt; " class="style24">
                            <asp:textbox id="txtiva" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"
								Width="62px" MaxLength="8" tabIndex="14" Height="16px" Visible="False"></asp:textbox></TD>
						<TD style="font-family: Gill Sans MT; font-size: 12px; color: #999999;" 
                            class="style22">Formato (dd/mm/yyyy)<cc1:MaskedEditValidator ID="Mask_Edit1" runat="server" 
                                ControlExtender="Mask_EditExt1" ControlToValidate="TxtDfecnaci" 
                                Display="Dynamic" EmptyValueMessage="La fecha es requerida" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" InvalidValueMessage="Fecha Invalida" 
                                IsValidEmpty="False" TooltipMessage="Por favor Digite una Fecha"></cc1:MaskedEditValidator></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; " 
                            class="style33">
                            &nbsp;</TD>
						<TD class="style34">
                            <asp:Label ID="Label6" runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                ForeColor="#666666"></asp:Label>
                        </TD>
						<TD style="FONT-SIZE: 10pt; " class="style35">
							<P style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'"
								align="left">NIT</P>
						</TD>
						<TD class="style36"><asp:textbox id="TxtIdTribu" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"
								Width="168px" MaxLength="18" tabIndex="12"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 23px">
                            Departamento Extendido Doc:</TD>
						<TD class="style8">
                            <asp:DropDownList ID="DropDownDeptos0" runat="server"  onchange="CargaMuni0();" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" Height="16px" Width="207px"  tabIndex="13"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </TD>
						<TD style="FONT-SIZE: 10pt; font-weight: normal; width: 114px; color: #16387c; font-style: normal; font-family: Gill Sans MT; height: 23px;" 
                            class="style13">
							Municipio Extendido Doc:</TD>
						<TD style="HEIGHT: 23px">
                            <asp:DropDownList ID="DropDownMuni0" runat="server"  Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Width="202px" tabIndex="14">
                            </asp:DropDownList>
                        </TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 2px">
                            Sexo:</TD>
						<TD class="style9"><asp:dropdownlist id="cmbGenCli" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"
								Width="208px" tabIndex="15"></asp:dropdownlist></TD>
						<TD style="FONT-SIZE: 10pt; " class="style14">
							<P style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'"
								align="left">Profesi�n</P>
						</TD>
						<TD style="HEIGHT: 2px"><asp:dropdownlist id="cmbProfCli" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"
								Width="184px" tabIndex="18"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 16px">Estado 
							Civil</TD>
						<TD class="style10">
                            <asp:dropdownlist id="cmbEstCli" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Enabled="False" runat="server"  
								Width="208px" tabIndex="16" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD style="FONT-SIZE: 10pt; " class="style15">
                            <asp:Label ID="Label5" runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                ForeColor="#000066" Text="N� Dependientes:" Width="107px"></asp:Label>
                        </TD>
						<TD style="HEIGHT: 16px">
                            <asp:textbox id="txtdepen" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False" runat="server"
								Width="89px" MaxLength="8" tabIndex="19" Height="28px" style="vertical-align:top"></asp:textbox>
                            <cc1:NumericUpDownExtender ID="txtdepen_NumericUpDownExtender" runat="server" 
                                Enabled="True" Maximum="100" Minimum="0" RefValues="" ServiceDownMethod="" 
                                ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                                TargetButtonUpID="" TargetControlID="txtdepen" Width="60">
                            </cc1:NumericUpDownExtender>
                        </TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 16px">
                            <asp:Label ID="Label18" runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                ForeColor="#000066" Text="N� Hijos:" Width="107px"></asp:Label>
                        </TD>
						<TD class="style10">
                            <asp:textbox id="txthijos" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="89px" MaxLength="8" tabIndex="17" Height="28px" style="vertical-align:top"></asp:textbox>
                            <cc1:NumericUpDownExtender ID="txthijos_NumericUpDownExtender" runat="server" 
                                Enabled="True" Maximum="100" Minimum="0" RefValues="" ServiceDownMethod="" 
                                ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                                TargetButtonUpID="" TargetControlID="txthijos" Width="60">
                            </cc1:NumericUpDownExtender>
                        </TD>
						<TD style="FONT-SIZE: 10pt; " class="style15">&nbsp;</TD>
						<TD style="HEIGHT: 16px">
                            &nbsp;</TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 114px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 16px">
                            &nbsp;</TD>
						<TD class="style10">
            
            <asp:FileUpload ID="fileUpEx" runat="server" Width="248px" Font-Names="Gill Sans MT" 
                                Visible="False" />
                        </TD>
						<TD style="FONT-SIZE: 10pt; " class="style15">
            <asp:Button ID="btnSubir" runat="server" Height="21px" Text="Subir Foto" 
                Width="98px" Font-Names="Gill Sans MT" Visible="False" />
                        </TD>
						<TD style="HEIGHT: 16px">
            <asp:Label ID="lblStatus" runat="server" CssClass="style4" Height="16px" Visible="False"></asp:Label>
                        </TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD style="FONT-SIZE: 11pt">
				<P style="FONT-WEIGHT: normal; FONT-SIZE: 11pt; COLOR: White; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; BACKGROUND-COLOR: #006699"
					align="center">Domicilio</P>
			</TD>
		</TR>
		<TR>
			<TD style="FONT-SIZE: 11pt" class="style39">
                            <table id="Table3" border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td 
                                style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 99px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 21px">Departamento</td>
						<td style="WIDTH: 225px; HEIGHT: 21px">
                            <asp:DropDownList runat="server" AutoPostBack="True" Font-Names="Gill Sans MT" Font-Size="10pt" Height="16px" TabIndex="20" Width="202px" ID="DropDownDeptos" onchange="CargaMuni();"></asp:DropDownList>

                        </td>
						<td class="style1" 
                                style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; ">Municipio</td>
						<td style="HEIGHT: 21px">
                            <asp:DropDownList runat="server" AutoPostBack="True" Font-Names="Gill Sans MT" Font-Size="10pt" TabIndex="21" Width="202px" ID="DropDownMuni" onchange="CargaComu();"></asp:DropDownList>

                        </td>
					</tr>
					<tr>
						<td 
                                style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 99px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 26px">
                            Comunidad/Colonia/Cant�n:</td>
						<td style="WIDTH: 225px; HEIGHT: 26px">
                            <asp:DropDownList runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" TabIndex="22" Width="202px" ID="DropDownComu"></asp:DropDownList>

                        </td>
						<td class="style2" 
                                style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Localidad Demografica:" Font-Names="Gill Sans MT" Font-Size="10pt" Height="17px" Width="149px" ID="Label22"></asp:Label>

                        </td>
						<td style="HEIGHT: 26px">
                            <asp:DropDownList runat="server" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" Height="18px" TabIndex="23" Width="203px" ID="cmblocalidad"></asp:DropDownList>

                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style43">
                            <asp:Label runat="server" Text="Tel&#232;fono:" Font-Names="Gill Sans MT" Font-Size="10pt" Height="17px" Width="96px" ID="Label21"></asp:Label>

                        </td>
						<td class="style44"><asp:TextBox runat="server" MaxLength="8" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" TabIndex="24" Width="120px" ID="TxtTelDom"></asp:TextBox>
</td>
						<td class="style45" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Celular:" Font-Names="Gill Sans MT" Font-Size="10pt" Height="17px" Width="96px" ID="Label20"></asp:Label>

                        </td>
						<td class="style44"><asp:TextBox runat="server" MaxLength="8" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" TabIndex="27" Width="120px" ID="txtcelular"></asp:TextBox>
</td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style46">
                            <asp:Label runat="server" Text="Otro telefono:" Font-Names="Gill Sans MT" Font-Size="10pt" Width="124px" ID="Label16"></asp:Label>

                        </td>
						<td class="style22">
                            <asp:TextBox runat="server" MaxLength="8" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" TabIndex="25" Width="120px" ID="txtotrtel"></asp:TextBox>
</td>
						<td class="style47" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Direcci&#242;n:" Font-Names="Gill Sans MT" Font-Size="10pt" Height="17px" Width="96px" ID="Label19"></asp:Label>

                        </td>
						<td class="style22">
                            <asp:TextBox runat="server" TextMode="MultiLine" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" Height="37px" TabIndex="28" Width="208px" ID="TxtDirDom"></asp:TextBox>
</td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style48">
                            <asp:Label runat="server" Text="Condici&#243;n de la Vivienda:" Font-Names="Gill Sans MT" Font-Size="10pt" ForeColor="#000066" Width="152px" ID="Label2"></asp:Label>

                        </td>
						<td class="style49">
                            <asp:DropDownList runat="server" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" TabIndex="26" Width="208px" ID="cmbCondicion"></asp:DropDownList>

                        </td>
						<td class="style50" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Otro:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label27" Height="16px"></asp:Label>

                        </td>
						<td class="style49">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="23px" TabIndex="28" Width="208px" 
                                ID="txtotracondicion"></asp:TextBox>
                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style51">
                            <asp:Label runat="server" Text="Paredes:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label28" Height="16px"></asp:Label>

                        </td>
						<td class="style52">
                            <asp:ListBox runat="server" SelectionMode="Multiple" Font-Names="Gill Sans MT" Height="60px" Width="148px" ID="cmbparedes">
                                <asp:ListItem Value="1">Adobe</asp:ListItem>
                                <asp:ListItem Value="2">Block</asp:ListItem>
                                <asp:ListItem Value="3">Ladrillo</asp:ListItem>
                                <asp:ListItem Value="4">Madera</asp:ListItem>
                                <asp:ListItem Value="5">Otro</asp:ListItem>
                            </asp:ListBox>

                        </td>
						<td class="style53" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Piso:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label30" Height="16px"></asp:Label>

                        </td>
						<td class="style52">
                            <asp:ListBox runat="server" SelectionMode="Multiple" Font-Names="Gill Sans MT" Height="60px" Width="148px" ID="cmbpiso">
                                <asp:ListItem Value="1">Tierra</asp:ListItem>
                                <asp:ListItem Value="2">Cemento</asp:ListItem>
                                <asp:ListItem Value="3">Granito</asp:ListItem>
                                <asp:ListItem Value="4">Ceramico</asp:ListItem>
                                <asp:ListItem Value="5">Otro</asp:ListItem>
                            </asp:ListBox>
                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style43">
                            <asp:Label runat="server" Text="Otro:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label29" Height="16px"></asp:Label>

                        </td>
						<td class="style44">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="23px" TabIndex="28" Width="208px" 
                                ID="txtotracondicion0"></asp:TextBox>

                        </td>
						<td class="style45" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Otro:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label31" Height="16px"></asp:Label>

                        </td>
						<td class="style44">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="23px" TabIndex="28" Width="208px" 
                                ID="txtotracondicion1"></asp:TextBox>
                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style54">
                            <asp:Label runat="server" Text="Techo:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label32" Height="16px"></asp:Label>

                        </td>
						<td class="style55">
                            <asp:ListBox runat="server" SelectionMode="Multiple" Font-Names="Gill Sans MT" Height="60px" Width="148px" ID="cmbtecho">
                                <asp:ListItem Value="1">Lamina</asp:ListItem>
                                <asp:ListItem Value="2">Terraza</asp:ListItem>
                                <asp:ListItem Value="3">Otro</asp:ListItem>
                            </asp:ListBox>

                        </td>
						<td class="style56" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Servicios:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label34" Height="16px"></asp:Label>

                        </td>
						<td class="style55">
                            <asp:ListBox runat="server" SelectionMode="Multiple" Font-Names="Gill Sans MT" Width="148px" ID="cmbservicios">
                                <asp:ListItem Value="1">Agua</asp:ListItem>
                                <asp:ListItem Value="2">Energia Electrica</asp:ListItem>
                                <asp:ListItem Value="3">Drenaje</asp:ListItem>
                                <asp:ListItem Value="4">Fosa Septica</asp:ListItem>
                                <asp:ListItem Value="5">Otros</asp:ListItem>
                            </asp:ListBox>
                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style57">
                            <asp:Label runat="server" Text="Otro:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label33" Height="16px"></asp:Label>

                        </td>
						<td class="style58">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="23px" TabIndex="28" Width="208px" 
                                ID="txtotracondicion2"></asp:TextBox>

                        </td>
						<td class="style59" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Otro:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label35" Height="16px"></asp:Label>

                        </td>
						<td class="style58">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="23px" TabIndex="28" Width="208px" 
                                ID="txtotracondicion3"></asp:TextBox>
                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style60">
                            <asp:Label runat="server" Text="Due�o:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="90px" ID="Label36" Height="16px"></asp:Label>

                        </td>
						<td class="style61">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="23px" TabIndex="28" Width="208px" ID="txtdue�o"></asp:TextBox>

                        </td>
						<td class="style62" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none">
                            <asp:Label runat="server" Text="Valor Aproximado:" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" ForeColor="#000066" Width="126px" ID="Label37" Height="16px"></asp:Label>

                        </td>
						<td class="style61">
                            <asp:TextBox runat="server" Enabled="False" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" TabIndex="25" Width="120px" ID="txtvalor"></asp:TextBox>
                        </td>
					</tr>
					<tr>
						<td 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none" 
                            class="style63">
                            <asp:Label runat="server" Text="A�o desde que Reside:" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" ForeColor="#000066" Width="134px" 
                                ID="Label38" Height="16px"></asp:Label>

                        </td>
						<td class="style64">
                            <asp:textbox id="txtrecidir" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="89px" tabIndex="19" Height="28px" style="vertical-align:top"></asp:textbox>
                            <cc1:NumericUpDownExtender ID="txtrecidir_NumericUpDownExtender" runat="server" 
                                Enabled="True" Maximum="2030" Minimum="0" RefValues="" ServiceDownMethod="" 
                                ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" 
                                TargetButtonUpID="" TargetControlID="txtrecidir" Width="60">
                            </cc1:NumericUpDownExtender>

                        </td>
						<td class="style65" 
                                
                            style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; TEXT-DECORATION: none"></td>
						<td class="style64"></td>
					</tr>
					</table>
			</TD>
		</TR>
		<TR align="center" 
            style="font-family: Gill Sans MT; font-size: 12px; color: #FFFFFF;">
			<TD style="FONT-SIZE: 14pt; HEIGHT: 20px; BACKGROUND-COLOR: #3366FF" 
                bgcolor="#000099">
				Otros			<TD style="FONT-SIZE: 11pt; HEIGHT: 20px; ">
				&nbsp;</TD>
		</TR>
		<TR align="center" 
            style="font-family: Gill Sans MT; font-size: 12px; color: #FFFFFF;">
			<TD style="FONT-SIZE: 14pt; HEIGHT: 20px; BACKGROUND-COLOR: #3366FF" 
                bgcolor="#000099">
				<table cellpadding="0" cellspacing="0" class="style4" align="center" 
                    bgcolor="White">
                    <tr>
                        <td align="right" class="style5">
                            <asp:Label ID="Label1" runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                ForeColor="#000066" Text="Etnia:"></asp:Label>
                        </td>
                        <td align="center" class="style25">
                            <asp:dropdownlist id="cmbEtnia" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="29"></asp:dropdownlist>
                        </td>
                        <td align="right" class="style37">
                            <asp:Label ID="Label23" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Grupo Etnico:" Width="124px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="cmbgruetnico" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="35"></asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style5">
                            <asp:Label ID="Label24" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Idiomas que domina:" Width="124px"></asp:Label>
                        </td>
                        <td align="left" class="style25">
                            <asp:ListBox runat="server" SelectionMode="Multiple" Font-Names="Gill Sans MT" 
                                Width="148px" ID="cmbidiomas">
                            </asp:ListBox>
                        </td>
                        <td align="right" class="style37">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="style28">
                            <asp:Label ID="Label3" runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                ForeColor="#000066" Text="Escolaridad:"></asp:Label>
                        </td>
                        <td align="center" class="style29">
                            <asp:dropdownlist id="cmbNivel" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="31"></asp:dropdownlist>
                        </td>
                        <td align="right" class="style38">
                            <asp:Label ID="Label17" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Grado:" Width="124px"></asp:Label>
                        </td>
                        <td align="left" class="style31">
                            <asp:textbox id="txtgrado" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="200px" tabIndex="36"></asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style5">
                            <asp:Label ID="Label13" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Sabe leer:" Width="124px"></asp:Label>
                        </td>
                        <td align="center" class="style25">
                            <asp:dropdownlist id="cmbleer" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="32"></asp:dropdownlist>
                        </td>
                        <td align="right" class="style37">
                            <asp:Label ID="Label15" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Height="17px" Text="Sabe firmar:" Width="96px"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="cmbfirmar" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="37"></asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="style28">
                            <asp:Label ID="Label4" runat="server" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                ForeColor="#000066" Text="Datos Adicionales:"></asp:Label>
                        </td>
                        <td align="center" class="style29">
                            <asp:textbox id="Txtadicionales" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" Height="37px" TextMode="MultiLine" tabIndex="34"></asp:textbox>
                        </td>
                        <td align="center" class="style38">
                            <asp:Label ID="Label14" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Sabe escribir:" Width="124px"></asp:Label>
                        </td>
                        <td align="left" class="style31">
                            <asp:dropdownlist id="cmbescribir" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="33"></asp:dropdownlist>
                        </td>
                    </tr>
                    </table>
			<TD style="FONT-SIZE: 11pt; HEIGHT: 20px; ">
				&nbsp;</TD>
		</TR>
		<TR>
			<TD style="FONT-SIZE: 11pt; HEIGHT: 20px; BACKGROUND-COLOR: maroon">
				<P style="FONT-WEIGHT: normal; FONT-SIZE: 11pt; COLOR: White; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; BACKGROUND-COLOR: #006699"
					align="center">Datos del Conyuge/Familiar</P>
			</TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 69px">
				<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 100px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">
                            <asp:Label ID="Label39" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Codigo Conyuge/Familiar:" Width="124px"></asp:Label>
                        </TD>
						<TD style="WIDTH: 230px; HEIGHT: 24px">
                                        <asp:TextBox runat="server" MaxLength="12" BorderWidth="1px" Enabled="False" Font-Names="Gill Sans MT" Font-Size="10pt" ID="TxtId"></asp:TextBox>

                                    </TD>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 79px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">
                            <asp:Label ID="Label40" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Text="Relacion con Cliente:" Width="76px" Height="16px"></asp:Label>
                        </TD>
						<TD style="HEIGHT: 24px">
                            <asp:dropdownlist id="cmbParent" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                Enabled="False" runat="server"
								Width="208px" tabIndex="33"></asp:dropdownlist>
                        </TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 100px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">Nombre</TD>
						<TD style="WIDTH: 230px; HEIGHT: 24px">
                            <asp:textbox id="TxtNomC" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" runat="server"
								Width="200px" tabIndex="38"></asp:textbox></TD>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 79px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">Nacimiento</TD>
						<TD style="HEIGHT: 24px">
                            <asp:textbox id="TxtNacCony" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" runat="server" onChange = "Getfecha1()"
								Width="120px" MaxLength="10" tabIndex="41"></asp:textbox>
                            <cc1:MaskedEditExtender ID="TxtNacCony_MaskedEdit" runat="server" 
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="TxtNacCony">
                            </cc1:MaskedEditExtender>
                            <asp:textbox id="TxtEdadCony" tabIndex="1" Font-Names="Gill Sans MT" Font-Size="10pt" Enabled="False"
								runat="server" Width="60px"></asp:textbox>
                            <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                                ControlExtender="TxtNacCony_MaskedEdit" ControlToValidate="TxtNacCony" 
                                Display="Dynamic" EmptyValueMessage="La fecha es requerida" 
                                ErrorMessage="Mask_Edit2" Font-Names="Gill Sans MT" Font-Size="10pt" 
                                InvalidValueMessage="Fecha Invalida" 
                                TooltipMessage="Por favor Digite una Fecha">
                            </cc1:MaskedEditValidator>
                        </TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 100px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">
                            Cedula/DPI:<br />
                        </TD>
						<TD style="WIDTH: 230px; HEIGHT: 24px">
                            <asp:textbox id="TxtIdCony" tabIndex="39" 
                                Font-Names="Gill Sans MT" Font-Size="10pt"
								runat="server" Width="120px" MaxLength="16"></asp:textbox></TD>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 79px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 24px">
                            Sexo:</TD>
						<TD style="HEIGHT: 24px"><asp:dropdownlist id="cmbGenCony" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" runat="server"
								Width="192px" tabIndex="42"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="FONT-WEIGHT: normal; FONT-SIZE: 10pt; WIDTH: 100px; COLOR: #16387c; FONT-STYLE: normal; FONT-FAMILY: 'Gill Sans MT'; HEIGHT: 22px">Profesi�n</TD>
						<TD style="WIDTH: 230px; HEIGHT: 22px">
                            <asp:dropdownlist id="cmbProfCony" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" runat="server"
								Width="208px" tabIndex="40"></asp:dropdownlist></TD>
						<TD style="WIDTH: 79px; HEIGHT: 22px"></TD>
						<TD style="HEIGHT: 22px">
                            <asp:CheckBox ID="Sleer" runat="server" Font-Bold="False" 
                                Font-Names="Gill Sans MT" Font-Size="10pt" Text="Sabe Leer y Escribir" 
                                Checked="True"  tabIndex="43" Visible="False"/>
                        </TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR>
			<TD style="HEIGHT: 53px">
				<P align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnuevo" 
                        runat="server" Font-Names="Gill Sans MT" Font-Size="12pt" Text="Nuevo" 
                        Width="85px" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btgrabar" runat="server" Font-Names="Gill Sans MT" 
                        Font-Size="12pt" Text="Grabar" Width="85px" tabIndex="44" 
                        Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="bteditar" runat="server" 
                        Font-Names="Gill Sans MT" Font-Size="12pt" Text="Editar" Width="85px" 
                        Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btCancela" runat="server" 
                        Font-Names="Gill Sans MT" Font-Size="12pt" Text="Inicializar" Width="85px" 
                        Visible="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btreferencia" runat="server" Font-Names="Gill Sans MT" 
                        Font-Size="12pt" Text="Referencias" Width="85px" />
                </P>
			</TD>
		</TR>
		<TR>
			<TD>
                            <asp:CheckBox ID="SeguroV" runat="server" Font-Bold="True" 
                                Font-Names="Century Gothic" Font-Size="10pt" 
                    Text="Sujeto a Retenci�n" Visible="False" />
                            <asp:CheckBox ID="Sfirmar" runat="server" Font-Bold="True" 
                                Font-Names="Century Gothic" Font-Size="10pt" Text="Sabe Leer y Escribir" 
                                Checked="True" Visible="False" />
                            <asp:DropDownList ID="DropDownComu0" runat="server" Font-Names="Gill Sans MT" 
                                Font-Size="10pt" Width="110px" Visible="False" Enabled="False" 
                                Height="16px">
                            </asp:DropDownList>
                                    </TD>
		</TR>
	</TABLE>
</P>
            <asp:HiddenField ID="hfExtension" runat="server" />
            <asp:HiddenField ID="hfPathArchivo" runat="server" />
            
            <asp:HiddenField ID="hfIdEmpleado" runat="server" />
        
            
