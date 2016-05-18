Public Class Frm_Empleados
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        If Btn_Salir.Text = "Salir" Then Me.Close()
        Txt_Codigo.Text = ""
        Txt_Apellidos.Text = ""
        Txt_Cedula.Text = ""
        Txt_Direccion.Text = ""
        Txt_Nombre.Text = ""
        Txt_Telefono.Text = ""
        Btn_Eliminar.Enabled = False
        Btn_Nuevo.Enabled = False
        Btn_Salir.Text = "Salir"
        Txt_Apellidos.ReadOnly = True
        Txt_Cedula.ReadOnly = True
        Txt_Direccion.ReadOnly = True
        Txt_Nombre.ReadOnly = True
        Txt_Telefono.ReadOnly = True
        Btn_Eliminar.Enabled = True
        Btn_Modificar.Enabled = True
        Lst_Empleados.Enabled = True
        Btn_Eliminar.Enabled = True
        Btn_Nuevo.Enabled = True
        Btn_Modificar.Text = "Modificar"
        Btn_Nuevo.Text = "Nuevo"
    End Sub
    Private Sub Frm_Empleados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarEmpleados()
    End Sub
    Public Sub CargarEmpleados()
        ObtenerTodosEmpleados()
        Lst_Empleados.Items.Clear()
        For A = 0 To Empleados.Length - 1
            If Empleados(A).Codigo = "" Then Continue For
            Lst_Empleados.Items.Add(Empleados(A).Codigo & "-" & UCase(Empleados(A).Nombre))
        Next
    End Sub
    Private Sub OFFONControls(ByVal Boton As String)
        If Boton = "Btn_Nuevo" Then
            If Btn_Nuevo.Text = "Guardar" Then
                Btn_Eliminar.Enabled = True
                Btn_Modificar.Enabled = True
                Btn_Salir.Text = "Salir"
                Txt_Apellidos.ReadOnly = True
                Txt_Cedula.ReadOnly = True
                Txt_Direccion.ReadOnly = True
                Txt_Nombre.ReadOnly = True
                Txt_Telefono.ReadOnly = True
                Txt_Codigo.Text = ""
                Txt_Apellidos.Text = ""
                Txt_Cedula.Text = ""
                Txt_Direccion.Text = ""
                Txt_Nombre.Text = ""
                Txt_Telefono.Text = ""
                Btn_Nuevo.Text = "Nuevo"
                Lst_Empleados.Enabled = True
            ElseIf Btn_Nuevo.Text = "Nuevo" Then
                Txt_Apellidos.Text = ""
                Txt_Cedula.Text = ""
                Txt_Direccion.Text = ""
                Txt_Nombre.Text = ""
                Txt_Telefono.Text = ""
                Btn_Nuevo.Text = "Guardar"
                Txt_Apellidos.ReadOnly = False
                Txt_Cedula.ReadOnly = False
                Txt_Direccion.ReadOnly = False
                Txt_Nombre.ReadOnly = False
                Txt_Telefono.ReadOnly = False
                Btn_Eliminar.Enabled = False
                Btn_Modificar.Enabled = False
                Btn_Salir.Text = "Cancelar"
                Lst_Empleados.Enabled = False
            End If
        End If
        If Boton = "Btn_Modificar" Then
            If Btn_Modificar.Text = "Guardar" Then
                Btn_Modificar.Text = "Modificar"
                Btn_Eliminar.Enabled = False
                Btn_Nuevo.Enabled = False
                Btn_Salir.Text = "Salir"
                Txt_Apellidos.ReadOnly = True
                Txt_Cedula.ReadOnly = True
                Txt_Direccion.ReadOnly = True
                Txt_Nombre.ReadOnly = True
                Txt_Telefono.ReadOnly = True
                Btn_Eliminar.Enabled = True
                Btn_Nuevo.Enabled = True
                Lst_Empleados.Enabled = True
            ElseIf Btn_Modificar.Text = "Modificar" Then
                Btn_Modificar.Text = "Guardar"
                Btn_Eliminar.Enabled = True
                Btn_Nuevo.Enabled = True
                Btn_Salir.Text = "Cancelar"
                Txt_Apellidos.ReadOnly = False
                Txt_Cedula.ReadOnly = False
                Txt_Direccion.ReadOnly = False
                Txt_Nombre.ReadOnly = False
                Txt_Telefono.ReadOnly = False
                Btn_Eliminar.Enabled = False
                Btn_Nuevo.Enabled = False
                Lst_Empleados.Enabled = False
            End If
        End If
    End Sub
    Private Sub Btn_Nuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Dim crtl As Button = CType(sender, Button)
        If Btn_Nuevo.Text = "Nuevo" Then
            OFFONControls(crtl.Name)
            Txt_Codigo.Text = ObtenerConsecutivoEmpleado()
        ElseIf Btn_Nuevo.Text = "Guardar" Then
            If Txt_Apellidos.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Cedula.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Nombre.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Direccion.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Telefono.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            IngresarNuevo(Txt_Codigo.Text, Txt_Nombre.Text, Txt_Apellidos.Text, Txt_Cedula.Text, Txt_Telefono.Text, Txt_Direccion.Text)
            Lst_Empleados.Items.Add(Txt_Codigo.Text & "-" & Txt_Nombre.Text)
            OFFONControls(crtl.Name)
        End If
    End Sub
    Private Sub Btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modificar.Click
        Dim crtl As Button = CType(sender, Button)
        If Btn_Modificar.Text = "Modificar" Then
            OFFONControls(crtl.Name)
        ElseIf Btn_Modificar.Text = "Guardar" Then
            If Txt_Apellidos.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Cedula.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Nombre.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Direccion.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            If Txt_Telefono.Text = "" Then MsgBox("Debe completar todos los campos", MsgBoxStyle.Information, "Faltan Datos") : Exit Sub
            ModificarEmpleado(Txt_Codigo.Text, Txt_Nombre.Text, Txt_Apellidos.Text, Txt_Cedula.Text, Txt_Telefono.Text, Txt_Direccion.Text)
            OFFONControls(crtl.Name)
        End If
    End Sub
    Private Sub Lst_Empleados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lst_Empleados.SelectedIndexChanged
        Dim CodigoEmpleado() As String = Nothing
        Try
            CodigoEmpleado = Lst_Empleados.Items.Item(Lst_Empleados.SelectedIndex).ToString.Split("-")
            CargarEmpleado(CodigoEmpleado(0))
        Catch
            Err.Clear()
        End Try
    End Sub
    Private Sub Btn_Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eliminar.Click
        If Txt_Codigo.Text = "" Then Exit Sub
        If MsgBox("¿Esta seguro que desea eliminar este registro de la base de datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar Empleado #" & Txt_Codigo.Text) = MsgBoxResult.No Then Exit Sub
        EliminarEmpleado(Txt_Codigo.Text)
        Lst_Empleados.Items.RemoveAt(Lst_Empleados.SelectedIndex)
        Txt_Codigo.Text = ""
        Txt_Apellidos.Text = ""
        Txt_Cedula.Text = ""
        Txt_Direccion.Text = ""
        Txt_Nombre.Text = ""
        Txt_Telefono.Text = ""
    End Sub
    Private Sub IngresarNuevo(ByVal Codigo As String, ByVal Nombre As String, ByVal Apellidos As String, ByVal Cedula As String, ByVal Telefono As String, ByVal Direccion As String)
        Agregar_BD("Insert into Empleados values(" & Codigo & ",'" & Cedula & "','" & Nombre & "','" & Apellidos & "'," & Telefono & ",'" & Direccion & "')")
    End Sub
    Private Sub ModificarEmpleado(ByVal Codigo As String, ByVal Nombre As String, ByVal Apellidos As String, ByVal Cedula As String, ByVal Telefono As String, ByVal Direccion As String)
        Modificar_BD("Update Empleados Set emp_cedula='" & Cedula & "',emp_nombre='" & Nombre & "',emp_apellidos='" & Apellidos & "',emp_telefono=" & Telefono & ",emp_direccion='" & Direccion & "' Where emp_codigo='" & Codigo & "'")
    End Sub
    Private Sub Txt_Telefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Telefono.KeyPress
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
End Class