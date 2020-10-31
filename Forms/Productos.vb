Public Class Productos
    Private producto As Producto = New Producto()
    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarProductos()
    End Sub

    Private Sub BuscarProductos()
        ' Condiciones de consulta para mostrar categoria y unidad de medida de productos
        Dim columnas As String() = {"cat_producto.nom_catP, unidad_medida.nom_unidadM"}
        Dim joins As String() = {"INNER JOIN cat_producto ON productos.id_catP = cat_producto.idcat_producto",
                                 "INNER JOIN unidad_medida ON productos.id_unidM = unidad_medida.idunidadM"}
        Dim condiciones As String() = {}

        Me.DataProductos.DataSource = producto.BuscarProductosByConditions(columnas, joins, condiciones)

        Me.DataProductos.Columns("idProductos").DisplayIndex = 0
        Me.DataProductos.Columns("idProductos").HeaderText = "ID"
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

    End Sub
End Class