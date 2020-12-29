Public Class IniciarSesion
    Private usuario As Usuario = New Usuario()
    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        If Not usuario.BuscarUsuarioByUsername(Me.txtUser.Text) Then
            MsgBox("Usuario o contraseña invalidos", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        If Not usuario.CompararPassword(Me.txtPassword.Text) Then
            MsgBox("Usuario o contraseña invalidos", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        My.Settings.iduser = usuario.GetIdUsuario()
        My.Settings.username = usuario.GetUsername()
        My.Settings.Save()

        Dim form As Form = New Menu()
        form.Show()
        Me.Close()
    End Sub
    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            If Not usuario.BuscarUsuarioByUsername(Me.txtUser.Text) Then
                MsgBox("Usuario o contraseña invalidos", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            If Not usuario.CompararPassword(Me.txtPassword.Text) Then
                MsgBox("Usuario o contraseña invalidos", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If
            My.Settings.iduser = usuario.GetIdUsuario()
            My.Settings.username = usuario.GetUsername()
            My.Settings.Save()

            Dim form As Form = New Menu()
            form.Show()
            Me.Close()
        End If
    End Sub
End Class