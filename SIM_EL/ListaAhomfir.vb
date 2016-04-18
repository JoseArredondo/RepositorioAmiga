<Serializable()> Public Class listaAhomfir
    Inherits listaBase

    Public Sub New()
    End Sub

    Public Sub New(ByVal value As listaAhomfir )
        Me.AgregarRango(value)
    End Sub

    Public Sub New(ByVal value() As Ahomfir)
        Me.AgregarRango(value)
    End Sub

    Default Public Property Blubber(ByVal index As Integer) As Ahomfir
        Get
            Return CType((List(index)), Ahomfir)
        End Get
        Set(ByVal Value As Ahomfir)
            List(index) = Value
        End Set
    End Property

    Public Function IndiceDe(ByVal value As Ahomfir) As Integer
        Dim i As Integer = 0
        While i < List.Count
            Dim s As Ahomfir = CType(List(i), Ahomfir)
            If s.ccodaho = value.ccodaho Then
                Return i
            End If
            i += 1
        End While
        Return -1
    End Function

    Public Function BuscarPorId(ByVal ccodaho As String) As Ahomfir
        Dim i As Integer = 0
        While i < List.Count
            Dim s As Ahomfir = CType(List(i), Ahomfir)
            If s.ccodaho = ccodaho Then
                Return s
            End If
            i += 1
        End While
        Return Nothing
    End Function

    Public Shadows Function GetEnumerator() As AhomfirEnumerator
        Return New AhomfirEnumerator(Me)
    End Function

    Public Class AhomfirEnumerator
        Inherits Object
        Implements IEnumerator

        Private Base As IEnumerator
        Private Local As IEnumerable

        Public Sub New(ByVal Mappings As listaAhomfir)
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
