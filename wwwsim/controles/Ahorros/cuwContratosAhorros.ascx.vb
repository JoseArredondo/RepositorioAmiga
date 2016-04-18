﻿Imports System.IO
Imports DocumentFormat.OpenXml.Packaging
Imports System.Text.RegularExpressions

Partial Class controles_cuwContratosAhorros
    Inherits System.Web.UI.UserControl

    Private cls1 As New SIM.BL.ClsMantenimiento
    Private clase As New SIM.BL.class1

    'Private crDatos As New ReportDocument
    Private crDatos As New crContratos
    Private nombreReporte As String = "Reporte"

#Region "Variables"
    Private _URLCodigo As String
    'Private pcCodCta As String
    'Private lNuevo As Boolean
    Private vCnn As Boolean
    Private Transacc As String
    Private ds As New DataSet
    Private ds_R As New DataSet
    Private lnindice_R As Integer
    Private lnindice_R1 As Integer
    Private lncodigo_R As String
    Private lnVal_R As String
    Private llBan_R As Boolean = False
    Private x As Integer
    Private y As Integer
    Private lnusu_R As String
    Private lnapl_R As String
    Private clsConvert As New SIM.BL.ConversionLetras


    'Variable de la clase Mantenimiento
    Private lnparametro1_R As String
    Private lnparametro2_R As String
    Private lnparametro3_R As String
    Private lnparametro4_R As String
    Private lnparametro5_R As String

    Private lnparametro6_R As String
#End Region

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub


    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aquí el código de usuario para inicializar la página
        'Dim ds As New dscontratos

        ''Es importante utilizar el System.Data.MissingSchemaAction.Ignore, 
        ''para que nos evite errores y haga el merge correctamente
        'ds.Merge(ReturnDataSet, False, System.Data.MissingSchemaAction.Ignore)

        'crDatos.SetDataSource(ds)
        'Me.crvPrueba.ReportSource = crDatos
        'Me.crvPrueba.Visible = False
        If Not IsPostBack Then
            Me.cargardatos()
            txtCodUsu.Text = Session("gcCodusu")
        End If
    End Sub

