Public Class WFindCreGB
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

#Region "Privadas"
    Private lnparametro1_R As String
    Private lnparametro2_R As String
    Private lnparametro3_R As String
    Private lnparametro4_R As String
    Private lnparametro5_R As String
    Private lnparametro6_R As String
    Private ds As New System.Data.DataSet
    Private lbsim As New SIM.BL.ClsMantenimiento
    Private lbsim1 As New SIM.BL.class1
    Private Transacc As String
    Private _URLCodigo As String
    Private _ClienteSeleccionado As String
    Private codigoJs As String
#End Region
    

    Public Event Seleccionado(ByVal codigoCliente As String)


    Public Property ClienteSeleccionado() As String
        Get
            Return _ClienteSeleccionado
        End Get
        Set(ByVal Value As String)
            _ClienteSeleccionado = Value
            If ViewState("ClienteSeleccionado") Is Nothing Then
                ViewState.Add("ClienteSeleccionado", Value)
            Else
                ViewState("ClienteSeleccionado") = Value
            End If
        End Set
    End Property

    

    Public Property URLCodigo() As String
        Get
            Return _URLCodigo
        End Get
        Set(ByVal Value As String)
            _URLCodigo = Value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            '    Me.Cargardatos()
        End If
        Me._ClienteSeleccionado = Me.ViewState("ClienteSeleccionado")
    End Sub

    Private Sub Button1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.ServerClick
        Dim nombre As String
        Dim ds As DataSet
        Dim clsfind As New ccreditos
        Dim lcestado As String
        Dim lctipo As String
        Dim lcbusq As String
        Dim lcmetodologia As String
        Dim filacre As DataRow
        Dim i As Integer
        nombre = Me.TxtNombre.Text.Trim
        lcestado = " "
        lctipo = Me.rdbbusqueda.SelectedValue
        lcbusq = Me.rdbbusqueda2.SelectedValue
        lcmetodologia = Me.rdbbusqueda3.SelectedValue

        If lctipo = "Por Nombre" Then
            lctipo = "1"
        ElseIf lctipo = "Por C�digo" Then
            lctipo = "2"
        Else
            lctipo = "3"
        End If

        If lcbusq = "Proceso de Solicitud" Then
            lcbusq = "1"
        ElseIf lcbusq = "Proceso de Sugerencia" Then
            lcbusq = "2"
        ElseIf lcbusq = "Proceso de Autorizaci�n" Then
            lcbusq = "3"
        ElseIf lcbusq = "Vigentes" Then
            lcbusq = "4"
        ElseIf lcbusq = "Todos" Then
            lcbusq = "5"
        ElseIf lcbusq = "Cancelados" Then
            lcbusq = "7"
        End If

        'If lcmetodologia = "Cliente" Then
        '    lcmetodologia = "1"
        'Else
        lcmetodologia = "2"
        'End If

        ds = clsfind.ObtenerbusquedacreditoGrupales(nombre, lcestado, lctipo, lcbusq, lcmetodologia, "02", Session("gcCodofi"))
        i = 0
        Dim lccodrec As String

        For Each filacre In ds.Tables(0).Rows
            lccodrec = IIf(IsDBNull(filacre("ccodrec")), "", filacre("ccodrec"))
            If lccodrec.Trim = "" Then
                If filacre("cestado") = "F" Then
                    ds.Tables(0).Rows(i)("cestado") = "VIGENTE"
                ElseIf filacre("cestado") = "A" Then
                    ds.Tables(0).Rows(i)("cestado") = "Solicitud"
                ElseIf filacre("cestado") = "C" Then
                    ds.Tables(0).Rows(i)("cestado") = "Sugerido"
                ElseIf filacre("cestado") = "D" Then
                    ds.Tables(0).Rows(i)("cestado") = "Pre-Aprobado"
                ElseIf filacre("cestado") = "E" Then
                    ds.Tables(0).Rows(i)("cestado") = "Aprobacion"
                ElseIf filacre("cestado") = "G" Then
                    ds.Tables(0).Rows(i)("cestado") = "Cancelado"
                Else
                    ds.Tables(0).Rows(i)("cestado") = "Otro"
                End If

            Else
                ds.Tables(0).Rows(i)("cestado") = "Rechazado"
            End If
            i = i + 1
        Next
        'Me.dgClientes.DataSource = ds
        'Me.dgClientes.DataBind()
        Me.Grid_Cuenta.DataSource = ds
        Me.Grid_Cuenta.DataBind()
        
    End Sub

#Region " Metodos de la Pagina "
    Private Sub Cargardatos()
        lnparametro1_R = "ccodcli as Codigo,cnomcli,"
        lnparametro4_R = "Climide"
        lnparametro5_R = "S"


        lnparametro6_R = " "

        ' Transacc = lbsim.Transac(lnparametro1_R, " ", " ", lnparametro4_R, lnparametro5_R, lnparametro6_R)
        Transacc = "Select CREMCRE.cCodCta As Codigo, CLIMIDE.cNomCli FROM CREMCRE, CLIMIDE "
        Transacc = Transacc + " WHERE CLIMIDE.cCodCli = CREMCRE.cCodCli"
        'and CREMCRE.cEstado = 'A'

        ds = lbsim.ResulSelect(Transacc)

        Me.Grid_Cuenta.DataSource = ds.Tables("Resultado")
        Me.Grid_Cuenta.DataBind()

        ds.Tables.Clear()

    End Sub

#End Region

    Private Sub DtGriduser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("WbSugInd.aspx?id=0")
    End Sub

    
    Private Sub Button2_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        Me.Button1_ServerClick(sender, e)
    End Sub

    Protected Sub Grid_Cuenta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid_Cuenta.SelectedIndexChanged
        'RaiseEvent Seleccionado(CType(Me.dgClientes.SelectedItem.DataItem.DataItem, DataRowView).Row.ItemArray(0).ToString())
        ClienteSeleccionado = Grid_Cuenta.SelectedRow.Cells(1).Text.ToString()
        'Verifica status para bloquear
        Dim ecreditos As New ccreditos
        Dim lcestatus As String
        'Dim dfecha As Date
        'dfecha = Date.Parse(dgClientes.Items(0).Cells(4).Text.Trim)

        lcestatus = ecreditos.StatusCredito(ClienteSeleccionado)
        If lcestatus.Trim = "" Then
        Else
            'Response.Write("<script language='javascript'>alert('Cr�dito Rechazado')</script>")
            codigoJs = "<script language='javascript'>alert('Cr�dito Rechazado, " & _
                       "Advertencia SIM.NET ')</script>"
            ScriptManager.RegisterStartupScript(Me.Page(), Me.GetType(), "Ventana_Aviso", codigoJs, False)
            Return
        End If

        RaiseEvent Seleccionado(ClienteSeleccionado)
    End Sub
End Class



