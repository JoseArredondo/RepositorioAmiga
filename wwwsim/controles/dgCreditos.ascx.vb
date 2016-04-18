

Partial Class dgCreditos
    Inherits ucWBase

    Public Event SeleccionarCuenta(ByVal codcta As String)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub

    Public Sub CargarDatosPorCliente(ByVal codcli As String)
        Dim mControl As New cCremcre
        Dim mLista As New listacremcre
        mLista = mControl.ObtenerLista()
        Me.BindGrid(mLista)
    End Sub

    Public Sub CargarDatosPorCuenta(ByVal codcta As String)
        Dim mControl As New cCremcre
        Dim mLista As New listacremcre
        Dim mEntidad As New cremcre
        mEntidad.ccodcta = codcta
        mControl.ObtenerCremcre(mEntidad)
        mLista.Add(mEntidad)
        Me.BindGrid(mLista)
    End Sub

    Private Sub BindGrid(ByVal aLista As listacremcre)
        Me.dgCred.DataSource = aLista
        Me.dgCred.DataBind()
    End Sub

    Private Sub dgCred_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCred.ItemCommand
        If e.CommandName = "Select" Then
            RaiseEvent SeleccionarCuenta(e.Item.Cells(1).Text)
        End If
    End Sub

End Class


