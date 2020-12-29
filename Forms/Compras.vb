Public Class Compras
    Private proveedor As Proveedor = New Proveedor()
    Private producto As Producto = New Producto()
    Private compra As Compra = New Compra()
    'Declaramos un arreglo de compra detalle
    Private compraDetalle As List(Of CompraDetalle) = New List(Of CompraDetalle)
    Private compraDetalleOriginal As List(Of CompraDetalle) = New List(Of CompraDetalle)
    Private editable As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtFolio.Text = CStr(compra.BuscarUltimoIdCompra() + 1)
        Me.btnModificarProducto.Enabled = False
        Me.btnQuitarProducto.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.btnGuardar.Enabled = True
        Me.btnModificar.Enabled = False
    End Sub
    Public Sub New(idcompras As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not compra.BuscarCompraById(idcompras) Then
            MsgBox("Compra no encontrada", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If

        Me.txtFolio.Text = compra.GetIdCompras()
        Me.dateFechaCompra.Value = compra.GetFechaCompra()
        Me.cbProveedor.SelectedItem = compra.GetIdProveedor()
        Me.cbProveedor.Enabled = False

        Me.btnEliminar.Enabled = True
        Me.btnGuardar.Enabled = False
        Me.btnModificar.Enabled = True

        Me.editable = True

        BuscarCompras()
        MostrarCompra()
    End Sub

    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.proveedor.PoblarComboProveedor(Me.cbProveedor)
        Me.producto.PoblarComboProducto(Me.cbProducto)
    End Sub
    Private Sub Compras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.editable Then
            Dim form As Form = New Menu()
            form.Show()
        Else
            Dim form As Form = New Reportes()
            form.Show()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnIngresaProducto_Click(sender As Object, e As EventArgs) Handles btnIngresaProducto.Click
        Dim cD As CompraDetalle = New CompraDetalle()
        Dim maxId As CompraDetalle = compraDetalle.OrderByDescending(
                             Function(x) x.GetIdCompraDetalle()).FirstOrDefault

        Dim productoExistente As CompraDetalle = compraDetalle.Find(
            Function(x) x.GetIdProductooo() = Me.cbProducto.SelectedValue)
        If Not IsNothing(productoExistente) Then
            MsgBox("Producto existente en la lista", MsgBoxStyle.Information, "INVÁLIDO")
            Exit Sub
        End If

        cD.SetIdCompraDetalle(If(Not IsNothing(maxId), maxId.GetIdCompraDetalle() + 1, cD.BuscarUltimoId() + 1))

        cD.SetCantCompra(CInt(Me.txtCantidad.Text))
        cD.SetIdCompraa(CInt(Me.txtFolio.Text))
        cD.SetIdProductooo(Me.cbProducto.SelectedValue)
        Me.compraDetalle.Add(cD)
        Me.cbProveedor.Enabled = False

        LimpiarCampos()
        MostrarCompra()
    End Sub
    Private Sub dgvDetalleCompra_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleCompra.CellClick
        Try
            txtCantidad.Text = dgvDetalleCompra.CurrentRow.Cells("Cantidad").Value
            cbProducto.Text = dgvDetalleCompra.CurrentRow.Cells("Producto").Value

            Me.btnIngresaProducto.Enabled = False
            Me.btnModificarProducto.Enabled = True
            Me.btnQuitarProducto.Enabled = True
        Catch ex As Exception
            MsgBox("Error en la operación: " & ex.Message)
        End Try
    End Sub

    Private Sub btnModificarProducto_Click(sender As Object, e As EventArgs) Handles btnModificarProducto.Click
        Dim detalleProducto As CompraDetalle = compraDetalle.Find(
            Function(x) x.GetIdCompraDetalle() = dgvDetalleCompra.CurrentRow.Cells("ID").Value)

        detalleProducto.SetCantCompra(CInt(Me.txtCantidad.Text))
        detalleProducto.SetIdProductooo(Me.cbProducto.SelectedValue)

        LimpiarCampos()
        MostrarCompra()

        Me.btnEliminar.Enabled = False
    End Sub

    Private Sub btnQuitarProducto_Click(sender As Object, e As EventArgs) Handles btnQuitarProducto.Click
        Dim index As Integer = compraDetalle.FindIndex(
            Function(x) x.GetIdCompraDetalle() = dgvDetalleCompra.CurrentRow.Cells("ID").Value)

        compraDetalle.RemoveAt(index)
        LimpiarCampos()
        MostrarCompra()

        Me.btnEliminar.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.compra.SetIdCompras(CInt(Me.txtFolio.Text))
        Me.compra.SetIdProveedor(Me.cbProveedor.SelectedValue)
        Me.compra.SetFechaCompra(Me.dateFechaCompra.Value)
        Me.compra.SetIdUser(My.Settings.iduser)

        If (Not Me.compra.AgregarCompra()) Then
            MsgBox("Error al agregar compra", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        For Each compD As CompraDetalle In compraDetalle
            If (Not producto.BuscarProductoById(compD.GetIdProductooo())) Then
                MsgBox("No se encontró el producto con el ID: " & compD.GetIdProductooo(), MsgBoxStyle.Critical, "ERROR")
            End If

            producto.SetCantidadProducto(producto.GetCantidadProducto() + compD.GetCantCompra())

            If (Not compD.AgregarCompraD()) Then
                MsgBox("Error al agregar compra", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
        Next

        MsgBox("Compra agregada", MsgBoxStyle.Information, "EXITO")
        Limpiar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Me.compra.SetIdCompras(CInt(Me.txtFolio.Text))
        Me.compra.SetIdProveedor(Me.cbProveedor.SelectedValue)
        Me.compra.SetFechaCompra(Me.dateFechaCompra.Value)
        Me.compra.SetIdUser(My.Settings.iduser)

        If (Not Me.compra.ActualizarCompras()) Then
            MsgBox("Error al actualizar compra", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        For Each compD As CompraDetalle In compraDetalle
            If (Not producto.BuscarProductoById(compD.GetIdProductooo())) Then
                MsgBox("No se encontró el producto con el ID: " & compD.GetIdProductooo(), MsgBoxStyle.Critical, "ERROR")
            End If

            Dim compraDetallePrevia As CompraDetalle = compraDetalleOriginal.Find(
                Function(x) x.GetIdCompraDetalle() = compD.GetIdCompraDetalle())

            producto.SetCantidadProducto(producto.GetCantidadProducto() + (compD.GetCantCompra() - compraDetallePrevia.GetCantCompra()))

            If (Not compD.ActualizarComprasD()) Then
                MsgBox("Error al actualizar compra", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            Me.Close()
        Next
        MsgBox("Compra actualizada", MsgBoxStyle.Information, "EXITO")
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.compra.SetIdCompras(CInt(Me.txtFolio.Text))
        Me.compra.SetIdProveedor(Me.cbProveedor.SelectedValue)
        Me.compra.SetFechaCompra(Me.dateFechaCompra.Value)
        Me.compra.SetIdUser(My.Settings.iduser)

        For Each compD As CompraDetalle In compraDetalle
            If (Not producto.BuscarProductoById(compD.GetIdProductooo())) Then
                MsgBox("No se encontró el producto con el ID: " & compD.GetIdProductooo(), MsgBoxStyle.Critical, "ERROR")
            End If

            producto.SetCantidadProducto(producto.GetCantidadProducto() - compD.GetCantCompra())

            If (Not compD.EliminarCompraD()) Then
                MsgBox("Error al eliminar compra", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
        Next

        If (Not Me.compra.EliminarCompra()) Then
            MsgBox("Error al eliminar compra", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        MsgBox("Compra eliminada", MsgBoxStyle.Information, "EXITO")
        Me.Close()
    End Sub
    Private Sub MostrarCompra()
        Dim detalleCompra As DataTable = New DataTable()
        detalleCompra.Columns.Add("ID")
        detalleCompra.Columns.Add("Producto")
        detalleCompra.Columns.Add("Cantidad")
        detalleCompra.Columns.Add("Unidad Medida")

        Dim unidadM As UnidadMedida = New UnidadMedida()

        For Each detalle As CompraDetalle In compraDetalle
            Dim dr As DataRow = detalleCompra.NewRow()
            dr("ID") = detalle.GetIdCompraDetalle()
            dr("Cantidad") = detalle.GetCantCompra()
            producto.BuscarProductoById(detalle.GetIdProductooo())
            dr("Producto") = producto.GetNombreProducto()
            unidadM.BuscarUnidadMById(producto.GetIdUnidadMedida())
            dr("Unidad Medida") = unidadM.GetNombreUnidadMedida()
            detalleCompra.Rows.Add(dr)
        Next
        Me.dgvDetalleCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.dgvDetalleCompra.DataSource = detalleCompra

        Me.dgvDetalleCompra.Columns("ID").Visible = False
    End Sub

    Private Sub BuscarCompras()
        Dim detalleCompra As DataTable

        Dim columnas As String() = {}
        Dim joins As String() = {}
        Dim condiciones As String() = {"id_compraa = '" & Me.txtFolio.Text & "'"}

        detalleCompra = New CompraDetalle().BuscarCompraDetalleByConditions(columnas, joins, condiciones)

        For Each rowCompra As DataRow In detalleCompra.Rows
            Dim cd As CompraDetalle = New CompraDetalle()
            cd.SetIdCompraDetalle(CInt(rowCompra("idcompraDetalle").ToString()))
            cd.SetCantCompra(CInt(rowCompra("cantCompra").ToString()))
            cd.SetIdProductooo(CInt(rowCompra("id_productooo").ToString()))
            cd.SetIdCompraa(CInt(rowCompra("id_compraa").ToString()))

            Dim cdO As CompraDetalle = New CompraDetalle()
            cdO.SetIdCompraDetalle(CInt(rowCompra("idcompraDetalle").ToString()))
            cdO.SetCantCompra(CInt(rowCompra("cantCompra").ToString()))
            cdO.SetIdProductooo(CInt(rowCompra("id_productooo").ToString()))
            cdO.SetIdCompraa(CInt(rowCompra("id_compraa").ToString()))

            compraDetalle.Add(cd)
            compraDetalleOriginal.Add(cdO)
        Next
    End Sub

    Private Sub LimpiarCampos()
        Me.txtCantidad.Text = "0"
        Me.cbProducto.Text = ""

        Me.btnIngresaProducto.Enabled = True
        Me.btnModificarProducto.Enabled = False
        Me.btnQuitarProducto.Enabled = False
    End Sub
    Private Sub Limpiar()
        Me.txtFolio.Text = CStr(compra.BuscarUltimoIdCompra() + 1)
        Me.txtCantidad.Text = "0"
        Me.cbProducto.Text = ""
        Me.cbProveedor.Text = ""
        Me.cbProveedor.Enabled = True
        Me.compraDetalle = New List(Of CompraDetalle)
        Me.dgvDetalleCompra.DataSource = Nothing

        Me.btnModificarProducto.Enabled = False
        Me.btnQuitarProducto.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.btnGuardar.Enabled = True
        Me.btnModificar.Enabled = False
    End Sub
End Class