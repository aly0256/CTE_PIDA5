Public Class frmHerramientasPersonal
    Dim dtRegistro As New DataTable
    Dim dtLista As DataTable
    Public CodigoArticulo As String
    Public RelojEmp As String
    Public FechaSal As String
    Dim CantidadDeArticulos As Integer
    Dim FiltroHerramientas As String = ""
    Private Sub frmHerramientasPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If FiltroXUsuario.Length > 4 Then
                FiltroHerramientas = " where " & FiltroXUsuario
            Else
                FiltroHerramientas = ""
            End If
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM personalVW" & FiltroHerramientas & " ORDER BY RELOJ ASC")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub MostrarInformacion(Optional ByVal rl As String = "")
        Dim ArchivoFoto As String
        Dim ATiempo As Boolean

        Try
            'Mostrar información
            If rl <> "" Then
                If FiltroXUsuario.Length > 4 Then
                    FiltroHerramientas = " and " & FiltroXUsuario
                Else
                    FiltroHerramientas = ""
                End If
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM personalVW WHERE RELOJ = '" & rl & "'" & FiltroHerramientas & " ORDER BY RELOJ ASC")

            End If
            Dim dRow = dtRegistro.Rows(0)
            txtReloj.Text = IIf(IsDBNull(dRow("RELOJ")), "", dRow("RELOJ"))
            txtNombre.Text = IIf(IsDBNull(dRow("NOMBRES")), "", dRow("NOMBRES"))
            txtAlta.Text = IIf(IsDBNull(dRow("ALTA")), Nothing, dRow("ALTA"))
            EsBaja = Not IsDBNull(dRow("BAJA"))
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBaja.Text = IIf(EsBaja, dRow("BAJA"), Nothing)
            txtTipoEmp.Text = IIf(IsDBNull(dRow("COD_TIPO")), "", dRow("COD_TIPO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_tipoemp")), "", ", " & dRow("nombre_tipoemp").ToString.Trim)
            txtDepto.Text = IIf(IsDBNull(dRow("COD_DEPTO")), "", dRow("COD_DEPTO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_depto")), "", ", " & dRow("nombre_depto").ToString.Trim)
            txtSupervisor.Text = IIf(IsDBNull(dRow("COD_SUPER")), "", dRow("COD_SUPER").ToString.Trim) & IIf(IsDBNull(dRow("nombre_super")), "", ", " & dRow("nombre_super").ToString.Trim)
            txtClase.Text = IIf(IsDBNull(dRow("COD_CLASE")), "", dRow("COD_CLASE").ToString.Trim) & IIf(IsDBNull(dRow("nombre_clase")), "", ", " & dRow("nombre_clase").ToString.Trim)
            txtTurno.Text = IIf(IsDBNull(dRow("COD_TURNO")), "", dRow("COD_TURNO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_Turno")), "", ", " & dRow("nombre_Turno").ToString.Trim)
            txtHorario.Text = IIf(IsDBNull(dRow("COD_HORA")), "", dRow("COD_HORA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_Horario")), "", ", " & dRow("nombre_Horario").ToString.Trim)
            txtPuesto.Text = IIf(IsDBNull(dRow("COD_PUESTO")), "", dRow("COD_PUESTO").ToString.Trim) & IIf(IsDBNull(dRow("nombre_Puesto")), "", ", " & dRow("nombre_Puesto").ToString.Trim)
            lblPlanta.Text = "Planta: " & IIf(IsDBNull(dRow("COD_PLANTA")), "", dRow("COD_PLANTA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_planta")), "", ", " & dRow("nombre_planta").ToString.Trim)
            txtArea.Text = IIf(IsDBNull(dRow("COD_AREA")), "", dRow("COD_AREA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_area")), "", ", " & dRow("nombre_area").ToString.Trim)
            Reloj = txtReloj.Text
            dtLista = sqlExecute("SELECT RTRIM(articulos.COD_ART) AS COD_ART,RTRIM(articulos.NOMBRE) as 'NOMBRE'," & _
                                 "RTRIM(clasificacion.NOMBRE) as 'CLASIFICACION'," & "FECHA_SAL,FECHA_ENT,RTRIM(CONTROL) AS CONTROL,CANTIDAD," & _
                                 "RTRIM(OBSERVACION) AS OBSERVACION,ENTREGADO,RTRIM(USUARIO) AS USUARIO,FECHA_DEV " & _
                                 "FROM articulos_por_empleado LEFT JOIN articulos ON articulos_por_empleado.COD_ART = articulos.COD_ART " & _
                                 "LEFT JOIN clasificacion ON articulos.COD_CLAS = clasificacion.COD_CLAS WHERE RELOJ = '" & txtReloj.Text & "' ORDER BY fecha_sal DESC", "HERRAMIENTAS")
            dgTabla.DataSource = dtLista
            For Each dR As System.Windows.Forms.DataGridViewRow In dgTabla.Rows

                If dR.Cells("entregado").Value = 1 Then
                    dR.DefaultCellStyle.ForeColor = SystemColors.InactiveCaptionText
                    dR.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Italic)
                Else
                    If dR.Cells("fecha_sal").Value = dR.Cells("fecha_ent").Value Then
                        ATiempo = True
                    Else
                        ATiempo = dR.Cells("fecha_ent").Value > Date.Now
                    End If
                    dR.DefaultCellStyle.ForeColor = IIf(ATiempo, SystemColors.WindowText, Color.Red)

                End If

            Next

            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & rl & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    ArchivoFoto = PathFoto & "nofoto.png"
                End If
                'Dim ft As New Bitmap(ArchivoFoto)
                picFoto.Width = picFoto.MinimumSize.Width
                picFoto.Height = picFoto.MinimumSize.Height
                picFoto.Left = 900
                'picFoto.Image = ft
                picFoto.ImageLocation = ArchivoFoto
            Catch
                picFoto.Image = picFoto.ErrorImage
            End Try
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("personalVW", "RELOJ", dtRegistro)
        MostrarInformacion()
    End Sub
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("personalVW", "RELOJ", txtReloj.Text, dtRegistro)
        MostrarInformacion()
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("personalVW", "RELOJ", txtReloj.Text, dtRegistro)
        MostrarInformacion()
    End Sub
    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("personalVW", "RELOJ", dtRegistro)
        MostrarInformacion()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                If FiltroXUsuario.Length > 4 Then
                    FiltroHerramientas = " and " & FiltroXUsuario
                Else
                    FiltroHerramientas = ""
                End If
                dtRegistro = sqlExecute("SELECT * FROM personalVW WHERE RELOJ ='" & Reloj & "'" & FiltroHerramientas)
                If dtRegistro.Rows.Count > 0 Then
                    MostrarInformacion(Reloj)
             
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
        MostrarInformacion(Reloj)
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        If lblEstado.Text = "INACTIVO" Then
            MessageBox.Show("No puede asignarse un préstamo a un empleado dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            frmAgregarPrestamo.ShowDialog(Me)
        End If
        MostrarInformacion(Reloj)
    End Sub
   
    Private Sub dgTabla_Click(sender As Object, e As EventArgs) Handles dgTabla.Click

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If dgTabla.SelectedCells.Count = 0 Then Exit Sub

            Dim i As Integer = dgTabla.SelectedCells(0).RowIndex
            setRowInfo()

            If dgTabla.Item("entregado", i).Value = 0 Then
                frmEditarPrestamo.ShowDialog(Me)
                MostrarInformacion(Reloj)
            Else
                MessageBox.Show("No puede modificarse este préstamo, ya que el articulo ya fue entregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub dgTabla_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        btnEditar.PerformClick()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            If dgTabla.SelectedCells.Count = 0 Then Exit Sub

            Dim i As Integer = dgTabla.SelectedCells(0).RowIndex
            setRowInfo()

            If dgTabla.Item("entregado", i).Value = 0 Then
                Dim dtTemp As DataTable = sqlExecute("SELECT * FROM articulos WHERE COD_ART ='" & CodigoArticulo & "'", "HERRAMIENTAS")
                If MessageBox.Show("¿Estás seguro que deseas borrar este préstamo?", "Borrar préstamo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    sqlExecute("UPDATE articulos SET IN_STOCK = IN_STOCK +" & CantidadDeArticulos & ", OUT_STOCK = OUT_STOCK -" & CantidadDeArticulos & "' WHERE COD_ART = '" & CodigoArticulo & "'", "HERRAMIENTAS")

                    'sqlExecute("UPDATE articulos SET IN_STOCK = '" & dtTemp.Rows(0).Item("IN_STOCK") + CantidadDeArticulos & "', OUT_STOCK = '" & _
                    '           dtTemp.Rows(0).Item("OUT_STOCK") - CantidadDeArticulos & "' WHERE COD_ART = '" & CodigoArticulo & "'", "HERRAMIENTAS")


                    sqlExecute("DELETE FROM articulos_por_empleado WHERE reloj = '" & txtReloj.Text & "' AND COD_ART = '" & CodigoArticulo & _
                               "' AND FECHA_SAL='" & FechaSal & "'", "HERRAMIENTAS")
                End If
            Else
                MessageBox.Show("No puede borrarse este préstamo, ya que el articulo fue entregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub setRowInfo()
        Dim i As Integer
        Try
            If dgTabla.SelectedCells.Count = 0 Then Exit Sub
            i = dgTabla.SelectedCells(0).RowIndex

            FechaSal = FechaSQL(dgTabla.Item("fecha_sal", i).Value)
            RelojEmp = txtReloj.Text
            CodigoArticulo = dgTabla.Item("cod_art", i).Value.ToString
            CantidadDeArticulos = dgTabla.Item("cantidad", i).Value.ToString
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub dgTabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellDoubleClick
        If e.RowIndex >= 0 And NivelEdicion Then
            btnEditar.PerformClick()
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            frmVistaPrevia.LlamarReporte("Reporte de herramientas por empleado", sqlExecute("SELECT * FROM ArticulosEmpleadosVW WHERE RELOJ ='" & txtReloj.Text & "'", "HERRAMIENTAS"))
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

 
    Private Sub frmHerramientasPersonal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlControles.Left = (Me.Width - pnlControles.Width) / 2
    End Sub

End Class