﻿Imports System.ComponentModel

Public Class RegSalidaP
    Private producto As Producto = New Producto()
    Private salida As RegSalidaPro = New RegSalidaPro()
    'Declaramos un arreglo de compra detalle
    Private salidaDetalle As List(Of RegSalidaProD) = New List(Of RegSalidaProD)
    Private salidaDetallePrevia As List(Of RegSalidaProD) = New List(Of RegSalidaProD)
    Private editable As Boolean = False
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtFolioSalida.Text = CStr(salida.BuscarUltimoId() + 1)
        Me.btnModificar.Enabled = False
        Me.btnQuitar.Enabled = False
        Me.btnEliminarSalida.Enabled = False
        Me.btnGuardarSalida.Enabled = True
        Me.btnEditarSalida.Enabled = False
    End Sub
    Public Sub New(idsalidaProducto As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        If Not salida.BuscarSalidaProdutoById(idsalidaProducto) Then
            MsgBox("Salida no encontrada", MsgBoxStyle.Critical)
            Me.Close()
            Exit Sub
        End If

        Me.txtFolioSalida.Text = salida.GetIdSalidaProdcuto()
        Me.txtRazon.Text = salida.GetRazon()
        Me.dateFechaSalida.Value = salida.GetFechaSalida()

        Me.btnGuardarSalida.Enabled = False
        Me.btnEliminarSalida.Enabled = True
        Me.btnEditarSalida.Enabled = True

        Me.editable = True

        BuscarSalida()
        MostrarSalida()
    End Sub
    Private Sub RegSalidaP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.producto.PoblarComboProducto(Me.cbProducto)
        Me.txtNumeroUsuario.Text = My.Settings.iduser
        Me.txtNombreUsuario.Text = My.Settings.username
    End Sub

    Private Sub RegSalidaP_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.editable Then
            Dim form As Form = New Menu()
            form.Show()
        Else
            Dim form As Form = New Reportes()
            form.Show()
        End If
    End Sub
    Private Sub dgvRegistroSalida_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistroSalida.CellClick
        Try
            txtCantidad.Text = dgvRegistroSalida.CurrentRow.Cells("Cantidad").Value
            cbProducto.Text = dgvRegistroSalida.CurrentRow.Cells("Producto").Value

            Me.btnIngresar.Enabled = False
            Me.btnModificar.Enabled = True
            Me.btnQuitar.Enabled = True
        Catch ex As Exception
            MsgBox("Error en la operación: " & ex.Message)
        End Try
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim sD As RegSalidaProD = New RegSalidaProD()
        Dim maxId As RegSalidaProD = salidaDetalle.OrderByDescending(
                             Function(x) x.GetIdSalidaProductoDetalle()).FirstOrDefault

        Dim productoExistente As RegSalidaProD = salidaDetalle.Find(
            Function(x) x.GetIdProducto() = Me.cbProducto.SelectedValue)
        If Not IsNothing(productoExistente) Then
            MsgBox("Producto existente en la lista", MsgBoxStyle.Information, "INVÁLIDO")
            Exit Sub
        End If

        sD.SetIdSalidaProductoDetalle(If(Not IsNothing(maxId), maxId.GetIdSalidaProductoDetalle() + 1, sD.BuscarUltimoIdSd() + 1))

        sD.SetCantidad(CInt(Me.txtCantidad.Text))
        sD.SetIdsalidaProd(CInt(Me.txtFolioSalida.Text))
        sD.SetIdProducto(Me.cbProducto.SelectedValue)
        Me.salidaDetalle.Add(sD)

        LimpiarCampos()
        MostrarSalida()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim detalleProducto As RegSalidaProD = salidaDetalle.Find(
            Function(x) x.GetIdSalidaProductoDetalle() = dgvRegistroSalida.CurrentRow.Cells("ID").Value)

        detalleProducto.SetCantidad(CInt(Me.txtCantidad.Text))
        detalleProducto.SetIdProducto(Me.cbProducto.SelectedValue)

        LimpiarCampos()
        MostrarSalida()

        Me.btnEliminarSalida.Enabled = False
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        Dim index As Integer = salidaDetalle.FindIndex(
            Function(x) x.GetIdSalidaProductoDetalle() = dgvRegistroSalida.CurrentRow.Cells("ID").Value)

        salidaDetalle.RemoveAt(index)
        LimpiarCampos()
        MostrarSalida()

        Me.btnEliminarSalida.Enabled = False
    End Sub

    Private Sub btnGuardarSalida_Click(sender As Object, e As EventArgs) Handles btnGuardarSalida.Click
        Me.salida.SetIdSalidaProducto(CInt(Me.txtFolioSalida.Text))
        Me.salida.SetRazon(Me.txtRazon.Text)
        Me.salida.SetFechaSalida(Me.dateFechaSalida.Value)
        Me.salida.SetIdUser(My.Settings.iduser)

        If (Not Me.salida.AgregarSalidaProducto()) Then
            MsgBox("Error al agregar salida", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        For Each salidaD As RegSalidaProD In salidaDetalle
            If (Not producto.BuscarProductoById(salidaD.GetIdProducto())) Then
                MsgBox("No se encontró el producto con el ID: " & salidaD.GetIdProducto(), MsgBoxStyle.Critical, "ERROR")
            End If

            producto.SetCantidadProducto(producto.GetCantidadProducto() - salidaD.GetCantidad())

            If (Not salidaD.AgregarRegistroSalidaD()) Then
                MsgBox("Error al registrar salida", MsgBoxStyle.Critical, "ERROR")
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

    Private Sub btnEditarSalida_Click(sender As Object, e As EventArgs) Handles btnEditarSalida.Click
        Me.salida.SetIdSalidaProducto(CInt(Me.txtFolioSalida.Text))
        Me.salida.SetRazon(Me.txtRazon.Text)
        Me.salida.SetFechaSalida(Me.dateFechaSalida.Value)
        Me.salida.SetIdUser(My.Settings.iduser)

        If (Not Me.salida.ActualizarSalidaProducto()) Then
            MsgBox("Error al agregar salida", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        For Each salidaD As RegSalidaProD In salidaDetalle
            If (Not producto.BuscarProductoById(salidaD.GetIdProducto())) Then
                MsgBox("No se encontró el producto con el ID: " & salidaD.GetIdProducto(), MsgBoxStyle.Critical, "ERROR")
            End If

            Dim detallePrevia As RegSalidaProD = salidaDetallePrevia.Find(
                Function(x) x.GetIdSalidaProductoDetalle() = salidaD.GetIdSalidaProductoDetalle())

            producto.SetCantidadProducto(producto.GetCantidadProducto() - (salidaD.GetCantidad() - detallePrevia.GetCantidad()))

            If (Not salidaD.ActualizarSalidaProductoD()) Then
                MsgBox("Error al registrar salida", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
        Next

        salidaDetallePrevia = salidaDetalle

        MsgBox("Salida registrada", MsgBoxStyle.Information, "EXITO")
        Me.Close()
    End Sub

    Private Sub btnEliminarSalida_Click(sender As Object, e As EventArgs) Handles btnEliminarSalida.Click
        Me.salida.SetIdSalidaProducto(CInt(Me.txtFolioSalida.Text))
        Me.salida.SetRazon(Me.txtRazon.Text)
        Me.salida.SetFechaSalida(Me.dateFechaSalida.Value)
        Me.salida.SetIdUser(My.Settings.iduser)

        For Each salidaD As RegSalidaProD In salidaDetalle
            If (Not producto.BuscarProductoById(salidaD.GetIdProducto())) Then
                MsgBox("No se encontró el producto con el ID: " & salidaD.GetIdProducto(), MsgBoxStyle.Critical, "ERROR")
            End If

            producto.SetCantidadProducto(producto.GetCantidadProducto() + salidaD.GetCantidad())

            If (Not salidaD.EliminarSalidaProductoD()) Then
                MsgBox("Error al registrar salida", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            If (Not producto.ActualizarProducto()) Then
                MsgBox("Error al actualizar producto", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
        Next

        If (Not Me.salida.EliminarSalidaProducto()) Then
            MsgBox("Error al agregar salida", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        MsgBox("Salida eliminada", MsgBoxStyle.Information, "EXITO")
        Me.Close()
    End Sub
    Private Sub MostrarSalida()
        Dim detalleSalida As DataTable = New DataTable()
        detalleSalida.Columns.Add("ID")
        detalleSalida.Columns.Add("Producto")
        detalleSalida.Columns.Add("Cantidad")
        detalleSalida.Columns.Add("Unidad Medida")

        Dim unidadM As UnidadMedida = New UnidadMedida()

        For Each detalle As RegSalidaProD In salidaDetalle
            Dim dr As DataRow = detalleSalida.NewRow()
            dr("ID") = detalle.GetIdSalidaProductoDetalle()
            dr("Cantidad") = detalle.GetCantidad()
            producto.BuscarProductoById(detalle.GetIdProducto())
            dr("Producto") = producto.GetNombreProducto()
            unidadM.BuscarUnidadMById(producto.GetIdUnidadMedida())
            dr("Unidad Medida") = unidadM.GetNombreUnidadMedida()
            detalleSalida.Rows.Add(dr)

        Next
        Me.dgvRegistroSalida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.dgvRegistroSalida.DataSource = detalleSalida

        Me.dgvRegistroSalida.Columns("ID").Visible = False
    End Sub
    Private Sub BuscarSalida()
        Dim detalleSalida As DataTable

        Dim columnas As String() = {}
        Dim joins As String() = {}
        Dim condiciones As String() = {"id_salidaProd = '" & Me.txtFolioSalida.Text & "'"}

        detalleSalida = New RegSalidaProD().BuscarRegistroSalidaDByConditions(columnas, joins, condiciones)

        For Each rowSalida As DataRow In detalleSalida.Rows
            Dim sd As RegSalidaProD = New RegSalidaProD()
            sd.SetIdSalidaProductoDetalle(CInt(rowSalida("idsalidaDetalle").ToString()))
            sd.SetIdsalidaProd(CInt(rowSalida("id_salidaProd").ToString))
            sd.SetIdProducto(CInt(rowSalida("id_producto").ToString))
            sd.SetCantidad(CInt(rowSalida("cantidad").ToString))

            Dim sdO As RegSalidaProD = New RegSalidaProD()
            sdO.SetIdSalidaProductoDetalle(CInt(rowSalida("idsalidaDetalle").ToString()))
            sdO.SetIdsalidaProd(CInt(rowSalida("id_salidaProd").ToString))
            sdO.SetIdProducto(CInt(rowSalida("id_producto").ToString))
            sdO.SetCantidad(CInt(rowSalida("cantidad").ToString))

            salidaDetalle.Add(sd)
            salidaDetallePrevia.Add(sdO)
        Next
    End Sub
    Private Sub LimpiarCampos()
        Me.txtCantidad.Text = "0"
        Me.cbProducto.Text = ""

        Me.btnIngresar.Enabled = True
        Me.btnModificar.Enabled = False
        Me.btnQuitar.Enabled = False
    End Sub
    Private Sub Limpiar()
        Me.txtFolioSalida.Text = CStr(salida.BuscarUltimoId() + 1)
        Me.txtCantidad.Text = "0"
        Me.cbProducto.Text = ""
        Me.txtRazon.Text = ""
        Me.salidaDetalle = New List(Of RegSalidaProD)
        Me.dgvRegistroSalida.DataSource = Nothing

        Me.btnModificar.Enabled = False
        Me.btnQuitar.Enabled = False
        Me.btnEliminarSalida.Enabled = False
        Me.btnGuardarSalida.Enabled = True
        Me.btnEditarSalida.Enabled = False
    End Sub
End Class