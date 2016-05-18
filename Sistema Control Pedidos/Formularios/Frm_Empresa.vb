Public Class Frm_Empresa
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        If Btn_Salir.Text = "Salir" Then Me.Close()
        Btn_Modificar.Text = "Modificar"
        Btn_Salir.Text = "Salir"
        With Me
            .Txt_Cedula.Text = Empresa.Cedula
            .Txt_Nombre.Text = Empresa.Nombre
            .Txt_Telefono.Text = Empresa.Telefono
            .Txt_Fax.Text = Empresa.Fax
            .Txt_Correo.Text = Empresa.Correo
            .Txt_Direccion.Text = Empresa.Direccion
            .Txt_Cedula.ReadOnly = True
            .Txt_Nombre.ReadOnly = True
            .Txt_Telefono.ReadOnly = True
            .Txt_Fax.ReadOnly = True
            .Txt_Correo.ReadOnly = True
            .Txt_Direccion.ReadOnly = True
        End With
    End Sub
    Private Sub Frm_Empresa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CargarDatosEmpresa()
    End Sub
    Private Sub Frm_Empresa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDatosEmpresa()
    End Sub
    Private Sub Btn_Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Modificar.Click
        If Btn_Modificar.Text = "Modificar" Then
            Btn_Modificar.Text = "Guardar"
            Btn_Salir.Text = "Cancelar"
            With Me
                .Txt_Cedula.ReadOnly = False
                .Txt_Nombre.ReadOnly = False
                .Txt_Telefono.ReadOnly = False
                .Txt_Fax.ReadOnly = False
                .Txt_Correo.ReadOnly = False
                .Txt_Direccion.ReadOnly = False
            End With
        ElseIf Btn_Modificar.Text = "Guardar" Then
            If Txt_Cedula.Text = "" Then MsgBox("Debe digitar una cédula.", MsgBoxStyle.Exclamation, "¡Faltan Datos!")
            If Txt_Nombre.Text = "" Then MsgBox("Debe digitar un nombre.", MsgBoxStyle.Exclamation, "¡Faltan Datos!")
            If Modificar_BD("Update Empresa Set cedula_juridica='" & Txt_Cedula.Text & "',nombre='" & Txt_Nombre.Text & "',telefono=" & Txt_Telefono.Text & ",fax=" & Txt_Fax.Text & ",correo='" & Txt_Correo.Text & "',dirrecion='" & Txt_Direccion.Text & "' Where Registro=0") = True Then
                Btn_Modificar.Text = "Modificar"
                Btn_Salir.Text = "Salir"
                With Me
                    .Txt_Cedula.ReadOnly = True
                    .Txt_Nombre.ReadOnly = True
                    .Txt_Telefono.ReadOnly = True
                    .Txt_Fax.ReadOnly = True
                    .Txt_Correo.ReadOnly = True
                    .Txt_Direccion.ReadOnly = True
                End With
            Else
                Exit Sub
            End If
            'AQUI VA LA FUNCIÓN MODIFICAR
            'CON UN IF
            'EJEMPLO
            'IF FUNCION = TRUE THEN HACE LO DE ABAJO
            'ELSE NOTIFICACION(MENCION EL ERROR)
            'TRUE = GUARDO      FALSE = NO GUARDO
            'SOLO PUEDE EXISTIR UN REGISTRO EN LA BASE DE DATOS
        End If
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
    Private Sub Txt_Correo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Correo.KeyPress
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub Txt_Fax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Fax.KeyPress
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