#Region "Funciones"
    Public Sub CargarPorCliente(ByVal codigoCliente As String)
        Me.txtccodcta.Text = codigoCliente
        'Nombre del Cliente
        Dim entidad3 As New SIM.EL.creditos
        Dim ecreditos As New SIM.BL.ccreditos


        entidad3.ccodcta = codigoCliente.Trim
        ecreditos.Obtenercreditos(entidad3)

        Me.txtccodcli.Text = entidad3.ccodcli.Trim
        Me.txtcnomcli.Text = entidad3.cnomcli.Trim

        If entidad3.cestado <> "E" Then
            Response.Write("<script language='javascript'>alert('Estado de Credito Errado')</script>")
            Me.cbxContrato.Enabled = False
            Me.Button1.Enabled = False
            Exit Sub
        End If

        Me.cbxContrato.Enabled = True
        Me.Button1.Enabled = True
        'Me.cbxContrato.SelectedValue = entidad3.ctipcon.Trim


        'Me.btnAplica_ServerClick(Me, New System.EventArgs)
    End Sub
    Public Sub CargarPorcuentahorro(ByVal ccodaho As String)
        Me.txtccodcta.Text = ccodaho

        Dim entidadahomcta As New ahomcta
        Dim mahomcta As New cAhomcta

        entidadahomcta.ccodaho = ccodaho
        mahomcta.ObtenerAhomcta(entidadahomcta)

        Dim entidadaclimide As New climide
        Dim mclimide As New cClimide

        entidadaclimide.ccodcli = entidadahomcta.cnudotr
        mclimide.ObtenerClimide(entidadaclimide)

        Me.txtcnomcli.Text = entidadaclimide.cnomcli

        Me.cbxContrato.Enabled = True
        Me.Button1.Enabled = True

    End Sub
    Private Sub cargardatos()
        lnparametro1_R = "cDescri , rtrim(ltrim(cCodigo)) as cCodigo, "
        lnparametro2_R = "S,S, "
        lnparametro3_R = " "
        lnparametro4_R = "TABTTAB"
        lnparametro5_R = "S"
        lnparametro6_R = "Where cCodTab + cTipReg ='3101' order by ccodigo"
        Transacc = cls1.Transac(lnparametro1_R, lnparametro2_R, lnparametro3_R, _
        lnparametro4_R, lnparametro5_R, lnparametro6_R)
        ds = cls1.ResulSelect(Transacc)
        If ds.Tables("Resultado").Rows.Count <= 0 Then
            MsgBox("No existen Datos a Eligir", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If
        Me.cbxContrato.DataTextField = "cDescri"
        Me.cbxContrato.DataValueField = "cCodigo"
        Me.cbxContrato.DataSource = ds.Tables("Resultado")
        Me.cbxContrato.DataBind()

        ds.Clear()
    End Sub
    Public Function Num2Text(ByVal value As Double) As String

        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select


    End Function

    Public Function Duiletras(ByVal Duivalue As String) As String
        Dim lntam As Integer = 0
        Dim lcduilet1 As String = ""
        Dim lcduilet2 As String = ""
        Dim lcultimo As String = ""
        Dim lcceros As String = ""
        Duivalue = Duivalue.Replace("-", "")
        lntam = Duivalue.Length
        If lntam = 0 Then
            lcduilet1 = ""
            lcduilet2 = ""
            lcultimo = ""
        Else

            Dim lnrot As Integer = 0
            Dim lcflag As String
            Dim lnflag As Integer = 0
            For lnrot = 0 To (lntam - 1)
                lcflag = Duivalue.Substring(lnrot, 1)
                If lcflag = "0" Then
                    lnflag += 1
                Else
                    Exit For
                End If
            Next
            If lnflag = 1 Then
                lcceros = "CERO "
            ElseIf lnflag = 2 Then
                lcceros = "CERO CERO "
            ElseIf lnflag = 3 Then
                lcceros = "CERO CERO CERO "
            ElseIf lnflag = 4 Then
                lcceros = "CERO CERO CERO CERO "
            ElseIf lnflag = 5 Then
                lcceros = "CERO CERO CERO CERO CERO "
            Else
                lcceros = " "
            End If
            lcduilet2 = Duivalue.Substring(0, lntam - 1)
            lcduilet1 = Num2Text(Integer.Parse(lcduilet2))
            If Integer.Parse(Duivalue.Substring(lntam - 1, 1)) = 1 Then
                lcultimo = "UNO"
            Else
                lcultimo = Num2Text(Integer.Parse(Duivalue.Substring(lntam - 1, 1)))
            End If

            lcduilet1 = lcduilet1 & " GUIÓN " & lcultimo

            lcduilet1 = lcceros & lcduilet1
            lcduilet1 = lcduilet1.ToLower

        End If

        Return lcduilet1
    End Function
#End Region


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click




        Dim lcNombre As String = ""
        Dim filename As String = ""
        Dim nombre As String = ""


        If cbxContrato.SelectedValue = "A" Then
            lcNombre = "Documentos\Ahorros\CONTRATO DE AHORRO-PARTICULARES.docx"
        ElseIf cbxContrato.SelectedValue = "B" Then
            lcNombre = "Documentos\Ahorros\CONTRATO DE AHORRO-EMPRESAS PRIVADAS.docx"
        ElseIf cbxContrato.SelectedValue = "C" Then
            lcNombre = "Documentos\Ahorros\CONTRATO DE AHORRO REMESAS-PARTICULARES.docx"
        ElseIf cbxContrato.SelectedValue = "D" Then
            lcNombre = "Documentos\Ahorros\CONTRATO DE AHORRO REMESAS-EMPRESAS PRIVADAS.docx"
        ElseIf cbxContrato.SelectedValue = "E" Then
            lcNombre = "Documentos\Ahorros\CONTRATO DE AHORRO PROGRAMADO-PARTICULARES.docx"
        ElseIf cbxContrato.SelectedValue = "F" Then
            lcNombre = "Documentos\Ahorros\CONTRATO DE AHORRO PROGRAMADO-EMPRESA PRIVADA.docx"

        End If

        filename = Server.MapPath(lcNombre)
        If Not File.Exists(filename) Then
            Return
        Else
            If Directory.Exists("C:\Contratos\Ahorros ") = False Then
                Directory.CreateDirectory("C:\Contratos\Ahorros ")
            End If

            nombre = "C:\Contratos\Ahorros " + cbxContrato.SelectedItem.Text.Trim + " - " + txtccodcta.Text.Trim.ToUpper + " - " + _
                     txtcnomcli.Text.Trim.ToUpper + ".docx"

            FileCopy(filename, nombre)

        End If


        Try
            ContratosWord_Ahorro(nombre)

        Catch ex As Exception
            Me.btnExportar.Enabled = False
            Response.Write("<script language='javascript'>alert('Imposible Generar el Contrato, Datos Invalidos, Advertencia SIM.NET')</script>")
        End Try
        'Buscar_Reemplazar(nombre, eCon)

    End Sub



#Region "Contratos"




    Private Sub ContratosWord_Ahorro(ByVal Contrato As String)
        Dim input As String = ""
        Dim lcnomcli As String = ""
        Dim lcnombar As String = ""
        Dim lcnombre As String = ""

        lcnombre = Me.txtcnomcli.Text.Trim
        'lee un archivo de texto


        Dim lccodcli As String = ""
        Dim lnmonsug As Double = 0
        Dim lncuosug As Double = 0
        Dim lcmonto As String = ""
        Dim lnentero As Double = 0
        Dim lndeci As Double = 0
        Dim lccuosug As String = ""
        Dim etabttab As New tabttab
        Dim mtabttab As New cTabttab
        Dim ecremcre As New cremcre
        Dim mcremcre As New cCremcre
        Dim ecredtpl As New credtpl
        Dim mcredtpl As New cCredtpl

        Dim lcdestino As String = ""
        Dim lcFuenteFondos As String = ""
        Dim lncuota As Double = 0
        Dim lccuota As String = ""
        Dim lcfecha As String = ""
        Dim ldfecha As Date = Nothing

        Dim lnmes As Integer = 0
        Dim lndia As Integer = 0
        Dim lnano As Integer = 0
        Dim lcmes As String = ""
        Dim lccodpro As String = ""


        Dim lnmesven As Integer = 0
        Dim lndiaven As Integer = 0
        Dim lnanoven As Integer = 0
        Dim lcmesven As String = ""


        Dim mclimide As New cClimide
        Dim eclimide As New climide
        Dim etabtprf As New tabtprf
        Dim mtabtprf As New cTabtprf



        Dim lcprofesion As String = ""
        Dim lcdirdom As String = ""
        Dim lcedad As String = ""
        Dim lcdui As String = ""
        Dim lcdesdui As String = ""
        Dim lntam As Integer = 0
        Dim i As Integer
        Dim lcdesdui1 As String = ""
        Dim lcdesdui2 As String = ""
        Dim lcultimo As String = ""
        Dim lcprimero As String = ""
        Dim lcnit As String = ""
        Dim lcnitn As String = ""
        Dim lcdesnit As String = ""
        Dim lcdesnit2 As String = ""
        Dim lcdesnit3 As String = ""
        Dim ldvencimiento As Date = Nothing
        Dim lcvencimiento As String = ""
        Dim lcmonpre As String = ""
        Dim lccoddom As String = ""
        '>>>>>>>>>>>>>>>>>>>>>>>
        Dim lcplazo1 As String = ""

        Dim lctiper As String = ""
        Dim lndia1 As Integer = 0
        Dim lnnumcuo As Integer = 0
        Dim lcforma As String = ""
        Dim ldfecvig As Date = Nothing
        Dim ldfecven As Date = Nothing
        Dim lnmeses As Integer = 0
        Dim lcmeses As String = ""
        Dim lnInterMora As Double = 0
        Dim lnInterMoraLetras As String = ""

        Dim lnFormadePago As String = ""
        Dim fechacuopri As String = ""

        Dim HoraImp As String
        Dim MinImp As String
        Dim HoraMinImp As String
        Dim DiaImp As String
        Dim MesImp As String
        Dim YearImip As String

        Dim HoraFechaImp As String
        Dim lcncuenta As String
        Dim ds_aho As New DataSet
        Dim ommclass As New cAhomcta
        Dim array_d As New ArrayList

        ecremcre.ccodcta = Me.txtccodcta.Text.Trim
        mcremcre.ObtenerCremcre(ecremcre)


        '---Departamento y Municipio del Usuario del Sistema
        Dim eusuarios As New cusuarios
        Dim clsusuarios As New usuarios
        Dim etabtofi As New cTabtofi
        Dim clstabtofi As New tabtofi

        Dim ccodusu, ccodofi As String


        Dim DeptoOfi As String = ""
        Dim MuniOfi As String = ""



        clsusuarios.usuario = txtCodUsu.Text.Trim.ToUpper 'Session("gcCodusu").ToString.ToUpper

        eusuarios.RecuperarUsuario(clsusuarios)

        With clsusuarios
            ccodusu = .usuario
            ccodofi = .ccodofi
        End With

        clstabtofi.ccodofi = ccodofi

        etabtofi.ObtenerTabtofi(clstabtofi)

        With clstabtofi
            DeptoOfi = .cdepa.Trim
            MuniOfi = .cmuni.Trim
        End With


        'Extrae datos de Ahorros
        ds_aho = ommclass.Extraer_Datos_cta_ahorros_contratos(Me.txtccodcta.Text.Trim)

        array_d.Add("")  'Codigo de ahorro
        array_d.Add("")  'Nombre de socio
        array_d.Add(Session("gdfecsis"))  'fecha de nacimiento
        array_d.Add(0)  'Edad
        array_d.Add("")  'Profesion
        array_d.Add(0)  'tasa anualizada
        array_d.Add(0)  'monto de apertura
        array_d.Add(0)  'tipo cliente
        array_d.Add("")  'nombre de representante legal


        For Each fila As DataRow In ds_aho.Tables(0).Rows

            array_d.Item(0) = fila("ccodaho")  'Codigo de ahorro
            array_d.Item(1) = fila("cnomcli") 'Nombre de socio
            array_d.Item(2) = fila("dnacimi") 'fecha de nacimiento 
            array_d.Item(3) = fila("canos") 'Edad
            array_d.Item(4) = fila("cdescri") 'Profesion
            array_d.Item(5) = fila("ntasint") 'tasa anualizada
            array_d.Item(6) = fila("nsaldoaho") 'monto de apertura
            array_d.Item(7) = fila("cclaper") ' tipo cliente
            array_d.Item(8) = fila("nombreplegal") ' nombre de representante legal

        Next


        'If array_d.Item(7).ToString.Trim <> "2" Then

        BuscarYReemplzar(Contrato, "pcnomcli", array_d.Item(1).ToString.Trim) 'nombre de representante legal

        ' Else
        BuscarYReemplzar(Contrato, "pcnombreplegal", array_d.Item(8).ToString.Trim) 'Nombre de socio
        'End If

        BuscarYReemplzar(Contrato, "pcctaAho", array_d.Item(0).ToString.Trim) 'Codigo de ahorro
        BuscarYReemplzar(Contrato, "pcnaci", array_d.Item(2).ToString.Trim) 'fecha de nacimiento
        BuscarYReemplzar(Contrato, "pcanos", array_d.Item(3).ToString.Trim) 'Edad
        BuscarYReemplzar(Contrato, "pcpro", array_d.Item(4).ToString.Trim) 'Profesion
        BuscarYReemplzar(Contrato, "pcntasint", array_d.Item(5).ToString.Trim) 'tasa anualizada
        BuscarYReemplzar(Contrato, "pcnsaldoah", array_d.Item(6).ToString.Trim) 'monto de apertura

        'datos de impresion

        BuscarYReemplzar(Contrato, "DeptoOfi", DeptoOfi) 'Departamento donde se está imprimiendo del Contrato (usuario del sistema)
        BuscarYReemplzar(Contrato, "MuniOfi", MuniOfi) 'Municipio donde se está imprimiendo del Contrato (usuario del sistema)
        BuscarYReemplzar(Contrato, "DiaImpr", Num2Text(Now.Day)) 'Dia de Impresion
        BuscarYReemplzar(Contrato, "MesImpr", MonthName(Now.Month).ToUpper) 'Mes de Impresion
        BuscarYReemplzar(Contrato, "AñoImpr", Num2Text((Now.Year))) 'Año de Impresion


        '----Descargar el Archivo

        Dim filename As String = Contrato

        If filename <> "" Then
            'Dim path As String = Server.MapPath(filename)
            Dim path As String = filename
            Dim file As New System.IO.FileInfo(path)

            If file.Exists Then
                Response.Clear()
                Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
                Response.AddHeader("Content-Length", file.Length.ToString())
                'Response.ContentType = "application/octet-stream"
                Response.ContentType = "application/msword"
                Response.WriteFile(file.FullName)
                Response.End()
            Else
                Response.Write("El Archivo no Existe")
            End If
        End If


        '    ldfecvig = ecremcre.dfecvig
        '    ldfecven = ecremcre.dfecven
        '    lnmeses = DateDiff(DateInterval.Month, ldfecvig, ldfecven)




        '    HoraImp = Num2Text(Now.Hour).ToLower
        '    MinImp = Num2Text(Now.Minute).ToLower

        '    HoraMinImp = HoraImp + " horas con " + MinImp + " minutos"

        '    DiaImp = Num2Text(Now.Day).ToLower
        '    MesImp = MonthName(Now.Month)
        '    YearImip = Num2Text(Now.Year).ToLower

        '    HoraFechaImp = HoraMinImp + " del día " + DiaImp + " de " + MesImp + " del año " + YearImip

        '    lnInterMora = mcremcre.InteresMoratorio(Me.txtccodcta.Text.Trim)

        '    lnInterMoraLetras = Num2Text(lnInterMora)


        '    'Destino del credito
        '    lcdestino = mcremcre.DestinoCredito(Me.txtccodcta.Text.Trim)

        '    'Forma de pago (Mensual, Trimestral, etc
        '    lnFormadePago = mcremcre.FormadePago(Me.txtccodcta.Text.Trim)


        '    lcmeses = Num2Text(lnmeses)


        '    Dim lcdiapago As String = ""


        '    lctiper = ecremcre.ctipper

        '    lndia1 = ecremcre.ndiasug
        '    lnnumcuo = ecremcre.ncuosug
        '    lcforma = clase.formapago2(lctiper, lndia1)

        '    lcdiapago = Num2Text(lndia1)


        '    Dim lctasalet As String = ""
        '    Dim lnenter As Double
        '    Dim lndecimal As Double
        '    Dim lnTasa As Double
        '    'lctasalet = Num2Text(ecremcre.ntasint)

        '    lnenter = Decimal.Floor(ecremcre.ntasint)
        '    lndecimal = Math.Round((ecremcre.ntasint - lnenter) * 100)
        '    If lndecimal > 0 Then
        '        lctasalet = Num2Text(lnenter) & " PUNTO " & Num2Text(lndecimal)
        '        lnTasa = Num2Text(lnenter) & " PUNTO " & Num2Text(lndecimal)
        '    Else
        '        lctasalet = Num2Text(lnenter)
        '        lnTasa = lnenter
        '    End If


        '    '<<<<<<<<<<<<<<<<<<<<<<<
        '    Dim etabtzon As New tabtzon
        '    Dim mtabtzon As New cTabtzon
        '    Dim lcmunicipio As String = ""
        '    Dim lcdepartamento As String = ""
        '    Dim lcplazo As String = ""
        '    Dim lcdias As String = ""
        '    Dim lccredito As String = ""
        '    Dim lclugexp As String = ""

        '    eclimide.ccodcli = ecremcre.ccodcli


        '    lcnomcli = Me.txtcnomcli.Text.Trim
        '    lccodcli = Me.txtccodcli.Text.Trim
        '    lnmonsug = ecremcre.nmonapr
        '    lncuosug = ecremcre.ncuosug
        '    lcmonpre = ecremcre.nmonapr

        '    lnentero = Decimal.Floor(lnmonsug)
        '    lndeci = Math.Round((lnmonsug - lnentero) * 100)
        '    If lndeci > 0 Then
        '        lcmonto = Num2Text(lnentero) & " DOLARES " & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
        '    Else
        '        lcmonto = Num2Text(lnentero) & " DOLARES CON CERO CENTAVOS " 'monto en letras
        '    End If

        '    lccuosug = Num2Text(lncuosug)  'cuotas en letras
        '    lcplazo = Num2Text(lncuosug) ' " CUOTAS "
        '    'lcplazo1 = Num2Text(lncuosug - 1)




        '    lccodcli = ecremcre.ccodcli
        '    lccredito = Me.txtccodcta.Text.Trim

        '    etabttab.ccodtab = "033"
        '    etabttab.ctipreg = "1"
        '    etabttab.ccodigo = ecremcre.ccodfue.Trim
        '    mtabttab.ObtenerTabttab(etabttab)

        '    'lcdestino = etabttab.cdescri.Trim  'destino del credito

        '    lcFuenteFondos = etabttab.cdescri.Trim


        '    ecredtpl.ccodcta = Me.txtccodcta.Text.Trim
        '    ecredtpl.ctipope = "N"
        '    ecredtpl.cnrocuo = "001"
        '    mcredtpl.ObtenerCredtpl(ecredtpl)
        '    clase.gnperbas = Session("gnperbas")
        '    clase.pnComtra = Session("gnComTra")
        '    clase.pnSegVm = Session("gnSegVm1")

        '    Dim ldpricuo As Date = Nothing
        '    Dim lcmespri As String = ""
        '    Dim lcañocuopri As String = ""

        '    ldpricuo = ecredtpl.dfecven
        '    lcmespri = MonthName(ldpricuo.Month)
        '    lcañocuopri = ldpricuo.Year.ToString.Trim


        '    fechacuopri = Num2Text(ldfecvig.Day).ToUpper & " DE " & MonthName(ldfecvig.Month).ToUpper & " DE " & Num2Text(ldfecvig.Year).ToUpper



        '    lncuota = ecremcre.nmoncuo

        '    lnentero = Decimal.Floor(lncuota)
        '    lndeci = Math.Round((lncuota - lnentero) * 100)
        '    If lndeci > 0 Then
        '        lccuota = Num2Text(lnentero) & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
        '    Else
        '        lccuota = Num2Text(lnentero) 'monto en letras
        '    End If

        '    'fecha desembolso
        '    ldfecha = Date.Parse(ecremcre.dfecapr)
        '    lnmes = ldfecha.Month
        '    lndia = ldfecha.Day
        '    lnano = ldfecha.Year
        '    lcmes = MonthName(lnmes)
        '    lcfecha = Num2Text(lndia) & " DIAS DEL MES DE " & lcmes & " DE " & Num2Text(lnano)
        '    lcfecha = lcfecha.ToUpper
        '    lcdias = Num2Text(lndia)

        '    ''obtiene fecha de vencimiento
        '    ldvencimiento = Date.Parse(ecremcre.dfecven)
        '    lnmesven = ldvencimiento.Month
        '    lndiaven = (ldvencimiento.Day)
        '    lnanoven = ldvencimiento.Year
        '    lcmesven = MonthName(lnmesven)
        '    lcvencimiento = Num2Text(lndiaven) & " DEL MES DE " & lcmesven & " DE " & Num2Text(lnanoven)
        '    lcvencimiento = lcvencimiento.ToUpper


        '    'obtiene datos del cliente
        '    eclimide.ccodcli = lccodcli
        '    mclimide.ObtenerClimide(eclimide)
        '    lcdirdom = eclimide.cdirdom
        '    lcdui = eclimide.cnudoci.Trim
        '    lclugexp = eclimide.cLugExp.Trim
        '    'lcdui = lcdui.Replace("-", "")
        '    lcnit = Replace(eclimide.cnudotr.Trim, "-", "")
        '    lcnitn = eclimide.cnudotr.Trim  '????????????????????????????????????????????????????????????????????????
        '    lcncuenta = ecremcre.ccodcta.Trim
        '    lccoddom = eclimide.ccoddom.Trim

        '    lccodpro = eclimide.ccodpro



        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    'obtiene municipio y departamento expedicion


        '    Dim lcmuniexp As String = ""
        '    Dim lcdepaexp As String = ""

        '    Dim lclugexp1 As String = ""
        '    Dim lclugexp2 As String = ""
        '    Dim lclugexp3 As String = ""

        '    Dim lcmuniexp1 As String = ""
        '    Dim lcmuniexp2 As String = ""
        '    Dim lcmuniexp3 As String = ""

        '    Dim lcdepaexp1 As String = ""
        '    Dim lcdepaexp2 As String = ""
        '    Dim lcdepaexp3 As String = ""
        '    Dim lnedad As Double = 0

        '    If lclugexp.Trim = "" Then
        '    Else

        '        etabtzon.ccodzon = lclugexp
        '        etabtzon.ctipzon = "2"
        '        mtabtzon.ObtenerTabtzon(etabtzon)
        '        lcmuniexp = etabtzon.cdeszon.Trim
        '        lcmuniexp = lcmuniexp.ToUpper
        '        'departamento
        '        etabtzon.ccodzon = lclugexp.Substring(0, 2)
        '        etabtzon.ctipzon = "1"
        '        mtabtzon.ObtenerTabtzon(etabtzon)
        '        lcdepaexp = etabtzon.cdeszon.Trim
        '        lcdepaexp = lcdepaexp.ToUpper

        '    End If



        '    etabtprf.ccodigo = lccodpro
        '    mtabtprf.ObtenerTabtprf(etabtprf)
        '    lcprofesion = etabtprf.cdescri.Trim  ' profesion
        '    'If eclimide.dnacimi <> Nothing Then
        '    lnedad = clase.CalculaEdad(eclimide.dnacimi)
        '    lcedad = Num2Text(IIf(lnedad < 0, 1, lnedad))
        '    lcedad = lcedad.ToLower
        '    'End If
        '    'detalla el dui en letras

        '    If lcdui.Trim.Length = 10 Then
        '        '            lcdesdui = Me.Duiletras(lcdui)

        '        'lcdui = lcdui.Replace("-", "")
        '        lcdesdui = cDUI(lcdui)
        '        lcdesdui = lcdesdui.Trim.ToUpper
        '    Else
        '        lcdesdui = ""
        '    End If




        '    'detalla el nit
        '    lntam = lcnit.Length
        '    lcdesnit = ""
        '    If lntam <> 14 Then
        '        lcdesnit = ""
        '        '    '            Response.Write("<script language='javascript'>alert('Nit del cliente no posee 14 caracteres')</script>")
        '    Else
        '        lcdesnit2 = lcnit.Substring(0, 4)
        '        lcdesnit = Num2Text(Integer.Parse(lcdesnit2))

        '        If lcnit.Substring(0, 3) = "000" Then
        '            lcdesnit = "CERO CERO CERO " & lcdesnit
        '        ElseIf lcnit.Substring(0, 2) = "00" Then
        '            lcdesnit = "CERO CERO " & lcdesnit
        '        ElseIf lcnit.Substring(0, 1) = "0" Then
        '            lcdesnit = "CERO " & lcdesnit
        '        End If

        '        lcdesnit2 = lcnit.Substring(4, 6)
        '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))

        '        lcdesnit2 = lcnit.Substring(10, 3)

        '        If lcnit.Substring(10, 2) = "00" Then
        '            lcdesnit = lcdesnit & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit2))
        '        ElseIf lcnit.Substring(10, 1) = "0" Then
        '            lcdesnit = lcdesnit & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit2))
        '        Else
        '            lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))
        '        End If


        '        lcdesnit2 = lcnit.Substring(lntam - 1, 1)
        '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))
        '        lcdesnit = lcdesnit.ToUpper
        '        'lcnit = lcnit.Replace("-", "")
        '        'lcdesnit = cNIT(lcnit)
        '        'lcdesnit = lcdesnit.ToUpper()
        '    End If

        '    'obtiene municipio y departamento

        '    etabtzon.ccodzon = lccoddom
        '    etabtzon.ctipzon = "3"
        '    mtabtzon.ObtenerTabtzon(etabtzon)
        '    lcmunicipio = etabtzon.cdeszon.Trim
        '    lcmunicipio = lcmunicipio.ToUpper
        '    'departamento
        '    etabtzon.ccodzon = lccoddom.Substring(0, 2)
        '    etabtzon.ctipzon = "1"
        '    mtabtzon.ObtenerTabtzon(etabtzon)
        '    lcdepartamento = etabtzon.cdeszon.Trim
        '    lcdepartamento = lcdepartamento.ToUpper


        '    '---Departamento y Municipio del Usuario del Sistema
        '    Dim eusuarios As New cusuarios
        '    Dim clsusuarios As New usuarios
        '    Dim etabtofi As New cTabtofi
        '    Dim clstabtofi As New tabtofi

        '    Dim ccodusu, ccodofi As String


        '    Dim DeptoOfi As String = ""
        '    Dim MuniOfi As String = ""



        '    clsusuarios.usuario = txtCodUsu.Text.Trim.ToUpper 'Session("gcCodusu").ToString.ToUpper

        '    eusuarios.RecuperarUsuario(clsusuarios)

        '    With clsusuarios
        '        ccodusu = .usuario
        '        ccodofi = .ccodofi
        '    End With

        '    clstabtofi.ccodofi = ccodofi

        '    etabtofi.ObtenerTabtofi(clstabtofi)

        '    With clstabtofi
        '        DeptoOfi = .cdepa.Trim
        '        MuniOfi = .cmuni.Trim
        '    End With



        '    '**************************obtiene datos del fiador******************

        '    Dim eclimgar As New climgar
        '    Dim mclimgar As New cClimgar
        '    Dim lccoduni As String = ""
        '    Dim lcnombre1 As String = ""
        '    Dim lcnit1 As String = ""
        '    Dim lcdui1 As String = ""
        '    Dim lcfiaduin1 As String = ""
        '    Dim lcfianitn1 As String = ""
        '    Dim lcfiaduin2 As String = ""
        '    Dim lcfianitn2 As String = ""
        '    Dim lcfiaduin3 As String = ""
        '    Dim lcfianitn3 As String = ""

        '    Dim lccodpro1 As String = ""
        '    Dim ldnacimi1 As Date = Nothing
        '    Dim lcdesnit1f As String = ""
        '    Dim lcdesnit2f As String = ""
        '    Dim lcdesnit3f As String = ""
        '    Dim lcdesnitf As String = ""
        '    Dim lcdesnitLetras1 As String = ""
        '    Dim lcdesnitLetras2 As String = ""
        '    Dim lcdesnitLetras3 As String = ""
        '    Dim lcdesduif As String = ""
        '    Dim lcdesdui2f As String = ""
        '    Dim lcprofesion1 As String = ""
        '    Dim lcedad1 As String = ""
        '    Dim lnedad1 As Double = 0
        '    Dim lccoddom1 As String = ""
        '    Dim lcmunicipio1 As String = ""
        '    Dim lcdepartamento1 As String = ""
        '    Dim lcdesduif1 As String = ""
        '    'Para fiador 2
        '    Dim lcnombre2 As String = ""
        '    Dim lcedad2 As String = ""
        '    Dim lcprofesion2 As String = ""
        '    Dim lcmunicipio2 As String = ""
        '    Dim lcdepartamento2 As String = ""
        '    Dim lcdesduif2 As String = ""

        '    Dim lcnit2 As String = ""
        '    Dim lcdui2 As String = ""
        '    Dim lccodpro2 As String = ""
        '    Dim ldnacimi2 As Date = Nothing
        '    Dim lccoddom2 As String = ""

        '    'Para fiador 3
        '    Dim lcnombre3 As String = ""
        '    Dim lcedad3 As String = ""
        '    Dim lcprofesion3 As String = ""
        '    Dim lcmunicipio3 As String = ""
        '    Dim lcdepartamento3 As String = ""
        '    Dim lcdesduif3 As String = ""

        '    Dim lcnit3 As String = ""
        '    Dim lcdui3 As String = ""
        '    Dim lccodpro3 As String = ""
        '    Dim ldnacimi3 As Date = Nothing
        '    Dim lccoddom3 As String = ""
        '    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        '    Dim lcdirdom1 As String = ""
        '    Dim lcdirdom2 As String = ""
        '    Dim lcdirdom3 As String = ""

        '    Dim lnfia As Integer = 0

        '    lccoduni = "**"
        '    eclimgar.ccodcli = lccodcli

        '    Dim ds As New DataSet
        '    'ds = mclimgar.ObtenerDataSetPor_Garantia_Cliente(lccodcli)
        '    ds = mclimgar.Datos_Fiadores(Me.txtccodcta.Text.Trim)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Dim fila As DataRow
        '        Dim ele As Integer = 0
        '        For Each fila In ds.Tables(0).Rows
        '            lnfia += 1
        '            If lnfia = 1 Then

        '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
        '                eclimide.ccodcli = lccoduni
        '                mclimide.ObtenerClimide(eclimide)
        '                lcnombre1 = eclimide.cnomcli.Trim
        '                lcnit1 = Replace(eclimide.cnudotr.Trim, "-", "")
        '                lcdui1 = eclimide.cnudoci.Trim
        '                'lcdui1 = lcdui1.Replace("-", "")
        '                lccodpro1 = eclimide.ccodpro.Trim
        '                ldnacimi1 = eclimide.dnacimi
        '                lccoddom1 = eclimide.ccoddom.Trim
        '                lcdirdom1 = eclimide.cdirdom.Trim
        '                lcfianitn1 = eclimide.cnudotr.Trim
        '                lcfiaduin1 = eclimide.cnudoci.Trim

        '                lclugexp1 = eclimide.cLugExp.Trim
        '                If lclugexp1.Trim = "" Then
        '                Else



        '                    etabtzon.ccodzon = lclugexp1
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmuniexp1 = etabtzon.cdeszon.Trim
        '                    lcmuniexp1 = lcmuniexp1.ToUpper
        '                    'departamento
        '                    etabtzon.ccodzon = lclugexp1.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepaexp1 = etabtzon.cdeszon.Trim
        '                    lcdepaexp1 = lcdepaexp1.ToUpper
        '                End If
        '                'detalla el nit

        '                ''''''''''''''''''''''''''''''''''

        '                lntam = lcnit1.Length
        '                If lntam <> 14 Then
        '                    lcdesnitLetras1 = ""
        '                    lcdesnit1f = ""
        '                    '                Response.Write("<script language='javascript'>alert('Nit del fiador no posee 17 caracteres')</script>")
        '                Else

        '                    lcdesnit1f = lcnit1.Substring(0, 4)
        '                    lcdesnitLetras1 = Num2Text(Integer.Parse(lcdesnit1f))


        '                    If lcnit1.Substring(0, 3) = "000" Then
        '                        lcdesnitLetras1 = "CERO CERO CERO " & lcdesnitLetras1
        '                    ElseIf lcnit1.Substring(0, 2) = "00" Then
        '                        lcdesnitLetras1 = "CERO CERO " & lcdesnitLetras1
        '                    ElseIf lcnit1.Substring(0, 1) = "0" Then
        '                        lcdesnitLetras1 = "CERO " & lcdesnitLetras1
        '                    End If


        '                    lcdesnit1f = lcnit1.Substring(4, 6)
        '                    lcdesnitLetras1 = lcdesnitLetras1 & " guión " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    lcdesnit1f = lcnit1.Substring(10, 3)

        '                    If lcnit1.Substring(10, 2) = "00" Then
        '                        lcdesnitLetras1 = lcdesnitLetras1 & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    ElseIf lcnit1.Substring(10, 1) = "0" Then
        '                        lcdesnitLetras1 = lcdesnitLetras1 & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    Else
        '                        lcdesnitLetras1 = lcdesnitLetras1 & " guión " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    End If


        '                    lcdesnit1f = lcnit1.Substring(lntam - 1, 1)
        '                    lcdesnitLetras1 = lcdesnitLetras1 & " guión " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    lcdesnitLetras1 = lcdesnitLetras1.ToUpper
        '                    'lcnit1 = lcnit1.Replace("-", "")
        '                    'lcdesnitLetras1 = cNIT(lcnit1)
        '                    'lcdesnitLetras1.ToUpper()
        '                End If

        '                'detalla el dui en letras


        '                'lcdesduif1 = Me.Duiletras(lcdui1).ToUpper
        '                'lcdui1 = lcdui1.Replace("-", "")
        '                If lcdui1.Trim.Length = 10 Then
        '                    lcdesduif1 = cDUI(lcdui1)
        '                    lcdesduif1 = lcdesduif1.ToUpper
        '                Else
        '                    lcdesduif1 = ""
        '                End If



        '                'obtiene profesion
        '                etabtprf.ccodigo = lccodpro1
        '                mtabtprf.ObtenerTabtprf(etabtprf)
        '                lcprofesion1 = etabtprf.cdescri.Trim
        '                lcprofesion1 = lcprofesion1.ToUpper



        '                'obtiene edad
        '                lnedad1 = clase.CalculaEdad(ldnacimi1)


        '                lcedad1 = Num2Text(IIf(lnedad1 < 0, 1, lnedad1))
        '                lcedad1 = lcedad1.ToLower

        '                'domicilio
        '                'obtiene municipio y departamento
        '                If lccoddom1.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lccoddom1.Substring(0, 4)
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmunicipio1 = etabtzon.cdeszon.Trim
        '                    lcmunicipio1 = lcmunicipio1.ToUpper

        '                    'departamento
        '                    etabtzon.ccodzon = lccoddom1.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepartamento1 = etabtzon.cdeszon.Trim
        '                    lcdepartamento1 = lcdepartamento1.ToUpper
        '                End If
        '            End If
        '            'Segundo fiador >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        '            If lnfia = 2 Then
        '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
        '                eclimide.ccodcli = lccoduni
        '                mclimide.ObtenerClimide(eclimide)
        '                lcnombre2 = eclimide.cnomcli.Trim
        '                lcnit2 = Replace(eclimide.cnudotr.Trim, "-", "")
        '                'lcnit2 = eclimide.cnudotr.Trim
        '                lcdui2 = eclimide.cnudoci.Trim
        '                'lcdui2 = lcdui2.Replace("-", "")
        '                lccodpro2 = eclimide.ccodpro.Trim
        '                ldnacimi2 = eclimide.dnacimi
        '                lccoddom2 = eclimide.ccoddom.Trim
        '                lcdirdom2 = eclimide.cdirdom.Trim
        '                lcfianitn2 = eclimide.cnudotr.Trim
        '                lcfiaduin2 = eclimide.cnudoci.Trim

        '                lclugexp2 = eclimide.cLugExp.Trim

        '                If lclugexp2.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lclugexp2
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmuniexp2 = etabtzon.cdeszon.Trim
        '                    lcmuniexp2 = lcmuniexp2.ToUpper
        '                    'departamento
        '                    etabtzon.ccodzon = lclugexp2.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepaexp2 = etabtzon.cdeszon.Trim
        '                    lcdepaexp2 = lcdepaexp2.ToUpper
        '                End If
        '                'detalla el nit



        '                lntam = lcnit2.Length
        '                If lntam <> 14 Then
        '                    lcdesnit2f = ""
        '                    lcdesnitLetras2 = ""

        '                Else

        '                    lcdesnit2f = lcnit2.Substring(0, 4)
        '                    lcdesnitLetras2 = Num2Text(Integer.Parse(lcdesnit2f))

        '                    If lcnit2.Substring(0, 3) = "000" Then
        '                        lcdesnitLetras2 = "CERO CERO CERO " & lcdesnitLetras2
        '                    ElseIf lcnit2.Substring(0, 2) = "00" Then
        '                        lcdesnitLetras2 = "CERO CERO " & lcdesnitLetras2
        '                    ElseIf lcnit2.Substring(0, 1) = "0" Then
        '                        lcdesnitLetras2 = "CERO " & lcdesnitLetras2
        '                    End If


        '                    lcdesnit2f = lcnit2.Substring(4, 6)
        '                    lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    lcdesnit2f = lcnit2.Substring(10, 3)
        '                    'lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))

        '                    If lcnit2.Substring(10, 2) = "00" Then
        '                        lcdesnitLetras2 = lcdesnitLetras2 & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    ElseIf lcnit2.Substring(10, 1) = "0" Then
        '                        lcdesnitLetras2 = lcdesnitLetras2 & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    Else
        '                        lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    End If

        '                    lcdesnit2f = lcnit2.Substring(lntam - 1, 1)
        '                    lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    lcdesnitLetras2 = lcdesnitLetras2.ToUpper
        '                    'lcnit2 = lcnit1.Replace("-", "")
        '                    'lcdesnitLetras2 = cNIT(lcnit2)
        '                    'lcdesnitLetras2.ToUpper()
        '                End If

        '                'detalla el dui en letras

        '                'lcdesduif2 = Me.Duiletras(lcdui2).ToUpper

        '                'lcdesduif2 = "" 'Me.Duiletras(lcdui2)
        '                'lcdui2 = lcdui1.Replace("-", "")

        '                If lcdui2.Trim.Length = 10 Then
        '                    lcdesduif2 = cDUI(lcdui2)
        '                    lcdesduif2 = lcdesduif2.ToUpper
        '                Else
        '                    lcdesduif2 = ""
        '                End If


        '                'obtiene profesion
        '                etabtprf.ccodigo = lccodpro2
        '                mtabtprf.ObtenerTabtprf(etabtprf)
        '                lcprofesion2 = etabtprf.cdescri.Trim
        '                lcprofesion2 = lcprofesion2.ToLower

        '                'obtiene edad
        '                lnedad1 = clase.CalculaEdad(ldnacimi2)
        '                'lcedad2 = Num2Text(lnedad1)
        '                lcedad2 = Num2Text(IIf(lnedad1 < 0, 1, lnedad1))
        '                lcedad2 = lcedad2.ToLower

        '                'domicilio
        '                'obtiene municipio y departamento

        '                If lccoddom2.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lccoddom2.Substring(0, 4)
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmunicipio2 = etabtzon.cdeszon.Trim
        '                    lcmunicipio2 = lcmunicipio2.ToUpper

        '                    'departamento
        '                    etabtzon.ccodzon = lccoddom2.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepartamento2 = etabtzon.cdeszon.Trim
        '                    lcdepartamento2 = lcdepartamento2.ToUpper
        '                End If
        '            Else
        '                'Manda en blanco Parametros
        '                'lcdesnitLetras2 = ""   me estaba mandando el campo vacio


        '            End If

        '            '---3er Fiador
        '            'Segundo fiador >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        '            If lnfia = 3 Then
        '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
        '                eclimide.ccodcli = lccoduni
        '                mclimide.ObtenerClimide(eclimide)
        '                lcnombre3 = eclimide.cnomcli.Trim
        '                lcnit3 = Replace(eclimide.cnudotr.Trim, "-", "")
        '                'lcnit3 = eclimide.cnudotr.Trim
        '                lcdui3 = eclimide.cnudoci.Trim
        '                'lcdui2 = lcdui2.Replace("-", "")
        '                lccodpro3 = eclimide.ccodpro.Trim
        '                ldnacimi3 = eclimide.dnacimi
        '                lccoddom3 = eclimide.ccoddom.Trim
        '                lcdirdom3 = eclimide.cdirdom.Trim
        '                lcfianitn3 = eclimide.cnudotr.Trim
        '                lcfiaduin3 = eclimide.cnudoci.Trim

        '                lclugexp3 = eclimide.cLugExp.Trim

        '                If lclugexp3.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lclugexp3
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmuniexp3 = etabtzon.cdeszon.Trim
        '                    lcmuniexp3 = lcmuniexp3.ToUpper
        '                    'departamento
        '                    etabtzon.ccodzon = lclugexp3.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepaexp3 = etabtzon.cdeszon.Trim
        '                    lcdepaexp3 = lcdepaexp3.ToUpper
        '                End If
        '                'detalla el nit
        '                lntam = lcnit3.Length
        '                If lntam <> 14 Then
        '                    lcdesnit3f = ""
        '                    lcdesnitLetras3 = ""

        '                Else

        '                    lcdesnit3f = lcnit3.Substring(0, 4)
        '                    lcdesnitLetras3 = Num2Text(Integer.Parse(lcdesnit3f))

        '                    If lcnit3.Substring(0, 3) = "000" Then
        '                        lcdesnitLetras3 = "CERO CERO CERO " & lcdesnitLetras3
        '                    ElseIf lcnit3.Substring(0, 2) = "00" Then
        '                        lcdesnitLetras3 = "CERO CERO " & lcdesnitLetras3
        '                    ElseIf lcnit3.Substring(0, 1) = "0" Then
        '                        lcdesnitLetras3 = "CERO " & lcdesnitLetras3
        '                    End If


        '                    lcdesnit3f = lcnit3.Substring(4, 6)
        '                    lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    lcdesnit3f = lcnit3.Substring(10, 3)
        '                    'lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))


        '                    If lcnit3.Substring(10, 2) = "00" Then
        '                        lcdesnitLetras3 = lcdesnitLetras3 & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    ElseIf lcnit3.Substring(10, 1) = "0" Then
        '                        lcdesnitLetras3 = lcdesnitLetras3 & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    Else
        '                        lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    End If

        '                    lcdesnit3f = lcnit3.Substring(lntam - 1, 1)
        '                    lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    lcdesnitLetras3 = lcdesnitLetras3.ToUpper
        '                    'lcnit3 = lcnit3.Replace("-", "")
        '                    'lcdesnitLetras3 = cNIT(lcnit3)
        '                    'lcdesnitLetras3.ToUpper()
        '                End If

        '                'detalla el dui en letras


        '                'lcdesduif3 = Me.Duiletras(lcdui3).ToUpper
        '                'lcdui3 = lcdui3.Replace("-", "")

        '                'lcdesduif3 = "" 'Me.Duiletras(lcdui2)
        '                If lcdui3.Trim.Length = 10 Then
        '                    lcdesduif3 = cDUI(lcdui3)
        '                    lcdesduif3 = lcdesduif3.ToUpper
        '                Else
        '                    lcdesduif3 = ""
        '                End If


        '                'obtiene profesion
        '                etabtprf.ccodigo = lccodpro3
        '                mtabtprf.ObtenerTabtprf(etabtprf)
        '                lcprofesion3 = etabtprf.cdescri.Trim
        '                lcprofesion3 = lcprofesion3.ToLower

        '                'obtiene edad
        '                lnedad1 = clase.CalculaEdad(ldnacimi3)
        '                'lcedad3 = Num2Text(lnedad1)
        '                lcedad3 = Num2Text(IIf(lnedad1 < 0, 1, lnedad1))

        '                lcedad3 = lcedad3.ToLower

        '                'domicilio
        '                'obtiene municipio y departamento

        '                If lccoddom3.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lccoddom3.Substring(0, 4)
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmunicipio3 = etabtzon.cdeszon.Trim
        '                    lcmunicipio3 = lcmunicipio3.ToUpper

        '                    'departamento
        '                    etabtzon.ccodzon = lccoddom3.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepartamento3 = etabtzon.cdeszon.Trim
        '                    lcdepartamento3 = lcdepartamento3.ToUpper
        '                End If
        '            Else
        '                lcdesnitLetras3 = ""
        '            End If
        '            ele += 1
        '        Next

        '    End If

        '    '------------Garantia Prendaria-----------------------
        '    Dim clsGarantPrenda As New SIM.BL.cGaran_prenda
        '    Dim eGarantPrenda As New SIM.EL.garan_prenda
        '    Dim dsGarantia As DataSet
        '    Dim valpericia As Double
        '    Dim valpericiaLetras As String
        '    Dim GarPrenDescri As String

        '    dsGarantia = clsGarantPrenda.ObtenerGarantiaPrendaria(Me.txtccodcta.Text.Trim)

        '    If dsGarantia.Tables(0).Rows.Count > 0 Then
        '        valpericia = IIf(IsDBNull(dsGarantia.Tables(0).Rows(0)("valpericia")), 0, dsGarantia.Tables(0).Rows(0)("valpericia"))
        '        GarPrenDescri = IIf(IsDBNull(dsGarantia.Tables(0).Rows(0)("descripcio")), "", dsGarantia.Tables(0).Rows(0)("descripcio"))
        '    End If

        '    lnentero = Decimal.Floor(valpericia)
        '    lndeci = Math.Round((valpericia - lnentero) * 100)
        '    If lndeci > 0 Then
        '        valpericiaLetras = Num2Text(lnentero) & " DOLARES " & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
        '    Else
        '        valpericiaLetras = Num2Text(lnentero) & " DOLARES CON CERO CENTAVOS " 'monto en letras
        '    End If


        '    '|-----------------------------------------------------------------|
        '    '|------Nueva Forma de Generar contratos usando OpenXML by HATA----|
        '    '|-----------------------------------------------------------------|

        '    'Dim DocSalida As String = Replace(Contrato, "C:\Contratos\Entrada", "C:\Contratos\Salida")

        '    'If System.IO.File.Exists(DocSalida) Then
        '    '    System.IO.File.Delete(DocSalida)
        '    '    File.Copy(Contrato, DocSalida)
        '    'Else
        '    '    File.Copy(Contrato, DocSalida)
        '    'End If



        '    '----Datos de Cliente
        '    BuscarYReemplzar(Contrato, "pcnomcli", txtcnomcli.Text.Trim) 'Nombre Cliente
        '    BuscarYReemplzar(Contrato, "ProfCliente", lcprofesion.Trim) 'Profesion segun DUI
        '    BuscarYReemplzar(Contrato, "pcedad", lcedad) 'Edad en letras
        '    BuscarYReemplzar(Contrato, "pcdesdui", lcdesdui) 'DUI en letras
        '    BuscarYReemplzar(Contrato, "pcdesnit", lcdesnit) 'NIT en letras
        '    BuscarYReemplzar(Contrato, "pcdirdom", lcdirdom.Trim) 'Domicilio cliente
        '    BuscarYReemplzar(Contrato, "pcmunicipio", lcmunicipio.Trim) 'Departamento
        '    BuscarYReemplzar(Contrato, "pcdepartamento", lcdepartamento.Trim) 'Municipio
        '    BuscarYReemplzar(Contrato, "HoraGen", HoraFechaImp) 'Hora de impresion
        '    BuscarYReemplzar(Contrato, "pcnit", lcnitn.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "lcnumcredito", lcncuenta.Trim) 'credito

        '    '----Credito
        '    BuscarYReemplzar(Contrato, "pcsumade", lcmonto.Trim) 'Monto del credito
        '    BuscarYReemplzar(Contrato, "pcmeses", lcmeses) 'Plazo en meses
        '    BuscarYReemplzar(Contrato, "pcdiapago", lcdiapago) 'Dia de pago
        '    BuscarYReemplzar(Contrato, "fechacuopri", fechacuopri) 'Fecha Primera Cuota
        '    BuscarYReemplzar(Contrato, "pctasalet", lctasalet) 'Tasa en letras
        '    BuscarYReemplzar(Contrato, "pcTasa", lnTasa) 'Tasa %
        '    BuscarYReemplzar(Contrato, "pcInterMora", lnInterMora) ' % Interes Moratorio
        '    BuscarYReemplzar(Contrato, "pcInterMoraLetra", lnInterMoraLetras) ' % Interes Moratorio Letras
        '    BuscarYReemplzar(Contrato, "pcDestino", lcdestino) 'Destino del Credito
        '    BuscarYReemplzar(Contrato, "pcFuenteFondos", lcFuenteFondos) ' % Fondos del Credito
        '    BuscarYReemplzar(Contrato, "pcFormadePago", lnFormadePago) ' % Forma de Pago


        '    '---Fecha Vencimiento Credito
        '    BuscarYReemplzar(Contrato, "pcdiaven", Num2Text(lndiaven)) 'Dia de Vencimiento 
        '    BuscarYReemplzar(Contrato, "pcmesven", lcmesven.Trim.ToUpper) 'Mes de Vencimiento
        '    BuscarYReemplzar(Contrato, "pcanoven", Num2Text(lnanoven)) 'Año de Vencimiento
        '    BuscarYReemplzar(Contrato, "lcvencimiento", lcvencimiento) 'Fecha de Vencimiento en Letras


        '    BuscarYReemplzar(Contrato, "pcmonsug", clase.Cominola(lnmonsug.ToString.Trim))
        '    'BuscarYReemplzar(Contrato, "pccuotas", lcplazo1.Trim)
        '    BuscarYReemplzar(Contrato, "CantCuotas", lcplazo) 'Cantidad Cuotas
        '    BuscarYReemplzar(Contrato, "MontoCuota", lccuota) 'Cuota en Letras
        '    BuscarYReemplzar(Contrato, "pccuota", clase.Cominola(lncuota.ToString.Trim))
        '    BuscarYReemplzar(Contrato, "pcmespri", lcmespri.Trim.ToUpper)
        '    BuscarYReemplzar(Contrato, "pcañocuopri", lcañocuopri.Trim)
        '    BuscarYReemplzar(Contrato, "pcañocuopri", Num2Text(lcañocuopri.Trim))

        '    BuscarYReemplzar(Contrato, "pcdia", Num2Text(lndia))
        '    BuscarYReemplzar(Contrato, "pcmes", lcmes.Trim.ToUpper)
        '    BuscarYReemplzar(Contrato, "pcano", Num2Text(lnano))

        '    BuscarYReemplzar(Contrato, "pcmunicipio", lcmunicipio.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento", lcdepartamento.Trim)
        '    BuscarYReemplzar(Contrato, "pcdui", lcdui.Trim)

        '    BuscarYReemplzar(Contrato, "pcmuniexp", lcmuniexp.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp", lcdepaexp.Trim)


        '    BuscarYReemplzar(Contrato, "DeptoOfi", DeptoOfi) 'Departamento donde se está imprimiendo del Contrato (usuario del sistema)
        '    BuscarYReemplzar(Contrato, "MuniOfi", MuniOfi) 'Municipio donde se está imprimiendo del Contrato (usuario del sistema)
        '    BuscarYReemplzar(Contrato, "DiaImpr", Num2Text(Now.Day)) 'Dia de Impresion
        '    BuscarYReemplzar(Contrato, "MesImpr", MonthName(Now.Month).ToUpper) 'Mes de Impresion
        '    BuscarYReemplzar(Contrato, "AñoImpr", Num2Text((Now.Year))) 'Año de Impresion


        '    '-----fiador 1
        '    BuscarYReemplzar(Contrato, "pcnomfia1", lcnombre1.Trim)
        '    BuscarYReemplzar(Contrato, "DirDomFia1", lcdirdom1.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento1", lcdepartamento1)
        '    BuscarYReemplzar(Contrato, "pcmunicipio1", lcmunicipio1)
        '    BuscarYReemplzar(Contrato, "lcdesduif1", lcdesduif1.Trim)
        '    BuscarYReemplzar(Contrato, "EDADF1", lcedad1.Trim)
        '    BuscarYReemplzar(Contrato, "fia1LetrasNIT", lcdesnitLetras1.Trim)
        '    BuscarYReemplzar(Contrato, "ProfFia1", lcprofesion1.Trim)
        '    BuscarYReemplzar(Contrato, "fianit1", lcfianitn1.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "pcfiadui1", lcfiaduin1.Trim)




        '    '-----fiador 2
        '    BuscarYReemplzar(Contrato, "pcnomfia2", lcnombre2.Trim)
        '    BuscarYReemplzar(Contrato, "DomFia2", lcdirdom2.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento2", lcdepartamento2)
        '    BuscarYReemplzar(Contrato, "pcmunicipio2", lcmunicipio2)
        '    BuscarYReemplzar(Contrato, "APedad2", lcedad2.Trim)
        '    BuscarYReemplzar(Contrato, "ArpNitLef2", lcdesnitLetras2.Trim)
        '    BuscarYReemplzar(Contrato, "fianit2", lcfianitn2.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "pcfiadui2", lcfiaduin2.Trim)
        '    BuscarYReemplzar(Contrato, "lcdesduif2", lcdesduif2.Trim)
        '    BuscarYReemplzar(Contrato, "lapro2", lcprofesion2.Trim)


        '    BuscarYReemplzar(Contrato, "pcmuniexp1", lcmuniexp1.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp1", lcdepaexp1.Trim)
        '    BuscarYReemplzar(Contrato, "pcmuniexp2", lcmuniexp2.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp2", lcdepaexp2.Trim)

        '    BuscarYReemplzar(Contrato, "pcprofesion", lcprofesion)
        '    BuscarYReemplzar(Contrato, "pccuosug", lccuosug)

        '    '----Fiador 3
        '    BuscarYReemplzar(Contrato, "pcnomfia3", lcnombre3.Trim)
        '    BuscarYReemplzar(Contrato, "domfia3", lcdirdom3.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento3", lcdepartamento3)
        '    BuscarYReemplzar(Contrato, "pcmunicipio3", lcmunicipio3)
        '    BuscarYReemplzar(Contrato, "pcdui3", lcdui3.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp3", lcdepaexp3.Trim)
        '    BuscarYReemplzar(Contrato, "fianit3", lcfianitn3.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "pcfiadui3", lcfiaduin3.Trim)
        '    BuscarYReemplzar(Contrato, "f3EdAd", lcedad3.Trim)
        '    BuscarYReemplzar(Contrato, "lcdesduif3", lcdesduif3.Trim)
        '    BuscarYReemplzar(Contrato, "fiaLNIT3", lcdesnitLetras3.Trim)
        '    BuscarYReemplzar(Contrato, "profe", lcprofesion3.Trim)


        '    '-----Garantia Prendaria
        '    BuscarYReemplzar(Contrato, "valpericiaLetras", valpericiaLetras)
        '    BuscarYReemplzar(Contrato, "GarPrenDescri", GarPrenDescri)


        '    '----Descargar el Archivo

        '    Dim filename As String = Contrato

        '    If filename <> "" Then
        '        'Dim path As String = Server.MapPath(filename)
        '        Dim path As String = filename
        '        Dim file As New System.IO.FileInfo(path)

        '        If file.Exists Then
        '            Response.Clear()
        '            Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
        '            Response.AddHeader("Content-Length", file.Length.ToString())
        '            'Response.ContentType = "application/octet-stream"
        '            Response.ContentType = "application/msword"
        '            Response.WriteFile(file.FullName)
        '            Response.End()
        '        Else
        '            Response.Write("El Archivo no Existe")
        '        End If
        '    End If


        '    '|------------------------------------------------------------------|
        '    '|---------------------Fin------------------------------------------|
        '    '|------------------------------------------------------------------|

        'End Sub

        'Private Sub ContratosWord(ByVal Contrato As String)
        '    Dim input As String = ""
        '    Dim lcnomcli As String = ""
        '    Dim lcnombar As String = ""
        '    Dim lcnombre As String = ""

        '    lcnombre = Me.txtcnomcli.Text.Trim
        '    'lee un archivo de texto


        '    Dim lccodcli As String = ""
        '    Dim lnmonsug As Double = 0
        '    Dim lncuosug As Double = 0
        '    Dim lcmonto As String = ""
        '    Dim lnentero As Double = 0
        '    Dim lndeci As Double = 0
        '    Dim lccuosug As String = ""
        '    Dim etabttab As New tabttab
        '    Dim mtabttab As New cTabttab
        '    Dim ecremcre As New cremcre
        '    Dim mcremcre As New cCremcre
        '    Dim ecredtpl As New credtpl
        '    Dim mcredtpl As New cCredtpl

        '    Dim lcdestino As String = ""
        '    Dim lcFuenteFondos As String = ""
        '    Dim lncuota As Double = 0
        '    Dim lccuota As String = ""
        '    Dim lcfecha As String = ""
        '    Dim ldfecha As Date = Nothing

        '    Dim lnmes As Integer = 0
        '    Dim lndia As Integer = 0
        '    Dim lnano As Integer = 0
        '    Dim lcmes As String = ""
        '    Dim lccodpro As String = ""


        '    Dim lnmesven As Integer = 0
        '    Dim lndiaven As Integer = 0
        '    Dim lnanoven As Integer = 0
        '    Dim lcmesven As String = ""


        '    Dim mclimide As New cClimide
        '    Dim eclimide As New climide
        '    Dim etabtprf As New tabtprf
        '    Dim mtabtprf As New cTabtprf



        '    Dim lcprofesion As String = ""
        '    Dim lcdirdom As String = ""
        '    Dim lcedad As String = ""
        '    Dim lcdui As String = ""
        '    Dim lcdesdui As String = ""
        '    Dim lntam As Integer = 0
        '    Dim i As Integer
        '    Dim lcdesdui1 As String = ""
        '    Dim lcdesdui2 As String = ""
        '    Dim lcultimo As String = ""
        '    Dim lcprimero As String = ""
        '    Dim lcnit As String = ""
        '    Dim lcnitn As String = ""
        '    Dim lcdesnit As String = ""
        '    Dim lcdesnit2 As String = ""
        '    Dim lcdesnit3 As String = ""
        '    Dim ldvencimiento As Date = Nothing
        '    Dim lcvencimiento As String = ""
        '    Dim lcmonpre As String = ""
        '    Dim lccoddom As String = ""
        '    '>>>>>>>>>>>>>>>>>>>>>>>
        '    Dim lcplazo1 As String = ""

        '    Dim lctiper As String = ""
        '    Dim lndia1 As Integer = 0
        '    Dim lnnumcuo As Integer = 0
        '    Dim lcforma As String = ""
        '    Dim ldfecvig As Date = Nothing
        '    Dim ldfecven As Date = Nothing
        '    Dim lnmeses As Integer = 0
        '    Dim lcmeses As String = ""
        '    Dim lnInterMora As Double = 0
        '    Dim lnInterMoraLetras As String = ""

        '    Dim lnFormadePago As String = ""
        '    Dim fechacuopri As String = ""

        '    Dim HoraImp As String
        '    Dim MinImp As String
        '    Dim HoraMinImp As String
        '    Dim DiaImp As String
        '    Dim MesImp As String
        '    Dim YearImip As String

        '    Dim HoraFechaImp As String
        '    Dim lcncuenta As String


        '    ecremcre.ccodcta = Me.txtccodcta.Text.Trim
        '    mcremcre.ObtenerCremcre(ecremcre)

        '    ldfecvig = ecremcre.dfecvig
        '    ldfecven = ecremcre.dfecven
        '    lnmeses = DateDiff(DateInterval.Month, ldfecvig, ldfecven)




        '    HoraImp = Num2Text(Now.Hour).ToLower
        '    MinImp = Num2Text(Now.Minute).ToLower

        '    HoraMinImp = HoraImp + " horas con " + MinImp + " minutos"

        '    DiaImp = Num2Text(Now.Day).ToLower
        '    MesImp = MonthName(Now.Month)
        '    YearImip = Num2Text(Now.Year).ToLower

        '    HoraFechaImp = HoraMinImp + " del día " + DiaImp + " de " + MesImp + " del año " + YearImip

        '    lnInterMora = mcremcre.InteresMoratorio(Me.txtccodcta.Text.Trim)

        '    lnInterMoraLetras = Num2Text(lnInterMora)


        '    'Destino del credito
        '    lcdestino = mcremcre.DestinoCredito(Me.txtccodcta.Text.Trim)

        '    'Forma de pago (Mensual, Trimestral, etc
        '    lnFormadePago = mcremcre.FormadePago(Me.txtccodcta.Text.Trim)


        '    lcmeses = Num2Text(lnmeses)


        '    Dim lcdiapago As String = ""


        '    lctiper = ecremcre.ctipper

        '    lndia1 = ecremcre.ndiasug
        '    lnnumcuo = ecremcre.ncuosug
        '    lcforma = clase.formapago2(lctiper, lndia1)

        '    lcdiapago = Num2Text(lndia1)


        '    Dim lctasalet As String = ""
        '    Dim lnenter As Double
        '    Dim lndecimal As Double
        '    Dim lnTasa As Double
        '    'lctasalet = Num2Text(ecremcre.ntasint)

        '    lnenter = Decimal.Floor(ecremcre.ntasint)
        '    lndecimal = Math.Round((ecremcre.ntasint - lnenter) * 100)
        '    If lndecimal > 0 Then
        '        lctasalet = Num2Text(lnenter) & " PUNTO " & Num2Text(lndecimal)
        '        lnTasa = Num2Text(lnenter) & " PUNTO " & Num2Text(lndecimal)
        '    Else
        '        lctasalet = Num2Text(lnenter)
        '        lnTasa = lnenter
        '    End If


        '    '<<<<<<<<<<<<<<<<<<<<<<<
        '    Dim etabtzon As New tabtzon
        '    Dim mtabtzon As New cTabtzon
        '    Dim lcmunicipio As String = ""
        '    Dim lcdepartamento As String = ""
        '    Dim lcplazo As String = ""
        '    Dim lcdias As String = ""
        '    Dim lccredito As String = ""
        '    Dim lclugexp As String = ""

        '    eclimide.ccodcli = ecremcre.ccodcli


        '    lcnomcli = Me.txtcnomcli.Text.Trim
        '    lccodcli = Me.txtccodcli.Text.Trim
        '    lnmonsug = ecremcre.nmonapr
        '    lncuosug = ecremcre.ncuosug
        '    lcmonpre = ecremcre.nmonapr

        '    lnentero = Decimal.Floor(lnmonsug)
        '    lndeci = Math.Round((lnmonsug - lnentero) * 100)
        '    If lndeci > 0 Then
        '        lcmonto = Num2Text(lnentero) & " DOLARES " & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
        '    Else
        '        lcmonto = Num2Text(lnentero) & " DOLARES CON CERO CENTAVOS " 'monto en letras
        '    End If

        '    lccuosug = Num2Text(lncuosug)  'cuotas en letras
        '    lcplazo = Num2Text(lncuosug) ' " CUOTAS "
        '    'lcplazo1 = Num2Text(lncuosug - 1)




        '    lccodcli = ecremcre.ccodcli
        '    lccredito = Me.txtccodcta.Text.Trim

        '    etabttab.ccodtab = "033"
        '    etabttab.ctipreg = "1"
        '    etabttab.ccodigo = ecremcre.ccodfue.Trim
        '    mtabttab.ObtenerTabttab(etabttab)

        '    'lcdestino = etabttab.cdescri.Trim  'destino del credito

        '    lcFuenteFondos = etabttab.cdescri.Trim


        '    ecredtpl.ccodcta = Me.txtccodcta.Text.Trim
        '    ecredtpl.ctipope = "N"
        '    ecredtpl.cnrocuo = "001"
        '    mcredtpl.ObtenerCredtpl(ecredtpl)
        '    clase.gnperbas = Session("gnperbas")
        '    clase.pnComtra = Session("gnComTra")
        '    clase.pnSegVm = Session("gnSegVm1")

        '    Dim ldpricuo As Date = Nothing
        '    Dim lcmespri As String = ""
        '    Dim lcañocuopri As String = ""

        '    ldpricuo = ecredtpl.dfecven
        '    lcmespri = MonthName(ldpricuo.Month)
        '    lcañocuopri = ldpricuo.Year.ToString.Trim


        '    fechacuopri = Num2Text(ldfecvig.Day).ToUpper & " DE " & MonthName(ldfecvig.Month).ToUpper & " DE " & Num2Text(ldfecvig.Year).ToUpper



        '    lncuota = ecremcre.nmoncuo

        '    lnentero = Decimal.Floor(lncuota)
        '    lndeci = Math.Round((lncuota - lnentero) * 100)
        '    If lndeci > 0 Then
        '        lccuota = Num2Text(lnentero) & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
        '    Else
        '        lccuota = Num2Text(lnentero) 'monto en letras
        '    End If

        '    'fecha desembolso
        '    ldfecha = Date.Parse(ecremcre.dfecapr)
        '    lnmes = ldfecha.Month
        '    lndia = ldfecha.Day
        '    lnano = ldfecha.Year
        '    lcmes = MonthName(lnmes)
        '    lcfecha = Num2Text(lndia) & " DIAS DEL MES DE " & lcmes & " DE " & Num2Text(lnano)
        '    lcfecha = lcfecha.ToUpper
        '    lcdias = Num2Text(lndia)

        '    ''obtiene fecha de vencimiento
        '    ldvencimiento = Date.Parse(ecremcre.dfecven)
        '    lnmesven = ldvencimiento.Month
        '    lndiaven = (ldvencimiento.Day)
        '    lnanoven = ldvencimiento.Year
        '    lcmesven = MonthName(lnmesven)
        '    lcvencimiento = Num2Text(lndiaven) & " DEL MES DE " & lcmesven & " DE " & Num2Text(lnanoven)
        '    lcvencimiento = lcvencimiento.ToUpper


        '    'obtiene datos del cliente
        '    eclimide.ccodcli = lccodcli
        '    mclimide.ObtenerClimide(eclimide)
        '    lcdirdom = eclimide.cdirdom
        '    lcdui = eclimide.cnudoci.Trim
        '    lclugexp = eclimide.cLugExp.Trim
        '    'lcdui = lcdui.Replace("-", "")
        '    lcnit = Replace(eclimide.cnudotr.Trim, "-", "")
        '    lcnitn = eclimide.cnudotr.Trim  '????????????????????????????????????????????????????????????????????????
        '    lcncuenta = ecremcre.ccodcta.Trim
        '    lccoddom = eclimide.ccoddom.Trim

        '    lccodpro = eclimide.ccodpro



        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    'obtiene municipio y departamento expedicion


        '    Dim lcmuniexp As String = ""
        '    Dim lcdepaexp As String = ""

        '    Dim lclugexp1 As String = ""
        '    Dim lclugexp2 As String = ""
        '    Dim lclugexp3 As String = ""

        '    Dim lcmuniexp1 As String = ""
        '    Dim lcmuniexp2 As String = ""
        '    Dim lcmuniexp3 As String = ""

        '    Dim lcdepaexp1 As String = ""
        '    Dim lcdepaexp2 As String = ""
        '    Dim lcdepaexp3 As String = ""
        '    Dim lnedad As Double = 0

        '    If lclugexp.Trim = "" Then
        '    Else

        '        etabtzon.ccodzon = lclugexp
        '        etabtzon.ctipzon = "2"
        '        mtabtzon.ObtenerTabtzon(etabtzon)
        '        lcmuniexp = etabtzon.cdeszon.Trim
        '        lcmuniexp = lcmuniexp.ToUpper
        '        'departamento
        '        etabtzon.ccodzon = lclugexp.Substring(0, 2)
        '        etabtzon.ctipzon = "1"
        '        mtabtzon.ObtenerTabtzon(etabtzon)
        '        lcdepaexp = etabtzon.cdeszon.Trim
        '        lcdepaexp = lcdepaexp.ToUpper

        '    End If



        '    etabtprf.ccodigo = lccodpro
        '    mtabtprf.ObtenerTabtprf(etabtprf)
        '    lcprofesion = etabtprf.cdescri.Trim  ' profesion
        '    'If eclimide.dnacimi <> Nothing Then
        '    lnedad = clase.CalculaEdad(eclimide.dnacimi)
        '    lcedad = Num2Text(IIf(lnedad < 0, 1, lnedad))
        '    lcedad = lcedad.ToLower
        '    'End If
        '    'detalla el dui en letras

        '    If lcdui.Trim.Length = 10 Then
        '        '            lcdesdui = Me.Duiletras(lcdui)

        '        'lcdui = lcdui.Replace("-", "")
        '        lcdesdui = cDUI(lcdui)
        '        lcdesdui = lcdesdui.Trim.ToUpper
        '    Else
        '        lcdesdui = ""
        '    End If




        '    'detalla el nit
        '    lntam = lcnit.Length
        '    lcdesnit = ""
        '    If lntam <> 14 Then
        '        lcdesnit = ""
        '        '    '            Response.Write("<script language='javascript'>alert('Nit del cliente no posee 14 caracteres')</script>")
        '    Else
        '        lcdesnit2 = lcnit.Substring(0, 4)
        '        lcdesnit = Num2Text(Integer.Parse(lcdesnit2))

        '        If lcnit.Substring(0, 3) = "000" Then
        '            lcdesnit = "CERO CERO CERO " & lcdesnit
        '        ElseIf lcnit.Substring(0, 2) = "00" Then
        '            lcdesnit = "CERO CERO " & lcdesnit
        '        ElseIf lcnit.Substring(0, 1) = "0" Then
        '            lcdesnit = "CERO " & lcdesnit
        '        End If

        '        lcdesnit2 = lcnit.Substring(4, 6)
        '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))

        '        lcdesnit2 = lcnit.Substring(10, 3)

        '        If lcnit.Substring(10, 2) = "00" Then
        '            lcdesnit = lcdesnit & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit2))
        '        ElseIf lcnit.Substring(10, 1) = "0" Then
        '            lcdesnit = lcdesnit & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit2))
        '        Else
        '            lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))
        '        End If


        '        lcdesnit2 = lcnit.Substring(lntam - 1, 1)
        '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))
        '        lcdesnit = lcdesnit.ToUpper
        '        'lcnit = lcnit.Replace("-", "")
        '        'lcdesnit = cNIT(lcnit)
        '        'lcdesnit = lcdesnit.ToUpper()
        '    End If

        '    'obtiene municipio y departamento

        '    etabtzon.ccodzon = lccoddom
        '    etabtzon.ctipzon = "3"
        '    mtabtzon.ObtenerTabtzon(etabtzon)
        '    lcmunicipio = etabtzon.cdeszon.Trim
        '    lcmunicipio = lcmunicipio.ToUpper
        '    'departamento
        '    etabtzon.ccodzon = lccoddom.Substring(0, 2)
        '    etabtzon.ctipzon = "1"
        '    mtabtzon.ObtenerTabtzon(etabtzon)
        '    lcdepartamento = etabtzon.cdeszon.Trim
        '    lcdepartamento = lcdepartamento.ToUpper


        '    '---Departamento y Municipio del Usuario del Sistema
        '    Dim eusuarios As New cusuarios
        '    Dim clsusuarios As New usuarios
        '    Dim etabtofi As New cTabtofi
        '    Dim clstabtofi As New tabtofi

        '    Dim ccodusu, ccodofi As String


        '    Dim DeptoOfi As String = ""
        '    Dim MuniOfi As String = ""



        '    clsusuarios.usuario = txtCodUsu.Text.Trim.ToUpper 'Session("gcCodusu").ToString.ToUpper

        '    eusuarios.RecuperarUsuario(clsusuarios)

        '    With clsusuarios
        '        ccodusu = .usuario
        '        ccodofi = .ccodofi
        '    End With

        '    clstabtofi.ccodofi = ccodofi

        '    etabtofi.ObtenerTabtofi(clstabtofi)

        '    With clstabtofi
        '        DeptoOfi = .cdepa.Trim
        '        MuniOfi = .cmuni.Trim
        '    End With



        '    '**************************obtiene datos del fiador******************

        '    Dim eclimgar As New climgar
        '    Dim mclimgar As New cClimgar
        '    Dim lccoduni As String = ""
        '    Dim lcnombre1 As String = ""
        '    Dim lcnit1 As String = ""
        '    Dim lcdui1 As String = ""
        '    Dim lcfiaduin1 As String = ""
        '    Dim lcfianitn1 As String = ""
        '    Dim lcfiaduin2 As String = ""
        '    Dim lcfianitn2 As String = ""
        '    Dim lcfiaduin3 As String = ""
        '    Dim lcfianitn3 As String = ""

        '    Dim lccodpro1 As String = ""
        '    Dim ldnacimi1 As Date = Nothing
        '    Dim lcdesnit1f As String = ""
        '    Dim lcdesnit2f As String = ""
        '    Dim lcdesnit3f As String = ""
        '    Dim lcdesnitf As String = ""
        '    Dim lcdesnitLetras1 As String = ""
        '    Dim lcdesnitLetras2 As String = ""
        '    Dim lcdesnitLetras3 As String = ""
        '    Dim lcdesduif As String = ""
        '    Dim lcdesdui2f As String = ""
        '    Dim lcprofesion1 As String = ""
        '    Dim lcedad1 As String = ""
        '    Dim lnedad1 As Double = 0
        '    Dim lccoddom1 As String = ""
        '    Dim lcmunicipio1 As String = ""
        '    Dim lcdepartamento1 As String = ""
        '    Dim lcdesduif1 As String = ""
        '    'Para fiador 2
        '    Dim lcnombre2 As String = ""
        '    Dim lcedad2 As String = ""
        '    Dim lcprofesion2 As String = ""
        '    Dim lcmunicipio2 As String = ""
        '    Dim lcdepartamento2 As String = ""
        '    Dim lcdesduif2 As String = ""

        '    Dim lcnit2 As String = ""
        '    Dim lcdui2 As String = ""
        '    Dim lccodpro2 As String = ""
        '    Dim ldnacimi2 As Date = Nothing
        '    Dim lccoddom2 As String = ""

        '    'Para fiador 3
        '    Dim lcnombre3 As String = ""
        '    Dim lcedad3 As String = ""
        '    Dim lcprofesion3 As String = ""
        '    Dim lcmunicipio3 As String = ""
        '    Dim lcdepartamento3 As String = ""
        '    Dim lcdesduif3 As String = ""

        '    Dim lcnit3 As String = ""
        '    Dim lcdui3 As String = ""
        '    Dim lccodpro3 As String = ""
        '    Dim ldnacimi3 As Date = Nothing
        '    Dim lccoddom3 As String = ""
        '    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        '    Dim lcdirdom1 As String = ""
        '    Dim lcdirdom2 As String = ""
        '    Dim lcdirdom3 As String = ""

        '    Dim lnfia As Integer = 0

        '    lccoduni = "**"
        '    eclimgar.ccodcli = lccodcli

        '    Dim ds As New DataSet
        '    'ds = mclimgar.ObtenerDataSetPor_Garantia_Cliente(lccodcli)
        '    ds = mclimgar.Datos_Fiadores(Me.txtccodcta.Text.Trim)
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Dim fila As DataRow
        '        Dim ele As Integer = 0
        '        For Each fila In ds.Tables(0).Rows
        '            lnfia += 1
        '            If lnfia = 1 Then

        '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
        '                eclimide.ccodcli = lccoduni
        '                mclimide.ObtenerClimide(eclimide)
        '                lcnombre1 = eclimide.cnomcli.Trim
        '                lcnit1 = Replace(eclimide.cnudotr.Trim, "-", "")
        '                lcdui1 = eclimide.cnudoci.Trim
        '                'lcdui1 = lcdui1.Replace("-", "")
        '                lccodpro1 = eclimide.ccodpro.Trim
        '                ldnacimi1 = eclimide.dnacimi
        '                lccoddom1 = eclimide.ccoddom.Trim
        '                lcdirdom1 = eclimide.cdirdom.Trim
        '                lcfianitn1 = eclimide.cnudotr.Trim
        '                lcfiaduin1 = eclimide.cnudoci.Trim

        '                lclugexp1 = eclimide.cLugExp.Trim
        '                If lclugexp1.Trim = "" Then
        '                Else



        '                    etabtzon.ccodzon = lclugexp1
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmuniexp1 = etabtzon.cdeszon.Trim
        '                    lcmuniexp1 = lcmuniexp1.ToUpper
        '                    'departamento
        '                    etabtzon.ccodzon = lclugexp1.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepaexp1 = etabtzon.cdeszon.Trim
        '                    lcdepaexp1 = lcdepaexp1.ToUpper
        '                End If
        '                'detalla el nit

        '                ''''''''''''''''''''''''''''''''''

        '                lntam = lcnit1.Length
        '                If lntam <> 14 Then
        '                    lcdesnitLetras1 = ""
        '                    lcdesnit1f = ""
        '                    '                Response.Write("<script language='javascript'>alert('Nit del fiador no posee 17 caracteres')</script>")
        '                Else

        '                    lcdesnit1f = lcnit1.Substring(0, 4)
        '                    lcdesnitLetras1 = Num2Text(Integer.Parse(lcdesnit1f))


        '                    If lcnit1.Substring(0, 3) = "000" Then
        '                        lcdesnitLetras1 = "CERO CERO CERO " & lcdesnitLetras1
        '                    ElseIf lcnit1.Substring(0, 2) = "00" Then
        '                        lcdesnitLetras1 = "CERO CERO " & lcdesnitLetras1
        '                    ElseIf lcnit1.Substring(0, 1) = "0" Then
        '                        lcdesnitLetras1 = "CERO " & lcdesnitLetras1
        '                    End If


        '                    lcdesnit1f = lcnit1.Substring(4, 6)
        '                    lcdesnitLetras1 = lcdesnitLetras1 & " guión " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    lcdesnit1f = lcnit1.Substring(10, 3)

        '                    If lcnit1.Substring(10, 2) = "00" Then
        '                        lcdesnitLetras1 = lcdesnitLetras1 & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    ElseIf lcnit1.Substring(10, 1) = "0" Then
        '                        lcdesnitLetras1 = lcdesnitLetras1 & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    Else
        '                        lcdesnitLetras1 = lcdesnitLetras1 & " guión " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    End If


        '                    lcdesnit1f = lcnit1.Substring(lntam - 1, 1)
        '                    lcdesnitLetras1 = lcdesnitLetras1 & " guión " & Num2Text(Integer.Parse(lcdesnit1f))
        '                    lcdesnitLetras1 = lcdesnitLetras1.ToUpper
        '                    'lcnit1 = lcnit1.Replace("-", "")
        '                    'lcdesnitLetras1 = cNIT(lcnit1)
        '                    'lcdesnitLetras1.ToUpper()
        '                End If

        '                'detalla el dui en letras


        '                'lcdesduif1 = Me.Duiletras(lcdui1).ToUpper
        '                'lcdui1 = lcdui1.Replace("-", "")
        '                If lcdui1.Trim.Length = 10 Then
        '                    lcdesduif1 = cDUI(lcdui1)
        '                    lcdesduif1 = lcdesduif1.ToUpper
        '                Else
        '                    lcdesduif1 = ""
        '                End If



        '                'obtiene profesion
        '                etabtprf.ccodigo = lccodpro1
        '                mtabtprf.ObtenerTabtprf(etabtprf)
        '                lcprofesion1 = etabtprf.cdescri.Trim
        '                lcprofesion1 = lcprofesion1.ToUpper



        '                'obtiene edad
        '                lnedad1 = clase.CalculaEdad(ldnacimi1)


        '                lcedad1 = Num2Text(IIf(lnedad1 < 0, 1, lnedad1))
        '                lcedad1 = lcedad1.ToLower

        '                'domicilio
        '                'obtiene municipio y departamento
        '                If lccoddom1.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lccoddom1.Substring(0, 4)
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmunicipio1 = etabtzon.cdeszon.Trim
        '                    lcmunicipio1 = lcmunicipio1.ToUpper

        '                    'departamento
        '                    etabtzon.ccodzon = lccoddom1.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepartamento1 = etabtzon.cdeszon.Trim
        '                    lcdepartamento1 = lcdepartamento1.ToUpper
        '                End If
        '            End If
        '            'Segundo fiador >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        '            If lnfia = 2 Then
        '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
        '                eclimide.ccodcli = lccoduni
        '                mclimide.ObtenerClimide(eclimide)
        '                lcnombre2 = eclimide.cnomcli.Trim
        '                lcnit2 = Replace(eclimide.cnudotr.Trim, "-", "")
        '                'lcnit2 = eclimide.cnudotr.Trim
        '                lcdui2 = eclimide.cnudoci.Trim
        '                'lcdui2 = lcdui2.Replace("-", "")
        '                lccodpro2 = eclimide.ccodpro.Trim
        '                ldnacimi2 = eclimide.dnacimi
        '                lccoddom2 = eclimide.ccoddom.Trim
        '                lcdirdom2 = eclimide.cdirdom.Trim
        '                lcfianitn2 = eclimide.cnudotr.Trim
        '                lcfiaduin2 = eclimide.cnudoci.Trim

        '                lclugexp2 = eclimide.cLugExp.Trim

        '                If lclugexp2.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lclugexp2
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmuniexp2 = etabtzon.cdeszon.Trim
        '                    lcmuniexp2 = lcmuniexp2.ToUpper
        '                    'departamento
        '                    etabtzon.ccodzon = lclugexp2.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepaexp2 = etabtzon.cdeszon.Trim
        '                    lcdepaexp2 = lcdepaexp2.ToUpper
        '                End If
        '                'detalla el nit



        '                lntam = lcnit2.Length
        '                If lntam <> 14 Then
        '                    lcdesnit2f = ""
        '                    lcdesnitLetras2 = ""

        '                Else

        '                    lcdesnit2f = lcnit2.Substring(0, 4)
        '                    lcdesnitLetras2 = Num2Text(Integer.Parse(lcdesnit2f))

        '                    If lcnit2.Substring(0, 3) = "000" Then
        '                        lcdesnitLetras2 = "CERO CERO CERO " & lcdesnitLetras2
        '                    ElseIf lcnit2.Substring(0, 2) = "00" Then
        '                        lcdesnitLetras2 = "CERO CERO " & lcdesnitLetras2
        '                    ElseIf lcnit2.Substring(0, 1) = "0" Then
        '                        lcdesnitLetras2 = "CERO " & lcdesnitLetras2
        '                    End If


        '                    lcdesnit2f = lcnit2.Substring(4, 6)
        '                    lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    lcdesnit2f = lcnit2.Substring(10, 3)
        '                    'lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))

        '                    If lcnit2.Substring(10, 2) = "00" Then
        '                        lcdesnitLetras2 = lcdesnitLetras2 & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    ElseIf lcnit2.Substring(10, 1) = "0" Then
        '                        lcdesnitLetras2 = lcdesnitLetras2 & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    Else
        '                        lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    End If

        '                    lcdesnit2f = lcnit2.Substring(lntam - 1, 1)
        '                    lcdesnitLetras2 = lcdesnitLetras2 & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
        '                    lcdesnitLetras2 = lcdesnitLetras2.ToUpper
        '                    'lcnit2 = lcnit1.Replace("-", "")
        '                    'lcdesnitLetras2 = cNIT(lcnit2)
        '                    'lcdesnitLetras2.ToUpper()
        '                End If

        '                'detalla el dui en letras

        '                'lcdesduif2 = Me.Duiletras(lcdui2).ToUpper

        '                'lcdesduif2 = "" 'Me.Duiletras(lcdui2)
        '                'lcdui2 = lcdui1.Replace("-", "")

        '                If lcdui2.Trim.Length = 10 Then
        '                    lcdesduif2 = cDUI(lcdui2)
        '                    lcdesduif2 = lcdesduif2.ToUpper
        '                Else
        '                    lcdesduif2 = ""
        '                End If


        '                'obtiene profesion
        '                etabtprf.ccodigo = lccodpro2
        '                mtabtprf.ObtenerTabtprf(etabtprf)
        '                lcprofesion2 = etabtprf.cdescri.Trim
        '                lcprofesion2 = lcprofesion2.ToLower

        '                'obtiene edad
        '                lnedad1 = clase.CalculaEdad(ldnacimi2)
        '                'lcedad2 = Num2Text(lnedad1)
        '                lcedad2 = Num2Text(IIf(lnedad1 < 0, 1, lnedad1))
        '                lcedad2 = lcedad2.ToLower

        '                'domicilio
        '                'obtiene municipio y departamento

        '                If lccoddom2.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lccoddom2.Substring(0, 4)
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmunicipio2 = etabtzon.cdeszon.Trim
        '                    lcmunicipio2 = lcmunicipio2.ToUpper

        '                    'departamento
        '                    etabtzon.ccodzon = lccoddom2.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepartamento2 = etabtzon.cdeszon.Trim
        '                    lcdepartamento2 = lcdepartamento2.ToUpper
        '                End If
        '            Else
        '                'Manda en blanco Parametros
        '                'lcdesnitLetras2 = ""   me estaba mandando el campo vacio


        '            End If

        '            '---3er Fiador
        '            'Segundo fiador >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        '            If lnfia = 3 Then
        '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
        '                eclimide.ccodcli = lccoduni
        '                mclimide.ObtenerClimide(eclimide)
        '                lcnombre3 = eclimide.cnomcli.Trim
        '                lcnit3 = Replace(eclimide.cnudotr.Trim, "-", "")
        '                'lcnit3 = eclimide.cnudotr.Trim
        '                lcdui3 = eclimide.cnudoci.Trim
        '                'lcdui2 = lcdui2.Replace("-", "")
        '                lccodpro3 = eclimide.ccodpro.Trim
        '                ldnacimi3 = eclimide.dnacimi
        '                lccoddom3 = eclimide.ccoddom.Trim
        '                lcdirdom3 = eclimide.cdirdom.Trim
        '                lcfianitn3 = eclimide.cnudotr.Trim
        '                lcfiaduin3 = eclimide.cnudoci.Trim

        '                lclugexp3 = eclimide.cLugExp.Trim

        '                If lclugexp3.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lclugexp3
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmuniexp3 = etabtzon.cdeszon.Trim
        '                    lcmuniexp3 = lcmuniexp3.ToUpper
        '                    'departamento
        '                    etabtzon.ccodzon = lclugexp3.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepaexp3 = etabtzon.cdeszon.Trim
        '                    lcdepaexp3 = lcdepaexp3.ToUpper
        '                End If
        '                'detalla el nit
        '                lntam = lcnit3.Length
        '                If lntam <> 14 Then
        '                    lcdesnit3f = ""
        '                    lcdesnitLetras3 = ""

        '                Else

        '                    lcdesnit3f = lcnit3.Substring(0, 4)
        '                    lcdesnitLetras3 = Num2Text(Integer.Parse(lcdesnit3f))

        '                    If lcnit3.Substring(0, 3) = "000" Then
        '                        lcdesnitLetras3 = "CERO CERO CERO " & lcdesnitLetras3
        '                    ElseIf lcnit3.Substring(0, 2) = "00" Then
        '                        lcdesnitLetras3 = "CERO CERO " & lcdesnitLetras3
        '                    ElseIf lcnit3.Substring(0, 1) = "0" Then
        '                        lcdesnitLetras3 = "CERO " & lcdesnitLetras3
        '                    End If


        '                    lcdesnit3f = lcnit3.Substring(4, 6)
        '                    lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    lcdesnit3f = lcnit3.Substring(10, 3)
        '                    'lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))


        '                    If lcnit3.Substring(10, 2) = "00" Then
        '                        lcdesnitLetras3 = lcdesnitLetras3 & " GUION CERO CERO " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    ElseIf lcnit3.Substring(10, 1) = "0" Then
        '                        lcdesnitLetras3 = lcdesnitLetras3 & " GUION CERO " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    Else
        '                        lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    End If

        '                    lcdesnit3f = lcnit3.Substring(lntam - 1, 1)
        '                    lcdesnitLetras3 = lcdesnitLetras3 & " guión " & Num2Text(Integer.Parse(lcdesnit3f))
        '                    lcdesnitLetras3 = lcdesnitLetras3.ToUpper
        '                    'lcnit3 = lcnit3.Replace("-", "")
        '                    'lcdesnitLetras3 = cNIT(lcnit3)
        '                    'lcdesnitLetras3.ToUpper()
        '                End If

        '                'detalla el dui en letras


        '                'lcdesduif3 = Me.Duiletras(lcdui3).ToUpper
        '                'lcdui3 = lcdui3.Replace("-", "")

        '                'lcdesduif3 = "" 'Me.Duiletras(lcdui2)
        '                If lcdui3.Trim.Length = 10 Then
        '                    lcdesduif3 = cDUI(lcdui3)
        '                    lcdesduif3 = lcdesduif3.ToUpper
        '                Else
        '                    lcdesduif3 = ""
        '                End If


        '                'obtiene profesion
        '                etabtprf.ccodigo = lccodpro3
        '                mtabtprf.ObtenerTabtprf(etabtprf)
        '                lcprofesion3 = etabtprf.cdescri.Trim
        '                lcprofesion3 = lcprofesion3.ToLower

        '                'obtiene edad
        '                lnedad1 = clase.CalculaEdad(ldnacimi3)
        '                'lcedad3 = Num2Text(lnedad1)
        '                lcedad3 = Num2Text(IIf(lnedad1 < 0, 1, lnedad1))

        '                lcedad3 = lcedad3.ToLower

        '                'domicilio
        '                'obtiene municipio y departamento

        '                If lccoddom3.Trim = "" Then
        '                Else
        '                    etabtzon.ccodzon = lccoddom3.Substring(0, 4)
        '                    etabtzon.ctipzon = "2"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcmunicipio3 = etabtzon.cdeszon.Trim
        '                    lcmunicipio3 = lcmunicipio3.ToUpper

        '                    'departamento
        '                    etabtzon.ccodzon = lccoddom3.Substring(0, 2)
        '                    etabtzon.ctipzon = "1"
        '                    mtabtzon.ObtenerTabtzon(etabtzon)
        '                    lcdepartamento3 = etabtzon.cdeszon.Trim
        '                    lcdepartamento3 = lcdepartamento3.ToUpper
        '                End If
        '            Else
        '                lcdesnitLetras3 = ""
        '            End If
        '            ele += 1
        '        Next

        '    End If

        '    '------------Garantia Prendaria-----------------------
        '    Dim clsGarantPrenda As New SIM.BL.cGaran_prenda
        '    Dim eGarantPrenda As New SIM.EL.garan_prenda
        '    Dim dsGarantia As DataSet
        '    Dim valpericia As Double
        '    Dim valpericiaLetras As String
        '    Dim GarPrenDescri As String

        '    dsGarantia = clsGarantPrenda.ObtenerGarantiaPrendaria(Me.txtccodcta.Text.Trim)

        '    If dsGarantia.Tables(0).Rows.Count > 0 Then
        '        valpericia = IIf(IsDBNull(dsGarantia.Tables(0).Rows(0)("valpericia")), 0, dsGarantia.Tables(0).Rows(0)("valpericia"))
        '        GarPrenDescri = IIf(IsDBNull(dsGarantia.Tables(0).Rows(0)("descripcio")), "", dsGarantia.Tables(0).Rows(0)("descripcio"))
        '    End If

        '    lnentero = Decimal.Floor(valpericia)
        '    lndeci = Math.Round((valpericia - lnentero) * 100)
        '    If lndeci > 0 Then
        '        valpericiaLetras = Num2Text(lnentero) & " DOLARES " & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
        '    Else
        '        valpericiaLetras = Num2Text(lnentero) & " DOLARES CON CERO CENTAVOS " 'monto en letras
        '    End If


        '    '|-----------------------------------------------------------------|
        '    '|------Nueva Forma de Generar contratos usando OpenXML by HATA----|
        '    '|-----------------------------------------------------------------|

        '    'Dim DocSalida As String = Replace(Contrato, "C:\Contratos\Entrada", "C:\Contratos\Salida")

        '    'If System.IO.File.Exists(DocSalida) Then
        '    '    System.IO.File.Delete(DocSalida)
        '    '    File.Copy(Contrato, DocSalida)
        '    'Else
        '    '    File.Copy(Contrato, DocSalida)
        '    'End If



        '    '----Datos de Cliente
        '    BuscarYReemplzar(Contrato, "pcnomcli", txtcnomcli.Text.Trim) 'Nombre Cliente
        '    BuscarYReemplzar(Contrato, "ProfCliente", lcprofesion.Trim) 'Profesion segun DUI
        '    BuscarYReemplzar(Contrato, "pcedad", lcedad) 'Edad en letras
        '    BuscarYReemplzar(Contrato, "pcdesdui", lcdesdui) 'DUI en letras
        '    BuscarYReemplzar(Contrato, "pcdesnit", lcdesnit) 'NIT en letras
        '    BuscarYReemplzar(Contrato, "pcdirdom", lcdirdom.Trim) 'Domicilio cliente
        '    BuscarYReemplzar(Contrato, "pcmunicipio", lcmunicipio.Trim) 'Departamento
        '    BuscarYReemplzar(Contrato, "pcdepartamento", lcdepartamento.Trim) 'Municipio
        '    BuscarYReemplzar(Contrato, "HoraGen", HoraFechaImp) 'Hora de impresion
        '    BuscarYReemplzar(Contrato, "pcnit", lcnitn.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "lcnumcredito", lcncuenta.Trim) 'credito

        '    '----Credito
        '    BuscarYReemplzar(Contrato, "pcsumade", lcmonto.Trim) 'Monto del credito
        '    BuscarYReemplzar(Contrato, "pcmeses", lcmeses) 'Plazo en meses
        '    BuscarYReemplzar(Contrato, "pcdiapago", lcdiapago) 'Dia de pago
        '    BuscarYReemplzar(Contrato, "fechacuopri", fechacuopri) 'Fecha Primera Cuota
        '    BuscarYReemplzar(Contrato, "pctasalet", lctasalet) 'Tasa en letras
        '    BuscarYReemplzar(Contrato, "pcTasa", lnTasa) 'Tasa %
        '    BuscarYReemplzar(Contrato, "pcInterMora", lnInterMora) ' % Interes Moratorio
        '    BuscarYReemplzar(Contrato, "pcInterMoraLetra", lnInterMoraLetras) ' % Interes Moratorio Letras
        '    BuscarYReemplzar(Contrato, "pcDestino", lcdestino) 'Destino del Credito
        '    BuscarYReemplzar(Contrato, "pcFuenteFondos", lcFuenteFondos) ' % Fondos del Credito
        '    BuscarYReemplzar(Contrato, "pcFormadePago", lnFormadePago) ' % Forma de Pago


        '    '---Fecha Vencimiento Credito
        '    BuscarYReemplzar(Contrato, "pcdiaven", Num2Text(lndiaven)) 'Dia de Vencimiento 
        '    BuscarYReemplzar(Contrato, "pcmesven", lcmesven.Trim.ToUpper) 'Mes de Vencimiento
        '    BuscarYReemplzar(Contrato, "pcanoven", Num2Text(lnanoven)) 'Año de Vencimiento
        '    BuscarYReemplzar(Contrato, "lcvencimiento", lcvencimiento) 'Fecha de Vencimiento en Letras


        '    BuscarYReemplzar(Contrato, "pcmonsug", clase.Cominola(lnmonsug.ToString.Trim))
        '    'BuscarYReemplzar(Contrato, "pccuotas", lcplazo1.Trim)
        '    BuscarYReemplzar(Contrato, "CantCuotas", lcplazo) 'Cantidad Cuotas
        '    BuscarYReemplzar(Contrato, "MontoCuota", lccuota) 'Cuota en Letras
        '    BuscarYReemplzar(Contrato, "pccuota", clase.Cominola(lncuota.ToString.Trim))
        '    BuscarYReemplzar(Contrato, "pcmespri", lcmespri.Trim.ToUpper)
        '    BuscarYReemplzar(Contrato, "pcañocuopri", lcañocuopri.Trim)
        '    BuscarYReemplzar(Contrato, "pcañocuopri", Num2Text(lcañocuopri.Trim))

        '    BuscarYReemplzar(Contrato, "pcdia", Num2Text(lndia))
        '    BuscarYReemplzar(Contrato, "pcmes", lcmes.Trim.ToUpper)
        '    BuscarYReemplzar(Contrato, "pcano", Num2Text(lnano))

        '    BuscarYReemplzar(Contrato, "pcmunicipio", lcmunicipio.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento", lcdepartamento.Trim)
        '    BuscarYReemplzar(Contrato, "pcdui", lcdui.Trim)

        '    BuscarYReemplzar(Contrato, "pcmuniexp", lcmuniexp.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp", lcdepaexp.Trim)


        '    BuscarYReemplzar(Contrato, "DeptoOfi", DeptoOfi) 'Departamento donde se está imprimiendo del Contrato (usuario del sistema)
        '    BuscarYReemplzar(Contrato, "MuniOfi", MuniOfi) 'Municipio donde se está imprimiendo del Contrato (usuario del sistema)
        '    BuscarYReemplzar(Contrato, "DiaImpr", Num2Text(Now.Day)) 'Dia de Impresion
        '    BuscarYReemplzar(Contrato, "MesImpr", MonthName(Now.Month).ToUpper) 'Mes de Impresion
        '    BuscarYReemplzar(Contrato, "AñoImpr", Num2Text((Now.Year))) 'Año de Impresion


        '    '-----fiador 1
        '    BuscarYReemplzar(Contrato, "pcnomfia1", lcnombre1.Trim)
        '    BuscarYReemplzar(Contrato, "DirDomFia1", lcdirdom1.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento1", lcdepartamento1)
        '    BuscarYReemplzar(Contrato, "pcmunicipio1", lcmunicipio1)
        '    BuscarYReemplzar(Contrato, "lcdesduif1", lcdesduif1.Trim)
        '    BuscarYReemplzar(Contrato, "EDADF1", lcedad1.Trim)
        '    BuscarYReemplzar(Contrato, "fia1LetrasNIT", lcdesnitLetras1.Trim)
        '    BuscarYReemplzar(Contrato, "ProfFia1", lcprofesion1.Trim)
        '    BuscarYReemplzar(Contrato, "fianit1", lcfianitn1.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "pcfiadui1", lcfiaduin1.Trim)




        '    '-----fiador 2
        '    BuscarYReemplzar(Contrato, "pcnomfia2", lcnombre2.Trim)
        '    BuscarYReemplzar(Contrato, "DomFia2", lcdirdom2.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento2", lcdepartamento2)
        '    BuscarYReemplzar(Contrato, "pcmunicipio2", lcmunicipio2)
        '    BuscarYReemplzar(Contrato, "APedad2", lcedad2.Trim)
        '    BuscarYReemplzar(Contrato, "ArpNitLef2", lcdesnitLetras2.Trim)
        '    BuscarYReemplzar(Contrato, "fianit2", lcfianitn2.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "pcfiadui2", lcfiaduin2.Trim)
        '    BuscarYReemplzar(Contrato, "lcdesduif2", lcdesduif2.Trim)
        '    BuscarYReemplzar(Contrato, "lapro2", lcprofesion2.Trim)


        '    BuscarYReemplzar(Contrato, "pcmuniexp1", lcmuniexp1.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp1", lcdepaexp1.Trim)
        '    BuscarYReemplzar(Contrato, "pcmuniexp2", lcmuniexp2.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp2", lcdepaexp2.Trim)

        '    BuscarYReemplzar(Contrato, "pcprofesion", lcprofesion)
        '    BuscarYReemplzar(Contrato, "pccuosug", lccuosug)

        '    '----Fiador 3
        '    BuscarYReemplzar(Contrato, "pcnomfia3", lcnombre3.Trim)
        '    BuscarYReemplzar(Contrato, "domfia3", lcdirdom3.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepartamento3", lcdepartamento3)
        '    BuscarYReemplzar(Contrato, "pcmunicipio3", lcmunicipio3)
        '    BuscarYReemplzar(Contrato, "pcdui3", lcdui3.Trim)
        '    BuscarYReemplzar(Contrato, "pcdepaexp3", lcdepaexp3.Trim)
        '    BuscarYReemplzar(Contrato, "fianit3", lcfianitn3.Trim) ' nit en numero
        '    BuscarYReemplzar(Contrato, "pcfiadui3", lcfiaduin3.Trim)
        '    BuscarYReemplzar(Contrato, "f3EdAd", lcedad3.Trim)
        '    BuscarYReemplzar(Contrato, "lcdesduif3", lcdesduif3.Trim)
        '    BuscarYReemplzar(Contrato, "fiaLNIT3", lcdesnitLetras3.Trim)
        '    BuscarYReemplzar(Contrato, "profe", lcprofesion3.Trim)


        '    '-----Garantia Prendaria
        '    BuscarYReemplzar(Contrato, "valpericiaLetras", valpericiaLetras)
        '    BuscarYReemplzar(Contrato, "GarPrenDescri", GarPrenDescri)




        '|------------------------------------------------------------------|
        '|---------------------Fin------------------------------------------|
        '|------------------------------------------------------------------|

    End Sub



    Public Sub BuscarYReemplzar(ByVal document As String, ByVal Buscar As String, ByVal Reemplazar As String)
        Try
            Dim wordDoc As WordprocessingDocument = WordprocessingDocument.Open(document, True)
            Using (wordDoc)
                Dim docText As String = Nothing
                Dim sr As StreamReader = New StreamReader(wordDoc.MainDocumentPart.GetStream)

                Using (sr)
                    docText = sr.ReadToEnd
                End Using

                Dim regexText As Regex = New Regex(Buscar)
                docText = regexText.Replace(docText, Reemplazar)

                Dim sw As StreamWriter = New StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create))

                Using (sw)
                    sw.Write(docText)
                End Using
            End Using
        Catch
            Response.Write("<script language='javascript'>alert('Error al intentar acceder al Documento de Word')</script>")

        End Try
    End Sub



    Public Shared Function cDUI(ByVal cCadena As String) As String
        Dim cDUIDPFC As String = " "
        Dim Flag As Integer
        Dim nLargo As Integer = cCadena.Length

        For n As Integer = 0 To nLargo - 1

            If n <> 8 Then
                Flag = cCadena.Substring(n, 1)
            End If

            If n = 8 Then
                cDUIDPFC += " guion "
            Else
                Select Case Flag
                    Case 1
                        cDUIDPFC += "uno "
                    Case 2
                        cDUIDPFC += "dos "
                    Case 3
                        cDUIDPFC += "tres "
                    Case 4
                        cDUIDPFC += "cuatro "
                    Case 5
                        cDUIDPFC += "cinco "
                    Case 6
                        cDUIDPFC += "seis "
                    Case 7
                        cDUIDPFC += "siete "
                    Case 8
                        cDUIDPFC += "ocho "
                    Case 9
                        cDUIDPFC += "nueve "
                    Case 0
                        cDUIDPFC += "cero "
                End Select
            End If

        Next



        Return cDUIDPFC
    End Function


    Public Shared Function cNIT(ByVal cCadena As String) As String
        Dim cNITPFC As String = " "
        Dim Flag As Integer
        Dim nLargo As Integer = cCadena.Length

        For n As Integer = 0 To nLargo - 1
            Flag = cCadena.Substring(n, 1)
            Select Case n
                Case 4
                    cNITPFC += " guion "
                Case 10
                    cNITPFC += " guion "
                Case 13
                    cNITPFC += " guion "
            End Select
            Select Case Flag
                Case 1
                    cNITPFC += "uno "
                Case 2
                    cNITPFC += "dos "
                Case 3
                    cNITPFC += "tres "
                Case 4
                    cNITPFC += "cuatro "
                Case 5
                    cNITPFC += "cinco "
                Case 6
                    cNITPFC += "seis "
                Case 7
                    cNITPFC += "siete "
                Case 8
                    cNITPFC += "ocho "
                Case 9
                    cNITPFC += "nueve "
                Case 0
                    cNITPFC += "cero "
            End Select
        Next
        Return cNITPFC
    End Function

