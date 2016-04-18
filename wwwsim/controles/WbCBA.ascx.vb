Public Class WbCBA
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




    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
        If Not IsPostBack Then
            btngrabar.Enabled = False
        End If

    End Sub

    Private Sub CargaGrid()
        Me.Datagrid1.Columns(3).Visible = False
        btngrabar.Enabled = True
        Dim eencuestas As New cEncuestas
        Dim ds As New DataSet
        ds = eencuestas.ObtenerDataSetPorID("003")

        Me.Datagrid1.DataSource = ds
        Me.Datagrid1.DataBind()

        Dim xy As Integer = 0
        Dim pregunta As String

        Dim bandera As TextBox


        For xy = 0 To Me.Datagrid1.Items.Count - 1
            pregunta = Me.Datagrid1.Items(xy).Cells(0).Text.Trim
            bandera = CType(Me.Datagrid1.Items(xy).FindControl("TextBox5"), TextBox)
            If Me.Datagrid1.Items(xy).Cells(3).Text.Trim = "X" Then

                bandera.Visible = False
            End If

            bandera.Text = 0

            'Dim ddl As DropDownList
            'Dim dt2 As DataTable = LlenarRespuestas("001", pregunta)

            '---------------------------
            'Busca el Sector Economico
            '---------------------------
            'lcsececo = eclidfin.BuscarSectorEconomico(cliente)

            'Dim gvrow As DataGridItem
            'gvrow = CType(Me.Datagrid1.Items(xy).Cells(1).NamingContainer, DataGridItem)
            'ddl = CType(gvrow.FindControl("DropDownList1"), DropDownList)

            'ddl.ClearSelection()

            'If ddl IsNot DBNull.Value Then

            '    ddl.DataSource = dt2
            '    ddl.DataTextField = "crespuestas"
            '    ddl.DataValueField = "ccodres"
            '    ddl.DataBind() 'Lleno el combo



            'End If

            'dt2.Clear()

        Next

    End Sub

    Private Function LlenarRespuestas(ByVal ccodenc As String, ByVal ccodpreg As String) As DataTable
        Dim ds As New DataSet
        Dim eencuestas As New cEncuestas
        ds = eencuestas.ObtenerRespuestasPregunta(ccodenc, ccodpreg)
        Return ds.Tables(0)
    End Function
    Public Sub CargarPorCliente(ByVal codigoCliente As String)
        Me.txtcodcli.Text = codigoCliente

        'Nombre del Cliente
        Dim entidadClimide As New SIM.EL.climide
        Dim eClimide As New SIM.BL.cClimide

        entidadClimide.ccodcli = Me.txtcodcli.Text.Trim
        eClimide.ObtenerClimide(entidadClimide)
        Me.txtcnomcli.Text = entidadClimide.cnomcli.Trim

        CargaGrid()
    End Sub

    Protected Sub btngrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim etabular As New cTABULAR
        Dim entidadtabular As New TABULAR

        Dim xy As Integer = 0
        Dim lccodpreg As String
        Dim lccodres As String

        Dim ddl As DropDownList
        Dim gvrow As DataGridItem

        Dim lnmonto As Double = 0
        Dim ecreditos As New ccreditos
        Dim lccodcta As String = ""
        Dim ccremcre As New cCremcre
        Dim eclimide As New climide
        Dim cclimide As New cClimide
        Dim respuesta As TextBox

        entidadtabular.ccodcli = Me.txtcodcli.Text.Trim
        entidadtabular.ccodenc = "003"
        'Elimina, por si ya existe
        etabular.EliminarTABULAR(entidadtabular)

        For xy = 0 To Me.Datagrid1.Items.Count - 1
            lccodpreg = Me.Datagrid1.Items(xy).Cells(0).Text.Trim
            lccodres = Me.Datagrid1.Items(xy).Cells(1).Text.Trim

            respuesta = CType(Me.Datagrid1.Items(xy).FindControl("TextBox5"), TextBox)
            'gvrow = CType(Me.Datagrid1.Items(xy).Cells(2).NamingContainer, DataGridItem)
            'ddl = CType(gvrow.FindControl("DropDownList1"), DropDownList)

            entidadtabular.ccodpreg = lccodpreg
            entidadtabular.ccodres = ""
            entidadtabular.ccodusu = Session("gccodusu")
            entidadtabular.dfecha = Session("gdfecsis")
            entidadtabular.nvalor = Double.Parse(respuesta.Text)
            If Me.Datagrid1.Items(xy).Cells(3).Text.Trim = "X" Then
            Else
                Try
                    'Agrega respuesta
                    etabular.Agregar(entidadtabular)
                Catch ex As Exception
                    Response.Write("<script language='javascript'>alert('Ocurrio un Problema')</script>")
                    Exit Sub
                End Try

            End If

        Next
        btngrabar.Enabled = False
        Response.Write("<script language='javascript'>alert('Respuestas Grabadas')</script>")
    End Sub
End Class
