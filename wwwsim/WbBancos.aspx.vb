

Partial Class WbBancos
    Inherits System.Web.UI.Page

    'Protected WithEvents CUWPlan1 As CuwPlan
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.cuwbancos1.Visible = True
        End If
    End Sub
End Class


