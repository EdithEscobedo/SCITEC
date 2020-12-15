<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.productos = New System.Windows.Forms.Label()
        Me.reportes = New System.Windows.Forms.Label()
        Me.compras = New System.Windows.Forms.Label()
        Me.proveedores = New System.Windows.Forms.Label()
        Me.usuarios = New System.Windows.Forms.Label()
        Me.btnUsuarios = New System.Windows.Forms.Button()
        Me.btnCompras = New System.Windows.Forms.Button()
        Me.btnProveedores = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.Registros = New System.Windows.Forms.Label()
        Me.btnRegistroSalida = New System.Windows.Forms.Button()
        Me.merma = New System.Windows.Forms.Label()
        Me.btnMerma = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'productos
        '
        Me.productos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.productos.Location = New System.Drawing.Point(62, 199)
        Me.productos.Name = "productos"
        Me.productos.Size = New System.Drawing.Size(120, 20)
        Me.productos.TabIndex = 500
        Me.productos.Text = "Productos"
        Me.productos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'reportes
        '
        Me.reportes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.reportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.reportes.Location = New System.Drawing.Point(161, 423)
        Me.reportes.Name = "reportes"
        Me.reportes.Size = New System.Drawing.Size(120, 20)
        Me.reportes.TabIndex = 501
        Me.reportes.Text = "Reportes"
        Me.reportes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'compras
        '
        Me.compras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.compras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.compras.Location = New System.Drawing.Point(560, 199)
        Me.compras.Name = "compras"
        Me.compras.Size = New System.Drawing.Size(120, 20)
        Me.compras.TabIndex = 502
        Me.compras.Text = "Compras"
        Me.compras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'proveedores
        '
        Me.proveedores.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.proveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.proveedores.Location = New System.Drawing.Point(417, 423)
        Me.proveedores.Name = "proveedores"
        Me.proveedores.Size = New System.Drawing.Size(120, 20)
        Me.proveedores.TabIndex = 503
        Me.proveedores.Text = "Proveedores"
        Me.proveedores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'usuarios
        '
        Me.usuarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.usuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usuarios.Location = New System.Drawing.Point(691, 423)
        Me.usuarios.Name = "usuarios"
        Me.usuarios.Size = New System.Drawing.Size(120, 20)
        Me.usuarios.TabIndex = 504
        Me.usuarios.Text = "Usuarios"
        Me.usuarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnUsuarios
        '
        Me.btnUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUsuarios.Image = CType(resources.GetObject("btnUsuarios.Image"), System.Drawing.Image)
        Me.btnUsuarios.Location = New System.Drawing.Point(691, 290)
        Me.btnUsuarios.Name = "btnUsuarios"
        Me.btnUsuarios.Size = New System.Drawing.Size(120, 120)
        Me.btnUsuarios.TabIndex = 4
        Me.btnUsuarios.UseVisualStyleBackColor = True
        '
        'btnCompras
        '
        Me.btnCompras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCompras.Image = Global.SCITEC.My.Resources.Resources.Compras
        Me.btnCompras.Location = New System.Drawing.Point(560, 65)
        Me.btnCompras.Name = "btnCompras"
        Me.btnCompras.Size = New System.Drawing.Size(120, 120)
        Me.btnCompras.TabIndex = 2
        Me.btnCompras.UseVisualStyleBackColor = True
        '
        'btnProveedores
        '
        Me.btnProveedores.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnProveedores.BackColor = System.Drawing.SystemColors.Control
        Me.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProveedores.Image = Global.SCITEC.My.Resources.Resources.Proveedores
        Me.btnProveedores.Location = New System.Drawing.Point(417, 290)
        Me.btnProveedores.Name = "btnProveedores"
        Me.btnProveedores.Size = New System.Drawing.Size(120, 120)
        Me.btnProveedores.TabIndex = 3
        Me.btnProveedores.UseVisualStyleBackColor = False
        '
        'btnReportes
        '
        Me.btnReportes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReportes.Image = Global.SCITEC.My.Resources.Resources.Reportes
        Me.btnReportes.Location = New System.Drawing.Point(161, 290)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(120, 120)
        Me.btnReportes.TabIndex = 1
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnProductos.BackgroundImage = Global.SCITEC.My.Resources.Resources.Producto
        Me.btnProductos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnProductos.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnProductos.FlatAppearance.BorderSize = 5
        Me.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProductos.Location = New System.Drawing.Point(62, 65)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(120, 120)
        Me.btnProductos.TabIndex = 0
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'Registros
        '
        Me.Registros.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Registros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Registros.Location = New System.Drawing.Point(299, 199)
        Me.Registros.Name = "Registros"
        Me.Registros.Size = New System.Drawing.Size(120, 20)
        Me.Registros.TabIndex = 506
        Me.Registros.Text = "Salidas"
        Me.Registros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRegistroSalida
        '
        Me.btnRegistroSalida.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnRegistroSalida.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRegistroSalida.Image = Global.SCITEC.My.Resources.Resources.Compras
        Me.btnRegistroSalida.Location = New System.Drawing.Point(299, 65)
        Me.btnRegistroSalida.Name = "btnRegistroSalida"
        Me.btnRegistroSalida.Size = New System.Drawing.Size(120, 120)
        Me.btnRegistroSalida.TabIndex = 505
        Me.btnRegistroSalida.UseVisualStyleBackColor = True
        '
        'merma
        '
        Me.merma.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.merma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.merma.Location = New System.Drawing.Point(805, 200)
        Me.merma.Name = "merma"
        Me.merma.Size = New System.Drawing.Size(120, 20)
        Me.merma.TabIndex = 508
        Me.merma.Text = "Merma"
        Me.merma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMerma
        '
        Me.btnMerma.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMerma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMerma.Image = Global.SCITEC.My.Resources.Resources.Reportes
        Me.btnMerma.Location = New System.Drawing.Point(805, 65)
        Me.btnMerma.Name = "btnMerma"
        Me.btnMerma.Size = New System.Drawing.Size(120, 120)
        Me.btnMerma.TabIndex = 507
        Me.btnMerma.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 507)
        Me.Controls.Add(Me.merma)
        Me.Controls.Add(Me.btnMerma)
        Me.Controls.Add(Me.Registros)
        Me.Controls.Add(Me.btnRegistroSalida)
        Me.Controls.Add(Me.proveedores)
        Me.Controls.Add(Me.usuarios)
        Me.Controls.Add(Me.compras)
        Me.Controls.Add(Me.reportes)
        Me.Controls.Add(Me.productos)
        Me.Controls.Add(Me.btnUsuarios)
        Me.Controls.Add(Me.btnCompras)
        Me.Controls.Add(Me.btnProveedores)
        Me.Controls.Add(Me.btnReportes)
        Me.Controls.Add(Me.btnProductos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnProductos As Button
    Friend WithEvents btnReportes As Button
    Friend WithEvents btnCompras As Button
    Friend WithEvents btnProveedores As Button
    Friend WithEvents btnUsuarios As Button
    Friend WithEvents productos As Label
    Friend WithEvents reportes As Label
    Friend WithEvents compras As Label
    Friend WithEvents proveedores As Label
    Friend WithEvents usuarios As Label
    Friend WithEvents Registros As Label
    Friend WithEvents btnRegistroSalida As Button
    Friend WithEvents merma As Label
    Friend WithEvents btnMerma As Button
End Class