#End Region
    '******************************************************************************************
#Region "Contratos Forma Anterior"
    'Private _objWordApplication As Word.Application
    'Private _objWordDocument As Word.Document
    'Private oMissing As [Object] = System.Reflection.Missing.Value

    '    Try

    '        _objWordApplication = New AppWord.Application
    '        _objWordDocument = _objWordApplication.Documents.Open(Server.MapPath("\Contratos\Plantillas\" & Contrato & " "), False, False, False, oMissing, oMissing, oMissing, oMissing)
    '        '_objWordDocument = _objWordApplication.Documents.Open(Server.MapPath("Documentos\Creditos") + "\" + _filename + ".Docx", False, False, False, oMissing, oMissing, _
    '        '_objWordDocument = _objWordApplication.Documents.Open(("C:\Contratos\Plantillas\CONTRATO FIDUCIARIO CON FIRMAS.docx"), False, False, False, oMissing, oMissing, _
    '        '_objWordDocument = _objWordApplication.Documents.Open(("C:\Contratos\Plantillas\" & Contrato & " "), False, False, False, oMissing, oMissing, _
    '        'oMissing, oMissing)
    '        _objWordApplication.Visible = True

    '        '-------------------------------------------------------------
    '        '------Busca y Reemplaza dentro del documento de word---------
    '        '-------------------------------------------------------------       
    '        BuscarYReemplzar("pcnomcli", txtcnomcli.Text.Trim) 'Nombre Cliente
    '        BuscarYReemplzar("ProfCliente", lcprofesion.Trim) 'Profesion segun DUI
    '        BuscarYReemplzar("pcedad", lcedad) 'Edad en letras
    '        BuscarYReemplzar("pcdesdui", lcdesdui) 'DUI en letras
    '        BuscarYReemplzar("pcdesnit", lcdesnit) 'NIT en letras
    '        BuscarYReemplzar("pcdirdom", lcdirdom.Trim) 'Domicilio cliente
    '        BuscarYReemplzar("pcmunicipio", lcmunicipio.Trim) 'Departamento
    '        BuscarYReemplzar("pcdepartamento", lcdepartamento.Trim) 'Municipio

    '        '----Credito
    '        BuscarYReemplzar("pcsumade", lcmonto.Trim) 'Monto del credito
    '        BuscarYReemplzar("pcmeses", lcmeses) 'Plazo en meses
    '        BuscarYReemplzar("pcdiapago", lcdiapago) 'Dia de pago
    '        BuscarYReemplzar("fechacuopri", fechacuopri) 'Fecha Primera Cuota
    '        BuscarYReemplzar("pctasalet", lctasalet) 'Tasa en letras
    '        BuscarYReemplzar("pcTasa", lnTasa) 'Tasa %
    '        BuscarYReemplzar("pcInterMora", lnInterMora) ' % Interes Moratorio
    '        BuscarYReemplzar("pcInterMoraLetra", lnInterMoraLetras) ' % Interes Moratorio Letras
    '        BuscarYReemplzar("pcDestino", lcdestino) 'Destino del Credito
    '        BuscarYReemplzar("pcFuenteFondos", lcFuenteFondos) ' % Fondos del Credito
    '        BuscarYReemplzar("pcFormadePago", lnFormadePago) ' % Forma de Pago


    '        '---Fecha Vencimiento Credito
    '        BuscarYReemplzar("pcdiaven", Num2Text(lndiaven)) 'Dia de Vencimiento 
    '        BuscarYReemplzar("pcmesven", lcmesven.Trim.ToUpper) 'Mes de Vencimiento
    '        BuscarYReemplzar("pcanoven", Num2Text(lnanoven)) 'Año de Vencimiento
    '        BuscarYReemplzar("lcvencimiento", lcvencimiento) 'Fecha de Vencimiento en Letras


    '        BuscarYReemplzar("pcmonsug", clase.Cominola(lnmonsug.ToString.Trim))
    '        'BuscarYReemplzar("pccuotas", lcplazo1.Trim)
    '        BuscarYReemplzar("pccuotas", lcplazo.Trim) 'Plazo de cuotas
    '        BuscarYReemplzar("pcmoncuo", lccuota.Trim) 'Cuota en Letras
    '        BuscarYReemplzar("pccuota", clase.Cominola(lncuota.ToString.Trim))
    '        BuscarYReemplzar("pcmespri", lcmespri.Trim.ToUpper)
    '        BuscarYReemplzar("pcañocuopri", lcañocuopri.Trim)
    '        BuscarYReemplzar("pcañocuopri", Num2Text(lcañocuopri.Trim))

    '        BuscarYReemplzar("pcdia", Num2Text(lndia))
    '        BuscarYReemplzar("pcmes", lcmes.Trim.ToUpper)
    '        BuscarYReemplzar("pcano", Num2Text(lnano))

    '        BuscarYReemplzar("pcmunicipio", lcmunicipio.Trim)
    '        BuscarYReemplzar("pcdepartamento", lcdepartamento.Trim)
    '        BuscarYReemplzar("pcdui", lcdui.Trim)

    '        BuscarYReemplzar("pcmuniexp", lcmuniexp.Trim)
    '        BuscarYReemplzar("pcdepaexp", lcdepaexp.Trim)


    '        BuscarYReemplzar("DeptoOfi", DeptoOfi) 'Departamento donde se está imprimiendo del Contrato (usuario del sistema)
    '        BuscarYReemplzar("MuniOfi", MuniOfi) 'Municipio donde se está imprimiendo del Contrato (usuario del sistema)
    '        BuscarYReemplzar("DiaImpr", Num2Text(Now.Day)) 'Dia de Impresion
    '        BuscarYReemplzar("MesImpr", MonthName(Now.Month).ToUpper) 'Mes de Impresion
    '        BuscarYReemplzar("AñoImpr", Num2Text((Now.Year))) 'Año de Impresion


    '        'fiador 1
    '        BuscarYReemplzar("pcnomfia1", lcnombre1.Trim)
    '        BuscarYReemplzar("pcdirdom1", lcdirdom1.Trim)
    '        BuscarYReemplzar("pcdepartamento1", lcdepartamento1)
    '        BuscarYReemplzar("pcmunicipio1", lcmunicipio1)
    '        BuscarYReemplzar("lcdesduif1", lcdesduif1.Trim)
    '        BuscarYReemplzar("edadfiapc", lcedad1.Trim)
    '        BuscarYReemplzar("fia1LetrasNIT", lcdesnitLetras1.Trim)
    '        BuscarYReemplzar("ProfFia1", lcprofesion1.Trim)


    '        'fiador 2
    '        BuscarYReemplzar("pcnomfia2", lcnombre2.Trim)
    '        BuscarYReemplzar("pcdirdom2", lcdirdom2.Trim)
    '        BuscarYReemplzar("pcdepartamento2", lcdepartamento2)
    '        BuscarYReemplzar("pcmunicipio2", lcmunicipio2)
    '        BuscarYReemplzar("pcdui2", lcdui2.Trim)
    '        BuscarYReemplzar("pcedad2", lcedad2.Trim)
    '        BuscarYReemplzar("pcdesnitLetras2", lcdesnitLetras2.Trim)

    '        BuscarYReemplzar("pcmuniexp1", lcmuniexp1.Trim)
    '        BuscarYReemplzar("pcdepaexp1", lcdepaexp1.Trim)
    '        BuscarYReemplzar("pcmuniexp2", lcmuniexp2.Trim)
    '        BuscarYReemplzar("pcdepaexp2", lcdepaexp2.Trim)

    '        BuscarYReemplzar("pcprofesion", lcprofesion)
    '        BuscarYReemplzar("pccuosug", lccuosug)

    '        '----Fiador 3
    '        BuscarYReemplzar("pcnomfia3", lcnombre3.Trim)
    '        BuscarYReemplzar("pcdirdom3", lcdirdom3.Trim)
    '        BuscarYReemplzar("pcdepartamento3", lcdepartamento3)
    '        BuscarYReemplzar("pcmunicipio3", lcmunicipio3)
    '        BuscarYReemplzar("pcdui3", lcdui3.Trim)
    '        BuscarYReemplzar("pcdepaexp3", lcdepaexp2.Trim)
    '        BuscarYReemplzar("pcdesnitLetras3", lcdesnitLetras3.Trim)

    '    Catch ex As Exception
    '        Response.Write("<script language='javascript'>alert('Error al intentar acceder al Documento de Word')</script>")
    '    End Try




    'End Sub

    'Private Sub CargaArchivo(ByVal _filename As String)
    '    _objWordApplication = New AppWord.Application 'Word.Application()
    '    '_objWordDocument = _objWordApplication.Documents.Open(Server.MapPath("Documentos\Creditos") + "\" + _filename + ".Docx", False, False, False, oMissing, oMissing, _
    '    _objWordDocument = _objWordApplication.Documents.Open(("C:\Contratos\Plantillas\CONTRATO FIDUCIARIO CON FIRMAS.docx"), False, False, False, oMissing, oMissing, _
    '     oMissing, oMissing)
    '    _objWordApplication.Visible = True '_objWordApplication
    '    '_objWordApplication = _objWordApplication.ActiveDocument
    'End Sub

    'Public Sub BuscarYReemplzar(ByVal _Buscar As String, ByVal _Reemplazar As String)
    '    Dim findObject As AppWord.Find = _objWordApplication.Selection.Find
    '    findObject.ClearFormatting()
    '    findObject.Text = _Buscar
    '    findObject.Replacement.ClearFormatting()
    '    findObject.Replacement.Text = _Reemplazar

    '    Dim replaceAll As Object = AppWord.WdReplace.wdReplaceAll
    '    findObject.Execute(oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, _
    '     oMissing, oMissing, oMissing, oMissing, replaceAll, oMissing, _
    '     oMissing, oMissing, oMissing)
    'End Sub

#End Region

#Region "Codigo Anterior que no se ocupa"

    'Public Sub ContratosWord()

    '    Dim word As New Microsoft.Office.Interop.Word.Application
    '    Dim doc As Microsoft.Office.Interop.Word.Document
    '    Try
    '        doc = word.Documents.Open("C:\Contratos\Plantillas\CONTRATO FIDUCIARIO CON FIRMAS.docx")
    '        doc.Activate()
    '        Dim myStoryRange As Microsoft.Office.Interop.Word.Range
    '        For Each myStoryRange In doc.StoryRanges
    '            With myStoryRange.Find
    '                .Text = "<<NombreCliente>>"
    '                .Replacement.Text = "Pedro Lopez"
    '                .Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue
    '                .Execute(Replace:=Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll)
    '            End With
    '        Next myStoryRange
    '        doc.SaveAs("C:\Contratos\Plantillas\CONTRATO FIDUCIARIO CON FIRMAS1.docx")
    '    Catch ex As Exception

    '        Response.Write("<script language='javascript'>alert('Error al intentar acceder al Documento de Word')</script>")
    '    End Try


    'End Sub

    'Private Function ReturnDataSet() As DataSet
    'Dim dt As New DataTable
    'Dim dr As DataRow
    'Dim ds As New dscontratos

    'dt.Columns.Add(New DataColumn("mcondoc", GetType(String)))

    'dr = dt.NewRow()
    'dr("mcondoc") = "Generar Contrato"
    'dt.Rows.Add(dr)

    'ds.Tables.Add(dt)
    'ds.Tables(0).TableName = "Contratos"

    'Return ds

    'End Function

    'Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
    '    'Se crea el documento de lectura y escritura
    '    Dim rptStream As New System.IO.MemoryStream
    '    'se envia el reporte el stram y le indicamos el metodo de escritura o tipo de documento
    '    rptStream = CType(crDatos.ExportToStream(CInt(ddlTipos.SelectedValue)), System.IO.MemoryStream)

    '    'Limpiamos la memoria
    '    Response.Clear()
    '    Response.Buffer = True

    '    'Le indicamos el tipo de documento que vamos a exportar
    '    Response.ContentType = FormatoDocumento()

    '    'Automaticamente se descarga el archivo
    '    Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)

    '    'Se escribe el archivo
    '    Response.BinaryWrite(rptStream.ToArray())
    '    Response.End()
    'End Sub


    'Indicamos el Tipo de archivo que vamos a exportar,
    'tambien le indicamos la extension
    'Private Function FormatoDocumento() As String
    '    Dim tipo As String
    '    Select Case Integer.Parse(ddlTipos.SelectedValue)
    '        Case ExportFormatType.Excel
    '            tipo = "application/vnd.ms-excel"
    '            nombreReporte &= ".xls"
    '        Case ExportFormatType.RichText
    '            tipo = "application/rtf"
    '            nombreReporte &= ".rtf"
    '        Case ExportFormatType.WordForWindows
    '            tipo = "application/msword"
    '            nombreReporte &= ".doc"
    '        Case Else
    '            tipo = "application/pdf"
    '            nombreReporte &= ".pdf"
    '    End Select
    '    Return tipo
    'End Function


    'Private Sub contratos(ByVal ctipo As String)
    '    Dim input As String
    '    Dim lcnomcli As String
    '    Dim lcnombar As String
    '    Dim lcnombre As String

    '    lcnombre = Me.txtcnomcli.Text.Trim
    '    'lee un archivo de texto


    '    Dim lccodcli As String
    '    Dim lnmonsug As Double
    '    Dim lncuosug As Double
    '    Dim lcmonto As String
    '    Dim lnentero As Double
    '    Dim lndeci As Double
    '    Dim lccuosug As String
    '    Dim etabttab As New tabttab
    '    Dim mtabttab As New cTabttab
    '    Dim ecremcre As New cremcre
    '    Dim mcremcre As New cCremcre
    '    Dim ecredtpl As New credtpl
    '    Dim mcredtpl As New cCredtpl

    '    Dim lcdestino As String
    '    Dim lncuota As Double
    '    Dim lccuota As String
    '    Dim lcfecha As String
    '    Dim ldfecha As Date

    '    Dim lnmes As Integer
    '    Dim lndia As Integer
    '    Dim lnano As Integer
    '    Dim lcmes As String
    '    Dim lccodpro As String

    '    Dim mclimide As New cClimide
    '    Dim eclimide As New climide
    '    Dim etabtprf As New tabtprf
    '    Dim mtabtprf As New cTabtprf
    '    Dim lcprofesion As String
    '    Dim lcdirdom As String
    '    Dim lcedad As String = ""
    '    Dim lcdui As String
    '    Dim lcdesdui As String
    '    Dim lntam As Integer
    '    Dim i As Integer
    '    Dim lcdesdui1 As String
    '    Dim lcdesdui2 As String
    '    Dim lcultimo As String
    '    Dim lcprimero As String
    '    Dim lcnit As String
    '    Dim lcdesnit As String
    '    Dim lcdesnit2 As String
    '    Dim ldvencimiento As Date
    '    Dim lcvencimiento As String
    '    Dim lcmonpre As String
    '    Dim lccoddom As String
    '    '>>>>>>>>>>>>>>>>>>>>>>>
    '    Dim lcplazo1 As String

    '    Dim lctiper As String
    '    Dim lndia1 As Integer
    '    Dim lnnumcuo As Integer
    '    Dim lcforma As String
    '    Dim ldfecvig As Date
    '    Dim ldfecven As Date
    '    Dim lnmeses As Integer
    '    Dim lcmeses As String

    '    ecremcre.ccodcta = Me.txtccodcta.Text.Trim
    '    mcremcre.ObtenerCremcre(ecremcre)

    '    ldfecvig = ecremcre.dfecvig
    '    ldfecven = ecremcre.dfecven
    '    lnmeses = DateDiff(DateInterval.Month, ldfecvig, ldfecven)

    '    lcmeses = Num2Text(lnmeses)


    '    Dim lcdiapago As String = ""


    '    lctiper = ecremcre.ctipper

    '    lndia1 = ecremcre.ndiasug
    '    lnnumcuo = ecremcre.ncuosug
    '    lcforma = clase.formapago2(lctiper, lndia1)

    '    lcdiapago = Num2Text(lndia1)


    '    Dim lctasalet As String = ""
    '    Dim lnenter As Double
    '    Dim lndecimal As Double
    '    'lctasalet = Num2Text(ecremcre.ntasint)

    '    lnenter = Decimal.Floor(ecremcre.ntasint)
    '    lndecimal = Math.Round((ecremcre.ntasint - lnenter) * 100)
    '    If lndecimal > 0 Then
    '        lctasalet = Num2Text(lnenter) & " PUNTO " & Num2Text(lndecimal)
    '    Else
    '        lctasalet = Num2Text(lnenter)
    '    End If


    '    '<<<<<<<<<<<<<<<<<<<<<<<
    '    Dim etabtzon As New tabtzon
    '    Dim mtabtzon As New cTabtzon
    '    Dim lcmunicipio As String
    '    Dim lcdepartamento As String
    '    Dim lcplazo As String
    '    Dim lcdias As String
    '    Dim lccredito As String
    '    Dim lclugexp As String = ""

    '    eclimide.ccodcli = ecremcre.ccodcli


    '    lcnomcli = Me.txtcnomcli.Text.Trim
    '    lccodcli = Me.txtccodcli.Text.Trim
    '    lnmonsug = ecremcre.nmonapr
    '    lncuosug = ecremcre.ncuosug
    '    lcmonpre = ecremcre.nmonapr

    '    lnentero = Decimal.Floor(lnmonsug)
    '    lndeci = Math.Round((lnmonsug - lnentero) * 100)
    '    If lndeci > 0 Then
    '        lcmonto = Num2Text(lnentero) & " DOLARES " & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
    '    Else
    '        lcmonto = Num2Text(lnentero) & " DOLARES CON CERO CENTAVOS " 'monto en letras
    '    End If

    '    lccuosug = Num2Text(lncuosug)  'cuotas en letras
    '    lcplazo = Num2Text(lncuosug) ' " CUOTAS "
    '    lcplazo1 = Num2Text(lncuosug - 1)




    '    lccodcli = ecremcre.ccodcli
    '    lccredito = Me.txtccodcta.Text.Trim

    '    etabttab.ccodtab = "005"
    '    etabttab.ctipreg = "1"
    '    etabttab.ccodigo = ecremcre.cdescre.Trim
    '    mtabttab.ObtenerTabttab(etabttab)

    '    lcdestino = etabttab.cdescri.Trim  'destino del credito

    '    ecredtpl.ccodcta = Me.txtccodcta.Text.Trim
    '    ecredtpl.ctipope = "N"
    '    ecredtpl.cnrocuo = "001"
    '    mcredtpl.ObtenerCredtpl(ecredtpl)
    '    clase.gnperbas = Session("gnperbas")
    '    clase.pnComtra = Session("gnComTra")
    '    clase.pnSegVm = Session("gnSegVm1")

    '    Dim ldpricuo As Date
    '    Dim lcmespri As String = ""
    '    Dim lcañocuopri As String = ""
    '    ldpricuo = ecredtpl.dfecven
    '    lcmespri = MonthName(ldpricuo.Month)
    '    lcañocuopri = ldpricuo.Year.ToString.Trim

    '    lncuota = ecremcre.nmoncuo

    '    lnentero = Decimal.Floor(lncuota)
    '    lndeci = Math.Round((lncuota - lnentero) * 100)
    '    If lndeci > 0 Then
    '        lccuota = Num2Text(lnentero) & " CON " & Num2Text(lndeci) & " CENTAVOS" 'monto en letras
    '    Else
    '        lccuota = Num2Text(lnentero) 'monto en letras
    '    End If

    '    'fecha desembolso
    '    ldfecha = Date.Parse(ecremcre.dfecapr)
    '    lnmes = ldfecha.Month
    '    lndia = ldfecha.Day
    '    lnano = ldfecha.Year
    '    lcmes = MonthName(lnmes)
    '    lcfecha = Num2Text(lndia) & " DIAS DEL MES DE " & lcmes & " DE " & Num2Text(lnano)
    '    lcfecha = lcfecha.ToUpper
    '    lcdias = Num2Text(lndia)

    '    ''obtiene fecha de vencimiento
    '    'ldvencimiento = Date.Parse(ecremcre.dfecven)
    '    'lnmes = ldvencimiento.Month
    '    'lndia = ldvencimiento.Day
    '    'lnano = ldvencimiento.Year
    '    'lcmes = MonthName(lnmes)
    '    'lcvencimiento = Num2Text(lndia) & " DEL MES DE " & lcmes & " DE " & Num2Text(lnano)
    '    'lcvencimiento = lcvencimiento.ToLower


    '    'obtiene datos del cliente
    '    eclimide.ccodcli = lccodcli
    '    mclimide.ObtenerClimide(eclimide)
    '    lcdirdom = eclimide.cdirdom
    '    lcdui = eclimide.cnudoci.Trim
    '    lclugexp = eclimide.cLugExp.Trim
    '    'lcdui = lcdui.Replace("-", "")
    '    lcnit = eclimide.cnudotr.Trim
    '    lccoddom = eclimide.ccoddom.Trim

    '    lccodpro = eclimide.ccodpro

    '    'obtiene municipio y departamento expedicion


    '    Dim lcmuniexp As String = ""
    '    Dim lcdepaexp As String = ""

    '    Dim lclugexp1 As String = ""
    '    Dim lclugexp2 As String = ""

    '    Dim lcmuniexp1 As String = ""
    '    Dim lcmuniexp2 As String = ""

    '    Dim lcdepaexp1 As String = ""
    '    Dim lcdepaexp2 As String = ""


    '    If lclugexp.Trim = "" Then
    '    Else

    '        etabtzon.ccodzon = lclugexp
    '        etabtzon.ctipzon = "2"
    '        mtabtzon.ObtenerTabtzon(etabtzon)
    '        lcmuniexp = etabtzon.cdeszon.Trim
    '        lcmuniexp = lcmuniexp.ToUpper
    '        'departamento
    '        etabtzon.ccodzon = lclugexp.Substring(0, 2)
    '        etabtzon.ctipzon = "1"
    '        mtabtzon.ObtenerTabtzon(etabtzon)
    '        lcdepaexp = etabtzon.cdeszon.Trim
    '        lcdepaexp = lcdepaexp.ToUpper

    '    End If



    '    etabtprf.ccodigo = lccodpro
    '    mtabtprf.ObtenerTabtprf(etabtprf)
    '    lcprofesion = etabtprf.cdescri.Trim  ' profesion
    '    If eclimide.dnacimi <> Nothing Then
    '        lcedad = Num2Text(Math.Round(clase.CalculaEdad(eclimide.dnacimi)))
    '        lcedad = lcedad.ToLower
    '    End If
    '    'detalla el dui en letras

    '    If lcdui.Replace("-", "").Trim.Length = 9 Then
    '        lcdesdui = Me.Duiletras(lcdui)
    '        lcdesdui = lcdesdui.Trim.ToUpper
    '    Else
    '        lcdesdui = ""
    '    End If




    '    'detalla el nit
    '    lntam = lcnit.Length
    '    lcdesnit = ""
    '    If lntam <> 14 Then
    '        lcdesnit = ""
    '        '    '            Response.Write("<script language='javascript'>alert('Nit del cliente no posee 14 caracteres')</script>")
    '    Else
    '        lcdesnit2 = lcnit.Substring(0, 4)
    '        lcdesnit = Num2Text(Integer.Parse(lcdesnit2))
    '        lcdesnit2 = lcnit.Substring(4, 6)
    '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))
    '        lcdesnit2 = lcnit.Substring(10, 3)
    '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))

    '        lcdesnit2 = lcnit.Substring(lntam - 1, 1)
    '        lcdesnit = lcdesnit & " guión " & Num2Text(Integer.Parse(lcdesnit2))
    '        lcdesnit = lcdesnit.ToUpper
    '    End If

    '    'obtiene municipio y departamento

    '    etabtzon.ccodzon = lccoddom
    '    etabtzon.ctipzon = "3"
    '    mtabtzon.ObtenerTabtzon(etabtzon)
    '    lcmunicipio = etabtzon.cdeszon.Trim
    '    lcmunicipio = lcmunicipio.ToUpper
    '    'departamento
    '    etabtzon.ccodzon = lccoddom.Substring(0, 2)
    '    etabtzon.ctipzon = "1"
    '    mtabtzon.ObtenerTabtzon(etabtzon)
    '    lcdepartamento = etabtzon.cdeszon.Trim
    '    lcdepartamento = lcdepartamento.ToUpper

    '    '**************************obtiene datos del fiador******************

    '    Dim eclimgar As New climgar
    '    Dim mclimgar As New cClimgar
    '    Dim lccoduni As String
    '    Dim lcnombre1 As String = ""
    '    Dim lcnit1 As String = ""
    '    Dim lcdui1 As String = ""
    '    Dim lccodpro1 As String = ""
    '    Dim ldnacimi1 As Date
    '    Dim lcdesnit2f As String = ""
    '    Dim lcdesnitf As String = ""
    '    Dim lcdesduif As String = ""
    '    Dim lcdesdui2f As String = ""
    '    Dim lcprofesion1 As String = ""
    '    Dim lcedad1 As String = ""
    '    Dim lnedad1 As Double = 0
    '    Dim lccoddom1 As String = ""
    '    Dim lcmunicipio1 As String = ""
    '    Dim lcdepartamento1 As String = ""
    '    Dim lcdesduif1 As String = ""
    '    'Para fiador 2
    '    Dim lcnombre2 As String = ""
    '    Dim lcedad2 As String = ""
    '    Dim lcprofesion2 As String = ""
    '    Dim lcmunicipio2 As String = ""
    '    Dim lcdepartamento2 As String = ""
    '    Dim lcdesduif2 As String = ""

    '    Dim lcnit2 As String = ""
    '    Dim lcdui2 As String = ""
    '    Dim lccodpro2 As String = ""
    '    Dim ldnacimi2 As Date
    '    Dim lccoddom2 As String
    '    '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    '    Dim lcdirdom1 As String = ""
    '    Dim lcdirdom2 As String = ""

    '    Dim lnfia As Integer = 0

    '    lccoduni = "**"
    '    eclimgar.ccodcli = lccodcli

    '    Dim ds As New DataSet
    '    ds = mclimgar.ObtenerDataSetPor_Garantia_Cliente(lccodcli)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim fila As DataRow
    '        Dim ele As Integer = 0
    '        For Each fila In ds.Tables(0).Rows
    '            lnfia += 1
    '            If lnfia = 1 Then
    '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
    '                eclimide.ccodcli = lccoduni
    '                mclimide.ObtenerClimide(eclimide)
    '                lcnombre1 = eclimide.cnomcli.Trim
    '                lcnit1 = eclimide.cnudotr.Trim
    '                lcdui1 = eclimide.cnudoci.Trim
    '                'lcdui1 = lcdui1.Replace("-", "")
    '                lccodpro1 = eclimide.ccodpro.Trim
    '                ldnacimi1 = eclimide.dnacimi
    '                lccoddom1 = eclimide.ccoddom.Trim
    '                lcdirdom1 = eclimide.cdirdom.Trim

    '                lclugexp1 = eclimide.cLugExp.Trim
    '                If lclugexp1.Trim = "" Then
    '                Else



    '                    etabtzon.ccodzon = lclugexp1
    '                    etabtzon.ctipzon = "2"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcmuniexp1 = etabtzon.cdeszon.Trim
    '                    lcmuniexp1 = lcmuniexp1.ToUpper
    '                    'departamento
    '                    etabtzon.ccodzon = lclugexp1.Substring(0, 2)
    '                    etabtzon.ctipzon = "1"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcdepaexp1 = etabtzon.cdeszon.Trim
    '                    lcdepaexp1 = lcdepaexp1.ToUpper
    '                End If
    '                'detalla el nit
    '                lntam = lcnit1.Length
    '                If lntam <> 17 Then
    '                    lcdesnitf = ""
    '                    lcdesnit2f = ""
    '                    '                Response.Write("<script language='javascript'>alert('Nit del fiador no posee 17 caracteres')</script>")
    '                Else

    '                    lcdesnit2f = lcnit1.Substring(0, 4)
    '                    lcdesnitf = Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnit2f = lcnit1.Substring(5, 6)
    '                    lcdesnitf = lcdesnitf & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnit2f = lcnit1.Substring(12, 3)
    '                    lcdesnitf = lcdesnitf & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnit2f = lcnit1.Substring(lntam - 1, 1)
    '                    lcdesnitf = lcdesnitf & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnitf = lcdesnitf.ToUpper
    '                End If

    '                'detalla el dui en letras


    '                lcdesduif1 = "" 'Me.Duiletras(lcdui1)


    '                'obtiene profesion
    '                etabtprf.ccodigo = lccodpro1
    '                mtabtprf.ObtenerTabtprf(etabtprf)
    '                lcprofesion1 = etabtprf.cdescri.Trim
    '                lcprofesion1 = lcprofesion1.ToLower

    '                'obtiene edad
    '                lnedad1 = clase.CalculaEdad(ldnacimi1)
    '                lcedad1 = Num2Text(lnedad1)
    '                lcedad1 = lcedad1.ToLower

    '                'domicilio
    '                'obtiene municipio y departamento
    '                If lccoddom1.Trim = "" Then
    '                Else
    '                    etabtzon.ccodzon = lccoddom1.Substring(0, 4)
    '                    etabtzon.ctipzon = "2"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcmunicipio1 = etabtzon.cdeszon.Trim
    '                    lcmunicipio1 = lcmunicipio1.ToUpper

    '                    'departamento
    '                    etabtzon.ccodzon = lccoddom1.Substring(0, 2)
    '                    etabtzon.ctipzon = "1"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcdepartamento1 = etabtzon.cdeszon.Trim
    '                    lcdepartamento1 = lcdepartamento1.ToUpper
    '                End If
    '            End If
    '            'Segundo fiador >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    '            If lnfia = 2 Then
    '                lccoduni = ds.Tables(0).Rows(ele)("ccoduni")
    '                eclimide.ccodcli = lccoduni
    '                mclimide.ObtenerClimide(eclimide)
    '                lcnombre2 = eclimide.cnomcli.Trim
    '                lcnit2 = eclimide.cnudotr.Trim
    '                lcdui2 = eclimide.cnudoci.Trim
    '                'lcdui2 = lcdui2.Replace("-", "")
    '                lccodpro2 = eclimide.ccodpro.Trim
    '                ldnacimi2 = eclimide.dnacimi
    '                lccoddom2 = eclimide.ccoddom.Trim
    '                lcdirdom2 = eclimide.cdirdom.Trim

    '                lclugexp2 = eclimide.cLugExp.Trim

    '                If lclugexp2.Trim = "" Then
    '                Else
    '                    etabtzon.ccodzon = lclugexp2
    '                    etabtzon.ctipzon = "2"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcmuniexp2 = etabtzon.cdeszon.Trim
    '                    lcmuniexp2 = lcmuniexp2.ToUpper
    '                    'departamento
    '                    etabtzon.ccodzon = lclugexp2.Substring(0, 2)
    '                    etabtzon.ctipzon = "1"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcdepaexp2 = etabtzon.cdeszon.Trim
    '                    lcdepaexp2 = lcdepaexp2.ToUpper
    '                End If
    '                'detalla el nit
    '                lntam = lcnit2.Length
    '                If lntam <> 17 Then
    '                    lcdesnitf = ""
    '                    lcdesnit2f = ""

    '                Else

    '                    lcdesnit2f = lcnit2.Substring(0, 4)
    '                    lcdesnitf = Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnit2f = lcnit2.Substring(5, 6)
    '                    lcdesnitf = lcdesnitf & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnit2f = lcnit2.Substring(12, 3)
    '                    lcdesnitf = lcdesnitf & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnit2f = lcnit2.Substring(lntam - 1, 1)
    '                    lcdesnitf = lcdesnitf & " guión " & Num2Text(Integer.Parse(lcdesnit2f))
    '                    lcdesnitf = lcdesnitf.ToUpper
    '                End If

    '                'detalla el dui en letras


    '                lcdesduif2 = "" 'Me.Duiletras(lcdui2)



    '                'obtiene profesion
    '                etabtprf.ccodigo = lccodpro2
    '                mtabtprf.ObtenerTabtprf(etabtprf)
    '                lcprofesion2 = etabtprf.cdescri.Trim
    '                lcprofesion2 = lcprofesion1.ToLower

    '                'obtiene edad
    '                lnedad1 = clase.CalculaEdad(ldnacimi2)
    '                lcedad1 = Num2Text(lnedad1)
    '                lcedad2 = lcedad2.ToLower

    '                'domicilio
    '                'obtiene municipio y departamento

    '                If lccoddom2.Trim = "" Then
    '                Else
    '                    etabtzon.ccodzon = lccoddom2.Substring(0, 4)
    '                    etabtzon.ctipzon = "2"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcmunicipio2 = etabtzon.cdeszon.Trim
    '                    lcmunicipio2 = lcmunicipio2.ToUpper

    '                    'departamento
    '                    etabtzon.ccodzon = lccoddom2.Substring(0, 2)
    '                    etabtzon.ctipzon = "1"
    '                    mtabtzon.ObtenerTabtzon(etabtzon)
    '                    lcdepartamento2 = etabtzon.cdeszon.Trim
    '                    lcdepartamento2 = lcdepartamento2.ToUpper
    '                End If
    '            End If
    '            ele += 1
    '        Next

    '    End If

    '    'Garantia Prendaria
    '    Dim ds1 As New DataSet
    '    Dim lngarpre As Integer = 0
    '    Dim lcinmueble1 As String = ""
    '    Dim lcdescri1 As String = ""
    '    ds1 = mclimgar.ObtenerDataSetPor_Garantia_Prendaria(lccodcli)
    '    If ds1.Tables(0).Rows.Count > 0 Then
    '        lngarpre = ds1.Tables(0).Rows.Count
    '        Dim fila1 As DataRow
    '        Dim ele1 As Integer = 0
    '        Dim lcdescri As String
    '        For Each fila1 In ds1.Tables(0).Rows
    '            lcdescri1 = ds1.Tables(0).Rows(ele1)("cdescri")
    '            lcinmueble1 = lcinmueble1 + lcdescri1.Trim

    '            ele1 += 1
    '            If lngarpre = ele1 Then
    '                lcinmueble1 = lcinmueble1 + " "
    '            Else
    '                lcinmueble1 = lcinmueble1 + ","
    '            End If
    '        Next
    '    End If
    '    '--------------------------------------------------------------------------------------

    '    'Imprime Plan de Pagos >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><
    '    Dim crRpt As New ReportDocument
    '    Dim rptStream As New System.IO.MemoryStream
    '    Dim nombreReporte As String
    '    If ctipo.Trim = "A" Then
    '        nombreReporte = "crContratos.rpt"
    '    Else
    '        nombreReporte = "crContratos2.rpt"
    '    End If


    '    Try
    '        'Cargar Definicion del Reporte
    '        crRpt.Load(Server.MapPath("reportes") + "\" & nombreReporte, OpenReportMethod.OpenReportByDefault)
    '    Catch ex As Exception
    '        Return
    '    End Try
    '    '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    '    ' Setear los registros recuperados, diciendole el Table respectivo

    '    Dim tipo As String
    '    Select Case Integer.Parse(ddlTipos.SelectedValue)
    '        Case ExportFormatType.Excel
    '            tipo = "application/vnd.ms-excel"
    '            nombreReporte &= ".xls"
    '        Case ExportFormatType.RichText
    '            tipo = "application/rtf"
    '            nombreReporte &= ".rtf"
    '        Case ExportFormatType.WordForWindows
    '            tipo = "application/msword"
    '            nombreReporte &= ".doc"
    '        Case Else
    '            tipo = "application/pdf"
    '            nombreReporte &= ".pdf"
    '    End Select


    '    Dim dsr As New DataSet
    '    Dim etabtusu As New cTabtusu
    '    dsr = etabtusu.ObtenerDataSetPorID()
    '    crRpt.SetDataSource(dsr.Tables(0))

    '    '-------------------------------------------------------------------------------------
    '    crRpt.SetParameterValue("pcnomcli", txtcnomcli.Text.Trim)
    '    crRpt.SetParameterValue("pcsumade", lcmonto.Trim)
    '    crRpt.SetParameterValue("pcmonsug", clase.Cominola(lnmonsug.ToString.Trim))
    '    crRpt.SetParameterValue("pccuotas", lcplazo1.Trim)
    '    crRpt.SetParameterValue("pcmoncuo", lccuota.Trim)
    '    crRpt.SetParameterValue("pccuota", clase.Cominola(lncuota.ToString.Trim))
    '    crRpt.SetParameterValue("pcmespri", lcmespri.Trim.ToUpper)
    '    crRpt.SetParameterValue("pcañocuopri", lcañocuopri.Trim)
    '    crRpt.SetParameterValue("pcdirdom", lcdirdom.Trim)
    '    crRpt.SetParameterValue("pcdia", Num2Text(lndia))
    '    crRpt.SetParameterValue("pcmes", lcmes.Trim.ToUpper)
    '    crRpt.SetParameterValue("pcano", Num2Text(lnano))

    '    crRpt.SetParameterValue("pcmunicipio", lcmunicipio.Trim)
    '    crRpt.SetParameterValue("pcdepartamento", lcdepartamento.Trim)
    '    crRpt.SetParameterValue("pcdui", lcdui.Trim)

    '    crRpt.SetParameterValue("pcmuniexp", lcmuniexp.Trim)
    '    crRpt.SetParameterValue("pcdepaexp", lcdepaexp.Trim)


    '    'fiador 1
    '    crRpt.SetParameterValue("pcnomfia1", lcnombre1.Trim)
    '    crRpt.SetParameterValue("pcdirdom1", lcdirdom1.Trim)
    '    crRpt.SetParameterValue("pcdepartamento1", lcdepartamento1)
    '    crRpt.SetParameterValue("pcmunicipio1", lcmunicipio1)
    '    crRpt.SetParameterValue("pcdui1", lcdui1.Trim)

    '    'fiador 1
    '    crRpt.SetParameterValue("pcnomfia2", lcnombre2.Trim)
    '    crRpt.SetParameterValue("pcdirdom2", lcdirdom2.Trim)
    '    crRpt.SetParameterValue("pcdepartamento2", lcdepartamento2)
    '    crRpt.SetParameterValue("pcmunicipio2", lcmunicipio2)
    '    crRpt.SetParameterValue("pcdui2", lcdui2.Trim)

    '    crRpt.SetParameterValue("pcmuniexp1", lcmuniexp1.Trim)
    '    crRpt.SetParameterValue("pcdepaexp1", lcdepaexp1.Trim)
    '    crRpt.SetParameterValue("pcmuniexp2", lcmuniexp2.Trim)
    '    crRpt.SetParameterValue("pcdepaexp2", lcdepaexp2.Trim)

    '    crRpt.SetParameterValue("pcedad", lcedad)
    '    crRpt.SetParameterValue("pcprofesion", lcprofesion)
    '    crRpt.SetParameterValue("pcdesnit", lcdesnit)
    '    crRpt.SetParameterValue("pctasalet", lctasalet)
    '    crRpt.SetParameterValue("pcmeses", lcmeses)
    '    crRpt.SetParameterValue("pccuosug", lccuosug)
    '    crRpt.SetParameterValue("pcdiapago", lcdiapago)
    '    crRpt.SetParameterValue("pcdesdui", lcdesdui)

    '    crRpt.SetParameterValue("pcfecha", lcfecha)
    '    '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    '    Dim reportes As String
    '    reportes = "Pagare.rtf"


    '    'rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
    '    rptStream = CType(crRpt.ExportToStream(ExportFormatType.RichText), System.IO.MemoryStream)
    '    Response.Clear()
    '    Response.Buffer = True
    '    ' Establece el tipo de documento
    '    'Response.ContentType = "application/pdf"
    '    'Response.ContentType = "application/msword"
    '    Response.ContentType = "application/rtf"

    '    'Automaticamente se descarga el archivo
    '    Response.BinaryWrite(rptStream.ToArray())
    '    Response.AddHeader("Content-Disposition", "attachment;filename=" + reportes)
    '    'Response.Flush()
    '    'Response.Close()
    '    Response.End()

    'End Sub
#End Region

    Protected Sub txtCodUsu_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodUsu.TextChanged

    End Sub

    Protected Sub cbxContrato_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxContrato.SelectedIndexChanged

    End Sub
End Class





