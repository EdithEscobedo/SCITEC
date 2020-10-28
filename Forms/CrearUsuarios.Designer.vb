<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrearUsuarios
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
        Me.txtNumUsuario = New System.Windows.Forms.TextBox()
        Me.NumeroUsuario = New System.Windows.Forms.Label()
        Me.NombreUsuario = New System.Windows.Forms.Label()
        Me.Telefono = New System.Windows.Forms.Label()
        Me.TipoUsuario = New System.Windows.Forms.Label()
        Me.Username = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.Label()
        Me.ConfirPassword = New System.Windows.Forms.Label()
        Me.txtNomUsuario = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtConfPass = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbTipoUsuario = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.imageUser = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imageUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNumUsuario
        '
        Me.txtNumUsuario.Enabled = False
        Me.txtNumUsuario.Location = New System.Drawing.Point(168, 154)
        Me.txtNumUsuario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumUsuario.Name = "txtNumUsuario"
        Me.txtNumUsuario.Size = New System.Drawing.Size(121, 21)
        Me.txtNumUsuario.TabIndex = 0
        '
        'NumeroUsuario
        '
        Me.NumeroUsuario.AutoSize = True
        Me.NumeroUsuario.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumeroUsuario.Location = New System.Drawing.Point(35, 154)
        Me.NumeroUsuario.Name = "NumeroUsuario"
        Me.NumeroUsuario.Size = New System.Drawing.Size(113, 17)
        Me.NumeroUsuario.TabIndex = 100
        Me.NumeroUsuario.Text = "Numero usuario"
        '
        'NombreUsuario
        '
        Me.NombreUsuario.AutoSize = True
        Me.NombreUsuario.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreUsuario.Location = New System.Drawing.Point(35, 211)
        Me.NombreUsuario.Name = "NombreUsuario"
        Me.NombreUsuario.Size = New System.Drawing.Size(113, 17)
        Me.NombreUsuario.TabIndex = 101
        Me.NombreUsuario.Text = "Nombre usuario"
        '
        'Telefono
        '
        Me.Telefono.AutoSize = True
        Me.Telefono.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Telefono.Location = New System.Drawing.Point(35, 265)
        Me.Telefono.Name = "Telefono"
        Me.Telefono.Size = New System.Drawing.Size(69, 17)
        Me.Telefono.TabIndex = 102
        Me.Telefono.Text = "Teléfono "
        '
        'TipoUsuario
        '
        Me.TipoUsuario.AutoSize = True
        Me.TipoUsuario.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoUsuario.Location = New System.Drawing.Point(35, 314)
        Me.TipoUsuario.Name = "TipoUsuario"
        Me.TipoUsuario.Size = New System.Drawing.Size(90, 17)
        Me.TipoUsuario.TabIndex = 103
        Me.TipoUsuario.Text = "Tipo usuario"
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.Location = New System.Drawing.Point(35, 366)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(75, 17)
        Me.Username.TabIndex = 104
        Me.Username.Text = "Username"
        '
        'Password
        '
        Me.Password.AutoSize = True
        Me.Password.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password.Location = New System.Drawing.Point(37, 424)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(70, 17)
        Me.Password.TabIndex = 106
        Me.Password.Text = "Password"
        '
        'ConfirPassword
        '
        Me.ConfirPassword.AutoSize = True
        Me.ConfirPassword.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConfirPassword.Location = New System.Drawing.Point(35, 482)
        Me.ConfirPassword.Name = "ConfirPassword"
        Me.ConfirPassword.Size = New System.Drawing.Size(126, 17)
        Me.ConfirPassword.TabIndex = 107
        Me.ConfirPassword.Text = "Confirm password"
        '
        'txtNomUsuario
        '
        Me.txtNomUsuario.Location = New System.Drawing.Point(168, 211)
        Me.txtNomUsuario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNomUsuario.Name = "txtNomUsuario"
        Me.txtNomUsuario.Size = New System.Drawing.Size(121, 21)
        Me.txtNomUsuario.TabIndex = 1
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(168, 265)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(121, 21)
        Me.txtTelefono.TabIndex = 2
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(168, 366)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(121, 21)
        Me.txtUsername.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(168, 424)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtPassword.Size = New System.Drawing.Size(121, 21)
        Me.txtPassword.TabIndex = 5
        '
        'txtConfPass
        '
        Me.txtConfPass.Location = New System.Drawing.Point(168, 482)
        Me.txtConfPass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtConfPass.Name = "txtConfPass"
        Me.txtConfPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtConfPass.Size = New System.Drawing.Size(121, 21)
        Me.txtConfPass.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(389, 519)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 26)
        Me.btnGuardar.TabIndex = 7
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(540, 519)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 26)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbTipoUsuario
        '
        Me.cbTipoUsuario.BackColor = System.Drawing.SystemColors.Window
        Me.cbTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cbTipoUsuario.FormattingEnabled = True
        Me.cbTipoUsuario.Location = New System.Drawing.Point(168, 314)
        Me.cbTipoUsuario.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbTipoUsuario.Name = "cbTipoUsuario"
        Me.cbTipoUsuario.Size = New System.Drawing.Size(121, 23)
        Me.cbTipoUsuario.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.SCITEC.My.Resources.Resources.agregar
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(143, 45)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(225, 40)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'imageUser
        '
        Me.imageUser.BackgroundImage = Global.SCITEC.My.Resources.Resources.agregarUsuario
        Me.imageUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.imageUser.Location = New System.Drawing.Point(37, 28)
        Me.imageUser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.imageUser.Name = "imageUser"
        Me.imageUser.Size = New System.Drawing.Size(100, 81)
        Me.imageUser.TabIndex = 17
        Me.imageUser.TabStop = False
        '
        'CrearUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(704, 559)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.imageUser)
        Me.Controls.Add(Me.cbTipoUsuario)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtConfPass)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.txtNomUsuario)
        Me.Controls.Add(Me.ConfirPassword)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.TipoUsuario)
        Me.Controls.Add(Me.Telefono)
        Me.Controls.Add(Me.NombreUsuario)
        Me.Controls.Add(Me.NumeroUsuario)
        Me.Controls.Add(Me.txtNumUsuario)
        Me.Font = New System.Drawing.Font("Microsoft New Tai Lue", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "CrearUsuarios"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CREAR USUARIOS"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imageUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNumUsuario As TextBox
    Friend WithEvents NumeroUsuario As Label
    Friend WithEvents NombreUsuario As Label
    Friend WithEvents Telefono As Label
    Friend WithEvents TipoUsuario As Label
    Friend WithEvents Username As Label
    Friend WithEvents Password As Label
    Friend WithEvents ConfirPassword As Label
    Friend WithEvents txtNomUsuario As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtConfPass As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents cbTipoUsuario As ComboBox
    Friend WithEvents imageUser As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
