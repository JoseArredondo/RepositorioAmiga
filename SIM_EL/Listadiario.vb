<Serializable()> Public Class listadiario
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listadiario )
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As diario)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As diario
        Get
            Return CType((List(index)), diario)
        End Get
        Set(ByVal Value As diario)
            List(index) = Value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As diario) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As diario = CType(List(i), diario)
            If s.cnumcom = value.cnumcom Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal cnumcom As String) As diario
        Dim i As Integer = 0
        While i < List.Count
            Dim s As diario = CType(List(i), diario)
            If s.cnumcom = cnumcom Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As diarioEnumerator
        Return New diarioEnumerator(Me)
    End Function

    Public Class diarioEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listadiario)
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
