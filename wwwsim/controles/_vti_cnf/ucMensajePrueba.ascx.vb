Public Class ucMensajePrueba
    Inherits ucWBase

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mControl As New crefunc
        Dim LCCTACTB As String
        LCCTACTB = mControl.fxcuentacontable("001001011000000001", "0000100", "N", "IN", "C", "N", "C", "01", 23.9, 0, 0)
        If LCCTACTB <> "" Or LCCTACTB Is Nothing Then
            Me.AsignarMensaje(LCCTACTB + ". Por Favor contactar a Soporte Tecnico.", True, True)
        Else
            Me.AsignarMensaje("Proceso guardado satisfactoriamente", , True)

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim mControl As New crefunc
        Dim LCCTACTB As String
        LCCTACTB = mControl.fxcuentacontable("001001011000000001", "0000100", "N", "IN", "C", "N", "C", "01", 23.9, 0, 0)
        If LCCTACTB <> "" Or LCCTACTB Is Nothing Then
            Response.Write("<script language='javascript'>alert('" & LCCTACTB & ". Por Favor contactar a Soporte Tecnico.')</script>")
        Else
            Response.Write("<script language='javascript'>alert('Proceso guardado satisfactoriamente.')</script>")
        End If
    End Sub

End Class
