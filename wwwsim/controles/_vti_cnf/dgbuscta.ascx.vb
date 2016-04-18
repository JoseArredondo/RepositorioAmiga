Public Class dgbuscta
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
    Public Event Seleccionarcliente(ByVal ccodcli As String)
    Dim _URLCodigo As String
    Public Property URLcodigo() As String
        Get
            Return _URLCodigo
        End Get
        Set(ByVal Value As String)
            _URLCodigo = Value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub
    Public Sub CargarDatosPorCliente(ByVal codcli As String)
        Dim mControl As New cClimide
        Dim mLista As New listaclimide
        mLista = mControl.ObtenerListaPorCliente(codcli)
        Me.BindGrid(mLista)
    End Sub

    Public Sub CargarDatosPorCliente_nombre(ByVal nombre As String)
        Dim mControl As New cClimide
        Dim mLista As New listaclimide
        mLista = mControl.ObtenerListaPorCliente(nombre)
        Me.BindGrid(mLista)
    End Sub

    Private Sub BindGrid(ByVal aLista As listaclimide)
        Me.dgdatos.DataSource = aLista
        Me.dgdatos.DataBind()
    End Sub

    Private Sub dgdatos_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        If e.CommandName = "Select" Then
            RaiseEvent Seleccionarcliente(e.Item.Cells(1).Text)
        End If
    End Sub

    Private Sub dgdatos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgdatos.SelectedIndexChanged

    End Sub
End Class
