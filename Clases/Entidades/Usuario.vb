Public Class Usuario
    Private Const Tabla As String = "Usuario"

    Private idusuario As Integer
    Private nom_usuario As String
    Private tel_usuario As String
    Private username As String
    Private password As String
    Private idTipoU As Integer

    Public Sub New()

    End Sub

    Public Sub New(idusuario As Integer,
                     nom_usuario As String,
                     tel_usuario As String,
                     username As String,
                     password As String,
                     idTipoU As Integer)

        Me.idusuario = idusuario
        Me.nom_usuario = nom_usuario
        Me.tel_usuario = tel_usuario
        Me.username = username
        Me.password = password
        Me.idTipoU = idTipoU
    End Sub
    Public Sub SetIdUsuario(idusuario As Integer)
        Me.idusuario = idusuario
    End Sub

    Public Sub SetNombreUsuario(nom_usuario As String)
        Me.nom_usuario = nom_usuario
    End Sub
    Public Sub SetTelefonoUsuario(tel_usuario As String)
        Me.tel_usuario = tel_usuario
    End Sub
    Public Sub SetUsername(username As String)
        Me.username = username
    End Sub
    Public Sub SetPassword(password As String)
        ' convert to byte array
        Dim byteArry As Byte() = System.Text.Encoding.UTF8.GetBytes(password)
        ' convert bytes to Base64:
        Me.password = System.Convert.ToBase64String(byteArry)
    End Sub
    Private Sub SetPasswordDB(password As String)
        Me.password = password
    End Sub
    Public Sub SetIdTipoUsuario(idTipoU As Integer)
        Me.idTipoU = idTipoU
    End Sub

    Public Function GetIdUsuario() As Integer
        Return Me.idusuario
    End Function
    Public Function GetNombreUsuario() As String
        Return Me.nom_usuario
    End Function
    Public Function GetTelefonoUsuario() As String
        Return Me.tel_usuario
    End Function
    Public Function GetUsername() As String
        Return Me.username
    End Function
    Public Function GetPassword() As String
        Return Me.password
    End Function
    Public Function GetIdTipoUsuario() As Integer
        Return Me.idTipoU
    End Function
    Public Function CompararPassword(confPassword As String) As Boolean
        ' convert to byte array
        Dim byteArry As Byte() = System.Text.Encoding.UTF8.GetBytes(confPassword)
        ' convert bytes to Base64:
        Dim encryptedPass = System.Convert.ToBase64String(byteArry)
        If (encryptedPass = Me.password) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function RegistrarUsuario() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idusuario", "nom_usuario", "tel_usuario", "username", "password", "idTipoU"}
        Dim valores As String() = {"'" & Me.idusuario & "'", "'" & Me.nom_usuario & "'", "'" & Me.tel_usuario & "'",
                                   "'" & Me.username & "'", "'" & Me.password & "'", "'" & Me.idTipoU & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarUsuario() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idusuario", "nom_usuario", "tel_usuario", "username", "password", "idTipoU"}
        Dim valores As String() = {"'" & Me.idusuario & "'", "'" & Me.nom_usuario & "'", "'" & Me.tel_usuario & "'",
                                   "'" & Me.username & "'", "'" & Me.password & "'", "'" & Me.idTipoU & "'"}
        Dim condiciones As String() = {"idusuario=" & "'" & Me.idusuario & "'"}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarUsuario() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idusuario=" & "'" & Me.idusuario & "'"}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarUsuarioById(idusuario As Integer) As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idusuario", "nom_usuario", "tel_usuario", "username", "password", "idTipoU"}
        Dim condiciones As String() = {"idusuario='" & idusuario & "'"}
        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, condiciones)

        If result.Rows.Count = 1 Then
            If Not IsDBNull(result.Rows(0)("idusuario")) And
               Not IsDBNull(result.Rows(0)("nom_usuario")) And
               Not IsDBNull(result.Rows(0)("tel_usuario")) And
               Not IsDBNull(result.Rows(0)("username")) And
               Not IsDBNull(result.Rows(0)("password")) And
               Not IsDBNull(result.Rows(0)("idTipoU")) Then
                SetIdTipoUsuario(CInt(result.Rows(0)("idusuario")))
                SetNombreUsuario(CStr(result.Rows(0)("nom_usuario")))
                SetTelefonoUsuario(CStr(result.Rows(0)("tel_usuario")))
                SetUsername(CStr(result.Rows(0)("username")))
                SetPasswordDB(CStr(result.Rows(0)("password")))
                SetIdTipoUsuario(CInt(result.Rows(0)("idTipoU")))
                Return True
            Else
                Throw New Exception("Error: Columna con valores vacios.")
            End If
        Else
            Return False
        End If
    End Function
    Public Function BuscarUsuario() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idusuario", "nom_usuario", "tel_usuario", "username", "password", "idTipoU"}

        Return database.Buscar({Tabla}, columnas, {})
    End Function
    Public Function BuscarUltimoId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idusuario) AS idusuario"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idusuario")) Then
            Return CInt(result.Rows(0)("idusuario"))
        Else
            Return 0
        End If
    End Function
End Class
