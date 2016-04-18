Public Class cuwInsPar
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            CargarDatos()
        End If
    End Sub

    Private Sub CargarDatos()
        Dim entidadCntaprm As New SIM.EL.cntaprm
        Dim eCntaprm As New SIM.BL.cCntaprm
        Dim ds As New DataSet
        Dim ncanti As Integer
        Dim lcmesvig As String
        Dim lccadena As String
        Dim lcyears As String
        Dim clssconta As New clsConta

        lcmesvig = Session("gcyears")
        lcyears = Left(lcmesvig, 4)
        lccadena = clssconta.cadena(Session("gcfondo"), lcyears, Session("gcnomser"))

        ds = eCntaprm.ObtenerDataSetPorID(Session("gcfondo"), lccadena)
        ncanti = ds.Tables(0).Rows.Count()
        If ncanti = 0 Then  'En caso que no devuelva nada se sale
            Exit Sub
        End If
        Me.txtdfecini.Text = ds.Tables(0).Rows(0)("dFecimes")
        Me.txtdfecfin.Text = ds.Tables(0).Rows(0)("dFecfmes")
        Me.Label4.Visible = False
        Me.Label4.Text = ""
    End Sub

    Private Sub ibtnprocesar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnprocesar.ServerClick
        Me.Label4.Visible = False
        Me.Label4.Text = ""

        Dim classconta As New clsConta
        classconta.dFecfin = Me.txtdfecfin.Text
        classconta.dFecIni = Me.txtdfecini.Text
        Dim dsa As New DataSet
        Dim i As Integer
        dsa = classconta.Inspeccion()
        i = dsa.Tables(0).Rows.Count
        If i = 0 Then
            Me.Label4.Visible = True
            Me.Label4.Text = "No Existen Incosistencias"
            Exit Sub
        End If
        Me.dgVerifica.DataSource = dsa
        Me.dgVerifica.DataBind()
    End Sub
End Class
