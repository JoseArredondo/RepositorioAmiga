

Partial Class WbAprLote
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Dim ngrav As Double
            Session.Add(ngrav, 0)

            Me.WFindCreGB1.Visible = True
            Me.CUWAprLote1.Visible = False
            Me.CuwPlanGB1.Visible = False
        End If
    End Sub
    Private Sub TabStrip1_SelectedIndexChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabStrip1.SelectedIndexChange
        If TabStrip1.SelectedIndex = 0 Then
            Me.CUWAprLote1.Visible = False
            Me.WFindCreGB1.Visible = True
            Me.CuwPlanGB1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 1 Then
            Me.CUWAprLote1.Visible = True
            Me.WFindCreGB1.Visible = False
            Me.CuwPlanGB1.Visible = False
        End If
        If TabStrip1.SelectedIndex = 2 Then
            Me.CUWAprLote1.Visible = False
            Me.WFindCreGB1.Visible = False
            Me.CuwPlanGB1.Visible = True

        End If
       

    End Sub

    Private Sub WFindCreGB1_Seleccionado(ByVal codigoCliente As String) Handles WFindCreGB1.Seleccionado
        TabStrip1.SelectedIndex = 1
        TabStrip1_SelectedIndexChange(TabStrip1, New System.EventArgs)
        CUWAprLote1.CargarPorCliente(codigoCliente)
    End Sub

End Class


