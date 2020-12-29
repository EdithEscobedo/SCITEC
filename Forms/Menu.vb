Public Class Menu
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim user As Usuario = New Usuario()
        Dim type_user As TipoUsuario = New TipoUsuario()

        user.BuscarUsuarioById(My.Settings.iduser)
        type_user.BuscarTipoUsuarioById(user.GetIdTipoUsuario)

        If type_user.GetNomTipoU().ToLower.Equals("gerente") Then
            Me.btnReportes.Enabled = True
            Me.btnProveedores.Enabled = True
            Me.btnUsuarios.Enabled = True
        End If
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim form As Form = New Productos()
        form.Show()
        Me.Close()
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Dim form As Form = New Usuarios()
        form.Show()
        Me.Close()
    End Sub

    Private Sub btnCompras_Click(sender As Object, e As EventArgs) Handles btnCompras.Click
        Dim form As Form = New Compras()
        form.Show()
        Me.Close()
    End Sub

    Private Sub btnRegistroSalida_Click(sender As Object, e As EventArgs) Handles btnRegistroSalida.Click
        Dim form As Form = New RegSalidaP()
        form.Show()
        Me.Close()
    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles btnProveedores.Click
        Dim form As Form = New Proveedores()
        form.Show()
        Me.Close()
    End Sub

    Private Sub btnMerma_Click(sender As Object, e As EventArgs) Handles btnMerma.Click
        Dim form As Form = New RegistroMerma()
        form.Show()
        Me.Close()
    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        Dim form As Form = New Reportes()
        form.Show()
        Me.Close()
    End Sub
End Class