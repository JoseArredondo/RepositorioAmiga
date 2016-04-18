Public Class ucliquida
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtcodcta As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtnomcli As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgClientes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgcreditos As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtdeuda As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtahorros As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlcajero As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnaplicar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btngraba As System.Web.UI.HtmlControls.HtmlInputButton

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    'retorna codigo de cliente
    Public Sub CargarDatosPorCuenta(ByVal cuenta As String)
        Me.txtcodcta.Text = cuenta
        Me.btnaplicar_ServerClick(Me, New System.EventArgs)
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            cargar()
        End If
    End Sub

    Sub cargar()
        Dim clstabttab As New SIM.BL.cTabttab
        Dim mListaTabttab As New listatabttab

        mListaTabttab = clstabttab.ObtenerLista("187", "1")

        Me.ddlcajero.DataTextField = "cdescri"
        Me.ddlcajero.DataValueField = "ccodigo"
        Me.ddlcajero.DataSource = mListaTabttab
        Me.ddlcajero.DataBind()

    End Sub
    
    
   
    Private Sub btnaplicar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaplicar.ServerClick
        'localiza datos
        Dim lccodcli As String
        Dim eclimide As New climide
        Dim mclimide As New cClimide
        Dim lndeuda As Double
        Dim lnahorros As Double

        'obtiene saldos para grid
        Dim mahomcta As New cAhomcta
        Dim ds1 As New DataSet
        Dim dr As DataRow

        Dim ecreditos As New creditos
        Dim mcreditos As New ccreditos
        Dim listacre As New listacreditos


        eclimide.ccodcli = Me.txtcodcta.Text.Trim
        mclimide.ObtenerClimide(eclimide)
        Me.txtnomcli.Text = eclimide.cnomcli

        lccodcli = Me.txtcodcta.Text.Trim

        ds1 = mahomcta.Obtenerdatasetporcliente(lccodcli)
        Me.dgClientes.DataSource = ds1
        Me.dgClientes.DataBind()

        'total de ahorros
        lnahorros = 0
        For Each dr In ds1.Tables(0).Rows
            lnahorros = lnahorros + dr("nsaldoaho")
        Next
        Me.txtahorros.Text = lnahorros.ToString


        'localiza las deudas pendientes


        listacre = mcreditos.ObtenerListaPorCliente(lccodcli)
        dgcreditos.DataSource = listacre
        dgcreditos.DataBind()

        'calcula totales

        ' empieza *************************************************
        'obtiene toda la base de la cremcre para filtrar pagos
        lndeuda = 0
        For Each ecreditos In listacre
            lndeuda = lndeuda + ecreditos.nsalcap + ecreditos.nsalint + ecreditos.nsalmor
        Next
        Me.txtdeuda.Text = lndeuda.ToString

    End Sub

    Private Sub btngraba_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngraba.ServerClick
        'graba liquidacion de ahorros
        Dim lccodcli As String
        Dim lnahorros As Double
        Dim lnsaldocre As Double
        Dim clsaho As New clsahorros
        Dim ldfecha As Date
        Dim lccodofi As String
        lccodcli = Me.txtcodcta.Text.Trim
        lnahorros = Double.Parse(Me.txtahorros.Text)
        lnsaldocre = Double.Parse(Me.txtdeuda.Text)
        lccodofi = Session("gccodofi")
        ldfecha = Session("gdfecsis")

        Try
            If lccodcli <> Nothing And lnahorros > 0 Then
                clsaho.ccodcli = lccodcli
                clsaho.nahorros = lnahorros
                clsaho.nsaldocre = lnsaldocre
                clsaho.pdfecha = ldfecha
                clsaho.gccodofi = lccodofi
                clsaho.pccodcaja = Me.ddlcajero.SelectedValue.Trim
                clsaho.liquidasocio()

            Else
                Response.Write("<script language='javascript'>alert('No hay disponibilidad de fondos')</script>")
            End If
            Response.Write("<script language='javascript'>alert('ok')</script>")

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('Hubo problemas en la liquidacion de fondos')</script>")
        End Try

    End Sub
End Class
