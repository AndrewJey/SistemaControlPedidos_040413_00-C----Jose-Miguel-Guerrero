Public Class Frm_Pedidos
    Dim Cargado As Boolean = False
    Private Sub Frm_Pedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        lbl_Nombre.Text = ""
        Txt_PU.Text = 0
        Txt_Observaciones.Text = ""
        Btn_NuevaOrden.Visible = False
        Lbl_NP.Enabled = True
        BuscarOrdenes()
    End Sub
    Private Sub Frm_Pedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Cargado = True
        Lbl_NU.Text = Usuario
        Cargar_Categorias_En_Pedidos()
        For Each Categoria As Label In Panel_Categorias.Controls
            AddHandler Categoria.Click, AddressOf Cargar_Productos_Categoria
        Next
        CargarEmpleadosCmb()
    End Sub
    Private Sub Tmr_Hora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Hora.Tick
        If Cargado = False Then Exit Sub
        lbl_Dia.Text = FormatDateTime(Now, DateFormat.GeneralDate)
    End Sub
    Private Sub Cargar_Productos_Categoria(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Cargado = False Then Exit Sub
        If sender.GetType.Name = "Label" Then
            Dim crtl As Label = CType(sender, Label)
            Cargar_Productos_En_Pedidos(crtl.Name)
        End If
        For Each Producto As PictureBox In Panel_Productos.Controls
            AddHandler Producto.Click, AddressOf Detalle_Producto
        Next
    End Sub
    Private Sub Detalle_Producto(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Cargado = False Then Exit Sub
        If sender.GetType.Name = "PictureBox" Then
            Dim crtl As PictureBox = CType(sender, PictureBox)
            For A = 0 To Productos.Length - 1
                If Productos(A).Codigo = crtl.Name Then
                    lbl_CodigoProducto.Text = Productos(A).Codigo
                    Txt_PU.Text = Productos(A).Precio
                    lbl_Nombre.Text = Productos(A).Nombre
                    Nud_Cantidad.Value = 1
                    Txt_Observaciones.Text = ""
                    For N = 0 To Orden.Length - 1
                        If Productos(A).Nombre = Orden(N).Producto And Orden(N).NumeroPedido = Lbl_NP.Text Then
                            Nud_Cantidad.Value = Orden(N).Cantidad
                            Txt_Observaciones.Text = Orden(N).Detalle
                        End If
                    Next
                    SubtotalProducto()
                End If
            Next
        End If
    End Sub
    Private Sub Btn_Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Agregar.Click
        If Cmb_Empleados.Text = "" Then MsgBox("Debe seleccionar un empleado para la orden", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
        If lbl_CodigoProducto.Text = "" Then Exit Sub
        If Cargado = False Then Exit Sub
        Dim Existe As Boolean = False
        For A = 1 To Orden.Count
            If Orden(A - 1).NumeroPedido = Me.Lbl_NP.Text And Orden(A - 1).Cod_Producto = lbl_CodigoProducto.Text Then
                Orden(A - 1).Detalle = Txt_Observaciones.Text
                Orden(A - 1).Cantidad = Nud_Cantidad.Value
                Orden(A - 1).Precio = Txt_PU.Text
                Orden(A - 1).Producto = lbl_Nombre.Text
                Orden(A - 1).Empleado = Cmb_Empleados.Text
                Existe = True
            End If
        Next
        If Existe = True Then Exit Sub
        ReDim Preserve Orden(Orden.Length)
        Orden(Orden.Count - 1).Detalle = Txt_Observaciones.Text
        Orden(Orden.Count - 1).Cantidad = Nud_Cantidad.Value
        Orden(Orden.Count - 1).Precio = Txt_PU.Text
        Orden(Orden.Count - 1).Producto = lbl_Nombre.Text
        Orden(Orden.Count - 1).Cod_Producto = lbl_CodigoProducto.Text
        Orden(Orden.Count - 1).NumeroPedido = Lbl_NP.Text
        Orden(Orden.Count - 1).Mesa = Lbl_NM.Text
        Orden(Orden.Count - 1).Empleado = Cmb_Empleados.Text
        Lst_Productos.Items.Add(lbl_Nombre.Text)
    End Sub
    Private Sub Lst_Productos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lst_Productos.SelectedIndexChanged
        Try
            If Cargado = False Then Exit Sub
            For A = 0 To Orden.Count - 1
                If Orden(A).NumeroPedido = Me.Lbl_NP.Text And Orden(A).Producto = Lst_Productos.Items(Lst_Productos.SelectedIndex).ToString Then
                    Txt_Observaciones.Text = Orden(A).Detalle
                    Nud_Cantidad.Value = Orden(A).Cantidad
                    Txt_PU.Text = Orden(A).Precio
                    lbl_Nombre.Text = Orden(A).Producto
                    lbl_CodigoProducto.Text = Orden(A).Cod_Producto
                    SubtotalProducto()
                    'For B = 0 To Productos.Length - 1
                    '    If Productos(B).Codigo = Orden(A).Cod_Producto Then
                    '        lbl_Nombre.Text = Productos(B).Nombre
                    '    End If
                    'Next
                End If
            Next
        Catch
            Err.Clear()
        End Try
    End Sub
    Private Sub SubtotalProducto()
        If Cargado = False Then Exit Sub
        Try
            Txt_Subtotal.Text = CDbl(Txt_PU.Text * Nud_Cantidad.Value)
        Catch
            Err.Clear()
            Txt_Subtotal.Text = 0
        End Try
    End Sub
    Private Sub Nud_Cantidad_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nud_Cantidad.ValueChanged
        SubtotalProducto()
    End Sub
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        Me.Close()
    End Sub
    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        If Lst_Productos.Items.Count = 0 Then MsgBox("La orden no pueden ser creada con cero productos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
        If Cmb_Empleados.Text = "" Then MsgBox("Debe seleccionar un empleado para la orden", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
        GuardarOrden(Lbl_NP.Text)
        If Lbl_NM.Text = "Llevar" Then
            Imprimir_Pedido_llevar(Lbl_NP.Text, Cmb_Empleados.Text)
        Else
            If Mid(Lbl_NM.Text, 1, 1) = "B" Then
                Imprimir_Pedido(Lbl_NP.Text, Lbl_NM.Text, Cargar_Salon(Lbl_NM.Text), Cmb_Empleados.Text)
            Else
                Imprimir_Pedido(Lbl_NP.Text, Lbl_NM.Text, Cargar_Salon("Mesa" & Lbl_NM.Text), Cmb_Empleados.Text)
            End If
        End If
        Me.Close()
    End Sub
    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        If Verificar_Orden(Lbl_NP.Text) = False Then Exit Sub
        If MsgBox("¿Esta seguro que desea cancelar esta orden?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CANCELANDO ORDEN # " & Lbl_NP.Text) = MsgBoxResult.No Then Exit Sub
        'Cancelar Orden
        Cancel_Orden(Lbl_NP.Text)
        Me.Close()
    End Sub
    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        Lst_Productos.Items.RemoveAt(Lst_Productos.SelectedIndex)
    End Sub
    Private Sub Btn_NuevaOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_NuevaOrden.Click
        Lbl_NP.Items.Clear()
        Lbl_NP.Items.Add(Obtener_NumPedido())
        Lbl_NP.SelectedIndex = 0
        Lbl_NP.Enabled = False
        Lst_Productos.Items.Clear()
        Txt_Observaciones.Text = ""
        Txt_PU.Text = ""
        Txt_Subtotal.Text = ""
        lbl_Nombre2.Text = ""
        Nud_Cantidad.Value = 1
    End Sub
    Private Sub Lbl_NP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lbl_NP.SelectedIndexChanged
        Lst_Productos.Items.Clear()
        For C = 0 To Orden.Length - 1
            If Orden(C).NumeroPedido = Lbl_NP.Text Then
                Lst_Productos.Items.Add(Orden(C).Producto)
            End If
        Next
        Txt_Observaciones.Text = ""
        Txt_PU.Text = ""
        Txt_Subtotal.Text = ""
        lbl_Nombre2.Text = ""
        Nud_Cantidad.Value = 1
    End Sub
    Private Sub Btn_Facturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Facturar.Click
        If Existe_Pedido(Lbl_NP.Text) = True Then
            Frm_Facturas.ShowDialog()
            Me.Close()
        End If
    End Sub
    Private Sub Btn_Imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Imprimir.Click
        If Cmb_Empleados.Text = "" Then MsgBox("Debe seleccionar un empleado para la orden", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
        If Existe_Pedido(Lbl_NP.Text) = True Then
            If Lbl_NM.Text = "Llevar" Then
                Imprimir_Pedido_llevar(Lbl_NP.Text, Cmb_Empleados.Text)
            Else
                If Mid(Lbl_NM.Text, 1, 1) = "B" Then
                    Imprimir_Pedido(Lbl_NP.Text, Lbl_NM.Text, Cargar_Salon(Lbl_NM.Text), Cmb_Empleados.Text)
                Else
                    Imprimir_Pedido(Lbl_NP.Text, Lbl_NM.Text, Cargar_Salon("Mesa" & Lbl_NM.Text), Cmb_Empleados.Text)
                End If
            End If
        End If
    End Sub
    Private Sub Txt_PU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PU.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub Txt_PU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_PU.TextChanged
        SubtotalProducto()
    End Sub
End Class

