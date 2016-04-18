Public Class WbUsCatal
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

#Region " Variables "
    Private cClsCat As New SIM.BL.ClsBusCatal
    Private ds As New DataSet
    Private _URLCodigo As String
    Private _ClienteSeleccionado As String
    Public Event CargarCuenta(ByVal codigoCliente As String)

#End Region

#Region " Propiedades "

    Public Property ClienteSeleccionado() As String
        Get
            Return _ClienteSeleccionado
        End Get
        Set(ByVal Value As String)
            _ClienteSeleccionado = Value
            If ViewState("ClienteSeleccionado") Is Nothing Then
                ViewState.Add("ClienteSeleccionado", Value)
            Else
                ViewState("ClienteSeleccionado") = Value
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

#End Region

#Region "Metodos"
    Public Function Catalogo() As DataSet

        'cClsCat._cValor = Me.TxtDescri.Text.Trim
        ds = cClsCat.Catalogo(Session("gcfondo"))
        Me.DgCatalogo.DataSource = ds
        Me.DgCatalogo.DataBind()
        Me.Rdbcuenta.Checked = True
        'ds.Clear()
    End Function


#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            'Dim lId As String = Request.QueryString("id")
        
            Me.Catalogo()


        End If

     
    End Sub


    
    Private Sub Rdbcuenta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdbcuenta.CheckedChanged
        Me.RdbDescrip.Checked = False
    End Sub

    Private Sub RdbDescrip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbDescrip.CheckedChanged
        Me.Rdbcuenta.Checked = False
    End Sub

    Private Sub DgCatalogo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgCatalogo.SelectedIndexChanged
        ClienteSeleccionado = CType(Me.DgCatalogo.SelectedItem.FindControl("Hyperlink1"), HyperLink).Text
        RaiseEvent CargarCuenta(ClienteSeleccionado)
    End Sub

    Private Sub Button1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        Me.DgCatalogo.CurrentPageIndex = 0
        Me.cargargrid()


    End Sub
    Private Sub cargargrid()
        cClsCat._cValor = Me.TxtDescri.Text.Trim


        If Me.RdbDescrip.Checked = True Then
            cClsCat._llBandera = True     'Descripcion
        Else
            cClsCat._llBandera = False    ' Cuenta  
        End If

        ds = cClsCat.BuscaCatalogo()

        Me.DgCatalogo.DataSource = ds
        Me.DgCatalogo.DataBind()

        ds.Clear()


        Me.TxtDescri.Text = " "

    End Sub

    Private Sub CargarDatos()
        Catalogo()
    End Sub
    Private Sub dgCatalago_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgCatalogo.PageIndexChanged
        If Me.IsPostBack Then
            Me.DgCatalogo.CurrentPageIndex = 0
            Me.DgCatalogo.CurrentPageIndex = e.NewPageIndex
            Me.CargarDatos()
        End If
    End Sub

End Class
