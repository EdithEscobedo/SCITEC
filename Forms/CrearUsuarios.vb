Imports System.Text.RegularExpressions

Public Class CrearUsuarios
    Private tipo_usuario As TipoUsuario = New TipoUsuario()
    Private usuario As Usuario = New Usuario()

    Private nuevoUsuario As Boolean = False
    Private passwordValida As Boolean = False

    'Ususario Existente
    Public Sub New(idusuario As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        poblarDatosUsuarios(idusuario)
    End Sub
    ' Nuevo Usuario
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtNumUsuario.Text = CStr(usuario.BuscarUltimoId() + 10)
        Me.nuevoUsuario = True
    End Sub
    Private Sub CrearUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Genera numero de usuario
        Me.tipo_usuario.PoblarComboTipoUsuario(Me.cbTipoUsuario)
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.usuario.BuscarUsuariosByConditions(
                                                 {}, {}, {"nom_usuario LIKE '%" &
                                                 Me.txtNomUsuario.Text.Replace(" ", "%") & "%'"}
                                                 ).Rows.Count > 0 Then
            MsgBox("EL nombre de usuario ya existe.", MsgBoxStyle.Critical, "ERROR")
            Me.txtNomUsuario.Text = ""
            Me.txtNomUsuario.Select()
            Exit Sub
        End If
        If Me.usuario.BuscarUsuariosByConditions({}, {}, {"username = '" & Me.txtUsername.Text & "'"}).Rows.Count > 0 Then
            MsgBox("EL username ya existe.", MsgBoxStyle.Critical, "ERROR")
            Me.txtUsername.Text = ""
            Me.txtUsername.Select()
            Exit Sub
        End If
        If (Me.txtTelefono.Text.Length <> 10) Then
            MsgBox("EL numero de telefono tiene menos de 10 dígitos", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        If Not Me.passwordValida Then
            MsgBox("La contraseña no es valida.", MsgBoxStyle.Critical, "ERROR")
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
        If Me.nuevoUsuario Or Me.txtPassword.Text <> "" Then
            Me.usuario.SetPassword(Me.txtPassword.Text)
        End If

        If Me.nuevoUsuario Then
            If (Not Me.usuario.RegistrarUsuario()) Then
                MsgBox("Error al registrar usuario", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            MsgBox("Usuario registrado", MsgBoxStyle.Information, "EXITO")
            Me.Close()
        Else
            If (Not Me.usuario.ActualizarUsuario()) Then
                MsgBox("Error al actualizar usuario", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            MsgBox("Usuario actualizado", MsgBoxStyle.Information, "EXITO")
            Me.Close()
        End If
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
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub CrearUsuarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Usuarios()
        form.Show()
    End Sub
    Private Sub poblarDatosUsuarios(idusuario As Integer)
        Me.usuario = New Usuario()

        If usuario.BuscarUsuarioById(idusuario) Then
            Me.txtNumUsuario.Text = usuario.GetIdUsuario()
            Me.txtNomUsuario.Text = usuario.GetNombreUsuario()
            Me.txtTelefono.Text = usuario.GetTelefonoUsuario()
            Me.cbTipoUsuario.SelectedValue = usuario.GetIdTipoUsuario()
            Me.txtUsername.Text = usuario.GetUsername()
            Me.passwordValida = True
        Else
            MsgBox("El ID de usuario es inexistente.", MsgBoxStyle.Critical, "ERROR!")
            Me.Close()
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        Me.lblNivelPassword.Visible = True
        If Me.txtPassword.TextLength = 0 And Not Me.nuevoUsuario Then
            Me.lblNivelPassword.Text = "Contraseña Invalida"
            Me.lblNivelPassword.ForeColor = Color.Red
            Me.lblNivelPassword.Visible = False
            Me.passwordValida = True
            Exit Sub
        End If
        'Nivel Invalido
        If Me.txtPassword.TextLength < 8 Or Not Regex.Match(Me.txtPassword.Text, "^[0-9a-zA-Z]+$").Success Then
            Me.lblNivelPassword.Text = "Contraseña Invalida"
            Me.lblNivelPassword.ForeColor = Color.Red
            Me.passwordValida = False
            Exit Sub
        End If
        'Nivel Bajo
        If Me.txtPassword.TextLength >= 8 Then
            Me.lblNivelPassword.Text = "Contraseña Débil"
            Me.lblNivelPassword.ForeColor = Color.Orange
            Me.passwordValida = True
        End If
        'Nivel Medio
        If Me.txtPassword.TextLength >= 12 And Regex.Match(Me.txtPassword.Text, "^[0-9a-zA-Z]+$").Success Then
            Me.lblNivelPassword.Text = "Contraseña Media"
            Me.lblNivelPassword.ForeColor = Color.Brown
            Me.passwordValida = True
        End If
        'Nivel Alto
        If Me.txtPassword.TextLength >= 16 And Regex.Match(Me.txtPassword.Text, "^[0-9a-zA-Z]+$").Success Then
            Me.lblNivelPassword.Text = "Contraseña Fuerte"
            Me.lblNivelPassword.ForeColor = Color.Green
            Me.passwordValida = True
        End If
    End Sub

    Private Sub txtConfPass_TextChanged(sender As Object, e As EventArgs) Handles txtConfPass.TextChanged
        Me.lblCoincidenciaPassword.Visible = True
        If Me.txtPassword.Text <> Me.txtConfPass.Text Then
            Me.lblCoincidenciaPassword.Text = "Contraseña no coincide."
            Me.lblCoincidenciaPassword.ForeColor = Color.Red
        Else
            Me.lblCoincidenciaPassword.Text = "Contraseña Correcta."
            Me.lblCoincidenciaPassword.ForeColor = Color.Green
        End If
    End Sub
End Class
