Imports System.Text
Imports System.IO
Module Base_de_Datos
    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Int32, ByVal fRequest As Int32, ByVal lpszDriver As String, ByVal lpszAttributes As StringBuilder) As Int32
    Private Cls_Conexion As Boolean
    Private Cls_Espacio_Trabajo As Odbc.OdbcConnection
    Private Cls_Ejecutar_comando As Odbc.OdbcCommand
    Private Cls_Leer_Consulta As Odbc.OdbcDataReader
    Private Error_BD As Boolean = False
    Public lista As Boolean = True
    Public Factura As Boolean
    Public total As Integer
    Private Cls_Conexion2 As Boolean
    Private Cls_Espacio_Trabajo2 As Odbc.OdbcConnection
    Private Cls_Ejecutar_comando2 As Odbc.OdbcCommand
    Private Cls_Leer_Consulta2 As Odbc.OdbcDataReader
    Private Sub Conectar2()
        Try
            Cls_Espacio_Trabajo2 = New Odbc.OdbcConnection("DSN=SCPBD;UID=;Pwd=;")
            Cls_Espacio_Trabajo2.Open()
            Cls_Espacio_Trabajo2.Close()
        Catch
            Err.Clear()
            Notificacion("¡Error de Comunicacion!", "¡Ha ocurrido un error al intentar cominicarse con la base de datos!" & _
                                 Chr(13) & _
                                 "Consulte un administrador.", 1, 3000)
            Error_BD = True
        End Try
    End Sub
    Private Sub Conectar()
        Try
            Cls_Espacio_Trabajo = New Odbc.OdbcConnection("DSN=SCPBD;UID=;Pwd=;")
            Cls_Espacio_Trabajo.Open()
            Cls_Espacio_Trabajo.Close()
        Catch
            Err.Clear()
            Notificacion("¡Error de Comunicacion!", "¡Ha ocurrido un error al intentar cominicarse con la base de datos!" & _
                                 Chr(13) & _
                                 "Consulte un administrador.", 1, 3000)
            Error_BD = True
        End Try
    End Sub
#Region "FUNCION PARA CREAR UN DSN"
    Public Function CREAR_DSN(ByVal TIPODSN As Integer, ByVal Direccion As String) As Boolean
        Dim DSN_CREADO As Boolean = False
        Dim sDriver As String  ' Nombre del controlador
        sDriver = "Microsoft Access Driver (*.mdb, *.accdb)"
        '------------------------------------------------------------
        Dim attributes As StringBuilder = New StringBuilder
        attributes.Append("DSN=SCPBD" & New Char)
        attributes.Append("Description=BASE DE DATOS DEL SISTEMA CONTROL PEDIDOS" & New Char)
        attributes.Append("Dbq=" & Direccion & "BD_Pollo.accdb;Uid=;Pwd=;")
        Dim dl As Int32 = SQLConfigDataSource(0, TIPODSN, sDriver, attributes)
        If (dl = 1) Then
            'MsgBox("El DSN se ha creado correctamente....", MsgBoxStyle.Information, "ENLACE CORRECTO...")
            CREAR_DSN = True
        Else
            MsgBox("su programa no podra trabajar bien hasta crear el enlace a: CONTROL_ORNAMENTALES", MsgBoxStyle.Critical, "No se creo el DSN")
            CREAR_DSN = False
        End If
        Return CREAR_DSN
    End Function
