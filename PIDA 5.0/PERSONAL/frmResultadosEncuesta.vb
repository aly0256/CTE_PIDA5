Imports OfficeOpenXml

Public Class frmResultadosEncuesta

    Private dtEncuestas As New DataTable
    Private strSql As String = ""
    Private cod_encuesta As String = ""
    Private Encuesta As String = ""
    Private f_ini As String = ""
    Private f_fin As String = ""


    Private Sub ResultadosEncuestasExcel()

        Dim sfd As New SaveFileDialog

        Dim frm As New frmTrabajando

        Try

            sfd.DefaultExt = ".xlsx"
            sfd.FileName = "Resultados " & Encuesta & " " & f_ini & " - " & f_fin & ".xlsx"
            sfd.OverwritePrompt = True

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

                frm.Show()

                EncuestaResultados(sfd.FileName)

                MessageBox.Show("El Archivo fue creado exitosamente.", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                'archivo.SaveAs(New System.IO.FileInfo(sfd.FileName))
            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar descargar los resultados de la encuesta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ActivoTrabajando = False
        frm.Close()

    End Sub

    Private Sub EncuestaResultados(ruta As String)

        Dim archivo As ExcelPackage = New ExcelPackage()
        Dim wb As ExcelWorkbook = archivo.Workbook


        Dim dtencuesta As DataTable = sqlExecute("select encuestas_detalles.RELOJ,personalvw.cod_turno,encuestas_detalles.COD_PREGUNTA, encuestas_preguntas.texto," & vbCr & _
                                         "encuestas_detalles.COD_RESPUESTA, encuestas_respuestas.valor, encuestas_detalles.fecha, encuestas_detalles.detalle_libre " & vbCr & _
                                         "from encuestas_detalles left join encuestas_preguntas on " & vbCr & _
                                         "encuestas_detalles.COD_PREGUNTA=encuestas_preguntas.COD_PREGUNTA " & vbCr & _
                                         "left join encuestas_respuestas on encuestas_detalles.COD_RESPUESTA=encuestas_respuestas.COD_RESPUESTA " & vbCr & _
                                         "left join personal.dbo.personalvw on encuestas_detalles.RELOJ = PersonalVW.reloj " & _
                                         "where encuestas_preguntas.COD_ENCUESTA='" & cod_encuesta & "' and encuestas_detalles.fecha between '" & f_ini & "' and '" & f_fin & "' order by FECHA desc", "KIOSCO")

        Dim x As Integer = 1
        Dim y As Integer = 1


        Dim hoja_excel As ExcelWorksheet = wb.Worksheets.Add(Encuesta)

        hoja_excel.Cells(x, y).Value = "RELOJ"
        hoja_excel.Cells(x, y).Style.Font.Bold = True
        hoja_excel.Cells(x, y).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 1).Value = "TURNO"
        hoja_excel.Cells(x, y + 1).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 1).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 1).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 1).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 2).Value = "PREGUNTA"
        hoja_excel.Cells(x, y + 2).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 2).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 2).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 3).Value = "RESPUESTA"
        hoja_excel.Cells(x, y + 3).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 3).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 3).Style.Font.Color.SetColor(Color.White)
        hoja_excel.Cells(x, y + 4).Value = "FECHA"
        hoja_excel.Cells(x, y + 4).Style.Font.Bold = True
        hoja_excel.Cells(x, y + 4).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        hoja_excel.Cells(x, y + 4).Style.Fill.BackgroundColor.SetColor(Color.DarkBlue)
        hoja_excel.Cells(x, y + 4).Style.Font.Color.SetColor(Color.White)

        For Each dr As DataRow In dtencuesta.Rows
            x += 1
            frmTrabajando.lblAvance.Text = dr("reloj")
            Application.DoEvents()
            hoja_excel.Cells(x, y).Value = dr("reloj")
            hoja_excel.Cells(x, y + 1).Value = dr("cod_turno")
            hoja_excel.Cells(x, y + 2).Value = dr("texto")
            hoja_excel.Cells(x, y + 3).Value = dr("valor")
            hoja_excel.Cells(x, y + 4).Value = Date.Parse(dr("fecha")).ToString("yyyy-MM-dd")

        Next

        hoja_excel.Cells(hoja_excel.Dimension.Address).AutoFitColumns()

        archivo.SaveAs(New System.IO.FileInfo(ruta))

    End Sub

    Private Sub frmResultadosEncuenta_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            strSql = "SELECT cod_encuesta as Código, rtrim(ltrim(isnull(nombre,''))) as Encuesta from encuestas order by cod_encuesta"

            dtEncuestas = sqlExecute(strSql, "KIOSCO")

            cmbEncuestas.DataSource = dtEncuestas
            cmbEncuestas.ValueMember = "Código"
            cmbEncuestas.DisplayMembers = "Código,Encuesta"
            cmbEncuestas.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar cargar las encuestas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub frmResultadosEncuenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click

        Try

            If dpFechaInicial.ValueObject IsNot Nothing Then
                f_ini = FechaSQL(dpFechaInicial.Value)

            Else
                f_ini = ""
            End If

            If dpFechaFinal.ValueObject IsNot Nothing Then
                f_fin = FechaSQL(dpFechaFinal.Value)

            Else
                f_fin = ""
            End If


            If f_ini = "" Then

                MessageBox.Show("Seleccione una fecha inicial.", "Fecha en blanco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                dpFechaInicial.Focus()
                Exit Sub

            ElseIf f_fin = "" Then

                MessageBox.Show("Seleccione una fecha final.", "Fecha en blanco", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                dpFechaFinal.Focus()
                Exit Sub

            ElseIf f_ini > f_fin Then

                MessageBox.Show("La fecha inicial debe ser menor o igual a la fecha final", "Rango incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                dpFechaInicial.Focus()
                Exit Sub

            ElseIf f_fin < f_ini Then

                MessageBox.Show("La fecha final debe ser mayor o igual a la fecha inicial", "Rango incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                dpFechaFinal.Focus()
                Exit Sub

            End If


            If cmbEncuestas.SelectedIndex >= 0 Then
                cod_encuesta = Trim(Split(cmbEncuestas.Text, ",")(0))
                Encuesta = Trim(Split(cmbEncuestas.Text, ",")(1))
                ResultadosEncuestasExcel()
            Else
                MessageBox.Show("Debe seleccionar una encuesta", "Encuesta no seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                cmbEncuestas.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un problema al intentar generar el archivo de las respuestas de la encuesta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
   
End Class