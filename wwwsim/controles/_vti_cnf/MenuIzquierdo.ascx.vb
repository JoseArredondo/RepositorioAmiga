Public Class MenuIzquierdo
    Inherits System.Web.UI.UserControl

#Region " C�digo generado por el Dise�ador de Web Forms "

    'El Dise�ador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DIV1 As System.Web.UI.HtmlControls.HtmlGenericControl

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
        If Not IsPostBack Then
            If Request.IsAuthenticated Then GenerarMenu()
        End If
    End Sub

    Private Sub GenerarMenu()
        Dim mControl As New cLogin
        Dim mListaOpciones As New listaopciones
        Dim mEntidad As New opciones
        mListaOpciones = mControl.ObtenerListaOpciones(configuracion.idUsuario)

        Dim i As Integer
        i = -1
        Dim strLinea As New System.Text.StringBuilder
        strLinea.Append("<div id='masterdiv'>")
        For Each mEntidad In mListaOpciones
            If mEntidad.idOpcionPadre = 0 Then
                i += 1
                If i > 0 Then strLinea.Append("</span>")
                strLinea.Append("<div class='menutitle' onclick=""SwitchMenu('sub" + i.ToString() + "')"">")
                strLinea.Append("<FONT size=""1"">" + mEntidad.opcion + "</FONT></div>")

                strLinea.Append("<span class=""submenu"" id=""sub" + i.ToString() + """>")
            Else
                strLinea.Append("<FONT size='1'>- </FONT><A href='" + _
                                mEntidad.url + "'><FONT size='1'>" + _
                                mEntidad.opcion + "</FONT></A><br>")
            End If
        Next
        strLinea.Append("</span></div>")
        Me.DIV1.InnerHtml = strLinea.ToString()
    End Sub
End Class
