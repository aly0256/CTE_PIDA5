Public Class frmProgramas

    Public pa As New programa
    Dim dtProgramas As New DataTable
    Dim codigo_anterior As String = ""

    Public Sub cargarDatos(Optional ByVal codigo As String = "")

        campoCodigoPrograma.Enabled = False
        campoDescripcionPrograma.Enabled = False
        botonColorFondo.Enabled = False
        botonColorLetra.Enabled = False

        If codigo.Equals("") Then
            dtProgramas = sqlExecute("select top 1 * from tipo_programa order by codigo", "sermed")
            If dtProgramas.Rows.Count > 0 Then
                pa = New programa(dtProgramas.Rows(0))
            End If
        ElseIf codigo.Equals("nuevo") Then
            pa = New programa()
            campoCodigoPrograma.Enabled = True
            campoDescripcionPrograma.Enabled = True
            botonColorFondo.Enabled = True
            botonColorLetra.Enabled = True
        Else
            dtProgramas = sqlExecute("select * from tipo_programa where codigo = '" + codigo + "'", "sermed")
            If dtProgramas.Rows.Count > 0 Then
                pa = New programa(dtProgramas.Rows(0))
            End If
        End If

        Me.campoCodigoPrograma.Text = pa.codigo
        Me.campoDescripcionPrograma.Text = pa.descripcion
        Me.botonColorLetra.BackColor = pa.fore
        Me.botonColorFondo.BackColor = pa.back
        Me.labelMuestra.BackColor = pa.back
        Me.labelMuestra.ForeColor = pa.fore

        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
        btnUltimo.Enabled = True
        btnSiguiente.Enabled = True


    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("tipo_programa", "codigo", dtProgramas, "sermed")
        If dtProgramas.Rows().Count > 0 Then
            Dim codigo As String = dtProgramas.Rows(0)("codigo")
            cargarDatos(codigo)
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("tipo_programa", "codigo", dtProgramas, "sermed")
        If dtProgramas.Rows().Count > 0 Then
            Dim codigo As String = dtProgramas.Rows(0)("codigo")
            cargarDatos(codigo)
        End If
    End Sub

    Private Sub botonColorFondo_Click(sender As Object, e As EventArgs) Handles botonColorFondo.Click
        Try
            If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                pa.back = ColorDialog1.Color
                botonColorFondo.BackColor = pa.back
                labelMuestra.BackColor = pa.back

                pa.bcolor = pa.back.R & "," & pa.back.G & "," & pa.back.B
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub botonColorLetra_Click(sender As Object, e As EventArgs) Handles botonColorLetra.Click
        Try
            If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                pa.fore = ColorDialog1.Color
                botonColorLetra.BackColor = pa.fore
                labelMuestra.ForeColor = pa.fore

                pa.fcolor = pa.fore.R & "," & pa.fore.G & "," & pa.fore.B
            End If
        Catch ex As Exception            
        End Try
    End Sub

    Private Sub campoCodigoPrograma_TextChanged(sender As Object, e As EventArgs) Handles campoCodigoPrograma.TextChanged
        labelMuestra.Text = campoCodigoPrograma.Text
    End Sub

    Private Sub frmProgramas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()        
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If btnEditar.Text.Equals("Editar") Then


            btnAnterior.Enabled = False
            btnPrimero.Enabled = False
            btnUltimo.Enabled = False
            btnSiguiente.Enabled = False

            campoCodigoPrograma.Enabled = True
            campoDescripcionPrograma.Enabled = True
            botonColorFondo.Enabled = True
            botonColorLetra.Enabled = True
            btnNuevo.Text = "Guardar"
            btnEditar.Text = "Revertir"

            codigo_anterior = pa.codigo

        Else


            btnAnterior.Enabled = True
            btnPrimero.Enabled = True
            btnUltimo.Enabled = True
            btnSiguiente.Enabled = True

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
            cargarDatos(codigo_anterior)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If pa.codigo <> "" Then
            If MsgBox("¿Seguro qué desea borrar este programa?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                pa.eliminar()
                cargarDatos(codigo_anterior)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If btnNuevo.Text.Equals("Agregar") Then
            btnNuevo.Text = "Guardar"
            btnEditar.Text = "Revertir"
            codigo_anterior = pa.codigo

            cargarDatos("nuevo")


            btnAnterior.Enabled = False
            btnPrimero.Enabled = False
            btnUltimo.Enabled = False
            btnSiguiente.Enabled = False

        Else
            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
            pa.guardar()
            cargarDatos(pa.codigo)
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("tipo_programa", "codigo", pa.codigo, dtProgramas, "sermed")

        codigo_anterior = pa.codigo

        If dtProgramas.Rows.Count > 0 Then
            cargarDatos(dtProgramas.Rows(0)("codigo"))
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("tipo_programa", "codigo", pa.codigo, dtProgramas, "sermed")

        codigo_anterior = pa.codigo

        If dtProgramas.Rows.Count > 0 Then
            cargarDatos(dtProgramas.Rows(0)("codigo"))
        End If
    End Sub

    Private Sub dgTabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellDoubleClick
        cargarDatos(dgTabla.DataSource.rows(e.RowIndex)("Código del Programa"))
        tabBuscar.SelectedTab = tabPrograma
    End Sub

    

    Private Sub tabTabla_Click(sender As Object, e As EventArgs) Handles tabTabla.Click    
        dgTabla.DataSource = sqlExecute("select codigo as 'Código del Programa', descripcion as 'Descripción', fcolor as 'Color de la Letra(RGB)', bcolor as 'Color del Fondo(RGB)' from tipo_programa order by codigo", "sermed")
    End Sub
End Class

Public Class programa
    Public codigo As String = "AAA"
    Public descripcion As String = "Descripción"
    Public bcolor As String = "255,255,255"
    Public back As Color = Color.White
    Public fcolor As String = "0,0,0"
    Public fore As Color = Color.Black

    Sub New()

    End Sub

    Sub New(row As DataRow)
        Me.codigo = row("codigo")
        Me.descripcion = row("descripcion")
        Me.bcolor = row("bcolor")
        Me.fcolor = row("fcolor")

        Me.back = Color.FromArgb(Integer.Parse(bcolor.Split(",")(0)), Integer.Parse(bcolor.Split(",")(1)), Integer.Parse(bcolor.Split(",")(2)))
        Me.fore = Color.FromArgb(Integer.Parse(fcolor.Split(",")(0)), Integer.Parse(fcolor.Split(",")(1)), Integer.Parse(fcolor.Split(",")(2)))
    End Sub

    Public Sub eliminar()
        sqlExecute("delete from tipo_programa where codigo = '" + Me.codigo + "'", "sermed")
    End Sub

    Public Sub guardar()
        Dim dtPrograma As DataTable = sqlExecute("select * from tipo_programa where codigo = '" + Me.codigo + "'", "sermed")
        If dtPrograma.Rows.Count <= 0 Then
            sqlExecute("insert into tipo_programa (codigo) values ('" + Me.codigo + "')", "sermed")
        End If

        sqlExecute("update tipo_programa set descripcion = '" + Me.descripcion + "', bcolor= '" + Me.bcolor + "', fcolor = '" + Me.fcolor + "' where codigo = '" + Me.codigo + "'", "sermed")
    End Sub

End Class