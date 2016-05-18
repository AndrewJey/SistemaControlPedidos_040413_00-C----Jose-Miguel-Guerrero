Imports System.IO
Public Class LoginForm
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Verificar_Usuario(UsernameTextBox.Text, PasswordTextBox.Text) = "" Then Notificacion("Error al iniciar sesión", "¡El Usuario o la Clave son incorrectos!" & Chr(13) & "¡Vuelva a intentarlo!", 2, 4000) : Exit Sub
        Frm_Mesas.Show()
        Me.Close()
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EXISTEDSN() = False Then
            CREAR_DSN(1, AppDomain.CurrentDomain.BaseDirectory)
        ElseIf EXISTEDSN() = True Then
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                Dim RUTA As String = Archivo.ReadLine
                CREAR_DSN(1, RUTA & "\")
            End If
        End If
        If IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory & "Imagenes") = False Then
            IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
        End If
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & "Config.cfg") = True Then
                Dim ArchivosLocales() As String
                Dim ArchivosRemotos() As String
                Dim Archivo As New StreamReader((AppDomain.CurrentDomain.BaseDirectory & "Config.cfg"))
                Dim RUTA As String = Archivo.ReadLine
                ArchivosLocales = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory & "Imagenes")
                ArchivosRemotos = Directory.GetFiles(RUTA & "\Imagenes")
                Dim Existe As Boolean = False
                Dim Ubicacion As Integer = 0
                For A = 0 To ArchivosLocales.Length - 1
                    For B = 0 To ArchivosRemotos.Length - 1
                        If ArchivosRemotos(B) = ArchivosLocales(A) Then Existe = True : Ubicacion = B
                    Next
                    If Existe = False Then
                        Dim Nombre() As String = ArchivosRemotos(Ubicacion).Split("\")
                        File.Copy(ArchivosRemotos(Ubicacion), AppDomain.CurrentDomain.BaseDirectory & "Imagenes\" & Nombre.Last)
                    End If
                Next
            End If
        Catch

        End Try
    End Sub
End Class
