Public Class cuwConGen
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
    Dim classconta As New clsConta
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            CargarDatos()
        End If
    End Sub
    Private Sub Blankear()
        Me.txtCodCta.Text = ""
        Me.txtDescri.Text = ""
        Me.txtdocume.Text = ""
        Me.txtvalore.Text = ""
        Me.txtfecha.Text = ""
    End Sub
    Private Sub CargarDatos()
        Dim entidadCntaprm As New SIM.EL.cntaprm
        Dim eCntaprm As New SIM.BL.cCntaprm
        Dim ds As New DataSet
        Dim ncanti As Integer
        Dim lcmesvig As String
        Dim lccadena As String
        Dim clssconta As New clsConta
        Dim lcyears As String
        lcmesvig = Session("gcyears")
        lcyears = Left(lcmesvig, 4)
        lccadena = clssconta.cadena(Session("gcfondo"), lcyears, Session("gcnomser"))

        ds = eCntaprm.ObtenerDataSetPorID(Session("gcfondo"), lccadena)
        ncanti = ds.Tables(0).Rows.Count()
        If ncanti = 0 Then  'En caso que no devuelva nada se sale
            Exit Sub
        End If
        Me.txtfecini.Text = ds.Tables(0).Rows(0)("dFecimes")
        Me.txtfecfin.Text = ds.Tables(0).Rows(0)("dFecfmes")
        Me.txtid.Text = 1
    End Sub


    Private Sub btnCtaCtb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaCtb.Click
        Me.Blankear()
        Me.txtCodCta.Enabled = True
        Me.txtDescri.Enabled = False
        Me.txtdocume.Enabled = False
        Me.txtvalore.Enabled = False
        Me.txtfecha.Enabled = False
        Me.txtid.Text = 1
        classconta.cBuscar = Me.txtCodCta.Text.Trim

    End Sub

    Private Sub btnDescri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescri.Click
        Me.Blankear()
        Me.txtCodCta.Enabled = False
        Me.txtDescri.Enabled = True
        Me.txtdocume.Enabled = False
        Me.txtvalore.Enabled = False
        Me.txtfecha.Enabled = False
        Me.txtid.Text = 2
        classconta.cBuscar = Me.txtDescri.Text.Trim
    End Sub

    Private Sub btnDocume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Blankear()
        Me.txtCodCta.Enabled = False
        Me.txtDescri.Enabled = False
        Me.txtdocume.Enabled = True
        Me.txtvalore.Enabled = False
        Me.txtfecha.Enabled = False
        Me.txtid.Text = 3
        classconta.cBuscar = Me.txtdocume.Text.Trim
    End Sub

    Private Sub btnvalore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvalore.Click
        Me.Blankear()
        Me.txtCodCta.Enabled = False
        Me.txtDescri.Enabled = False
        Me.txtdocume.Enabled = False
        Me.txtvalore.Enabled = True
        Me.txtfecha.Enabled = False
        Me.txtid.Text = 4
        classconta.cBuscar = Me.txtvalore.Text.Trim
    End Sub

    Private Sub btnFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFecha.Click
        Me.Blankear()
        Me.txtCodCta.Enabled = False
        Me.txtDescri.Enabled = False
        Me.txtdocume.Enabled = False
        Me.txtvalore.Enabled = False
        Me.txtfecha.Enabled = True
        Me.txtid.Text = 5
        classconta.cBuscar = Me.txtfecha.Text.Trim
    End Sub

    Private Sub btnBuscar_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.ServerClick
        Dim dsConsulta As New DataSet
        classconta.dFecfin = Me.txtfecfin.Text
        classconta.dFecIni = Me.txtfecini.Text

        Dim lcBuscar As String
        Dim lnBuscar As Double
        Dim ldBuscar As Date
        classconta.nOpBuscar = Me.txtid.Text
        If Me.txtid.Text = 1 Then
            classconta.cBuscar = Me.txtCodCta.Text.Trim
        ElseIf Me.txtid.Text = 2 Then
            classconta.cBuscar = Me.txtDescri.Text.Trim
        ElseIf Me.txtid.Text = 3 Then
            classconta.cBuscar = Me.txtdocume.Text.Trim
        ElseIf Me.txtid.Text = 4 Then
            classconta.cBuscar = Me.txtvalore.Text.Trim
        Else
            classconta.cBuscar = Me.txtfecha.Text.Trim
        End If
        dsConsulta = classconta.Consulta_General()
        Dim nelem As Integer
        nelem = dsConsulta.Tables(0).Rows.Count
        If nelem = 0 Then
            Exit Sub
        End If
        Me.dgConsulta.DataSource = dsConsulta
        Me.dgConsulta.DataBind()
    End Sub
End Class
