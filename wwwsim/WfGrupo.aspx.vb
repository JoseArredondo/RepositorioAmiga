Public Class Wfgrupo
    Inherits System.Web.UI.Page

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
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.WbFindgr1.Visible = True
            Me.WbSolidario1.Visible = False
            Me.WbFind1.Visible = False
        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.wbfindgr1.Visible = True
            Me.WbSolidario1.Visible = False
            Me.WbFind1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.wbfindgr1.Visible = False
            Me.WbSolidario1.Visible = True
            Me.WbFind1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 2 Then
            Me.WbFindgr1.Visible = False
            Me.WbSolidario1.Visible = False
            Me.WbFind1.Visible = True
        End If
    End Sub

    Private Sub wbfindgr1_Seleccionado(ByVal codigoCliente As String) Handles wbfindgr1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        Me.WbSolidario1.CargarPorCliente(codigoCliente)
    End Sub
    Private Sub Wbfind1_Refinaciamiento(ByVal codigoCliente As String) Handles WbFind1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        WbSolidario1.MiembrosBanco(codigoCliente)
    End Sub

End Class
