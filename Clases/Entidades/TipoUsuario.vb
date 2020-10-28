Public Class TipoUsuario
    Private Const Tabla As String = "tipousuario"
    Private idtipousuario As Integer
    Private nom_tipoU As String

    Public Sub New()

    End Sub
    Public Sub New(idtipousuario As Integer, nom_tipoU As String)
        Me.idtipousuario = idtipousuario
        Me.nom_tipoU = nom_tipoU
    End Sub

    Public Function GetIdTipoUsuario() As Integer
        Return Me.idtipousuario
    End Function

    Public Function GetNomTipoU() As String
        Return Me.nom_tipoU
    End Function

    Public Sub SetIdTipoUsuario(idtipousuario As Integer)
        Me.idtipousuario = idtipousuario
    End Sub

    Public Sub SetNomTipoU(nom_tipoU As String)
        Me.nom_tipoU = nom_tipoU
    End Sub
    Public Function RegistrarTipoUsuario() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idtipousuario", "nom_tipoU"}
        Dim valores As String() = {BuscarTipoUsuarioId() + 1, "'" & Me.nom_tipoU & "'"}
        Dim result = database.Insertar(Tabla, columnas, valores)
        Return result
    End Function
    Public Function ActualizarTipoUsuario() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"nom_tipoU"}
        Dim valores As String() = {"'" & Me.nom_tipoU & "'"}
        Dim condiciones As String() = {"idtipousuario=" & Me.idtipousuario}
        Dim result = database.Actualizar(Tabla, columnas, valores, condiciones)
        Return result
    End Function

    Public Function EliminarTipoUsuario() As Boolean
        Dim database As BaseDatos = New BaseDatos()
        Dim condiciones As String() = {"idtipousuario=" & Me.idtipousuario}
        Dim result = database.Eliminar(Tabla, condiciones)
        Return result
    End Function
    Public Function BuscarTipoUsuarioId() As Integer
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"Max(idtipousuario) AS idtipousuario"}

        Dim result As DataTable

        result = database.Buscar({Tabla}, columnas, {})
        If result.Rows.Count = 1 And Not IsDBNull(result.Rows(0)("idtipousuario")) Then
            Return CInt(result.Rows(0)("idtipousuario"))
        Else
            Return 0
        End If
    End Function
    Public Function BuscarTipoUsuario() As DataTable
        Dim database As BaseDatos = New BaseDatos()
        Dim columnas As String() = {"idtipousuario", "nom_tipoU"}
        Dim result As DataTable = database.Buscar({Tabla}, columnas, {})
        result.DefaultView.Sort = "idtipousuario ASC"

        Return result
    End Function
    Public Sub PoblarComboTipoUsuario(cbTipoUsuario As ComboBox)
        cbTipoUsuario.DisplayMember = "Value"
        cbTipoUsuario.ValueMember = "Key"
        Dim tipousuario As DataTable = BuscarTipoUsuario()
        tipousuario.DefaultView.Sort = "idtipousuario ASC"
        tipousuario = tipousuario.DefaultView.ToTable()

        If tipousuario.Rows.Count > 0 Then
            Dim tipoUDictionary As New Dictionary(Of Integer, String)
            For index = 0 To tipousuario.Rows.Count - 1
                tipoUDictionary.Add(tipousuario.Rows(index)("idtipousuario"), tipousuario.Rows(index)("nom_tipoU"))
            Next
            cbTipoUsuario.DataSource = New BindingSource(tipoUDictionary, Nothing)
        Else
            cbTipoUsuario.DataSource = Nothing
        End If
    End Sub
End Class
