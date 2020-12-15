Public Class RegMerma
    Private Const Tabla As String = "regmerma"
    Private idregMerma As Integer
    Private fechaReg As Date
    Private descripcion As String
    Private iduseer As Integer
    Public Sub New()

    End Sub

    Public Sub New(idregMerma As Integer,
                     fechaReg As Date,
                     descripcion As String,
                     iduseer As Integer)

        Me.idregMerma = idregMerma
        Me.fechaReg = fechaReg
        Me.descripcion = descripcion
        Me.iduseer = iduseer
    End Sub
    Public Sub SetIdRegistroMerma(idregMerma As Integer)
        Me.idregMerma = idregMerma
    End Sub
    Public Sub SetFechaRegistro(fechaReg As Date)
        Me.fechaReg = fechaReg
    End Sub
    Public Sub SetDescripcion(descripcion As String)
        Me.descripcion = descripcion
    End Sub
    Public Sub SetIdUser(iduseer As Integer)
        Me.iduseer = iduseer
    End Sub

    Public Function GetIdRegistroMerma() As Integer
        Return Me.idregMerma
    End Function
    Public Function GetFechaRegistro() As Date
        Return Me.fechaReg
    End Function
    Public Function GetDescripcion() As String
        Return Me.descripcion
    End Function
    Public Function GetIdUser() As String
        Return Me.iduseer
    End Function

    Public Function AgregarRegistroMerma() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idregMerma", "fechaReg", "descripcion", "iduseer"}
        Dim valores As String() = {"'" & Me.idregMerma & "'", "'" & Me.fechaReg.ToString("yyyy-MM-dd") & "'", "'" & Me.descripcion & "'", "'" & Me.iduseer & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarRegistroMerma() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idregMerma", "fechaReg", "descripcion", "iduseer"}
        Dim valores As String() = {"'" & Me.idregMerma & "'", "'" & Me.fechaReg.ToString("yyyy-MM-dd") & "'", "'" & Me.descripcion & "'", "'" & Me.iduseer & "'"}
        Dim condiciones As String() = {"idregMerma=" & "'" & Me.idregMerma & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarRegistroMerma() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idregMerma=" & "'" & Me.idregMerma & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarRegistroMermaById(idusuario As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idregMerma", "fechaReg", "descripcion", "iduseer"}
        Dim condiciones As String() = {"idregMerma='" & idregMerma & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idregMerma")) And
               Not IsDBNull(result.Rows(0)("fechaReg")) And
               Not IsDBNull(result.Rows(0)("descripcion")) And
               Not IsDBNull(result.Rows(0)("iduseer")) Then
                SetIdRegistroMerma(CInt(result.Rows(0)("idregMerma")))
                SetFechaRegistro(CStr(result.Rows(0)("fechaReg")))
                SetDescripcion(CStr(result.Rows(0)("descripcion")))
                SetIdUser(CInt(result.Rows(0)("iduseer")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarRegistroMerma() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idregMerma", "fechaREG", "descripcion", "iduseer"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarRegistroMermaByConditions(columnasExtra As String(), joins As String(), condiciones As String()) As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {Tabla & ".idregMerma", Tabla & ".fechaReg", Tabla & ".descripcion", Tabla & ".iduseer"}
        Return database.Buscar({Tabla}, columnasExtra.Union(columnas).ToArray, joins, condiciones)
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idregMerma) AS idregMerma"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idregMerma")) Then
            Return CInt(result.Rows(0)("idregMerma"))
        Else
            Return 0
        End If
    End Function
End Class
