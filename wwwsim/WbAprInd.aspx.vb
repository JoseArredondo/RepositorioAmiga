

Partial Class WbAprInd
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Dim ngrav As Double
            Session.Add(ngrav, 0)

            Me.wucfindcligru1.Visible = True
            Me.CUWAprInd1.Visible = False
            Me.CuwPlan1.Visible = False
            Me.WUCGarantias1.Visible = False
        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.CUWAprInd1.Visible = False
            Me.wucfindcligru1.Visible = True
            Me.CuwPlan1.Visible = False
            Me.WUCGarantias1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.CUWAprInd1.Visible = True
            Me.wucfindcligru1.Visible = False
            Me.CuwPlan1.Visible = False
            Me.WUCGarantias1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 2 Then
            Me.CUWAprInd1.Visible = False
            Me.wucfindcligru1.Visible = False
            Me.CuwPlan1.Visible = True
            Me.WUCGarantias1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 3 Then
            Me.CUWAprInd1.Visible = False
            Me.wucfindcligru1.Visible = False
            Me.CuwPlan1.Visible = False
            Me.WUCGarantias1.Visible = True
        End If

    End Sub

    Private Sub wucfindcligru1_Seleccionado(ByVal codigoCliente As String) Handles wucfindcligru1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        CUWAprInd1.CargarPorCliente(codigoCliente)
        WUCGarantias1.CargarPorCliente(codigoCliente)
    End Sub

End Class


