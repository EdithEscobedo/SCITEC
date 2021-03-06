﻿Imports System.ComponentModel
Imports System.Data
Imports Syncfusion.Pdf
Imports Syncfusion.Pdf.Grid
Imports Syncfusion.Pdf.Graphics
Imports System.Drawing
Imports System
Imports System.IO

Public Class Reportes
    Private selected_report As String
    Private selected_modify As Boolean = False

    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rbSemanal.Checked = True
        Me.dtIncial.Enabled = False
        Me.dtFinal.Enabled = False
        generarReporteSalidas()
        generarReporteMerma()
        generarReporteCompras()
        generarReporteInventario()
    End Sub

    Private Sub Reportes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.selected_modify Then
            Dim form As Form = New Menu()
            form.Show()
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim doc As PdfDocument = New PdfDocument()

        Dim gridStyle As PdfGridStyle = New PdfGridStyle()
        'gridStyle.Font = New PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Regular)
        gridStyle.CellPadding = New PdfPaddings(5, 5, 5, 5)

        'Titulo
        Dim pageTitulo As PdfPage = doc.Pages.Add()
        Dim graphicsTitulo As PdfGraphics = pageTitulo.Graphics
        Dim titulo As String
        Dim fechaReporte As String
        Dim fecha As DateTime = DateTime.Today
        Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)

        If rbSemanal.Checked Then

            titulo = "Reporte Semanal"
            fechaReporte = fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy/MM/dd") & "  -  " &
                           fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy/MM/dd")

        ElseIf rbMensual.Checked Then

            titulo = "Reporte Mensual"
            fechaReporte = fecha.AddDays(fecha.Day * -1).ToString("yyyy/MM/dd") & "  -  " &
                           fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy/MM/dd")

        ElseIf rbEspecifico.Checked Then

            titulo = "Reporte Específico"
            fechaReporte = dtIncial.Value.ToString("yyyy/MM/dd") & "  -  " &
                           dtFinal.Value.ToString("yyyy/MM/dd")
        Else
            titulo = "Reporte"
            fechaReporte = fecha.ToString("yyyy-MM-dd")
        End If

        graphicsTitulo.DrawString(titulo, New PdfStandardFont(PdfFontFamily.TimesRoman, 50, PdfFontStyle.Bold), PdfBrushes.DarkRed, 70, 250)
        graphicsTitulo.DrawString(fechaReporte, New PdfStandardFont(PdfFontFamily.TimesRoman, 22, PdfFontStyle.Bold), PdfBrushes.DarkOrange, 150, 350)

        ' Inventario
        Dim pageInventario As PdfPage = doc.Pages.Add()
        Dim tInventario As DataTable = dgInventario.DataSource
        Dim graphicsInventario As PdfGraphics = pageInventario.Graphics

        graphicsInventario.DrawString("Inventario", New PdfStandardFont(PdfFontFamily.TimesRoman, 20, PdfFontStyle.Bold), PdfBrushes.Black, 10, 10)

        tInventario.Columns("nombreProducto").SetOrdinal(0)
        tInventario.Columns("nombreProducto").ColumnName = "Producto"
        tInventario.Columns("nom_catP").SetOrdinal(1)
        tInventario.Columns("nom_catP").ColumnName = "Categoria"
        tInventario.Columns("cantidadProducto").SetOrdinal(2)
        tInventario.Columns("cantidadProducto").ColumnName = "Cantidad"
        tInventario.Columns("nom_unidadM").SetOrdinal(3)
        tInventario.Columns("nom_unidadM").ColumnName = "Unidad Medida"
        tInventario.Columns("estadoproducto").SetOrdinal(4)
        tInventario.Columns("estadoproducto").ColumnName = "Estado"

        tInventario.Columns.Remove("id_catP")
        tInventario.Columns.Remove("id_unidM")
        tInventario.Columns.Remove("idProductos")

        Dim gridInvetario As PdfGrid = New PdfGrid()

        gridInvetario.Style = gridStyle
        gridInvetario.DataSource = tInventario

        For Each cell As PdfGridCell In gridInvetario.Headers(0).Cells
            cell.Style.BackgroundBrush = New PdfSolidBrush(New PdfColor(128, 0, 64))
            cell.Style.TextPen = New PdfPen(New PdfColor(255, 255, 255))
            cell.Style.StringFormat = New PdfStringFormat()
            cell.Style.StringFormat.Alignment = PdfTextAlignment.Center
            cell.Style.Font = New PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Regular)
        Next

        gridInvetario.Draw(pageInventario, 10, 50)

        'Mermas
        Dim pageMermas As PdfPage = doc.Pages.Add()
        Dim tMermas As DataTable = dgMerma.DataSource
        Dim graphicsMermas As PdfGraphics = pageMermas.Graphics

        graphicsMermas.DrawString("Mermas", New PdfStandardFont(PdfFontFamily.TimesRoman, 20, PdfFontStyle.Bold), PdfBrushes.Black, 10, 10)

        tMermas.Columns("nombreproducto").SetOrdinal(0)
        tMermas.Columns("nombreproducto").ColumnName = "Producto"
        tMermas.Columns("cantidadMerma").SetOrdinal(1)
        tMermas.Columns("cantidadMerma").ColumnName = "Cantidad"
        tMermas.Columns("nom_unidadM").SetOrdinal(2)
        tMermas.Columns("nom_unidadM").ColumnName = "Unidad"
        tMermas.Columns("descripcion").SetOrdinal(3)
        tMermas.Columns("descripcion").ColumnName = "Descripción"
        tMermas.Columns("fechaReg").SetOrdinal(4)
        tMermas.Columns("fechaReg").ColumnName = "Fecha"
        tMermas.Columns("nom_usuario").SetOrdinal(5)
        tMermas.Columns("nom_usuario").ColumnName = "Usuario"

        tMermas.Columns.Remove("idregMerma")
        tMermas.Columns.Remove("iduseer")
        'tMermas.Columns.Remove("id_producti")

        Dim gridMermas As PdfGrid = New PdfGrid()

        gridMermas.Style = gridStyle
        gridMermas.DataSource = tMermas

        For Each cell As PdfGridCell In gridMermas.Headers(0).Cells
            cell.Style.BackgroundBrush = New PdfSolidBrush(New PdfColor(128, 0, 64))
            cell.Style.TextPen = New PdfPen(New PdfColor(255, 255, 255))
            cell.Style.StringFormat = New PdfStringFormat()
            cell.Style.StringFormat.Alignment = PdfTextAlignment.Center
            cell.Style.Font = New PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Regular)
        Next

        gridMermas.Draw(pageMermas, 10, 50)

        ' Salidas
        Dim pageSalidas As PdfPage = doc.Pages.Add()
        Dim tSalidas As DataTable = dgSalidas.DataSource
        Dim graphicsSalidas As PdfGraphics = pageSalidas.Graphics

        graphicsSalidas.DrawString("Salidas", New PdfStandardFont(PdfFontFamily.TimesRoman, 20, PdfFontStyle.Bold), PdfBrushes.Black, 10, 10)

        tSalidas.Columns("nombreproducto").SetOrdinal(0)
        tSalidas.Columns("nombreproducto").ColumnName = "Producto"
        tSalidas.Columns("cantidad").SetOrdinal(1)
        tSalidas.Columns("cantidad").ColumnName = "Cantidad"
        tSalidas.Columns("nom_unidadM").SetOrdinal(2)
        tSalidas.Columns("nom_unidadM").ColumnName = "Unidad"
        tSalidas.Columns("razon").SetOrdinal(3)
        tSalidas.Columns("razon").ColumnName = "Razón"
        tSalidas.Columns("fecha_salida").SetOrdinal(4)
        tSalidas.Columns("fecha_salida").ColumnName = "Fecha"
        tSalidas.Columns("nom_usuario").SetOrdinal(5)
        tSalidas.Columns("nom_usuario").ColumnName = "Usuario"

        tSalidas.Columns.Remove("idsalidaProducto")
        tSalidas.Columns.Remove("id_user")
        'tSalidas.Columns.Remove("id_producto")

        Dim gridSalidas As PdfGrid = New PdfGrid()

        gridSalidas.Style = gridStyle
        gridSalidas.DataSource = tSalidas

        For Each cell As PdfGridCell In gridSalidas.Headers(0).Cells
            cell.Style.BackgroundBrush = New PdfSolidBrush(New PdfColor(128, 0, 64))
            cell.Style.TextPen = New PdfPen(New PdfColor(255, 255, 255))
            cell.Style.StringFormat = New PdfStringFormat()
            cell.Style.StringFormat.Alignment = PdfTextAlignment.Center
            cell.Style.Font = New PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Regular)
        Next

        gridSalidas.Draw(pageSalidas, 10, 50)

        ' Compras
        Dim pageCompras As PdfPage = doc.Pages.Add()
        Dim tCompras As DataTable = dgCompras.DataSource
        Dim graphicsCompras As PdfGraphics = pageCompras.Graphics

        graphicsCompras.DrawString("Compras", New PdfStandardFont(PdfFontFamily.TimesRoman, 20, PdfFontStyle.Bold), PdfBrushes.Black, 10, 10)

        tCompras.Columns("nombreproducto").SetOrdinal(0)
        tCompras.Columns("nombreproducto").ColumnName = "Producto"
        tCompras.Columns("cantCompra").SetOrdinal(1)
        tCompras.Columns("cantCompra").ColumnName = "Cantidad"
        tCompras.Columns("nom_unidadM").SetOrdinal(2)
        tCompras.Columns("nom_unidadM").ColumnName = "Unidad"
        tCompras.Columns("fecha_compra").SetOrdinal(3)
        tCompras.Columns("fecha_compra").ColumnName = "Fecha"
        tCompras.Columns("nom_usuario").SetOrdinal(4)
        tCompras.Columns("nom_usuario").ColumnName = "Usuario"

        tCompras.Columns.Remove("idcompras")
        tCompras.Columns.Remove("id_user")
        tCompras.Columns.Remove("id_pro")

        Dim gridCompras As PdfGrid = New PdfGrid()

        gridCompras.Style = gridStyle
        gridCompras.DataSource = tCompras


        For Each cell As PdfGridCell In gridCompras.Headers(0).Cells
            cell.Style.BackgroundBrush = New PdfSolidBrush(New PdfColor(128, 0, 64))
            cell.Style.TextPen = New PdfPen(New PdfColor(255, 255, 255))
            cell.Style.StringFormat = New PdfStringFormat()
            cell.Style.StringFormat.Alignment = PdfTextAlignment.Center
            cell.Style.Font = New PdfStandardFont(PdfFontFamily.TimesRoman, 12, PdfFontStyle.Regular)
        Next

        gridCompras.Draw(pageCompras, 10, 50)

        ' Dialog
        Dim dialog As SaveFileDialog = New SaveFileDialog()

        dialog.Filter = "Pdf Files|*.pdf"
        dialog.Title = "Generar Reporte"
        dialog.FileName = "SCITEC-" & DateTime.Now.ToString("dd-MM-yyyy") & ".pdf"
        dialog.AddExtension = True

        Dim archivo As FileStream

        If dialog.ShowDialog() = DialogResult.OK Then
            If File.Exists(dialog.FileName) Then
                File.Delete(dialog.FileName)
            End If
            archivo = New FileStream(dialog.FileName, FileMode.CreateNew, FileAccess.ReadWrite)
            doc.Save(archivo)
            doc.Close(True)
            archivo.Close()
            MsgBox("Reporte generado exitosamente", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim form As Form
        Me.selected_modify = True
        Select Case Me.selected_report
            Case "Merma"
                form = New RegistroMerma(CInt(Me.dgMerma.CurrentRow.Cells("idregMerma").Value))
                form.Show()
                Me.Close()
            Case "Salidas"
                form = New RegSalidaP(CInt(Me.dgSalidas.CurrentRow.Cells("idsalidaProducto").Value))
                form.Show()
                Me.Close()
            Case "Compras"
                form = New Compras(CInt(Me.dgCompras.CurrentRow.Cells("idcompras").Value))
                form.Show()
                Me.Close()
        End Select
    End Sub

    Private Sub generarReporteSalidas()
        Dim salidas As RegSalidaPro = New RegSalidaPro()
        Dim fecha As DateTime = DateTime.Today

        Dim columnas As String() = {"nombreproducto", "cantidad", "nom_usuario", "nom_unidadM"}
        Dim joins As String() = {"INNER JOIN usuario On salidaproducto.id_user = usuario.idusuario",
                                 "INNER JOIN salidadetalle On salidadetalle.id_salidaProd = salidaproducto.idsalidaProducto",
                                 "INNER JOIN productos On productos.idProductos = salidadetalle.id_producto",
                                 "INNER JOIN unidad_medida On unidad_medida.idunidadM = productos.id_unidM"}
        Dim condiciones As String() = {}

        If rbSemanal.Checked Then
            condiciones = {"fecha_salida BETWEEN '" & fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy-MM-dd") &
                            "' AND '" & fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy-MM-dd") & "'"}
        ElseIf rbMensual.Checked Then
            Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
            condiciones = {"fecha_salida BETWEEN '" & fecha.AddDays(fecha.Day * -1).ToString("yyyy-MM-dd") &
                            "' AND '" & fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy-MM-dd") & "'"}
        ElseIf rbEspecifico.Checked Then
            condiciones = {"fecha_salida BETWEEN '" & dtIncial.Value.ToString("yyyy-MM-dd") &
                            "' AND '" & dtFinal.Value.ToString("yyyy-MM-dd") & "'"}
        End If

        Me.dgSalidas.DataSource = salidas.BuscarSalidaProductoByConditions(columnas, joins, condiciones)
        Me.dgSalidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.dgSalidas.Columns("nombreproducto").DisplayIndex = 0
        Me.dgSalidas.Columns("nombreproducto").HeaderText = "Producto"
        Me.dgSalidas.Columns("cantidad").DisplayIndex = 1
        Me.dgSalidas.Columns("cantidad").HeaderText = "Cantidad"
        Me.dgSalidas.Columns("nom_unidadM").DisplayIndex = 2
        Me.dgSalidas.Columns("nom_unidadM").HeaderText = "Unidad"
        Me.dgSalidas.Columns("razon").DisplayIndex = 3
        Me.dgSalidas.Columns("razon").HeaderText = "Razon"
        Me.dgSalidas.Columns("fecha_salida").DisplayIndex = 4
        Me.dgSalidas.Columns("fecha_salida").HeaderText = "Fecha"
        Me.dgSalidas.Columns("nom_usuario").DisplayIndex = 5
        Me.dgSalidas.Columns("nom_usuario").HeaderText = "Usuario"

        Me.dgSalidas.Columns("id_user").Visible = False
        Me.dgSalidas.Columns("idsalidaProducto").Visible = False
    End Sub
    Private Sub generarReporteMerma()
        Dim merma As RegMerma = New RegMerma()
        Dim fecha As DateTime = DateTime.Today

        Dim columnas As String() = {"nombreproducto", "cantidadMerma", "nom_usuario", "nom_unidadM"}
        Dim joins As String() = {"INNER JOIN usuario On regmerma.iduseer = usuario.idusuario",
                                 "INNER JOIN mermadetalle On mermadetalle.idreg_m = regmerma.idregMerma",
                                 "INNER JOIN productos On productos.idProductos = mermadetalle.id_producti",
                                 "INNER JOIN unidad_medida On unidad_medida.idunidadM = productos.id_unidM"}
        Dim condiciones As String() = {}

        If rbSemanal.Checked Then
            condiciones = {" fechaReg BETWEEN '" & fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy-MM-dd") &
                            "' AND '" & fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy-MM-dd") & "'"}
        ElseIf rbMensual.Checked Then
            Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
            condiciones = {"fechaReg BETWEEN '" & fecha.AddDays(fecha.Day * -1).ToString("yyyy-MM-dd") &
                            "' AND '" & fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy-MM-dd") & "'"}
        ElseIf rbEspecifico.Checked Then
            condiciones = {"fechaReg BETWEEN '" & dtIncial.Value.ToString("yyyy-MM-dd") &
                            "' AND '" & dtFinal.Value.ToString("yyyy-MM-dd") & "'"}
        End If

        Me.dgMerma.DataSource = merma.BuscarRegistroMermaByConditions(columnas, joins, condiciones)
        Me.dgMerma.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.dgMerma.Columns("nombreproducto").DisplayIndex = 0
        Me.dgMerma.Columns("nombreproducto").HeaderText = "Producto"
        Me.dgMerma.Columns("cantidadMerma").DisplayIndex = 1
        Me.dgMerma.Columns("cantidadMerma").HeaderText = "Cantidad"
        Me.dgMerma.Columns("nom_unidadM").DisplayIndex = 2
        Me.dgMerma.Columns("nom_unidadM").HeaderText = "Unidad"
        Me.dgMerma.Columns("descripcion").DisplayIndex = 3
        Me.dgMerma.Columns("descripcion").HeaderText = "Descripcion"
        Me.dgMerma.Columns("fechaReg").DisplayIndex = 4
        Me.dgMerma.Columns("fechaReg").HeaderText = "Fecha"
        Me.dgMerma.Columns("nom_usuario").DisplayIndex = 5
        Me.dgMerma.Columns("nom_usuario").HeaderText = "Usuario"

        Me.dgMerma.Columns("iduseer").Visible = False
        Me.dgMerma.Columns("idregMerma").Visible = False
    End Sub

    Private Sub generarReporteInventario()
        Dim producto As Producto = New Producto
        Dim columnas As String() = {"cat_producto.nom_catP, unidad_medida.nom_unidadM"}
        Dim joins As String() = {"INNER JOIN cat_producto ON productos.id_catP = cat_producto.idcat_producto",
                                 "INNER JOIN unidad_medida ON productos.id_unidM = unidad_medida.idunidadM"}
        Dim condiciones As String() = {}

        Me.dgInventario.DataSource = producto.BuscarProductosByConditions(columnas, joins, condiciones)
        Me.dgInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'Mostrar columnas en el DataGridView de manera ordenada
        Me.dgInventario.Columns("nombreProducto").DisplayIndex = 0
        Me.dgInventario.Columns("nombreProducto").HeaderText = "Producto"
        Me.dgInventario.Columns("nom_catP").DisplayIndex = 1
        Me.dgInventario.Columns("nom_catP").HeaderText = "Categoria"
        Me.dgInventario.Columns("cantidadProducto").DisplayIndex = 2
        Me.dgInventario.Columns("cantidadProducto").HeaderText = "Cantidad"
        Me.dgInventario.Columns("nom_unidadM").DisplayIndex = 3
        Me.dgInventario.Columns("nom_unidadM").HeaderText = "Unidad Medida"
        Me.dgInventario.Columns("estadoproducto").DisplayIndex = 4
        Me.dgInventario.Columns("estadoproducto").HeaderText = "Estado"

        Me.dgInventario.Columns("id_catP").Visible = False
        Me.dgInventario.Columns("id_unidM").Visible = False
        Me.dgInventario.Columns("idProductos").Visible = False

        Me.dgInventario.Sort(Me.dgInventario.Columns("nombreProducto"), ListSortDirection.Ascending)
    End Sub

    Private Sub generarReporteCompras()
        Dim compra As Compra = New Compra()
        Dim fecha As DateTime = DateTime.Today

        Dim columnas As String() = {"nombreproducto", "cantCompra", "nom_usuario", "nom_unidadM"}
        Dim joins As String() = {"INNER JOIN usuario On compras.id_user = usuario.idusuario",
                                 "INNER JOIN compradetalle On compradetalle.id_compraa = compras.idcompras",
                                 "INNER JOIN productos On productos.idProductos = compradetalle.id_productooo",
                                 "INNER JOIN unidad_medida On unidad_medida.idunidadM = productos.id_unidM"}
        Dim condiciones As String() = {}

        If rbSemanal.Checked Then
            condiciones = {" fecha_compra BETWEEN '" & fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy-MM-dd") &
                            "' AND '" & fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy-MM-dd") & "'"}
        ElseIf rbMensual.Checked Then
            Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
            condiciones = {"fecha_compra BETWEEN '" & fecha.AddDays(fecha.Day * -1).ToString("yyyy-MM-dd") &
                            "' AND '" & fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy-MM-dd") & "'"}
        ElseIf rbEspecifico.Checked Then
            condiciones = {"fecha_compra BETWEEN '" & dtIncial.Value.ToString("yyyy-MM-dd") &
                            "' AND '" & dtFinal.Value.ToString("yyyy-MM-dd") & "'"}
        End If

        Me.dgCompras.DataSource = compra.BuscarCompraByConditions(columnas, joins, condiciones)
        Me.dgCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Me.dgCompras.Columns("nombreproducto").DisplayIndex = 0
        Me.dgCompras.Columns("nombreproducto").HeaderText = "Producto"
        Me.dgCompras.Columns("cantCompra").DisplayIndex = 1
        Me.dgCompras.Columns("cantCompra").HeaderText = "Cantidad"
        Me.dgCompras.Columns("nom_unidadM").DisplayIndex = 2
        Me.dgCompras.Columns("nom_unidadM").HeaderText = "Unidad"
        Me.dgCompras.Columns("fecha_compra").DisplayIndex = 3
        Me.dgCompras.Columns("fecha_compra").HeaderText = "Fecha"
        Me.dgCompras.Columns("nom_usuario").DisplayIndex = 4
        Me.dgCompras.Columns("nom_usuario").HeaderText = "Usuario"

        Me.dgCompras.Columns("idcompras").Visible = False
        Me.dgCompras.Columns("id_user").Visible = False
        Me.dgCompras.Columns("id_pro").Visible = False
    End Sub

    Private Sub rbSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles rbSemanal.CheckedChanged
        If Me.rbSemanal.Checked Then
            generarReporteSalidas()
            generarReporteMerma()
            generarReporteCompras()
            generarReporteInventario()
        End If
    End Sub

    Private Sub rb_Mensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbMensual.CheckedChanged
        If Me.rbMensual.Checked Then
            generarReporteSalidas()
            generarReporteMerma()
            generarReporteCompras()
            generarReporteInventario()
        End If
    End Sub
    Private Sub rbEspecifico_CheckedChanged(sender As Object, e As EventArgs) Handles rbEspecifico.CheckedChanged
        If Me.rbEspecifico.Checked Then
            generarReporteSalidas()
            generarReporteMerma()
            generarReporteCompras()
            generarReporteInventario()

            dtIncial.Enabled = True
            dtFinal.Enabled = True
        Else
            dtIncial.Enabled = False
            dtFinal.Enabled = False
        End If
    End Sub

    Private Sub dtIncial_ValueChanged(sender As Object, e As EventArgs) Handles dtIncial.ValueChanged
        generarReporteSalidas()
        generarReporteMerma()
        generarReporteCompras()
        generarReporteInventario()
    End Sub

    Private Sub dtFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtFinal.ValueChanged
        generarReporteSalidas()
        generarReporteMerma()
        generarReporteCompras()
        generarReporteInventario()
    End Sub

    Private Sub dgInventario_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgInventario.CellClick
        Me.btnModificar.Enabled = False
        Me.btnModificar.Text = "Modificar"
    End Sub

    Private Sub dgMerma_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMerma.CellClick
        Me.selected_report = "Merma"
        Me.btnModificar.Text = "Modificar Registro Merma"
        Me.btnModificar.Enabled = True
    End Sub

    Private Sub dgSalidas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSalidas.CellClick
        Me.selected_report = "Salidas"
        Me.btnModificar.Text = "Modificar Registro Salidas"
        Me.btnModificar.Enabled = True
    End Sub

    Private Sub dgCompras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCompras.CellClick
        Me.selected_report = "Compras"
        Me.btnModificar.Text = "Modificar Registro Compras"
        Me.btnModificar.Enabled = True
    End Sub
End Class