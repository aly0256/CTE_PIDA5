Public Class frmUniformesPersonal
    Dim dtRegistro As New DataTable
    Dim dtLista As DataTable
    Public Codigouniforme As String
    Public RelojEmp As String
    Public FechaSal As String
    Dim CantidadDeuniformes As Integer
    Dim FiltroUniformes As String = ""
    Private Sub frmUniformesPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If FiltroXUsuario.Length > 4 Then
                FiltroUniformes = " where " & FiltroXUsuario
            Else
                FiltroUniformes = ""
            End If
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM personalVW" & FiltroUniformes & " ORDER BY RELOJ ASC")
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
                    FiltroUniformes = " and " & FiltroXUsuario
                Else
                    FiltroUniformes = ""
                End If
                dtRegistro = sqlExecute("SELECT TOP 1 * FROM personalVW WHERE RELOJ = '" & rl & "'" & FiltroUniformes)
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
            lblPlanta.Text = IIf(IsDBNull(dRow("COD_PLANTA")), "", dRow("COD_PLANTA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_planta")), "", ", " & dRow("nombre_planta").ToString.Trim)
            txtArea.Text = IIf(IsDBNull(dRow("COD_AREA")), "", dRow("COD_AREA").ToString.Trim) & IIf(IsDBNull(dRow("nombre_area")), "", ", " & dRow("nombre_area").ToString.Trim)
            Reloj = txtReloj.Text
            dtLista = sqlExecute("SELECT RTRIM(uniformes.COD_unif) AS COD_UNIF,	RTRIM(uniformes.NOMBRE) AS 'NOMBRE', FECHA_SAL,	FECHA_ENT, " & _
                                 "RTRIM(talla) AS TALLA,CANTIDAD,RTRIM(OBSERVACION) AS OBSERVACION,ENTREGADO,RTRIM(USUARIO) AS USUARIO,FECHA_DEV " & _
                                 "FROM uniformes_por_empleado LEFT JOIN uniformes ON uniformes_por_empleado.COD_unif = uniformes.COD_unif " & _
                                 "WHERE RELOJ = '" & txtReloj.Text & "' ORDER BY fecha_sal DESC", "HERRAMIENTAS")
            dgTabla.DataSource = dtLista
            For Each dR As System.Windows.Forms.DataGridViewRow In dgTabla.Rows

                'AOS -05/09/2018 A solicitud de Ivette, solicita que no se ponga Italica la letra en el DGV al cargarse
                '  If dR.Cells("entregado").Value = 1 Then
                'dR.DefaultCellStyle.ForeColor = SystemColors.InactiveCaptionText
                'dR.DefaultCellStyle.Font = New Font("Arial", 8, FontStyle.Italic)
                'Else
                If dR.Cells("fecha_sal").Value = dR.Cells("fecha_ent").Value Then
                    ATiempo = True
                Else
                    ATiempo = dR.Cells("fecha_ent").Value > Date.Now
                End If
                dR.DefaultCellStyle.ForeColor = IIf(ATiempo, SystemColors.WindowText, Color.Red)
                ' End If
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
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
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
                    FiltroUniformes = " and " & FiltroXUsuario
                Else
                    FiltroUniformes = ""
                End If
                dtRegistro = sqlExecute("SELECT * FROM personalVW WHERE RELOJ ='" & Reloj & "'" & FiltroUniformes)
                If dtRegistro.Rows.Count > 0 Then
                    MostrarInformacion(Reloj)
                    'btnNuevo.PerformClick()
                    'Else
                    'frmAgregarPrestamo.ShowDialog(Me)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        If lblEstado.Text = "INACTIVO" Then
            MessageBox.Show("No puede asignarse un préstamo a un empleado dado de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            frmAgregarPrestamoU.ShowDialog(Me)
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
                frmEditarPrestamoU.ShowDialog(Me)
                MostrarInformacion(Reloj)
            Else
                MessageBox.Show("No puede modificarse este préstamo, ya que el uniforme ya fue entregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Dim dtTemp As DataTable = sqlExecute("SELECT * FROM uniformes WHERE cod_unif ='" & Codigouniforme & "'", "HERRAMIENTAS")
                If MessageBox.Show("¿Estás seguro que deseas borrar este préstamo?", "Borrar préstamo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    sqlExecute("UPDATE uniformes SET IN_STOCK =  IN_STOCK+" & CantidadDeuniformes & ", OUT_STOCK = out_STOCK -" & CantidadDeuniformes & " WHERE cod_unif = '" & Codigouniforme & "'", "HERRAMIENTAS")


                    'sqlExecute("UPDATE uniformes SET IN_STOCK = '" & dtTemp.Rows(0).Item("IN_STOCK") + CantidadDeuniformes & "', OUT_STOCK = '" & _
                    '           dtTemp.Rows(0).Item("OUT_STOCK") - CantidadDeuniformes & "' WHERE cod_unif = '" & Codigouniforme & "'", "HERRAMIENTAS")




                    sqlExecute("DELETE FROM uniformes_por_empleado WHERE reloj = '" & txtReloj.Text & "' AND cod_unif = '" & Codigouniforme & _
                               "' AND FECHA_SAL='" & FechaSal & "'", "HERRAMIENTAS")
                End If
            Else
                MessageBox.Show("No puede borrarse este préstamo, ya que el uniforme fue entregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Codigouniforme = dgTabla.Item("cod_unif", i).Value.ToString
            CantidadDeuniformes = dgTabla.Item("cantidad", i).Value.ToString
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
            frmVistaPrevia.LlamarReporte("Reporte de uniformes por empleado", sqlExecute("SELECT * FROM UniformesEmpleadosVW WHERE RELOJ ='" & txtReloj.Text & "'", "HERRAMIENTAS"))
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub frmHerramientasPersonal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlControles.Left = (Me.Width - pnlControles.Width) / 2
    End Sub

End Class