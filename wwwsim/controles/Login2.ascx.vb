Imports System.Web.Security
Public Class Login2
    Inherits System.Web.UI.UserControl
#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    

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
    Private cinfo As Globalization.CultureInfo
    Dim pClassIdio As New PageBase

    Dim ldfecsis As Date
    Dim ldfecven As Date
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            activa()
        End If
    End Sub

   
 

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim miLogin As New cLogin

        Dim sys As New System.Security.Cryptography.SHA1CryptoServiceProvider
        Dim eusuarios As New cusuarios

        If miLogin.ValidarUsuario(Session("gccodusu"), Convert.ToBase64String(sys.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Me.txtClave2.Text.ToUpper)))) Then
            'Clave Valida
            'verifica claves
            If Me.txtClave0.Text.Trim <> Me.txtClave1.Text.Trim Then
                Response.Write("<script language='javascript'>alert('Claves no coinciden')</script>")
                Return
            Else
                '
                Dim ldfecven As Date
                Dim ldfecsis As Date
                Dim lndiasven As Integer
                ldfecsis = Session("gdfecsis")
                lndiasven = Session("gndiasven")
                ldfecven = DateAdd(DateInterval.Day, lndiasven, ldfecsis)
                Dim i As Integer
                i = eusuarios.ActualizaClave(Session("gccodusu"), Convert.ToBase64String(sys.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Me.txtClave0.Text.ToUpper))), ldfecven)
                inactiva()
                Response.Write("<script language='javascript'>alert('Clave Actualizada')</script>")
            End If
        Else
            Response.Write("<script language='javascript'>alert('Clave Iv�lida')</script>")
            Return
        End If

    End Sub
    Private Sub inactiva()

        Me.Label1.Visible = False
        Me.Label7.Visible = False
        Me.Label8.Visible = False
        Me.Label9.Visible = False
        Me.Label5.Visible = False

        Me.txtClave0.Visible = False
        Me.txtClave1.Visible = False
        Me.txtClave2.Visible = False

        Me.Button1.Visible = False
    End Sub
    Private Sub activa()
        Me.Label1.Visible = True
        Me.Label7.Visible = True
        Me.Label8.Visible = True
        Me.Label9.Visible = True
        Me.Label5.Visible = True

        Me.txtClave0.Visible = True
        Me.txtClave1.Visible = True
        Me.txtClave2.Visible = True

        Me.Button1.Visible = True

    End Sub

End Class
