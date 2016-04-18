<Serializable()> Public Class listaDEPMBEN
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaDEPMBEN )
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As DEPMBEN)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As DEPMBEN
        Get
            Return CType((List(index)), DEPMBEN)
        End Get
        Set(ByVal Value As DEPMBEN)
            List(index) = Value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As DEPMBEN) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPMBEN = CType(List(i), DEPMBEN)
            If s.ccodcrt = value.ccodcrt _
            And s.ncorrel = value.ncorrel Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal ccodcrt As String, _
        ByVal ncorrel As Int32) As DEPMBEN
        Dim i As Integer = 0
        While i < List.Count
            Dim s As DEPMBEN = CType(List(i), DEPMBEN)
            If s.ccodcrt = ccodcrt _
            And s.ncorrel = ncorrel Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As DEPMBENEnumerator
        Return New DEPMBENEnumerator(Me)
    End Function

    Public Class DEPMBENEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaDEPMBEN)
            Me.Local = Mappings
            Me.Base = Local.GetEnumerator()
        End Sub

        ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Return Base.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Return Base.MoveNext()
        End Function

        Sub Reset() Implements IEnumerator.Reset
            Base.Reset()
        End Sub
    End Class
End Class
