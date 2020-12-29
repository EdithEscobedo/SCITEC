Public Class RegistroMerma
    Private producto As Producto = New Producto()
    Private registroMerma As RegMerma = New RegMerma()
    Private mermaDetalle As List(Of MermaDetalle) = New List(Of MermaDetalle)
    Private mermaDetalleOriginal As List(Of MermaDetalle) = New List(Of MermaDetalle)
    Private editable As Boolean = False
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtFolio.Text = CStr(registroMerma.BuscarUltimoId() + 1)
        Me.btnModificar.Enabled = False
        Me.btnQuitar.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.btnGuardar.Enabled = True
        Me.btnEditar.Enabled = False
    End Sub
    Public Sub New(idregMerma As Integer)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not registroMerma.BuscarRegistroMermaById(idregMerma) Then
            MsgBox("Registro Merma no encontrado", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If

        Me.txtFolio.Text = registroMerma.GetIdRegistroMerma()
        Me.dateMerma.Value = registroMerma.GetFechaRegistro()
        Me.txtObservacion.Text = registroMerma.GetDescripcion()

        Me.btnGuardar.Enabled = False
        Me.btnModificar.Enabled = True
        Me.btnEliminar.Enabled = True

        Me.editable = True

        BuscarMermas()
        MostrarMerma()
    End Sub
    Private Sub RegistroMerma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.producto.PoblarComboProducto(Me.cbProducto)
        'Me.txtNumeroUsuario.Text = My.Settings.iduser
        'Me.txtNombreUsuario.Text = My.Settings.username
    End Sub
    Private Sub RegistroMerma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.editable Then
            Dim form As Form = New Menu()
            form.Show()
        Else
            Dim form As Form = New Reportes()
            form.Show()
        End If
    End Sub
    Private Sub dgvRegistroMerma_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistroMerma.CellClick
        Try
            txtCantidad.Text = dgvRegistroMerma.CurrentRow.Cells("Cantidad").Value
            cbProducto.Text = dgvRegistroMerma.CurrentRow.Cells("Producto").Value

            Me.btnAgregar.Enabled = False
            Me.btnModificar.Enabled = True
            Me.btnQuitar.Enabled = True
        Catch ex As Exception
            MsgBox("Error en la operación: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim rM As MermaDetalle = New MermaDetalle()
        Dim maxId As MermaDetalle = mermaDetalle.OrderByDescending(
                             Function(x) x.GetIdMermaDetalle()).FirstOrDefault

        Dim productoExistente As MermaDetalle = mermaDetalle.Find(
            Function(x) x.GetIdProducto() = Me.cbProducto.SelectedValue)
        If Not IsNothing(productoExistente) Then
            MsgBox("Producto existente en la lista", MsgBoxStyle.Information, "INVÁLIDO")
            Exit Sub
        End If

        rM.SetIdMermaDetalle(If(Not IsNothing(maxId), maxId.GetIdMermaDetalle() + 1, rM.BuscarUltimoId() + 1))

        rM.SetCantidadMerma(CInt(Me.txtCantidad.Text))
        rM.SetIdRegistroMerma(CInt(Me.txtFolio.Text))
        rM.SetIdProducto(Me.cbProducto.SelectedValue)
        Me.mermaDetalle.Add(rM)

        LimpiarCampos()
        MostrarMerma()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim detalleMerma As MermaDetalle = mermaDetalle.Find(
           Function(x) x.GetIdMermaDetalle() = dgvRegistroMerma.CurrentRow.Cells("ID").Value)

        detalleMerma.SetCantidadMerma(CInt(Me.txtCantidad.Text))
        detalleMerma.SetIdProducto(Me.cbProducto.SelectedValue)

        LimpiarCampos()
        MostrarMerma()

        Me.btnEliminar.Enabled = False
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim index As Integer = mermaDetalle.FindIndex(
           Function(x) x.GetIdMermaDetalle() = dgvRegistroMerma.CurrentRow.Cells("ID").Value)

        mermaDetalle.RemoveAt(index)
        LimpiarCampos()
        MostrarMerma()

        Me.btnEliminar.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.registroMerma.SetIdRegistroMerma(CInt(Me.txtFolio.Text))
        Me.registroMerma.SetDescripcion(Me.txtObservacion.Text)
        Me.registroMerma.SetFechaRegistro(Me.dateMerma.Value)
        Me.registroMerma.SetIdUser(My.Settings.iduser)

        If (Not Me.registroMerma.AgregarRegistroMerma()) Then
            MsgBox("Error al agregar merma", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        For Each mermaD As MermaDetalle In mermaDetalle
            If (Not producto.BuscarProductoById(mermaD.GetIdProducto())) Then
                MsgBox("No se encontró el producto con el ID: " & mermaD.GetIdProducto(), MsgBoxStyle.Critical, "ERROR")
            End If

            producto.SetCantidadProducto(producto.GetCantidadProducto() - mermaD.GetCantidadMerma())

            If (Not mermaD.AgregarMermaDetalle()) Then
                MsgBox("Error al registrar merma", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

        Next
        MsgBox("Merma registrada", MsgBoxStyle.Information, "EXITO")
        Limpiar()
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.registroMerma.SetIdRegistroMerma(CInt(Me.txtFolio.Text))
        Me.registroMerma.SetDescripcion(Me.txtObservacion.Text)
        Me.registroMerma.SetFechaRegistro(Me.dateMerma.Value)
        Me.registroMerma.SetIdUser(My.Settings.iduser)

        If (Not Me.registroMerma.ActualizarRegistroMerma()) Then
            MsgBox("Error al actualizar merma", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        For Each mermaD As MermaDetalle In mermaDetalle
            If (Not producto.BuscarProductoById(mermaD.GetIdProducto())) Then
                MsgBox("No se encontró el producto con el ID: " & mermaD.GetIdProducto(), MsgBoxStyle.Critical, "ERROR")
            End If

            Dim mermaDetallePrevia As MermaDetalle = mermaDetalleOriginal.Find(
                Function(x) x.GetIdMermaDetalle() = mermaD.GetIdMermaDetalle())

            producto.SetCantidadProducto(producto.GetCantidadProducto() - (mermaD.GetCantidadMerma() - mermaDetallePrevia.GetCantidadMerma()))

            If (Not mermaD.ActualizarMermaDetalle()) Then
                MsgBox("Error al actualiar merma", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

        Next
        MsgBox("Merma Actualizada", MsgBoxStyle.Information, "EXITO")
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.registroMerma.SetIdRegistroMerma(CInt(Me.txtFolio.Text))
        Me.registroMerma.SetDescripcion(Me.txtObservacion.Text)
        Me.registroMerma.SetFechaRegistro(Me.dateMerma.Value)
        Me.registroMerma.SetIdUser(My.Settings.iduser)

        For Each mermaD As MermaDetalle In mermaDetalle
            If (Not producto.BuscarProductoById(mermaD.GetIdProducto())) Then
                MsgBox("No se encontró el producto con el ID: " & mermaD.GetIdProducto(), MsgBoxStyle.Critical, "ERROR")
            End If

            producto.SetCantidadProducto(producto.GetCantidadProducto() + mermaD.GetCantidadMerma())

            If (Not mermaD.EliminarMermaDetalle()) Then
                MsgBox("Error al eliminar merma", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

        Next

        If (Not Me.registroMerma.EliminarRegistroMerma()) Then
            MsgBox("Error al eliminar registro merma", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        MsgBox("Merma Eliminada", MsgBoxStyle.Information, "EXITO")
        Me.Close()
    End Sub
    Private Sub MostrarMerma()
        Dim detalleMerma As DataTable = New DataTable()
        detalleMerma.Columns.Add("ID")
        detalleMerma.Columns.Add("Producto")
        detalleMerma.Columns.Add("Cantidad")
        detalleMerma.Columns.Add("Unidad Medida")

        Dim unidadM As UnidadMedida = New UnidadMedida()

        For Each detalle As MermaDetalle In mermaDetalle
            Dim dm As DataRow = detalleMerma.NewRow()
            dm("ID") = detalle.GetIdMermaDetalle()
            dm("Cantidad") = detalle.GetCantidadMerma()
            producto.BuscarProductoById(detalle.GetIdProducto())
            dm("Producto") = producto.GetNombreProducto()
            unidadM.BuscarUnidadMById(producto.GetIdUnidadMedida())
            dm("Unidad Medida") = unidadM.GetNombreUnidadMedida()
            detalleMerma.Rows.Add(dm)

        Next
        Me.dgvRegistroMerma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.dgvRegistroMerma.DataSource = detalleMerma

        Me.dgvRegistroMerma.Columns("ID").Visible = False
    End Sub
    Private Sub BuscarMermas()
        Dim detalleMerma As DataTable

        Dim columnas As String() = {}
        Dim joins As String() = {}
        Dim condiciones As String() = {"idreg_m = '" & Me.txtFolio.Text & "'"}

        detalleMerma = New MermaDetalle().BuscarMermaDetalleDByConditions(columnas, joins, condiciones)

        For Each rowMerma As DataRow In detalleMerma.Rows
            Dim md As MermaDetalle = New MermaDetalle()
            md.SetIdMermaDetalle(CInt(rowMerma("idmermadetalle").ToString()))
            md.SetCantidadMerma(CInt(rowMerma("cantidadMerma").ToString()))
            md.SetIdProducto(CInt(rowMerma("id_producti").ToString()))
            md.SetIdRegistroMerma(CInt(rowMerma("idreg_m").ToString()))

            Dim mdO As MermaDetalle = New MermaDetalle()
            mdO.SetIdMermaDetalle(CInt(rowMerma("idmermadetalle").ToString()))
            mdO.SetCantidadMerma(CInt(rowMerma("cantidadMerma").ToString()))
            mdO.SetIdProducto(CInt(rowMerma("id_producti").ToString()))
            mdO.SetIdRegistroMerma(CInt(rowMerma("idreg_m").ToString()))

            mermaDetalle.Add(md)
            mermaDetalleOriginal.Add(mdO)
        Next
    End Sub
    Private Sub LimpiarCampos()
        Me.txtCantidad.Text = "0"
        Me.cbProducto.Text = ""

        Me.btnAgregar.Enabled = True
        Me.btnModificar.Enabled = False
        Me.btnQuitar.Enabled = False
    End Sub
    Private Sub Limpiar()
        Me.txtFolio.Text = CStr(registroMerma.BuscarUltimoId() + 1)
        Me.txtCantidad.Text = "0"
        Me.cbProducto.Text = ""
        Me.txtObservacion.Text = ""
        Me.mermaDetalle = New List(Of MermaDetalle)
        Me.dgvRegistroMerma.DataSource = Nothing

        Me.btnModificar.Enabled = False
        Me.btnQuitar.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.btnGuardar.Enabled = True
        Me.btnEditar.Enabled = False
    End Sub
End Class