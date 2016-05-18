'Option Explicit On
'Option Strict On
Imports System.IO
Public Class Frm_Mesas
    Private SegundoPlano As Threading.Thread
    Private Mover As Boolean = False
    Private p_Mouse As Point = Nothing
    Private Cargado As Boolean = False
    Private Sub Frm_Mesas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.Cursor = Cursors.Hand
        Mover = True
        ' guarda rl el x e y donde se hizo clic  
        p_Mouse.X = e.X
        p_Mouse.Y = e.Y
    End Sub
    Private Sub Frm_Mesas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Mover Then
            ' referencia al control  
            'Dim unControl As Control = CType(sender, Control)
            ' cambiar las coordenadas  
            Dim p1 As Point = Me.PointToScreen(e.Location)
            Dim p2 As Point = Me.PointToClient(p1)
            ' asignar el left y el top - laposición del mouse donde se hizo clic  
            Me.Left = p1.X - p_Mouse.X
            Me.Top = p1.Y - p_Mouse.Y
        End If
    End Sub
    Private Sub Frm_Mesas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        ' cambiar el  cursors  
        Me.Cursor = Cursors.Default
        ' flag para mover el control  
        Mover = False
    End Sub
    Private Sub Frm_Mesas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Cargado = True
        AsignarProcedimiento()
        OtraNumeracion()
        BuscarOrdenes()
        ObtenerTodosProductos()
        ObtenerDatosEmpresa()
    End Sub
    Private Sub CrearReloj()
        While My.Application.OpenForms.Count > 0
            CheckBD()
            Threading.Thread.Sleep(1000)
        End While
    End Sub
    Private Sub CheckBD()
        If (Activado(Frm_Facturas.Name) = True) Or (Activado(Frm_Pedidos.Name) = True) Or (Activado(Frm_Productos.Name) = True) Then Exit Sub
        'Refrescar Estructuras
        BuscarOrdenesBackground()
    End Sub
    Private Function Activado(ByVal nombreForm As String) As Boolean
        Dim frm As Form
        Dim stat As Boolean
        stat = False
        For Each frm In My.Application.OpenForms
            If LCase(frm.Name) = LCase(nombreForm) Then stat = True
        Next frm
        Activado = stat
    End Function
    Private Sub OtraNumeracion()
        Try
            '1A
            AddHandler Mesa1A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler LblMesa1A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler PctMesa1A.Click, AddressOf BuscarPedidoBarraLlevar
            '2A
            AddHandler Mesa2A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler LblMesa2A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler PctMesa2A.Click, AddressOf BuscarPedidoBarraLlevar
            '3A
            AddHandler Mesa3A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler LblMesa3A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler PctMesa3A.Click, AddressOf BuscarPedidoBarraLlevar
            '4A
            AddHandler Mesa4A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler LblMesa4A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler PctMesa4A.Click, AddressOf BuscarPedidoBarraLlevar
            '5A
            AddHandler Mesa5A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler LblMesa5A.Click, AddressOf BuscarPedidoBarraLlevar
            AddHandler PctMesa5A.Click, AddressOf BuscarPedidoBarraLlevar
        Catch
            Err.Clear()
            Notificacion("ERROR AL ASGINAR PROCESO", "Ocurrio un error al asignar el proceso a las mesas.", 3, 5000)
        End Try
    End Sub
    Private Sub AsignarProcedimiento()
        If Cargado = False Then Exit Sub
        For Each Objeto As Control In Me.P_Mesas.Controls
            'Asignar Evento a la Barra de Llevar
            If Objeto.Name = "Llevar" Then
                AddHandler Objeto.Click, AddressOf BuscarPedido
                For Each Controll As Control In Objeto.Controls
                    If Controll.Name = "LblLlevar" Then
                        AddHandler Controll.Click, AddressOf BuscarPedidoBarraLlevar
                    End If
                    If Controll.Name = "PctLlevar" Then
                        AddHandler Controll.Click, AddressOf BuscarPedidoBarraLlevar
                    End If
                Next
            End If
            For C = 1 To 20
                'Asignar Evento a las mesas
                If Objeto.Name = "Mesa" & C Then
                    AddHandler Objeto.Click, AddressOf BuscarPedido
                    For Each Controll As Control In Objeto.Controls
                        If Controll.Name = "LblMesa" & C Then
                            AddHandler Controll.Click, AddressOf BuscarPedido
                        End If
                        If Controll.Name = "PctMesa" & C Then
                            AddHandler Controll.Click, AddressOf BuscarPedido
                        End If
                    Next
                End If
                'Asignar Evento a las Barras
                If Objeto.Name = "Barra" & C Then
                    AddHandler Objeto.Click, AddressOf BuscarPedidoBarraLlevar
                    For Each Controll As Control In Objeto.Controls
                        If Controll.Name = "LblBarra" & C Then
                            AddHandler Controll.Click, AddressOf BuscarPedidoBarraLlevar
                        End If
                        If Controll.Name = "PctBarra" & C Then
                            AddHandler Controll.Click, AddressOf BuscarPedidoBarraLlevar
                        End If
                    Next
                End If
            Next
        Next
    End Sub
    Private Sub BuscarPedidoBarraLlevar(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AhiEsta As Boolean = False
        Frm_Pedidos.Lbl_NP.Items.Clear()
        Dim PN As Integer = Obtener_NumPedido()
        Dim Numero As String = ""
        Dim Ejecutado As Boolean = False
        If sender.GetType.Name = "Panel" Then
            Dim crtl As Panel = CType(sender, Panel)
            For A = 1 To crtl.Name.Length
                If IsNumeric(Mid(crtl.Name, A, A)) = True Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    If (crtl.Name = "PctMesa1A") Or (crtl.Name = "PctMesa2A") Or (crtl.Name = "PctMesa3A") Or (crtl.Name = "PctMesa4A") Or (crtl.Name = "PctMesa5A") Or _
                     (crtl.Name = "LblMesa1A") Or (crtl.Name = "LblMesa2A") Or (crtl.Name = "LblMesa3A") Or (crtl.Name = "LblMesa4A") Or (crtl.Name = "LblMesa5A") Or _
                     (crtl.Name = "Mesa1A") Or (crtl.Name = "Mesa2A") Or (crtl.Name = "Mesa3A") Or (crtl.Name = "Mesa4A") Or (crtl.Name = "Mesa5A") Then _
                         Frm_Pedidos.Lbl_NM.Text = crtl.Name.Substring(crtl.Name.Length - 2, 2) Else Frm_Pedidos.Lbl_NM.Text = crtl.Parent.Name
                    If crtl.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If Orden(B).Mesa = crtl.Name Then
                                For F = 0 To Frm_Pedidos.Lbl_NP.Items.Count - 1
                                    If Frm_Pedidos.Lbl_NP.Items(F).ToString = Orden(B).NumeroPedido Then
                                        AhiEsta = True
                                        Try
                                            Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                        Catch
                                            Err.Clear()
                                        End Try
                                    Else
                                        AhiEsta = False
                                    End If
                                Next
                                If AhiEsta = False Then
                                    Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                    Try
                                        Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                                    Catch
                                        Err.Clear()
                                    End Try
                                End If
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                            End If
                        Next
                    ElseIf crtl.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.Btn_NuevaOrden.Visible = True
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                ElseIf IsNumeric(Mid(crtl.Name, A, A)) = False And A = crtl.Name.Length Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    If (crtl.Name = "PctMesa1A") Or (crtl.Name = "PctMesa2A") Or (crtl.Name = "PctMesa3A") Or (crtl.Name = "PctMesa4A") Or (crtl.Name = "PctMesa5A") Or _
                    (crtl.Name = "LblMesa1A") Or (crtl.Name = "LblMesa2A") Or (crtl.Name = "LblMesa3A") Or (crtl.Name = "LblMesa4A") Or (crtl.Name = "LblMesa5A") Or _
                    (crtl.Name = "Mesa1A") Or (crtl.Name = "Mesa2A") Or (crtl.Name = "Mesa3A") Or (crtl.Name = "Mesa4A") Or (crtl.Name = "Mesa5A") Then _
                        Frm_Pedidos.Lbl_NM.Text = crtl.Name.Substring(crtl.Name.Length - 2, 2) Else Frm_Pedidos.Lbl_NM.Text = crtl.Parent.Name
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If Orden(B).Mesa = crtl.Name Then
                                For F = 0 To Frm_Pedidos.Lbl_NP.Items.Count - 1
                                    If Frm_Pedidos.Lbl_NP.Items(F).ToString = Orden(B).NumeroPedido Then
                                        AhiEsta = True
                                        Try
                                            Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                        Catch
                                            Err.Clear()
                                        End Try
                                    Else
                                        AhiEsta = False
                                    End If
                                Next
                                If AhiEsta = False Then
                                    Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                    Try
                                        Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                                    Catch
                                        Err.Clear()
                                    End Try
                                End If
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                            End If
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.Btn_NuevaOrden.Visible = True
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                End If
            Next
        End If
        If sender.GetType.Name = "PictureBox" Then
            Dim crtl As PictureBox = CType(sender, PictureBox)
            For A = 1 To crtl.Name.Length
                If IsNumeric(Mid(crtl.Name, A, A)) = True Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    If (crtl.Name = "PctMesa1A") Or (crtl.Name = "PctMesa2A") Or (crtl.Name = "PctMesa3A") Or (crtl.Name = "PctMesa4A") Or (crtl.Name = "PctMesa5A") Or _
                    (crtl.Name = "LblMesa1A") Or (crtl.Name = "LblMesa2A") Or (crtl.Name = "LblMesa3A") Or (crtl.Name = "LblMesa4A") Or (crtl.Name = "LblMesa5A") Or _
                    (crtl.Name = "Mesa1A") Or (crtl.Name = "Mesa2A") Or (crtl.Name = "Mesa3A") Or (crtl.Name = "Mesa4A") Or (crtl.Name = "Mesa5A") Then _
                        Frm_Pedidos.Lbl_NM.Text = crtl.Name.Substring(crtl.Name.Length - 2, 2) Else Frm_Pedidos.Lbl_NM.Text = crtl.Parent.Name
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If "Pct" & Orden(B).Mesa = crtl.Name Then
                                For F = 0 To Frm_Pedidos.Lbl_NP.Items.Count - 1
                                    If Frm_Pedidos.Lbl_NP.Items(F).ToString = Orden(B).NumeroPedido Then
                                        AhiEsta = True
                                        Try
                                            Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                        Catch
                                            Err.Clear()
                                        End Try
                                    Else
                                        AhiEsta = False
                                    End If
                                Next
                                If AhiEsta = False Then
                                    Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                    Try
                                        Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                                    Catch
                                        Err.Clear()
                                    End Try
                                End If
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                            End If
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.Btn_NuevaOrden.Visible = True
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                ElseIf IsNumeric(Mid(crtl.Name, A, A)) = False And A = crtl.Name.Length Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    If (crtl.Name = "PctMesa1A") Or (crtl.Name = "PctMesa2A") Or (crtl.Name = "PctMesa3A") Or (crtl.Name = "PctMesa4A") Or (crtl.Name = "PctMesa5A") Or _
                    (crtl.Name = "LblMesa1A") Or (crtl.Name = "LblMesa2A") Or (crtl.Name = "LblMesa3A") Or (crtl.Name = "LblMesa4A") Or (crtl.Name = "LblMesa5A") Or _
                    (crtl.Name = "Mesa1A") Or (crtl.Name = "Mesa2A") Or (crtl.Name = "Mesa3A") Or (crtl.Name = "Mesa4A") Or (crtl.Name = "Mesa5A") Then _
                        Frm_Pedidos.Lbl_NM.Text = crtl.Name.Substring(crtl.Name.Length - 2, 2) Else Frm_Pedidos.Lbl_NM.Text = crtl.Parent.Name
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If "Pct" & Orden(B).Mesa = crtl.Name Then
                                For F = 0 To Frm_Pedidos.Lbl_NP.Items.Count - 1
                                    If Frm_Pedidos.Lbl_NP.Items(F).ToString = Orden(B).NumeroPedido Then
                                        AhiEsta = True
                                        Try
                                            Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                        Catch
                                            Err.Clear()
                                        End Try
                                    Else
                                        AhiEsta = False
                                    End If
                                Next
                                If AhiEsta = False Then
                                    Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                    Try
                                        Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                                    Catch
                                        Err.Clear()
                                    End Try
                                End If
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                            End If
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.Btn_NuevaOrden.Visible = True
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                End If
            Next
        End If
        If sender.GetType.Name = "Label" Then
            Dim crtl As Label = CType(sender, Label)
            For A = 1 To crtl.Name.Length
                If IsNumeric(Mid(crtl.Name, A, A)) = True Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    If (crtl.Name = "PctMesa1A") Or (crtl.Name = "PctMesa2A") Or (crtl.Name = "PctMesa3A") Or (crtl.Name = "PctMesa4A") Or (crtl.Name = "PctMesa5A") Or _
                    (crtl.Name = "LblMesa1A") Or (crtl.Name = "LblMesa2A") Or (crtl.Name = "LblMesa3A") Or (crtl.Name = "LblMesa4A") Or (crtl.Name = "LblMesa5A") Or _
                    (crtl.Name = "Mesa1A") Or (crtl.Name = "Mesa2A") Or (crtl.Name = "Mesa3A") Or (crtl.Name = "Mesa4A") Or (crtl.Name = "Mesa5A") Then _
                        Frm_Pedidos.Lbl_NM.Text = crtl.Name.Substring(crtl.Name.Length - 2, 2) Else Frm_Pedidos.Lbl_NM.Text = crtl.Parent.Name
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            For F = 0 To Frm_Pedidos.Lbl_NP.Items.Count - 1
                                If Frm_Pedidos.Lbl_NP.Items(F).ToString = Orden(B).NumeroPedido Then
                                    AhiEsta = True
                                    Try
                                        Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                    Catch
                                        Err.Clear()
                                    End Try
                                Else
                                    AhiEsta = False
                                End If
                            Next
                            If AhiEsta = False Then
                                Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                Try
                                    Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                                Catch
                                    Err.Clear()
                                End Try
                            End If
                            Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.Btn_NuevaOrden.Visible = True
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                ElseIf IsNumeric(Mid(crtl.Name, A, A)) = False And A = crtl.Name.Length Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    If (crtl.Name = "PctMesa1A") Or (crtl.Name = "PctMesa2A") Or (crtl.Name = "PctMesa3A") Or (crtl.Name = "PctMesa4A") Or (crtl.Name = "PctMesa5A") Or _
                    (crtl.Name = "LblMesa1A") Or (crtl.Name = "LblMesa2A") Or (crtl.Name = "LblMesa3A") Or (crtl.Name = "LblMesa4A") Or (crtl.Name = "LblMesa5A") Or _
                    (crtl.Name = "Mesa1A") Or (crtl.Name = "Mesa2A") Or (crtl.Name = "Mesa3A") Or (crtl.Name = "Mesa4A") Or (crtl.Name = "Mesa5A") Then _
                        Frm_Pedidos.Lbl_NM.Text = crtl.Name.Substring(crtl.Name.Length - 2, 2) Else Frm_Pedidos.Lbl_NM.Text = crtl.Parent.Name
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            For F = 0 To Frm_Pedidos.Lbl_NP.Items.Count - 1
                                If Frm_Pedidos.Lbl_NP.Items(F).ToString = Orden(B).NumeroPedido Then
                                    AhiEsta = True
                                    Try
                                        Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                    Catch
                                        Err.Clear()
                                    End Try
                                Else
                                    AhiEsta = False
                                End If
                            Next
                            If AhiEsta = False Then
                                Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                Try
                                    Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                                Catch
                                    Err.Clear()
                                End Try
                            End If
                            Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.Btn_NuevaOrden.Visible = True
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                End If
            Next
        End If
    End Sub
    Private Sub BuscarPedido(ByVal sender As Object, ByVal e As System.EventArgs)
        Frm_Pedidos.Lbl_NP.Items.Clear()
        Dim PN As Integer = Obtener_NumPedido()
        Dim Numero As String = ""
        Dim Ejecutado As Boolean = False
        If sender.GetType.Name = "Panel" Then
            Dim crtl As Panel = CType(sender, Panel)
            For A = 1 To crtl.Name.Length
                If IsNumeric(Mid(crtl.Name, A, A)) = True Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    Frm_Pedidos.Lbl_NM.Text = Numero
                    If crtl.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If Orden(B).Mesa = crtl.Name Then
                                Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                                Try
                                    Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                Catch
                                    Err.Clear()
                                End Try
                            End If
                        Next
                    ElseIf crtl.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                End If
            Next
        End If
        If sender.GetType.Name = "PictureBox" Then
            Dim crtl As PictureBox = CType(sender, PictureBox)
            For A = 1 To crtl.Name.Length
                If IsNumeric(Mid(crtl.Name, A, A)) = True Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    Frm_Pedidos.Lbl_NM.Text = Numero
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If "Pct" & Orden(B).Mesa = crtl.Name Then
                                Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                                Try
                                    Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                Catch
                                    Err.Clear()
                                End Try
                            End If
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                End If
            Next
        End If
        If sender.GetType.Name = "Label" Then
            Dim crtl As Label = CType(sender, Label)
            For A = 1 To crtl.Name.Length
                If IsNumeric(Mid(crtl.Name, A, A)) = True Then
                    If Ejecutado = True Then Continue For
                    Numero &= Mid(crtl.Name, A, A)
                    Frm_Pedidos.Lbl_NM.Text = Numero
                    If crtl.Parent.BackColor = Color.Gold Then
                        For B = 0 To Orden.Length - 1
                            If "Lbl" & Orden(B).Mesa = crtl.Name Then
                                Frm_Pedidos.Lbl_NP.Items.Add(Orden(B).NumeroPedido)
                                Frm_Pedidos.Lbl_NP.Text = Orden(B).NumeroPedido
                                Try
                                    Frm_Pedidos.Cmb_Empleados.Text = Orden(B).Empleado
                                Catch
                                    Err.Clear()
                                End Try
                            End If
                        Next
                    ElseIf crtl.Parent.BackColor = Color.Transparent Then
                        Frm_Pedidos.Lbl_NP.Items.Add(PN)
                        Frm_Pedidos.Lbl_NP.Text = PN
                        Try
                            Frm_Pedidos.Cmb_Empleados.SelectedIndex = 0
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Frm_Pedidos.Nud_Cantidad.Value = 1
                    Frm_Pedidos.Txt_Subtotal.Text = ""
                    Frm_Pedidos.Txt_PU.Text = ""
                    Frm_Pedidos.Lst_Productos.Items.Clear()
                    For C = 0 To Orden.Length - 1
                        If Orden(C).NumeroPedido = Frm_Pedidos.Lbl_NP.Text Then
                            Frm_Pedidos.Lst_Productos.Items.Add(Orden(C).Producto)
                        End If
                    Next
                    Frm_Pedidos.ShowDialog()
                    Ejecutado = True
                End If
            Next
        End If
    End Sub
    Private Sub Btn_Productos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Productos.Click
        Frm_Productos.ShowDialog()
    End Sub
    Private Sub REDIRECCIONARBD()
        Dim WScript As Object
        WScript = CreateObject("WScript.Shell")
        'obtenemos la ruta del destino de Mis Documentos 
        Dim Dialogo As New System.Windows.Forms.FolderBrowserDialog
        '(WScript.SpecialFolders("NetHood"))
        WScript = Nothing
        If Dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ARCHIVO As New StreamWriter(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg")
            ARCHIVO.WriteLine(Dialogo.SelectedPath)
            ARCHIVO.Close()
            Application.Restart()
        End If
    End Sub
    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        REDIRECCIONARBD()
    End Sub
    Private Sub Btn_Facturar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Facturar.Click
        Factura = True
        Frm_Facturas.ShowDialog()
    End Sub
    Private Sub Btn_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Usuarios.Click
        Frm_Usuarios.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Application.Exit()
    End Sub
    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        LoginForm.Show()
        Me.Close()
    End Sub
    Private Sub EmpleadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpleadosToolStripMenuItem.Click
        Frm_Empleados.ShowDialog()
    End Sub
    Private Sub Tmr_Refresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Refresh.Tick
        CheckBD()
    End Sub
    Private Sub MiEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MiEmpresaToolStripMenuItem.Click
        Frm_Empresa.ShowDialog()
    End Sub
End Class
