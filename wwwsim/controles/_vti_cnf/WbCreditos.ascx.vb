Public Class WbCreditos
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
    Private _URLCuenta As String
    Protected WithEvents WbFind1 As WbFind
    Protected WithEvents wbcreditosclientes1 As WbCreditosClientes


#Region " Propiedades "
    Public Property RCuenta() As String
        Get
            Return _URLCuenta
        End Get
        Set(ByVal Value As String)
            _URLCuenta = Value
        End Set
    End Property

#End Region


#Region " Metodos "
    Public Sub CargarPorCliente()


    End Sub
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

    End Sub

    Private Sub WbFind1_Seleccionado(ByVal codigoCliente As String) Handles WbFind1.Seleccionado
        wbcreditosclientes1.CargarCreditos(codigoCliente)
    End Sub
End Class
