Public Class Reportes
    Private selected_report As String

    Private Sub Reportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rbSemanal.Checked = True
        generarReporteSalidas()
        generarReporteMerma()
        generarReporteCompras()
        generarReporteInventario()
    End Sub

    Private Sub Reportes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim form As Form = New Menu()
        form.Show()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim form As Form
        Select Case Me.selected_report
            Case "Merma"
                form = New RegistroMerma(CInt(Me.dgMerma.CurrentRow.Cells("idregMerma").Value))
                form.Show()
            Case "Salidas"
                form = New RegSalidaP(CInt(Me.dgSalidas.CurrentRow.Cells("idsalidaProducto").Value))
                form.Show()
            Case "Compras"
                form = New Compras(CInt(Me.dgCompras.CurrentRow.Cells("idcompras").Value))
                form.Show()
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
            condiciones = {"fecha_salida BETWEEN " & fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy-MM-dd") &
                            " AND " & fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy-MM-dd")}
        ElseIf rbMensual.Checked Then
            Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
            condiciones = {"fecha_salida BETWEEN " & fecha.AddDays(fecha.Day * -1).ToString("yyyy-MM-dd") &
                            " AND " & fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy-MM-dd")}
        ElseIf rbEspecifico.Checked Then
            condiciones = {"fecha_salida BETWEEN " & dtIncial.Value.ToString("yyyy-MM-dd") &
                            " AND " & dtFinal.Value.ToString("yyyy-MM-dd")}
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
            condiciones = {" fechaReg BETWEEN " & fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy-MM-dd") &
                            " AND " & fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy-MM-dd")}
        ElseIf rbMensual.Checked Then
            Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
            condiciones = {"fechaReg BETWEEN " & fecha.AddDays(fecha.Day * -1).ToString("yyyy-MM-dd") &
                            " AND " & fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy-MM-dd")}
        ElseIf rbEspecifico.Checked Then
            condiciones = {"fechaReg BETWEEN " & dtIncial.Value.ToString("yyyy-MM-dd") &
                            " AND " & dtFinal.Value.ToString("yyyy-MM-dd")}
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
            condiciones = {" fecha_compra BETWEEN " & fecha.AddDays(fecha.DayOfWeek * -1).ToString("yyyy-MM-dd") &
                            " AND " & fecha.AddDays(6 - fecha.DayOfWeek).ToString("yyyy-MM-dd")}
            MsgBox(condiciones(0))
        ElseIf rbMensual.Checked Then
            Dim daysMonth As Integer = DateTime.DaysInMonth(fecha.Year, fecha.Month)
            condiciones = {"fecha_compra BETWEEN " & fecha.AddDays(fecha.Day * -1).ToString("yyyy-MM-dd") &
                            " AND " & fecha.AddDays(daysMonth - fecha.Day).ToString("yyyy-MM-dd")}
        ElseIf rbEspecifico.Checked Then
            condiciones = {"fecha_compra BETWEEN " & dtIncial.Value.ToString("yyyy-MM-dd") &
                            " AND " & dtFinal.Value.ToString("yyyy-MM-dd")}
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

    Private Sub rb_Semanal_CheckedChanged(sender As Object, e As EventArgs) Handles rbEspecifico.CheckedChanged
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

    Private Sub rb_Especifico_CheckedChanged(sender As Object, e As EventArgs) Handles rbSemanal.CheckedChanged
        If Me.rbEspecifico.Checked Then
            generarReporteSalidas()
            generarReporteMerma()
            generarReporteCompras()
            generarReporteInventario()

            Me.dtIncial.Enabled = True
            Me.dtFinal.Enabled = True
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
    End Sub

    Private Sub dgMerma_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgMerma.CellClick
        Me.selected_report = "Merma"
        Me.btnModificar.Enabled = True
    End Sub

    Private Sub dgSalidas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSalidas.CellClick
        Me.selected_report = "Salidas"
        Me.btnModificar.Enabled = True
    End Sub

    Private Sub dgCompras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgCompras.CellClick
        Me.selected_report = "Compras"
        Me.btnModificar.Enabled = True
    End Sub
End Class