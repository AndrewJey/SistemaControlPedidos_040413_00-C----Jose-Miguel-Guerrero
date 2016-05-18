<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Productos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Productos))
        Me.Panel_Categorias = New System.Windows.Forms.Panel
        Me.Panel_Productos = New System.Windows.Forms.Panel
        Me.Panel_DetArt = New System.Windows.Forms.Panel
        Me.Lbl_C = New System.Windows.Forms.Label
        Me.Lbl_P = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Pct_Categoria = New System.Windows.Forms.PictureBox
        Me.Pct_Producto = New System.Windows.Forms.PictureBox
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Btn_Modificar = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Cmb_Categorias = New System.Windows.Forms.ComboBox
        Me.Txt_Producto = New System.Windows.Forms.TextBox
        Me.Txt_Precio = New System.Windows.Forms.TextBox
        Me.Txt_Codigo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel_DetArt.SuspendLayout()
        CType(Me.Pct_Categoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pct_Producto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_Categorias
        '
        Me.Panel_Categorias.AutoScroll = True
        Me.Panel_Categorias.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.page_bg
        Me.Panel_Categorias.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Categorias.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Categorias.Name = "Panel_Categorias"
        Me.Panel_Categorias.Size = New System.Drawing.Size(1174, 143)
        Me.Panel_Categorias.TabIndex = 0
        '
        'Panel_Productos
        '
        Me.Panel_Productos.AutoScroll = True
        Me.Panel_Productos.BackColor = System.Drawing.Color.Transparent
        Me.Panel_Productos.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel_Productos.Location = New System.Drawing.Point(0, 143)
        Me.Panel_Productos.Name = "Panel_Productos"
        Me.Panel_Productos.Size = New System.Drawing.Size(789, 423)
        Me.Panel_Productos.TabIndex = 1
        '
        'Panel_DetArt
        '
        Me.Panel_DetArt.BackColor = System.Drawing.Color.DimGray
        Me.Panel_DetArt.Controls.Add(Me.Lbl_C)
        Me.Panel_DetArt.Controls.Add(Me.Lbl_P)
        Me.Panel_DetArt.Controls.Add(Me.Label6)
        Me.Panel_DetArt.Controls.Add(Me.Label5)
        Me.Panel_DetArt.Controls.Add(Me.Pct_Categoria)
        Me.Panel_DetArt.Controls.Add(Me.Pct_Producto)
        Me.Panel_DetArt.Controls.Add(Me.Btn_Nuevo)
        Me.Panel_DetArt.Controls.Add(Me.Btn_Modificar)
        Me.Panel_DetArt.Controls.Add(Me.Btn_Salir)
        Me.Panel_DetArt.Controls.Add(Me.Btn_Eliminar)
        Me.Panel_DetArt.Controls.Add(Me.Cmb_Categorias)
        Me.Panel_DetArt.Controls.Add(Me.Txt_Producto)
        Me.Panel_DetArt.Controls.Add(Me.Txt_Precio)
        Me.Panel_DetArt.Controls.Add(Me.Txt_Codigo)
        Me.Panel_DetArt.Controls.Add(Me.Label4)
        Me.Panel_DetArt.Controls.Add(Me.Label3)
        Me.Panel_DetArt.Controls.Add(Me.Label2)
        Me.Panel_DetArt.Controls.Add(Me.Label1)
        Me.Panel_DetArt.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel_DetArt.Location = New System.Drawing.Point(808, 143)
        Me.Panel_DetArt.Name = "Panel_DetArt"
        Me.Panel_DetArt.Size = New System.Drawing.Size(366, 423)
        Me.Panel_DetArt.TabIndex = 2
        '
        'Lbl_C
        '
        Me.Lbl_C.AutoSize = True
        Me.Lbl_C.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_C.ForeColor = System.Drawing.Color.White
        Me.Lbl_C.Location = New System.Drawing.Point(79, 240)
        Me.Lbl_C.Name = "Lbl_C"
        Me.Lbl_C.Size = New System.Drawing.Size(67, 13)
        Me.Lbl_C.TabIndex = 17
        Me.Lbl_C.Text = "Categorias"
        Me.Lbl_C.Visible = False
        '
        'Lbl_P
        '
        Me.Lbl_P.AutoSize = True
        Me.Lbl_P.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_P.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_P.ForeColor = System.Drawing.Color.White
        Me.Lbl_P.Location = New System.Drawing.Point(82, 253)
        Me.Lbl_P.Name = "Lbl_P"
        Me.Lbl_P.Size = New System.Drawing.Size(64, 13)
        Me.Lbl_P.TabIndex = 16
        Me.Lbl_P.Text = "Productos"
        Me.Lbl_P.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(200, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(146, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Imagen Producto"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(200, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Imagen Categoria"
        '
        'Pct_Categoria
        '
        Me.Pct_Categoria.BackColor = System.Drawing.Color.Transparent
        Me.Pct_Categoria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pct_Categoria.Location = New System.Drawing.Point(204, 207)
        Me.Pct_Categoria.Name = "Pct_Categoria"
        Me.Pct_Categoria.Size = New System.Drawing.Size(141, 125)
        Me.Pct_Categoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pct_Categoria.TabIndex = 13
        Me.Pct_Categoria.TabStop = False
        '
        'Pct_Producto
        '
        Me.Pct_Producto.BackColor = System.Drawing.Color.Transparent
        Me.Pct_Producto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pct_Producto.Location = New System.Drawing.Point(204, 29)
        Me.Pct_Producto.Name = "Pct_Producto"
        Me.Pct_Producto.Size = New System.Drawing.Size(141, 125)
        Me.Pct_Producto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pct_Producto.TabIndex = 12
        Me.Pct_Producto.TabStop = False
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Location = New System.Drawing.Point(2, 285)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Nuevo.TabIndex = 6
        Me.Btn_Nuevo.Text = "Nuevo"
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Btn_Modificar
        '
        Me.Btn_Modificar.Location = New System.Drawing.Point(123, 353)
        Me.Btn_Modificar.Name = "Btn_Modificar"
        Me.Btn_Modificar.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Modificar.TabIndex = 8
        Me.Btn_Modificar.Text = "Modificar"
        Me.Btn_Modificar.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Location = New System.Drawing.Point(244, 353)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Salir.TabIndex = 9
        Me.Btn_Salir.Text = "Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Location = New System.Drawing.Point(2, 353)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Eliminar.TabIndex = 7
        Me.Btn_Eliminar.Text = "Eliminar"
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'Cmb_Categorias
        '
        Me.Cmb_Categorias.BackColor = System.Drawing.Color.Silver
        Me.Cmb_Categorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Categorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Categorias.FormattingEnabled = True
        Me.Cmb_Categorias.Location = New System.Drawing.Point(30, 207)
        Me.Cmb_Categorias.Name = "Cmb_Categorias"
        Me.Cmb_Categorias.Size = New System.Drawing.Size(155, 26)
        Me.Cmb_Categorias.TabIndex = 3
        '
        'Txt_Producto
        '
        Me.Txt_Producto.BackColor = System.Drawing.Color.Silver
        Me.Txt_Producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Producto.Location = New System.Drawing.Point(30, 89)
        Me.Txt_Producto.MaxLength = 50
        Me.Txt_Producto.Name = "Txt_Producto"
        Me.Txt_Producto.Size = New System.Drawing.Size(155, 24)
        Me.Txt_Producto.TabIndex = 1
        '
        'Txt_Precio
        '
        Me.Txt_Precio.BackColor = System.Drawing.Color.Silver
        Me.Txt_Precio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Precio.Location = New System.Drawing.Point(30, 151)
        Me.Txt_Precio.MaxLength = 8
        Me.Txt_Precio.Name = "Txt_Precio"
        Me.Txt_Precio.Size = New System.Drawing.Size(155, 24)
        Me.Txt_Precio.TabIndex = 2
        '
        'Txt_Codigo
        '
        Me.Txt_Codigo.BackColor = System.Drawing.Color.Silver
        Me.Txt_Codigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Codigo.Location = New System.Drawing.Point(30, 29)
        Me.Txt_Codigo.Name = "Txt_Codigo"
        Me.Txt_Codigo.Size = New System.Drawing.Size(155, 24)
        Me.Txt_Codigo.TabIndex = 0
        Me.Txt_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Categoria"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Precio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'Frm_Productos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.fondo_madera_negro
        Me.ClientSize = New System.Drawing.Size(1174, 566)
        Me.Controls.Add(Me.Panel_DetArt)
        Me.Controls.Add(Me.Panel_Productos)
        Me.Controls.Add(Me.Panel_Categorias)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Productos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frm_Productos"
        Me.Panel_DetArt.ResumeLayout(False)
        Me.Panel_DetArt.PerformLayout()
        CType(Me.Pct_Categoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pct_Producto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel_Categorias As System.Windows.Forms.Panel
    Friend WithEvents Panel_Productos As System.Windows.Forms.Panel
    Friend WithEvents Panel_DetArt As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Categorias As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Producto As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Precio As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Modificar As System.Windows.Forms.Button
    Friend WithEvents Pct_Producto As System.Windows.Forms.PictureBox
    Friend WithEvents Pct_Categoria As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Lbl_P As System.Windows.Forms.Label
    Friend WithEvents Lbl_C As System.Windows.Forms.Label
End Class
