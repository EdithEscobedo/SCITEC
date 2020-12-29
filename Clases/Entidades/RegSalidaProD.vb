Public Class RegSalidaProD
    Private Const Tabla As String = "salidadetalle"
    Private idsalidaDetalle As Integer
    Private cantidad As Integer
    Private id_salidaProd As Integer
    Private id_producto As Integer
    Public Sub New()

    End Sub

    Public Sub New(idsalidaDetalle As Integer,
                     cantidad As Decimal,
                     id_salidaProd As Integer,
                     id_producto As Integer)

        Me.idsalidaDetalle = idsalidaDetalle
        Me.cantidad = cantidad
        Me.id_salidaProd = id_salidaProd
        Me.id_producto = id_producto
    End Sub
    Public Sub SetIdSalidaProductoDetalle(idsalidaDetalle As Integer)
        Me.idsalidaDetalle = idsalidaDetalle
    End Sub
    Public Sub SetCantidad(cantidad As Integer)
        Me.cantidad = cantidad
    End Sub
    Public Sub SetIdsalidaProd(id_salidaProd As Integer)
        Me.id_salidaProd = id_salidaProd
    End Sub
    Public Sub SetIdProducto(id_producto As Integer)
        Me.id_producto = id_producto
    End Sub
    Public Function GetIdSalidaProductoDetalle() As Integer
        Return Me.idsalidaDetalle
    End Function
    Public Function GetCantidad() As Integer
        Return Me.cantidad
    End Function
    Public Function GetIdsalidaProd() As Integer
        Return Me.id_salidaProd
    End Function
    Public Function GetIdProducto() As String
        Return Me.id_producto
    End Function

    Public Function AgregarRegistroSalidaD() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaDetalle", "cantidad", "id_salidaProd", "id_producto"}
        Dim valores As String() = {"'" & Me.idsalidaDetalle & "'", "'" & Me.cantidad & "'", "'" & Me.id_salidaProd & "'",
                                   "'" & Me.id_producto & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarSalidaProductoD() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaDetalle", "cantidad", "id_salidaProd", "id_producto"}
        Dim valores As String() = {"'" & Me.idsalidaDetalle & "'", "'" & Me.cantidad & "'", "'" & Me.id_salidaProd & "'",
                                   "'" & Me.id_producto & "'"}
        Dim condiciones As String() = {"idsalidaDetalle=" & "'" & Me.idsalidaDetalle & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarSalidaProductoD() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idsalidaDetalle=" & "'" & Me.idsalidaDetalle & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarSalidaProductoDById(idusuario As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"'" & Me.idsalidaDetalle & "'", "'" & Me.cantidad & "'", "'" & Me.id_salidaProd & "'",
                                   "'" & Me.id_producto & "'"}
        Dim condiciones As String() = {"idsalidaDetalle=" & "'" & Me.idsalidaDetalle & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idsalidaDetalle")) And
               Not IsDBNull(result.Rows(0)("cantidad")) And
               Not IsDBNull(result.Rows(0)("id_salidaProd")) And
               Not IsDBNull(result.Rows(0)("id_producto")) Then
                SetIdSalidaProductoDetalle(CInt(result.Rows(0)("idsalidaDetalle")))
                SetCantidad(CInt(result.Rows(0)("cantidad")))
                SetIdsalidaProd(CInt(result.Rows(0)("id_salidaProd")))
                SetIdProducto(CInt(result.Rows(0)("id_producto")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarRegistroSalidaD() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaDetalle", "cantidad", "id_salidaProd", "id_producto"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarRegistroSalidaDByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idsalidaDetalle", Tabla & ".cantidad", Tabla & ".id_salidaProd",
                                    Tabla & ".id_producto"}

        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoIdSd() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idsalidaDetalle) AS idsalidaDetalle"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idsalidaDetalle")) Then
            Return CInt(result.Rows(0)("idsalidaDetalle"))
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
