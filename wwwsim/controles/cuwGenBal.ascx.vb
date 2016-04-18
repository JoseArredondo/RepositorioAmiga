Public Class cuwGenBal
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatos()
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub
    Private Sub CargarDatos()
        Dim entidadCntaprm As New SIM.EL.cntaprm
        Dim eCntaprm As New SIM.BL.cCntaprm
        Dim ds As New DataSet
        Dim ncanti As Integer
        Dim lcmesvig As String
        Dim lccadena As String
        Dim lcyears As String
        Dim clssconta As New clsConta

        lcmesvig = Session("gcyears")
        lcyears = Left(lcmesvig, 4)
        lccadena = clssconta.cadena(Session("gcfondo"), lcyears, Session("gcnomser"))

        ds = eCntaprm.ObtenerDataSetPorID(Session("gcfondo"), lccadena)
        ncanti = ds.Tables(0).Rows.Count()
        If ncanti = 0 Then  'En caso que no devuelva nada se sale
            Me.ibtnprocesar.Disabled = True
            Exit Sub
        Else
            Me.ibtnprocesar.Disabled = False
        End If
        Me.txtMesPro.Text = ds.Tables(0).Rows(0)("cMesVig")
        Me.txtdfecini.Text = ds.Tables(0).Rows(0)("dFecimes")
        Me.txtdfecfin.Text = ds.Tables(0).Rows(0)("dFecfmes")
    End Sub

    
    Private Sub ibtnprocesar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnprocesar.ServerClick
        Dim claseconta As New clsConta
        Dim entidadcntabal As New SIM.EL.cntabal
        Dim ecntabal As New SIM.BL.cCntabal
        'Eliminar Contenido de CNTABAL
        ecntabal.EliminarCntabal()
        'Agrega Contenido de Catalogo a CNTABAL

        claseconta.cCodofi = Session("gcCodOfi")
        claseconta.cCodUsu = Session("gcCodUsu")
        claseconta.dfecmes = Me.txtMesPro.Text.Trim
        claseconta.AgregarCNTABAL(Session("gcfondo"))

        'CalCular Saldos Para Cuentas de Detalle
        claseconta.dFecIni = CDate(Me.txtdfecini.Text.Trim)
        claseconta.dFecfin = CDate(Me.txtdfecfin.Text.Trim)
        claseconta.CtaDetalle()
        claseconta.CtaResumen()
        Response.Write("<script language='javascript'>alert('Proceso Correcto')</script>")

    End Sub
End Class
