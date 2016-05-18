Module Objetos_Publicos
    Public Structure D_Empresa
        Dim Cedula As String
        Dim Nombre As String
        Dim Telefono As String
        Dim Fax As String
        Dim Correo As String
        Dim Direccion As String
    End Structure
    Public Structure D_Categorias
        Dim Codigo As String
        Dim Nombre As String
    End Structure
    Public Structure D_Productos
        Dim Codigo As String
        Dim Nombre As String
        Dim Precio As Double
        Dim Categoria As String
    End Structure
    Public Structure D_Empleados
        Dim Codigo As String
        Dim Nombre As String
        Dim Apellidos As String
        Dim Cedula As String
        Dim Telefono As Integer
        Dim Direccion As String
    End Structure
    Public Structure D_Ordenes
        Dim NumeroPedido As String
        Dim Cantidad As String
        Dim Cod_Producto As String
        Dim Producto As String
        Dim Precio As Double
        Dim Detalle As String
        Dim Hora As DateTime
        Dim Fecha As DateTime
        Dim Empleado As String
        Dim Mesa As String
    End Structure
    Public Categorias() As D_Categorias
    Public Productos() As D_Productos
    Public Usuario As String = ""
    Public ID_Usuario As String
    Public Orden() As D_Ordenes
    Public Empleados() As D_Empleados
    Public MESAJEFUNCION As Integer = 1
    Public Empresa As D_Empresa
    Public Sub CargarDatosEmpresa()
        ObtenerDatosEmpresa()
        With Frm_Empresa
            Frm_Empresa.Txt_Cedula.Text = Empresa.Cedula
            Frm_Empresa.Txt_Nombre.Text = Empresa.Nombre
            Frm_Empresa.Txt_Telefono.Text = Empresa.Telefono
            Frm_Empresa.Txt_Fax.Text = Empresa.Fax
            Frm_Empresa.Txt_Correo.Text = Empresa.Correo
            Frm_Empresa.Txt_Direccion.Text = Empresa.Direccion
        End With
    End Sub
    Public Sub BuscarOrdenesBackground()
        Cargar_OrdenesBackground()
        On Error Resume Next
        For Each P As Object In Frm_Mesas.P_Mesas.Controls
            If P.GetType.ToString = "Panel" Then Continue For
            For A = 0 To Orden.Length - 1
                If P.Name = Orden(A).Mesa Then P.BackColor = Color.Gold : Exit For Else P.BackColor = Color.Transparent
            Next
        Next
    End Sub
    Public Sub BuscarOrdenes()
        Cargar_Ordenes()
        On Error Resume Next
        For Each P As Object In Frm_Mesas.P_Mesas.Controls
            If P.GetType.ToString = "Panel" Then Continue For
            For A = 0 To Orden.Length - 1
                If P.Name = Orden(A).Mesa Then P.BackColor = Color.Gold : Exit For Else P.BackColor = Color.Transparent
            Next
        Next
    End Sub
    Public Sub GuardarOrden(ByVal Numero As String)
        Dim Excluido As Boolean = True
        'Actualiza Orden Existente
        If Verificar_Orden(Numero) = True Then
            For A = 0 To Orden.Length - 1
                If Orden(A).NumeroPedido = "" And Orden(A).Cod_Producto = "" Then Continue For
                If Not Orden(A).NumeroPedido = Numero Then Continue For
                'Eliminar registros excluidos
                For B = 0 To Frm_Pedidos.Lst_Productos.Items.Count - 1
                    If Orden(A).Producto = Frm_Pedidos.Lst_Productos.Items(B).ToString Then
                        Excluido = False
                    End If
                Next
                If Excluido = True Then Eliminar_RegistroOrden(Numero, Orden(A).Cod_Producto) Else Excluido = True
                'Actualizar registros existentes
                If Verificar_ArticuloOrden(Numero, Orden(A).Cod_Producto) = True Then _
                    Actualizar_Orden(Numero, Orden(A).Producto, Orden(A).Cod_Producto, Orden(A).Cantidad, Orden(A).Precio, Orden(A).Detalle)
                'Agregar registros nuevos
                If Not (Orden(A).NumeroPedido = "" And Orden(A).Cod_Producto = "") Then _
                    Insertar_Orden(Numero, Orden(A).Producto, Orden(A).Cod_Producto, Orden(A).Cantidad, Orden(A).Precio, Orden(A).Detalle)
            Next
            'For L = 0 To Orden.Length - 1
            '    If Not Orden(L).NumeroPedido = "" And Orden(L).Cod_Producto = "" Then _
            '        Insertar_Orden(Numero, Orden(L).Producto, Orden(L).Cod_Producto, Orden(L).Cantidad, Orden(L).Precio, Orden(L).Detalle)
            'Next
            'Crea una nueva orden
        ElseIf Verificar_Orden(Numero) = False Then
            For A = 0 To Orden.Length - 1
                If Orden(A).NumeroPedido = "" And Orden(A).Cod_Producto = "" Then Continue For
                If Not Orden(A).NumeroPedido = Numero Then Continue For
                'Crear Nueva Orden
                If Orden(A).Mesa = "Llevar" Then Nueva_Orden(Numero, Orden(A).Mesa, Orden(A).Empleado) : Exit For
                If (Orden(A).Mesa = "Barra1" Or Orden(A).Mesa = "Barra2" Or Orden(A).Mesa = "Barra3") Then Nueva_Orden(Numero, Orden(A).Mesa, Orden(A).Empleado) : Exit For
                Nueva_Orden(Numero, "Mesa" & Orden(A).Mesa, Orden(A).Empleado) : Exit For
            Next
            For A = 0 To Orden.Length - 1
                If Orden(A).NumeroPedido = "" And Orden(A).Cod_Producto = "" Then Continue For
                If Not Orden(A).NumeroPedido = Numero Then Continue For
                'Agregar registros nuevos
                Insertar_Orden(Numero, Orden(A).Producto, Orden(A).Cod_Producto, Orden(A).Cantidad, Orden(A).Precio, Orden(A).Detalle)
            Next
        End If
    End Sub
End Module
