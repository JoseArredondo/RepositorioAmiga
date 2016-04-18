Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports System.Data.Common
Imports System.Text
Imports System.Configuration.ConfigurationSettings
Imports System
Imports System.Data
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Drawing.Printing
Imports System.IO


Partial Class ucretiroaho
    Inherits ucWBase

#Region "Privadas"
    Private codigoJs As String
    Private omclass As New cAhomcta
    Private dataset_lineas As New DataSet
    Private clsConvert As New SIM.BL.ConversionLetras
    Private Shared global_cnumcom As String
    Private Shared control1 As Integer = 0
#End Region
    
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        'txtmonto.Attributes.Add("onChange", "return Calculatotal()")

        If Not IsPostBack Then
            CargarCombos()

        End If
    End Sub
    Private Sub activarcheque()
        If chkcheque.Checked = True Then
            CbxBancos1.Enabled = True
            Cbx_ctaBco1.Enabled = True
            txtnroche.Enabled = True
            txtcnomchq.Enabled = True
        Else
            CbxBancos1.Enabled = True
            Cbx_ctaBco1.Enabled = True
            txtnroche.Enabled = False
            txtcnomchq.Enabled = False
        End If
    End Sub

    Private Sub initvar2()
        txtnrodoc.Text = ""
        txtmonto.Text = 0
        txtnroche.Text = ""
        txtcnomchq.Text = ""
        txttotaporta.Text = 0
        txtmoraaporta.Text = 0
        txtobserva.Text = ""
        txtnotas.Text = ""
        txtsaldo.Text = 0
        txtcompensado.Text = 0
        txtrestringido.Text = 0

    End Sub
    Public Sub CargarDatosPorCuenta(ByVal cuenta As String)
        HiddenField1.Value = 0
        'control1 = 0
        Me.txtcodcta.Text = cuenta
        initvar2()
        Me.btnaplicar_Click(Me, New System.EventArgs)
    End Sub



    Public Sub CargarCombos()
        Dim clsbancos As New SIM.BL.cTabtbco
        Dim clstabttab As New SIM.BL.cTabttab
        Dim clstabtofi As New SIM.BL.cTabtofi
        Dim clspromo As New SIM.BL.cPromociones


        Dim ldfecha As Date

        Dim dsc As New DataSet
        Dim dsb As New DataSet
        Dim mListaTabttab As New listatabttab
        Dim mlistainstitu As New listatabttab
        Dim mlistaoficina As New listatabtofi


        mListaTabttab = clstabttab.ObtenerLista("187", "1")
        mlistainstitu = clstabttab.ObtenerLista("054", "1")
        mlistaoficina = clstabtofi.ObtenerLista()

        Me.ddlcajero.DataTextField = "cdescri"
        Me.ddlcajero.DataValueField = "ccodigo"
        Me.ddlcajero.DataSource = mListaTabttab
        Me.ddlcajero.DataBind()


        Dim mlistapromociones As New listapromociones


        mlistapromociones = clspromo.ObtenerLista()

        ddlpromociones.DataTextField = "nombre"
        ddlpromociones.DataValueField = "codigo"
        ddlpromociones.DataSource = mlistapromociones
        ddlpromociones.DataBind()


        'Evalua si usuario es cajero
        Dim lverifica As Boolean
        lverifica = clstabttab.VerificaUsuarioCajero(Session("gccodusu"))
        If lverifica = True Then
            'Obtiene el codigo del usuario en cajeros
            Dim lccodigo As String
            lccodigo = clstabttab.ObtieneCodigoCajero(Session("gccodusu"))
            ddlcajero.SelectedValue = lccodigo
            Me.Button1.Enabled = True
        Else
            Me.Button1.Enabled = False
        End If
        btnprogra.Visible = False
        '------------------------------------------------

        'mListaTabttab = clstabttab.ObtenerLista("186", "1")

        'Me.ddltipaho.DataTextField = "cdescri"
        'Me.ddltipaho.DataValueField = "ccodigo"
        'Me.ddltipaho.DataSource = mListaTabttab
        'Me.ddltipaho.DataBind()

        'clsbancos.ObtenerDatasetporid(dsb, Session("gcCodofi"))
        'Me.ddlbancos.DataTextField = "cnombco"
        'Me.ddlbancos.DataValueField = "ccodbco"
        'Me.ddlbancos.DataSource = dsb.Tables(0)
        'Me.ddlbancos.DataBind()

        CbxBancos1.Recuperar()
        Cbx_ctaBco1.Recuperar(CbxBancos1.SelectedValue)

        Me.ddloficina.DataTextField = "cnomofi"
        Me.ddloficina.DataValueField = "ccodofi"
        Me.ddloficina.DataSource = mlistaoficina
        Me.ddloficina.DataBind()
        Me.ddloficina.SelectedValue = Session("gccodofi")

        ldfecha = Session("GDFECSIS")
        Me.txtfecha.Text = ldfecha.ToString

        '    Me.txtfecha.EnableViewState = False
        Me.btnaplicar.EnableViewState = True
        'Me.ddlbancos.Enabled = False
        Me.CbxBancos1.Enabled = False
        Me.Cbx_ctaBco1.Enabled = False
        Me.btnimprimir.Enabled = False
        Me.Button1.Enabled = False
        Me.btnaplicar.Enabled = True
        Me.btncancela.Enabled = True
        btnlibreta.Enabled = False
        inicializa()
    End Sub

    Sub inicializa()
        Me.txtcodcli.Text = ""
        Me.txtnomcli.Text = ""
        Me.txtcodcta.Text = ""
        Me.txtfecha.Text = ""
        Me.txtnrodoc.Text = ""
        Me.txtmonto.Text = 0
        Me.txtobserva.Text = ""
        txtdepositos.Text = 0
        Me.verificalavado.Text = "0"
        txtnroche.Text = ""
        txtcnomchq.Text = ""
        comprobante_Button.Visible = False
    End Sub
    Sub cancela()
        Me.txtcodcli.Text = ""
        Me.txtnomcli.Text = ""
        Me.txtcodcta.Text = ""
        Me.txtfecha.Text = ""
        Me.txtnrodoc.Text = ""
        Me.txtmonto.Text = 0
        Me.txtobserva.Text = ""
        Me.btnaplicar.Enabled = True
        Me.Button1.Enabled = False
        Me.btnimprimir.Enabled = False
        Me.btncancela.Enabled = True
    End Sub
    Private Sub Deshabilitado()
        ddlpromociones.Enabled = False
        txtnrodoc.Enabled = False
        txtmonto.Enabled = False
        txtfecha.Enabled = False
        txtnotas.Enabled = False
        txtcolector.Enabled = False
        txtobserva.Enabled = False
        txtnroche.Enabled = False
    End Sub
    Private Sub ParaImprimir()
        Me.btnaplicar.Enabled = True
        Me.btncancela.Enabled = True
        Button1.Enabled = False
        btnimprimir.Enabled = True
        'control1 = 0
        HiddenField1.Value = 0

        If RadioButton1.Checked = True Then
            btnlibreta.Enabled = True
        Else
            btnlibreta.Enabled = False

        End If

    End Sub
    Private Sub Habilitado()
        ddlpromociones.Enabled = True
        txtnrodoc.Enabled = True
        txtmonto.Enabled = True
        txtfecha.Enabled = True
        txtnotas.Enabled = True
        txtcolector.Enabled = True
        txtobserva.Enabled = True
        txtnroche.Enabled = True
        Me.btnaplicar.Enabled = False
        Me.Button1.Enabled = True
        Me.btnimprimir.Enabled = False
        Me.btncancela.Enabled = True
        btnlibreta.Enabled = False
    End Sub


    Private Sub efectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles efectivo.CheckedChanged
        If Me.efectivo.Checked = True Then
            'Me.ddlbancos.Enabled = False
            Me.CbxBancos1.Enabled = False
            Me.Cbx_ctaBco1.Enabled = False
            Me.ddlcajero.Enabled = True
            Me.bancos.Checked = False
        End If
    End Sub

    Private Sub bancos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bancos.CheckedChanged
        If Me.bancos.Checked = True Then
            Me.CbxBancos1.Enabled = True
            Me.Cbx_ctaBco1.Enabled = True
            Me.ddlcajero.Enabled = False
            Me.efectivo.Checked = False
        End If
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If escondido_TextBox.Text <> 0 Then
        '    Exit Sub
        'End If

        'escondido_TextBox.Text = 100

        HiddenField1.Value = Integer.Parse(HiddenField1.Value) + 1
        'control1 = control1 + 1
        If HiddenField1.Value <> 1 Then
            Exit Sub
        End If


        global_cnumcom = ""

        Dim entidadCtbdChq As New SIM.EL.ctbdchq
        Dim eCtbdchq As New SIM.BL.cCtbdchq

        Dim lccodaho As String
        Dim lcnrodoc As String
        Dim lnretiro As Double
        Dim lnsaldo As Double
        Dim lnnewsal As Double
        Dim lnnumlin As Integer
        Dim ldfecha As Date
        Dim lcnumpar As String = ""
        Dim lnnumlin2 As Integer
        Dim lcctactb As String
        Dim lccodcaja As String
        Dim lctippag As String
        Dim lnefectivo As Double
        Dim lccodofi As String
        Dim lncompen As Integer = 0
        Dim pnsaldoAho_ As Double = 0


        lccodofi = Session("gccodofi")

        If Me.txtcodcta.Text.Trim = " " Or Me.txtcodcta.Text.Trim = Nothing Or Me.txtmonto.Text.Trim = " " Or Me.txtmonto.Text.Trim = Nothing Then
            Exit Sub
        End If


        'Valida que monto a retirar no sea mayor al saldo
        pnsaldoAho_ = omclass.Extraer_Saldo_Cta_Ahorro(Me.txtcodcta.text.trim)


        Me.txtsaldo.text = pnsaldoAho_

        If Double.Parse(Me.txtmonto.text) > pnsaldoAho_ Then
            codigoJs = "<script language='javascript'>alert('El Monto a Retirar no puede ser mayor al Saldo de la Cuenta, " & _
                        "Advertencia SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            Exit Sub
        End If


        If Double.Parse(Me.txtmonto.Text) <= 0 Then
            codigoJs = "<script language='javascript'>alert('El Monto a Retirar debe ser mayor a cero, " & _
                        "Advertencia SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            Exit Sub
        End If


        'Valida cheque en blanco
        'If Double.Parse(txtcheque.Text) > 0 Then
        '    If txtnroche.Text.Trim = "" Then
        '        Response.Write("<script language='javascript'>alert('Cheque en Blanco')</script>")
        '        Exit Sub
        '    End If
        '    lncompen = 1
        'Else
        '    lncompen = 0
        'End If

        Dim lccodcaj As String
        lccodcaj = Me.ddlcajero.SelectedValue.Trim
        'Obtiene si es caja o cajero contable
        Dim etabttab As New cTabttab

        lctippag = "E"
        'lctippag = etabttab.ObtieneTipoCajero(Me.ddlcajero.SelectedValue.Trim)

        'If lctippag.Trim = "" Then 'usuario no es cajero
        '    'Response.Write("<script language='javascript'>alert('Usuario no tiene Autorizaci�n para esta opci�n, Ingrese con otro Usuario ')</script>")
        '    codigoJs = "<script language='javascript'>alert('Usuario no tiene Autorizaci�n para esta opci�n, Ingrese con otro Usuario, " & _
        '                   "Aviso SIM.NET ')</script>"

        '    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
        '    Exit Sub
        'End If
        'If Me.efectivo.Checked = True Then
        '    lccodcaja = Me.ddlcajero.SelectedValue
        '    lccodcaja = ""
        '    lctippag = "E"
        'Else
        '    lccodcaja = Me.ddlbancos.SelectedValue
        '    lctippag = "N"
        'End If



        lccodaho = Me.txtcodcta.Text.Trim
        lcnrodoc = Me.txtnrodoc.Text.Trim
        lnefectivo = Double.Parse(Me.txtmonto.Text.Trim)
        ldfecha = Date.Parse(Me.txtfecha.Text.Trim)

        Dim lncheque As Double = 0
        Dim lnotros As Double = 0


        Dim cahomcta1 As New cAhomcta
        Dim ahomcta1 As New ahomcta

        Dim cahommov1 As New cAhommov
        Dim ahommov1 As New ahommov



        If (lccodaho <> Nothing And lccodaho.Trim <> "") And (lnefectivo > 0 Or lncheque > 0 Or lnotros > 0) Then

            Try
                If Double.Parse(txtmonto.Text) > (Double.Parse(txtsaldo.Text) - Double.Parse(txtrestringido.Text)) Then
                    '                    Response.Write("<script language='javascript'>alert('No puede Retirar mas del Saldo, ni mas del monto Restringido ')</script>")
                    codigoJs = "<script language='javascript'>alert('No puede Retirar mas del Saldo, ni mas del monto Restringido, " & _
                               "Advertencia SIM.NET ')</script>"

                    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                    Exit Sub

                End If


                If chkcheque.Checked = True Then 'validar datos del cheque
                    If txtcnomchq.Text.Trim = "" Then
                        'Response.Write("<script language='javascript'>alert('Digitar a nombre de  quien se emitira cheque ')</script>")
                        codigoJs = "<script language='javascript'>alert('Digitar a nombre de  quien se emitira cheque, " & _
                               "Advertencia SIM.NET ')</script>"

                        ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                        Exit Sub
                    End If
                    If txtnroche.Text.Trim = "" Then
                        'Response.Write("<script language='javascript'>alert('Digitar N� de Cheque ')</script>")
                        codigoJs = "<script language='javascript'>alert('Digitar N� de Cheque, " & _
                               "Advertencia SIM.NET ')</script>"

                        ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                        Exit Sub
                    End If
                    'Verificar si ya existe cheque
                    Dim lverifica As Boolean = False
                    'lverifica = eCtbdchq.VerificarChequeExiste(ddlbancos.SelectedValue.Trim, txtnroche.Text.Trim)
                    lverifica = eCtbdchq.VerificarChequeExiste(Cbx_ctaBco1.SelectedValue.Trim, txtnroche.Text.Trim)
                    If lverifica = True Then
                        'Response.Write("<script language='javascript'>alert('N� de Cheque ya Existe ')</script>")
                        codigoJs = "<script language='javascript'>alert('N� de Cheque ya Existe, " & _
                               "Advertencia SIM.NET ')</script>"

                        ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                        Exit Sub
                    End If
                End If
                Button1.Enabled = False
                'busca el saldo de las cuentas 
                If lccodaho.Trim.Substring(6, 2) = "08" Then
                    If Month(Session("gdfecsis")) > 12 Then
                        'Response.Write("<script language='javascript'>alert('Retiro de Ahorro Navide�o en mes Incorrecto')</script>")
                        codigoJs = "<script language='javascript'>alert('Retiro de Ahorro Navide�o en mes Incorrecto, " & _
                               "Advertencia SIM.NET ')</script>"

                        ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                        Exit Sub

                    End If
                End If

                'If lccodaho.Trim.Substring(6, 2) = "04" Then
                '    If Month(Session("gdfecsis")) >= 3 Then
                '        'Response.Write("<script language='javascript'>alert('Retiro de Ahorro Educativo en mes Incorrecto')</script>")
                '        codigoJs = "<script language='javascript'>alert('Retiro de Ahorro Educativo en mes Incorrecto, " & _
                '               "Advertencia SIM.NET ')</script>"

                '        ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                '        Exit Sub

                '    End If
                'End If



                Dim lntotal As Double = 0
                Dim val_chq As Double = 0
                lnretiro = lnefectivo

                If lncompen = 1 Then
                    val_chq = lncheque
                End If

                'Obtiene numero de linea
                Dim lnlinea As Integer = 1
                Dim lncorrel As Integer = 1
                Dim eahommov As New cAhommov
                Dim clsppal As New class1
                lnlinea = eahommov.ObtieneLinea(lccodaho)
                lnlinea = clsppal.fxLinea(lnlinea)
                If lnlinea = 1 Then
                    'Response.Write("<script language='javascript'>alert('Libreta ha Terminado, pasar por una nueva')</script>")
                    codigoJs = "<script language='javascript'>alert('Libreta ha Terminado, pasar por una nueva, " & _
                               "Advertencia SIM.NET ')</script>"

                    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                End If

                lncorrel = eahommov.ObtieneCorrelativo(lccodaho)

                ahomcta1.ccodaho = lccodaho
                cahomcta1.ObtenerAhomcta(ahomcta1)
                lnsaldo = ahomcta1.nsaldoaho
                lnnewsal = lnsaldo - lnretiro
                lnnumlin = lnlinea

                ahomcta1.ncorrel = lncorrel
                ahomcta1.nsaldoaho = lnnewsal
                ahomcta1.nsaldnind = lnnewsal
                ahomcta1.dfechault = ldfecha
                ahomcta1.dfecult = ldfecha
                ahomcta1.dfecmod = ldfecha
                ahomcta1.dultmov = ldfecha
                ahomcta1.nnum = lnnumlin
                ahomcta1.nmonres = (ahomcta1.nmonres)
                cahomcta1.ActualizarAhomcta(ahomcta1)

                'graba los movimientos
                ahommov1.ccodaho = lccodaho
                ahommov1.nnum = lnnumlin
                ahommov1.nmonto = lnretiro
                ahommov1.nsaldoaho = lnnewsal
                ahommov1.nsaldnind = lnnewsal
                ahommov1.cconcep = "RT"
                ahommov1.ccodusu = Session("gccodusu")
                ahommov1.cnumdoc = lcnrodoc
                ahommov1.dfecefe = ldfecha
                ahommov1.dfecomp = ldfecha
                ahommov1.dfecmod = ldfecha
                ahommov1.dfecope = ldfecha
                ahommov1.clinea = "N"
                ahommov1.npartida = 0
                'ahommov1.interes = Decimal.Parse(Me.ddlpromociones.SelectedValue.Trim)
                ahommov1.interes = 0.0
                ahommov1.ctipope = "R"
                ahommov1.ncompen = lncompen
                ahommov1.notromon = 0
                ahommov1.ccodtra = " "
                ahommov1.ncorrel = lncorrel

                ahommov1.ctipdoc = lctippag
                ahommov1.crazon = "RETIRO " & txtobserva.Text & " " & txtnotas.Text
                ahommov1.nlibreta = Integer.Parse(txtlibreta.Text)
                ahommov1.cnrochq = txtnroche.Text.Trim
                ahommov1.ctipchq = Me.ddlcajero.SelectedValue.Trim
                ahommov1.ctipaho = Me.ddltipaho.SelectedValue.Trim

                ahommov1.tip = ""
                ahommov1.producto = ""
                ahommov1.ccodtra = ""
                ahommov1.notromon = 0

                cahommov1.agregar(ahommov1)

                ' graba en contabilidad
                'cntamov
                Dim lcconcep As String
                Dim eahomtrs As New cAhomtrs
                lcconcep = Mid(lccodaho, 7, 2)

                Dim cclase As New crefunc
                lcnumpar = cclase.fxStevo(ldfecha)

                Dim entidadcntamov As New SIM.EL.cntamov
                Dim ecntamov As New SIM.BL.cCntamov
                entidadcntamov.cnumcom = lcnumpar

                'diario
                Dim entidaddiario As New SIM.EL.diario
                Dim ediario As New SIM.BL.cDiario
                entidaddiario.cnumcom = lcnumpar

                'diario
                Dim lctipoaho As String = ""
                lctipoaho = etabttab.Describe(lcconcep, "186")
                entidaddiario.cnumcom = lcnumpar
                entidaddiario.cglosa = "Retiro " & lctipoaho.Trim & " " & lnretiro.ToString & " PESOS " & Me.txtnomcli.Text.Trim & " recibo No. " & lcnrodoc
                entidaddiario.cnumdoc = lcnrodoc
                entidaddiario.dfeccnt = ldfecha
                entidaddiario.cestado = " "
                entidaddiario.ccodofi = lccodofi
                entidaddiario.ffondos = " "
                entidaddiario.dfecdoc = ldfecha
                entidaddiario.dfecmod = ldfecha
                ediario.agregarDiario(entidaddiario)

                'cntamov
                'lcctactb = cclase.fxcuentacontableahorros("C", lcconcep, "N", "N", "N", lccodofi)
                lcctactb = eahomtrs.ObtenerCuenta(lcconcep, 1)

                lnnumlin2 = 1
                entidadcntamov.ccodcta = lcctactb
                entidadcntamov.cnumlin = lnnumlin2
                entidadcntamov.nhaber = 0
                entidadcntamov.ndebe = lnretiro
                entidadcntamov.ccodpres = lccodaho
                entidadcntamov.cnumdoc = lcnrodoc
                entidadcntamov.ccodofi = lccodofi
                entidadcntamov.cflc = " "
                entidadcntamov.dfeccnt = ldfecha
                entidadcntamov.dfecmod = ldfecha
                entidadcntamov.ccodusu1 = Session("gccodusu")
                entidadcntamov.ffondos = "01"
                entidadcntamov.cclase = Left(lcctactb, 1)
                entidadcntamov.cpoliza = "RT"
                ecntamov.agregarCntamov(entidadcntamov)

                'cuenta por contra
                'lcctactb = cclase.fxcuentacontableahorros("CCJ", lccodcaja, "N", "N", "N", lccodofi)
                lcctactb = etabttab.ObtieneContabledelCajero(ddlcajero.SelectedValue)

                lnnumlin2 = 2
                entidadcntamov.ccodcta = lcctactb
                entidadcntamov.cnumlin = lnnumlin2
                entidadcntamov.nhaber = lnretiro
                entidadcntamov.ndebe = 0
                entidadcntamov.ccodpres = lccodaho
                entidadcntamov.cnumdoc = lcnrodoc
                entidadcntamov.ccodofi = lccodofi
                entidadcntamov.cflc = " "
                entidadcntamov.dfeccnt = ldfecha
                entidadcntamov.dfecmod = ldfecha
                entidadcntamov.ccodusu1 = Session("gccodusu")
                entidadcntamov.ffondos = "01"
                entidadcntamov.cclase = Left(lcctactb, 1)
                entidadcntamov.cpoliza = "RT"
                ecntamov.agregarCntamov(entidadcntamov)

                'Agrega cheque
                If chkcheque.Checked = True Then
                    Dim lcctacte As String
                    Dim etabtbco As New cTabtbco
                    Dim lcctabco As String = ""

                    'lcctacte = etabtbco.CuentadeBanco1(Me.ddlbancos.SelectedValue.Trim)
                    'lcctabco = etabtbco.CuentaContableBanco(ddlbancos.SelectedValue.Trim)

                    lcctacte = etabtbco.CuentadeBanco1(Cbx_ctaBco1.SelectedValue.Trim)
                    lcctabco = etabtbco.CuentaContableBanco(Cbx_ctaBco1.SelectedValue.Trim)


                    lnnumlin2 = 3
                    entidadcntamov.ccodcta = lcctactb
                    entidadcntamov.cnumlin = lnnumlin2
                    entidadcntamov.nhaber = 0
                    entidadcntamov.ndebe = lnretiro
                    entidadcntamov.ccodpres = lccodaho
                    entidadcntamov.cnumdoc = lcnrodoc
                    entidadcntamov.ccodofi = lccodofi
                    entidadcntamov.cflc = " "
                    entidadcntamov.dfeccnt = ldfecha
                    entidadcntamov.dfecmod = ldfecha
                    entidadcntamov.ccodusu1 = Session("gccodusu")
                    entidadcntamov.ffondos = "01"
                    entidadcntamov.cclase = Left(lcctactb, 1)
                    entidadcntamov.cpoliza = "RT"
                    ecntamov.agregarCntamov(entidadcntamov)

                    lnnumlin2 = 4
                    entidadcntamov.ccodcta = lcctabco
                    entidadcntamov.cnumlin = lnnumlin2
                    entidadcntamov.nhaber = lnretiro
                    entidadcntamov.ndebe = 0
                    entidadcntamov.ccodpres = lccodaho
                    entidadcntamov.cnumdoc = lcnrodoc
                    entidadcntamov.ccodofi = lccodofi
                    entidadcntamov.cflc = " "
                    entidadcntamov.dfeccnt = ldfecha
                    entidadcntamov.dfecmod = ldfecha
                    entidadcntamov.ccodusu1 = Session("gccodusu")
                    entidadcntamov.ffondos = "01"
                    entidadcntamov.cclase = Left(lcctabco, 1)
                    entidadcntamov.cpoliza = "RT"
                    ecntamov.agregarCntamov(entidadcntamov)


                    'Agregara un movimiento adicional
                    Dim lnDecimal As Double
                    Dim lcletras As String = ""

                    lcletras = ConversionLetras.ConversionEnteros(lnretiro)
                    lnDecimal = clsConvert.ExtraeDecimales(lnretiro.ToString.Trim)
                    lcletras = lcletras.Trim & " " & lnDecimal.ToString & "/100"

                    entidadCtbdChq.cnumcom = lcnumpar
                    eCtbdchq.ObtenerCtbdchq(entidadCtbdChq)

                    entidadCtbdChq.cnumcom = lcnumpar
                    entidadCtbdChq.cmonchq = lnretiro
                    entidadCtbdChq.cnomchq = txtcnomchq.Text.Trim
                    entidadCtbdChq.cnrochq = txtnroche.Text.Trim
                    entidadCtbdChq.cnomcta = " "
                    entidadCtbdChq.dfeccnt2 = Session("gdfecsis")
                    'entidadCtbdChq.ccodbco = ddlbancos.SelectedValue.Trim
                    entidadCtbdChq.ccodbco = Cbx_ctaBco1.SelectedValue.Trim
                    entidadCtbdChq.cflc = " "
                    entidadCtbdChq.lprint = True
                    entidadCtbdChq.ccoddeb = " "
                    entidadCtbdChq.ccodhab = " "
                    entidadCtbdChq.cctacte = lcctacte
                    entidadCtbdChq.cmonlet = lcletras

                    eCtbdchq.Agregar(entidadCtbdChq)
                    comprobante_Button.Visible = True
                End If


                'If RadioButton1.Checked = True Then
                '    imprimir_lineas(lccodaho)
                'End If
                btnimprimir.Enabled = True

                ParaImprimir()
                'Recibo()

                If chkcheque.Checked = True Then
                    global_cnumcom = lcnumpar
                    'Response.Write("<script language='javascript'>alert('Ok, Imprima Voucher N�:  " & lcnumpar & " ')</script>")
                    codigoJs = "<script language='javascript'>alert('Ok, Imprima Voucher N�:  " & lcnumpar & " '"

                    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                Else
                    'Response.Write("<script language='javascript'>alert('ok, Imprima Recibo')</script>")
                    codigoJs = "<script language='javascript'>alert('Proceso correcto, Imprima Recibo, " & _
                           "Aviso SIM.NET ')</script>"

                    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                End If

                ' cancela()
                'control1 = 0
                HiddenField1.Value = 0
            Catch ex As Exception
                'Response.Write("<script language='javascript'>alert('No se completo operacion de grabado')</script>")
                codigoJs = "<script language='javascript'>alert('No se completo operacion de grabado, " & _
                           "Aviso SIM.NET ')</script>"

                ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            End Try
        Else
            'Response.Write("<script language='javascript'>alert('Cuenta vacia o deposito nulo')</script>")
            codigoJs = "<script language='javascript'>alert('Cuenta vacia o deposito nulo, " & _
                           "Aviso SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)

        End If
        Session("fuente") = "0"
        Button1.Enabled = False
        chkcheque.Checked = False
        btnlibreta.Focus()
        '    Me.Deshabilitado()
    End Sub

    Protected Sub btncancela_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancela.Click
        cancela()
    End Sub

    Protected Sub btnaplicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnaplicar.Click
        'escondido_TextBox.Text = 0
        HiddenField1.Value = 0
        btnprogra.Visible = False
        comprobante_Button.Visible = False
        Me.Button1.Enabled = False
        Dim lccodaho As String
        Dim mclimide As New cClimide
        Dim eclimide As New climide
        Dim mahomcta As New cAhomcta
        Dim eahomcta As New ahomcta
        'Dim lccodcli As String
        Dim ldfecha As Date
        lccodaho = Me.txtcodcta.Text.Trim
        If lccodaho.Trim = "" Or lccodaho.Trim.Length <> 14 Then
            Exit Sub
        End If
        Me.verificalavado.Text = "0"
        eahomcta.ccodaho = lccodaho
        mahomcta.ObtenerAhomcta(eahomcta)
        Me.txtcodcli.Text = eahomcta.cnudotr
        Me.txtsaldo.Text = eahomcta.nsaldoaho
        Me.txtrestringido.Text = eahomcta.nmonres
        Me.txtlibreta.Text = eahomcta.nlibreta


        'Verifica esta de la cuenta para entrar
        If eahomcta.cestado <> "A" Then
            codigoJs = "<script language='javascript'>alert('La cuenta no se encuentra activa, " & _
                          "Advertencia SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            Exit Sub
        End If

        eclimide.ccodcli = Me.txtcodcli.Text.Trim
        mclimide.ObtenerClimide(eclimide)
        Me.txtnomcli.Text = eclimide.cnomcli

        ldfecha = Session("GDFECSIS")
        Me.txtfecha.Text = ldfecha.ToString

        ddltipaho.SelectedValue = txtcodcta.Text.Substring(6, 2)

        'Obtiene Cuenta de Aportaciones
        Dim lnsalapo As Double = 0
        lnsalapo = mahomcta.Aportaciones(txtcodcli.Text.Trim)
        txttotaporta.Text = lnsalapo
        Dim lnmoraaporta As Decimal = 0
        Dim clase As New class1
        'lnmoraaporta = clase.Moraaportaciones(txtcodcli.Text.Trim, Session("gdfecsis"))

        txtmoraaporta.Text = lnmoraaporta

        txtdepositos.Text = ObtenerDepositos()


        Dim pnsaldoAho As Double = 0

        pnsaldoAho = omclass.Extraer_Saldo_Cta_Ahorro(Me.txtcodcta.Text.Trim)

        If pnsaldoAho <= 0 Then
            codigoJs = "<script language='javascript'>alert('La cuenta no posee Saldo " & _
                       "Advertencia SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            Me.Button1.Enabled = False
            Exit Sub
            'Else
            '    Me.Button1.Enabled = True
        End If



        Session("fuente") = "1"
        '-------------verifica meses de bloqueo para ahorro navide�o y educativo
        If lccodaho.Substring(6, 2) = "08" And Month(Session("gdfecsis")) <> 12 Then
            Session("codigo") = Session("GCSUPERUSU")
            Session("fuente") = "0"
            'Response.Write("<script language='javascript'>alert('Retiro de Ahorro Navide�o en Mes Incorrecto')</script>")
            'Response.Write("<script>window.open('wfAcceso.aspx','cal', 'location=1, toolbar = no, status=1,width=350,height=350')</script>")

            codigoJs = "<script language='javascript'>alert('Retiro de Ahorro Navide�o en Mes Incorrecto " & _
                       "Advertencia SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)

            codigoJs = "<script>window.open('wfAcceso.aspx','cal', 'location=1, toolbar = no, status=1,width=350,height=350')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
        End If
        'If lccodaho.Substring(6, 2) = "04" And (Month(Session("gdfecsis")) >= 3) Then
        '    Session("codigo") = "9999"
        '    Session("fuente") = "0"
        '    'Response.Write("<script language='javascript'>alert('Retiro de Ahorro Educativo en Mes Incorrecto')</script>")
        '    'Response.Write("<script>window.open('wfAcceso.aspx','cal', 'location=1, toolbar = no, status=1,width=350,height=350')</script>")

        '    codigoJs = "<script language='javascript'>alert('Retiro de Ahorro Educativo en Mes Incorrecto " & _
        '               "Advertencia SIM.NET ')</script>"

        '    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)

        '    codigoJs = "<script>window.open('wfAcceso.aspx','cal', 'location=1, toolbar = no, status=1,width=350,height=350')</script>"

        '    ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
        'End If
        If lccodaho.Substring(6, 2) = "06" Then
            Session("codigo") = Session("GCSUPERUSU")

            Session("fuente") = "0"
            'Response.Write("<script language='javascript'>alert('No puede retirar de aportaciones, sin autorizaci�n.')</script>")
            'Response.Write("<script>window.open('wfAcceso.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=300')</script>")

            codigoJs = "<script language='javascript'>alert('No puede retirar de aportaciones, sin autorizaci�n " & _
                       "Advertencia SIM.NET ')</script>"

            'ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)

            codigoJs = "<script>window.open('wfAcceso.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=300')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
        End If

        If Session("fuente") = "1" Then 'Habilitar

            Dim a As Integer = 0
            a = 1
            Me.Habilitado()
            verificar()
        End If

        


    End Sub

    Protected Sub btnimprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnimprimir.Click
        Recibo()
    End Sub

    Private Sub imprimir_lineas(ByVal cuenta As String)


        Dim miclase As New clase_jaime
        Dim miclase1 As New clase_funciones
        Dim salto_pagina As Boolean = False
        Dim dt As DataTable
        Dim fila As DataRow


        Dim con As New SqlConnection
        Dim stringconnection As String = miclase.conexion()
        Dim str_select As String = ""
        con.ConnectionString = stringconnection

        con.Open()

        salto_pagina = miclase1.habra_cambio_pagina(con, cuenta)

        If salto_pagina = True Then
            Session("fuente") = "Habr� cambio de  libreta " + Chr(13) + "Se imprimiran primero las lineas antiguas y luego las nuevas en la libreta nueva" + Chr(13) + "deber� hacer clic al boton de impresion"
            'Response.Write("<script>window.open('Mensaje.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=130')</script>")
            codigoJs = "<script>window.open('Mensaje.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=130')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)

        End If

        dataset_lineas.Clear()
        dataset_lineas = miclase1.devolver_dataset_lineas_libreta_imprimir(con, cuenta)

        dt = dataset_lineas.Tables(0)

        Dim fecha As String = ""
        Dim ctipope As String = ""
        For Each fila In dt.Rows
            fecha = fila("dfecope")
            ctipope = fila("ctipope")
            If fila("nnum") > 0 Then
                str_select = "set language spanish; update ahommov set clinea = 'S' where clinea = 'N' and ccodaho = " & miclase1.ToString(cuenta) & " and " & _
                             "ctipope = " & miclase1.ToString(ctipope) & " and  dfecope = " & miclase1.ToString(fecha)
                miclase.nonquery_sin_parametros(con, str_select)
            End If

        Next


        con.Close()


        ImprimeLineas(dataset_lineas)
    End Sub

    Private Sub ImprimeLineas(ByVal ds As DataSet)
        Dim crRpt As New ReportDocument
        Dim rptStream As New System.IO.MemoryStream

        Try
            'Cargar Definicion del Reporte

            crRpt.Load(Server.MapPath("reportes") + "\libreta.rpt", OpenReportMethod.OpenReportByDefault)
        Catch ex As Exception
            Return
        End Try

        ' Setear los registros recuperados, diciendole el Table respectivo
        crRpt.SetDataSource(ds.Tables(0))
        crRpt.Refresh()

        Dim reportes As String
        reportes = "libreta.pdf"

        rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
        '>>>>
        '<<<<
        Response.Clear()
        Response.Buffer = True
        ' Establece el tipo de documento
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(rptStream.ToArray())
        Response.AddHeader("Content-Disposition", "attachment;filename=" + reportes)
        Response.Flush()
        Response.Close()

    End Sub

    Private Sub print_lineas(ByVal sender As Object, _
                               ByVal e As PrintPageEventArgs)


        Dim miclase1 As New clase_funciones
        Dim prtFont As New Font("Arial", 9, FontStyle.Regular)

        e.HasMorePages = False

        Dim lineHeight As Single
        Dim yPos As Single = 30
        Dim leftMargin As Single = 1
        Dim printFont As System.Drawing.Font
        ' Asignar el tipo de letra
        printFont = prtFont
        lineHeight = printFont.GetHeight(e.Graphics)

        Dim dep As Decimal, ret As Decimal, sal As Decimal
        Dim fila As DataRow
        Dim dfecope As Date, nmonto As Decimal, ctipope As String, nsaldoaho As Decimal
        Dim clinea As String, nnum As Integer, primera As Boolean = True

        Dim veces As Integer = 0

        For Each fila In dataset_lineas.Tables(0).Rows
            nnum = fila("nnum")
            dfecope = fila("dfecope")
            nmonto = fila("nmonto")
            ctipope = fila("ctipope")
            nsaldoaho = fila("nsaldoaho")
            clinea = fila("clinea")

            'este es el margen superior
            If nnum = 1 And clinea = "N" Then
                For m = 1 To 9 'este es el margen superior
                    yPos += lineHeight
                    e.Graphics.DrawString("    ", printFont, Brushes.Black, leftMargin, yPos)
                Next
            End If

            'ajustar la primera impresion
            If nnum > 1 And clinea = "N" And primera = True Then
                For m = 1 To 9 'este es el margen superior
                    yPos += lineHeight
                    e.Graphics.DrawString("    ", printFont, Brushes.Black, leftMargin, yPos)
                Next

                For m = 1 To nnum - 1 'ajustar la primera impresion
                    yPos += lineHeight
                    e.Graphics.DrawString("    ", printFont, Brushes.Black, leftMargin, yPos)
                Next
                primera = False
            End If

            If clinea = "N" Then
                sal = nsaldoaho
                If ctipope = "D" Then
                    dep = nmonto
                    ret = 0.0
                Else
                    dep = 0.0
                    ret = nmonto
                End If
                yPos += lineHeight
                e.Graphics.DrawString("    " & Left(dfecope.ToString, 10), printFont, Brushes.Black, 15, yPos)
                e.Graphics.DrawString("    " & miclase1.mascara_numerica(ret), printFont, Brushes.Black, 180, yPos)
                e.Graphics.DrawString("    " & miclase1.mascara_numerica(dep), printFont, Brushes.Black, 320, yPos)
                e.Graphics.DrawString("    " & miclase1.mascara_numerica(sal), printFont, Brushes.Black, 450, yPos)
                veces = veces + 1
            End If

            If nnum = 65 And clinea = "N" Then
                fila("clinea") = "S"
                e.HasMorePages = True

                Exit Sub
            End If

            fila("clinea") = "S"

        Next

        If veces = 0 Then
            'MsgBox("No Hay Ninguna Transaccion Pendiente que Imprimir", MsgBoxStyle.Information, "Administrador SIM.NET")
            codigoJs = "<script language='javascript'>alert('No Hay Ninguna Transaccion Pendiente que Imprimir, " & _
                        "Advertencia SIM.NET ')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
        End If

    End Sub

    Protected Sub btnverificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnverificar.Click
        verificar()
    End Sub
    Private Sub verificar()
        Session("codigo") = Me.txtcodcli.Text.Trim
        Session("fuente") = Me.txtcodcta.Text.Trim
        'Response.Write("<script>window.open('wffotofirma.aspx','cal', 'location=1, toolbar = no, status=1,width=850,height=530')</script>")
        codigoJs = "<script>window.open('wffotofirma.aspx','cal', 'location=1, toolbar = no, status=1,width=850,height=530')</script>"

        ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
    End Sub
    Private Sub Recibo()
        If txtcodcta.Text.Trim <> "" Then
            Dim crRpt As New ReportDocument
            Dim rptStream As New System.IO.MemoryStream
            Dim reportes As String = "crDeposito.pdf"
            crRpt.Load(Server.MapPath("reportes") + "\crRetiro.rpt", OpenReportMethod.OpenReportByDefault)

            Dim dtrecibo As New DataTable
            Dim eahommov As New cAhommov
            dtrecibo = eahommov.ObtenerMovimientoAhorro(Me.txtcodcta.Text.Trim, "RT", Date.Parse(txtfecha.Text), txtnrodoc.Text.Trim)
            'Obtiene el movimiento que se ha generado

            Dim lcnumdoc As String = ""
            Dim lccodaho As String = ""
            Dim ldfecha As Date = Today

            Dim lnefectivo As Double = 0
            Dim lncheque As Double = 0
            Dim lnotros As Double = 0
            Dim lntotal As Double = 0
            Dim lcletras As String = ""
            Dim lcobserva As String = ""
            Dim lcnombre As String = ""


            If dtrecibo.Rows.Count = 0 Then
                Exit Sub
            Else
                lcnumdoc = dtrecibo.Rows(0)("cnumdoc")
                lccodaho = txtcodcta.Text.Trim
                ldfecha = Date.Parse(txtfecha.Text)
                lnefectivo = Double.Parse(txtmonto.Text)
                lncheque = 0
                lnotros = 0
                lntotal = lnefectivo + lncheque + lnotros
                lcobserva = txtobserva.Text.Trim
                lcnombre = txtnomcli.Text.Trim

                Dim lcmonlet As String = " "
                Dim lndecimal As Integer = 0

                lcletras = clsConvert.ConversionEnteros(lntotal)
                lndecimal = clsConvert.ExtraeDecimales(lntotal)
                lcletras = lcletras.Trim & " " & lndecimal.ToString & "/100" & " PESOS"

            End If
            Dim lctipoaho As String = ""
            Dim etabttab As New cTabttab
            Dim etabtusu As New cTabtusu
            Dim lcnomusu As String = ""
            lcnomusu = etabtusu.usuario(Session("gcCodusu"))

            lctipoaho = etabttab.Describe(Mid(lccodaho, 7, 2), "186").Trim


            'crRpt.SetDataSource(dtrecibo)
            crRpt.Refresh()


            crRpt.SetParameterValue("cnombre", lcnombre)
            crRpt.SetParameterValue("cnumdoc", lcnumdoc)
            crRpt.SetParameterValue("ccodaho", lccodaho)
            crRpt.SetParameterValue("dfecha", ldfecha)
            crRpt.SetParameterValue("nefectivo", lnefectivo)
            crRpt.SetParameterValue("ncheque", lncheque)
            crRpt.SetParameterValue("notros", lnotros)
            crRpt.SetParameterValue("ntotal", lntotal)
            crRpt.SetParameterValue("cobserva", lcobserva)
            crRpt.SetParameterValue("cletras", lcletras)
            crRpt.SetParameterValue("ccodusu", Session("gccodusu"))
            crRpt.SetParameterValue("tipo_cuenta", lctipoaho)
            crRpt.SetParameterValue("socio", txtcodcli.Text.Trim)
            crRpt.SetParameterValue("cnomusu", lcnomusu)

            'crRpt.PrintToPrinter(1, False, 0, 0)

            rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
            Response.Clear()
            Response.Buffer = True


            ' Establece el tipo de documento
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(rptStream.ToArray())
            Response.AddHeader("Content-Disposition", "attachment;filename=" & reportes)
            Response.Flush()
            Response.Close()

        End If
    End Sub

    Protected Sub btnhabilitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnhabilitar.Click
        If Session("fuente") = "1" Then 'Habilitar
            Dim a As Integer = 0
            a = 1
            Me.Habilitado()
        End If

    End Sub
    Private Function ObtenerDepositos() As Decimal
        Dim clsppal As New class1
        Dim ldfecini As Date
        Dim lccodaho As String = ""
        Dim eahomcta As New cAhomcta
        Dim ds As New DataSet
        Dim lndepositos As Decimal = 0
        ldfecini = DateAdd(DateInterval.Day, -30, Session("gdfecsis"))
        'Obtiene codigo de cuenta de ahorro
        lndepositos = clsppal.ObtenerSumadeDepositos(txtcodcli.Text.Trim, ldfecini)


        Return lndepositos
    End Function

    Protected Sub txtmonto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmonto.TextChanged
        If Me.verificalavado.Text = "0" Then
            Dim lndepositos As Decimal = 0
            lndepositos = Double.Parse(txtdepositos.Text)

            lndepositos = lndepositos + Double.Parse(txtmonto.Text)

            If (Double.Parse(txtmonto.Text) >= 5000.0 And Double.Parse(txtmonto.Text) <= 57000) Or (lndepositos > 57000) Then
                'MsgBox("Los Depositos Realizados a 30 d�as Superan el Limite de LAVADO " + Chr(13) + "DE DINERO Permitido, Esta Advertencia Debe de ser Trasladada  " + Chr(13) + "al Jefe de Mercadeo ,para que LLene el Formulario Correspondiante y sea Enviado a LA FISCALIA DE LA REPUBLICA ", MsgBoxStyle.Information)
                'Response.Write("<script language='javascript'>alert('Los Depositos Realizados a 30 d�as Superan el Limite de LAVADO ' + CHR(13) + 'DE DINERO Permitido, Esta Advertencia Debe de ser Trasladada al Jefe de Mercadeo ' + CHR(13) + 'Para que LLene el Formulario Correspondiante y sea Enviado a LA FISCALIA DE LA REPUBLICA ')</script>")
                Session("fuente") = "Los Depositos Realizados a 30 d�as Superan el Limite de LAVADO " + Chr(13) + "DE DINERO Permitido, Esta Advertencia Debe de ser Trasladada  " + Chr(13) + "al Jefe de Mercadeo ,para que LLene el Formulario Correspondiante y sea Enviado a LA FISCALIA DE LA REPUBLICA"
                'Response.Write("<script>window.open('Mensaje.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=230')</script>")
                codigoJs = "<script>window.open('Mensaje.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=230')</script>"

                ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
                btnprogra.Visible = True
                'lavado()
                Me.verificalavado.Text = "1"
            End If

        Else
            btnprogra.Visible = False
        End If
        btnlibreta.Focus()
    End Sub

    Private Sub lavado()
        '        Try

        Dim origen As String
        Dim Destino As String
        Dim lcnomcli As String = ""
        Dim ldnacimi As Date = Session("gdfecsis")
        Dim lcsexo As String = ""
        Dim lcdui As String = ""
        Dim lcteldom As String = ""
        Dim lccelular As String = ""
        Dim lccodpro As String = ""
        Dim lcprofesion As String = ""
        Dim lcestciv As String = ""
        Dim lccivil As String = ""
        Dim lcdirdom As String = ""
        Dim etabtprf As New cTabtprf
        Dim entidadtabtprf As New tabtprf
        Dim eclimide As New cClimide
        Dim entidadclimide As New climide
        Dim etabttab As New cTabttab
        Dim ds As New DataSet


        ds = eclimide.ObtenerDatosClimide(txtnomcli.Text.Trim)

        origen = Session("codigo")
        Destino = Session("fuente")


        entidadclimide.ccodcli = txtcodcli.Text.Trim
        eclimide.ObtenerClimide(entidadclimide)

        lcnomcli = entidadclimide.cnomcli.Trim
        ldnacimi = entidadclimide.dnacimi
        lcsexo = entidadclimide.csexo
        lcdui = entidadclimide.cnudoci
        lcteldom = entidadclimide.cteldom
        lccelular = entidadclimide.cTelFam
        lccodpro = entidadclimide.ccodpro
        lcestciv = entidadclimide.cestciv
        lccivil = etabttab.Describe(lcestciv, "012")
        lcdirdom = entidadclimide.cdirdom

        entidadtabtprf.ccodigo = lccodpro
        etabtprf.ObtenerTabtprf(entidadtabtprf)

        lcprofesion = entidadtabtprf.cdescri


        Dim crRpt As New ReportDocument
        Dim rptStream As New System.IO.MemoryStream


        Try
            'Cargar Definicion del Reporte
            If Double.Parse(txtmonto.Text) >= 5000 And Double.Parse(txtmonto.Text) <= 57000 Then
                crRpt.Load(Server.MapPath("reportes") + "\CrLavado.rpt", OpenReportMethod.OpenReportByDefault)
            Else
                crRpt.Load(Server.MapPath("reportes") + "\CrLavado2.rpt", OpenReportMethod.OpenReportByDefault)
            End If

        Catch ex As Exception
            Me.AsignarMensaje("Error: Al cargar el archivo. " + ex.Message.ToString, True)
            Return
        End Try

        ' Setear los registros recuperados, diciendole el Table respectivo
        crRpt.SetDataSource(ds.Tables(0))
        crRpt.Refresh()

        crRpt.SetParameterValue("pcorigen", origen)
        crRpt.SetParameterValue("pcdestino", Destino)

        crRpt.SetParameterValue("id1", "")
        crRpt.SetParameterValue("id2", "")
        crRpt.SetParameterValue("id3", "")
        crRpt.SetParameterValue("id4", "")
        crRpt.SetParameterValue("id5", "")
        crRpt.SetParameterValue("id6", "X")
        crRpt.SetParameterValue("id7", "")

        crRpt.SetParameterValue("nmonto1", 0)
        crRpt.SetParameterValue("nmonto2", 0)
        crRpt.SetParameterValue("nmonto3", 0)
        crRpt.SetParameterValue("nmonto4", 0)
        crRpt.SetParameterValue("nmonto5", 0)
        crRpt.SetParameterValue("nmonto6", Double.Parse(txtmonto.Text))
        crRpt.SetParameterValue("nmonto7", 0)

        crRpt.SetParameterValue("pccodcli", txtcodcli.Text.Trim)
        crRpt.SetParameterValue("pcnomcli", lcnomcli)
        crRpt.SetParameterValue("pdnacimi", ldnacimi)
        crRpt.SetParameterValue("pcsexo", lcsexo)
        crRpt.SetParameterValue("pcdui", lcdui)
        crRpt.SetParameterValue("pcteldom", (lcteldom + " " + lccelular))
        crRpt.SetParameterValue("pcprofesion", lcprofesion)
        crRpt.SetParameterValue("pccivil", lccivil)
        crRpt.SetParameterValue("pcdirdom", lcdirdom)

        Dim reportes As String

        reportes = "Lavado.pdf"

        rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
        '>>>>
        '<<<<
        Response.Clear()
        Response.Buffer = True
        ' Establece el tipo de documento
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(rptStream.ToArray())
        Response.AddHeader("Content-Disposition", "attachment;filename=" + reportes)
        Response.Flush()
        Response.Close()

        '       Catch ex As Exception

        '      End Try

    End Sub

    Protected Sub btnprogra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprogra.Click
        lavado()
    End Sub

    Protected Sub btnlibreta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlibreta.Click
        If txtcodcta.Text.Trim <> "" Then
            Dim lccodaho As String = ""
            lccodaho = txtcodcta.Text.Trim
            imprimir_lineas(lccodaho)
        End If

    End Sub

    Protected Sub chkcheque_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkcheque.CheckedChanged
        activarcheque()
    End Sub

    Protected Sub comprobante_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles comprobante_Button.Click

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim miclase As New clase_jaime
        Dim miclase1 As New clase_funciones
        Dim con As New SqlConnection
        Dim stringconnection As String = miclase.conexion()
        Dim str_select As String = ""

        con.ConnectionString = stringconnection
        con.Open()
        str_select = "select dia.cnumcom, mov.cnumlin as idcuenta, cta.cdescrip, mov.ccodcta, mov.ndebe, mov.nhaber, " & _
              "mov.ffondos, mov.dfeccnt as dfecdoc, dia.cglosa, dia.ccodofi " & _
              "from diario as dia, cntamov as mov, ctbmcta as cta " & _
              "where dia.cnumcom = " & miclase1.ToString(global_cnumcom) & " and dia.cnumcom = mov.cnumcom and mov.ccodcta = cta.ccodcta "
        ds = miclase.devolver_dataset(con, str_select)
        imprimirpartida(ds)
        con.Close()
    End Sub
    Private Sub imprimirpartida(ByVal ds As DataSet)


        Try
            'Imprime la Reversi�n >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>><
            Dim crRpt As New ReportDocument
            Dim rptStream As New System.IO.MemoryStream

            Try
                'Cargar Definicion del Reporte
                crRpt.Load(Server.MapPath("reportes") + "\RptPartida.rpt", OpenReportMethod.OpenReportByDefault)
            Catch ex As Exception
                Return
            End Try




            ' Setear los registros recuperados, diciendole el Table respectivo
            crRpt.SetDataSource(ds.Tables(0))
            crRpt.Refresh()

            '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Dim reportes As String
            reportes = "RptPartida.pdf"

            Dim lcfondos As String = "Cheque No. " & txtnroche.Text.Trim
            Dim lcusuario As String = Session("gccodusu")

            Dim lcpoliza As String
            lcpoliza = "12"

            crRpt.SetParameterValue("cfondos", lcfondos.Trim)
            crRpt.SetParameterValue("cpoliza", lcpoliza.Trim)
            crRpt.SetParameterValue("usuario", lcusuario.Trim)

            rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
            '>>>>
            '<<<<
            Response.Clear()
            Response.Buffer = True
            ' Establece el tipo de documento
            Response.ContentType = "application/pdf"
            Response.BinaryWrite(rptStream.ToArray())
            Response.AddHeader("Content-Disposition", "attachment;filename=" + reportes)
            Response.Flush()
            Response.Close()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_rec_direct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_rec_direct.Click
        Dim mUsuarios As New cusuarios
        Dim user As String = ""
        Dim ofi As String = ""
        Dim rep As String = ""

        user = Session("gccodusu").ToString()
        ofi = mUsuarios.Oficina(user).Trim()
        rep = "*"

        rep = ImpresionReciboDirect()

        If rep = "*" Then
            Return
        Else
            'Response.Write("<script>window.open('Print.aspx?user=" + Session("gccodusu").ToString() + "&ofi=" + ofi + "&rep=" + rep + "','cal', 'location=1, toolbar = no, status=1,width=550,height=230')</script>")
            codigoJs = "<script language='javascript'>window.open('Print.aspx?user=" + Session("gccodusu").ToString() + "&ofi=" + ofi + "&rep=" + rep + "','cal', 'location=1, toolbar = no, status=1,width=550,height=230')</script>"
            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            Exit Sub
        End If
    End Sub

    Private Function ImpresionReciboDirect() As String
        If txtcodcta.Text.Trim <> "" Then
            Dim crRpt As New ReportDocument
            Dim rptStream As New System.IO.MemoryStream
            Dim reportes As String = "crDeposito.pdf"
            crRpt.Load(Server.MapPath("reportes") + "\crRetiro.rpt", OpenReportMethod.OpenReportByDefault)

            Dim dtrecibo As New DataTable
            Dim eahommov As New cAhommov
            dtrecibo = eahommov.ObtenerMovimientoAhorro(Me.txtcodcta.Text.Trim, "RT", Date.Parse(txtfecha.Text), txtnrodoc.Text.Trim)
            'Obtiene el movimiento que se ha generado

            Dim lcnumdoc As String = ""
            Dim lccodaho As String = ""
            Dim ldfecha As Date = Today

            Dim lnefectivo As Double = 0
            Dim lncheque As Double = 0
            Dim lnotros As Double = 0
            Dim lntotal As Double = 0
            Dim lcletras As String = ""
            Dim lcobserva As String = ""
            Dim lcnombre As String = ""


            If dtrecibo.Rows.Count = 0 Then
                Exit Function
            Else
                lcnumdoc = dtrecibo.Rows(0)("cnumdoc")
                lccodaho = txtcodcta.Text.Trim
                ldfecha = Date.Parse(txtfecha.Text)
                lnefectivo = Double.Parse(txtmonto.Text)
                lncheque = 0
                lnotros = 0
                lntotal = lnefectivo + lncheque + lnotros
                lcobserva = txtobserva.Text.Trim
                lcnombre = txtnomcli.Text.Trim

                Dim lcmonlet As String = " "
                Dim lndecimal As Integer = 0

                lcletras = clsConvert.ConversionEnteros(lntotal)
                lndecimal = clsConvert.ExtraeDecimales(lntotal)

                If lndecimal >= 10 Then
                    lcletras = lcletras.Trim & " " & lndecimal.ToString & "/100 DOLARES DE LOS ESTADOS UNIDOS DE AMERICA"
                Else
                    lcletras = lcletras.Trim & " 0" & lndecimal.ToString & "/100 DOLARES DE LOS ESTADOS UNIDOS DE AMERICA"
                End If

                'lcletras = lcletras.Trim & " " & lndecimal.ToString & "/100" & " DOLARES"

            End If
            Dim lctipoaho As String = ""
            Dim etabtusu As New cTabtusu
            Dim lcnomusu As String = ""
            lcnomusu = etabtusu.usuario(Session("gcCodusu"))

            Dim etabttab As New cTabttab
            lctipoaho = etabttab.Describe(Mid(lccodaho, 7, 2), "186").Trim


            'crRpt.SetDataSource(dtrecibo)
            crRpt.Refresh()


            crRpt.SetParameterValue("cnombre", lcnombre)
            crRpt.SetParameterValue("cnumdoc", lcnumdoc)
            crRpt.SetParameterValue("ccodaho", lccodaho)
            crRpt.SetParameterValue("dfecha", ldfecha)
            crRpt.SetParameterValue("nefectivo", lnefectivo)
            crRpt.SetParameterValue("ncheque", lncheque)
            crRpt.SetParameterValue("notros", lnotros)
            crRpt.SetParameterValue("ntotal", lntotal)
            crRpt.SetParameterValue("cobserva", lcobserva)
            crRpt.SetParameterValue("cletras", lcletras)
            crRpt.SetParameterValue("ccodusu", Session("gccodusu"))
            crRpt.SetParameterValue("tipo_cuenta", lctipoaho)
            crRpt.SetParameterValue("socio", txtcodcli.Text.Trim)
            crRpt.SetParameterValue("cnomusu", lcnomusu)

            'crRpt.PrintToPrinter(1, False, 0, 0)

            'rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
            'Response.Clear()
            'Response.Buffer = True


            ' Establece el tipo de documento
            'Response.ContentType = "application/pdf"
            'Response.BinaryWrite(rptStream.ToArray())
            'Response.AddHeader("Content-Disposition", "attachment;filename=" & reportes)
            'Response.Flush()
            'Response.Close()

            Dim reporte As String = ""
            reporte = GuardarWord(crRpt)

            btnlibreta.Focus()
            Return reporte
        End If

    End Function

    Public Function GuardarWord(ByRef crrpt As ReportDocument) As String
        ' Crear el Directorio Temporal de los Archivos si es que no existe
        Dim mUsuarios As New cusuarios
        Dim ofi As String = ""
        Dim user As String = ""
        Dim rep As String = ""
        Dim exis As Boolean = True
        Dim complemento As String = ""
        Dim dir_completa As String = ""

        Try
            user = Session("gccodusu").ToString.Trim.ToUpper
            ofi = mUsuarios.Oficina(user).Trim

            ' Crear un nombre aleatorio y buscar si ya existe, si existe crear otro que no exista
            Do While exis = True
                rep = Guid.NewGuid.ToString("D")
                complemento = "\" + ofi + "\" + user + "\" + rep + ".doc"

                If File.Exists(Server.MapPath("Impresiones") + complemento) Then
                    exis = True
                Else
                    Directory.CreateDirectory(Server.MapPath("Impresiones") + "\" + ofi + "\" + user)
                    exis = False
                End If
            Loop

            dir_completa = Server.MapPath("Impresiones") + complemento
            crrpt.ExportToDisk(ExportFormatType.WordForWindows, dir_completa)
        Catch ex As Exception
            rep = "*"
        End Try

        Return rep
    End Function

    Protected Sub btnlib_direct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlib_direct.Click
        Dim mUsuarios As New cusuarios
        Dim user As String = ""
        Dim ofi As String = ""
        Dim rep As String = ""

        user = Session("gccodusu").ToString()
        ofi = mUsuarios.Oficina(user).Trim()
        rep = "*"

        If txtcodcta.Text.Trim <> "" Then
            Dim lccodaho As String = ""
            lccodaho = txtcodcta.Text.Trim
            rep = imprimir_lineasDirect(lccodaho)
        End If

        If rep = "*" Then
            Return
        Else
            codigoJs = "<script language='javascript'>window.open('Print.aspx?user=" + Session("gccodusu").ToString() + "&ofi=" + ofi + "&rep=" + rep + "','cal', 'location=1, toolbar = no, status=1,width=550,height=230')</script>"
            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)
            Exit Sub
        End If
    End Sub

    Private Function imprimir_lineasDirect(ByVal cuenta As String) As String
        Dim miclase As New clase_jaime
        Dim miclase1 As New clase_funciones
        Dim salto_pagina As Boolean = False
        Dim dt As DataTable
        Dim fila As DataRow


        Dim con As New SqlConnection
        Dim stringconnection As String = miclase.conexion()
        Dim str_select As String = ""
        con.ConnectionString = stringconnection

        con.Open()

        salto_pagina = miclase1.habra_cambio_pagina(con, cuenta)

        If salto_pagina = True Then
            Session("fuente") = "Habr� cambio de  libreta " + Chr(13) + "Se imprimiran primero las lineas antiguas y luego las nuevas en la libreta nueva" + Chr(13) + "deber� hacer clic al boton de impresion"
            'Response.Write("<script>window.open('Mensaje.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=130')</script>")
            codigoJs = "<script>window.open('Mensaje.aspx','cal', 'location=1, toolbar = no, status=1,width=550,height=130')</script>"

            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "tempJS", codigoJs, False)

        End If

        dataset_lineas.Clear()
        dataset_lineas = miclase1.devolver_dataset_lineas_libreta_imprimir(con, cuenta)

        dt = dataset_lineas.Tables(0)

        Dim fecha As String = ""
        Dim ctipope As String = ""
        For Each fila In dt.Rows
            fecha = fila("dfecope")
            ctipope = fila("ctipope")
            If fila("nnum") > 0 Then
                str_select = "set language spanish; update ahommov set clinea = 'S' where clinea = 'N' and ccodaho = " & miclase1.ToString(cuenta) & " and " & _
                             "ctipope = " & miclase1.ToString(ctipope) & " and  dfecope = " & miclase1.ToString(fecha)
                miclase.nonquery_sin_parametros(con, str_select)
            End If

        Next

        con.Close()
        Return ImprimeLineasDirect(dataset_lineas)
    End Function

    Private Function ImprimeLineasDirect(ByVal ds As DataSet) As String
        Dim crRpt As New ReportDocument
        Dim rptStream As New System.IO.MemoryStream

        Try
            'Cargar Definicion del Reporte

            crRpt.Load(Server.MapPath("reportes") + "\libreta.rpt", OpenReportMethod.OpenReportByDefault)
        Catch ex As Exception
            Return "*"
        End Try

        ' Setear los registros recuperados, diciendole el Table respectivo
        crRpt.SetDataSource(ds.Tables(0))
        crRpt.Refresh()

        Dim nomrep As String = "*"
        nomrep = GuardarWord(crRpt)
        Return nomrep

        'Dim reportes As String
        'reportes = "libreta.pdf"

        'rptStream = CType(crRpt.ExportToStream(ExportFormatType.PortableDocFormat), System.IO.MemoryStream)
        '>>>>
        '<<<<
        'Response.Clear()
        'Response.Buffer = True
        ' Establece el tipo de documento
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(rptStream.ToArray())
        'Response.AddHeader("Content-Disposition", "attachment;filename=" + reportes)
        'Response.Flush()
        'Response.Close()
    End Function

    Protected Sub CbxBancos1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbxBancos1.SelectedIndexChanged
        Cbx_ctaBco1.Items.Clear()
        Cbx_ctaBco1.Recuperar(CbxBancos1.SelectedValue)
    End Sub
End Class


