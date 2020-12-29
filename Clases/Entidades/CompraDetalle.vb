Public Class CompraDetalle
    Private Const Tabla As String = "compradetalle"
    Private idcompraDetalle As Integer
    Private cantCompra As Integer
    Private id_compraa As Integer
    Private id_productooo As Integer
    Public Sub New()

    End Sub

    Public Sub New(idcompraDetalle As Integer,
                     cantCompra As Integer,
                     id_compraa As Integer,
                     id_productooo As Integer)

        Me.idcompraDetalle = idcompraDetalle
        Me.cantCompra = cantCompra
        Me.id_compraa = id_compraa
        Me.id_productooo = id_productooo
    End Sub
    Public Sub SetIdCompraDetalle(idcompraDetalle As Integer)
        Me.idcompraDetalle = idcompraDetalle
    End Sub
    Public Sub SetCantCompra(cantCompra As Integer)
        Me.cantCompra = cantCompra
    End Sub
    Public Sub SetIdCompraa(id_compraa As Integer)
        Me.id_compraa = id_compraa
    End Sub
    Public Sub SetIdProductooo(id_productooo As Integer)
        Me.id_productooo = id_productooo
    End Sub
    Public Function GetIdCompraDetalle() As Integer
        Return Me.idcompraDetalle
    End Function
    Public Function GetCantCompra() As Integer
        Return Me.cantCompra
    End Function
    Public Function GetIdCompraa() As Integer
        Return Me.id_compraa
    End Function
    Public Function GetIdProductooo() As Integer
        Return Me.id_productooo
    End Function

    Public Function AgregarCompraD() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompraDetalle", "cantCompra", "id_compraa", "id_productooo"}
        Dim valores As String() = {"'" & Me.idcompraDetalle & "'", "'" & Me.cantCompra & "'", "'" & Me.id_compraa & "'",
                                   "'" & Me.id_productooo & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarComprasD() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompradetalle", "cantCompra", "id_compraa", "id_productooo"}
        Dim valores As String() = {"'" & Me.idcompraDetalle & "'", "'" & Me.cantCompra & "'", "'" & Me.id_compraa & "'",
                                   "'" & Me.id_productooo & "'"}
        Dim condiciones As String() = {"idcompradetalle=" & "'" & Me.idcompraDetalle & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarCompraD() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idcompradetalle=" & "'" & Me.idcompraDetalle & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarCompraBDyId(idcompraDetalle As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompraDetalle", "cantCompra ", "id_compraa",
                                   "id_productooo"}
        Dim condiciones As String() = {"idcompradetalle=" & "'" & idcompraDetalle & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idcompraDetalle")) And
               Not IsDBNull(result.Rows(0)("cantCompra")) And
               Not IsDBNull(result.Rows(0)("id_compraa")) And
               Not IsDBNull(result.Rows(0)("id_productooo")) Then
                SetIdCompraDetalle(CInt(result.Rows(0)("idCompras")))
                SetCantCompra(CInt(result.Rows(0)("cantCompra")))
                SetIdCompraa(CInt(result.Rows(0)("id_compraa")))
                SetIdProductooo(CInt(result.Rows(0)("id_productooo")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarCompraD() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idcompradetalle", "cantCompra", "id_compraa", "id_productooo"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarCompraDetalleByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idcompradetalle", Tabla & ".cantCompra", Tabla & ".id_compraa",
                                    Tabla & ".id_productooo"}

        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idcompradetalle) AS idcompradetalle"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idcompradetalle")) Then
            Return CInt(result.Rows(0)("idcompradetalle"))
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
