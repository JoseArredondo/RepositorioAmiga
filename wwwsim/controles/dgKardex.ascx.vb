

Partial Class dgKardex
    Inherits ucWBase

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Introducir aqu� el c�digo de usuario para inicializar la p�gina
    End Sub

    Public Sub CargarDatosPorCuenta(ByVal codcta As String)
        Dim mControl As New cCredkar
        Dim mLista As New listacredkar
        mLista = mControl.ObtenerListaPorCuenta(codcta)
        Me.BindGrid(mLista)
    End Sub

    Private Sub BindGrid(ByVal aLista As listacredkar)
        Me.dgDatos.DataSource = aLista
        Me.dgDatos.DataBind()
    End Sub

End Class


