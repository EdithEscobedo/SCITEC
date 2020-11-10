Imports System.Text.RegularExpressions

Public Class CrearUsuarios
    Private tipo_usuario As TipoUsuario = New TipoUsuario()
    Private usuario As Usuario = New Usuario()

    Private Sub CrearUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Genera numero de usuario
        Me.tipo_usuario.PoblarComboTipoUsuario(Me.cbTipoUsuario)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'valida solo numeros 
        If (Not IsNumeric(Me.txtTelefono.Text)) Then
            MsgBox("El telefono contiene letras", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        If (Me.txtTelefono.Text.Length <> 10) Then
            MsgBox("EL numero de telefono tiene mas o menos de 10 dígitos", MsgBoxStyle.Critical, "ERROR")
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

    Private Sub CrearUsuarios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Menu()
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
        Else
            limpiarDatos()
        End If
    End Sub

    Private Sub limpiarDatos()
        Me.usuario = New Usuario()

        Me.txtNumUsuario.Text = usuario.BuscarUltimoId() + 1
        Me.txtNomUsuario.Text = ""
        Me.txtTelefono.Text = 0.00
        Me.txtUsername.Text = ""
    End Sub

    Public Sub New(idusuario As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        poblarDatosUsuarios(idusuario)
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtNumUsuario.Text = CStr(usuario.BuscarUltimoId() + 10)

    End Sub
End Class
