Public Class MermaDetalle
    Private Const Tabla As String = "mermadetalle"
    Private idmermadetalle As Integer
    Private cantidadMerma As Integer
    Private idreg_m As Integer
    Private id_producti As Integer
    Public Sub New()

    End Sub

    Public Sub New(idmermadetalle As Integer,
                     cantidadMerma As Integer,
                     idreg_m As Integer,
                     id_producti As Integer)

        Me.idmermadetalle = idmermadetalle
        Me.cantidadMerma = cantidadMerma
        Me.idreg_m = idreg_m
        Me.id_producti = id_producti
    End Sub
    Public Sub SetIdMermaDetalle(idmermadetalle As Integer)
        Me.idmermadetalle = idmermadetalle
    End Sub
    Public Sub SetCantidadMerma(cantidadMerma As Integer)
        Me.cantidadMerma = cantidadMerma
    End Sub
    Public Sub SetIdRegistroMerma(idreg_m As Integer)
        Me.idreg_m = idreg_m
    End Sub
    Public Sub SetIdProducto(id_producti As Integer)
        Me.id_producti = id_producti
    End Sub
    Public Function GetIdMermaDetalle() As Integer
        Return Me.idmermadetalle
    End Function
    Public Function GetCantidadMerma() As Integer
        Return Me.cantidadMerma
    End Function
    Public Function GetIdRegistrarMerma() As Integer
        Return Me.idreg_m
    End Function
    Public Function GetIdProducto() As Integer
        Return Me.id_producti
    End Function

    Public Function AgregarMermaDetalle() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idmermadetalle", "cantidadMerma", "idreg_m", "id_producti"}
        Dim valores As String() = {"'" & Me.idmermadetalle & "'", "'" & Me.cantidadMerma & "'", "'" & Me.idreg_m & "'",
                                   "'" & Me.id_producti & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarMermaDetalle() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idmermadetalle", "cantidadMerma", "idreg_m", "id_producti"}
        Dim valores As String() = {"'" & Me.idmermadetalle & "'", "'" & Me.cantidadMerma & "'", "'" & Me.idreg_m & "'",
                                   "'" & Me.id_producti & "'"}
        Dim condiciones As String() = {"idmermadetalle=" & "'" & Me.idmermadetalle & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarMermaDetalle() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idmermadetalle=" & "'" & Me.idmermadetalle & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarMermaDetalleById(idusuario As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"'" & Me.idmermadetalle & "'", "'" & Me.cantidadMerma & "'", "'" & Me.idreg_m & "'",
                                   "'" & Me.id_producti & "'"}
        Dim condiciones As String() = {"idmermadetalle=" & "'" & Me.idmermadetalle & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idmermadetalle")) And
               Not IsDBNull(result.Rows(0)("cantidadMerma")) And
               Not IsDBNull(result.Rows(0)("idreg_m")) And
               Not IsDBNull(result.Rows(0)("id_producti")) Then
                SetIdMermaDetalle(CInt(result.Rows(0)("idmermadetalle")))
                SetCantidadMerma(CInt(result.Rows(0)("cantidadMerma")))
                SetIdRegistroMerma(CInt(result.Rows(0)("idreg_m")))
                SetIdProducto(CInt(result.Rows(0)("id_producti")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarMermaDetalle() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idmermadetale", "cantidadMerma", "idreg_m", "id_producti"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarMermaDetalleDByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idmermadetalle", Tabla & ".cantidadMerma", Tabla & ".idreg_m",
                                    Tabla & ".idproducti"}

        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idmermadetalle) AS idmermadetalle"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idmermadetalle")) Then
            Return CInt(result.Rows(0)("idmermadetalle"))
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
