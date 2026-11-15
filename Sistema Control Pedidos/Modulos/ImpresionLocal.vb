Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms

Public Module ImpresionLocal
    ' El formato nuevo utiliza las APIs de Windows; no necesita Crystal Reports 2008.
    Public Function CrearLineas(ByVal titulo As String, ByVal encabezado As IEnumerable(Of String), ByVal datos As DataTable) As List(Of String)
        Dim lineas As New List(Of String)()
        lineas.Add(titulo)
        lineas.Add(New String("="c, 80))
        For Each texto As String In encabezado
            lineas.Add(If(texto, String.Empty))
        Next
        lineas.Add(New String("-"c, 80))
        For Each fila As DataRow In datos.Rows
            For Each columna As DataColumn In datos.Columns
                Dim texto As String = columna.ColumnName & ": " & Convert.ToString(fila(columna))
                Do While texto.Length > 90
                    lineas.Add(texto.Substring(0, 90))
                    texto = texto.Substring(90)
                Loop
                lineas.Add(texto)
            Next
            lineas.Add(New String("-"c, 80))
        Next
        Return lineas
    End Function

    Public Sub Mostrar(ByVal titulo As String, ByVal encabezado As IEnumerable(Of String), ByVal datos As DataTable)
        Dim lineas As List(Of String) = CrearLineas(titulo, encabezado, datos)
        Dim posicion As Integer = 0
        Using documento As New PrintDocument(), fuente As New Font("Consolas", 9.0F)
            documento.DocumentName = titulo
            AddHandler documento.BeginPrint, Sub(sender, e) posicion = 0
            AddHandler documento.PrintPage,
                Sub(sender, e)
                    Dim y As Single = e.MarginBounds.Top
                    Dim alto As Single = fuente.GetHeight(e.Graphics)
                    Do While posicion < lineas.Count AndAlso y + alto <= e.MarginBounds.Bottom
                        e.Graphics.DrawString(lineas(posicion), fuente, Brushes.Black, e.MarginBounds.Left, y)
                        y += alto
                        posicion += 1
                    Loop
                    e.HasMorePages = posicion < lineas.Count
                End Sub
            Using vista As New PrintPreviewDialog()
                vista.Document = documento
                vista.Width = 900
                vista.Height = 700
                vista.ShowDialog()
            End Using
        End Using
    End Sub
End Module
