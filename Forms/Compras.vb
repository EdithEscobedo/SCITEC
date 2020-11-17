Public Class Compras
    Private proveedor As Proveedor = New Proveedor()
    Private producto As Producto = New Producto()
    Private compra As Compra = New Compra()
    Private compraD As CompraDetalle = New CompraDetalle()

    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.proveedor.PoblarComboProveedor(Me.cbProveedor)
        Me.producto.PoblarComboProducto(Me.cbProducto)
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectedIndexChanged

    End Sub

    Private Sub Compras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Menu()
        form.Show()
    End Sub

    Public Sub New(idusuario As Integer)

        ' Esta llamada es exigida por el diseñador.
        'InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'poblarDatosUsuarios(idusuario)
    End Sub

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtFolio.Text = CStr(Compra.BuscarUltimoIdC() + 1)

    End Sub

End Class