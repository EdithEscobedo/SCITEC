Public Class RegSalidaPro
    Private Const Tabla As String = "salidaproducto"
    Private idsalidaProducto As Integer
    Private fecha_salida As Date
    Private id_user As Integer
    Private razon As String
    Public Sub New()

    End Sub

    Public Sub New(idsalidaProducto As Integer,
                     fecha_salida As Date,
                     id_user As Integer,
                   razon As String)

        Me.idsalidaProducto = idsalidaProducto
        Me.fecha_salida = fecha_salida
        Me.id_user = id_user
        Me.razon = razon
    End Sub
    Public Sub SetIdSalidaProducto(idsalidaProducto As Integer)
        Me.idsalidaProducto = idsalidaProducto
    End Sub
    Public Sub SetFechaSalida(fecha_salida As Date)
        Me.fecha_salida = fecha_salida
    End Sub
    Public Sub SetIdUser(id_user As Integer)
        Me.id_user = id_user
    End Sub
    Public Sub SetRazon(razon As String)
        Me.razon = razon
    End Sub
    Public Function GetIdSalidaProdcuto() As Integer
        Return Me.idsalidaProducto
    End Function
    Public Function GetFechaSalida() As Date
        Return Me.fecha_salida
    End Function
    Public Function GetIdUser() As String
        Return Me.id_user
    End Function
    Public Function GetRazon() As String
        Return Me.razon
    End Function

    Public Function AgregarSalidaProducto() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaProducto", "fecha_salida", "id_user", "razon"}
        Dim valores As String() = {"'" & Me.idsalidaProducto & "'", "'" & Me.fecha_salida.ToString("yyyy-MM-dd") & "'", "'" & Me.id_user & "'", "'" & Me.razon & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarSalidaProducto() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaProducto", "fecha_salida", "id_user", "razon"}
        Dim valores As String() = {"'" & Me.idsalidaProducto & "'", "'" & Me.fecha_salida.ToString("yyyy-MM-dd") & "'", "'" & Me.id_user & "'", "'" & Me.razon & "'"}
        Dim condiciones As String() = {"idsalidaProducto=" & "'" & Me.idsalidaProducto & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarSalidaProducto() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idsalidaProducto=" & "'" & Me.idsalidaProducto & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarSalidaProdutoById(idsalidaProducto As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaProducto", "fecha_salida", "id_user", "razon"}
        Dim condiciones As String() = {"idsalidaProducto='" & idsalidaProducto & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idsalidaProducto")) And
               Not IsDBNull(result.Rows(0)("fecha_salida")) And
               Not IsDBNull(result.Rows(0)("id_user")) And
               Not IsDBNull(result.Rows(0)("razon")) Then
                SetIdSalidaProducto(CInt(result.Rows(0)("idsalidaProducto")))
                SetFechaSalida(CDate(result.Rows(0)("fecha_salida")))
                SetIdUser(CInt(result.Rows(0)("id_user")))
                SetRazon(CStr(result.Rows(0)("razon")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarSalidaProducto() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idsalidaProducto", "fecha_salida", "id_user", "razon"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarSalidaProductoByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idsalidaProducto", Tabla & ".fecha_salida", Tabla & ".id_user", Tabla & ".razon"}
        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idsalidaProducto) AS idsalidaProducto"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idsalidaProducto")) Then
            Return CInt(result.Rows(0)("idsalidaProducto"))
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

