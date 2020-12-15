Public Class RegistroMerma
    Private producto As Producto = New Producto()
    Private registroMerma As RegMerma = New RegMerma()
    Private mermaDetalle As List(Of MermaDetalle) = New List(Of MermaDetalle)
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
    End Sub
    Private Sub RegistroMerma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.producto.PoblarComboProducto(Me.cbProducto)
        'Me.txtNumeroUsuario.Text = My.Settings.iduser
        'Me.txtNombreUsuario.Text = My.Settings.username
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
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim index As Integer = mermaDetalle.FindIndex(
           Function(x) x.GetIdMermaDetalle() = dgvRegistroMerma.CurrentRow.Cells("ID").Value)

        mermaDetalle.RemoveAt(index)
        LimpiarCampos()
        MostrarMerma()
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
        MsgBox("Salida registrada", MsgBoxStyle.Information, "EXITO")
        Limpiar()
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

    Private Sub RegistroMerma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Menu()
        form.Show()
    End Sub
End Class