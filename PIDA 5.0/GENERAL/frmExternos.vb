Public Class frmExternos
    Public reloj As String = ""
    Public fam As String = ""
    Public id As String = ""

    Dim BSEmpleados As New BindingSource
    Dim BSFamiliares As New BindingSource
    Dim BSExternos As New BindingSource

    Dim dtBuscarEmpleados As New DataTable
    Dim dtBuscarFamiliares As New DataTable
    Dim dtBuscarExternos As New DataTable

    'La busqueda es similar a la de la pantalla de frmBuscar, pero omite los campos extra
    'Para empleados, nombre y reloj
    'Para familiares, nombre, reloj
    'Para externos, nombre y compañía externa

    Private Sub frmExternos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgFamiliares.AutoGenerateColumns = False
        dgTabla.AutoGenerateColumns = False
        dgExternos.AutoGenerateColumns = False

    End Sub

    '*************************
    Private Sub rbEmpleado_CheckedChanged(sender As Object, e As EventArgs) Handles rbEmpleado.CheckedChanged
        If rbEmpleado.Checked = True Then
            rbExterno.Checked = False
            rbFamiliar.Checked = False
        End If
    End Sub
    Private Sub rbFamiliar_CheckedChanged(sender As Object, e As EventArgs) Handles rbFamiliar.CheckedChanged
        If rbFamiliar.Checked = True Then
            rbExterno.Checked = False
            rbEmpleado.Checked = False
        End If
    End Sub
    Private Sub rbExterno_CheckedChanged(sender As Object, e As EventArgs) Handles rbExterno.CheckedChanged
        If rbExterno.Checked = True Then
            rbFamiliar.Checked = False
            rbEmpleado.Checked = False
        End If
    End Sub

    '*************************

    Dim DtPersonalBuscar As DataTable
    Dim dtFamiliarBuscar As DataTable
    Dim dtExternoBuscar As DataTable

    Private Sub wizCampos_NextButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WizardConsultas.NextButtonClick

        e.Cancel = True

        Select Case WizardConsultas.SelectedPage.Name
            Case WizardPageSeleccion.Name
                If rbEmpleado.Checked = True Then

                    '************************ DATOS PARA BUSQUEDA DE EMPLEADOS *************************

                    Try
                        WizardConsultas.SelectedPage = WizardPageEmpleados
                        Application.DoEvents()
                        Cursor = Cursors.WaitCursor

                        If BSEmpleados.DataSource Is Nothing Then
                            dtBuscarEmpleados = ConsultaPersonalVW("SELECT RELOJ,NOMBRES AS NOMBRE,ALTA,BAJA,RTRIM(COD_DEPTO) + ' - ' + RTRIM(NOMBRE_DEPTO) AS DEPARTAMENTO," & _
                                                                  " RTRIM(COD_PUESTO) + ' - ' + RTRIM(NOMBRE_PUESTO) AS PUESTO,PERSONALVW.COD_COMP,FOTO,'' AS CAMPOS_EXTRA" & _
                                                                  " FROM PERSONALVW " & _
                                                                  " WHERE (nivel_seguridad IS NULL OR nivel_seguridad <=" & NivelConsulta & ")", False)

                            BSEmpleados.DataSource = dtBuscarEmpleados

                            navPersonal.BindingSource = BSEmpleados

                            dgTabla.DataSource = BSEmpleados

                            txtRelojEmpleados.DataBindings.Add("Text", BSEmpleados, "Reloj")
                            txtNombreEmpleados.DataBindings.Add("Text", BSEmpleados, "nombre")
                            txtPuestoEmpleados.DataBindings.Add("Text", BSEmpleados, "puesto")
                            txtDeptoEmpleados.DataBindings.Add("Text", BSEmpleados, "departamento")
                            txtAltaEmpleados.DataBindings.Add("Text", BSEmpleados, "alta", True, DataSourceUpdateMode.Never, Nothing, "d")
                            txtBajaEmpleados.DataBindings.Add("Text", BSEmpleados, "baja", True, DataSourceUpdateMode.Never, "------", "d")
                            picFotoEmpleados.DataBindings.Add("ImageLocation", BSEmpleados, "foto")
                        End If

                        Cursor = Cursors.Default
                        txtBuscarEmpleados.Text = ""
                        txtBuscarEmpleados.Select()
                    Catch ex As Exception

                    End Try



                    '*************************************************************************************

                ElseIf rbFamiliar.Checked = True Then

                    '************************ DATOS PARA BUSQUEDA DE FAMILIARES *************************

                    Try
                        WizardConsultas.SelectedPage = WizardPageFamiliares
                        Application.DoEvents()
                        Cursor = Cursors.WaitCursor

                        If BSFamiliares.DataSource Is Nothing Then
                            dtBuscarFamiliares = ConsultaPersonalVW("SELECT RELOJ,NOMBRES AS NOMBRE,ALTA,BAJA,RTRIM(COD_DEPTO) + ' - ' + RTRIM(NOMBRE_DEPTO) AS DEPARTAMENTO," & _
                                                                  " RTRIM(COD_PUESTO) + ' - ' + RTRIM(NOMBRE_PUESTO) AS PUESTO,PERSONALVW.COD_COMP,FOTO,'' AS CAMPOS_EXTRA" & _
                                                                  " FROM PERSONALVW " & _
                                                                  " WHERE (nivel_seguridad IS NULL OR nivel_seguridad <=" & NivelConsulta & ")", False)

                            BSFamiliares.DataSource = dtBuscarFamiliares

                            navFamiliares.BindingSource = BSFamiliares

                            txtRelojFamiliares.DataBindings.Add("Text", BSFamiliares, "Reloj")
                            txtNombreFamiliares.DataBindings.Add("Text", BSFamiliares, "nombre")
                            txtPuestoFamiliares.DataBindings.Add("Text", BSFamiliares, "puesto")
                            txtDeptoFamiliares.DataBindings.Add("Text", BSFamiliares, "departamento")
                            txtAltaFamiliares.DataBindings.Add("Text", BSFamiliares, "alta", True, DataSourceUpdateMode.Never, Nothing, "d")
                            txtBajaFamiliares.DataBindings.Add("Text", BSFamiliares, "baja", True, DataSourceUpdateMode.Never, "------", "d")
                            picFotoFamiliares.DataBindings.Add("ImageLocation", BSFamiliares, "foto")
                        End If

                        Cursor = Cursors.Default
                        txtBuscarFamiliares.Text = ""
                        txtBuscarFamiliares.Select()
                    Catch ex As Exception

                    End Try

                ElseIf rbExterno.Checked = True Then

                    '************************ DATOS PARA BUSQUEDA DE EXTERNOS *************************

                    Try
                        WizardConsultas.SelectedPage = WizardPageExternos
                        Application.DoEvents()
                        Cursor = Cursors.WaitCursor

                        If BSExternos.DataSource Is Nothing Then
                            dtBuscarExternos = sqlExecute(
                                "select id, rtrim(isnull(apaterno, '')) + ',' + rtrim(isnull(amaterno, '')) + ',' + rtrim(isnull(externos.nombre, '')) as nombres, " & _
                                "fha_nac, imss, compania, cias_externas.nombre as nombre_compania, alta from externos " & _
                                "left join cias_externas on cias_externas.cia = externos.compania", "sermed")

                            BSExternos.DataSource = dtBuscarExternos

                            NavExternos.BindingSource = BSExternos

                            dgExternos.DataSource = BSExternos

                            txtIdExternos.DataBindings.Add("Text", BSExternos, "id")
                            txtNombreExternos.DataBindings.Add("Text", BSExternos, "nombres")
                            txtCompaniaExternos.DataBindings.Add("Text", BSExternos, "nombre_compania")                            
                            txtAltaExternos.DataBindings.Add("Text", BSExternos, "alta", True, DataSourceUpdateMode.Never, Nothing, "d")
                        End If

                        Cursor = Cursors.Default
                        txtBuscarExternos.Text = ""
                        txtBuscarExternos.Select()
                    Catch ex As Exception

                    End Try

                End If

            Case WizardPageEmpleados.Name
                reloj = txtRelojEmpleados.Text
                If reloj <> "" Then
                    Dim frm As New frmAgregarConsultaEmp
                    frm.reloj = reloj
                    frm.ShowDialog()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Case WizardPageFamiliares.Name
                reloj = txtRelojFamiliares.Text
                If reloj <> "" Then
                    Dim frm As New frmAgregarConsultaFam
                    frm.reloj = reloj
                    If fam = "" Then
                        Try
                            fam = dgFamiliares.Item("ColumnID", 0).Value
                        Catch ex As Exception

                        End Try

                    End If
                    If fam <> "" Then
                        frm.fam = fam
                        frm.ShowDialog()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        If MessageBox.Show("El empleado seleccionado no tiene familiares registrados, ¿Desea agregar una consulta al empleado?", "Empleado sin familiares registrados", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                            reloj = txtRelojFamiliares.Text
                            If reloj <> "" Then
                                Dim _frm As New frmAgregarConsultaEmp
                                _frm.reloj = reloj
                                _frm.ShowDialog()
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                            Else
                                MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        End If
                    End If

                Else
                    MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Case WizardPageExternos.Name
                reloj = txtIdExternos.Text
                If reloj <> "" Then
                    Dim frm As New frmAgregarConsultaExt
                    frm.reloj = reloj
                    frm.ShowDialog()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

        End Select

    End Sub

    Private Sub Wizard1_BackButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WizardConsultas.BackButtonClick

        e.Cancel = True

        Select Case WizardConsultas.SelectedPage.Name
            Case WizardPageEmpleados.Name
                WizardConsultas.SelectedPage = WizardPageSeleccion
            Case WizardPageFamiliares.Name
                WizardConsultas.SelectedPage = WizardPageSeleccion
            Case WizardPageExternos.Name
                WizardConsultas.SelectedPage = WizardPageSeleccion
        End Select
    End Sub

    '********* BUSQUEDA DE PERSONAL
    Private Sub txtBusca_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarEmpleados.TextChanged
        Dim vl As String

        Try
            Dim dtSeleccion As New DataTable
            Dim vlAnt As String
            Dim vlDes As String
            Dim i As Integer
            dtSeleccion = dtBuscarEmpleados.Clone
            vl = txtBuscarEmpleados.Text.Replace("*", "%")
            vl = vl.Replace("'", "")
            i = vl.IndexOf("%")

            If i >= 0 Then
                vlAnt = vl.Substring(0, i)
                vlDes = vl.Substring(i + 1)

                vl = "(reloj LIKE '%" & vlAnt & "%' OR nombre LIKE '%" & vlAnt & "%') AND (" & _
                    "reloj LIKE '%" & vlDes & "%' OR nombre LIKE '%" & vlDes & "%')"
            Else
                vl = "reloj LIKE '%" & vl & "%' OR nombre LIKE '%" & vl & "%'"
            End If

            For Each dDato As DataRow In dtBuscarEmpleados.Select(vl)
                dtSeleccion.ImportRow(dDato)
            Next

            BSEmpleados.DataSource = dtSeleccion
            RevisaColoresEmpleados()

        Catch ex As Exception
            'MCR 26/OCT/2015
            'Cambio para evitar que "truene" cuando el usuario presione secuencias incorrectas
            'p.ej. *,*,
            MessageBox.Show("Se detectó un error al buscar un empleado que cumpla con la condición indicada. Favor de verificar." & vbCrLf & _
                             vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBuscarEmpleados.Text = ""
        End Try
    End Sub

    '*********** BUSQUEDA EMPLEADO / FAMILIAR
    Private Sub TextBoxBuscaFams_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarFamiliares.TextChanged
        Dim vl As String

        Try
            Dim dtSeleccion As New DataTable
            Dim vlAnt As String
            Dim vlDes As String
            Dim i As Integer
            dtSeleccion = dtBuscarFamiliares.Clone
            vl = txtBuscarFamiliares.Text.Replace("*", "%")
            vl = vl.Replace("'", "")
            i = vl.IndexOf("%")

            If i >= 0 Then
                vlAnt = vl.Substring(0, i)
                vlDes = vl.Substring(i + 1)

                vl = "(reloj LIKE '%" & vlAnt & "%' OR nombre LIKE '%" & vlAnt & "%') AND (" & _
                    "reloj LIKE '%" & vlDes & "%' OR nombre LIKE '%" & vlDes & "%')"
            Else
                vl = "reloj LIKE '%" & vl & "%' OR nombre LIKE '%" & vl & "%'"
            End If

            For Each dDato As DataRow In dtBuscarFamiliares.Select(vl)
                dtSeleccion.ImportRow(dDato)
            Next

            BSFamiliares.DataSource = dtSeleccion
            RevisaColoresFamiliares()

        Catch ex As Exception
            'MCR 26/OCT/2015
            'Cambio para evitar que "truene" cuando el usuario presione secuencias incorrectas
            'p.ej. *,*,
            MessageBox.Show("Se detectó un error al buscar un empleado que cumpla con la condición indicada. Favor de verificar." & vbCrLf & _
                             vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBuscarFamiliares.Text = ""
        End Try
    End Sub

    Private Sub txtRelojFamiliares_TextChanged(sender As Object, e As EventArgs) Handles txtRelojFamiliares.TextChanged
        Try
            Dim dtFamiliares As DataTable = sqlExecute("select familiares.*, familia.nombre as parentesco from familiares left join familia on familia.cod_familia = familiares.cod_familia where reloj = '" & txtRelojFamiliares.Text & "'")
            dgFamiliares.DataSource = dtFamiliares
        Catch ex As Exception

        End Try
    End Sub


    '*********** BUSQUEDA EXTERNOS
    Private Sub TextBoxBuscaExt_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarExternos.TextChanged
        Dim vl As String

        Try
            Dim dtSeleccion As New DataTable
            Dim vlAnt As String
            Dim vlDes As String
            Dim i As Integer
            dtSeleccion = dtBuscarExternos.Clone
            vl = txtBuscarExternos.Text.Replace("*", "%")
            vl = vl.Replace("'", "")
            i = vl.IndexOf("%")



            If i >= 0 Then
                vlAnt = vl.Substring(0, i)
                vlDes = vl.Substring(i + 1)

                vl = "(convert(id, 'System.String') LIKE '%" & vl & "%' or nombres LIKE '%" & vlAnt & "%' or nombre_compania like '%" & vlAnt & "%') AND (" & _
                    "convert(id, 'System.String') LIKE '%" & vl & "%' or nombres LIKE '%" & vlDes & "%' or nombre_compania like '%" & vlDes & "%')"
            Else
                
                vl = "convert(id, 'System.String') LIKE '%" & vl & "%' or nombres LIKE '%" & vl & "%' or nombre_compania like '%" & vl & "%'"

            End If

            For Each dDato As DataRow In dtBuscarExternos.Select(vl)
                dtSeleccion.ImportRow(dDato)
            Next

            BSExternos.DataSource = dtSeleccion            

        Catch ex As Exception
            'MCR 26/OCT/2015
            'Cambio para evitar que "truene" cuando el usuario presione secuencias incorrectas
            'p.ej. *,*,
            MessageBox.Show("Se detectó un error al buscar un empleado externo que cumpla con la condición indicada. Favor de verificar." & vbCrLf & _
                             vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBuscarFamiliares.Text = ""
        End Try

    End Sub


    Private Sub RevisaColoresEmpleados()
        Dim vl As String
        Try

            vl = txtBuscarEmpleados.Text.ToUpper.Trim
            If vl = "" Then vl = "*******"
            txtRelojEmpleados.BackColor = IIf(txtRelojEmpleados.Text.Contains(vl), Color.Yellow, SystemColors.Control)
            txtNombreEmpleados.BackColor = IIf(txtNombreEmpleados.Text.ToUpper.Contains(vl), Color.Yellow, SystemColors.Control)

        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub RevisaColoresFamiliares()
        Dim vl As String
        Try

            vl = txtBuscarFamiliares.Text.ToUpper.Trim
            If vl = "" Then vl = "*******"
            txtRelojFamiliares.BackColor = IIf(txtRelojFamiliares.Text.Contains(vl), Color.Yellow, SystemColors.Control)
            txtRelojFamiliares.BackColor = IIf(txtRelojFamiliares.Text.ToUpper.Contains(vl), Color.Yellow, SystemColors.Control)

        Catch ex As Exception
            Stop
        End Try
    End Sub


    Private Sub txtReloj_TextChanged(sender As Object, e As EventArgs) Handles txtRelojEmpleados.TextChanged
        reloj = txtRelojEmpleados.Text
    End Sub
    Private Sub DataGridViewX3_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFamiliares.CellClick
        fam = dgFamiliares.Item("ColumnID", e.RowIndex).Value
    End Sub

    Private Sub Wizard1_FinishButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WizardConsultas.FinishButtonClick
        ' e.Cancel = True

        Select Case WizardConsultas.SelectedPage.Name
            Case WizardPageSeleccion.Name
                If rbEmpleado.Checked = True Then
                    WizardConsultas.SelectedPage = WizardPageEmpleados
                    txtBuscarEmpleados.Select()
                ElseIf rbFamiliar.Checked = True Then
                    WizardConsultas.SelectedPage = WizardPageFamiliares
                    txtBuscarFamiliares.Select()
                ElseIf rbExterno.Checked = True Then
                    WizardConsultas.SelectedPage = WizardPageExternos
                    txtBuscarExternos.Select()
                End If
            Case WizardPageEmpleados.Name
                reloj = txtRelojEmpleados.Text
                If reloj <> "" Then
                    frmAgregarConsultaEmp.reloj = reloj
                    frmAgregarConsultaEmp.ShowDialog()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Case WizardPageFamiliares.Name
                reloj = txtRelojFamiliares.Text
                If reloj <> "" Then
                    frmAgregarConsultaFam.reloj = reloj
                    frmAgregarConsultaFam.fam = fam
                    frmAgregarConsultaFam.ShowDialog()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Case WizardPageExternos.Name
                reloj = txtIdExternos.Text
                If reloj <> "" Then
                    frmAgregarConsultaExt.reloj = reloj
                    frmAgregarConsultaExt.ShowDialog()
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

        End Select
    End Sub

    Private Sub Wizard1_CancelButtonClick(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles WizardConsultas.CancelButtonClick
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgTabla_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellDoubleClick
        Try
            Dim reloj As String = dgTabla.Rows(e.RowIndex).Cells("ColReloj").Value
            frmAgregarConsultaEmp.reloj = reloj
            frmAgregarConsultaEmp.ShowDialog()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridViewX3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFamiliares.CellDoubleClick
        Try
            reloj = txtRelojFamiliares.Text
            Dim idfld As String = dgFamiliares.Rows(e.RowIndex).Cells("ColumnID").Value

            If reloj <> "" Then
                frmAgregarConsultaFam.reloj = reloj
                frmAgregarConsultaFam.fam = idfld
                frmAgregarConsultaFam.ShowDialog()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MessageBox.Show("El reloj no puede quedar en blanco. Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnCatálogoExternos.Click
        frmCatExternos.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        frmCatExternos.ControlBox = False
        frmCatExternos.ShowDialog()
        id = frmCatExternos.id
        frmCatExternos.Dispose()

        txtBuscarExternos.Text = id
    End Sub

    Private Sub txtBajaEmp_TextChanged(sender As Object, e As EventArgs) Handles txtBajaEmpleados.TextChanged
        Dim EsBaja As Boolean

        Try
            EsBaja = txtBajaEmpleados.Text <> "------"
        Catch ex As Exception
            EsBaja = False
        Finally
            lblEstadoEmpleados.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstadoEmpleados.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBuscarEmpleados.Focus()
        End Try
    End Sub

    Private Sub txtBajaFam_TextChanged(sender As Object, e As EventArgs) Handles txtBajaFamiliares.TextChanged
        Dim EsBaja As Boolean

        Try
            EsBaja = txtBajaFamiliares.Text <> "------"
        Catch ex As Exception
            EsBaja = False
        Finally
            lblEstadoFamiliares.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstadoFamiliares.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            txtBuscarFamiliares.Focus()
        End Try
    End Sub

    
End Class