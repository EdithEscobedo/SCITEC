Public Class Menu
    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
End Class