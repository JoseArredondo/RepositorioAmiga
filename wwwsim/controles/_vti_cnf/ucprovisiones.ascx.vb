Public Class ucprovisiones
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents btnsalir As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btncertificados As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents btnaportaciones As System.Web.UI.HtmlControls.HtmlInputButton

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
    End Sub

    Private Sub btnaportaciones_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaportaciones.ServerClick
        Response.Redirect("ucprovaporta.ascx")
    End Sub

    Private Sub btncertificados_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncertificados.ServerClick
        Response.Redirect("ucprovpla.asx")
        Response.Redirect("ucprovpla.ascx")

    End Sub
End Class
