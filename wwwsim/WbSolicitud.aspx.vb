

Partial Class WbSoli2
    Inherits System.Web.UI.Page



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            WbFindgs1.Visible = True
            Me.WbSolcred2.Visible = False
        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            WbFindgs1.Visible = True
            Me.wbsolcred2.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            WbFindgs1.Visible = False
            Me.wbsolcred2.Visible = True
        End If
    End Sub

    Private Sub WbFindgs1_Seleccionado(ByVal codigoCliente As String) Handles WbFindgs1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        WbSolcred2.CargarPorCliente(codigoCliente)
    End Sub

End Class


