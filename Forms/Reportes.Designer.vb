<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Me.TabInventario = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgInventario = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgMerma = New System.Windows.Forms.DataGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgSalidas = New System.Windows.Forms.DataGridView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.dgCompras = New System.Windows.Forms.DataGridView()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.rbSemanal = New System.Windows.Forms.RadioButton()
        Me.rbMensual = New System.Windows.Forms.RadioButton()
        Me.gpPeriodo = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtIncial = New System.Windows.Forms.DateTimePicker()
        Me.rbEspecifico = New System.Windows.Forms.RadioButton()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.TabInventario.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgMerma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgSalidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.dgCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpPeriodo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabInventario
        '
        Me.TabInventario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabInventario.Controls.Add(Me.TabPage1)
        Me.TabInventario.Controls.Add(Me.TabPage2)
        Me.TabInventario.Controls.Add(Me.TabPage3)
        Me.TabInventario.Controls.Add(Me.TabPage5)
        Me.TabInventario.Location = New System.Drawing.Point(12, 12)
        Me.TabInventario.Name = "TabInventario"
        Me.TabInventario.SelectedIndex = 0
        Me.TabInventario.Size = New System.Drawing.Size(633, 426)
        Me.TabInventario.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgInventario)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(625, 400)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inventario"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgInventario
        '
        Me.dgInventario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgInventario.Location = New System.Drawing.Point(3, 3)
        Me.dgInventario.Name = "dgInventario"
        Me.dgInventario.Size = New System.Drawing.Size(619, 394)
        Me.dgInventario.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgMerma)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(625, 400)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Merma"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgMerma
        '
        Me.dgMerma.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMerma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMerma.Location = New System.Drawing.Point(0, 0)
        Me.dgMerma.Name = "dgMerma"
        Me.dgMerma.Size = New System.Drawing.Size(629, 404)
        Me.dgMerma.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgSalidas)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(625, 400)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Salidas"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgSalidas
        '
        Me.dgSalidas.AllowUserToAddRows = False
        Me.dgSalidas.AllowUserToDeleteRows = False
        Me.dgSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSalidas.Location = New System.Drawing.Point(-4, 0)
        Me.dgSalidas.Name = "dgSalidas"
        Me.dgSalidas.ReadOnly = True
        Me.dgSalidas.RowHeadersVisible = False
        Me.dgSalidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSalidas.Size = New System.Drawing.Size(629, 404)
        Me.dgSalidas.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.dgCompras)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(625, 400)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Compras"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'dgCompras
        '
        Me.dgCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCompras.Location = New System.Drawing.Point(0, 0)
        Me.dgCompras.Name = "dgCompras"
        Me.dgCompras.Size = New System.Drawing.Size(629, 400)
        Me.dgCompras.TabIndex = 0
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnGenerar.Location = New System.Drawing.Point(668, 34)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(109, 32)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Generar reporte"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'rbSemanal
        '
        Me.rbSemanal.AutoSize = True
        Me.rbSemanal.Location = New System.Drawing.Point(11, 32)
        Me.rbSemanal.Name = "rbSemanal"
        Me.rbSemanal.Size = New System.Drawing.Size(66, 17)
        Me.rbSemanal.TabIndex = 2
        Me.rbSemanal.TabStop = True
        Me.rbSemanal.Text = "Semanal"
        Me.rbSemanal.UseVisualStyleBackColor = True
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(11, 55)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(65, 17)
        Me.rbMensual.TabIndex = 3
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'gpPeriodo
        '
        Me.gpPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.gpPeriodo.Controls.Add(Me.Label1)
        Me.gpPeriodo.Controls.Add(Me.dtFinal)
        Me.gpPeriodo.Controls.Add(Me.Label2)
        Me.gpPeriodo.Controls.Add(Me.dtIncial)
        Me.gpPeriodo.Controls.Add(Me.rbEspecifico)
        Me.gpPeriodo.Controls.Add(Me.rbSemanal)
        Me.gpPeriodo.Controls.Add(Me.rbMensual)
        Me.gpPeriodo.Location = New System.Drawing.Point(657, 129)
        Me.gpPeriodo.Name = "gpPeriodo"
        Me.gpPeriodo.Size = New System.Drawing.Size(131, 199)
        Me.gpPeriodo.TabIndex = 4
        Me.gpPeriodo.TabStop = False
        Me.gpPeriodo.Text = "Periodos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "a:"
        '
        'dtFinal
        '
        Me.dtFinal.Enabled = False
        Me.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFinal.Location = New System.Drawing.Point(11, 162)
        Me.dtFinal.Name = "dtFinal"
        Me.dtFinal.Size = New System.Drawing.Size(90, 20)
        Me.dtFinal.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "De:"
        '
        'dtIncial
        '
        Me.dtIncial.Enabled = False
        Me.dtIncial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtIncial.Location = New System.Drawing.Point(11, 123)
        Me.dtIncial.Name = "dtIncial"
        Me.dtIncial.Size = New System.Drawing.Size(90, 20)
        Me.dtIncial.TabIndex = 5
        '
        'rbEspecifico
        '
        Me.rbEspecifico.AutoSize = True
        Me.rbEspecifico.Location = New System.Drawing.Point(11, 78)
        Me.rbEspecifico.Name = "rbEspecifico"
        Me.rbEspecifico.Size = New System.Drawing.Size(74, 17)
        Me.rbEspecifico.TabIndex = 4
        Me.rbEspecifico.TabStop = True
        Me.rbEspecifico.Text = "Especifico"
        Me.rbEspecifico.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnModificar.Enabled = False
        Me.btnModificar.Location = New System.Drawing.Point(668, 72)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(109, 32)
        Me.btnModificar.TabIndex = 5
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.gpPeriodo)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.TabInventario)
        Me.Name = "Reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabInventario.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgMerma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgSalidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.dgCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpPeriodo.ResumeLayout(False)
        Me.gpPeriodo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabInventario As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgInventario As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgMerma As DataGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgSalidas As DataGridView
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents dgCompras As DataGridView
    Friend WithEvents btnGenerar As Button
    Friend WithEvents rbSemanal As RadioButton
    Friend WithEvents rbMensual As RadioButton
    Friend WithEvents gpPeriodo As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtFinal As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtIncial As DateTimePicker
    Friend WithEvents rbEspecifico As RadioButton
    Friend WithEvents btnModificar As Button
End Class
