

Partial Class WbRechazarSol
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.wucfindetapa1.Visible = True
            Me.WbRechazar1.Visible = False

        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.wucfindetapa1.Visible = True
            Me.WbRechazar1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.wucfindetapa1.Visible = False
            Me.WbRechazar1.Visible = True
        End If

    End Sub

    Private Sub wucfindetapa1_Seleccionado(ByVal codigoCliente As String) Handles wucfindetapa1.Seleccionado
        If TabStrip1.SelectedIndex = 0 Then
            TabStrip1.SelectedIndex = 1
            TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
            WbRechazar1.CargarDatosPorCuenta(codigoCliente)
        End If


    End Sub
End Class


