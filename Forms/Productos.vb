Public Class Productos
    Private producto As Producto = New Producto()
    Private categoria As CategoriaProducto = New CategoriaProducto()
    Private unidadMedida As UnidadMedida = New UnidadMedida()

    Private Sub Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarProductos()
        Me.txtIdProducto.Text = CStr(producto.BuscarUltimoId() + 1)
        Me.categoria.PoblarComboCategoria(Me.cbCategoria)
        Me.unidadMedida.PoblarComboUnidadMedida(Me.cbUnidadM)
    End Sub

    Private Sub BuscarProductos()
        ' Condiciones de consulta para mostrar categoria y unidad de medida de productos
        Dim columnas As String() = {"cat_producto.nom_catP, unidad_medida.nom_unidadM"}
        Dim joins As String() = {"INNER JOIN cat_producto ON productos.id_catP = cat_producto.idcat_producto",
                                 "INNER JOIN unidad_medida ON productos.id_unidM = unidad_medida.idunidadM"}
        Dim condiciones As String() = {}

        Me.DataProductos.DataSource = producto.BuscarProductosByConditions(columnas, joins, condiciones)

        'Mostrar columnas en el DataGridView de manera ordenada
        Me.DataProductos.Columns("idProductos").DisplayIndex = 0
        Me.DataProductos.Columns("idProductos").HeaderText = "ID"
        Me.DataProductos.Columns("nombreProducto").DisplayIndex = 1
        Me.DataProductos.Columns("nombreProducto").HeaderText = "Producto"
        Me.DataProductos.Columns("nom_catP").DisplayIndex = 2
        Me.DataProductos.Columns("nom_catP").HeaderText = "Categoria"
        Me.DataProductos.Columns("cantidadProducto").DisplayIndex = 3
        Me.DataProductos.Columns("cantidadProducto").HeaderText = "Cantidad"
        Me.DataProductos.Columns("nom_unidadM").DisplayIndex = 4
        Me.DataProductos.Columns("nom_unidadM").HeaderText = "Unidad Medida"

        'Remover columnas
        Me.DataProductos.Columns.Remove("id_catP")
        Me.DataProductos.Columns.Remove("id_unidM")
        'Ajustar tamaño de celdas
        If Me.DataProductos.Rows.Count > 0 Then
            Dim noColumnas = DataProductos.Columns.Count
            For index = 0 To noColumnas - 1
                Me.DataProductos.Columns(index).Width = CInt(Me.DataProductos.Width / noColumnas)
            Next
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.producto.SetIdProductos(CInt(Me.txtIdProducto.Text))
        Me.producto.SetNombreProducto(Me.txtNombre.Text)
        Me.producto.SetIdCategoriaProducto(Me.cbCategoria.SelectedValue)
        Me.producto.SetCantidadProducto(CInt(Me.txtCantidad.Text))
        Me.producto.SetIdUnidadMedida(Me.cbUnidadM.SelectedValue)

        If (Not Me.producto.ActualizarProducto()) Then
            MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        MsgBox("Producto actualizado", MsgBoxStyle.Information, "EXITO")

        BuscarProductos()
    End Sub

    Private Sub DataProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataProductos.CellClick
        Try
            txtIdProducto.Text = DataProductos.CurrentRow.Cells("idProductos").Value
            txtNombre.Text = DataProductos.CurrentRow.Cells("nombreProducto").Value
            cbCategoria.Text = DataProductos.CurrentRow.Cells("nom_catP").Value
            txtCantidad.Text = DataProductos.CurrentRow.Cells("cantidadProducto").Value
            cbUnidadM.Text = DataProductos.CurrentRow.Cells("nom_unidadM").Value
        Catch ex As Exception
            MsgBox("Error en la operación: " & ex.Message)
        End Try
    End Sub

    Private Sub Productos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Ajustar tamaño de celdas
        If Me.DataProductos.Rows.Count > 0 Then
            Dim noColumnas = DataProductos.Columns.Count
            For index = 0 To noColumnas - 1
                Me.DataProductos.Columns(index).Width = CInt(Me.DataProductos.Width / noColumnas)
            Next
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.txtIdProducto.Text = CStr(producto.BuscarUltimoId() + 1)
        Me.txtNombre.Text = ""
        Me.cbCategoria.Text = ""
        Me.txtCantidad.Text = ""
        Me.cbUnidadM.Text = ""
    End Sub
End Class