#End Region
    Public Sub ObtenerDatosEmpresa()
        With Frm_Pedidos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Sub
            Cls_Espacio_Trabajo.Open()
            Dim SQL As String = "SELECT * FROM Empresa"
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            Try
                While Cls_Leer_Consulta.Read
                    Empresa.Cedula = Cls_Leer_Consulta(0).ToString
                    Empresa.Nombre = Cls_Leer_Consulta(1).ToString
                    Empresa.Telefono = Cls_Leer_Consulta(2).ToString
                    Empresa.Fax = Cls_Leer_Consulta(3).ToString
                    Empresa.Correo = Cls_Leer_Consulta(4).ToString
                    Empresa.Direccion = Cls_Leer_Consulta(5).ToString
                End While
            Catch ex As Exception
                Err.Clear()
                Notificacion("ERROR", "Ocurrio un error al intentar cargar los datos de la empresa", 5000, 3)
            End Try
        End With
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub CargarEmpleadosCmb()
        With Frm_Pedidos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Sub
            Cls_Espacio_Trabajo.Open()
            Dim SQL As String = "Select emp_nombre from Empleados"
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            Try
                .Cmb_Empleados.Items.Clear()
                While Cls_Leer_Consulta.Read
                    .Cmb_Empleados.Items.Add(Cls_Leer_Consulta(0).ToString)
                End While
            Catch ex As Exception
                Err.Clear()
            End Try
        End With
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Function EXISTEDSN() As Boolean
        EXISTEDSN = False
        Conectar()
        If Error_BD = True Then Error_BD = False : EXISTEDSN = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String = "Select emp_codigo from Empleados"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                EXISTEDSN = True
            End While
        Catch ex As Exception
            Err.Clear()
        End Try
        Return EXISTEDSN
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function ObtenerConsecutivoCategoria() As String
        Conectar()
        If Error_BD = True Then Error_BD = False : ObtenerConsecutivoCategoria = Nothing : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        SQL = "Select * from Categorias"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = CInt(Cls_Leer_Consulta(0)) : Continue While
                If Registro < CInt(Cls_Leer_Consulta(0)) Then Registro = CInt(Cls_Leer_Consulta(0))
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
        Catch ex As Exception
            Err.Clear()
        End Try
        If Registro.ToString.Length = 1 Then Return "0" & Registro Else Return CStr(Registro)
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function VerificarCategoria(ByVal Nombre As String) As String
        Conectar()
        VerificarCategoria = ""
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String = ""
        SQL = "Select cat_codigo from Categorias Where cat_descripcion='" & Nombre & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            If Cls_Leer_Consulta.Read = True Then
                VerificarCategoria = Cls_Leer_Consulta(0).ToString
            End If
        Catch ex As Exception
            Err.Clear()
        End Try
        Return VerificarCategoria
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function ObtenerConsecutivoEmpleado() As String
        Conectar()
        ObtenerConsecutivoEmpleado = ""
        If Error_BD = True Then Error_BD = False : ObtenerConsecutivoEmpleado = Nothing : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        SQL = "Select emp_codigo from Empleados"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = CInt(Cls_Leer_Consulta(0)) : Continue While
                If Registro < CInt(Cls_Leer_Consulta(0)) Then Registro = CInt(Cls_Leer_Consulta(0))
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
        Catch ex As Exception
            Err.Clear()
        End Try
        ObtenerConsecutivoEmpleado = Registro
        If Registro.ToString.Length = 1 Then Return CStr(ObtenerConsecutivoEmpleado)
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function ObtenerConsecutivoProducto() As String
        Conectar()
        If Error_BD = True Then Error_BD = False : ObtenerConsecutivoProducto = Nothing : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        SQL = "Select art_codigo from Articulos"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = CInt(Cls_Leer_Consulta(0)) : Continue While
                If Registro < CInt(Cls_Leer_Consulta(0)) Then Registro = CInt(Cls_Leer_Consulta(0))
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
        Catch ex As Exception
            Err.Clear()
        End Try
        If Registro.ToString.Length = 1 Then Return "0" & Registro Else Return CStr(Registro)
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Sub EliminarArticulo(ByVal Codigo As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Delete * FROM Articulos Where Articulos.art_codigo='" & Codigo & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Ejecutar_comando.ExecuteNonQuery()
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub EliminarEmpleado(ByVal Codigo As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Delete * FROM Empleados Where Empleados.emp_codigo='" & Codigo & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Ejecutar_comando.ExecuteNonQuery()
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub CargarEmpleado(ByVal Codigo As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "SELECT  Empleados.emp_cedula, Empleados.emp_nombre, Empleados.emp_apellidos, Empleados.emp_telefono, Empleados.emp_direccion FROM Empleados Where Empleados.emp_codigo='" & Codigo & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        If Cls_Leer_Consulta.Read = True Then
            With Frm_Empleados
                .Txt_Cedula.Text = UCase(Cls_Leer_Consulta(0).ToString)
                .Txt_Nombre.Text = UCase(Cls_Leer_Consulta(1).ToString)
                .Txt_Apellidos.Text = UCase(Cls_Leer_Consulta(2).ToString)
                .Txt_Telefono.Text = Cls_Leer_Consulta(3).ToString
                .Txt_Direccion.Text = Cls_Leer_Consulta(4).ToString
                .Txt_Codigo.Text = Codigo
            End With
        End If
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub ObtenerTodosEmpleados()
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim Encontrados As Integer = 0
        Dim SQL As String
        SQL = "SELECT Empleados.emp_codigo, Empleados.emp_cedula, Empleados.emp_nombre, Empleados.emp_apellidos, Empleados.emp_telefono, Empleados.emp_direccion FROM Empleados"
        Encontrados = 0
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        ReDim Empleados(0)
        While Cls_Leer_Consulta.Read
            ReDim Preserve Empleados(Encontrados)
            Empleados(Encontrados).Codigo = Cls_Leer_Consulta(0).ToString
            Empleados(Encontrados).Cedula = Cls_Leer_Consulta(1).ToString
            Empleados(Encontrados).Nombre = Cls_Leer_Consulta(2).ToString
            Empleados(Encontrados).Apellidos = Cls_Leer_Consulta(3).ToString
            Empleados(Encontrados).Telefono = Cls_Leer_Consulta(4).ToString
            Empleados(Encontrados).Direccion = Cls_Leer_Consulta(5).ToString
            Encontrados += 1
        End While
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub ObtenerTodosProductos()
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim Encontrados As Integer = 0
        Dim SQL As String
        SQL = "SELECT Articulos.art_codigo, Articulos.art_descripcion, Articulos.art_precio, Categorias.cat_descripcion, Articulos.cat_codigo FROM Categorias INNER JOIN Articulos ON Categorias.cat_codigo = Articulos.cat_codigo"
        Encontrados = 0
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        ReDim Productos(0)
        While Cls_Leer_Consulta.Read
            ReDim Preserve Productos(Encontrados)
            Productos(Encontrados).Codigo = Cls_Leer_Consulta(0).ToString
            Productos(Encontrados).Nombre = Cls_Leer_Consulta(1).ToString
            Productos(Encontrados).Precio = Cls_Leer_Consulta(2).ToString
            Productos(Encontrados).Categoria = Cls_Leer_Consulta(3).ToString
            Encontrados += 1
        End While
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Function Cargar_Productos_En_Pedidos(ByVal Categoria As String) As Integer
        With Frm_Pedidos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Function
            Cls_Espacio_Trabajo.Open()
            Dim Encontrados As Integer = 0
            Dim SQL As String
            SQL = "SELECT Articulos.art_codigo, Articulos.art_descripcion, Articulos.art_precio, Categorias.cat_descripcion, Articulos.cat_codigo FROM Categorias INNER JOIN Articulos ON Categorias.cat_codigo = Articulos.cat_codigo WHERE (((Articulos.cat_codigo)='" & Categoria & "'))"
            Encontrados = 0
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            .Panel_Productos.Controls.Clear()
            'ReDim Productos(0)
            While Cls_Leer_Consulta.Read
                Dim Existe As Boolean = False
                Dim C_Objetos As Integer = 0, Cantidad As Integer = 1
                For Each PctB As PictureBox In .Panel_Productos.Controls
                    If PctB.Name = Cls_Leer_Consulta(0).ToString Then Existe = True
                    C_Objetos += 1
                    Cantidad += 1
                Next
                If Existe = False Then
                    Dim Objeto As New PictureBox
                    Objeto.Name = Cls_Leer_Consulta(0).ToString
                    Dim Imagenes() As String = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
                    Dim Entro As Boolean = False
                    For A = 0 To Imagenes.Length - 1
                        Entro = True
                        Dim Imagen() As String = Imagenes(A).Split("\")
                        Imagen = Imagen.Last.Split(".")
                        If Imagen(0) = "P" & Objeto.Name Then
                            Imagen = Imagenes(A).Split("\")
                            Try
                                Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & Imagen.Last
                                Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                            Catch
                                Err.Clear()
                                Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                                Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                                Notificacion("Error", "Ocurrio un error al intentar cargar la imagen", 3, 5000)
                            End Try
                        End If
                    Next
                    If Entro = False Then
                        Try
                            Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                            Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Objeto.Size = New Size(141, 125)
                    Objeto.BackColor = Color.Transparent
                    Dim X As Integer = 12, Y As Integer = 12
                    Dim NumF As Integer = CInt(C_Objetos / 5)
                    'If NumF < 1 Then NumF = 1
                    If C_Objetos > 4 Then Y = 143 * NumF
                    If C_Objetos > 4 Then C_Objetos = 0
                    If C_Objetos > 0 Then X = 159 * C_Objetos
                    If C_Objetos > 1 Then X = X - (12 * (C_Objetos - 1))
                    Objeto.Location = New Point(X, Y)
                    Objeto.Visible = True
                    Objeto.Show()
                    .Panel_Productos.Controls.Add(Objeto)
                    'ReDim Preserve Productos(Cantidad - 1)
                    'Productos(Cantidad - 1).Codigo = Cls_Leer_Consulta(0).ToString
                    'Productos(Cantidad - 1).Nombre = Cls_Leer_Consulta(1).ToString
                    'Productos(Cantidad - 1).Precio = Cls_Leer_Consulta(2).ToString
                    'Productos(Cantidad - 1).Categoria = Cls_Leer_Consulta(3).ToString
                End If
            End While
            Return Encontrados
        End With
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Verificar_ArticuloOrden(ByVal Numero As String, ByVal Codigo As String) As Boolean
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Verificar_ArticuloOrden = False
        Dim SQL As String
        SQL = "SELECT * FROM Desc_Pedido Where ped_numero=" & Numero & " and art_codigo='" & Codigo & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        If Cls_Leer_Consulta.Read = True Then
            Verificar_ArticuloOrden = True
        End If
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Verificar_Orden(ByVal Numero As String) As Boolean
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Verificar_Orden = False
        Dim SQL As String
        SQL = "SELECT Pedidos.ped_numero FROM Pedidos"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        While Cls_Leer_Consulta.Read
            If Cls_Leer_Consulta(0).ToString = Numero Then
                Verificar_Orden = True
            End If
        End While
        Return Verificar_Orden
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Sub Eliminar_RegistroOrden(ByVal Numero As String, ByVal CProducto As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Delete * from Desc_Pedido Where ped_numero=" & Numero & " and art_codigo='" & CProducto & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
            For A = 0 To Orden.Length - 1
                If Orden(A).NumeroPedido = Numero And Orden(A).Cod_Producto = CProducto Then
                    Orden(A).NumeroPedido = ""
                    Orden(A).Cod_Producto = ""
                End If
            Next
        Catch
            Notificacion("ERROR", ErrorToString, 3, 4000)
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub Cancel_Orden(ByVal Numero As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Update Pedidos Set Cancelado=True Where ped_numero=" & Numero
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
        Catch
            Notificacion("ERROR", ErrorToString, 3, 4000)
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub Nueva_Orden(ByVal Numero As String, ByVal Mesa As String, ByVal Empleado As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Insert Into Pedidos Values (" & Numero & ",'" & FormatDateTime(Now, DateFormat.ShortDate) & "','" & FormatDateTime(Now, DateFormat.LongTime) & "','" & Mesa & "','" & Empleado & "',False)"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
        Catch
            Notificacion("ERROR", ErrorToString, 3, 4000)
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub Insertar_Orden(ByVal Numero As String, ByVal Producto As String, ByVal CProducto As String, ByVal Cantidad As String, ByVal Precio As String, ByVal Detalle As String)
        Dim Registro As Integer = Obtener_ArtOrden()
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Insert Into Desc_Pedido Values (" & Numero & ",'" & CProducto & "'," & Cantidad & ",'" & Detalle & "','" & Producto & "'," & Precio & "," & Registro & ")"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
            For A = 0 To Orden.Length - 1
                If Orden(A).NumeroPedido = Numero And Orden(A).Cod_Producto = CProducto Then
                    Orden(A).NumeroPedido = ""
                    Orden(A).Cod_Producto = ""
                End If
            Next
        Catch
            Notificacion("ERROR", ErrorToString, 3, 4000)
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub Actualizar_Orden(ByVal Numero As String, ByVal Producto As String, ByVal CProducto As String, ByVal Cantidad As String, ByVal Precio As String, ByVal Detalle As String)
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "Update Desc_Pedido Set ped_numero=" & Numero & ",art_codigo='" & CProducto & "', cantidad=" & Cantidad & ", ped_descripcion='" & Detalle & "', ped_producto='" & Producto & "',ped_precio=" & Precio & " Where ped_numero=" & Numero & " and art_codigo='" & CProducto & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
            For A = 0 To Orden.Length - 1
                If Orden(A).NumeroPedido = Numero And Orden(A).Cod_Producto = CProducto Then
                    Orden(A).NumeroPedido = ""
                    Orden(A).Cod_Producto = ""
                End If
            Next
        Catch
            Notificacion("ERROR", ErrorToString, 3, 4000)
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Sub Cargar_OrdenesBackground()
        Conectar2()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo2.Open()
        Dim Encontrados As Integer = 0
        Dim SQL As String
        SQL = "SELECT Desc_Pedido.ped_numero, Desc_Pedido.art_codigo, Desc_Pedido.cantidad, Desc_Pedido.ped_descripcion, Desc_Pedido.ped_producto, Desc_Pedido.ped_precio, Pedidos.ped_fecha, Pedidos.ped_hora, Pedidos.mes_codigo, Pedidos.emp_codigo FROM Pedidos INNER JOIN Desc_Pedido ON Pedidos.ped_numero = Desc_Pedido.ped_numero WHERE (((Pedidos.Cancelado)=False))"
        Encontrados = 0
        Cls_Ejecutar_comando2 = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo2)
        Cls_Leer_Consulta2 = Cls_Ejecutar_comando2.ExecuteReader
        ReDim Orden(Encontrados)
        While Cls_Leer_Consulta2.Read
            ReDim Preserve Orden(Encontrados)
            Orden(Encontrados).NumeroPedido = Cls_Leer_Consulta2(0).ToString
            Orden(Encontrados).Cod_Producto = Cls_Leer_Consulta2(1).ToString
            Orden(Encontrados).Cantidad = Cls_Leer_Consulta2(2).ToString
            Orden(Encontrados).Detalle = Cls_Leer_Consulta2(3).ToString
            Orden(Encontrados).Producto = Cls_Leer_Consulta2(4).ToString
            Orden(Encontrados).Precio = Cls_Leer_Consulta2(5).ToString
            Orden(Encontrados).Fecha = Cls_Leer_Consulta2(6).ToString
            Orden(Encontrados).Hora = Cls_Leer_Consulta2(7).ToString
            Orden(Encontrados).Mesa = Cls_Leer_Consulta2(8).ToString
            Orden(Encontrados).Empleado = Cls_Leer_Consulta2(9).ToString
            Encontrados += 1
        End While
        Cls_Espacio_Trabajo2.Close()
    End Sub
    Public Sub Cargar_Ordenes()
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Sub
        Cls_Espacio_Trabajo.Open()
        Dim Encontrados As Integer = 0
        Dim SQL As String
        SQL = "SELECT Desc_Pedido.ped_numero, Desc_Pedido.art_codigo, Desc_Pedido.cantidad, Desc_Pedido.ped_descripcion, Desc_Pedido.ped_producto, Desc_Pedido.ped_precio, Pedidos.ped_fecha, Pedidos.ped_hora, Pedidos.mes_codigo, Pedidos.emp_codigo FROM Pedidos INNER JOIN Desc_Pedido ON Pedidos.ped_numero = Desc_Pedido.ped_numero WHERE (((Pedidos.Cancelado)=False))"
        Encontrados = 0
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        ReDim Orden(Encontrados)
        While Cls_Leer_Consulta.Read
            ReDim Preserve Orden(Encontrados)
            Orden(Encontrados).NumeroPedido = Cls_Leer_Consulta(0).ToString
            Orden(Encontrados).Cod_Producto = Cls_Leer_Consulta(1).ToString
            Orden(Encontrados).Cantidad = Cls_Leer_Consulta(2).ToString
            Orden(Encontrados).Detalle = Cls_Leer_Consulta(3).ToString
            Orden(Encontrados).Producto = Cls_Leer_Consulta(4).ToString
            Orden(Encontrados).Precio = Cls_Leer_Consulta(5).ToString
            Orden(Encontrados).Fecha = Cls_Leer_Consulta(6).ToString
            Orden(Encontrados).Hora = Cls_Leer_Consulta(7).ToString
            Orden(Encontrados).Mesa = Cls_Leer_Consulta(8).ToString
            Orden(Encontrados).Empleado = Cls_Leer_Consulta(9).ToString
            Encontrados += 1
        End While
        Cls_Espacio_Trabajo.Close()
    End Sub
    Public Function Cargar_Categorias_En_Pedidos() As Integer
        With Frm_Pedidos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Function
            Cls_Espacio_Trabajo.Open()
            Dim Encontrados As Integer = 0
            Dim SQL As String
            SQL = "SELECT Articulos.art_codigo, Articulos.art_descripcion, Categorias.cat_codigo, Categorias.cat_descripcion FROM Categorias INNER JOIN Articulos ON Categorias.cat_codigo = Articulos.cat_codigo"
            Encontrados = 0
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            .Panel_Categorias.Controls.Clear()
            While Cls_Leer_Consulta.Read
                Dim Existe As Boolean = False
                Dim C_Objetos As Integer = 0
                For Each PctB As Label In .Panel_Categorias.Controls
                    If PctB.Name = Cls_Leer_Consulta(2).ToString Then Existe = True
                    C_Objetos += 1
                Next
                If Existe = False Then
                    Dim Objeto As New Label
                    Objeto.Name = Cls_Leer_Consulta(2).ToString
                    Objeto.Text = Cls_Leer_Consulta(3).ToString
                    Objeto.Size = New Size(166, 37)
                    Objeto.BorderStyle = BorderStyle.Fixed3D
                    Objeto.TextAlign = ContentAlignment.MiddleCenter
                    Objeto.Font = New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
                    Dim Y As Integer = 0
                    If C_Objetos > 0 Then Y = 41 * C_Objetos
                    Objeto.Location = New Point(3, Y)
                    Objeto.Visible = True
                    Objeto.Show()
                    .Panel_Categorias.Controls.Add(Objeto)
                End If
            End While
            Return Encontrados
        End With
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Verificar_Usuario(ByVal Nombre As String, ByVal Password As String) As String
        Conectar()
        Verificar_Usuario = ""
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        SQL = "Select * from Usuarios Where Cuenta='" & Nombre & "' and Clave='" & Password & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            If Cls_Leer_Consulta.Read = True Then
                Verificar_Usuario = Cls_Leer_Consulta(2).ToString
                Usuario = Cls_Leer_Consulta(2).ToString
                ID_Usuario = Cls_Leer_Consulta(0).ToString
            End If
        Catch ex As Exception
            Err.Clear()
        End Try
        Return Verificar_Usuario
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Obtener_ArtOrden() As Integer
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        SQL = "Select Registro from Desc_Pedido"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = Cls_Leer_Consulta(0) : Continue While
                If Registro < Cls_Leer_Consulta(0) Then Registro = Cls_Leer_Consulta(0)
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
        Catch ex As Exception
            Err.Clear()
        End Try
        Return Registro
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Obtener_NumPedido() As Integer
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        SQL = "Select ped_numero from Pedidos"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = Cls_Leer_Consulta(0) : Continue While
                If Registro < Cls_Leer_Consulta(0) Then Registro = Cls_Leer_Consulta(0)
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
        Catch ex As Exception
            Err.Clear()
        End Try
        Return Registro
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_Productos(ByVal Categoria As String) As Integer
        With Frm_Productos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Function
            Cls_Espacio_Trabajo.Open()
            Dim Encontrados As Integer = 0
            Dim SQL As String
            SQL = "SELECT Articulos.art_codigo, Articulos.art_descripcion, Articulos.art_precio, Categorias.cat_descripcion, Articulos.cat_codigo FROM Categorias INNER JOIN Articulos ON Categorias.cat_codigo = Articulos.cat_codigo WHERE (((Articulos.cat_codigo)='" & Categoria & "'))"
            Encontrados = 0
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            .Panel_Productos.Controls.Clear()
            ReDim Productos(0)
            While Cls_Leer_Consulta.Read
                Dim Existe As Boolean = False
                Dim C_Objetos As Integer = 0, Cantidad As Integer = 1
                For Each PctB As PictureBox In .Panel_Productos.Controls
                    If PctB.Name = Cls_Leer_Consulta(0).ToString Then Existe = True
                    C_Objetos += 1
                    Cantidad += 1
                Next
                If Existe = False Then
                    Dim Objeto As New PictureBox
                    Objeto.Name = Cls_Leer_Consulta(0).ToString
                    Dim Imagenes() As String = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
                    Dim Entro As Boolean = False
                    For A = 0 To Imagenes.Length - 1
                        Entro = True
                        Dim Imagen() As String = Imagenes(A).Split("\")
                        Imagen = Imagen.Last.Split(".")
                        If Imagen(0) = "P" & Objeto.Name Then
                            Imagen = Imagenes(A).Split("\")
                            Try
                                Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & Imagen.Last
                                Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                            Catch
                                Err.Clear()
                                Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                                Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                                Notificacion("Error", "Ocurrio un error al intentar cargar la imagen", 3, 5000)
                            End Try
                        End If
                    Next
                    If Entro = False Then
                        Try
                            Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                            Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Objeto.Size = New Size(141, 125)
                    Objeto.BackColor = Color.Transparent
                    Dim X As Integer = 12, Y As Integer = 25 '12
                    Dim NumF As Integer = CInt(C_Objetos / 5)
                    'If NumF < 1 Then NumF = 1
                    If C_Objetos > 4 Then Y = 156 * NumF '143
                    If C_Objetos > 4 Then C_Objetos = 0
                    If C_Objetos > 0 Then X = 159 * C_Objetos
                    If C_Objetos > 1 Then X = X - (12 * (C_Objetos - 1))
                    Objeto.Location = New Point(X, Y)
                    Objeto.Visible = True
                    Objeto.Show()
                    .Panel_Productos.Controls.Add(Objeto)
                    Objeto.SendToBack()
                    Frm_Productos.Lbl_P.BringToFront()
                    ReDim Preserve Productos(Cantidad - 1)
                    Productos(Cantidad - 1).Codigo = Cls_Leer_Consulta(0).ToString
                    Productos(Cantidad - 1).Nombre = Cls_Leer_Consulta(1).ToString
                    Productos(Cantidad - 1).Precio = Cls_Leer_Consulta(2).ToString
                    Productos(Cantidad - 1).Categoria = Cls_Leer_Consulta(3).ToString
                End If
            End While
            Dim LabelP As New Label
            LabelP = .Lbl_P
            'LabelP.Text = "Productos"
            'LabelP.AutoSize = True
            LabelP.Visible = True
            LabelP.Location = New Point(2, 0)
            'LabelP.ForeColor = Color.White
            'LabelP.Font = .Lbl_P.Font
            .Panel_Productos.Controls.Add(LabelP)
            Return Encontrados
        End With
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_CmbCategorias() As Integer
        With Frm_Productos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Function
            Cls_Espacio_Trabajo.Open()
            Dim Encontrados As Integer = 0
            Dim SQL As String
            SQL = "SELECT cat_descripcion FROM Categorias"
            Encontrados = 0
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            .Cmb_Categorias.Items.Clear()
            While Cls_Leer_Consulta.Read
                Dim Existe As Boolean = False
                Try
                    For A = 0 To .Cmb_Categorias.Items.Count - 1
                        If .Cmb_Categorias.Items(A) = Cls_Leer_Consulta(0).ToString Then Existe = True
                    Next
                    If Existe = False Then
                        .Cmb_Categorias.Items.Add(Cls_Leer_Consulta(0).ToString)
                    Else
                        Existe = False
                    End If
                Catch
                    Err.Clear()
                End Try
            End While
            Return Encontrados
        End With
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_Categorias() As Integer
        With Frm_Productos
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Function
            Cls_Espacio_Trabajo.Open()
            Dim Encontrados As Integer = 0
            Dim SQL As String
            SQL = "SELECT Articulos.art_codigo, Articulos.art_descripcion, Categorias.cat_codigo, Categorias.cat_descripcion FROM Categorias INNER JOIN Articulos ON Categorias.cat_codigo = Articulos.cat_codigo"
            Encontrados = 0
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            .Panel_Categorias.Controls.Clear()
            '.Cmb_Categorias.Items.Clear()
            ReDim Categorias(0)
            While Cls_Leer_Consulta.Read
                Dim Existe As Boolean = False
                Dim C_Objetos As Integer = 0
                For Each PctB As PictureBox In .Panel_Categorias.Controls
                    If PctB.Name = Cls_Leer_Consulta(2).ToString Then Existe = True
                    C_Objetos += 1
                Next
                If Existe = False Then
                    '.Cmb_Categorias.Items.Add(Cls_Leer_Consulta(3).ToString)
                    Dim Objeto As New PictureBox
                    Objeto.Name = Cls_Leer_Consulta(2).ToString
                    ReDim Preserve Categorias(Categorias.Length)
                    Categorias(Categorias.Length - 1).Codigo = Cls_Leer_Consulta(2).ToString
                    Categorias(Categorias.Length - 1).Nombre = Cls_Leer_Consulta(3).ToString
                    Dim Imagenes() As String = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
                    Dim Entro As Boolean = False
                    For A = 0 To Imagenes.Length - 1
                        Entro = True
                        Dim Imagen() As String = Imagenes(A).Split("\")
                        Imagen = Imagen.Last.Split(".")
                        If Imagen(0) = "CAT" & Objeto.Name Then
                            Imagen = Imagenes(A).Split("\")
                            Try
                                Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & Imagen.Last
                                Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                            Catch
                                Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                                Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                                Err.Clear()
                                Notificacion("Error", "Ocurrio un error al intentar cargar la imagen", 3, 5000)
                            End Try
                        End If
                    Next
                    If Entro = False Then
                        Try
                            Objeto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                            Objeto.SizeMode = PictureBoxSizeMode.StretchImage
                        Catch
                            Err.Clear()
                        End Try
                    End If
                    Objeto.Size = New Size(141, 125)
                    Objeto.BackColor = Color.Transparent
                    Dim X As Integer = 12
                    If C_Objetos > 0 Then X = 159 * C_Objetos
                    Objeto.Location = New Point(X, 15)
                    Objeto.Visible = True
                    Objeto.Show()
                    .Panel_Categorias.Controls.Add(Objeto)
                End If
            End While
            Dim LabelC As New Label
            LabelC = .Lbl_C
            LabelC.Location = New Point(2, 0)
            LabelC.Visible = True
            .Panel_Categorias.Controls.Add(LabelC)
            Return Encontrados
        End With
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Agregar_BD(ByVal SQL As String) As Boolean
        '----------------------------------------------------------------------------------
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Agregado As Boolean = False
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
            Agregado = True
            If MESAJEFUNCION = 1 Then
                Notificacion("¡Base de Datos Actualizada!", "¡El nuevo elemento ha sido agregado con satisfacción!", 1, 3000)
            End If
        Catch
            Err.Clear()
            Agregado = False
            Notificacion("¡Error en la BD!", "¡Ha ocurrido un error al escribir en la base de datos!" & _
                         Chr(13) & _
                         "Consulte un administrador.", 1, 3000)
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Modificar_BD(ByVal SQL As String) As Boolean
        '----------------------------------------------------------------------------------
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Modificado As Boolean = False
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
            Modificado = True
            If MESAJEFUNCION = 1 Then
                Notificacion("¡Base de Datos Actualizada!", "¡El elemento ha sido modificado con satisfacción!", 1, 3000)
            End If
        Catch
            Err.Clear()
            Modificado = False
            Notificacion("¡Error en la BD!", "¡Ha ocurrido un error al escribir en la base de datos!" & _
                         Chr(13) & _
                         "Consulte un administrador.", 1, 3000)
        End Try
        Return Modificado
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Eliminar_BD(ByVal SQL As String, ByVal mensaje As Integer) As Boolean
        '----------------------------------------------------------------------------------
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Eliminar As Boolean = False
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Try
            Cls_Ejecutar_comando.ExecuteNonQuery()
            Eliminar = True
            If mensaje = 1 Then
                Notificacion("¡Base de Datos Actualizada!", "¡El elemento ha sido eliminado con satisfacción!", 1, 3000)
            End If
        Catch
            Err.Clear()
            Eliminar = False
            Notificacion("¡Error en la BD!", "¡Ha ocurrido un error al escribir en la base de datos!" & _
                         Chr(13) & _
                         "Consulte un administrador.", 1, 3000)
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Sub Generar_Reporte(ByVal Campo As String, ByVal Valor As String)
        'Dim Reporte As New CrystalReport_Estudiantes
        ''"{Estudiantes.Identificacion}='2714585'"
        ''"{Estudiantes.Nombre} Like 'A*'"
        'Dim SQL As String = "{Estudiantes." & Campo & "} " & Valor
        'Reporte.RecordSelectionFormula = SQL
        'Frm_ReportesEstudiantes.CrptView_Estudiantes.ReportSource = Reporte
        'Frm_ReportesEstudiantes.MdiParent = MDI_Principal
        'Frm_ReportesEstudiantes.Show()
    End Sub
    '-------------------------------------------------------------------------------------
    'Declaracion de Subproceso
    Public Function Notificacion(ByVal Titulo As String, ByVal Texto As String, ByVal Tipo As Integer, ByVal Tiempo As Integer) As Boolean
        Dim Subproceso As Threading.Thread
        Subproceso = New Threading.Thread(AddressOf Segundo_Plano_Notificacion)
        TituloNoti = Titulo
        TextoNoti = Texto
        TiempoNoti = Tiempo
        TipoNoti = Tipo
        Subproceso.Start()
    End Function
    'Notificacion de Sistema
    Private TituloNoti, TextoNoti As String
    Private TipoNoti, TiempoNoti As Integer
    Private Sub Segundo_Plano_Notificacion()
        Dim MyNotificacion As New NotifyIcon
        Dim Icono As New Icon(AppDomain.CurrentDomain.BaseDirectory & "coffee.ico")
        MyNotificacion.Visible = True
        MyNotificacion.Icon = Icono
        MyNotificacion.BalloonTipText = TextoNoti
        MyNotificacion.BalloonTipIcon = TipoNoti
        MyNotificacion.BalloonTipTitle = TituloNoti
        MyNotificacion.ShowBalloonTip(TiempoNoti)
        Threading.Thread.Sleep(TiempoNoti)
        MyNotificacion.Visible = False
        MyNotificacion.Dispose()
    End Sub
    '-------------------------------------------------------------------------------------
    'CODIGO DE MIGUEL
    '******************************************************************************************************************************************
    '******************************************************************************************************************************************
    '******************************************************************************************************************************************
    '******************************************************************************************************************************************
    Public Function Existe_Usuario(ByVal Nombre As String) As Boolean
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        Dim Existe As Boolean = False
        SQL = "Select * from Usuarios Where Cuenta='" & Nombre & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            If Cls_Leer_Consulta.Read = True Then
                Existe = True
            End If
        Catch ex As Exception
            Err.Clear()
        End Try
        Return Existe
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Existe_Pedido(ByVal pedido As Integer) As Boolean
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Dim SQL As String = ""
        Dim Existe As Boolean = False
        SQL = "Select * from Pedidos Where ped_numero=" & pedido & ""
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            If Cls_Leer_Consulta.Read = True Then
                Existe = True
            End If
        Catch ex As Exception
            Err.Clear()
        End Try
        Return Existe
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_Salon(ByVal mesa As String) As String
        Conectar()
        Cargar_Salon = ""
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String, salon As String = ""
        SQL = "SELECT * from Mesas where mes_codigo='" & mesa & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                salon = Cls_Leer_Consulta(2).ToString
            End While
            Return salon
        Catch ex As Exception
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_cod_empleado(ByVal emp As String) As String
        Conectar()
        Cargar_cod_empleado = ""
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "SELECT * from Empleados where emp_codigo='" & emp & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                emp = Cls_Leer_Consulta(0).ToString
            End While
            Return emp
        Catch ex As Exception
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_Usuarios() As Long
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "SELECT * from Usuarios where cuenta='" & ID_Usuario & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Frm_Usuarios.Txt_User.Text = ""
        Frm_Usuarios.Txt_Clave.Text = ""
        Frm_Usuarios.Txt_Nom.Text = ""
        Try
            While Cls_Leer_Consulta.Read
                Frm_Usuarios.Txt_User.Text = Cls_Leer_Consulta(0).ToString
                Frm_Usuarios.Txt_Clave.Text = Cls_Leer_Consulta(1).ToString
                Frm_Usuarios.Txt_Nom.Text = Cls_Leer_Consulta(2).ToString
            End While
        Catch ex As Exception
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_Usuarios_Eliminar() As Boolean
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        Dim Existe As Boolean = False
        SQL = "SELECT * from Usuarios where not cuenta='" & ID_Usuario & "'"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Frm_Usuarios.Cmb_User.Items.Clear()
        Try
            While Cls_Leer_Consulta.Read
                Frm_Usuarios.Cmb_User.Items.Add(Cls_Leer_Consulta(0).ToString)
                Existe = True
            End While
            If Existe = True Then
                Frm_Usuarios.Cmb_User.SelectedIndex = 0
            Else
                Existe = False
            End If
        Catch ex As Exception
        End Try
        Return Existe
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Sub Imprimir_Factura(ByVal num_factura As Integer, ByVal cliente As String, ByVal emp As String, ByVal subt As Integer, ByVal des As Integer, ByVal tot As Integer, ByVal ped As Integer)
        Dim SQL_Balance As String
        Dim Reporte As New Crt_facturas
        SQL_Balance = "{Detalle_Factura.NumeroFactura}=" & num_factura
        Reporte.RecordSelectionFormula = SQL_Balance
        Reporte.SetParameterValue("Nombre", Empresa.Nombre)
        Reporte.SetParameterValue("Direccion", Empresa.Direccion)
        Reporte.SetParameterValue("Telefono", Empresa.Telefono)
        Reporte.SetParameterValue("Pedido", ped)
        Reporte.SetParameterValue("Cliente", cliente)
        Reporte.SetParameterValue("Empleado", emp)
        Reporte.SetParameterValue("Subtotal", subt)
        Reporte.SetParameterValue("Descuento", des)
        Reporte.SetParameterValue("Total", tot)
        Reporte.PrintToPrinter(1, False, 0, 0)
    End Sub
    Public Sub Imprimir_Pedido(ByVal num_factura As Integer, ByVal mesa As String, ByVal cliente As String, ByVal emp As String)
        Dim SQL_Balance As String
        Dim Reporte As New Crt_pedidos
        SQL_Balance = "{Desc_Pedido.ped_numero}=" & num_factura
        Reporte.RecordSelectionFormula = SQL_Balance
        Reporte.SetParameterValue("Nombre", Empresa.Nombre)
        Reporte.SetParameterValue("Telefono", "Pedido N° " & num_factura)
        Reporte.SetParameterValue("Cliente", cliente)
        Reporte.SetParameterValue("Empleado", emp)
        Reporte.SetParameterValue("Subtotal", mesa)
        Reporte.SetParameterValue("Total", "Servir")
        Reporte.PrintToPrinter(1, False, 0, 0)
    End Sub
    Public Sub Imprimir_Pedido_llevar(ByVal num_factura As Integer, ByVal emp As String)
        Dim SQL_Balance As String
        Dim Reporte As New Crt_pedidos_llevar
        SQL_Balance = "{Desc_Pedido.ped_numero}=" & num_factura
        Reporte.RecordSelectionFormula = SQL_Balance
        Reporte.SetParameterValue("Nombre", Empresa.Nombre)
        Reporte.SetParameterValue("Telefono", "Pedido N° " & num_factura)
        Reporte.SetParameterValue("Empleado", emp)
        Reporte.SetParameterValue("Total", "Llevar")
        Reporte.PrintToPrinter(1, False, 0, 0)
    End Sub
    Public Function Cargar_Pedidos_Fractura() As Long
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL, pedido As String
        SQL = "SELECT ped_numero from Pedidos where Cancelado=false"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        lista = False
        pedido = Frm_Facturas.Cmb_Pedidos.Text
        Frm_Facturas.Cmb_Pedidos.Items.Clear()
        Try
            While Cls_Leer_Consulta.Read
                Frm_Facturas.Cmb_Pedidos.Items.Add(Cls_Leer_Consulta(0).ToString)
            End While
            Frm_Facturas.Cmb_Pedidos.Text = pedido
            lista = True
        Catch ex As Exception
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Cargar_Empleado_Fractura() As Long
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL, pedido As String
        SQL = "SELECT * from Empleados"
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        pedido = Frm_Facturas.Cmb_Empleado.Text
        Frm_Facturas.Cmb_Empleado.Items.Clear()
        Try
            While Cls_Leer_Consulta.Read
                Frm_Facturas.Cmb_Empleado.Items.Add(Cls_Leer_Consulta(2).ToString)
            End While
            Frm_Facturas.Cmb_Empleado.Text = pedido
        Catch ex As Exception
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Sub Calcular_Factura()
        Dim contador, precio As Integer
        Dim vec(), vec2(), producto As String
        contador = Frm_Facturas.LB_Facturar.Items.Count
        If contador > 0 Then
            Frm_Facturas.Lbl_Subtotal.Text = 0
            For a = 0 To contador - 1
                producto = Frm_Facturas.LB_Facturar.Items(a)
                vec = producto.Split("-")
                vec2 = vec(1).Split(" ")
                producto = ""
                For b = 1 To vec2.Length - 1
                    If b = 1 Then
                        producto = producto & vec2(b)
                    Else
                        producto = producto & " " & vec2(b)
                    End If
                Next
                Conectar()
                If Error_BD = True Then Error_BD = False : Exit Sub
                Cls_Espacio_Trabajo.Open()
                Dim SQL As String
                SQL = "SELECT * from Desc_Pedido where ped_producto='" & producto & "'"
                Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
                Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
                While Cls_Leer_Consulta.Read
                    precio = Cls_Leer_Consulta(5).ToString
                End While
                Cls_Espacio_Trabajo.Close()
                Frm_Facturas.Lbl_Subtotal.Text = Frm_Facturas.Lbl_Subtotal.Text + (vec(0) * precio)
                Frm_Facturas.Lbl_Total.Text = Frm_Facturas.Lbl_Subtotal.Text - (Frm_Facturas.Lbl_Subtotal.Text * Frm_Facturas.ND_descuento.Value / 100)
            Next
        Else
            Frm_Facturas.Lbl_Subtotal.Text = 0
            Frm_Facturas.Lbl_Total.Text = 0
        End If
    End Sub
    Public Sub Calcular_Factura_Imprimir()
        Dim contador, precio, subtotal As Integer
        Dim vec(), vec2(), producto As String
        contador = Frm_Facturas.LB_Contenedor.Items.Count
        If contador > 0 Then
            subtotal = 0
            For a = 0 To contador - 1
                producto = Frm_Facturas.LB_Contenedor.Items(a)
                vec = producto.Split("-")
                vec2 = vec(1).Split(" ")
                producto = ""
                For b = 1 To vec2.Length - 1
                    If b = 1 Then
                        producto = producto & vec2(b)
                    Else
                        producto = producto & " " & vec2(b)
                    End If
                Next
                Conectar()
                If Error_BD = True Then Error_BD = False : Exit Sub
                Cls_Espacio_Trabajo.Open()
                Dim SQL As String
                SQL = "SELECT * from Desc_Pedido where ped_producto='" & producto & "'"
                Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
                Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
                While Cls_Leer_Consulta.Read
                    precio = Cls_Leer_Consulta(5).ToString
                End While
                Cls_Espacio_Trabajo.Close()
                subtotal = subtotal + (vec(0) * precio)
                total = subtotal - (subtotal * Frm_Facturas.ND_descuento.Value / 100)
            Next
        End If
    End Sub
    Public Function Cargar_Pedidos_Fractura_Lista(ByVal orden As Integer) As Long
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim SQL As String
        SQL = "SELECT * from Desc_Pedido where ped_numero=" & orden & ""
        Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Frm_Facturas.LB_Pedido.Items.Clear()
        Frm_Facturas.LB_Facturar.Items.Clear()
        Frm_Facturas.LB_Contenedor.Items.Clear()
        Try
            While Cls_Leer_Consulta.Read
                Frm_Facturas.LB_Pedido.Items.Add(Cls_Leer_Consulta(2).ToString & " - " & Cls_Leer_Consulta(4).ToString)
                Frm_Facturas.LB_Contenedor.Items.Add(Cls_Leer_Consulta(2).ToString & " - " & Cls_Leer_Consulta(4).ToString)
            End While
        Catch ex As Exception
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Sub Facturar()
        Dim precio, codigo, registro As Integer
        Dim vec() As String, vec2() As String, producto As String, Art_codigo As String = ""
        registro = Obtener_Registro_Fractura()
        MESAJEFUNCION = 0
        Agregar_BD("Insert into Facturas Values (" & registro & "," & total & ",'" & FormatDateTime(Now, DateFormat.ShortDate) & "','" & FormatDateTime(Now, DateFormat.LongTime) & "','" & Cargar_cod_empleado(Frm_Facturas.Cmb_Empleado.Text) & "')")
        For a = 0 To Frm_Facturas.LB_Contenedor.Items.Count - 1
            producto = Frm_Facturas.LB_Contenedor.Items(a)
            vec = producto.Split("-")
            vec2 = vec(1).Split(" ")
            producto = ""
            For b = 1 To vec2.Length - 1
                If b = 1 Then
                    producto = producto & vec2(b)
                Else
                    producto = producto & " " & vec2(b)
                End If
            Next
            Conectar()
            If Error_BD = True Then Error_BD = False : Exit Sub
            Cls_Espacio_Trabajo.Open()
            Dim SQL As String
            SQL = "SELECT * from Desc_Pedido where ped_producto='" & producto & "'"
            Cls_Ejecutar_comando = New Odbc.OdbcCommand(SQL, Cls_Espacio_Trabajo)
            Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
            While Cls_Leer_Consulta.Read
                codigo = Cls_Leer_Consulta(1).ToString
                precio = Cls_Leer_Consulta(5).ToString
            End While
            Cls_Espacio_Trabajo.Close()
            If codigo < 10 Then
                Art_codigo = "0" & codigo
            End If
            MESAJEFUNCION = 0
            Agregar_BD("Insert into Detalle_Factura Values (" & Obtener_Registro_Detalle_Fractura() & "," & registro & ",'" & producto & "'," & vec(0) & "," & precio & ",'" & Art_codigo & "')")
        Next

    End Sub
    Public Function Obtener_Registro_Fractura() As Integer
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Cls_Ejecutar_comando = New Odbc.OdbcCommand("Select fac_numero from Facturas", Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = Cls_Leer_Consulta(0) : Continue While
                If Registro < Cls_Leer_Consulta(0) Then Registro = Cls_Leer_Consulta(0)
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
            Return Registro
        Catch ex As Exception
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Obtener_Registro_Fractura_imprimir() As Integer
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Cls_Ejecutar_comando = New Odbc.OdbcCommand("Select fac_numero from Facturas", Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = Cls_Leer_Consulta(0) : Continue While
                If Registro < Cls_Leer_Consulta(0) Then Registro = Cls_Leer_Consulta(0)
            End While
            If Registro Is Nothing Then Registro = 0
            Return Registro
        Catch ex As Exception
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
    Public Function Obtener_Registro_Detalle_Fractura() As Integer
        Conectar()
        If Error_BD = True Then Error_BD = False : Exit Function
        Cls_Espacio_Trabajo.Open()
        Dim Registro? As Integer = Nothing
        Cls_Ejecutar_comando = New Odbc.OdbcCommand("Select ID from Detalle_Factura", Cls_Espacio_Trabajo)
        Cls_Leer_Consulta = Cls_Ejecutar_comando.ExecuteReader
        Try
            While Cls_Leer_Consulta.Read
                If Registro Is Nothing Then Registro = Cls_Leer_Consulta(0) : Continue While
                If Registro < Cls_Leer_Consulta(0) Then Registro = Cls_Leer_Consulta(0)
            End While
            If Registro Is Nothing Then Registro = 0
            Registro = Registro + 1
            Return Registro
        Catch ex As Exception
            Err.Clear()
        End Try
        Cls_Espacio_Trabajo.Close()
    End Function
End Module
