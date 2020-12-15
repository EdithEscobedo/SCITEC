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
    Public Sub SetIdProveedor(id_pro As Integer)
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
    Public Function GetIdProveedor() As Integer
        Return Me.id_pro
    End Function
    Public Function GetIdUser() As String
        Return Me.id_user
    End Function

    Public Function AgregarCompra() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompras", "fecha_compra", "id_pro", "id_user"}
        Dim valores As String() = {"'" & Me.idcompras & "'", "'" & Me.fecha_compra.ToString("yyyy-MM-dd") & "'", "'" & Me.id_pro & "'",
                                   "'" & Me.id_user & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarCompras() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompras", "fecha_compra", "id_pro", "id_user"}
        Dim valores As String() = {"'" & Me.idcompras & "'", "'" & Me.fecha_compra.ToString("yyyy-MM-dd") & "'", "'" & Me.id_pro & "'",
                                   "'" & Me.id_user & "'"}
        Dim condiciones As String() = {"idcompras=" & "'" & Me.idcompras & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarCompra() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idcompras=" & "'" & Me.idcompras & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarCompraById(idusuario As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompras", "fecha_compra", "id_pro", "id_user"}
        Dim condiciones As String() = {"idcompras='" & idcompras & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idcompras")) And
               Not IsDBNull(result.Rows(0)("fecha_compra")) And
               Not IsDBNull(result.Rows(0)("id_pro")) And
               Not IsDBNull(result.Rows(0)("id_user")) Then
                SetIdCompras(CInt(result.Rows(0)("idCompras")))
                SetFechaCompra(CStr(result.Rows(0)("fecha_compra")))
                SetIdProveedor(CInt(result.Rows(0)("id_pro")))
                SetIdUser(CStr(result.Rows(0)("id_user")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarCompra() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompras", "fecha_compra", "id_pro", "id_user"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarCompraByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idcompras", Tabla & ".fecha_compra", Tabla & ".id_pro",
                                    Tabla & ".id_user"}

        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idcompras) AS idcompras"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idcompras")) Then
            Return CInt(result.Rows(0)("idcompras"))
        Else
            Return 0
        End If
    End Function

    Public Function BuscarUltimoIdCompra() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idcompras) AS idcompras"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idcompras")) Then
            Return CInt(result.Rows(0)("idcompras"))
        Else
            Return 0
        End If
    End Function

    'Public Sub PoblarComboProducto(cbPrducto As ComboBox)
    '   cbPrducto.DisplayMember = "Value"
    '  cbPrducto.ValueMember = "Key"
    'Dim producto As DataTable = BuscarProducto()
    '   producto.DefaultView.Sort = "idProductos ASC"
    '  producto = producto.DefaultView.ToTable()

    'If producto.Rows.Count > 0 Then
    'Dim tipoUDictionary As New Dictionary(Of Integer, String)
    'For index = 0 To producto.Rows.Count - 1
    '           tipoUDictionary.Add(producto.Rows(index)("idProductos"), producto.Rows(index)("nombreProducto"))
    'Next
    '       cbPrducto.DataSource = New BindingSource(tipoUDictionary, Nothing)
    'Else
    '       cbPrducto.DataSource = Nothing
    'End If
    'End Sub
End Class
