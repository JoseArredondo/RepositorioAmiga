

Partial Class WbLibretas
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            WUCFindCre1.Visible = True
            Me.cuwlibretas1.Visible = False
        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            WUCFindCre1.Visible = True
            Me.cuwlibretas1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            WUCFindCre1.Visible = False
            Me.cuwlibretas1.Visible = True
        End If
    End Sub

    Private Sub WUCFindCre1_Seleccionado(ByVal codigoCliente As String) Handles WUCFindCre1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        cuwlibretas1.CargarPorCliente(codigoCliente)
    End Sub

End Class


