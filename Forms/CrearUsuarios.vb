Imports System.Text.RegularExpressions

Public Class CrearUsuarios
    Private tipo_usuario As TipoUsuario = New TipoUsuario()
    Private usuario As Usuario = New Usuario()

    Private Sub CrearUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Genera numero de usuario
        Me.txtNumUsuario.Text = CStr(usuario.BuscarUltimoId() + 10)
        Me.tipo_usuario.PoblarComboTipoUsuario(Me.cbTipoUsuario)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'valida solo numeros 
        If (Regex.IsMatch(Me.txtTelefono.Text, "^[0-9]+$")) Then
            MsgBox("El telefono contiene letras", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        If (Me.txtPassword.Text <> Me.txtConfPass.Text) Then
            MsgBox("No coinciden las contraseñas", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        Me.usuario.SetIdUsuario(CInt(Me.txtNumUsuario.Text))
        Me.usuario.SetNombreUsuario(Me.txtNomUsuario.Text)
        Me.usuario.SetTelefonoUsuario(Me.txtTelefono.Text)
        Me.usuario.SetIdTipoUsuario(Me.cbTipoUsuario.SelectedValue)
        Me.usuario.SetUsername(Me.txtUsername.Text)
        Me.usuario.SetPassword(Me.txtPassword.Text)

        If (Not Me.usuario.RegistrarUsuario()) Then
            MsgBox("Error al registrar usuario", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        MsgBox("Usuario registrado", MsgBoxStyle.Information, "EXITO")
        LimpiarCampos()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub LimpiarCampos()
        Me.txtNumUsuario.Text = CStr(usuario.BuscarUltimoId() + 10)
        Me.txtNomUsuario.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtUsername.Text = ""
        Me.txtPassword.Text = ""
        Me.txtConfPass.Text = ""
        Me.tipo_usuario.PoblarComboTipoUsuario(Me.cbTipoUsuario)
    End Sub
End Class
