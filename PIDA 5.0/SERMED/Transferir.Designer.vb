<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transferir
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.campoDirectorio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.botonSeleccionarDirectorio = New System.Windows.Forms.Button()
        Me.pb1 = New System.Windows.Forms.ProgressBar()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.campoTabla = New System.Windows.Forms.TextBox()
        Me.botonSeleccionarTabla = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.campoPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.campoUsuario = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.campoHost = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.campoBase = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'campoDirectorio
        '
        Me.campoDirectorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoDirectorio.Location = New System.Drawing.Point(9, 32)
        Me.campoDirectorio.Name = "campoDirectorio"
        Me.campoDirectorio.Size = New System.Drawing.Size(250, 22)
        Me.campoDirectorio.TabIndex = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Directorio"
        '
        'botonSeleccionarDirectorio
        '
        Me.botonSeleccionarDirectorio.Image = Global.PIDA.NET.My.Resources.Resources.Search16
        Me.botonSeleccionarDirectorio.Location = New System.Drawing.Point(265, 32)
        Me.botonSeleccionarDirectorio.Name = "botonSeleccionarDirectorio"
        Me.botonSeleccionarDirectorio.Size = New System.Drawing.Size(22, 22)
        Me.botonSeleccionarDirectorio.TabIndex = 1000
        Me.botonSeleccionarDirectorio.UseVisualStyleBackColor = True
        '
        'pb1
        '
        Me.pb1.Location = New System.Drawing.Point(12, 593)
        Me.pb1.Name = "pb1"
        Me.pb1.Size = New System.Drawing.Size(513, 23)
        Me.pb1.TabIndex = 1000
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Size = New System.Drawing.Size(516, 575)
        Me.SplitContainer1.SplitterDistance = 287
        Me.SplitContainer1.TabIndex = 1001
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(516, 287)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Origen"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(510, 268)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataGridView2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(516, 284)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Destino"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(510, 265)
        Me.DataGridView2.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1003
        Me.Label2.Text = "Tabla a Importar"
        '
        'campoTabla
        '
        Me.campoTabla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoTabla.Location = New System.Drawing.Point(9, 82)
        Me.campoTabla.Name = "campoTabla"
        Me.campoTabla.Size = New System.Drawing.Size(250, 22)
        Me.campoTabla.TabIndex = 1004
        '
        'botonSeleccionarTabla
        '
        Me.botonSeleccionarTabla.Image = Global.PIDA.NET.My.Resources.Resources.Search16
        Me.botonSeleccionarTabla.Location = New System.Drawing.Point(265, 82)
        Me.botonSeleccionarTabla.Name = "botonSeleccionarTabla"
        Me.botonSeleccionarTabla.Size = New System.Drawing.Size(22, 22)
        Me.botonSeleccionarTabla.TabIndex = 1005
        Me.botonSeleccionarTabla.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.campoPassword)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.campoUsuario)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.campoHost)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.ComboBox1)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.campoBase)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 234)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(293, 292)
        Me.GroupBox3.TabIndex = 1006
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Copiar en"
        '
        'campoPassword
        '
        Me.campoPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoPassword.Location = New System.Drawing.Point(6, 114)
        Me.campoPassword.Name = "campoPassword"
        Me.campoPassword.Size = New System.Drawing.Size(278, 22)
        Me.campoPassword.TabIndex = 1014
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 1013
        Me.Label7.Text = "password"
        '
        'campoUsuario
        '
        Me.campoUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoUsuario.Location = New System.Drawing.Point(6, 73)
        Me.campoUsuario.Name = "campoUsuario"
        Me.campoUsuario.Size = New System.Drawing.Size(278, 22)
        Me.campoUsuario.TabIndex = 1012
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 1011
        Me.Label6.Text = "usuario"
        '
        'campoHost
        '
        Me.campoHost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoHost.Location = New System.Drawing.Point(6, 32)
        Me.campoHost.Name = "campoHost"
        Me.campoHost.Size = New System.Drawing.Size(278, 22)
        Me.campoHost.TabIndex = 1010
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 1009
        Me.Label5.Text = "Host"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 196)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(278, 21)
        Me.ComboBox1.TabIndex = 1007
        '
        'Button1
        '
        Me.Button1.Image = Global.PIDA.NET.My.Resources.Resources.Search16
        Me.Button1.Location = New System.Drawing.Point(262, 155)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 1006
        Me.Button1.UseVisualStyleBackColor = True
        '
        'campoBase
        '
        Me.campoBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoBase.Location = New System.Drawing.Point(6, 155)
        Me.campoBase.Name = "campoBase"
        Me.campoBase.Size = New System.Drawing.Size(250, 22)
        Me.campoBase.TabIndex = 1005
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Base de SQL"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.campoDirectorio)
        Me.GroupBox4.Controls.Add(Me.botonSeleccionarTabla)
        Me.GroupBox4.Controls.Add(Me.botonSeleccionarDirectorio)
        Me.GroupBox4.Controls.Add(Me.campoTabla)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(293, 116)
        Me.GroupBox4.TabIndex = 1007
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Origen"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox4)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox5)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox7)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(531, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(299, 604)
        Me.FlowLayoutPanel1.TabIndex = 1008
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ListBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 125)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(293, 103)
        Me.GroupBox5.TabIndex = 1008
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Campos"
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.White
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(3, 16)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(287, 84)
        Me.ListBox1.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Button2)
        Me.GroupBox7.Location = New System.Drawing.Point(3, 532)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(293, 57)
        Me.GroupBox7.TabIndex = 1010
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Acciones"
        '
        'Button2
        '
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(6, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(278, 22)
        Me.Button2.TabIndex = 1006
        Me.Button2.Text = "Transferir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 1015
        Me.Label4.Text = "Tabla"
        '
        'Transferir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(842, 628)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pb1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Transferir"
        Me.Text = "Transferir"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents campoDirectorio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents botonSeleccionarDirectorio As System.Windows.Forms.Button
    Friend WithEvents pb1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents campoTabla As System.Windows.Forms.TextBox
    Friend WithEvents botonSeleccionarTabla As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents campoBase As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents campoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents campoHost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents campoPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
