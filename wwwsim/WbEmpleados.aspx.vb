Public Class WbEmpleados
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
 

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.cuwempleados1.Visible = True
            Me.cuwplanillas1.Visible = False
            Me.cuwplanictb1.Visible = False
        End If
    End Sub
    '
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.cuwempleados1.Visible = True
            Me.cuwplanillas1.Visible = False
            Me.cuwplanictb1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.cuwempleados1.Visible = False
            Me.cuwplanillas1.Visible = True
            Me.cuwplanictb1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 2 Then
            Me.cuwempleados1.Visible = False
            Me.cuwplanillas1.Visible = False
            Me.cuwplanictb1.Visible = True
        End If

    End Sub
End Class
