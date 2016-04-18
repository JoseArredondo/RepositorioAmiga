Public Class ucbuscer
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents TxtNombre As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents dgClientes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
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
    Private _certificadoSeleccionado As String
    Public Event Seleccionado(ByVal codigoCliente As String)


    Public Property certificadoSeleccionado() As String
        Get
            Return _certificadoSeleccionado
        End Get
        Set(ByVal Value As String)
            _certificadoSeleccionado = Value
            If ViewState("numcertificado") Is Nothing Then
                ViewState.Add("numcertificado", Value)
            Else
                ViewState("numcertificado") = Value
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
            '            Me.Cargardatos()
        End If
        Me._certificadoSeleccionado = Me.ViewState("numcertificado")
    End Sub

    'carga elementos necesarios para la linea
    Private Sub Cargardatos()
        Dim mControl As New cAhomcrt
        Dim ds As New DataSet
        Dim lcnomcli As String
        lcnomcli = Me.TxtNombre.Text.Trim
        ds = mControl.ObtenerDataSetporcertificado(lcnomcli)
        Me.dgClientes.DataSource = ds
        Me.dgClientes.DataBind()
    End Sub

    Private Sub DtGriduser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("wblineas.aspx?id=0")
    End Sub

    Private Sub dgClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgClientes.SelectedIndexChanged
        '        RaiseEvent Seleccionado(CType(Me.dgClientes.SelectedItem.DataItem.DataItem, DataRowView).Row.ItemArray(0).ToString())
        certificadoSeleccionado = CType(Me.dgClientes.SelectedItem.FindControl("Hyperlink1"), HyperLink).Text
        RaiseEvent Seleccionado(certificadoSeleccionado)
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Button1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        Cargardatos()
    End Sub

    Private Sub btnadiciona_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadiciona.ServerClick
        certificadoSeleccionado = "0000"
        RaiseEvent Seleccionado(certificadoSeleccionado)
    End Sub
End Class
