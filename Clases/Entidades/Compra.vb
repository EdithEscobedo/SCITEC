Public Class Compra
    Private Const Tabla As String = "compras"
    Private idcompras As Integer
    Private fecha_compra As Date
    Private id_pro As Integer
    Private id_user As Integer
    Public Sub New()

    End Sub

    Public Sub New(idcompras As Integer,
                     fecha_compra As Date,
                     id_pro As Integer,
                     id_user As Integer)

        Me.idcompras = idcompras
        Me.fecha_compra = fecha_compra
        Me.id_pro = id_pro
        Me.id_user = id_user
    End Sub
    Public Sub SetIdCompras(idcompras As Integer)
        Me.idcompras = idcompras
    End Sub
    Public Sub SetFechaCompra(fecha_compra As Date)
        Me.fecha_compra = fecha_compra
    End Sub
    Public Sub SetIdProducto(id_pro As Integer)
        Me.id_pro = id_pro
    End Sub
    Public Sub SetIdUser(id_user As Integer)
        Me.id_user = id_user
    End Sub
    Public Function GetIdCompras() As Integer
        Return Me.idcompras
    End Function
    Public Function GetFechaCompra() As Date
        Return Me.fecha_compra
    End Function
    Public Function GetIdProducto() As Integer
        Return Me.id_pro
    End Function
    Public Function GetIdUser() As String
        Return Me.id_user
    End Function
End Class
