Imports System.Web.Security
Public Class Login1
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblUsuario As System.Web.UI.WebControls.Label
    Protected WithEvents txtUsuario As System.Web.UI.WebControls.TextBox
    Protected WithEvents requiredUsuario As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblClave As System.Web.UI.WebControls.Label
    Protected WithEvents txtClave As System.Web.UI.WebControls.TextBox
    Protected WithEvents requiredClave As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents FailureText As System.Web.UI.WebControls.Literal
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents btnIn As System.Web.UI.WebControls.Button
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image

    'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
        'No la modifique con el editor de c�digo.
        InitializeComponent()
    End Sub

#End Region

    Private perfil As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub


    Private Sub txtUsuario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.TextChanged

    End Sub

    
    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim miLogin As New cLogin
        If miLogin.ValidarUsuario(Me.txtUsuario.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtClave.Text, "MD5")) Then
            FormsAuthentication.SetAuthCookie(Me.txtUsuario.Text, False)
            FormsAuthentication.RedirectFromLoginPage(Me.txtUsuario.Text, False)
        Else
            Me.FailureText.Text = "Verifique usuario y/o clave. Acceso Denegado."
        End If

    End Sub

    Private Sub btnIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIn.Click
        Dim miLogin As New cLogin
        Dim lcnombre As String
        lcnombre = Me.txtUsuario.Text.Trim
        Session.Add("gccodusu", lcnombre)
        If miLogin.ValidarUsuario(Me.txtUsuario.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Me.txtClave.Text, "MD5")) Then
            FormsAuthentication.SetAuthCookie(Me.txtUsuario.Text, False)
            FormsAuthentication.RedirectFromLoginPage(Me.txtUsuario.Text, False)
        Else
            Me.FailureText.Text = "Verifique usuario y/o clave. Acceso Denegado."
        End If
    End Sub
End Class
