Public Class Frm_Facturas
    Dim ped As Integer
    Private Sub Cmb_Pedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_Pedidos.Click
        Cargar_Pedidos_Fractura()
    End Sub

    Private Sub Cmb_Pedidos_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_Pedidos.SelectedValueChanged
        If Factura = True Then
            If lista = True Then
                Try
                    Cargar_Pedidos_Fractura_Lista(Cmb_Pedidos.Text)
                    Calcular_Factura_Imprimir()
                    ped = Cmb_Pedidos.Text
                Catch ex As Exception
                    Me.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub Frm_Facturas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Factura = True Then
            Cmb_Pedidos.Visible = True
            Lbl_Pedido.Visible = True
            Cargar_Pedidos_Fractura()
            Try
                Cmb_Pedidos.SelectedIndex = 0
            Catch ex As Exception
                MsgBox("¡No existen pedidos actualmente!", MsgBoxStyle.Exclamation, "Facturar")
                Me.Close()
                Exit Sub
            End Try
            Cmb_Pedidos_SelectedValueChanged(sender, e)
            Calcular_Factura()
            Cmb_Empleado_Click(sender, e)
            Cmb_Empleado.SelectedIndex = 0
            Cmb_Cliente.SelectedIndex = 0
        Else
            ped = Frm_Pedidos.Lbl_NP.Text
            Cmb_Pedidos.Visible = False
            Lbl_Pedido.Visible = False
            Cargar_Pedidos_Fractura_Lista(Frm_Pedidos.Lbl_NP.Text)
            Calcular_Factura_Imprimir()
            Cmb_Empleado_Click(sender, e)
            Cmb_Empleado.SelectedIndex = 0
            Cmb_Cliente.SelectedIndex = 0
        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        If MsgBox("¿Esta seguro que desea salir?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Facturar") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Btn_Incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Incluir.Click
        If LB_Pedido.SelectedIndex >= 0 Then
            Dim cantidad, existe, lugar As Integer
            Dim vec(), vec2(), producto As String
            cantidad = LB_Facturar.Items.Count
            producto = LB_Pedido.Items(LB_Pedido.SelectedIndex)
            vec = producto.Split("-")
            For a = 0 To cantidad - 1
                producto = LB_Facturar.Items(a)
                vec2 = producto.Split("-")
                If vec(1) = vec2(1) Then
                    existe = 1
                    lugar = a
                    producto = LB_Pedido.Items(LB_Pedido.SelectedIndex)
                    Exit For
                Else
                    existe = 0
                End If
            Next
            If existe = 1 Then
                vec = producto.Split("-")
                If vec(0) = 1 Then
                    LB_Pedido.Items.RemoveAt(LB_Pedido.SelectedIndex)
                    producto = LB_Facturar.Items(lugar)
                    vec = producto.Split("-")
                    LB_Facturar.Items(lugar) = vec(0) + 1 & " -" & vec(1)
                Else
                    LB_Pedido.Items(LB_Pedido.SelectedIndex) = vec(0) - 1 & " -" & vec(1)
                    producto = LB_Facturar.Items(lugar)
                    vec = producto.Split("-")
                    LB_Facturar.Items(lugar) = vec(0) + 1 & " -" & vec(1)
                End If
            Else
                producto = LB_Pedido.Items(LB_Pedido.SelectedIndex)
                vec = producto.Split("-")
                If vec(0) = 1 Then
                    LB_Facturar.Items.Add(LB_Pedido.Items(LB_Pedido.SelectedIndex))
                    LB_Pedido.Items.RemoveAt(LB_Pedido.SelectedIndex)
                Else
                    LB_Pedido.Items(LB_Pedido.SelectedIndex) = vec(0) - 1 & " -" & vec(1)
                    LB_Facturar.Items.Add("1 " & "-" & vec(1))
                End If
            End If
            Calcular_Factura()
        Else
            MsgBox("¡Debe tener un producto selecionado!", MsgBoxStyle.Exclamation, "Facturar")
        End If
    End Sub

    Private Sub Btn_Todos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Todos.Click
        If LB_Pedido.Items.Count > 0 Then
            LB_Facturar.Items.AddRange(LB_Pedido.Items)
            LB_Pedido.Items.Clear()
            Calcular_Factura()
        End If
    End Sub

    Private Sub Btn_Excluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Excluir.Click
        If LB_Facturar.SelectedIndex >= 0 Then
            Dim cantidad, existe, lugar As Integer
            Dim vec(), vec2(), producto As String
            cantidad = LB_Pedido.Items.Count
            producto = LB_Facturar.Items(LB_Facturar.SelectedIndex)
            vec = producto.Split("-")
            For a = 0 To cantidad - 1
                producto = LB_Pedido.Items(a)
                vec2 = producto.Split("-")
                If vec(1) = vec2(1) Then
                    existe = 1
                    lugar = a
                    producto = LB_Facturar.Items(LB_Facturar.SelectedIndex)
                    Exit For
                Else
                    existe = 0
                End If
            Next
            If existe = 1 Then
                vec = producto.Split("-")
                If vec(0) = 1 Then
                    LB_Facturar.Items.RemoveAt(LB_Facturar.SelectedIndex)
                    producto = LB_Pedido.Items(lugar)
                    vec = producto.Split("-")
                    LB_Pedido.Items(lugar) = vec(0) + 1 & " -" & vec(1)
                Else
                    LB_Facturar.Items(LB_Facturar.SelectedIndex) = vec(0) - 1 & " -" & vec(1)
                    producto = LB_Pedido.Items(lugar)
                    vec = producto.Split("-")
                    LB_Pedido.Items(lugar) = vec(0) + 1 & " -" & vec(1)
                End If
            Else
                producto = LB_Facturar.Items(LB_Facturar.SelectedIndex)
                vec = producto.Split("-")
                If vec(0) = 1 Then
                    LB_Pedido.Items.Add(LB_Facturar.Items(LB_Facturar.SelectedIndex))
                    LB_Facturar.Items.RemoveAt(LB_Facturar.SelectedIndex)
                Else
                    LB_Facturar.Items(LB_Facturar.SelectedIndex) = vec(0) - 1 & " -" & vec(1)
                    LB_Pedido.Items.Add("1 " & "-" & vec(1))
                End If
            End If
            Calcular_Factura()
        Else
            MsgBox("¡Debe tener un producto selecionado!", MsgBoxStyle.Exclamation, "Facturar")
        End If
    End Sub

    Private Sub Btn_Facturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Facturar.Click
        If LB_Facturar.Items.Count > 0 Then
            If LB_Pedido.Items.Count = 0 Then
                Facturar()
                If Factura = True Then
                    MESAJEFUNCION = 0
                    Modificar_BD("update Pedidos set Cancelado=True where ped_numero=" & Cmb_Pedidos.Text & "")
                Else
                    MESAJEFUNCION = 0
                    Modificar_BD("update Pedidos set Cancelado=True where ped_numero=" & Frm_Pedidos.Lbl_NP.Text & "")
                End If
                Imprimir_Factura(Obtener_Registro_Fractura_imprimir, Cmb_Cliente.Text, Cmb_Empleado.Text, Lbl_Subtotal.Text, ND_descuento.Value, Lbl_Total.Text, ped)
                If Factura = True Then
                    Cargar_Pedidos_Fractura()
                    Try
                        Cmb_Pedidos.SelectedIndex = 0
                    Catch
                        Err.Clear()
                        Me.Close()
                    End Try
                    Cmb_Pedidos_SelectedValueChanged(sender, e)
                Else
                    Me.Close()
                End If
                Notificacion("¡Base de Datos Actualizada!", "¡El pedido ha sido facturado correctamente!", 1, 3000)
                If Factura = False Then
                    Me.Close()
                End If
            Else
                LB_Facturar.Items.Clear()
            End If
        End If
    End Sub

    Private Sub ND_descuento_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ND_descuento.ValueChanged
        If Lbl_Subtotal.Text >= 1 Then
            Lbl_Total.Text = Lbl_Subtotal.Text - (Lbl_Subtotal.Text * ND_descuento.Value / 100)
        End If
    End Sub

    Private Sub Cmb_Empleado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmb_Empleado.Click
        Cargar_Empleado_Fractura()
    End Sub
End Class