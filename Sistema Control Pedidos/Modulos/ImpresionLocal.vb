Imports System
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows.Forms

Public Module ImpresionLocal
    ' El formato nuevo utiliza las APIs de Windows; no necesita Crystal Reports 2008.
    Public Function CrearLineas(ByVal titulo As String, ByVal encabezado As IEnumerable(Of String), ByVal datos As DataTable) As List(Of String)
        Dim lineas As New List(Of String)()
        lineas.Add(If(String.IsNullOrWhiteSpace(titulo), "Comprobante", titulo.Trim()))
        lineas.Add(New String("="c, 80))

        If encabezado IsNot Nothing Then
            For Each texto As String In encabezado
                lineas.Add(If(texto, String.Empty))
            Next
        End If

        lineas.Add(New String("-"c, 80))

        If datos Is Nothing OrElse datos.Rows.Count = 0 Then
            lineas.Add("(Sin registros para mostrar)")
            lineas.Add(New String("-"c, 80))
            Return lineas
        End If

        For Each fila As DataRow In datos.Rows
            For Each columna As DataColumn In datos.Columns
                Dim valor As Object = fila(columna)
                Dim valorTexto As String = If(valor Is Nothing OrElse Convert.IsDBNull(valor), String.Empty, Convert.ToString(valor, CultureInfo.CurrentCulture))
                Dim texto As String = columna.ColumnName & ": " & valorTexto
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

    Public Function CalcularTotalColumna(ByVal datos As DataTable, ByVal nombreColumna As String) As Decimal
        If datos Is Nothing OrElse String.IsNullOrWhiteSpace(nombreColumna) OrElse Not datos.Columns.Contains(nombreColumna) Then
            Return 0D
        End If

        Dim acumulado As Decimal = 0D
        For Each fila As DataRow In datos.Rows
            Dim raw As Object = fila(nombreColumna)
            If raw Is Nothing OrElse Convert.IsDBNull(raw) Then Continue For
            Dim valor As Decimal
            If Decimal.TryParse(Convert.ToString(raw, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, valor) Then
                acumulado += valor
            End If
        Next
        Return acumulado
    End Function

    Public Sub Mostrar(ByVal titulo As String, ByVal encabezado As IEnumerable(Of String), ByVal datos As DataTable)
        Dim lineas As List(Of String) = CrearLineas(titulo, encabezado, datos)
        Dim posicion As Integer = 0
        Using documento As New PrintDocument(), fuente As New Font("Consolas", 9.0F)
            documento.DocumentName = If(String.IsNullOrWhiteSpace(titulo), "Comprobante", titulo)
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
