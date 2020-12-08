Imports System.ComponentModel

Public Class Proveedores
    Private proveedor As Proveedor = New Proveedor()
    Private Sub Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarProveedor()
        Me.txtNumProveedor.Text = CStr(proveedor.BuscarUltimoId() + 10)
        Me.btnEditar.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.btnAgregar.Enabled = True
    End Sub

    Private Sub Proveedores_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Menu()
        form.Show()
    End Sub

    Private Sub dgvProveedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProveedores.CellClick
        Try
            txtNumProveedor.Text = dgvProveedores.CurrentRow.Cells("idProveedores").Value
            txtNomProveedor.Text = dgvProveedores.CurrentRow.Cells("nomProveedor").Value
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells("telProveedor").Value
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells("dirProveedor").Value
            txtCorreo.Text = dgvProveedores.CurrentRow.Cells("correoProveedor").Value
            Me.btnEditar.Enabled = True
            Me.btnEliminar.Enabled = True
            Me.btnAgregar.Enabled = False
        Catch ex As Exception
            MsgBox("Error en la operación: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Me.proveedor.SetIdProveedores(CInt(Me.txtNumProveedor.Text))
        Me.proveedor.SetNombreProveedor(Me.txtNomProveedor.Text)
        Me.proveedor.SetTelofonoProveedor(Me.txtTelefono.Text)
        Me.proveedor.SetDireccionProveedor(Me.txtDireccion.Text)
        Me.proveedor.SetCorreoProveedor(Me.txtCorreo.Text)

        If (Me.txtTelefono.Text.Length <> 10) Then
            MsgBox("EL número de teléfono tiene menos de 10 dígitos", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        If (Not Me.proveedor.AgregarProveedor()) Then
            MsgBox("Error al agregar proveedor", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        MsgBox("Proveedor registrado", MsgBoxStyle.Information, "EXITO")

        BuscarProveedor()
        LimpiarCampos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.proveedor.SetIdProveedores(CInt(Me.txtNumProveedor.Text))
        Me.proveedor.SetNombreProveedor(Me.txtNomProveedor.Text)
        Me.proveedor.SetTelofonoProveedor(Me.txtTelefono.Text)
        Me.proveedor.SetDireccionProveedor(Me.txtDireccion.Text)
        Me.proveedor.SetCorreoProveedor(Me.txtCorreo.Text)


        If (Not Me.proveedor.ActualizarProveedor()) Then
            MsgBox("Error al actualizar proveedor", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        MsgBox("Datos del proveedor actualizados", MsgBoxStyle.Information, "EXITO")

        BuscarProveedor()
        LimpiarCampos()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
        Me.btnEditar.Enabled = False
        Me.btnEliminar.Enabled = False
        Me.btnAgregar.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.proveedor.SetIdProveedores(CInt(Me.txtNumProveedor.Text))
        Me.proveedor.SetNombreProveedor(Me.txtNomProveedor.Text)
        Me.proveedor.SetTelofonoProveedor(Me.txtTelefono.Text)
        Me.proveedor.SetDireccionProveedor(Me.txtDireccion.Text)
        Me.proveedor.SetCorreoProveedor(Me.txtCorreo.Text)

        Dim confirmacion As MsgBoxResult = MsgBox(
            "El siguiente producto se va a eliminar: " & vbNewLine &
            "ID: " & Me.proveedor.GetIdProveedores() & vbNewLine &
            "Nombre: " & Me.proveedor.GetNombreProveedor() & vbNewLine &
            "Telefono: " & Me.proveedor.GetTelefonoProveedor() & vbNewLine &
            "Dirección: " & Me.proveedor.GetDireccionProveedor() & vbNewLine &
            "Correo: " & Me.proveedor.GetCorreoProveedor() & vbNewLine &
            "Desea continuar?",
            MsgBoxStyle.OkCancel, "ELIMINAR!")
        If confirmacion = MsgBoxResult.Cancel Then
            Exit Sub
        End If

        If (Not Me.proveedor.EliminarProveedor()) Then
            MsgBox("Error al Eliminar proveedor", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If
        MsgBox("Proveedor Eliminado", MsgBoxStyle.Information, "EXITO")

        BuscarProveedor()
        LimpiarCampos()
    End Sub
    Private Sub BuscarProveedor()
        Me.dgvProveedores.DataSource = Me.proveedor.BuscarProveedor()

        'Mostrar columnas en el DataGridView de manera ordenada
        Me.dgvProveedores.Columns("idProveedores").DisplayIndex = 0
        Me.dgvProveedores.Columns("idProveedores").HeaderText = "ID"
        Me.dgvProveedores.Columns("nomProveedor").DisplayIndex = 1
        Me.dgvProveedores.Columns("nomProveedor").HeaderText = "Proveedor"
        Me.dgvProveedores.Columns("telProveedor").DisplayIndex = 2
        Me.dgvProveedores.Columns("telProveedor").HeaderText = "Teléfono"
        Me.dgvProveedores.Columns("dirProveedor").DisplayIndex = 3
        Me.dgvProveedores.Columns("dirProveedor").HeaderText = "Dirección"
        Me.dgvProveedores.Columns("correoProveedor").DisplayIndex = 4
        Me.dgvProveedores.Columns("correoProveedor").HeaderText = "Correo"

        Me.dgvProveedores.Sort(Me.dgvProveedores.Columns("idProveedores"), ListSortDirection.Ascending)
        'Ajustar tamaño de celdas
        Me.dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
    Private Sub LimpiarCampos()
        Me.txtNumProveedor.Text = CStr(proveedor.BuscarUltimoId() + 10)
        Me.txtNomProveedor.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtCorreo.Text = ""

    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class