<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pedidos
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pedidos))
        Me.Tmr_Hora = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_DetalleProducto = New System.Windows.Forms.Panel
        Me.Panel_DetPro = New System.Windows.Forms.Panel
        Me.lbl_Nombre = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lbl_Nombre2 = New System.Windows.Forms.Label
        Me.lbl_CodigoProducto = New System.Windows.Forms.Label
        Me.Btn_Agregar = New System.Windows.Forms.Button
        Me.Btn_Facturar = New System.Windows.Forms.Button
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Salir = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_Observaciones = New System.Windows.Forms.TextBox
        Me.Btn_Eliminar = New System.Windows.Forms.Button
        Me.Btn_Imprimir = New System.Windows.Forms.Button
        Me.Btn_Guardar = New System.Windows.Forms.Button
        Me.Nud_Cantidad = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.Txt_Subtotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txt_PU = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Lst_Productos = New System.Windows.Forms.ListBox
        Me.Panel_Productos = New System.Windows.Forms.Panel
        Me.Panel_Categorias = New System.Windows.Forms.Panel
        Me.Panel_Datps = New System.Windows.Forms.Panel
        Me.Cmb_Empleados = New System.Windows.Forms.ComboBox
        Me.Btn_NuevaOrden = New System.Windows.Forms.Button
        Me.Lbl_NP = New System.Windows.Forms.ComboBox
        Me.Lbl_NU = New System.Windows.Forms.Label
        Me.Lbl_NM = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lbl_Dia = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel_DetalleProducto.SuspendLayout()
        Me.Panel_DetPro.SuspendLayout()
        CType(Me.Nud_Cantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Datps.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tmr_Hora
        '
        Me.Tmr_Hora.Enabled = True
        '
        'Panel_DetalleProducto
        '
        Me.Panel_DetalleProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_DetalleProducto.Controls.Add(Me.Panel_DetPro)
        Me.Panel_DetalleProducto.Controls.Add(Me.Panel_Productos)
        Me.Panel_DetalleProducto.Controls.Add(Me.Panel_Categorias)
        Me.Panel_DetalleProducto.Controls.Add(Me.Panel_Datps)
        Me.Panel_DetalleProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_DetalleProducto.Location = New System.Drawing.Point(0, 0)
        Me.Panel_DetalleProducto.Name = "Panel_DetalleProducto"
        Me.Panel_DetalleProducto.Size = New System.Drawing.Size(955, 555)
        Me.Panel_DetalleProducto.TabIndex = 3
        '
        'Panel_DetPro
        '
        Me.Panel_DetPro.BackColor = System.Drawing.Color.DimGray
        Me.Panel_DetPro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_DetPro.Controls.Add(Me.lbl_Nombre)
        Me.Panel_DetPro.Controls.Add(Me.Label9)
        Me.Panel_DetPro.Controls.Add(Me.lbl_Nombre2)
        Me.Panel_DetPro.Controls.Add(Me.lbl_CodigoProducto)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Agregar)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Facturar)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Cancelar)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Salir)
        Me.Panel_DetPro.Controls.Add(Me.Label8)
        Me.Panel_DetPro.Controls.Add(Me.Txt_Observaciones)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Eliminar)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Imprimir)
        Me.Panel_DetPro.Controls.Add(Me.Btn_Guardar)
        Me.Panel_DetPro.Controls.Add(Me.Nud_Cantidad)
        Me.Panel_DetPro.Controls.Add(Me.Label7)
        Me.Panel_DetPro.Controls.Add(Me.Txt_Subtotal)
        Me.Panel_DetPro.Controls.Add(Me.Label6)
        Me.Panel_DetPro.Controls.Add(Me.Txt_PU)
        Me.Panel_DetPro.Controls.Add(Me.Label5)
        Me.Panel_DetPro.Controls.Add(Me.Label3)
        Me.Panel_DetPro.Controls.Add(Me.Lst_Productos)
        Me.Panel_DetPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_DetPro.Location = New System.Drawing.Point(177, 330)
        Me.Panel_DetPro.Name = "Panel_DetPro"
        Me.Panel_DetPro.Size = New System.Drawing.Size(774, 221)
        Me.Panel_DetPro.TabIndex = 10
        '
        'lbl_Nombre
        '
        Me.lbl_Nombre.Location = New System.Drawing.Point(151, 44)
        Me.lbl_Nombre.MaxLength = 50
        Me.lbl_Nombre.Name = "lbl_Nombre"
        Me.lbl_Nombre.Size = New System.Drawing.Size(113, 20)
        Me.lbl_Nombre.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(148, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Nombre"
        '
        'lbl_Nombre2
        '
        Me.lbl_Nombre2.AutoSize = True
        Me.lbl_Nombre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Nombre2.Location = New System.Drawing.Point(148, 49)
        Me.lbl_Nombre2.Name = "lbl_Nombre2"
        Me.lbl_Nombre2.Size = New System.Drawing.Size(12, 16)
        Me.lbl_Nombre2.TabIndex = 30
        Me.lbl_Nombre2.Text = "-"
        Me.lbl_Nombre2.Visible = False
        '
        'lbl_CodigoProducto
        '
        Me.lbl_CodigoProducto.AutoSize = True
        Me.lbl_CodigoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_CodigoProducto.Location = New System.Drawing.Point(148, 5)
        Me.lbl_CodigoProducto.Name = "lbl_CodigoProducto"
        Me.lbl_CodigoProducto.Size = New System.Drawing.Size(58, 16)
        Me.lbl_CodigoProducto.TabIndex = 29
        Me.lbl_CodigoProducto.Text = "Codigo"
        Me.lbl_CodigoProducto.Visible = False
        '
        'Btn_Agregar
        '
        Me.Btn_Agregar.Location = New System.Drawing.Point(371, 135)
        Me.Btn_Agregar.Name = "Btn_Agregar"
        Me.Btn_Agregar.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Agregar.TabIndex = 5
        Me.Btn_Agregar.Text = "Agregar a Orden"
        Me.Btn_Agregar.UseVisualStyleBackColor = True
        '
        'Btn_Facturar
        '
        Me.Btn_Facturar.Location = New System.Drawing.Point(637, 81)
        Me.Btn_Facturar.Name = "Btn_Facturar"
        Me.Btn_Facturar.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Facturar.TabIndex = 9
        Me.Btn_Facturar.Text = "Facturar Orden"
        Me.Btn_Facturar.UseVisualStyleBackColor = True
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(511, 135)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Cancelar.TabIndex = 10
        Me.Btn_Cancelar.Text = "Cancelar Orden"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        '
        'Btn_Salir
        '
        Me.Btn_Salir.Location = New System.Drawing.Point(637, 135)
        Me.Btn_Salir.Name = "Btn_Salir"
        Me.Btn_Salir.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Salir.TabIndex = 11
        Me.Btn_Salir.Text = "Salir"
        Me.Btn_Salir.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(277, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 16)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Observaciones"
        '
        'Txt_Observaciones
        '
        Me.Txt_Observaciones.Location = New System.Drawing.Point(280, 50)
        Me.Txt_Observaciones.MaxLength = 255
        Me.Txt_Observaciones.Multiline = True
        Me.Txt_Observaciones.Name = "Txt_Observaciones"
        Me.Txt_Observaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Observaciones.Size = New System.Drawing.Size(214, 81)
        Me.Txt_Observaciones.TabIndex = 4
        '
        'Btn_Eliminar
        '
        Me.Btn_Eliminar.Location = New System.Drawing.Point(637, 28)
        Me.Btn_Eliminar.Name = "Btn_Eliminar"
        Me.Btn_Eliminar.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Eliminar.TabIndex = 7
        Me.Btn_Eliminar.Text = "Eliminar Producto"
        Me.Btn_Eliminar.UseVisualStyleBackColor = True
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.Location = New System.Drawing.Point(511, 81)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Imprimir.TabIndex = 8
        Me.Btn_Imprimir.Text = "Imprimir Orden"
        Me.Btn_Imprimir.UseVisualStyleBackColor = True
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Location = New System.Drawing.Point(511, 28)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(123, 50)
        Me.Btn_Guardar.TabIndex = 6
        Me.Btn_Guardar.Text = "Guardar Orden"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        '
        'Nud_Cantidad
        '
        Me.Nud_Cantidad.Location = New System.Drawing.Point(151, 126)
        Me.Nud_Cantidad.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Nud_Cantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_Cantidad.Name = "Nud_Cantidad"
        Me.Nud_Cantidad.Size = New System.Drawing.Size(67, 20)
        Me.Nud_Cantidad.TabIndex = 3
        Me.Nud_Cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Nud_Cantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(150, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 16)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Subtotal"
        '
        'Txt_Subtotal
        '
        Me.Txt_Subtotal.Location = New System.Drawing.Point(153, 165)
        Me.Txt_Subtotal.Name = "Txt_Subtotal"
        Me.Txt_Subtotal.ReadOnly = True
        Me.Txt_Subtotal.Size = New System.Drawing.Size(111, 20)
        Me.Txt_Subtotal.TabIndex = 17
        Me.Txt_Subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(148, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Precio Unitario"
        '
        'Txt_PU
        '
        Me.Txt_PU.Location = New System.Drawing.Point(151, 85)
        Me.Txt_PU.Name = "Txt_PU"
        Me.Txt_PU.Size = New System.Drawing.Size(113, 20)
        Me.Txt_PU.TabIndex = 2
        Me.Txt_PU.Text = "0"
        Me.Txt_PU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(148, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Cantidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Productos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lst_Productos
        '
        Me.Lst_Productos.BackColor = System.Drawing.Color.Gray
        Me.Lst_Productos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lst_Productos.FormattingEnabled = True
        Me.Lst_Productos.Location = New System.Drawing.Point(11, 24)
        Me.Lst_Productos.Name = "Lst_Productos"
        Me.Lst_Productos.Size = New System.Drawing.Size(131, 184)
        Me.Lst_Productos.TabIndex = 0
        '
        'Panel_Productos
        '
        Me.Panel_Productos.AutoScroll = True
        Me.Panel_Productos.BackColor = System.Drawing.Color.Silver
        Me.Panel_Productos.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.page_bg
        Me.Panel_Productos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_Productos.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Productos.Location = New System.Drawing.Point(177, 37)
        Me.Panel_Productos.Name = "Panel_Productos"
        Me.Panel_Productos.Size = New System.Drawing.Size(774, 293)
        Me.Panel_Productos.TabIndex = 9
        '
        'Panel_Categorias
        '
        Me.Panel_Categorias.AutoScroll = True
        Me.Panel_Categorias.BackColor = System.Drawing.Color.LightGray
        Me.Panel_Categorias.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.fondo_madera_negro
        Me.Panel_Categorias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_Categorias.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel_Categorias.Location = New System.Drawing.Point(0, 37)
        Me.Panel_Categorias.Name = "Panel_Categorias"
        Me.Panel_Categorias.Size = New System.Drawing.Size(177, 514)
        Me.Panel_Categorias.TabIndex = 8
        '
        'Panel_Datps
        '
        Me.Panel_Datps.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel_Datps.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.fondo_madera_negro
        Me.Panel_Datps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_Datps.Controls.Add(Me.Cmb_Empleados)
        Me.Panel_Datps.Controls.Add(Me.Btn_NuevaOrden)
        Me.Panel_Datps.Controls.Add(Me.Lbl_NP)
        Me.Panel_Datps.Controls.Add(Me.Lbl_NU)
        Me.Panel_Datps.Controls.Add(Me.Lbl_NM)
        Me.Panel_Datps.Controls.Add(Me.Label4)
        Me.Panel_Datps.Controls.Add(Me.lbl_Dia)
        Me.Panel_Datps.Controls.Add(Me.Label2)
        Me.Panel_Datps.Controls.Add(Me.Label1)
        Me.Panel_Datps.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Datps.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Datps.Name = "Panel_Datps"
        Me.Panel_Datps.Size = New System.Drawing.Size(951, 37)
        Me.Panel_Datps.TabIndex = 6
        '
        'Cmb_Empleados
        '
        Me.Cmb_Empleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Empleados.FormattingEnabled = True
        Me.Cmb_Empleados.Location = New System.Drawing.Point(529, 6)
        Me.Cmb_Empleados.Name = "Cmb_Empleados"
        Me.Cmb_Empleados.Size = New System.Drawing.Size(114, 21)
        Me.Cmb_Empleados.TabIndex = 2
        '
        'Btn_NuevaOrden
        '
        Me.Btn_NuevaOrden.Location = New System.Drawing.Point(329, 0)
        Me.Btn_NuevaOrden.Name = "Btn_NuevaOrden"
        Me.Btn_NuevaOrden.Size = New System.Drawing.Size(80, 32)
        Me.Btn_NuevaOrden.TabIndex = 1
        Me.Btn_NuevaOrden.Text = "Nueva Orden"
        Me.Btn_NuevaOrden.UseVisualStyleBackColor = True
        Me.Btn_NuevaOrden.Visible = False
        '
        'Lbl_NP
        '
        Me.Lbl_NP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Lbl_NP.FormattingEnabled = True
        Me.Lbl_NP.Location = New System.Drawing.Point(226, 6)
        Me.Lbl_NP.Name = "Lbl_NP"
        Me.Lbl_NP.Size = New System.Drawing.Size(80, 21)
        Me.Lbl_NP.TabIndex = 0
        '
        'Lbl_NU
        '
        Me.Lbl_NU.AutoSize = True
        Me.Lbl_NU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NU.Location = New System.Drawing.Point(529, 8)
        Me.Lbl_NU.Name = "Lbl_NU"
        Me.Lbl_NU.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lbl_NU.Size = New System.Drawing.Size(12, 16)
        Me.Lbl_NU.TabIndex = 7
        Me.Lbl_NU.Text = "-"
        Me.Lbl_NU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Lbl_NU.Visible = False
        '
        'Lbl_NM
        '
        Me.Lbl_NM.AutoSize = True
        Me.Lbl_NM.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_NM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NM.ForeColor = System.Drawing.Color.White
        Me.Lbl_NM.Location = New System.Drawing.Point(86, 8)
        Me.Lbl_NM.Name = "Lbl_NM"
        Me.Lbl_NM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Lbl_NM.Size = New System.Drawing.Size(12, 16)
        Me.Lbl_NM.TabIndex = 5
        Me.Lbl_NM.Text = "-"
        Me.Lbl_NM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(451, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Empleado"
        '
        'lbl_Dia
        '
        Me.lbl_Dia.AutoSize = True
        Me.lbl_Dia.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Dia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Dia.ForeColor = System.Drawing.Color.White
        Me.lbl_Dia.Location = New System.Drawing.Point(764, 8)
        Me.lbl_Dia.Name = "lbl_Dia"
        Me.lbl_Dia.Size = New System.Drawing.Size(12, 16)
        Me.lbl_Dia.TabIndex = 2
        Me.lbl_Dia.Text = "-"
        Me.lbl_Dia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(150, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pedido #"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesa #"
        '
        'Frm_Pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 555)
        Me.Controls.Add(Me.Panel_DetalleProducto)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Pedidos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frm_Pedidos"
        Me.Panel_DetalleProducto.ResumeLayout(False)
        Me.Panel_DetPro.ResumeLayout(False)
        Me.Panel_DetPro.PerformLayout()
        CType(Me.Nud_Cantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Datps.ResumeLayout(False)
        Me.Panel_Datps.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tmr_Hora As System.Windows.Forms.Timer
    Friend WithEvents Panel_DetalleProducto As System.Windows.Forms.Panel
    Friend WithEvents Panel_Productos As System.Windows.Forms.Panel
    Friend WithEvents Panel_Categorias As System.Windows.Forms.Panel
    Friend WithEvents Panel_Datps As System.Windows.Forms.Panel
    Friend WithEvents Lbl_NU As System.Windows.Forms.Label
    Friend WithEvents Lbl_NM As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Dia As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel_DetPro As System.Windows.Forms.Panel
    Friend WithEvents Lst_Productos As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Txt_Subtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_PU As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Nud_Cantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents Btn_Eliminar As System.Windows.Forms.Button
    Friend WithEvents Btn_Imprimir As System.Windows.Forms.Button
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Txt_Observaciones As System.Windows.Forms.TextBox
    Friend WithEvents Btn_Salir As System.Windows.Forms.Button
    Friend WithEvents Btn_Facturar As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Agregar As System.Windows.Forms.Button
    Friend WithEvents lbl_Nombre2 As System.Windows.Forms.Label
    Friend WithEvents lbl_CodigoProducto As System.Windows.Forms.Label
    Friend WithEvents Lbl_NP As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Btn_NuevaOrden As System.Windows.Forms.Button
    Friend WithEvents Cmb_Empleados As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_Nombre As System.Windows.Forms.TextBox
End Class
