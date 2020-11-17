Public Class Compras
    Private proveedor As Proveedor = New Proveedor()
    Private producto As Producto = New Producto()
    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.proveedor.PoblarComboProveedor(Me.cbProveedor)
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged

    End Sub

    Private Sub Compras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Menu()
        form.Show()
    End Sub
End Class