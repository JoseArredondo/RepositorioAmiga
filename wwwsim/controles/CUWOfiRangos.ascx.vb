Public Class CUWOfiRangos
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If Not IsPostBack Then
            CargaOficinas()
        End If
    End Sub
    Private Sub CargaOficinas()
        Dim etabtofi As New cTabtofi
        Dim ds As New DataSet
        ds = etabtofi.CargaAgenciaChk()

        Me.cmboficinas.DataTextField = "cnomofi"
        Me.cmboficinas.DataValueField = "ccodofi"
        Me.cmboficinas.DataSource = ds.Tables(0)
        Me.cmboficinas.DataBind()
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Carga correlativos
        Dim etabtofi As New cTabtofi
        Dim entidadtabtofi As New tabtofi

        entidadtabtofi.ccodofi = cmboficinas.SelectedValue.Trim

        etabtofi.ObtenerTabtofi(entidadtabtofi)

    End Sub
End Class
