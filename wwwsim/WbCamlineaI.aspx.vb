

Partial Class WbCamLineaI
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.wucfindcligru1.Visible = True
            Me.ucCambiaLineaI1.Visible = False

        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.wucfindcligru1.Visible = True
            Me.ucCambiaLineaI1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.wucfindcligru1.Visible = False
            Me.ucCambiaLineaI1.Visible = True

        End If
    End Sub

    Private Sub wucfindcligru1_Seleccionado(ByVal codigoCliente As String) Handles wucfindcligru1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        Me.ucCambiaLineaI1.CargarDatosPorCuenta(codigoCliente)
    End Sub
End Class


