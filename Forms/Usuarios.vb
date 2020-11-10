Imports System.ComponentModel

Public Class Usuarios
    Private usuario As Usuario = New Usuario()

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarUsuarios()
    End Sub

    Private Sub BuscarUsuarios()
        ' Condiciones de consulta para mostrar tipo de usuario del usuario.
        Dim columnas As String() = {"tipousuario.idtipousuario"}
        Dim joins As String() = {"INNER JOIN tipousuario ON usuario.idTipoU = tipousuario.idtipousuario"}
        Dim condiciones As String() = {}

        Me.DataUsuarios.DataSource = usuario.BuscarUsuariosByConditions(columnas, joins, condiciones)

        'Mostrar columnas en el DataGridView de manera ordenada
        Me.DataUsuarios.Columns("idUsuario").DisplayIndex = 0
        Me.DataUsuarios.Columns("idUsuario").HeaderText = "ID"
        Me.DataUsuarios.Columns("nom_usuario").DisplayIndex = 1
        Me.DataUsuarios.Columns("nom_usuario").HeaderText = "Usuario"
        Me.DataUsuarios.Columns("tel_usuario").DisplayIndex = 2
        Me.DataUsuarios.Columns("tel_usuario").HeaderText = "Telefono"
        Me.DataUsuarios.Columns("username").DisplayIndex = 3
        Me.DataUsuarios.Columns("username").HeaderText = "Username"
        Me.DataUsuarios.Columns("idTipoU").DisplayIndex = 4
        Me.DataUsuarios.Columns("idTipoU").HeaderText = "Tipo Usuario"

        'Remover columnas
        Me.DataUsuarios.Columns.Remove("password")
        Me.DataUsuarios.Sort(Me.DataUsuarios.Columns("idUsuario"), ListSortDirection.Ascending)
        'Ajustar tamaño de celdas
        If Me.DataUsuarios.Rows.Count > 0 Then
            Dim noColumnas = DataUsuarios.Columns.Count
            For index = 0 To noColumnas - 1
                Me.DataUsuarios.Columns(index).Width = CInt(Me.DataUsuarios.Width / noColumnas)
            Next
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim form As Form = New CrearUsuarios()
        form.Show()
        Me.Close()
    End Sub

    Private Sub DataUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataUsuarios.CellClick
        Me.usuario.SetIdUsuario(CInt(Me.DataUsuarios.CurrentRow.Cells("idusuario").Value))
        Me.usuario.SetNombreUsuario(Me.DataUsuarios.CurrentRow.Cells("nom_usuario").Value)
        Me.usuario.SetTelefonoUsuario(Me.DataUsuarios.CurrentRow.Cells("tel_usuario").Value)
        Me.usuario.SetUsername(Me.DataUsuarios.CurrentRow.Cells("username").Value)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim confirmacion As MsgBoxResult = MsgBox(
               "El siguiente producto se va a eliminar: " & vbNewLine &
              "ID: " & Me.usuario.GetIdUsuario() & vbNewLine &
             "Nombre: " & Me.usuario.GetNombreUsuario() & vbNewLine &
           "Username: " & Me.usuario.GetUsername() & vbNewLine &
          "Desea continuar?",
          MsgBoxStyle.OkCancel, "ELIMINAR!")
        If confirmacion = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If (Not Me.usuario.EliminarUsuario()) Then
            MsgBox("Error al usuario producto", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        MsgBox("Usuario Eliminado", MsgBoxStyle.Information, "EXITO")

        BuscarUsuarios()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As Form = New CrearUsuarios(Me.usuario.GetIdUsuario)
        form.Show()
    End Sub
End Class