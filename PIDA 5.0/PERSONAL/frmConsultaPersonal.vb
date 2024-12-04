Public Class frmConsultaPersonal

    Dim dtPersonal As New DataTable
    Dim dtCias As DataTable
    Dim dtBancos As DataTable
    Dim dtDeptos As DataTable
    Dim dtSuper As DataTable
    Dim dtTurnos As DataTable
    Dim dtTipos As Object
    Dim dtPuestos As DataTable
    Dim dtPlantas As DataTable
    Dim dtareas As DataTable
    Dim dtClases As DataTable
    Dim dtHorarios As DataTable
    Dim dtLineas As DataTable
    Dim cmbNivel As Object
    Dim dtCCostos As DataTable

    Dim filtroConsulta As String = "cod_clase = 'D'"

    Private Sub frmConsultaPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtCias = sqlExecute("SELECT * FROM cias")
            cmbCia.DataSource = dtCias
            btnFirst.PerformClick()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MostrarInformacion()

        Dim ArchivoFoto As String
        Dim SI As Integer = 0
        Dim drEmpleado As DataRow
        Dim dtReingreso As New DataTable
        Try

           

            If dtPersonal.Rows.Count = 0 Then Exit Sub
            drEmpleado = dtPersonal.Rows(0)
            Compania = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))

            txtReloj.Text = IIf(IsDBNull(drEmpleado("reloj")), "", drEmpleado("reloj"))
            txtNombre.Text = Trim(IIf(IsDBNull(drEmpleado("nombre")), "", drEmpleado("nombre")))
            txtApaterno.Text = Trim(IIf(IsDBNull(drEmpleado("apaterno")), "", drEmpleado("apaterno")))
            txtAmaterno.Text = Trim(IIf(IsDBNull(drEmpleado("amaterno")), "", drEmpleado("amaterno")))

            txtAlta.Value = IIf(IsDBNull(drEmpleado("alta")), Now, drEmpleado("alta"))
            EsBaja = Not IsDBNull(drEmpleado("baja"))
            txtBaja.Value = IIf(EsBaja, drEmpleado("baja"), Now)
            txtBaja.Visible = IIf(EsBaja, True, False)
            lblBaja.Visible = txtBaja.Visible

            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)

            cmbCia.SelectedValue = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
            cmbCia.Columns(0).AutoSize()
            cmbCia.Columns(1).AutoSize()

            cmbPlanta.SelectedValue = IIf(IsDBNull(drEmpleado("cod_planta")), "", drEmpleado("cod_planta"))
            cmbPlanta.Columns(0).AutoSize()
            cmbPlanta.Columns(1).AutoSize()

            cmbArea.SelectedValue = IIf(IsDBNull(drEmpleado("cod_area")), "", RTrim(drEmpleado("cod_area")))
            cmbArea.Columns(0).AutoSize()
            cmbArea.Columns(1).AutoSize()

            cmbLinea.SelectedValue = IIf(IsDBNull(drEmpleado("cod_linea")), "", drEmpleado("cod_linea"))
            cmbLinea.Columns(0).AutoSize()
            cmbLinea.Columns(1).AutoSize()

            cmbDepto.SelectedValue = IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto"))
            cmbDepto.Columns(0).AutoSize()
            cmbDepto.Columns(1).AutoSize()

            cmbSuper.SelectedValue = IIf(IsDBNull(drEmpleado("cod_super")), "", drEmpleado("cod_super"))
            cmbSuper.Columns(0).AutoSize()
            cmbSuper.Columns(1).AutoSize()

            cmbPuesto.SelectedValue = IIf(IsDBNull(drEmpleado("cod_puesto")), "", drEmpleado("cod_puesto"))
            cmbPuesto.Columns(0).AutoSize()
            cmbPuesto.Columns(1).AutoSize()

            cmbTipo.SelectedValue = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
            cmbTipo.Columns(0).AutoSize()
            cmbTipo.Columns(1).AutoSize()

            cmbClase.SelectedValue = IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase"))
            cmbClase.Columns(0).AutoSize()
            cmbClase.Columns(1).AutoSize()


            cmbHorario.SelectedValue = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))
            cmbHorario.Columns(0).AutoSize()
            cmbHorario.Columns(1).AutoSize()

            cmbTurno.SelectedValue = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))
            cmbTurno.Columns(0).AutoSize()
            cmbTurno.Columns(1).AutoSize()



            txtIMSS.Text = IIf(IsDBNull(drEmpleado("imss")), "", drEmpleado("imss"))
            txtIMSSdv.Text = IIf(IsDBNull(drEmpleado("dig_ver")), "", drEmpleado("dig_ver"))

            txtRFC.Text = IIf(IsDBNull(drEmpleado("RFC")), "", drEmpleado("RFC"))
            txtCurp.Text = IIf(IsDBNull(drEmpleado("Curp")), "", drEmpleado("Curp"))
            'bntSexo = False -> Masculino
            If IsDBNull(drEmpleado("sexo")) Then
                btnSexo.Value = False
            Else
                btnSexo.Value = drEmpleado("sexo") = "F"
            End If
            txtGafete.Text = IIf(IsDBNull(drEmpleado("Gafete")), "", drEmpleado("Gafete"))
            chkChecaTarjeta.Checked = IIf(IsDBNull(drEmpleado("checa_tarjeta")), False, drEmpleado("checa_tarjeta"))


            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & Reloj.Trim & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    picFoto.Image = My.Resources.NoFoto
                Else
                    picFoto.ImageLocation = ArchivoFoto
                End If

            Catch
                picFoto.Image = picFoto.ErrorImage
                picFoto.SizeMode = PictureBoxSizeMode.Zoom
            End Try

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("La información no pudo ser cargada exitosamente. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.- " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = sqlExecute("SELECT TOP 1 * from personalvw WHERE reloj >'" & reloj & "' and " & filtroConsulta & " ORDER BY reloj ASC")
            If dtPersonal.Rows.Count < 1 Then
                btnLast.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = sqlExecute("SELECT TOP 1 * from personalvw where " & filtroConsulta & " ORDER BY reloj DESC")
            If dtPersonal.Rows.Count > 0 Then
                'EmpIdx = dtPersonal.Rows.Count - 1
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = sqlExecute("SELECT TOP 1 * from personalvw where " & filtroConsulta & " ORDER BY reloj ASC")
            If dtPersonal.Rows.Count > 0 Then
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = sqlExecute("SELECT TOP 1 * from personalvw WHERE reloj <'" & reloj & "' and " & filtroConsulta & " ORDER BY reloj DESC")
            If dtPersonal.Rows.Count < 1 Then
                btnFirst.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub


    Private Sub cmbCia_SelectedValueChanged1(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        'If Cargando Then Exit Sub
        Try
            If cmbCia.SelectedValue Is Nothing Then Exit Sub
            dtDeptos = sqlExecute("SELECT rtrim(cod_depto) as cod_depto, nombre from deptos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbDepto.DataSource = dtDeptos            

            dtSuper = sqlExecute("SELECT rtrim(cod_super) as cod_super, nombre FROM super WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbSuper.DataSource = dtSuper

            dtTurnos = sqlExecute("SELECT rtrim(cod_turno) as cod_tuno, nombre FROM turnos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbTurno.DataSource = dtTurnos

            dtTipos = sqlExecute("SELECT rtrim(cod_tipo) as cod_tipo, nombre FROM tipo_emp WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbTipo.DataSource = dtTipos

            dtPuestos = sqlExecute("SELECT rtrim(cod_puesto) as cod_puesto,nombre FROM puestos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbPuesto.DataSource = dtPuestos

            dtPlantas = sqlExecute("SELECT rtrim(cod_planta) as cod_planta,nombre FROM plantas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbPlanta.DataSource = dtPlantas

            dtareas = sqlExecute("SELECT rtrim(cod_area) as cod_area,nombre FROM areas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbArea.DataSource = dtareas

            dtClases = sqlExecute("SELECT rtrim(cod_clase) as cod_clase,nombre FROM clase WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbClase.DataSource = dtClases

            dtHorarios = sqlExecute("SELECT rtrim(cod_hora) as cod_hora,nombre FROM horarios WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbHorario.DataSource = dtHorarios

            dtLineas = sqlExecute("SELECT rtrim(cod_linea) as cod_linea,nombre FROM lineas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbLinea.DataSource = dtLineas

           
            dtCCostos = sqlExecute("SELECT rtrim(centro_costos) as centro_costos,nombre FROM c_costos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbCCostos.DataSource = dtCCostos

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim filtroTMP As String = FiltroXUsuario
            FiltroXUsuario = filtroConsulta
            frmBuscar.ShowDialog()
            FiltroXUsuario = filtroTMP
            If Reloj <> "CANCEL" Then
                dtPersonal = ConsultaPersonalVW("SELECT * from personalvw WHERE reloj = '" & Reloj & "' and " & filtroConsulta & "")
                MostrarInformacion()
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class