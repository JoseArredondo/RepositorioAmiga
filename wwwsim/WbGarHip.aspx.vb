

Partial Class WbGarHip
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.WUCFindCre1.Visible = True
            Me.cuwGarHip1.Visible = False
            Me.cuwRepHip1.Visible = False
        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.WUCFindCre1.Visible = True
            Me.cuwGarHip1.Visible = False
            Me.cuwRepHip1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.WUCFindCre1.Visible = False
            Me.cuwGarHip1.Visible = True
            Me.cuwRepHip1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 2 Then
            Me.WUCFindCre1.Visible = False
            Me.cuwGarHip1.Visible = False
            Me.cuwRepHip1.Visible = True
        End If
    End Sub
    Private Sub WUCFindCre1_Seleccionado(ByVal codigoCliente As String) Handles WUCFindCre1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        Me.cuwGarHip1.CargarPorCliente(codigoCliente)
    End Sub
    '

End Class


