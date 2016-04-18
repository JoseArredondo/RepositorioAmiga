

Partial Class cuwCamAna
    Inherits ucWBase
    Private pcCodCta As String
    Private pcCodPre As String
#Region "Variable"
    'Variable de la clase Mantenimiento
    Private cls1 As New SIM.bl.ClsMantenimiento
    Private Transacc As String
    Private ds As New DataSet
    Private lnparametro1_R As String
    Private lnparametro2_R As String
    Private lnparametro3_R As String
    Private lnparametro4_R As String
    Private lnparametro5_R As String
    Private lnparametro6_R As String
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            Me.CargarDatos()
        End If
    End Sub
    Private Sub CargarDatos()
        Me.cbxanacre.Disabled = True
        Me.btnGraba.Disabled = True
        '----------------------------
        'Llenando Analistas
        '----------------------------
        lnparametro1_R = "cNomUsu , cCodUsu, "
        lnparametro2_R = "S,S, "
        lnparametro3_R = " "
        lnparametro4_R = "TABTUSU"
        lnparametro5_R = "S"

        Dim lccodofi As String = Session("gccodofi")
        If lccodofi = "001" Then
            lnparametro6_R = "Where cCatego ='ANA' order by CNOMUSU "
        Else
            lnparametro6_R = "Where cCatego ='ANA' and cCodofi =" & lccodofi.Trim & " order by CNOMUSU "
        End If

        Transacc = cls1.Transac(lnparametro1_R, lnparametro2_R, lnparametro3_R, _
        lnparametro4_R, lnparametro5_R, lnparametro6_R)
        ds = cls1.ResulSelect(Transacc)
        If ds.Tables("Resultado").Rows.Count <= 0 Then
            MsgBox("No existen Operaciones", MsgBoxStyle.Information, "Aviso")
            Exit Sub
        End If

        Me.cbxanacre.DataTextField = "cNomUsu"
        Me.cbxanacre.DataValueField = "cCodUsu"
        Me.cbxanacre.DataSource = ds.Tables("Resultado")
        Me.cbxanacre.DataBind()

        'Me.cbxanacre.DropDownWidth = 300
        ds.Tables("Resultado").Clear()
    End Sub
    Private Sub CargarDatosCredito()
        Dim entidad3 As New SIM.EL.creditos
        Dim ecreditos As New SIM.BL.ccreditos
        entidad3.ccodcta = pcCodCta
        ecreditos.Obtenercreditos(entidad3)
        Me.txtccodcli.Text = entidad3.ccodcli
        Me.txtccodcta.Text = pcCodCta
        Me.txtcnomcli.Text = entidad3.cnomcli
        Me.txtcnomana.Text = entidad3.cNomUsu
        Me.cbxanacre.Disabled = False
        Me.btnGraba.Disabled = False
    End Sub
    Public Sub CargarPorCliente(ByVal codigoCliente As String)
        pcCodCta = codigoCliente
        CargarDatosCredito()
    End Sub

    Private Sub btncancela_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancela.ServerClick
        Me.Cancela()
    End Sub
    Private Sub Cancela()
        Me.txtcnomcli.Text = " "
        Me.txtccodcli.Text = " "
        Me.txtccodcta.Text = " "
        Me.txtcnomana.Text = " "
        Me.cbxanacre.Disabled = True
        Me.btnGraba.Disabled = True
    End Sub

    Private Sub btnGraba_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGraba.ServerClick
        Dim lccodana As String
        lccodana = Me.cbxanacre.Value
        Dim cCremcre As New cremcre
        Dim eCremcre As New cCremcre

        cCremcre.ccodcta = Me.txtccodcta.Text.Trim
        cCremcre.ccodana = lccodana
        eCremcre.ActualizarAnalista(cCremcre)
        Me.Cancela()
    End Sub
End Class


