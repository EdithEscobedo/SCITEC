﻿Public Class Producto
    Private Const Tabla As String = "Productos"

    Private idProductos As Integer
    Private nombreProducto As String
    Private cantidadProducto As Integer
    Private id_catP As Integer
    Private id_unidM As Integer
    Private estadoProducto As String
    Public Sub New()

    End Sub

    Public Sub New(idProductos As Integer,
                     nombreProducto As String,
                     cantidadProducto As Integer,
                     estadoProducto As String,
                     id_catP As Integer,
                     id_unidM As Integer)

        Me.idProductos = idProductos
        Me.nombreProducto = nombreProducto
        Me.cantidadProducto = cantidadProducto
        Me.estadoProducto = estadoProducto
        Me.id_catP = id_catP
        Me.id_unidM = id_unidM
    End Sub
    Public Sub SetIdProductos(idProductos As Integer)
        Me.idProductos = idProductos
    End Sub

    Public Sub SetNombreProducto(nombreProducto As String)
        Me.nombreProducto = nombreProducto
    End Sub
    Public Sub SetCantidadProducto(cantidadProducto As Integer)
        Me.cantidadProducto = cantidadProducto
    End Sub
    Public Sub SetEstadoProducto(estadoProducto As String)
        Me.estadoProducto = estadoProducto
    End Sub
    Public Sub SetIdCategoriaProducto(id_catP As Integer)
        Me.id_catP = id_catP
    End Sub
    Public Sub SetIdUnidadMedida(id_unidM As Integer)
        Me.id_unidM = id_unidM
    End Sub
    Public Function GetIdProductos() As Integer
        Return Me.idProductos
    End Function
    Public Function GetNombreProducto() As String
        Return Me.nombreProducto
    End Function
    Public Function GetCantidadProducto() As Integer
        Return Me.cantidadProducto
    End Function
    Public Function GetEstadoProducto() As String
        Return Me.estadoProducto
    End Function
    Public Function GetidCategoriaProducto() As Integer
        Return Me.id_catP
    End Function
    Public Function GetIdUnidadMedida() As String
        Return Me.id_unidM
    End Function
    Public Function AgregarProducto() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProductos", "nombreProducto", "cantidadProducto", "estadoProducto",
                                    "id_catP", "id_unidM"}
        Dim valores As String() = {"'" & Me.idProductos & "'", "'" & Me.nombreProducto & "'", "'" & Me.cantidadProducto & "'",
                                   "'" & Me.estadoProducto & "'", "'" & Me.id_catP & "'", "'" & Me.id_unidM & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarProducto() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProductos", "nombreProducto", "cantidadProducto", "estadoProducto",
                                    "id_catP", "id_unidM"}
        Dim valores As String() = {"'" & Me.idProductos & "'", "'" & Me.nombreProducto & "'", "'" & Me.cantidadProducto & "'",
                                   "'" & Me.estadoProducto & "'", "'" & Me.id_catP & "'", "'" & Me.id_unidM & "'"}
        Dim condiciones As String() = {"idProductos=" & "'" & Me.idProductos & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarProducto() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idProductos=" & "'" & Me.idProductos & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarProductoById(idProductos As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProductos", "nombreProducto", "cantidadProducto", "estadoProducto", "id_catP",
                                    "id_unidM"}
        Dim condiciones As String() = {"idProductos='" & idProductos & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idProductos")) And
               Not IsDBNull(result.Rows(0)("nombreProducto")) And
               Not IsDBNull(result.Rows(0)("cantidadProducto")) And
               Not IsDBNull(result.Rows(0)("estadoProducto")) And
               Not IsDBNull(result.Rows(0)("id_catP")) And
               Not IsDBNull(result.Rows(0)("id_unidM")) Then
                SetIdProductos(CInt(result.Rows(0)("idProductos")))
                SetNombreProducto(CStr(result.Rows(0)("nombreProducto")))
                SetCantidadProducto(CInt(result.Rows(0)("cantidadProducto")))
                SetEstadoProducto(CStr(result.Rows(0)("estadoProducto")))
                SetIdCategoriaProducto(CInt(result.Rows(0)("id_catP")))
                SetIdUnidadMedida(CInt(result.Rows(0)("id_unidM")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarProducto() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProductos", "nombreProducto", "cantidadProducto", "estadoProducto", "id_catP",
                                    "id_unidM"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarProductosByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idProductos", Tabla & ".nombreProducto", Tabla & ".cantidadProducto",
                                    Tabla & ".estadoProducto", Tabla & ".id_catP", Tabla & ".id_unidM"}

        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idProductos) AS idProductos"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idProductos")) Then
            Return CInt(result.Rows(0)("idProductos"))
        Else
            Return 0
        End If
    End Function
    Public Sub PoblarComboProducto(cbPrducto As ComboBox)
        cbPrducto.DisplayMember = "Value"
        cbPrducto.ValueMember = "Key"

        Dim columnas As String() = {"unidad_medida.nom_unidadM"}
        Dim joins As String() = {"INNER JOIN unidad_medida On productos.id_unidM = unidad_medida.idunidadM"}
        Dim conditions As String() = {"estadoProducto = 'activo'"}

        Dim producto As DataTable = BuscarProductosByConditions(columnas, joins, conditions)
        producto.DefaultView.Sort = "idProductos ASC"
        producto = producto.DefaultView.ToTable()

        If producto.Rows.Count > 0 Then
            Dim tipoUDictionary As New Dictionary(Of Integer, String)
            For index = 0 To producto.Rows.Count - 1
                tipoUDictionary.Add(producto.Rows(index)("idProductos"),
                                    producto.Rows(index)("nombreProducto") & " - " & producto.Rows(index)("nom_unidadM"))
            Next
            cbPrducto.DataSource = New BindingSource(tipoUDictionary, Nothing)
        Else
            cbPrducto.DataSource = Nothing
        End If
    End Sub
End Class