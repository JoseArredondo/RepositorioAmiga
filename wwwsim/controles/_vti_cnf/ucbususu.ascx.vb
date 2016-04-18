Public Class ucbususu
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgClientes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnadiciona As System.Web.UI.HtmlControls.HtmlInputButton

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region
    Private Transacc As String
    Private _URLCodigo As String
    Private _usuSeleccionado As String
    Public Event Seleccionado(ByVal codigoCliente As String)

    Public Property usuSeleccionado() As String
        Get
            Return _usuSeleccionado
        End Get
        Set(ByVal Value As String)
            _usuSeleccionado = Value
            If ViewState("numusu") Is Nothing Then
                ViewState.Add("numusu", Value)
            Else
                ViewState("numusu") = Value
            End If
        End Set
    End Property

    Public Property URLCodigo() As String
        Get
            Return _URLCodigo
        End Get
        Set(ByVal Value As String)
            _URLCodigo = Value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            Me.Cargardatos()
        End If
        Me._usuSeleccionado = Me.ViewState("numusu")
    End Sub

    'carga elementos necesarios para la linea
    Private Sub Cargardatos()
        Dim mControl As New cusuarios
        Dim mLista As New listausuarios
        Dim mEntidad As New usuarios
        mLista = mControl.ObtenerLista()
        Me.dgClientes.DataSource = mLista
        Me.dgClientes.DataBind()
    End Sub

    ' Private Sub DtGriduser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Response.Redirect("wblineas.aspx?id=0")
    'End Sub

    Private Sub dgClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgClientes.SelectedIndexChanged
        usuSeleccionado = CType(Me.dgClientes.SelectedItem.FindControl("Hyperlink1"), HyperLink).Text
        RaiseEvent Seleccionado(usuSeleccionado)
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Button1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mControl As New cusuarios
        Dim mLista As New listausuarios
        Dim mEntidad As New usuarios
        Dim usuario As String
        usuario = Me.TxtNombre.Text.Trim
        mLista = mControl.ObtenerListaPorusuario(usuario)
        Me.dgClientes.DataSource = mLista
        Me.dgClientes.DataBind()
    End Sub

    Private Sub btnadiciona_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadiciona.ServerClick
        usuSeleccionado = "0000"
        RaiseEvent Seleccionado(usuSeleccionado)
    End Sub
End Class
