Public Class dgbuscre
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgdatos As System.Web.UI.WebControls.DataGrid

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region
    Public Event SeleccionarCuenta(ByVal codcta As String)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub
    Public Sub CargarDatosPorCliente(ByVal codcli As String)
        Dim mControl As New cCremcre
        Dim mLista As New listacremcre
        mLista = mControl.ObtenerLista()
        Me.BindGrid(mLista)
    End Sub

    Public Sub CargarDatosPorCuenta(ByVal codcta As String)
        Dim mControl As New cCremcre
        Dim mLista As New listacremcre
        Dim mEntidad As New cremcre
        mEntidad.ccodcta = codcta
        mControl.ObtenerCremcre(mEntidad)
        mLista.Add(mEntidad)
        Me.BindGrid(mLista)
    End Sub

    Private Sub BindGrid(ByVal aLista As listacremcre)
        Me.dgdatos.DataSource = aLista
        Me.dgdatos.DataBind()
    End Sub

    Private Sub dgCred_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdatos.ItemCommand
        If e.CommandName = "Select" Then
            RaiseEvent SeleccionarCuenta(e.Item.Cells(1).Text)
        End If
    End Sub

End Class
