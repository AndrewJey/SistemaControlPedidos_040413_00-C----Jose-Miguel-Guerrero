<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Facturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Facturas))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LB_Contenedor = New System.Windows.Forms.ListBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Cmb_Cliente = New System.Windows.Forms.ComboBox
        Me.Btn_Facturar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Cmb_Empleado = New System.Windows.Forms.ComboBox
        Me.Lbl_Total = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ND_descuento = New System.Windows.Forms.NumericUpDown
        Me.Label4 = New System.Windows.Forms.Label
        Me.Lbl_Subtotal = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LB_Facturar = New System.Windows.Forms.ListBox
        Me.LB_Pedido = New System.Windows.Forms.ListBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Btn_Excluir = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Btn_Todos = New System.Windows.Forms.Button
        Me.Btn_Incluir = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Lbl_Pedido = New System.Windows.Forms.Label
        Me.Cmb_Pedidos = New System.Windows.Forms.ComboBox
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ND_descuento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.fondo_madera_negro
        Me.Panel2.Controls.Add(Me.LB_Contenedor)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.LB_Facturar)
        Me.Panel2.Controls.Add(Me.LB_Pedido)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(1, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(946, 423)
        Me.Panel2.TabIndex = 1
        '
        'LB_Contenedor
        '
        Me.LB_Contenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Contenedor.FormattingEnabled = True
        Me.LB_Contenedor.ItemHeight = 16
        Me.LB_Contenedor.Location = New System.Drawing.Point(752, 389)
        Me.LB_Contenedor.Name = "LB_Contenedor"
        Me.LB_Contenedor.Size = New System.Drawing.Size(92, 20)
        Me.LB_Contenedor.TabIndex = 4
        Me.LB_Contenedor.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Silver
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Cmb_Cliente)
        Me.Panel4.Controls.Add(Me.Btn_Facturar)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Cmb_Empleado)
        Me.Panel4.Controls.Add(Me.Lbl_Total)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.ND_descuento)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Lbl_Subtotal)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(752, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(182, 307)
        Me.Panel4.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Cliente"
        '
        'Cmb_Cliente
        '
        Me.Cmb_Cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Cliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Cliente.FormattingEnabled = True
        Me.Cmb_Cliente.Items.AddRange(New Object() {"Contado", "Credito"})
        Me.Cmb_Cliente.Location = New System.Drawing.Point(19, 188)
        Me.Cmb_Cliente.Name = "Cmb_Cliente"
        Me.Cmb_Cliente.Size = New System.Drawing.Size(148, 26)
        Me.Cmb_Cliente.TabIndex = 2
        '
        'Btn_Facturar
        '
        Me.Btn_Facturar.Location = New System.Drawing.Point(30, 232)
        Me.Btn_Facturar.Name = "Btn_Facturar"
        Me.Btn_Facturar.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Facturar.TabIndex = 3
        Me.Btn_Facturar.Text = "Facturar"
        Me.Btn_Facturar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Empleado"
        '
        'Cmb_Empleado
        '
        Me.Cmb_Empleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Empleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Empleado.FormattingEnabled = True
        Me.Cmb_Empleado.Location = New System.Drawing.Point(4, 136)
        Me.Cmb_Empleado.Name = "Cmb_Empleado"
        Me.Cmb_Empleado.Size = New System.Drawing.Size(175, 26)
        Me.Cmb_Empleado.TabIndex = 1
        '
        'Lbl_Total
        '
        Me.Lbl_Total.AutoSize = True
        Me.Lbl_Total.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Total.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Total.Location = New System.Drawing.Point(67, 80)
        Me.Lbl_Total.Name = "Lbl_Total"
        Me.Lbl_Total.Size = New System.Drawing.Size(16, 16)
        Me.Lbl_Total.TabIndex = 7
        Me.Lbl_Total.Text = "0"
        Me.Lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Total:"
        '
        'ND_descuento
        '
        Me.ND_descuento.DecimalPlaces = 2
        Me.ND_descuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ND_descuento.Location = New System.Drawing.Point(111, 42)
        Me.ND_descuento.Name = "ND_descuento"
        Me.ND_descuento.Size = New System.Drawing.Size(56, 22)
        Me.ND_descuento.TabIndex = 0
        Me.ND_descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Descuento:"
        '
        'Lbl_Subtotal
        '
        Me.Lbl_Subtotal.AutoSize = True
        Me.Lbl_Subtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Subtotal.ForeColor = System.Drawing.Color.Black
        Me.Lbl_Subtotal.Location = New System.Drawing.Point(95, 10)
        Me.Lbl_Subtotal.Name = "Lbl_Subtotal"
        Me.Lbl_Subtotal.Size = New System.Drawing.Size(16, 16)
        Me.Lbl_Subtotal.TabIndex = 3
        Me.Lbl_Subtotal.Text = "0"
        Me.Lbl_Subtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Subtotal:"
        '
        'LB_Facturar
        '
        Me.LB_Facturar.BackColor = System.Drawing.Color.Gray
        Me.LB_Facturar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Facturar.ForeColor = System.Drawing.Color.White
        Me.LB_Facturar.FormattingEnabled = True
        Me.LB_Facturar.ItemHeight = 16
        Me.LB_Facturar.Location = New System.Drawing.Point(471, 1)
        Me.LB_Facturar.Name = "LB_Facturar"
        Me.LB_Facturar.Size = New System.Drawing.Size(266, 420)
        Me.LB_Facturar.TabIndex = 1
        '
        'LB_Pedido
        '
        Me.LB_Pedido.BackColor = System.Drawing.Color.Gray
        Me.LB_Pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Pedido.ForeColor = System.Drawing.Color.White
        Me.LB_Pedido.FormattingEnabled = True
        Me.LB_Pedido.ItemHeight = 16
        Me.LB_Pedido.Location = New System.Drawing.Point(11, 1)
        Me.LB_Pedido.Name = "LB_Pedido"
        Me.LB_Pedido.Size = New System.Drawing.Size(266, 420)
        Me.LB_Pedido.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Controls.Add(Me.Btn_Excluir)
        Me.Panel3.Controls.Add(Me.Btn_Salir)
        Me.Panel3.Controls.Add(Me.Btn_Todos)
        Me.Panel3.Controls.Add(Me.Btn_Incluir)
        Me.Panel3.Location = New System.Drawing.Point(283, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(182, 422)
        Me.Panel3.TabIndex = 0
        '
        'Btn_Excluir
        '
        Me.Btn_Excluir.Location = New System.Drawing.Point(27, 152)
        Me.Btn_Excluir.Name = "Btn_Excluir"
        Me.Btn_Excluir.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Excluir.TabIndex = 2
        Me.Btn_Excluir.Text = "Excluir"
        Me.Btn_Excluir.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Location = New System.Drawing.Point(27, 303)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Salir.TabIndex = 3
        Me.Btn_Salir.Text = "Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Btn_Todos
        '
        Me.Btn_Todos.Location = New System.Drawing.Point(27, 79)
        Me.Btn_Todos.Name = "Btn_Todos"
        Me.Btn_Todos.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Todos.TabIndex = 1
        Me.Btn_Todos.Text = "Incluir Todos"
        Me.Btn_Todos.UseVisualStyleBackColor = True
        '
        'Btn_Incluir
        '
        Me.Btn_Incluir.Location = New System.Drawing.Point(27, 6)
        Me.Btn_Incluir.Name = "Btn_Incluir"
        Me.Btn_Incluir.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Incluir.TabIndex = 0
        Me.Btn_Incluir.Text = "Incluir"
        Me.Btn_Incluir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.page_bg
        Me.Panel1.Controls.Add(Me.Lbl_Pedido)
        Me.Panel1.Controls.Add(Me.Cmb_Pedidos)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 90)
        Me.Panel1.TabIndex = 0
        '
        'Lbl_Pedido
        '
        Me.Lbl_Pedido.AutoSize = True
        Me.Lbl_Pedido.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Pedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Pedido.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl_Pedido.Location = New System.Drawing.Point(75, 18)
        Me.Lbl_Pedido.Name = "Lbl_Pedido"
        Me.Lbl_Pedido.Size = New System.Drawing.Size(121, 20)
        Me.Lbl_Pedido.TabIndex = 9
        Me.Lbl_Pedido.Text = "Nº De Pedido "
        '
        'Cmb_Pedidos
        '
        Me.Cmb_Pedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Pedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Pedidos.FormattingEnabled = True
        Me.Cmb_Pedidos.Location = New System.Drawing.Point(28, 46)
        Me.Cmb_Pedidos.Name = "Cmb_Pedidos"
        Me.Cmb_Pedidos.Size = New System.Drawing.Size(214, 26)
        Me.Cmb_Pedidos.TabIndex = 0
        '
        'Frm_Facturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 510)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Facturas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frm_Facturas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.ND_descuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LB_Facturar As System.Windows.Forms.ListBox
    Friend WithEvents LB_Pedido As System.Windows.Forms.ListBox
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Facturar As System.Windows.Forms.Button
    Friend WithEvents Btn_Todos As System.Windows.Forms.Button
    Friend WithEvents Btn_Incluir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Cmb_Pedidos As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_Pedido As System.Windows.Forms.Label
    Friend WithEvents Btn_Excluir As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Total As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ND_descuento As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Lbl_Subtotal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Empleado As System.Windows.Forms.ComboBox
    Friend WithEvents LB_Contenedor As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cmb_Cliente As System.Windows.Forms.ComboBox
End Class
