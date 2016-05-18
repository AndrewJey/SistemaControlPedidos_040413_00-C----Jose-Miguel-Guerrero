Imports System.IO
Public Class Frm_Productos
    Dim CategoriaTemporal As String = "", ProductoTemporal As String = ""
    Private Sub Frm_Productos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Frm_Mesas.Enabled = True
        Txt_Codigo.Text = ""
        Txt_Precio.Text = ""
        Txt_Producto.Text = ""
        Cmb_Categorias.Text = ""
    End Sub
    Private Sub Frm_Productos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True
        Cargar_CmbCategorias()
        'Frm_Mesas.Enabled = False
        Cargar_Categorias()
        On Error Resume Next
        For Each Categoria As PictureBox In Panel_Categorias.Controls
            AddHandler Categoria.Click, AddressOf Cargar_Productos_Categoria
        Next
    End Sub
    Private Sub Cargar_Productos_Categoria(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.GetType.Name = "PictureBox" Then
            Dim crtl As PictureBox = CType(sender, PictureBox)
            Cargar_Productos(crtl.Name)
        End If
        On Error Resume Next
        For Each Producto As PictureBox In Panel_Productos.Controls
            AddHandler Producto.Click, AddressOf Detalle_Producto
        Next
    End Sub
    Private Sub Detalle_Producto(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.GetType.Name = "PictureBox" Then
            Dim crtl As PictureBox = CType(sender, PictureBox)
            For A = 0 To Productos.Length - 1
                If Productos(A).Codigo = crtl.Name Then
                    Txt_Codigo.Text = Productos(A).Codigo
                    Txt_Precio.Text = Productos(A).Precio
                    Txt_Producto.Text = Productos(A).Nombre
                    Cmb_Categorias.Text = Productos(A).Categoria
                    Try
                        Pct_Producto.Image = crtl.Image
                    Catch
                        Err.Clear()
                        Pct_Categoria.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                        Notificacion("ERROR", "Ocurrio un error al intentar cargar la imagen", 3, 5000)
                    End Try
                End If
            Next
        End If
    End Sub
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        If Btn_Salir.Text = "Salir" Then
            Me.Close()
        ElseIf Btn_Salir.Text = "Cancelar" Then
            Panel_Categorias.Enabled = True
            Panel_Productos.Enabled = True
            Btn_Eliminar.Enabled = True
            Btn_Modificar.Enabled = True
            Btn_Nuevo.Enabled = True
            Btn_Nuevo.Text = "Nuevo"
            Btn_Modificar.Text = "Modificar"
            Btn_Salir.Text = "Salir"
        End If
    End Sub
    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        If Btn_Nuevo.Text = "Nuevo" Then
            Txt_Codigo.Text = ""
            Txt_Precio.Text = "0"
            Txt_Producto.Text = ""
            Panel_Categorias.Enabled = False
            Panel_Productos.Enabled = False
            Btn_Eliminar.Enabled = False
            Btn_Modificar.Enabled = False
            Btn_Salir.Text = "Cancelar"
            Btn_Nuevo.Text = "Guardar"
            Txt_Codigo.Enabled = False
            Txt_Codigo.Text = ObtenerConsecutivoProducto()
            Cmb_Categorias.DropDownStyle = ComboBoxStyle.DropDown
            Try
                Pct_Producto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                Cmb_Categorias.SelectedIndex = 0
            Catch
                Pct_Categoria.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                Err.Clear()
            End Try
        ElseIf Btn_Nuevo.Text = "Guardar" Then
            If Txt_Producto.Text = "" Then MsgBox("¡Debe completar todos los campos!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            If Txt_Precio.Text = "" Or Txt_Precio.Text = "0" Then MsgBox("¡El precio debe ser mayor a cero!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            If Txt_Codigo.Text = "" Then MsgBox("¡Debe completar todos los campos!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            If Cmb_Categorias.Text = "" Then MsgBox("¡Debe completar todos los campos!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            Dim Categoria As String = VerificarCategoria(Cmb_Categorias.Text)
            Dim Imagen As String = ObtenerConsecutivoCategoria()
            If Categoria = "" Then
                'Dim BuscarImagenCategoria As New OpenFileDialog
                'BuscarImagenCategoria.Filter = "Archivos JPG (*.jpg)|*.jpg|Archivos BMP (*.bmp)|*.bmp"
                'BuscarImagenCategoria.FilterIndex = 1
                'BuscarImagenCategoria.CheckFileExists = True
                'BuscarImagenCategoria.CheckPathExists = True
                'BuscarImagenCategoria.Title = "Seleccion la imagen de la categoria."
                'If BuscarImagenCategoria.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '    Dim Extension() As String = BuscarImagenCategoria.SafeFileName.Split(".")
                '    Imagen = ObtenerConsecutivoCategoria()
                '    Try
                '        File.Copy(BuscarImagenCategoria.FileName, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CAT" & Imagen & "." & Extension.Last, True)
                '        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                '            Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                '            Dim RUTA As String = Archivo.ReadLine
                '            File.Copy(BuscarImagenCategoria.FileName, RUTA & "\Imagenes\CAT" & Imagen & "." & Extension.Last, True)
                '        End If
                '    Catch
                '        Err.Clear()
                '    End Try
                Try
                    If Not CategoriaTemporal = "" Then
                        Dim ImagenTemporal() As String = CategoriaTemporal.Split(".")
                        File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & CategoriaTemporal, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CAT" & Imagen & "." & ImagenTemporal.Last, True)
                        CategoriaTemporal = ""
                        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                            Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                            Dim RUTA As String = Archivo.ReadLine
                            File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & CategoriaTemporal, RUTA & "\Imagenes\CAT" & Imagen & "." & ImagenTemporal.Last, True)
                        End If
                    End If
                Catch
                    Err.Clear()
                End Try
                Agregar_BD("Insert Into Categorias values('" & Imagen & "','" & Cmb_Categorias.Text & "','" & "CAT" & Imagen & "')")
                Categoria = Imagen
            Else
                'Notificacion("Falta Imagen", "No se puede continuar sin haber asignado una imagen a la categoria.", 2, 3000)
                'Exit Sub
            End If
            'End If
            'Dim BuscarImagenProducto As New OpenFileDialog
            'BuscarImagenProducto.Filter = "Archivos JPG (*.jpg)|*.jpg|Archivos BMP (*.bmp)|*.bmp"
            'BuscarImagenProducto.FilterIndex = 2
            'BuscarImagenProducto.CheckFileExists = True
            'BuscarImagenProducto.CheckPathExists = True
            'BuscarImagenProducto.Title = "Seleccion la imagen del producto."
            'If BuscarImagenProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    Imagen = ObtenerConsecutivoProducto()
            '    Dim Extension() As String = BuscarImagenProducto.SafeFileName.Split(".")
            '    Try
            '        File.Copy(BuscarImagenProducto.FileName, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\P" & Imagen & "." & Extension.Last, True)
            '        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
            '            Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
            '            Dim RUTA As String = Archivo.ReadLine
            '            File.Copy(BuscarImagenProducto.FileName, RUTA & "\Imagenes\P" & Imagen & "." & Extension.Last, True)
            '        End If
            '    Catch
            '        Err.Clear()
            '    End Try
            'Else
            '    Notificacion("Falta Imagen", "No se puede continuar sin haber asignado una imagen al producto.", 2, 3000)
            '    Exit Sub
            'End If
            Try
                If Not ProductoTemporal = "" Then
                    Dim ImagenTemporal() As String = ProductoTemporal.Split(".")
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & ProductoTemporal, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\P" & Txt_Codigo.Text & "." & ImagenTemporal.Last, True)
                    ProductoTemporal = ""
                    If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                        Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                        Dim RUTA As String = Archivo.ReadLine
                        File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & ProductoTemporal, RUTA & "\Imagenes\P" & Txt_Codigo.Text & "." & ImagenTemporal.Last, True)
                    End If
                End If
            Catch
                Err.Clear()
            End Try
            NuevoProducto(Txt_Codigo.Text, Txt_Producto.Text, Txt_Precio.Text, Categoria, Imagen, "")
            Panel_Categorias.Enabled = True
            Panel_Productos.Enabled = True
            Btn_Eliminar.Enabled = True
            Btn_Modificar.Enabled = True
            Btn_Nuevo.Text = "Nuevo"
            Btn_Salir.Text = "Salir"
            Txt_Codigo.Enabled = True
            Cmb_Categorias.DropDownStyle = ComboBoxStyle.DropDownList
            ObtenerTodosProductos()
            Cargar_Categorias()
            Panel_Productos.Controls.Clear()
            AGAIN()
            Cargar_CmbCategorias()
            Txt_Codigo.Text = ""
            Txt_Precio.Text = ""
            Txt_Producto.Text = ""
            Cmb_Categorias.Text = ""
        End If
    End Sub
    Private Sub NuevoProducto(ByVal Codigo As String, ByVal Descripcion As String, ByVal Precio As String, ByVal CodigoCat As String, ByVal Imagen As String, ByVal Observaciones As String)
        Agregar_BD("Insert into Articulos values('" & Codigo & "','" & Descripcion & "','" & Precio & "','" & CodigoCat & "','" & Imagen & "','" & Observaciones & "')")
    End Sub
    Private Sub ModificarProducto(ByVal Codigo As String, ByVal Descripcion As String, ByVal Precio As String, ByVal CodigoCat As String, ByVal Imagen As String, ByVal Observaciones As String)
        If Imagen = "" Then
            Modificar_BD("Update Articulos set art_descripcion='" & Descripcion & "',art_precio='" & Precio & "',cat_codigo='" & CodigoCat & "',art_observaciones='" & Observaciones & "' Where art_codigo='" & Codigo & "'")
        Else
            Modificar_BD("Update Articulos set art_descripcion='" & Descripcion & "',art_precio='" & Precio & "',cat_codigo='" & CodigoCat & "',art_imagen='" & Imagen & "',art_observaciones='" & Observaciones & "' Where art_codigo='" & Codigo & "'")
        End If
    End Sub
    Private Sub EliminarImagen()
        Try
            Dim ArchivosLocales() As String
            ArchivosLocales = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
            Dim Existe As Boolean = False
            Dim Ubicacion As Integer = 0
            Dim Foto() As String
            For A = 0 To ArchivosLocales.Length - 1
                Foto = ArchivosLocales(A).Split("\")
                Foto = Foto.Last.Split(".")
                If Foto(0) = "P" & Txt_Codigo.Text Then
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & Foto(0) & "." & Foto(1))
                    If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                        Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                        Dim RUTA As String = Archivo.ReadLine
                        File.Delete(RUTA & "\Imagenes\" & Foto(0) & "." & Foto(1))
                    End If
                End If
            Next
        Catch
            Err.Clear()
        End Try
    End Sub
    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If MsgBox("¿Esta seguro que desea eliminar este articulo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Articulo #" & Txt_Codigo.Text) = MsgBoxResult.No Then Exit Sub
        EliminarArticulo(Txt_Codigo.Text)
        EliminarImagen()
        Panel_Productos.Controls.Clear()
        Panel_Categorias.Controls.Clear()
        ObtenerTodosProductos()
        Cargar_Categorias()
        AGAIN()
        Txt_Codigo.Text = ""
        Txt_Precio.Text = ""
        Txt_Producto.Text = ""
        Cmb_Categorias.Text = ""
    End Sub
    Private Sub Btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modificar.Click
        If Btn_Modificar.Text = "Modificar" Then
            If Txt_Producto.Text = "" Then Exit Sub
            Panel_Categorias.Enabled = False
            Panel_Productos.Enabled = False
            Btn_Eliminar.Enabled = False
            Btn_Nuevo.Enabled = False
            Btn_Salir.Text = "Cancelar"
            Btn_Modificar.Text = "Guardar"
            Txt_Codigo.Enabled = False
            'Txt_Codigo.Text = ObtenerConsecutivoProducto()
            Cmb_Categorias.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf Btn_Modificar.Text = "Guardar" Then
            If Txt_Producto.Text = "" Then MsgBox("¡Debe completar todos los campos!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            If Txt_Precio.Text = "" Or Txt_Precio.Text = "0" Then MsgBox("¡El precio debe ser mayor a cero!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            If Txt_Codigo.Text = "" Then MsgBox("¡Debe completar todos los campos!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            If Cmb_Categorias.Text = "" Then MsgBox("¡Debe completar todos los campos!", MsgBoxStyle.Exclamation, "¡Faltan Datos!") : Exit Sub
            Dim Categoria As String = VerificarCategoria(Cmb_Categorias.Text)
            Dim Imagen As String = Txt_Codigo.Text
            If Categoria = "" Then
                'Dim BuscarImagenCategoria As New OpenFileDialog
                'BuscarImagenCategoria.Filter = "Archivos JPG (*.jpg)|*.jpg|Archivos BMP (*.bmp)|*.bmp"
                'BuscarImagenCategoria.FilterIndex = 1
                'BuscarImagenCategoria.CheckFileExists = True
                'BuscarImagenCategoria.CheckPathExists = True
                'BuscarImagenCategoria.Title = "Seleccione la imagen de la categoria."
                'If BuscarImagenCategoria.ShowDialog() = Windows.Forms.DialogResult.OK Then
                '    Dim Extension() As String = BuscarImagenCategoria.SafeFileName.Split(".")
                '    Imagen = ObtenerConsecutivoCategoria()
                '    Try
                '        File.Copy(BuscarImagenCategoria.FileName, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CAT" & Imagen & "." & Extension.Last, True)
                '        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                '            Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                '            Dim RUTA As String = Archivo.ReadLine
                '            File.Copy(BuscarImagenCategoria.FileName, RUTA & "\Imagenes\CAT" & Imagen & "." & Extension.Last, True)
                '        End If
                '    Catch
                '        Err.Clear()
                '    End Try
                Try
                    If Not CategoriaTemporal = "" Then
                        Dim ImagenTemporal() As String = CategoriaTemporal.Split(".")
                        File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & CategoriaTemporal, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CAT" & Categoria & "." & ImagenTemporal.Last, True)
                        CategoriaTemporal = ""
                        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                            Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                            Dim RUTA As String = Archivo.ReadLine
                            File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & CategoriaTemporal, RUTA & "\Imagenes\CAT" & Imagen & "." & ImagenTemporal.Last, True)
                        End If
                    End If
                Catch
                    Err.Clear()
                End Try
                Agregar_BD("Insert Into Categorias values('" & Imagen & "','" & Cmb_Categorias.Text & "','" & "CAT" & Imagen & "')")
                Categoria = Imagen
                'Else
                '    Notificacion("Falta Imagen", "No se puede continuar sin haber asignado una imagen a la categoria.", 2, 3000)
                '    Exit Sub
                'End If
            End If
            Try
                If Not CategoriaTemporal = "" Then
                    Dim ImagenTemporal() As String = CategoriaTemporal.Split(".")
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & CategoriaTemporal, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CAT" & Categoria & "." & ImagenTemporal.Last, True)
                    CategoriaTemporal = ""
                    If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                        Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                        Dim RUTA As String = Archivo.ReadLine
                        File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & CategoriaTemporal, RUTA & "\Imagenes\CAT" & Imagen & "." & ImagenTemporal.Last, True)
                    End If
                End If
            Catch
                Err.Clear()
            End Try
            'If MsgBox("¿Desea modificar la imagen del producto?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Imagen Producto") = MsgBoxResult.Ok Then
            '    Dim BuscarImagenProducto As New OpenFileDialog
            '    BuscarImagenProducto.Filter = "Archivos JPG (*.jpg)|*.jpg|Archivos BMP (*.bmp)|*.bmp"
            '    BuscarImagenProducto.FilterIndex = 1
            '    BuscarImagenProducto.CheckFileExists = True
            '    BuscarImagenProducto.CheckPathExists = True
            '    BuscarImagenProducto.Title = "Seleccione la imagen del producto."
            '    If BuscarImagenProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '        Imagen = ObtenerConsecutivoProducto()
            '        Dim Extension() As String = BuscarImagenProducto.SafeFileName.Split(".")
            '        Try
            '            File.Copy(BuscarImagenProducto.FileName, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\P" & Imagen & "." & Extension.Last, True)
            '            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
            '                Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
            '                Dim RUTA As String = Archivo.ReadLine
            '                File.Copy(BuscarImagenProducto.FileName, RUTA & "\Imagenes\P" & Imagen & "." & Extension.Last, True)
            '            End If
            '        Catch
            '            Err.Clear()
            '        End Try
            '    Else
            '        Notificacion("Falta Imagen", "No se puede continuar sin haber asignado una imagen al producto.", 2, 3000)
            '        Exit Sub
            '    End If
            '    ModificarProducto(Txt_Codigo.Text, Txt_Producto.Text, Txt_Precio.Text, Categoria, Imagen, "")
            'Else
            '    ModificarProducto(Txt_Codigo.Text, Txt_Producto.Text, Txt_Precio.Text, Categoria, "", "")
            'End If
            Try
                If Not ProductoTemporal = "" Then
                    Dim ImagenTemporal() As String = ProductoTemporal.Split(".")
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & ProductoTemporal, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\P" & Txt_Codigo.Text & "." & ImagenTemporal.Last, True)
                    ProductoTemporal = ""
                    If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                        Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                        Dim RUTA As String = Archivo.ReadLine
                        File.Copy(AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & ProductoTemporal, RUTA & "\Imagenes\P" & Txt_Codigo.Text & "." & ImagenTemporal.Last, True)
                    End If
                End If
            Catch
                Err.Clear()
            End Try
            ModificarProducto(Txt_Codigo.Text, Txt_Producto.Text, Txt_Precio.Text, Categoria, Imagen, "")
            Panel_Categorias.Enabled = True
            Panel_Productos.Enabled = True
            Btn_Eliminar.Enabled = True
            Btn_Nuevo.Enabled = True
            Btn_Modificar.Text = "Modificar"
            Btn_Salir.Text = "Salir"
            Txt_Codigo.Enabled = True
            Cmb_Categorias.DropDownStyle = ComboBoxStyle.DropDownList
            ObtenerTodosProductos()
            Cargar_Categorias()
            Panel_Productos.Controls.Clear()
            AGAIN()
            Cargar_CmbCategorias()
            Txt_Codigo.Text = ""
            Txt_Precio.Text = ""
            Txt_Producto.Text = ""
            Cmb_Categorias.Text = ""
        End If
    End Sub
    Private Sub AGAIN()
        On Error Resume Next
        For Each Categoria2 As PictureBox In Panel_Categorias.Controls
            AddHandler Categoria2.Click, AddressOf Cargar_Productos_Categoria
        Next
        Panel_Categorias.Enabled = True
    End Sub
    Private Sub Txt_Precio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Precio.KeyPress
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
    Private Sub Cmb_Categorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Categorias.SelectedIndexChanged
        Try
            For A = 0 To Categorias.Length - 1
                If Categorias(A).Nombre = Cmb_Categorias.Text Then
                    Dim Imagenes() As String = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
                    For B = 0 To Imagenes.Length - 1
                        Dim Imagen() As String = Imagenes(B).Split("\")
                        Imagen = Imagen.Last.Split(".")
                        If Imagen(0) = "CAT" & Categorias(A).Codigo Then
                            Imagen = Imagenes(B).Split("\")
                            Pct_Categoria.ImageLocation = (AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & Imagen.Last)
                        End If
                    Next
                    Pct_Categoria.Load()
                    Exit For
                ElseIf A = Categorias.Length - 1 Then
                    Pct_Categoria.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
                End If
            Next
        Catch
            Err.Clear()
            Pct_Categoria.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "no_disponible.jpg"
        End Try
    End Sub
    Private Sub Pct_Producto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pct_Producto.Click
        If (Btn_Modificar.Text = "Guardar") Xor (Btn_Nuevo.Text = "Guardar") Then  Else Exit Sub
        Dim Imagen As String = Txt_Codigo.Text
        Dim BuscarImagenProducto As New OpenFileDialog
        If BuscarImagenProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim Extension() As String = BuscarImagenProducto.SafeFileName.Split(".")
            'Imagen = ObtenerConsecutivoCategoria()
            Try
                File.Copy(BuscarImagenProducto.FileName, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\PTemporalImage." & Extension.Last, True)
                ProductoTemporal = "PTemporalImage." & Extension.Last
                Pct_Producto.ImageLocation = BuscarImagenProducto.FileName
                'Pct_Producto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "Imagenes\P" & Imagen & "." & Extension.Last
                Pct_Producto.Load()
                If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                    Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                    Dim RUTA As String = Archivo.ReadLine
                    File.Copy(BuscarImagenProducto.FileName, RUTA & "\Imagenes\PTemporalImage." & Extension.Last, True)
                End If
            Catch
                Err.Clear()
                Notificacion("ERROR", "Ocurrio un error al intentar cargar la imagen", 3, 5000)
            End Try
        End If
    End Sub
    Private Sub Pct_Categoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pct_Categoria.Click
        If (Btn_Modificar.Text = "Guardar") Xor (Btn_Nuevo.Text = "Guardar") Then  Else Exit Sub
        Dim Imagen As String = Txt_Codigo.Text
        Dim BuscarImagenProducto As New OpenFileDialog
        If BuscarImagenProducto.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim Extension() As String = BuscarImagenProducto.SafeFileName.Split(".")
            'Imagen = ObtenerConsecutivoCategoria()
            Try
                File.Copy(BuscarImagenProducto.FileName, AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CATTemporalImage." & Extension.Last, True)
                CategoriaTemporal = "CATTemporalImage." & Extension.Last
                Pct_Categoria.ImageLocation = BuscarImagenProducto.FileName
                'Pct_Producto.ImageLocation = AppDomain.CurrentDomain.BaseDirectory & "Imagenes\CAT" & Imagen & "." & Extension.Last
                Pct_Categoria.Load()
                If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                    Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                    Dim RUTA As String = Archivo.ReadLine
                    File.Copy(BuscarImagenProducto.FileName, RUTA & "\Imagenes\CATTemporalImage." & Extension.Last, True)
                End If
            Catch
                Err.Clear()
                Notificacion("ERROR", "Ocurrio un error al intentar cargar la imagen", 3, 5000)
            End Try
        End If
    End Sub
End Class