<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegSalidaP
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvRegistroSalida = New System.Windows.Forms.DataGridView()
        Me.cbProducto = New System.Windows.Forms.ComboBox()
        Me.dateFechaSalida = New System.Windows.Forms.DateTimePicker()
        Me.txtNumeroUsuario = New System.Windows.Forms.TextBox()
        Me.txtFolioSalida = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtNombreUsuario = New System.Windows.Forms.TextBox()
        Me.btnGuardarSalida = New System.Windows.Forms.Button()
        Me.btnEditarSalida = New System.Windows.Forms.Button()
        Me.btnEliminarSalida = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.txtRazon = New System.Windows.Forms.TextBox()
        CType(Me.dgvRegistroSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(85, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio de salida:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero de usuario:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(112, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Razon:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(100, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Producto:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha de salida:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(348, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Nombre de usuario:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(395, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cantidad:"
        '
        'dgvRegistroSalida
        '
        Me.dgvRegistroSalida.AllowUserToAddRows = False
        Me.dgvRegistroSalida.AllowUserToDeleteRows = False
        Me.dgvRegistroSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegistroSalida.Location = New System.Drawing.Point(27, 219)
        Me.dgvRegistroSalida.Name = "dgvRegistroSalida"
        Me.dgvRegistroSalida.RowHeadersVisible = False
        Me.dgvRegistroSalida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRegistroSalida.Size = New System.Drawing.Size(622, 219)
        Me.dgvRegistroSalida.TabIndex = 7
        '
        'cbProducto
        '
        Me.cbProducto.FormattingEnabled = True
        Me.cbProducto.Location = New System.Drawing.Point(168, 134)
        Me.cbProducto.Name = "cbProducto"
        Me.cbProducto.Size = New System.Drawing.Size(143, 21)
        Me.cbProducto.TabIndex = 8
        '
        'dateFechaSalida
        '
        Me.dateFechaSalida.Location = New System.Drawing.Point(467, 14)
        Me.dateFechaSalida.Name = "dateFechaSalida"
        Me.dateFechaSalida.Size = New System.Drawing.Size(200, 20)
        Me.dateFechaSalida.TabIndex = 9
        '
        'txtNumeroUsuario
        '
        Me.txtNumeroUsuario.Enabled = False
        Me.txtNumeroUsuario.Location = New System.Drawing.Point(168, 60)
        Me.txtNumeroUsuario.Name = "txtNumeroUsuario"
        Me.txtNumeroUsuario.Size = New System.Drawing.Size(143, 20)
        Me.txtNumeroUsuario.TabIndex = 11
        '
        'txtFolioSalida
        '
        Me.txtFolioSalida.Enabled = False
        Me.txtFolioSalida.Location = New System.Drawing.Point(168, 14)
        Me.txtFolioSalida.Name = "txtFolioSalida"
        Me.txtFolioSalida.Size = New System.Drawing.Size(143, 20)
        Me.txtFolioSalida.TabIndex = 12
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(467, 130)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(133, 20)
        Me.txtCantidad.TabIndex = 13
        '
        'txtNombreUsuario
        '
        Me.txtNombreUsuario.Enabled = False
        Me.txtNombreUsuario.Location = New System.Drawing.Point(467, 60)
        Me.txtNombreUsuario.Name = "txtNombreUsuario"
        Me.txtNombreUsuario.Size = New System.Drawing.Size(200, 20)
        Me.txtNombreUsuario.TabIndex = 14
        '
        'btnGuardarSalida
        '
        Me.btnGuardarSalida.Location = New System.Drawing.Point(667, 251)
        Me.btnGuardarSalida.Name = "btnGuardarSalida"
        Me.btnGuardarSalida.Size = New System.Drawing.Size(109, 23)
        Me.btnGuardarSalida.TabIndex = 15
        Me.btnGuardarSalida.Text = "Guardar Salida"
        Me.btnGuardarSalida.UseVisualStyleBackColor = True
        '
        'btnEditarSalida
        '
        Me.btnEditarSalida.Location = New System.Drawing.Point(667, 312)
        Me.btnEditarSalida.Name = "btnEditarSalida"
        Me.btnEditarSalida.Size = New System.Drawing.Size(109, 23)
        Me.btnEditarSalida.TabIndex = 16
        Me.btnEditarSalida.Text = "Editar Salida"
        Me.btnEditarSalida.UseVisualStyleBackColor = True
        '
        'btnEliminarSalida
        '
        Me.btnEliminarSalida.Location = New System.Drawing.Point(667, 374)
        Me.btnEliminarSalida.Name = "btnEliminarSalida"
        Me.btnEliminarSalida.Size = New System.Drawing.Size(109, 23)
        Me.btnEliminarSalida.TabIndex = 17
        Me.btnEliminarSalida.Text = "Eliminar Salida"
        Me.btnEliminarSalida.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.Location = New System.Drawing.Point(27, 179)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(166, 23)
        Me.btnIngresar.TabIndex = 18
        Me.btnIngresar.Text = "Ingresar Producto"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(256, 179)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(166, 23)
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "Modificar Producto"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(483, 179)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(166, 23)
        Me.btnQuitar.TabIndex = 20
        Me.btnQuitar.Text = "Quitar Producto"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'txtRazon
        '
        Me.txtRazon.Location = New System.Drawing.Point(168, 97)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(143, 20)
        Me.txtRazon.TabIndex = 21
        '
        'RegSalidaP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.txtRazon)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.btnEliminarSalida)
        Me.Controls.Add(Me.btnEditarSalida)
        Me.Controls.Add(Me.btnGuardarSalida)
        Me.Controls.Add(Me.txtNombreUsuario)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtFolioSalida)
        Me.Controls.Add(Me.txtNumeroUsuario)
        Me.Controls.Add(Me.dateFechaSalida)
        Me.Controls.Add(Me.cbProducto)
        Me.Controls.Add(Me.dgvRegistroSalida)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RegSalidaP"
        Me.Text = "Registro salida del producto"
        CType(Me.dgvRegistroSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dgvRegistroSalida As DataGridView
    Friend WithEvents cbProducto As ComboBox
    Friend WithEvents dateFechaSalida As DateTimePicker
    Friend WithEvents txtNumeroUsuario As TextBox
    Friend WithEvents txtFolioSalida As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtNombreUsuario As TextBox
    Friend WithEvents btnGuardarSalida As Button
    Friend WithEvents btnEditarSalida As Button
    Friend WithEvents btnEliminarSalida As Button
    Friend WithEvents btnIngresar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents txtRazon As TextBox
End Class
