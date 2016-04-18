Public Class ucbenefi
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgClientes As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtccodcrt As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtnomcli As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtbeneficiario As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlparentesco As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtfecnac As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtdirben As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtporcen As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents txtcorrela As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents btnaplicar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnadicionar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btncancela As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btncancelar As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents RangeValidator5 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents RangeValidator6 As System.Web.UI.WebControls.RangeValidator

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
        If Not IsPostBack Then
            Cargardatos()
        End If

    End Sub
    'carga combos
    Sub cargardatos()
        Dim clscparent As New cParent
        Dim mlistaparent As New listaparent
        mlistaparent = clscparent.ObtenerLista()

        Me.ddlparentesco.DataTextField = "cdescri"
        Me.ddlparentesco.DataValueField = "cparent"
        Me.ddlparentesco.DataSource = mlistaparent
        Me.ddlparentesco.DataBind()


    End Sub

    Private Sub txtporcen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    

    Public Sub CargarPorcertificado(ByVal ccodcrt As String)
        Me.txtccodcrt.Text = ccodcrt
        Me.btnaplicar_ServerClick(Me, New System.EventArgs)
    End Sub

    Private Sub dgClientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgClientes.SelectedIndexChanged

    End Sub
    Private Sub dgClientes_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgClientes.ItemCommand
        Dim lncorrela As Integer
        If e.CommandName = "Select" Then
            lncorrela = e.Item.Cells(1).Text
            Me.txtbeneficiario.Text = e.Item.Cells(2).Text
            Me.txtcorrela.Text = lncorrela
            Me.txtdirben.Text = e.Item.Cells(3).Text
            Me.txtfecnac.Text = e.Item.Cells(4).Text
            Me.txtporcen.Text = e.Item.Cells(5).Text
            '            RaiseEvent SeleccionarCuenta(e.Item.Cells(1).Text)
        End If
    End Sub



    Private Sub btnaplicar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaplicar.ServerClick
        'procesa los certificados
        Dim edepmben As New DEPMBEN
        Dim mdepmben As New cDEPMBEN
        Dim lccodcrt As String
        Dim lccodcli As String
        Dim listabeneficiarios As listaDEPMBEN

        edepmben.ccodcrt = Me.txtccodcrt.Text.Trim
        mdepmben.ObtenerDEPMBEN(edepmben)
        lccodcrt = Me.txtccodcrt.Text.Trim
        listabeneficiarios = mdepmben.ObtenerLista(lccodcrt)


        'obtiene el nombre del socio
        Dim mahomcrt As New cAhomcrt
        Dim eahomcrt As New ahomcrt
        eahomcrt.ccodcrt = lccodcrt
        mahomcrt.ObtenerAhomcrt(eahomcrt)
        Me.txtnomcli.Text = eahomcrt.nombre

        Me.dgClientes.DataSource = listabeneficiarios
        Me.dgClientes.DataBind()
        Me.txtcorrela.Text = listabeneficiarios.Count

    End Sub

    Private Sub btnadicionar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadicionar.ServerClick
        Dim edepmben As New DEPMBEN
        Dim mdepmben As New cDEPMBEN

        Dim lcnombre As String
        Dim ldfecnac As Date
        Dim lnporcen As Double
        Dim lcparentesco As String
        Dim lcdirben As String
        Dim lncorrela As Integer

        Me.btnaplicar_ServerClick(sender, e)

        If Me.txtbeneficiario.Text <> Nothing And Me.txtccodcrt.Text.Trim <> Nothing Then
            lncorrela = Double.Parse(Me.txtcorrela.Text.Trim) + 1
            Me.txtcorrela.Text = lncorrela.ToString
            lcnombre = Me.txtbeneficiario.Text.Trim
            ldfecnac = Date.Parse(Me.txtfecnac.Text)
            lnporcen = Double.Parse(Me.txtporcen.Text)
            lcparentesco = Me.ddlparentesco.SelectedValue
            lcdirben = Me.txtdirben.Text.Trim

            edepmben.ccodcrt = Me.txtccodcrt.Text.Trim
            edepmben.ncorrel = lncorrela
            edepmben.cnomben = lcnombre
            edepmben.cparent = lcparentesco
            edepmben.dfecnac = ldfecnac
            edepmben.nporcen = lnporcen
            mdepmben.Agregar(edepmben)
            Me.btnaplicar_ServerClick(sender, e)
            btncancelar_ServerClick(sender, e)

        End If
    End Sub

    
    
    Private Sub btncancela_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancela.ServerClick
        Dim EDEPMBEN As New DEPMBEN
        Dim mdepmben As New cDEPMBEN

        EDEPMBEN.ccodcrt = Me.txtccodcrt.Text.Trim
        EDEPMBEN.ncorrel = Integer.Parse(Me.txtcorrela.Text)
        EDEPMBEN.cnomben = Me.txtbeneficiario.Text.Trim
        EDEPMBEN.cparent = Me.ddlparentesco.SelectedValue
        EDEPMBEN.dfecnac = Date.Parse(Me.txtfecnac.Text)
        EDEPMBEN.nporcen = Double.Parse(Me.txtporcen.Text)
        mdepmben.EliminarDEPMBEN(EDEPMBEN)
        Me.btnaplicar_ServerClick(sender, e)
    End Sub

    Private Sub btncancelar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.ServerClick
        Me.txtbeneficiario.Text = " "
        Me.txtcorrela.Text = 0
        Me.txtdirben.Text = " "
        Me.txtfecnac.Text = " /  /"
        Me.txtporcen.Text = 0
    End Sub
End Class

