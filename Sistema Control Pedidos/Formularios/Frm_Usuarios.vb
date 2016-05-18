Public Class Frm_Usuarios
    Dim cuenta, clave As String
    Private Sub Btn_Incluir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Nuevo.Click
        Txt_User.Text = ""
        Txt_Clave.Text = ""
        Txt_Nom.Text = ""
        Txt_User.ReadOnly = False
        Txt_Clave.ReadOnly = False
        Txt_Nom.ReadOnly = False
        Btn_Nuevo.Enabled = False
        Btn_Mod.Enabled = True
        Btn_Cancelar.Visible = True
        Btn_Guardar.Visible = True
        Lbl_clave.Visible = True
        Lbl_nom.Visible = True
        Txt_User.Visible = True
        Txt_Clave.Visible = True
        Txt_Nom.Visible = True
        Cmb_User.Visible = False
        Btn_Guardar.Text = "Guardar"
    End Sub

    Private Sub Btn_Mod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Mod.Click
        Cargar_Usuarios()
        Txt_User.ReadOnly = False
        Txt_Clave.ReadOnly = False
        Txt_Nom.ReadOnly = False
        Btn_Mod.Enabled = False
        Btn_Nuevo.Enabled = True
        Btn_Eli.Enabled = True
        Btn_Cancelar.Visible = True
        Btn_Guardar.Visible = True
        cuenta = Txt_User.Text
        clave = Txt_Clave.Text
        Lbl_clave.Visible = True
        Lbl_nom.Visible = True
        Txt_User.Visible = True
        Txt_Clave.Visible = True
        Txt_Nom.Visible = True
        Cmb_User.Visible = False
        Btn_Guardar.Text = "Guardar"
    End Sub

    Private Sub Btn_End_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_End.Click
        Me.Close()
    End Sub

    Private Sub Btn_Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Guardar.Click
        If Txt_User.Text = "" Then
            MsgBox("¡El campo usuario no puede estar vacio!", MsgBoxStyle.Exclamation, "Usuarios")
            Exit Sub
        End If
        If Txt_Clave.Text = "" Then
            MsgBox("¡El campo clave no puede estar vacio!", MsgBoxStyle.Exclamation, "Usuarios")
            Exit Sub
        End If
        If Txt_Nom.Text = "" Then
            MsgBox("¡El campo nombre no puede estar vacio!", MsgBoxStyle.Exclamation, "Usuarios")
            Exit Sub
        End If
        If Btn_Nuevo.Enabled = False Then
            If Existe_Usuario(Txt_User.Text) = True Then
                MsgBox("¡El usuario digitado ya existe!", MsgBoxStyle.Exclamation, "Usuarios")
                Exit Sub
            End If
        ElseIf Btn_Mod.Enabled = False Then
            If cuenta <> Txt_User.Text Then
                If Existe_Usuario(Txt_User.Text) = True Then
                    MsgBox("¡El usuario digitado ya existe!", MsgBoxStyle.Exclamation, "Usuarios")
                    Exit Sub
                End If
            End If
        End If
        If Btn_Mod.Enabled = False Then
            If clave <> Txt_Clave.Text Then
back:
                Dim valor As String = InputBox("Debe confirmar la nueva clave" & Chr(13) & "Digite la anterior clave", "Usuarios", "", , )
                If String.IsNullOrEmpty(valor) Then
                    Exit Sub
                End If
                If valor <> clave Then
                    MsgBox("¡Clave incorecta!", MsgBoxStyle.Critical, "Usuarios")
                    GoTo back
                End If
            End If
            Btn_Mod.Enabled = True
            ID_Usuario = Txt_User.Text
            MESAJEFUNCION = 1
            Modificar_BD("update Usuarios set cuenta='" & Txt_User.Text & "',clave='" & Txt_Clave.Text & "',nombre='" & Txt_Nom.Text & "' where cuenta='" & cuenta & "'")
            Cargar_Usuarios()
        End If
        Txt_User.ReadOnly = True
        Txt_Clave.ReadOnly = True
        Txt_Nom.ReadOnly = True
        Btn_Cancelar.Visible = False
        Btn_Guardar.Visible = False
        If Btn_Nuevo.Enabled = False Then
            Btn_Nuevo.Enabled = True
            MESAJEFUNCION = 1
            Agregar_BD("Insert into Usuarios Values ('" & Txt_User.Text & "','" & Txt_Clave.Text & "','" & Txt_Nom.Text & "')")
            Cargar_Usuarios()
        End If

        If Btn_Eli.Enabled = False Then
            If MsgBox("¿Esta seguro que desea eliminar el usuario seleccionado?", MsgBoxStyle.YesNo, "Usuarios") = MsgBoxResult.Yes Then
                Eliminar_BD("delete * from Usuarios where cuenta='" & Cmb_User.Text & "'", 1)
                Btn_Eli.Enabled = True
                Cmb_User.Visible = False
                Lbl_clave.Visible = True
                Lbl_nom.Visible = True
                Txt_User.Visible = True
                Txt_Clave.Visible = True
                Txt_Nom.Visible = True
                Btn_Eli.Enabled = True
                Btn_Guardar.Text = "Guardar"
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Btn_Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancelar.Click
        Txt_User.ReadOnly = True
        Txt_Clave.ReadOnly = True
        Txt_Nom.ReadOnly = True
        Btn_Cancelar.Visible = False
        Btn_Guardar.Visible = False
        If Btn_Nuevo.Enabled = False Then
            Btn_Nuevo.Enabled = True
        End If
        If Btn_Mod.Enabled = False Then
            Btn_Mod.Enabled = True
        End If
        If Btn_Eli.Enabled = False Then
            Btn_Eli.Enabled = True
            Cmb_User.Visible = False
            Lbl_clave.Visible = True
            Lbl_nom.Visible = True
            Txt_User.Visible = True
            Txt_Clave.Visible = True
            Txt_Nom.Visible = True
            Btn_Eli.Enabled = True
            Btn_Guardar.Text = "Guardar"
        End If
        Cargar_Usuarios()
    End Sub

    Private Sub Frm_Usuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Cargar_Usuarios()
        Btn_Nuevo.Enabled = True
        Btn_Mod.Enabled = True
        Btn_Eli.Enabled = True
        Cmb_User.Visible = False
        Txt_User.ReadOnly = True
        Txt_Clave.ReadOnly = True
        Txt_Nom.ReadOnly = True
        Btn_Cancelar.Visible = False
        Btn_Guardar.Visible = False
        Lbl_clave.Visible = True
        Lbl_nom.Visible = True
        Txt_User.Visible = True
        Txt_Clave.Visible = True
        Txt_Nom.Visible = True
    End Sub

    Private Sub Btn_Eli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Eli.Click
        If Cargar_Usuarios_Eliminar() = False Then
            MsgBox("¡No existen mas usuarios aparte del actual!", MsgBoxStyle.Exclamation, "Usuarios")
            Exit Sub
        End If
        Cmb_User.Visible = True
        Lbl_clave.Visible = False
        Lbl_nom.Visible = False
        Txt_User.Visible = False
        Txt_Clave.Visible = False
        Txt_Nom.Visible = False
        Btn_Eli.Enabled = False
        Btn_Mod.Enabled = True
        Btn_Nuevo.Enabled = True
        Btn_Guardar.Text = "Eliminar"
        Btn_Cancelar.Visible = True
        Btn_Guardar.Visible = True
        Cargar_Usuarios_Eliminar()
    End Sub
End Class