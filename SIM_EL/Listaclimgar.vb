<Serializable()> Public Class listaclimgar
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaclimgar )
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As climgar)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As climgar
        Get
            Return CType((List(index)), climgar)
        End Get
        Set(ByVal Value As climgar)
            List(index) = Value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As climgar) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As climgar = CType(List(i), climgar)
            If s.ccodcli = value.ccodcli _
            And s.ccodgar = value.ccodgar Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal ccodcli As String, _
        ByVal ccodgar As String) As climgar
        Dim i As Integer = 0
        While i < List.Count
            Dim s As climgar = CType(List(i), climgar)
            If s.ccodcli = ccodcli _
            And s.ccodgar = ccodgar Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As climgarEnumerator
        Return New climgarEnumerator(Me)
    End Function

    Public Class climgarEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaclimgar)
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
