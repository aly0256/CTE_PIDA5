Public Class frmPatologias

    Public pat As New patologia
    Dim dtPatologias As New DataTable
    Dim codigo_anterior As String = ""

    Public Sub cargarDatos(Optional ByVal codigo As String = "")

        txtCodigo.Enabled = False
        txtNombre.Enabled = False
       
        If codigo.Equals("") Then
            dtPatologias = sqlExecute("select top 1 * from patologia order by codigo", "sermed")
            If dtPatologias.Rows.Count > 0 Then
                pat = New patologia(dtPatologias.Rows(0))
            End If
        ElseIf codigo.Equals("nuevo") Then
            pat = New patologia()
            txtCodigo.Enabled = True
            txtNombre.Enabled = True
          
        Else
            dtPatologias = sqlExecute("select * from patologia where codigo = '" + codigo + "'", "sermed")
            If dtPatologias.Rows.Count > 0 Then
                pat = New patologia(dtPatologias.Rows(0))
            End If
        End If

        Me.txtCodigo.Text = pat.codigo
        Me.txtNombre.Text = pat.descripcion

        btnAnterior.Enabled = True
        btnPrimero.Enabled = True
        btnUltimo.Enabled = True
        btnSiguiente.Enabled = True

    End Sub

    Private Sub frmProgramas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("patologia", "codigo", dtPatologias, "sermed")
        If dtPatologias.Rows().Count > 0 Then
            Dim codigo As String = dtPatologias.Rows(0)("codigo")
            cargarDatos(codigo)
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("patologia", "codigo", dtPatologias, "sermed")
        If dtPatologias.Rows().Count > 0 Then
            Dim codigo As String = dtPatologias.Rows(0)("codigo")
            cargarDatos(codigo)
        End If
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If btnEditar.Text.Equals("Editar") Then
            'txtCodigo.Enabled = True
            txtNombre.Enabled = True
           
            btnNuevo.Text = "Guardar"
            btnEditar.Text = "Revertir"

            btnAnterior.Enabled = False
            btnPrimero.Enabled = False
            btnUltimo.Enabled = False
            btnSiguiente.Enabled = False

            codigo_anterior = pat.codigo

        Else
            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"


            cargarDatos(codigo_anterior)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If pat.codigo <> "" Then
            If MsgBox("¿Seguro qué desea borrar esta patologia?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                pat.eliminar()
                cargarDatos(codigo_anterior)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If btnNuevo.Text.Equals("Agregar") Then
            btnNuevo.Text = "Guardar"
            btnEditar.Text = "Revertir"

            codigo_anterior = pat.codigo
            cargarDatos("nuevo")

            btnAnterior.Enabled = False
            btnPrimero.Enabled = False
            btnUltimo.Enabled = False
            btnSiguiente.Enabled = False

        Else
            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"

            pat.guardar()
            cargarDatos(pat.codigo)
        End If
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("patologia", "codigo", pat.codigo, dtPatologias, "sermed")
        codigo_anterior = pat.codigo
        If dtPatologias.Rows.Count > 0 Then
            cargarDatos(dtPatologias.Rows(0)("codigo"))
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("patologia", "codigo", pat.codigo, dtPatologias, "sermed")
        codigo_anterior = pat.codigo
        If dtPatologias.Rows.Count > 0 Then
            cargarDatos(dtPatologias.Rows(0)("codigo"))
        End If
    End Sub

    Private Sub dgTabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellDoubleClick
        cargarDatos(dgTabla.DataSource.rows(e.RowIndex)("Código del Programa"))
        tabBuscar.SelectedTab = tabPrograma
    End Sub

    Private Sub tabTabla_Click(sender As Object, e As EventArgs) Handles tabTabla.Click
        dgTabla.DataSource = sqlExecute("select codigo as 'Código del Programa', descripcion as 'Descripción' from patologia order by codigo", "sermed")
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        pat.codigo = txtCodigo.Text
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        pat.descripcion = txtNombre.Text
    End Sub

    Private Sub txtNombre_Click(sender As Object, e As EventArgs) Handles txtNombre.Click
        txtNombre.SelectAll()
    End Sub
End Class

Public Class patologia
    Public codigo As String = "00"
    Public descripcion As String = "Descripción"   

    Sub New()
        Dim dtFolio As DataTable = sqlExecute("select top 1 codigo from patologia order by codigo desc", "sermed")
        If dtFolio.Rows.Count > 0 Then
            Me.codigo = completar(Integer.Parse(dtFolio(0)("codigo")) + 1, 3)
        End If
    End Sub

    Private Function completar(numero As Integer, caracteres As Integer) As String
        Dim s As String = numero.ToString
        While (s.Length < caracteres)
            s = "0" + s
        End While
        Return s
    End Function


    Sub New(row As DataRow)
        Me.codigo = row("codigo")
        Me.descripcion = row("descripcion")
    End Sub

    Public Sub eliminar()
        sqlExecute("delete from patologia where codigo = '" + Me.codigo + "'", "sermed")
    End Sub

    Public Sub guardar()
        Dim dtPrograma As DataTable = sqlExecute("select * from patologia where codigo = '" + Me.codigo + "'", "sermed")
        If dtPrograma.Rows.Count <= 0 Then
            sqlExecute("insert into patologia (codigo) values ('" + Me.codigo + "')", "sermed")
        End If

        sqlExecute("update patologia set descripcion = '" + Me.descripcion + "' where codigo = '" + Me.codigo + "'", "sermed")
    End Sub

End Class