Public Class Proveedor
    Private Const Tabla As String = "proveedores"

    Private idProveedores As Integer
    Private nombProveedor As String
    Private telProveedor As String
    Private dirProveedor As String
    Private correoProveedor As String
    Public Sub New()

    End Sub

    Public Sub New(idProveedores As Integer,
                   nombProveedor As String,
                   telProveedor As String,
                   dirProveedor As String,
                   correoProveedor As String)

        Me.idProveedores = idProveedores
        Me.nombProveedor = nombProveedor
        Me.telProveedor = telProveedor
        Me.dirProveedor = dirProveedor
        Me.correoProveedor = correoProveedor

    End Sub
    Public Sub SetIdProveedores(idProveedores As Integer)
        Me.idProveedores = idProveedores
    End Sub

    Public Sub SetNombreProveedor(nombreProveedor As String)
        Me.nombProveedor = nombreProveedor
    End Sub
    Public Sub SetTelofonoProveedor(telProveedor As String)
        Me.telProveedor = telProveedor
    End Sub
    Public Sub SetDireccionProveedor(dirProveedor As String)
        Me.dirProveedor = dirProveedor
    End Sub
    Public Sub SetCorreoProveedor(correProveedor As String)
        Me.correoProveedor = correoProveedor
    End Sub
    Public Function GetIdProveedores() As Integer
        Return Me.idProveedores
    End Function
    Public Function GetNombreProveedor() As String
        Return Me.nombProveedor
    End Function
    Public Function GetTelefonoProveedor() As String
        Return Me.telProveedor
    End Function
    Public Function GetDireccionProveedor() As String
        Return Me.dirProveedor
    End Function
    Public Function GetCorreoProveedor() As String
        Return Me.correoProveedor
    End Function
    Public Function AgregarProveedor() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProveedores", "nomProveedor", "telProveedor", "dirProveedor",
                                    "correoProveedor"}
        Dim valores As String() = {"'" & Me.idProveedores & "'", "'" & Me.nombProveedor & "'", "'" & Me.telProveedor & "'",
                                   "'" & Me.dirProveedor & "'", "'" & Me.correoProveedor & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarProveedor() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProveedores", "nomProveedor", "telProveedor", "dirProveedor",
                                    "correoProveedor"}
        Dim valores As String() = {"'" & Me.idProveedores & "'", "'" & Me.nombProveedor & "'", "'" & Me.telProveedor & "'",
                                   "'" & Me.dirProveedor & "'", "'" & Me.correoProveedor & "'"}
        Dim condiciones As String() = {"idProveedores=" & "'" & Me.idProveedores & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarProveedor() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idProveedores=" & "'" & Me.idProveedores & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarProveedorById(idusuario As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProveedores", "nomProveedor", "telProveedor", "dirProveedor",
                                    "correoProveedor"}
        Dim condiciones As String() = {"idProveedores='" & idProveedores & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idProveedores")) And
               Not IsDBNull(result.Rows(0)("nomProveedor")) And
               Not IsDBNull(result.Rows(0)("telProveedor")) And
               Not IsDBNull(result.Rows(0)("dirProveedor")) And
               Not IsDBNull(result.Rows(0)("correoProveedor")) Then
                SetIdProveedores(CInt(result.Rows(0)("idProveedores")))
                SetNombreProveedor(CStr(result.Rows(0)("nomProveedor")))
                SetTelofonoProveedor(CInt(result.Rows(0)("telProveedor")))
                SetDireccionProveedor(CStr(result.Rows(0)("dirProveedor")))
                SetCorreoProveedor(CInt(result.Rows(0)("correoProveedor")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarProveedor() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idProveedores", "nomProveedor", "telProveedor", "dirProveedor",
                                    "correoProveedor"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarProveedorByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idProveedores", Tabla & ".nomProveedor", Tabla & ".telProveedor",
                                    Tabla & ".dirProveedor", Tabla & ".correoProveedor"}

        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idProveedores) AS idProveedores"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idProveedores")) Then
            Return CInt(result.Rows(0)("idProveedores"))
        Else
            Return 0
        End If
    End Function
    Public Sub PoblarComboProveedor(cbProveedor As ComboBox)
        cbProveedor.DisplayMember = "Value"
        cbProveedor.ValueMember = "Key"
        Dim proveedor As DataTable = BuscarProveedor()
        proveedor.DefaultView.Sort = "idProveedores ASC"
        proveedor = proveedor.DefaultView.ToTable()

        If proveedor.Rows.Count > 0 Then
            Dim tipoUDictionary As New Dictionary(Of Integer, String)
            For index = 0 To proveedor.Rows.Count - 1
                tipoUDictionary.Add(proveedor.Rows(index)("idProveedores"), proveedor.Rows(index)("nomProveedor"))
            Next
            cbProveedor.DataSource = New BindingSource(tipoUDictionary, Nothing)
        Else
            cbProveedor.DataSource = Nothing
        End If
    End Sub
End Class
