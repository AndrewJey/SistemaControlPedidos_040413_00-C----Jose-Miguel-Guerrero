<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Usuarios))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Btn_End = New System.Windows.Forms.Button
        Me.Btn_Eli = New System.Windows.Forms.Button
        Me.Btn_Mod = New System.Windows.Forms.Button
        Me.Btn_Nuevo = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Cmb_User = New System.Windows.Forms.ComboBox
        Me.Txt_Nom = New System.Windows.Forms.TextBox
        Me.Txt_Clave = New System.Windows.Forms.TextBox
        Me.Txt_User = New System.Windows.Forms.TextBox
        Me.Lbl_nom = New System.Windows.Forms.Label
        Me.Lbl_clave = New System.Windows.Forms.Label
        Me.Lbl_user = New System.Windows.Forms.Label
        Me.Btn_Cancelar = New System.Windows.Forms.Button
        Me.Btn_Guardar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.page_bg
        Me.Panel1.Controls.Add(Me.Btn_End)
        Me.Panel1.Controls.Add(Me.Btn_Eli)
        Me.Panel1.Controls.Add(Me.Btn_Mod)
        Me.Panel1.Controls.Add(Me.Btn_Nuevo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(712, 88)
        Me.Panel1.TabIndex = 0
        '
        'Btn_End
        '
        Me.Btn_End.Location = New System.Drawing.Point(579, 12)
        Me.Btn_End.Name = "Btn_End"
        Me.Btn_End.Size = New System.Drawing.Size(121, 67)
        Me.Btn_End.TabIndex = 3
        Me.Btn_End.Text = "Salir"
        Me.Btn_End.UseVisualStyleBackColor = True
        '
        'Btn_Eli
        '
        Me.Btn_Eli.Location = New System.Drawing.Point(266, 12)
        Me.Btn_Eli.Name = "Btn_Eli"
        Me.Btn_Eli.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Eli.TabIndex = 2
        Me.Btn_Eli.Text = "Eliminar"
        Me.Btn_Eli.UseVisualStyleBackColor = True
        '
        'Btn_Mod
        '
        Me.Btn_Mod.Location = New System.Drawing.Point(139, 12)
        Me.Btn_Mod.Name = "Btn_Mod"
        Me.Btn_Mod.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Mod.TabIndex = 1
        Me.Btn_Mod.Text = "Modificar"
        Me.Btn_Mod.UseVisualStyleBackColor = True
        '
        'Btn_Nuevo
        '
        Me.Btn_Nuevo.Location = New System.Drawing.Point(12, 12)
        Me.Btn_Nuevo.Name = "Btn_Nuevo"
        Me.Btn_Nuevo.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Nuevo.TabIndex = 0
        Me.Btn_Nuevo.Text = "Nuevo"
        Me.Btn_Nuevo.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Sistema_Control_Pedidos.My.Resources.Resources.fondo_madera_negro
        Me.Panel2.Controls.Add(Me.Cmb_User)
        Me.Panel2.Controls.Add(Me.Txt_Nom)
        Me.Panel2.Controls.Add(Me.Txt_Clave)
        Me.Panel2.Controls.Add(Me.Txt_User)
        Me.Panel2.Controls.Add(Me.Lbl_nom)
        Me.Panel2.Controls.Add(Me.Lbl_clave)
        Me.Panel2.Controls.Add(Me.Lbl_user)
        Me.Panel2.Controls.Add(Me.Btn_Cancelar)
        Me.Panel2.Controls.Add(Me.Btn_Guardar)
        Me.Panel2.Location = New System.Drawing.Point(0, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(712, 172)
        Me.Panel2.TabIndex = 1
        '
        'Cmb_User
        '
        Me.Cmb_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_User.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_User.FormattingEnabled = True
        Me.Cmb_User.Location = New System.Drawing.Point(94, 14)
        Me.Cmb_User.Name = "Cmb_User"
        Me.Cmb_User.Size = New System.Drawing.Size(176, 26)
        Me.Cmb_User.TabIndex = 0
        Me.Cmb_User.Visible = False
        '
        'Txt_Nom
        '
        Me.Txt_Nom.Location = New System.Drawing.Point(94, 132)
        Me.Txt_Nom.MaxLength = 50
        Me.Txt_Nom.Name = "Txt_Nom"
        Me.Txt_Nom.ReadOnly = True
        Me.Txt_Nom.Size = New System.Drawing.Size(350, 20)
        Me.Txt_Nom.TabIndex = 2
        '
        'Txt_Clave
        '
        Me.Txt_Clave.Location = New System.Drawing.Point(94, 74)
        Me.Txt_Clave.MaxLength = 10
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Clave.ReadOnly = True
        Me.Txt_Clave.Size = New System.Drawing.Size(176, 20)
        Me.Txt_Clave.TabIndex = 1
        '
        'Txt_User
        '
        Me.Txt_User.Location = New System.Drawing.Point(94, 18)
        Me.Txt_User.MaxLength = 20
        Me.Txt_User.Name = "Txt_User"
        Me.Txt_User.ReadOnly = True
        Me.Txt_User.Size = New System.Drawing.Size(176, 20)
        Me.Txt_User.TabIndex = 22
        '
        'Lbl_nom
        '
        Me.Lbl_nom.AutoSize = True
        Me.Lbl_nom.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_nom.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lbl_nom.Location = New System.Drawing.Point(12, 130)
        Me.Lbl_nom.Name = "Lbl_nom"
        Me.Lbl_nom.Size = New System.Drawing.Size(76, 20)
        Me.Lbl_nom.TabIndex = 21
        Me.Lbl_nom.Text = "Nombre:"
        '
        'Lbl_clave
        '
        Me.Lbl_clave.AutoSize = True
        Me.Lbl_clave.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_clave.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lbl_clave.Location = New System.Drawing.Point(12, 74)
        Me.Lbl_clave.Name = "Lbl_clave"
        Me.Lbl_clave.Size = New System.Drawing.Size(58, 20)
        Me.Lbl_clave.TabIndex = 20
        Me.Lbl_clave.Text = "Clave:"
        '
        'Lbl_user
        '
        Me.Lbl_user.AutoSize = True
        Me.Lbl_user.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_user.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Lbl_user.Location = New System.Drawing.Point(12, 16)
        Me.Lbl_user.Name = "Lbl_user"
        Me.Lbl_user.Size = New System.Drawing.Size(76, 20)
        Me.Lbl_user.TabIndex = 19
        Me.Lbl_user.Text = "Usuario:"
        '
        'Btn_Cancelar
        '
        Me.Btn_Cancelar.Location = New System.Drawing.Point(579, 93)
        Me.Btn_Cancelar.Name = "Btn_Cancelar"
        Me.Btn_Cancelar.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Cancelar.TabIndex = 4
        Me.Btn_Cancelar.Text = "Cancelar"
        Me.Btn_Cancelar.UseVisualStyleBackColor = True
        Me.Btn_Cancelar.Visible = False
        '
        'Btn_Guardar
        '
        Me.Btn_Guardar.Location = New System.Drawing.Point(579, 7)
        Me.Btn_Guardar.Name = "Btn_Guardar"
        Me.Btn_Guardar.Size = New System.Drawing.Size(121, 67)
        Me.Btn_Guardar.TabIndex = 3
        Me.Btn_Guardar.Text = "Guardar"
        Me.Btn_Guardar.UseVisualStyleBackColor = True
        Me.Btn_Guardar.Visible = False
        '
        'Frm_Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 259)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Frm_Usuarios"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Btn_End As System.Windows.Forms.Button
    Friend WithEvents Btn_Eli As System.Windows.Forms.Button
    Friend WithEvents Btn_Mod As System.Windows.Forms.Button
    Friend WithEvents Btn_Nuevo As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancelar As System.Windows.Forms.Button
    Friend WithEvents Btn_Guardar As System.Windows.Forms.Button
    Friend WithEvents Lbl_user As System.Windows.Forms.Label
    Friend WithEvents Txt_Nom As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Clave As System.Windows.Forms.TextBox
    Friend WithEvents Txt_User As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_nom As System.Windows.Forms.Label
    Friend WithEvents Lbl_clave As System.Windows.Forms.Label
    Friend WithEvents Cmb_User As System.Windows.Forms.ComboBox
End Class
